using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LGC.Business;
using LGC.Business.Parametre;
using LGC.UI.Parametre;
using LGC.Business.GestionDeStock;
using LGC.Business.GestionDesAnalyses;
using LGC.Business.GestionDeLaCaisse;
using LGG.Business;
using LGC.Business.GestionUtilisateur;
using System.IO.Ports;
using System.IO;
using QRCoder;
using Microsoft.Win32;

namespace LGG.UI.Parametre
{
    public partial class Frm_AnnulationDemandes : Telerik.WinControls.UI.RadForm
    {
        public Fournisseur oFournisseur = new Fournisseur();
        List<DemandeAnalyse> olstDemandeAnalyse = new List<DemandeAnalyse>();
        public string numCommande = "";
        public decimal total = 0;
        Facture oFacture = new Facture();
        string[] retour33h;
        string codeQR = "";
        Image image = null;
        string operateur = "";
        string ifuAcheteur = "", nomAcheteur = "";
        int AIB = 0;
        int idOperateur = 0;
        SerialPort serialPort = new SerialPort();

        public Frm_AnnulationDemandes()
        {
            
            InitializeComponent();
        }

       

        private void Frm_ListePartenaire_Load(object sender, EventArgs e)
        {
            meb_DateDebut.Value = DateTime.Now;
            meb_DateFin.Value = DateTime.Now;
            btn_Actualiser_Click(null, null);
            //gv_Liste.Columns["MotifAnnulation"].ReadOnly = true;
        }

        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            
                
        }

        private void btn_Inserer_Click(object sender, EventArgs e)
        {
            try
            {
                #region controles

                for (int i = 0; i < gv_Liste.RowCount; i++)
                {
                    if (Convert.ToBoolean(gv_Liste.Rows[i].Cells["chk"].Value) == true)
                    {
                        oFacture = Facture.Liste(null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null, Convert.ToDecimal(gv_Liste.Rows[i].Cells["NumDemande"].Value), null, null)[0];
                        if (oFacture.IdFactureAssurance != "")
                        {
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Impossible d'annuler la demande N°" + Convert.ToString(gv_Liste.Rows[i].Cells["NumDemande"].Value) + " \n car elle est prise en compte sur la note d'honoraire à envoyer à l'assurance",
                                                    "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                            return;
                        }
                        if (oFacture.IdFacturePartenaire != "")
                        {
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Impossible d'annuler la demande N°" + Convert.ToString(gv_Liste.Rows[i].Cells["NumDemande"].Value) + " \n car elle est prise en compte sur la note d'honoraire à envoyer au partenaire",
                                                    "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                            return;
                        }
                        if (oFacture.MontantRestantAPayer == 0 && oFacture.IdFacturePartenaire == "")
                        {
                            if(Convert.ToDecimal(gv_Liste.Rows[i].Cells["TauxCouverture"].Value) == 0)                          

                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, "Impossible d'annuler la demande N°" + Convert.ToString(gv_Liste.Rows[i].Cells["NumDemande"].Value) + " \n car elle a déjà fait l'objet d'un règlement",
                                                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                                return;
                            }

                            if (Convert.ToDecimal(gv_Liste.Rows[i].Cells["TauxCouverture"].Value) != 100)
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, "Impossible d'annuler la demande N°" + Convert.ToString(gv_Liste.Rows[i].Cells["NumDemande"].Value) + " \n car elle a déjà fait l'objet d'un règlement",
                                                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                                return;
                            }
                        }
                        
                       


                        switch (Convert.ToString(gv_Liste.Rows[i].Cells["niveauExecution"].Value))
                        {
                            case "PRELEVEMENT":
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, "Impossible d'annuler la demande N°" + Convert.ToString(gv_Liste.Rows[i].Cells["NumDemande"].Value) + " \n car elle a déjà fait l'objet d'un prélèvement",
                                                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                                return;
                                break;
                            case "VALIDATION DE RESULTAT":
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, "Impossible d'annuler la demande N°" + Convert.ToString(gv_Liste.Rows[i].Cells["NumDemande"].Value) + " \n car les résultats sont en cours de validation",
                                                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                                return;
                                break;
                            case "RESULTAT VALIDE":
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, "Impossible d'annuler la demande N°" + Convert.ToString(gv_Liste.Rows[i].Cells["NumDemande"].Value) + " \n car les résultats sont déja disponibles",
                                                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                                return;
                                break;
                            case "EDITION DE RESULTAT":
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, "Impossible d'annuler la demande N°" + Convert.ToString(gv_Liste.Rows[i].Cells["NumDemande"].Value) + " \n car les résultats sont déja disponibles",
                                                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                                return;
                                break;
                        }

                        if (Convert.ToString(gv_Liste.Rows[i].Cells["MotifAnnulation"].Value) == "")
                        {
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Veuillez renseigner le motif d'annulation de la demande N°" + Convert.ToString(gv_Liste.Rows[i].Cells["NumDemande"].Value),
                                                    "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                            return;
                        }

                    }
                }

                
                for (int i = 0; i < gv_Liste.RowCount; i++)
                {
                    if (Convert.ToBoolean(gv_Liste.Rows[i].Cells["chk"].Value) == true)
                    {

                        DemandeAnalyse oDemandeAnalyse = olstDemandeAnalyse.Find(x => x.NumDemande == Convert.ToDecimal(gv_Liste.Rows[i].Cells["NumDemande"].Value));

                        #region vérifier si cette demande a fait l'objet d'une normalisation
                        if(oDemandeAnalyse.Reference!="")
                        {
                            #region Envoi des informations à la DGI et édition de la facture Normalisée
                            //string port = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\HARDWARE\\DEVICEMAP\\SERIALCOMM", "\\Device\\Serial0", " ");
                            //string port1 = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\HARDWARE\\DEVICEMAP\\SERIALCOMM", "\\Device\\USBSER000", " ");

                            // Récupérer la liste des ports.
                            string[] ports = SerialPort.GetPortNames();
                            SerialPort serialPort = new SerialPort();
                            byte seq = (byte)0;
                            bool C1Valide = false;

                            try
                            {
                                try
                                {
                                /* ETAT DE MCF*/

                                // Parcours de la liste.
                                #region MyRegion
                                //foreach (string port in ports)
                                //{
                                //    try
                                //    {
                                //        SerialPort serialPort1 = new SerialPort(port, 115200);

                                //        if (serialPort1 != null)
                                //        {
                                //            //serialPort.Close();
                                //            try
                                //            {
                                //                serialPort1.Open();

                                //                if (!serialPort1.IsOpen)
                                //                    continue;
                                //                else
                                //                {
                                //                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                //                    Commandes.SEQ_INT++;

                                //                    try
                                //                    {
                                //                        C1Valide = Commandes.C1h(serialPort1, seq);
                                //                    }
                                //                    catch (Exception ex)
                                //                    {
                                //                        C1Valide = false;
                                //                    }

                                //                    if (!C1Valide)
                                //                    {
                                //                        serialPort1.Close();
                                //                        continue;
                                //                    }
                                //                }

                                //                if (C1Valide)
                                //                {
                                //                    serialPort = serialPort1;
                                //                    break;
                                //                }
                                //            }
                                //            catch (Exception ex)
                                //            {
                                //                serialPort1.Close();
                                //                continue;
                                //            }
                                //        }
                                //    }
                                //    catch (Exception ex)
                                //    {

                                //        continue;
                                //    }
                                //} 
                                #endregion



                                //if (serialPort != null && !serialPort.IsOpen)
                                //    serialPort.Open();

                                
                            string port = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\HARDWARE\\DEVICEMAP\\SERIALCOMM", "\\Device\\USBSER000", " ");
                            serialPort = new SerialPort(port, 115200, Parity.None, 8, StopBits.One);
                            serialPort.Open();


                            do
                            {

                                seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                Commandes.SEQ_INT++;

                                C1Valide = Commandes.C1h(serialPort, seq);

                                if (!C1Valide)
                                {

                                    RadMessageBox.ThemeName = this.ThemeName;
                                    RadMessageBox.Show(this, "[======ECHEC DE CONNEXION AU PC !======]",
                                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);

                                    serialPort.Close();
                                    return;

                                }
                                else
                                {
                                    //CurrentInfo.serialPort = serialPort;
                                    //RadMessageBox.ThemeName = this.ThemeName;
                                    //RadMessageBox.Show(this, "[======CONNEXION EFFECTUEE AVEC SUCCES !======]",
                                    //    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);

                                    #region récupérer les infos sur le contribuables
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    CurrentUser.nom = Commandes._2Bh(serialPort, seq, "I0");
                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    CurrentUser.adresse = Commandes._2Bh(serialPort, seq, "I1");

                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    CurrentUser.ville = Commandes._2Bh(serialPort, seq, "I2");

                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    CurrentUser.telephone = Commandes._2Bh(serialPort, seq, "I3");

                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    CurrentUser.mail = Commandes._2Bh(serialPort, seq, "I4");
                                    #endregion

                                }


                            } while (!C1Valide);
                        }
                        catch
                        {
                            if (serialPort != null)
                            serialPort.Close();
                        }

                                /* FIN ETAT DE MCF*/

                                if (C1Valide)
                                {
                                    #region Détermination de l'id et du nom de l'opérateur
                                    {
                                        Utilisateur user = Utilisateur.Liste(null, null, null, null, null, null, null, null, null, CurrentUser.UserLogin.Trim(), null, null, null, null, null, null, null, false, null)[0];

                                        idOperateur = Convert.ToInt32(user.NumeroUtilisateur);
                                        operateur = (user.NomUtilisateur + " " + user.PrenomUtilisateur).Length > 32 ? (user.NomUtilisateur + " " + user.PrenomUtilisateur).Substring(0, 32) : (user.NomUtilisateur + " " + user.PrenomUtilisateur);
                                        ifuAcheteur = "";
                                        nomAcheteur = oDemandeAnalyse.Patient;                                        
                                      
                                    }
                                    #endregion


                                    #region C0h (OUVRIR FACTURE)
                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    string message = Commandes.testC0h(serialPort, seq, idOperateur, operateur, ifuAcheteur,
                                        nomAcheteur, Convert.ToString(AIB), "FA", oDemandeAnalyse.Reference.Trim());

                                    if (message != null && message.Length == 0)
                                    {
                                        RadMessageBox.ThemeName = this.ThemeName;
                                        RadMessageBox.Show(this, "Facture non ouverte",
                                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                        #region 38h (FERMER FACTURE)
                                        Commandes.SEQ_INT++;
                                        seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                        message = Commandes.test38h(serialPort, seq);
                                        #endregion

                                        serialPort.Close();
                                        return;
                                    }

                                    if (message != null && message.Contains("E:"))
                                    {
                                        RadMessageBox.ThemeName = this.ThemeName;
                                        RadMessageBox.Show(this, message.Split(':')[1],
                                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                        #region 38h (FERMER FACTURE)
                                        Commandes.SEQ_INT++;
                                        seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                        message = Commandes.test38h(serialPort, seq);
                                        #endregion

                                        serialPort.Close();
                                        return;
                                    }
                                    #endregion
                                    List<AnalyseDemande> lstAnalyseDemande = AnalyseDemande.Liste(null, oDemandeAnalyse.NumDemande, null, null, null, null, null, null, null, null, false, null, null);
                                    decimal tauxAssurance = ((100 - oDemandeAnalyse.TauxCouverture) / 100);
                                    foreach(AnalyseDemande mligne in lstAnalyseDemande)
                                    {

                                        decimal prixTTC = decimal.Round(Convert.ToDecimal(mligne.PrixApresRemise) * tauxAssurance, 0, MidpointRounding.AwayFromZero);
                                        
                                        //Analyse objP = Analyse.FindFirst(Convert.ToString(mligne.CodeAnalyse.Trim()));
                                        string libelleAnalyse = Convert.ToString(mligne.LibelleAnalyse.Trim());

                                        //AnalyseDemande objAD = AnalyseDemande.Liste(Convert.ToString(gv_Analyses.Rows[i].Cells["CodeAnalyse"].Value), objDem.NumDemande, null, null, null, null, null, null, null, null, false, null, null)[0];

                                        string quantite = Convert.ToString(Math.Abs(decimal.Round(Convert.ToDecimal(mligne.Qte), 3))).Replace(",", ".");

                                        #region 31h (INSCRIRE DES ARTICLES)

                                        libelleAnalyse = libelleAnalyse.Length > 60
                                            ? Fonction.RemplacerCaracSpec(libelleAnalyse.Substring(0, 60)) :
                                                    Fonction.RemplacerCaracSpec(libelleAnalyse);
                                        List<byte> article = new List<byte>();
                                        article = new List<Byte>(Encoding.Default.GetBytes(libelleAnalyse));
                                        article.Add(0x09);
                                        string lettre = "A";
                                        article.Add(((byte)Convert.ToInt32(lettre[0])));
                                        article.AddRange((Encoding.UTF8.GetBytes(Convert.ToString(prixTTC))));
                                        string star = "*";
                                        article.Add((byte)Convert.ToInt32(star[0]));
                                        article.AddRange((Encoding.UTF8.GetBytes(quantite)));

                                        #region gestion des remises
                                        if (Convert.ToDecimal(mligne.RemiseAnalyse) != 0)
                                        {
                                            string remise = "remise de " + Convert.ToDecimal(mligne.RemiseAnalyse);
                                            decimal prixOrig = Convert.ToDecimal(mligne.PrixNormal);
                                            article.Add(0x09);
                                            article.AddRange((Encoding.UTF8.GetBytes(Convert.ToString(prixOrig))));
                                            string virgule = ",";
                                            article.Add((byte)Convert.ToInt32(virgule[0]));
                                            article.AddRange((Encoding.Default.GetBytes(remise)));
                                        }
                                        #endregion

                                        Commandes.SEQ_INT++;
                                        seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                        message = Commandes.C31h(serialPort, seq, article);
                                        if (message.Split(',').Length == 4)
                                        {
                                            #region 33h (LIRE SOUS TOTAL)
                                            Commandes.SEQ_INT++;
                                            seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                            message = Commandes.test33h(serialPort, seq);
                                            if (Convert.ToString(message[message.Length - 1]).Trim() == ",")
                                            {
                                                message = message.Substring(0, message.Length - 1);
                                            }
                                            if (message.Split(',').Length == 15)
                                            {

                                            }
                                            else
                                            {
                                                RadMessageBox.ThemeName = this.ThemeName;
                                                RadMessageBox.Show(this, "Impossible de déterminer le sous total pour l'article " + Convert.ToString(mligne.LibelleAnalyse).Trim(),
                                                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                                #region 38h (FERMER FACTURE)
                                                Commandes.SEQ_INT++;
                                                seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                                message = Commandes.test38h(serialPort, seq);
                                                #endregion

                                                serialPort.Close();
                                                return;
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            RadMessageBox.ThemeName = this.ThemeName;
                                            RadMessageBox.Show(this, "Impossible d'inscrire l'article " + Convert.ToString(mligne.LibelleAnalyse).Trim(),
                                                CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                            #region 38h (FERMER FACTURE)
                                            Commandes.SEQ_INT++;
                                            seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                            message = Commandes.test38h(serialPort, seq);
                                            #endregion

                                            serialPort.Close();
                                            return;
                                        }
                                        #endregion
                                    }

                                    if (Convert.ToString(message[message.Length - 1]).Trim() == ",")
                                    {
                                        message = message.Substring(0, message.Length - 1);
                                    }

                                    if (message.Split(',').Length == 15)
                                    {
                                        //if (Convert.ToDecimal(message.Split(',')[0]) != Convert.ToDecimal(meb_MontantTotal.Value))
                                        //{
                                        //    RadMessageBox.ThemeName = this.ThemeName;
                                        //    RadMessageBox.Show(this, "Montant Facture [" + Convert.ToDecimal(meb_MontantClient.Value) + "] != Montant Mcf [" + Convert.ToDecimal(message.Split(',')[0]) + "]",
                                        //        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                        //    #region 38h (FERMER FACTURE)
                                        //    Commandes.SEQ_INT++;
                                        //    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                        //    message = Commandes.test38h(serialPort, seq);
                                        //    #endregion

                                        //    serialPort.Close();
                                        //    return;
                                        //}

                                        #region 35h (CONFIRMER FACTURE)
                                        List<ReglementClient> lstReglement = ReglementClient.Liste(null, null, oDemandeAnalyse.NumDemande, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);
                                        Commandes.SEQ_INT++;
                                        seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);

                                        if (lstReglement.Count == 0)
                                        {
                                            message = Commandes.test35h(serialPort, seq, "E" + Convert.ToString((Convert.ToDecimal(oDemandeAnalyse.MontantBrut))));
                                            while (message.Trim().Contains("E"))
                                            {
                                                Commandes.SEQ_INT++;
                                                seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                                message = Commandes.test35h(serialPort, seq, "E" + Convert.ToString((Convert.ToDecimal(oDemandeAnalyse.MontantBrut))));
                                            }
                                        }
                                        else
                                        {
                                            foreach (ReglementClient unReglement in lstReglement)
                                            {
                                                Commandes.SEQ_INT++;
                                                seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                                message = Commandes.test35h(serialPort, seq, unReglement.ValeurMCF + Convert.ToString((decimal.Round(unReglement.Montant))));
                                                while (message.Trim().Contains("E"))
                                                {
                                                    Commandes.SEQ_INT++;
                                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                                    message = Commandes.test35h(serialPort, seq, unReglement.ValeurMCF + Convert.ToString((decimal.Round(unReglement.Montant))));
                                                }
                                            }
                                        }
                                        #endregion

                                        if (message.Trim().Contains("R"))
                                        {
                                            #region Traitement de la reponse de 35h

                                            #region 38h (FERMER FACTURE)
                                            Commandes.SEQ_INT++;
                                            seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                            message = Commandes.test38h(serialPort, seq);
                                            #endregion

                                            if (message.Split(',').Length == 6)
                                            {
                                                RadMessageBox.ThemeName = this.ThemeName;
                                                MessageBox.Show(this, "La signature n'a pas été retournée car la facture est considérée comme annulée",
                                                    CurrentUser.LogicielHote, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                #region 38h (FERMER FACTURE)
                                                Commandes.SEQ_INT++;
                                                seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                                message = Commandes.test38h(serialPort, seq);
                                                #endregion

                                                serialPort.Close();
                                                return;
                                            }
                                            if (message.Split(',').Length == 7)
                                            {
                                                codeQR = "F;" + message.Split(',')[4] + ";" + message.Split(',')[6] + ";" + message.Split(',')[5] + ";" + message.Split(',')[3];

                                                #region génération de QRCode

                                                string DATA = codeQR;
                                                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                                                QRCodeData qrCodeData = qrGenerator.CreateQrCode(DATA, QRCodeGenerator.ECCLevel.M);
                                                QRCode qrCode = new QRCode(qrCodeData);
                                                //Bitmap qrCodeImage = qrCode.GetGraphic(20);

                                                System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                                                imgBarCode.Height = 150;
                                                imgBarCode.Width = 150;

                                                using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                                                {
                                                    using (MemoryStream ms = new MemoryStream())
                                                    {
                                                        qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                                        byte[] byteImage = ms.ToArray();
                                                        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);

                                                        Panel pnl_codeQR = new Panel();
                                                        pnl_codeQR.BackgroundImage = qrCodeImage;

                                                        #region Sauvegarde dans la table T_DonneesMCF
                                                        try
                                                        {
                                                            DonneesMCF obj = new DonneesMCF();
                                                            obj.IdFacture = Facture.FindFirst(null, (oDemandeAnalyse.NumDemande)).IdFacture.Trim()+"_R";
                                                            obj.Fc = Convert.ToDecimal(message.Split(',')[0]);
                                                            obj.Tc = Convert.ToDecimal(message.Split(',')[1]);
                                                            obj.Ft = message.Split(',')[2];
                                                            obj.Sig = Fonction.Signature(Convert.ToString(message.Split(',')[6]));
                                                            obj.Compteur = Convert.ToString(message.Split(',')[0]) + "/" + Convert.ToString(message.Split(',')[1])
                                                                + "" + Convert.ToString(message.Split(',')[2]);
                                                            obj.DateEtHeure = Fonction.dateSignature(message.Split(',')[3]);
                                                            obj.CodeQR = codeQR;
                                                            obj.Nim = message.Split(',')[4];
                                                            obj.CodeQRImage = byteImage;
                                                            obj.Adresse = CurrentUser.adresse;
                                                            obj.Mail = CurrentUser.mail;
                                                            obj.IFU = Commandes.IFU;
                                                            obj.Nom = CurrentUser.nom;
                                                            obj.Telephone = CurrentUser.telephone;
                                                            obj.RCCM = "";
                                                            obj.Ville = CurrentUser.ville;
                                                            obj.Reference = "";
                                                            obj.Insert();
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            RadMessageBox.ThemeName = this.ThemeName;
                                                            RadMessageBox.Show(this, ex.Message,
                                                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                                        }
                                                        finally
                                                        {

                                                        }
                                                        #endregion
                                                    }
                                                }
                                                #endregion
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            RadMessageBox.ThemeName = this.ThemeName;
                                            MessageBox.Show(this, "Cette facture ne peut etre confirmée",
                                                CurrentUser.LogicielHote, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            #region 38h (FERMER FACTURE)
                                            Commandes.SEQ_INT++;
                                            seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                            message = Commandes.test38h(serialPort, seq);
                                            #endregion

                                            serialPort.Close();
                                            return;
                                        }
                                    }
                                }

                                serialPort.Close();

                                //RadMessageBox.ThemeName = this.ThemeName;
                                //RadMessageBox.Show(this, "NORMALISATION TERMINEE AVEC SUCCES",
                                //    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                            catch (Exception ex)
                            {
                                if (serialPort != null)
                                    serialPort.Close();

                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, ex.Message,
                                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);

                                return;
                            }
                            #endregion
                        }
                        #endregion

                        oDemandeAnalyse.DateAnnulation = DateTime.Now;
                        oDemandeAnalyse.MotifAnnulation = Convert.ToString(gv_Liste.Rows[i].Cells["MotifAnnulation"].Value);
                        oDemandeAnalyse.EstAnnulee = true;
                        oDemandeAnalyse.Update();
                    }
                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Annulation(s) enregistrée(s) avec succès",
                                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                btn_Actualiser_Click(null, null);
                #endregion
            }
            catch { }
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            olstDemandeAnalyse=DemandeAnalyse.Liste(meb_DateDebut.Value, meb_DateFin.Value);
            bds_Demandes.DataSource = olstDemandeAnalyse.FindAll(x => x.EstAnnulee == false);
        }

        private void gv_Liste_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 &&
            //        e.Column.Name == "chk" && Convert.ToBoolean(gv_Liste.Rows[e.RowIndex].Cells["chk"].Value) == true)
            //{
            //    gv_Liste.Rows[e.RowIndex].Cells["MotifAnnulation"].ReadOnly = false;
            //}
            //else
            //{
            //    gv_Liste.Rows[e.RowIndex].Cells["MotifAnnulation"].ReadOnly = true;
            //    gv_Liste.Rows[e.RowIndex].Cells["MotifAnnulation"].Value = "";
            //}
        }

        

        
    }
}
