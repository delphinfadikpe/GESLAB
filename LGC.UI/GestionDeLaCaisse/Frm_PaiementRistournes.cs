using LGC.Business;
using LGC.Business.GestionDeLaCaisse;
using LGC.Business.Parametre;
using LGG.UI.Parametre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace LGG.UI.GestionDeLaCaisse
{
    public partial class Frm_PaiementRistournes : Telerik.WinControls.UI.RadForm
    {

        #region declarations
        public List<PaiementRistourne> lstPaiementRistourne = new List<PaiementRistourne>();
        public List<FacturePartenaire> lstFacture = new List<FacturePartenaire>();
        public List<Partenaires> lstPartenaire = new List<Partenaires>();
        FacturePartenaire oFacturePartenaire = new FacturePartenaire();
        Partenaires oPartenaire = new Partenaires();
        public bool nouveau = false;
        public bool nouveauLivraison = false;
        string sortie;
        string[] message;
        int ligne = 0;
       
         
        Assurance oAssurance = new Assurance();
        #endregion

        #region Autres
        private void Viderchamp()
        {

                     
            txt_Partenaire.Text = "";
            txt_Facture.Text = "";
            meb_numero.Text = "EN CREATION";
            meb_MontantGlobal.Text = "0";
            meb_Ristourne.Text = "0";
            meb_Taux.Text = "0,00";
            dtp_date.Value = DateTime.Now;
            
        }

        private void Detailler(PaiementRistourne obj)
        {
            try{
                oFacturePartenaire = FacturePartenaire.Liste(obj.IdFacture, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null)[0];
                txt_Partenaire.Text = oFacturePartenaire.Partenaire;
                txt_Facture.Text = "FACTURE N°" + oFacturePartenaire.IdFacture;
            }
            catch{}
            //txt_Facture.Text = ;
            meb_numero.Text = obj.IdPaiement.ToString();
            meb_MontantGlobal.Value = obj.MontantGlobal;
            meb_Ristourne.Value = obj.MontantRistourne;
            meb_Taux.Value = obj.TauxRistourne;
            dtp_date.Value = obj.DatePaiement;
        }

        private void ChargerDonnes(PaiementRistourne obj)
        {
            Viderchamp();
                  
            bds_PaiementRistourne.DataSource = PaiementRistourne.Liste(null,null,null,null,null,null,null,null,null,null,null,null,false,null);
           
            if (obj != null)
            {
                int i = 0;
                foreach (PaiementRistourne ligne in bds_PaiementRistourne.List as List<PaiementRistourne>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_PaiementRistourne.Position = i;
                        break;
                    }
                    else
                        i++;
                }
            }
        }
        
       

        private void constituerObjet(PaiementRistourne obj) 
        {

            obj.MontantGlobal =Convert.ToDecimal(meb_MontantGlobal.Value);
            obj.MontantRistourne=Convert.ToDecimal(meb_Ristourne.Value) ;
             obj.TauxRistourne=Convert.ToDecimal(meb_Taux.Value) ;
             obj.DatePaiement = dtp_date.Value.Date;
             obj.IdFacture = oFacturePartenaire.IdFacture;
            
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
            meb_Ristourne.ReadOnly = etat;
            btn_choixAssurance.Enabled = !etat;
            btn_ChoixFacture.Enabled = !etat;

        }
        #endregion

        #region Formulaires
        public Frm_PaiementRistournes()
        {
            InitializeComponent();
        }
        private void Frm_PaiementRistourne_Load(object sender, EventArgs e)
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
                    //                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                    //return;

                Bloquerdebloquer(false);
                nouveau = false;
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
            ChargerDonnes((PaiementRistourne)bds_PaiementRistourne.Current);
        }


         private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            #region Déclaration

            PaiementRistourne obj = new PaiementRistourne();
            #endregion

            #region ControlDeSaisie          

            

            if (txt_Partenaire.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez obligatoirement spécifier le partenaire", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
               
                return;
            }
            if (txt_Facture.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez obligatoirement spécifier la facture ", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);

                return;
            }

            if (Convert.ToDecimal(meb_Ristourne.Value) ==0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "la ristourne ne peut etre égale à zéro ", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_Ristourne.Focus();
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

                    #region Mise a jour du champ a reçuRistourne pour la facture partenaire
                    oFacturePartenaire.AReçuRistourne = true;
                    oFacturePartenaire.Update();
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
            else
            {
                obj = (PaiementRistourne)bds_PaiementRistourne.Current;
                constituerObjet(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1] != "")
                {
                    
                    ChargerDonnes(obj);
                    Bloquerdebloquer(true);
                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "GESLAB",
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }
            #endregion

          
             

        }

        
         private void btn_Actualiser_Click(object sender, EventArgs e)
         {
             PaiementRistourne obj = (PaiementRistourne)bds_PaiementRistourne.Current;
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
                 meb_Taux.Value = oPartenaire.TauxRistourne;
             }
             catch { }
         }
	#endregion

        #region DatagridView
		 private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
             if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                Detailler((PaiementRistourne)bds_PaiementRistourne.Current);
            }
            else
            {
                Viderchamp();
            }
        } 
	#endregion

         private void btn_ChoixFacture_Click(object sender, EventArgs e)
         {
             try
             {
                 Frm_ListeFacturePourRistourne frm = new Frm_ListeFacturePourRistourne(oPartenaire.IdPersonne);
                 frm.ShowDialog();
                 oFacturePartenaire = frm.oFacturePartenaire;
                 txt_Facture.Text ="FACTURE N°"+ oFacturePartenaire.IdFacture;
                 meb_MontantGlobal.Value = oFacturePartenaire.MontantDemande;
             }
             catch { }
         }

         private void meb_MontantGlobal_TextChanged(object sender, EventArgs e)
         {
             meb_Ristourne.Value = (Convert.ToDecimal(meb_MontantGlobal.Value) * Convert.ToDecimal(meb_Taux.Value))/100;
         }

         private void btn_Supprimer_Click(object sender, EventArgs e)
         {
             if (gv_Liste.SelectedRows != null &&
                gv_Liste.SelectedRows.Count > 0)
             {
                 RadMessageBox.ThemeName = this.ThemeName;
                 if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne " +
                     "sélectionnée", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                     RadMessageIcon.Question) == DialogResult.Yes)
                 {
                     PaiementRistourne obj = (PaiementRistourne)bds_PaiementRistourne.Current;
                     string res = obj.Delete();
                     message = Tools.SplitMessage(res);
                     if (int.Parse(message[0]) > 0)
                     {                         

                         try
                         {
                             FacturePartenaire oFact = FacturePartenaire.Liste(obj.IdFacture, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null)[0];
                             oFact.AReçuRistourne = false;
                             oFact.Update();
                         }
                         catch
                         {

                         }

                         RadMessageBox.ThemeName = this.ThemeName;
                         RadMessageBox.Show(this, message[3].Trim(),CurrentUser.LogicielHote,
                             MessageBoxButtons.OK, RadMessageIcon.Info);
                         ChargerDonnes(null);
                     }
                     else
                     {
                         RadMessageBox.ThemeName = this.ThemeName;
                         MessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }
             }
             else
             {
                 RadMessageBox.ThemeName = this.ThemeName;
                 RadMessageBox.Show(this, "Veuillez sélectionner la ligne à supprimer.",
                     CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
             }
         }

         
    }
}
