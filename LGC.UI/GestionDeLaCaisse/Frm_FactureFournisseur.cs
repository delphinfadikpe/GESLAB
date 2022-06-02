using LGC.Business;
using LGC.Business.GestionDeLaCaisse;
using LGC.Business.Parametre;
using LGG.UI.Parametre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace LGG.UI.GestionDeLaCaisse
{
    public partial class Frm_FactureFournisseur : Telerik.WinControls.UI.RadForm
    {

        #region declarations
        public bool nouveau = false;
        public List<Fournisseur> lstFournisseur = new List<Fournisseur>();
        public List<FactureFournisseur> lstFactureFournisseur = new List<FactureFournisseur>();      
        FactureFournisseur oFactureFournisseur = new FactureFournisseur();
        Fournisseur oFournisseur = new Fournisseur();
        List<FactureCommande> olstFactureCommande = new List<FactureCommande>();
        string sortie;
        string[] message;
        int ligne = 0;
        string cheminFichierAdd = "";
        Societe oSociete = new Societe();
        
        #endregion

        #region Autres
        private void Viderchamp()
        {

            dtp_date.Value = DateTime.Now;
            txt_Fournisseur.Text = "";
            txt_Commande.Text = "";
            meb_reference.Text = "";

            meb_MontantGlobal.Text = "0";
            meb_Tva.Text = "0";
            meb_Remise.Text = "0";
            meb_Tva.Text = "0";
            meb_Aib.Text = "0";
            meb_MontantAPremise.Text = "0";
            
            
        }

        private void Detailler(FactureFournisseur obj)
        {
            try{
                oFournisseur = Fournisseur.Liste(obj.IdPersonne, null, null, null, null, null, null, null, null, null, null, null, null, null,null,null,null,null, false, null)[0];
                txt_Fournisseur.Text = oFournisseur.RaisonSociale;
                txt_Commande.Text = "";
                olstFactureCommande = FactureCommande.Liste(obj.IdFacture, null, null, null, null, null, null, false, null);
                if(olstFactureCommande.Count==1)
                {
                    txt_Commande.Text =  olstFactureCommande[0].NumCde;
                }
                else
                {
                    foreach(FactureCommande ligne in olstFactureCommande)
                    {
                        txt_Commande.Text += ligne.NumCde + ";";
                    }
                }


                
            }
            catch{}
            
            //txt_Facture.Text = ;
            meb_reference.Text = obj.Reference;
            meb_MontantGlobal.Value = obj.MontantBrut;
            meb_Tva.Value = obj.Tva;
            meb_Remise.Value = obj.Remise;
            meb_MontantAPremise.Value = Convert.ToDecimal(obj.MontantBrut) - Convert.ToDecimal(obj.Remise);
            meb_Net.Value = obj.MontantFacture;
            meb_Aib.Value = obj.Aib;
            dtp_date.Value = obj.DateFacture;
            txt_PieceFacture.Text = obj.CheminFichierFacture;
        }

        private void ChargerDonnes(FactureFournisseur obj)
        {
            Viderchamp();

            bds_FactureFournisseur.DataSource = FactureFournisseur.Liste(null,null,null,null,null,null,null,null,null,null,false,null,null,null,null,null,null,null);
           
            if (obj != null)
            {
                int i = 0;
                foreach (FactureFournisseur ligne in bds_FactureFournisseur.List as List<FactureFournisseur>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_FactureFournisseur.Position = i;
                        break;
                    }
                    else
                        i++;
                }
            }
        }



        private void constituerObjet(FactureFournisseur obj) 
        {

            obj.Reference = meb_reference.Text;
            obj.MontantBrut=Convert.ToDecimal(meb_MontantGlobal.Value);
            obj.Tva=Convert.ToDecimal(meb_Tva.Value );
            obj.Remise=Convert.ToDecimal(meb_Remise.Value);
            obj.MontantFacture=Convert.ToDecimal(meb_Net.Value);
            obj.Aib=Convert.ToDecimal(meb_Aib.Value);
            obj.DateFacture = dtp_date.Value;
            obj.IdPersonne = oFournisseur.IdPersonne;
            obj.CheminFichierFacture = txt_PieceFacture.Text.Trim();
            obj.MontantRestantAPayer = Convert.ToDecimal(meb_Net.Value);
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
            meb_reference.ReadOnly = etat;
            meb_Remise.ReadOnly = etat;
            meb_Aib.ReadOnly = etat;
            btn_choixAssurance.Enabled = !etat;
            btn_ChoixCommande.Enabled = !etat;
            btn_Importer.Enabled = !etat;

        }
        #endregion

        #region Formulaires
        public Frm_FactureFournisseur()
        {
            InitializeComponent();
        }
        private void Frm_PaiementRistourne_Load(object sender, EventArgs e)
        {
            ChargerDonnes(null);
            Bloquerdebloquer(true);
            if (nouveau)
                btn_Nouveau_Click(null, null);

             oSociete = Societe.Liste(null, null, null, null, null, null, null, null, null, null, null, 
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null)[0];
        }
	#endregion

        #region Boutons de commandes


         private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = (true);
            Viderchamp();
            meb_reference.Focus();
            Bloquerdebloquer(false);
           
        }

        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {              
               

                    //RadMessageBox.ThemeName = this.ThemeName;
                    //RadMessageBox.Show(this, "Cette commande a été déjà livrée partiellement. Impossible de la modifier.",
                    //                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                    //return;
               
                
               
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veillez sélèctioner une ligne avant d'entamer la modification.",
                                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }

           private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
             
            Viderchamp();
            Bloquerdebloquer(true);
            //ChargerDonnes((PaiementRistourne)bds_FactureFournisseur.Current);
        }


         private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            #region Déclaration

            FactureFournisseur obj = new FactureFournisseur();
            #endregion

            #region ControlDeSaisie          

            

            if (txt_Fournisseur.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez obligatoirement spécifier le partenaire", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
               
                return;
            }
            if (txt_Commande.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez obligatoirement spécifier la facture ", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);

                return;
            }

            if (txt_PieceFacture.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez rattacher la facture scannée ", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);

                return;
            }

            if (Convert.ToDecimal(meb_MontantGlobal.Value)==0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Le montant de la facture ne peut etre nulle ", "GESLAB",
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
                    obj.IdFacture = (message[message.Length - 1].Trim());

                    #region Enregistrement dans TJ_FactureCommande
                    string[] tab = txt_Commande.Text.Trim().Split(';');
                    for (int i = 0; i < tab.Length;i++)
                    {
                        FactureCommande oFactureCommande = new FactureCommande();
                        oFactureCommande.IdFacture = obj.IdFacture;
                        oFactureCommande.NumCde = tab[i];
                        oFactureCommande.Insert();
                    }
                    #endregion

                    #region Enregistrement de l'image
                    if(!Directory.Exists(CurrentUser.AppPath+"\\FACTURES"))
                    {
                        Directory.CreateDirectory(CurrentUser.AppPath + "\\FACTURES");
                    }
                    File.Copy(cheminFichierAdd, CurrentUser.AppPath + "\\FACTURES\\" + txt_PieceFacture.Text);
                    #endregion
                        nouveau = false;
                    ChargerDonnes(obj);
                    Bloquerdebloquer(true);
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "GESLAB",
                    MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }
            #endregion

            #region Modification
            //else
            //{
            //    obj = (PaiementRistourne)bds_FactureFournisseur.Current;
            //    constituerObjet(obj);
            //    sortie = obj.Update();
            //    message = Tools.SplitMessage(sortie);
            //    if (message[message.Length - 1] != "")
            //    {
                    
            //        ChargerDonnes(obj);
            //        Bloquerdebloquer(true);
            //    }

            //    RadMessageBox.ThemeName = this.ThemeName;
            //    RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "GESLAB",
            //    MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            //}
            #endregion

          
             

        }

        
         private void btn_Actualiser_Click(object sender, EventArgs e)
         {
             FactureFournisseur obj = (FactureFournisseur)bds_FactureFournisseur.Current;
             ChargerDonnes(obj);
         }

         private void btn_choixAssurance_Click(object sender, EventArgs e)
         {
             try
             {
                 Frm_ListeFournisseur frm = new Frm_ListeFournisseur();
                 frm.ShowDialog();
                 oFournisseur = frm.oFournisseur;
                 txt_Fournisseur.Text = oFournisseur.SiglePersonneMorale + " " + oFournisseur.RaisonSociale;
                 
             }
             catch { }
         }
	#endregion

        #region DatagridView
		 private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
             if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                Detailler((FactureFournisseur)bds_FactureFournisseur.Current);
            }
            else
            {
                Viderchamp();
            }
        } 
	#endregion

         private void btn_ChoixFacture_Click(object sender, EventArgs e)
         {
             if(txt_Fournisseur.Text=="")
             {
                 RadMessageBox.ThemeName = this.ThemeName;
                 RadMessageBox.Show(this, "veillez sélèctioner le fournisseur.",
                                         "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                 return;
             }
             try
             {
                 Frm_ListeCommande frm = new Frm_ListeCommande(oFournisseur);
                 frm.ShowDialog();
                 txt_Commande.Text = frm.numCommande;
                 meb_MontantGlobal.Value = frm.total;
             }
             catch { }
         }

         private void meb_MontantGlobal_TextChanged(object sender, EventArgs e)
         {
             meb_MontantAPremise.Value = Convert.ToDecimal(meb_MontantGlobal.Value) - Convert.ToDecimal(meb_Remise.Value);
             meb_Net.Value = Convert.ToDecimal(meb_MontantAPremise.Value) + Convert.ToDecimal(meb_Tva.Value) - Convert.ToDecimal(meb_Aib.Value);
         }

         private void btn_Importer_Click(object sender, EventArgs e)
         {
             OpenFileDialog OpenFile = new OpenFileDialog();
             OpenFile.Filter = /*"Fichier image(JPEG)|*.jpg|Fichier image(PNG)|*.png"*/"Fichier PDF|*.pdf";
             if (OpenFile.ShowDialog() == DialogResult.OK)
             {

                    cheminFichierAdd = OpenFile.FileName;
                     txt_PieceFacture.Text = OpenFile.SafeFileName;
                
             }
         }

         private void meb_MontantAPremise_TextChanged(object sender, EventArgs e)
         {

             meb_Tva.Value = Convert.ToDecimal(meb_MontantAPremise.Value) * oSociete.Tva / 100;
             meb_Aib.Value = Convert.ToDecimal(meb_MontantAPremise.Value) * oSociete.Aib / 100;
             meb_MontantGlobal_TextChanged(null, null);
         }

         private void btn_Supprimer_Click(object sender, EventArgs e)
         {

         }

         private void btn_Voir_Click(object sender, EventArgs e)
         {
             if(txt_PieceFacture.Text.Trim()!="")
             {
                 System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                 myProcess.StartInfo.FileName = CurrentUser.AppPath + "\\FACTURES\\" + txt_PieceFacture.Text.Trim();
                 //myProcess.StartInfo.CreateNoWindow = true;
                 myProcess.Start();
             }
         }

       

         
    }
}
