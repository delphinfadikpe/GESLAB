using LGC.Business;
using LGC.Business.GestionDeLaCaisse;
using LGC.Business.GestionDesAnalyses;
using LGC.Business.GestionUtilisateur;
using LGC.Business.Impressions;
using LGC.Business.Parametre;
using LGC.UI;
using LGC.UI.Impressions;
using LGG.Business;
using LGG.UI.Parametre;
using Microsoft.Win32;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace LGG.UI.GestionDeLaCaisse
{
    public partial class Frm_FacturePartenaire : Telerik.WinControls.UI.RadForm
    {

        #region declarations
        public List<FacturePartenaire> lstFactureAssurance = new List<FacturePartenaire>();
        public List<Facture > lstAncienneFacture = new List<Facture>();
        public List<Facture > lstFacture = new List<Facture>();
        public List<Partenaires> lstPartenaire = new List<Partenaires>();
        public bool nouveau = false;
        public bool nouveauLivraison = false;
        string sortie;
        string[] message;
        int ligne = 0;       
        Partenaires oPartenaire = new Partenaires();
        public List<PaiementRistourne> lstPaiementRistourne = new List<PaiementRistourne>();

        string codeQR = "";
        Image image = null;
        string operateur = "";
        string ifuAcheteur = "", nomAcheteur = "";
        int AIB = 0;
        int idOperateur = 0;
        decimal montant = 0;
        private GridViewSpreadExport spreadExporter;
        #endregion


        #region Autres
        private void Viderchamp()
        {

            bds_FactureClients.DataSource = new List<Facture>();           
            txt_Partenaire.Text = "";           
            meb_numero.Text = "EN CREATION";
            dtp_date.Value = DateTime.Now;
            msk_Ristourne.Value = 0;
            chk_PayerRistourne.Checked = false;
            dtp_DateDebut.Value = DateTime.Now;
            dtp_DateDeFin.Value = DateTime.Now;
        }

        private void Detailler(FacturePartenaire obj)
        {
            meb_numero.Text = obj.IdFacture;
            txt_Partenaire.Text = obj.Partenaire;
            bds_FactureClients.DataSource = Facture.Liste(null, null, null, null, null, null, null, null, obj.IdFacture.Trim(), null, null, null, null, null, false, null, null, null, null);
            dtp_date.Value = obj.DateFacture;
            dtp_DateDebut.Value = obj.DateDebut;
            dtp_DateDeFin.Value = obj.DateFin;
            txt_NumPolice.Text = obj.NumPolice;
            lstPartenaire = Partenaires.Liste(obj.IdPersonne, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,null,null,  false, null);
            oPartenaire = lstPartenaire.Count != 0 ? lstPartenaire[0] : null;
            txt_Partenaire.Text = obj.Partenaire;
            txt_NB.Text = obj.Nb;
            #region affichage de la ristourne
            try
            {
                chk_PayerRistourne.Checked = true;
                msk_Ristourne.Value = PaiementRistourne.Liste(null, null, null, null, null, null, obj.IdFacture.Trim(), null, null, null, null, null, false, null)[0].MontantRistourne;
            }
            catch
            {
                chk_PayerRistourne.Checked = false;
                msk_Ristourne.Value = 0;
            }
            #endregion
        }

        private void ChargerDonnes(FacturePartenaire obj)
        {
            Viderchamp();

            bds_Facture.DataSource = FacturePartenaire.Liste(null, null, null, null, null, null, null,null, null, null, null, null, null, null, false, null);
           
            if (obj != null)
            {
                int i = 0;
                foreach (FacturePartenaire ligne in bds_Facture.List as List<FacturePartenaire>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_Facture.Position = i;
                        break;
                    }
                    else
                        i++;
                }
            }
        }
        
        private void Bloquerdebloquer(bool etat)
        {
           
            gv_Liste.Enabled = etat;
            btn_Nouveau.Visible = etat;
            btn_Modifier.Visible = etat;
            btn_Annuler.Visible = !etat;
            btn_Enregistrer.Visible = !etat;
            btn_Supprimer.Enabled = etat;
            btn_Actualiser.Enabled = etat;
            dtp_date.ReadOnly = CurrentUser.OUtilisateur.AutoriseDateAnterieur == true ? false : true;
           gb_Periode.Enabled=!etat;
           btn_choixPartenaire.Enabled = !etat;
           txt_NumPolice.ReadOnly = etat;
           txt_NB.ReadOnly = etat;
           msk_Ristourne.ReadOnly = true;
        }

        private void constituerObjet(FacturePartenaire obj)
        {
           obj.DateDebut=dtp_DateDebut.Value.Date;
            obj.DateFin=dtp_DateDeFin.Value.Date;
            obj.DateFacture=dtp_date.Value.Date;
            obj.Nb = txt_NB.Text.Trim();
            obj.IdPersonne=oPartenaire.IdPersonne;
            obj.MontantFacture=calculMontant();
            obj.MontantRestantAPayer=calculMontant();
            obj.TypeFacture="";
            obj.NumPolice = txt_NumPolice.Text;
            obj.AReçuRistourne = chk_PayerRistourne.Checked;
            obj.Objet = "Sous traitance du " + Convert.ToDateTime(dtp_DateDebut.Value.Date).ToShortDateString() + " AU " + Convert.ToDateTime(dtp_DateDeFin.Value.Date).ToShortDateString();
        }
     
        private decimal calculMontant()
        {
            decimal montant=0;
            for(int i=0;i<gv_FactureClients.RowCount;i++)
            {
                if (Convert.ToBoolean(gv_FactureClients.Rows[i].Cells["estSurComptePartenaire"].Value) == true)
                {
                    montant += Convert.ToDecimal(gv_FactureClients.Rows[i].Cells["MontantBase"].Value);
                }
            }
            return montant;

        }

        private decimal calculBasePourRistourne()
        {
            decimal montant = 0;
            for (int i = 0; i < gv_FactureClients.RowCount; i++)
            {
                
                {
                    montant += Convert.ToDecimal(gv_FactureClients.Rows[i].Cells["MontantBase"].Value);
                }
            }
            return montant;

        }

        private decimal calculRistourne()
        {
            return calculBasePourRistourne()*oPartenaire.TauxRistourne/100;
        }

        private void AfficherFacture(bool avecSynthese)
        {
            if (gv_Liste.SelectedRows != null &&
                gv_Liste.SelectedRows.Count != 0)
            {
                List<DonneesMCF> olstDonneesMCF = new List<DonneesMCF>();
                olstDonneesMCF = DonneesMCF.Liste(((FacturePartenaire)bds_Facture.Current).IdFacture, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                  null, null, null, null, null, false, null);


                decimal montTot = 0;
                DataTable dt = null;
                string montEnLettre = "";
                dt = Rapport.FacturePArtenaire(((FacturePartenaire)bds_Facture.Current).IdFacture);

                TR_FacturePartenaire rpt = new TR_FacturePartenaire();
                rpt.objectDataSource1.DataSource = dt;
                rpt.DataSource = rpt.objectDataSource1;
                try
                {
                    rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                }
                catch { }
                if (olstDonneesMCF.Count != 0)
                {
                    rpt.pnl_MCF.Visible = true;
                    rpt.txt_Compteur.Visible = true;
                    rpt.txt_dateEtHeure.Visible = true;
                    rpt.txt_sig.Visible = true;
                    rpt.pb_QRCode.Visible = true;
                    rpt.lbl_Compteurs.Visible = true;
                    rpt.lbl_NIM.Visible = true;
                    rpt.lbl_Heure.Visible = true;
                    rpt.lbl_Operateur.Visible = true;
                    rpt.txt_Operateur.Visible = true;

                    Utilisateur user = Utilisateur.Liste(null, null, null, null, null, null, null, null, null, ((FacturePartenaire)bds_Facture.Current).UserLogin.Trim(), null, null, null, null, null, null, null, false, null)[0];

                    idOperateur = Convert.ToInt32(user.NumeroUtilisateur);
                    operateur = (user.NomUtilisateur + " " + user.PrenomUtilisateur).Length > 32 ? (user.NomUtilisateur + " " + user.PrenomUtilisateur).Substring(0, 32) : (user.NomUtilisateur + " " + user.PrenomUtilisateur);

                    rpt.txt_Operateur.Value = idOperateur.ToString() + "-" + operateur;

                    rpt.txt_nim.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Nim : "Aucune donnée";
                    rpt.txt_Compteur.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Compteur : "Aucune donnée";
                    rpt.txt_dateEtHeure.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].DateEtHeure : "Aucune donnée";
                    rpt.txt_sig.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Sig : "Aucune donnée";
                }
                else
                {
                    rpt.lbl_Operateur.Visible = false;
                    rpt.txt_Operateur.Visible = false;
                    rpt.pnl_MCF.Visible = false;
                    rpt.txt_Compteur.Visible = false;
                    rpt.txt_dateEtHeure.Visible = false;
                    rpt.txt_sig.Visible = false;
                    rpt.pb_QRCode.Visible = false;
                    rpt.lbl_Compteurs.Visible = false;
                    rpt.lbl_NIM.Visible = false;
                    rpt.lbl_Heure.Visible = false;
                    rpt.txt_nim.Value = "";
                    rpt.txt_Compteur.Value = "";
                    rpt.txt_dateEtHeure.Value = "";
                    rpt.txt_sig.Value = "";
                }
                rpt.txt_Entete.Value = "POINT DES PRESTATIONS DU LABORATOIRE SUR LA PERIODE DU " + Convert.ToDateTime(gv_Liste.SelectedRows[0].Cells["DateDebut"].Value).ToShortDateString() + " AU " + Convert.ToDateTime(gv_Liste.SelectedRows[0].Cells["DateFin"].Value).ToShortDateString();
                rpt.txt_NomApplication.Value = "GESLAB";
                rpt.txt_Directeur.Value ="19 "+CurrentUser.OSociete.Directeur /*CurrentUser.OUtilisateur.NumeroUtilisateur + "       " + CurrentUser.OUtilisateur.NomUtilisateur + " " + CurrentUser.OUtilisateur.PrenomUtilisateur*/;
                rpt.lbl_Profil.Value ="LE DIRECTEUR GENERAL"/* CurrentUser.OProfil == null ? "CAISSE" : CurrentUser.OProfil.LibelleProfil*/;
                rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                    CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                rpt.pb_QRCode.Value = null;
                rpt.pnl_Synthèse.Visible = avecSynthese;
                rpt.txt_DateFacture.Value = string.Format("{0:D}", ((FacturePartenaire)bds_Facture.Current).DateFacture);
                rpt.txt_NumFActure.Value = Convert.ToString(gv_Liste.SelectedRows[0].Cells["IdFacture"].Value);
                if (olstDonneesMCF != null && olstDonneesMCF.Count > 0 && olstDonneesMCF[0].CodeQRImage != null)
                {
                    using (Stream imgStr = new MemoryStream(olstDonneesMCF[0].CodeQRImage))
                    {
                        rpt.pb_QRCode.Value = System.Drawing.Image.FromStream(imgStr);
                    }
                }
                Frm_ReportViewer frm = new Frm_ReportViewer("FACTURE PARTENAIRE", rpt);
                frm.MdiParent = Application.OpenForms["Frm_Menu"];
                frm.Show();
            }
        }

        private void renderer_WorkbookCreated(object sender, WorkbookCreatedEventArgs e)
        {
            Worksheet worksheet = e.Workbook.ActiveWorksheet;
            worksheet.Columns[worksheet.UsedCellRange].AutoFitWidth();
        }
        #endregion

    #region Formulaires
        public Frm_FacturePartenaire()
        {
            InitializeComponent();
        }
        private void Frm_FactureAssurance_Load(object sender, EventArgs e)
        {
            ChargerDonnes(null);
             Bloquerdebloquer(true);
            if (nouveau)
                btn_Nouveau_Click(null, null);
        }
	#endregion

    #region Boutons de commandes


         private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = (true);
            Viderchamp();
            Bloquerdebloquer(false);

           
        }

        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {              
               

                    //RadMessageBox.ThemeName = this.ThemeName;
                    //RadMessageBox.Show(this, "Cette commande a été déjà livrée partiellement. Impossible de la modifier.",
                    //                        "GESCOM", MessageBoxButtons.OK, RadMessageIcon.Error);
                    //return;
               
                Bloquerdebloquer(false);
               
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veillez sélèctioner une ligne avant d'entamer la modification.",
                                        "GESCOM", MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }

           private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            Bloquerdebloquer(true);
            Viderchamp();

            ChargerDonnes((FacturePartenaire)bds_Facture.Current);
        }


         private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            #region Déclaration

            FacturePartenaire obj = new FacturePartenaire();
            #endregion

            #region ControlDeSaisie               

            if (txt_Partenaire.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez obligatoirement spécifier le partenaire", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
               
                return;
            }                    
            
            #endregion            

            
            #region Enregistrement

            if (nouveau)
            {
                constituerObjet(obj);
                sortie = obj.Insert();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.IdFacture =(message[message.Length - 1].Trim());
                    //enregistrement des factures clients
                    foreach (Facture ligne in bds_FactureClients.List as List<Facture>)
                        {
                            ligne.IdFacturePartenaire=obj.IdFacture;
                            ligne.Update();
                        }

                    //Paiement automatique de ristourne
                    if(chk_PayerRistourne.Checked==true)
                    {
                        PaiementRistourne objP = new PaiementRistourne();
                        objP.MontantGlobal = Convert.ToDecimal(calculBasePourRistourne());
                        objP.MontantRistourne = Convert.ToDecimal(msk_Ristourne.Value);
                        objP.TauxRistourne = Convert.ToDecimal(oPartenaire.TauxRistourne);
                        objP.DatePaiement = dtp_date.Value.Date;
                        objP.IdFacture = obj.IdFacture;
                        objP.Insert();
                    }

                    Bloquerdebloquer(true);
                    nouveau = false;                    
                    ChargerDonnes(obj);
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "GESCOM",
                    MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }
            #endregion

            #region Modification
            else
            {
                obj = (FacturePartenaire)bds_Facture.Current;
                constituerObjet(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1] != "")
                {
                    //suppression des anciens factures clients
                    lstAncienneFacture = Facture.Liste(null, null, null, null, null, null, null, obj.IdFacture.Trim(), null, null, null, null, null, null, false, null, null, null, null);
                    foreach (Facture ligne in lstAncienneFacture)
                        {
                            ligne.IdFacturePartenaire="";
                            ligne.Update();
                        }
                    //enregistrement des factures clients
                    foreach (Facture ligne in bds_FactureClients.List as List<Facture>)
                        {
                            ligne.IdFacturePartenaire=obj.IdFacture;
                            ligne.Update();
                        }
                    Bloquerdebloquer(true);
                    //bds_Demandes.DataSource = DemandeAnalyse.Liste(meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                    ChargerDonnes(obj);
                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "GESCOM",
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }
            #endregion

          
             

        }

         private void btn_ActualiserPeriode_Click(object sender, EventArgs e)
         {
             lstFacture = Facture.Liste(null, null, null, null, null, oPartenaire.IdPersonne, null, null, null, null, null, null, null, null, false, null, null, null, null);
             bds_FactureClients.DataSource = lstFacture.FindAll(x => x.IdFacturePartenaire == ""  &&
                                                                 x.DateFacture >= dtp_DateDebut.Value.Date && x.DateFacture <= dtp_DateDeFin.Value.Date);

             chk_PayerRistourne_Click(null, null);
         }

         private void btn_Actualiser_Click(object sender, EventArgs e)
         {
             FacturePartenaire obj = (FacturePartenaire)bds_Facture.Current;
             ChargerDonnes(obj);
         }

         private void btn_choixAssurance_Click(object sender, EventArgs e)
         {
             try
             {
                 Frm_ListePartenaire frm = new Frm_ListePartenaire(false);
                 frm.ShowDialog();
                 oPartenaire = frm.oPartenaires;
                 txt_Partenaire.Text = oPartenaire.NomSigle + " " + oPartenaire.PrenomRaisonSociale;
             }
             catch { }
         }

         private void btn_Facture_Click(object sender, EventArgs e)
         {
             AfficherFacture(true);
         }
	#endregion



       #region DatagridView
		 private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
             if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                Detailler((FacturePartenaire)bds_Facture.Current);
                lstFacture = Facture.Liste(null, null, null, null, null, null, null, null, ((FacturePartenaire)bds_Facture.Current).IdFacture, null, null, null, null, null, false, null, null, null, null);
            }
            else
            {
                Viderchamp();
            }
        } 
	#endregion

       

         private void chk_PayerRistourne_Click(object sender, EventArgs e)
         {
             if(nouveau)
             { 
                 //if(chk_PayerRistourne.Checked==true)
                 //{
                 //msk_Ristourne.ReadOnly = false;
                     msk_Ristourne.Value = calculRistourne();
                 //}
                 //else
                 //{
                 //    msk_Ristourne.ReadOnly = true;
                 //    msk_Ristourne.Value = 0;
                 //}
              }
             
         }

         private void btn_Normalisation_Click(object sender, EventArgs e)
         {
             if (gv_Liste.SelectedRows != null &&
              gv_Liste.SelectedRows.Count != 0)
             {

                 List<DonneesMCF> olstDonneesMCF = new List<DonneesMCF>();
                 olstDonneesMCF = DonneesMCF.Liste(((FacturePartenaire)bds_Facture.Current).IdFacture, null, null, null, null, null, null, null, null, null,
                     null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);


                 PictureBox pb = new PictureBox();

                 if (olstDonneesMCF.Count == 0)
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
                         /* ETAT DE MCF*/



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
                             Utilisateur user = Utilisateur.Liste(null, null, null, null, null, null, null, null, null, ((FacturePartenaire)bds_Facture.Current).UserLogin.Trim(), null, null, null, null, null, null, null, false, null)[0];
                             idOperateur = Convert.ToInt32(user.NumeroUtilisateur);
                             operateur = (user.NomUtilisateur + " " + user.PrenomUtilisateur).Length > 32 ? (user.NomUtilisateur + " " + user.PrenomUtilisateur).Substring(0, 32) : (user.NomUtilisateur + " " + user.PrenomUtilisateur);

                             nomAcheteur = txt_Partenaire.Text;
                         }
                         #endregion


                         #region C0h (OUVRIR FACTURE)
                         Commandes.SEQ_INT++;
                         seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                         string message = Commandes.testC0h(serialPort, seq, idOperateur, operateur, ifuAcheteur,
                             nomAcheteur, Convert.ToString(AIB), "FV", "");

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

                         montant = 0;

                         for (int j = 0; j < lstFacture.Count; j++)
                         {
                             DataTable dt = null;
                             dt = Rapport.FactureClient(lstFacture[j].NumDemande);

                             for (int i = 0; i < dt.Rows.Count; i++)
                             {


                                 decimal prixTTC = decimal.Round(Convert.ToDecimal(dt.Rows[i]["prixApresRemise"].ToString().Trim()) * (oPartenaire.TauxRistourne == 0 ? 1 : ((100 - oPartenaire.TauxRistourne)/100)), 0);
                                 string quantite = Convert.ToString(Math.Abs(decimal.Round(Convert.ToDecimal(dt.Rows[i]["qte"].ToString().Trim()), 3))).Replace(",", ".");

                                 montant += (prixTTC * decimal.Round(Convert.ToDecimal(dt.Rows[i]["qte"].ToString().Trim()), 3));
                                 //Analyse objP = Analyse.FindFirst(Convert.ToString(dt.Rows[i]["codeAnalyse"].ToString().Trim()));
                                 string libelleAnalyse = Convert.ToString(dt.Rows[i]["codeAnalyse"].ToString().Trim());

                                 //AnalyseDemande objAD = AnalyseDemande.Liste(Convert.ToString(gv_Analyses.Rows[i].Cells["CodeAnalyse"].Value), objDem.NumDemande, null, null, null, null, null, null, null, null, false, null, null)[0];

                                

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
                                 if (Convert.ToDecimal(dt.Rows[i]["remiseAnalyse"].ToString().Trim()) != 0)
                                 {
                                     string remise = "remise de " + Convert.ToDecimal(dt.Rows[i]["remiseAnalyse"].ToString().Trim());
                                     decimal prixOrig = Convert.ToDecimal(dt.Rows[i]["prixNormal"].ToString().Trim());
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
                                         RadMessageBox.Show(this, "Impossible de déterminer le sous total pour l'article " + libelleAnalyse.Trim(),
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
                                     RadMessageBox.Show(this, "Impossible d'inscrire l'article " + libelleAnalyse.Trim(),
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
                         }

                         if (Convert.ToString(message[message.Length - 1]).Trim() == ",")
                         {
                             message = message.Substring(0, message.Length - 1);
                         }

                         if (message.Split(',').Length == 15)
                         {
                             if (Convert.ToDecimal(message.Split(',')[0]) != montant)
                             {
                                 RadMessageBox.ThemeName = this.ThemeName;
                                 RadMessageBox.Show(this, "Montant Facture [" + Convert.ToDecimal(montant) + "] != Montant Mcf [" + Convert.ToDecimal(message.Split(',')[0]) + "]",
                                     CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                 #region 38h (FERMER FACTURE)
                                 Commandes.SEQ_INT++;
                                 seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                 message = Commandes.test38h(serialPort, seq);
                                 #endregion

                                 serialPort.Close();
                                 return;
                             }

                             #region 35h (CONFIRMER FACTURE)
                             Commandes.SEQ_INT++;
                             seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);

                             {
                                 message = Commandes.test35h(serialPort, seq, "A" + Convert.ToString((Convert.ToDecimal(montant))));
                                 while (message.Trim().Contains("E"))
                                 {
                                     Commandes.SEQ_INT++;
                                     seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                     message = Commandes.test35h(serialPort, seq, "A" + Convert.ToString((Convert.ToDecimal(montant))));
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
                                                 obj.IdFacture = ((FacturePartenaire)bds_Facture.Current).IdFacture;
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


                         serialPort.Close();

                         RadMessageBox.ThemeName = this.ThemeName;
                         RadMessageBox.Show(this, "NORMALISATION TERMINEE AVEC SUCCES",
                             CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                     }

                     btn_Facture_Click(null, null);

                     //catch (Exception ex)
                     //{
                     //    if (serialPort != null)
                     //        serialPort.Close();

                     //    RadMessageBox.ThemeName = this.ThemeName;
                     //    RadMessageBox.Show(this, ex.Message,
                     //        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);

                     //    return;
                     //}
                     #endregion
                 }
                 else
                 {
                     btn_Facture_Click(null, null);
                 }
             }

         }

         private void rmi_SImple_Click(object sender, EventArgs e)
         {
             if (gv_Liste.SelectedRows != null &&
               gv_Liste.SelectedRows.Count != 0)
             {
                 List<DonneesMCF> olstDonneesMCF = new List<DonneesMCF>();
                 olstDonneesMCF = DonneesMCF.Liste(((FacturePartenaire)bds_Facture.Current).IdFacture, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                   null, null, null, null, null, false, null);


                 decimal montTot = 0;
                 DataTable dt = null;
                 string montEnLettre = "";
                 dt = Rapport.FacturePartenaireSimplifie(((FacturePartenaire)bds_Facture.Current).IdFacture);

                 #region montant total de la facture
                 
                 for(int i=0;i<dt.Rows.Count;i++)
                 {
                     montTot += (Convert.ToDecimal(dt.Rows[i]["nbre"]) * Convert.ToDecimal(dt.Rows[i]["prixApresRemise"]));
                 }
                 #endregion

                 TR_FacturePartenaireSimplifiee rpt = new TR_FacturePartenaireSimplifiee();
                 rpt.objectDataSource1.DataSource = dt;
                 rpt.DataSource = rpt.objectDataSource1;
                 try
                 {
                     rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                 }
                 catch { }
                 if (olstDonneesMCF.Count != 0)
                 {
                     rpt.pnl_MCF.Visible = true;
                     rpt.txt_Compteur.Visible = true;
                     rpt.txt_dateEtHeure.Visible = true;
                     rpt.txt_sig.Visible = true;
                     rpt.pb_QRCode.Visible = true;
                     rpt.lbl_Compteurs.Visible = true;
                     rpt.lbl_NIM.Visible = true;
                     rpt.lbl_Heure.Visible = true;
                     rpt.lbl_Operateur.Visible = true;
                     rpt.txt_Operateur.Visible = true;

                     Utilisateur user = Utilisateur.Liste(null, null, null, null, null, null, null, null, null, ((FacturePartenaire)bds_Facture.Current).UserLogin.Trim(), null, null, null, null, null, null, null, false, null)[0];

                     idOperateur = Convert.ToInt32(user.NumeroUtilisateur);
                     operateur = (user.NomUtilisateur + " " + user.PrenomUtilisateur).Length > 32 ? (user.NomUtilisateur + " " + user.PrenomUtilisateur).Substring(0, 32) : (user.NomUtilisateur + " " + user.PrenomUtilisateur);

                     rpt.txt_Operateur.Value = idOperateur.ToString() + "-" + operateur;

                     rpt.txt_nim.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Nim : "Aucune donnée";
                     rpt.txt_Compteur.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Compteur : "Aucune donnée";
                     rpt.txt_dateEtHeure.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].DateEtHeure : "Aucune donnée";
                     rpt.txt_sig.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Sig : "Aucune donnée";
                 }
                 else
                 {
                     rpt.lbl_Operateur.Visible = false;
                     rpt.txt_Operateur.Visible = false;
                     rpt.pnl_MCF.Visible = false;
                     rpt.txt_Compteur.Visible = false;
                     rpt.txt_dateEtHeure.Visible = false;
                     rpt.txt_sig.Visible = false;
                     rpt.pb_QRCode.Visible = false;
                     rpt.lbl_Compteurs.Visible = false;
                     rpt.lbl_NIM.Visible = false;
                     rpt.lbl_Heure.Visible = false;
                     rpt.txt_nim.Value = "";
                     rpt.txt_Compteur.Value = "";
                     rpt.txt_dateEtHeure.Value = "";
                     rpt.txt_sig.Value = "";
                 }
                 montEnLettre = "Arretée la présente facture à la somme de " + Tools.convertirNombreEnLettre((float)montTot);
                 rpt.txt_MontantLettres.Value = montEnLettre + " (" + string.Format("{0:n0}", montTot) + ") francs CFA";
                 //rpt.txt_Entete.Value = "POINT DES PRESTATIONS DU LABORATOIRE SUR LA PERIODE DU " + Convert.ToDateTime(gv_Liste.SelectedRows[0].Cells["DateDebut"].Value).ToShortDateString() + " AU " + Convert.ToDateTime(gv_Liste.SelectedRows[0].Cells["DateFin"].Value).ToShortDateString();
                 rpt.txt_NomApplication.Value = "GESLAB";
                 rpt.txt_Directeur.Value = CurrentUser.OSociete.Directeur;
                 rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                 rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                     CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                 rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                 rpt.pb_QRCode.Value = null;
                 rpt.txt_DateFacture.Value = string.Format("{0:D}", ((FacturePartenaire)bds_Facture.Current).DateFacture);
                 
                 if (olstDonneesMCF != null && olstDonneesMCF.Count > 0 && olstDonneesMCF[0].CodeQRImage != null)
                 {
                     using (Stream imgStr = new MemoryStream(olstDonneesMCF[0].CodeQRImage))
                     {
                         rpt.pb_QRCode.Value = System.Drawing.Image.FromStream(imgStr);
                     }
                 }
                 Frm_ReportViewer frm = new Frm_ReportViewer("FACTURE PARTENAIRE", rpt);
                 frm.MdiParent = Application.OpenForms["Frm_Menu"];
                 frm.Show();
             }
         }

         private void rmi_DetailleSansSynth_Click(object sender, EventArgs e)
         {
             AfficherFacture(false);
         }

         private void btn_Supprimer_Click(object sender, EventArgs e)
         {
              List<DonneesMCF> olstDonneesMCF = new List<DonneesMCF>();
                 olstDonneesMCF = DonneesMCF.Liste(((FacturePartenaire)bds_Facture.Current).IdFacture, null, null, null, null, null, null, null, null, null,
                     null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);
               
               

                 List<ReglementPartenaire> olstReglementPartenaire = ReglementPartenaire.Liste(((FacturePartenaire)bds_Facture.Current).IdFacture, null, null, 
                     null, null, null, null, null, null, null, null, null, null, null, null, false, null);

             if(olstReglementPartenaire.Count!=0)
             {
                 RadMessageBox.ThemeName = this.ThemeName;
                 MessageBox.Show(this, "Impossible de supprimer une facture ayant au moins un règlement",
                     CurrentUser.LogicielHote, MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }

             
                 RadMessageBox.ThemeName = this.ThemeName;
                 if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne " +
                     "sélectionnée", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                     RadMessageIcon.Question) == DialogResult.Yes)
                 {

                     if (olstDonneesMCF.Count != 0)
                     {
                         #region normalisation de l'annulation de la facture normalisée

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
                             /* ETAT DE MCF*/



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
                                 Utilisateur user = Utilisateur.Liste(null, null, null, null, null, null, null, null, null, ((FacturePartenaire)bds_Facture.Current).UserLogin.Trim(), null, null, null, null, null, null, null, false, null)[0];
                                 idOperateur = Convert.ToInt32(user.NumeroUtilisateur);
                                 operateur = (user.NomUtilisateur + " " + user.PrenomUtilisateur).Length > 32 ? (user.NomUtilisateur + " " + user.PrenomUtilisateur).Substring(0, 32) : (user.NomUtilisateur + " " + user.PrenomUtilisateur);

                                 nomAcheteur = txt_Partenaire.Text;
                             }
                             #endregion


                             #region C0h (OUVRIR FACTURE)
                             Commandes.SEQ_INT++;
                             seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                             string message = Commandes.testC0h(serialPort, seq, idOperateur, operateur, ifuAcheteur,
                                 nomAcheteur, Convert.ToString(AIB), "FA", olstDonneesMCF[0].Nim + "-" + olstDonneesMCF[0].Tc);

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

                             montant = 0;

                             for (int j = 0; j < lstFacture.Count; j++)
                             {
                                 DataTable dt = null;
                                 dt = Rapport.FactureClient(lstFacture[j].NumDemande);

                                 for (int i = 0; i < dt.Rows.Count; i++)
                                 {


                                     decimal prixTTC = decimal.Round(Convert.ToDecimal(dt.Rows[i]["prixApresRemise"].ToString().Trim()), 0);
                                     montant += prixTTC;
                                     //Analyse objP = Analyse.FindFirst(Convert.ToString(dt.Rows[i]["codeAnalyse"].ToString().Trim()));
                                     string libelleAnalyse = Convert.ToString(dt.Rows[i]["codeAnalyse"].ToString().Trim());

                                     //AnalyseDemande objAD = AnalyseDemande.Liste(Convert.ToString(gv_Analyses.Rows[i].Cells["CodeAnalyse"].Value), objDem.NumDemande, null, null, null, null, null, null, null, null, false, null, null)[0];

                                     string quantite = "1";

                                     #region 31h (INSCRIRE DES ARTICLES)

                                     libelleAnalyse = libelleAnalyse.Length > 60
                                         ? Fonction.RemplacerCaracSpec(libelleAnalyse.Substring(0, 60)) :
                                                 Fonction.RemplacerCaracSpec(libelleAnalyse);
                                     List<byte> article = new List<byte>();
                                     article = new List<Byte>(Encoding.Default.GetBytes(libelleAnalyse));
                                     article.Add(0x09);
                                     string lettre = "E";
                                     article.Add(((byte)Convert.ToInt32(lettre[0])));
                                     article.AddRange((Encoding.UTF8.GetBytes(Convert.ToString(prixTTC))));
                                     string star = "*";
                                     article.Add((byte)Convert.ToInt32(star[0]));
                                     article.AddRange((Encoding.UTF8.GetBytes(quantite)));

                                     #region gestion des remises
                                     if (Convert.ToDecimal(dt.Rows[i]["remiseAnalyse"].ToString().Trim()) != 0)
                                     {
                                         string remise = "remise de " + Convert.ToDecimal(dt.Rows[i]["remiseAnalyse"].ToString().Trim());
                                         decimal prixOrig = Convert.ToDecimal(dt.Rows[i]["prixNormal"].ToString().Trim());
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
                                             RadMessageBox.Show(this, "Impossible de déterminer le sous total pour l'article " + libelleAnalyse.Trim(),
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
                                         RadMessageBox.Show(this, "Impossible d'inscrire l'article " + libelleAnalyse.Trim(),
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
                             }

                             if (Convert.ToString(message[message.Length - 1]).Trim() == ",")
                             {
                                 message = message.Substring(0, message.Length - 1);
                             }

                             if (message.Split(',').Length == 15)
                             {
                                 if (Convert.ToDecimal(message.Split(',')[0]) != montant)
                                 {
                                     RadMessageBox.ThemeName = this.ThemeName;
                                     RadMessageBox.Show(this, "Montant Facture [" + Convert.ToDecimal(montant) + "] != Montant Mcf [" + Convert.ToDecimal(message.Split(',')[0]) + "]",
                                         CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                     #region 38h (FERMER FACTURE)
                                     Commandes.SEQ_INT++;
                                     seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                     message = Commandes.test38h(serialPort, seq);
                                     #endregion

                                     serialPort.Close();
                                     return;
                                 }

                                 #region 35h (CONFIRMER FACTURE)
                                 Commandes.SEQ_INT++;
                                 seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);

                                 {
                                     message = Commandes.test35h(serialPort, seq, "A" + Convert.ToString((Convert.ToDecimal(montant))));
                                     while (message.Trim().Contains("E"))
                                     {
                                         Commandes.SEQ_INT++;
                                         seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                         message = Commandes.test35h(serialPort, seq, "A" + Convert.ToString((Convert.ToDecimal(montant))));
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
                                                     DonneesMCF objR = new DonneesMCF();
                                                     objR.IdFacture = ((FacturePartenaire)bds_Facture.Current).IdFacture + "_R";
                                                     objR.Fc = Convert.ToDecimal(message.Split(',')[0]);
                                                     objR.Tc = Convert.ToDecimal(message.Split(',')[1]);
                                                     objR.Ft = message.Split(',')[2];
                                                     objR.Sig = Fonction.Signature(Convert.ToString(message.Split(',')[6]));
                                                     objR.Compteur = Convert.ToString(message.Split(',')[0]) + "/" + Convert.ToString(message.Split(',')[1])
                                                         + "" + Convert.ToString(message.Split(',')[2]);
                                                     objR.DateEtHeure = Fonction.dateSignature(message.Split(',')[3]);
                                                     objR.CodeQR = codeQR;
                                                     objR.Nim = message.Split(',')[4];
                                                     objR.CodeQRImage = byteImage;
                                                     objR.Adresse = CurrentUser.adresse;
                                                     objR.Mail = CurrentUser.mail;
                                                     objR.IFU = Commandes.IFU;
                                                     objR.Nom = CurrentUser.nom;
                                                     objR.Telephone = CurrentUser.telephone;
                                                     objR.RCCM = "";
                                                     objR.Ville = CurrentUser.ville;
                                                     objR.Reference = "";
                                                     objR.Insert();
                                                 }
                                                 catch (Exception ex)
                                                 {

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


                             serialPort.Close();

                             //RadMessageBox.ThemeName = this.ThemeName;
                             //RadMessageBox.Show(this, "NORMALISATION TERMINEE AVEC SUCCES",
                             //    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                         }

                         //btn_Facture_Click(null, null);

                         //catch (Exception ex)
                         //{
                         //    if (serialPort != null)
                         //        serialPort.Close();

                         //    RadMessageBox.ThemeName = this.ThemeName;
                         //    RadMessageBox.Show(this, ex.Message,
                         //        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);

                         //    return;
                         //}
                         #endregion

                         #endregion
                     }


                     FacturePartenaire obj = (FacturePartenaire)bds_Facture.Current;
                     string res = obj.Delete();
                     string[] messager = Tools.SplitMessage(res);
                     if (int.Parse(messager[0]) > 0)
                     {

                         foreach (Facture ligne in bds_FactureClients.List as List<Facture>)
                         {
                             ligne.IdFacturePartenaire = "";
                             ligne.Update();
                         }

                         ChargerDonnes((FacturePartenaire)bds_Facture.Current);
                         RadMessageBox.ThemeName = this.ThemeName;
                         RadMessageBox.Show(this, messager[3].Trim(), CurrentUser.LogicielHote,
                             MessageBoxButtons.OK, RadMessageIcon.Info);
                     }
                     else
                     {
                         RadMessageBox.ThemeName = this.ThemeName;
                         MessageBox.Show(this, messager[3].Trim(), CurrentUser.LogicielHote,
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }
            
         }

         private void btn_Exporter_Click(object sender, EventArgs e)
         {
             if (gv_FactureClients != null && gv_FactureClients.Rows.Count != 0)
             {

                 try
                 {
                     SaveFileDialog dialog = new SaveFileDialog();
                     dialog.Filter = "Excel files|*.xls";

                     if (dialog.ShowDialog() == DialogResult.OK)
                     {
                         this.spreadExporter = new GridViewSpreadExport(this.gv_FactureClients);
                         spreadExporter.ExportVisualSettings = true;
                         spreadExporter.HiddenColumnOption = Telerik.WinControls.UI.Export.HiddenOption.DoNotExport;
                         spreadExporter.HiddenRowOption = Telerik.WinControls.UI.Export.HiddenOption.DoNotExport;
                         SpreadExportRenderer renderer = new SpreadExportRenderer();
                         renderer.WorkbookCreated += renderer_WorkbookCreated;

                         this.spreadExporter.RunExport(dialog.FileName, renderer);

                         RadMessageBox.ThemeName = this.ThemeName;
                         RadMessageBox.Show(this, "Exportation terminée.",
                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                     }

                 }
                 catch (Exception ex)
                 {
                     RadMessageBox.Show(this, ex.Message,
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                 }

             }
             else
             {
                 RadMessageBox.ThemeName = this.ThemeName;
                 RadMessageBox.Show(this, "La grille est vide.", CurrentUser.LogicielHote,
                     MessageBoxButtons.OK, RadMessageIcon.Error);
             }
         }

       

    }
}
