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

namespace LGG.UI.GestionDeLaCaisse
{
    public partial class Frm_FacturePartenaireVisualiser : Telerik.WinControls.UI.RadForm
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
        
        #endregion


        #region Autres

        private void AfficherFacture(bool avecSynthese)
        {
           
            {
                
                decimal montTot = 0;
                DataTable dt = null;
                string montEnLettre = "";
                dt = Rapport.FacturePArtenaire_Previsualiser(oPartenaire.IdPersonne, dtp_DateDebut.Value.Date,dtp_DateDeFin.Value.Date);

                TR_FacturePartenaire rpt = new TR_FacturePartenaire();
                rpt.objectDataSource1.DataSource = dt;
                rpt.DataSource = rpt.objectDataSource1;
                try
                {
                    rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                }
                catch { }
               
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
                rpt.txt_Entete.Value = "POINT DES PRESTATIONS DU LABORATOIRE SUR LA PERIODE DU " + Convert.ToDateTime(dtp_DateDebut.Value).ToShortDateString() + " AU " + Convert.ToDateTime(dtp_DateDeFin.Value).ToShortDateString();
                rpt.txt_NomApplication.Value = "GESLAB";
                rpt.txt_Directeur.Value = CurrentUser.OSociete.Directeur;
                rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                    CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                rpt.pb_QRCode.Value = null;
                rpt.pnl_Synthèse.Visible = avecSynthese;
                rpt.txt_DateFacture.Value = string.Format("{0:D}", DateTime.Now);
                rpt.txt_NumFActure.Visible = false;
                rpt.lbl_NumFacture.Visible = false;
                rpt.pnl_Signature.Visible = false;
                Frm_ReportViewer frm = new Frm_ReportViewer("FACTURE PARTENAIRE", rpt);
                frm.MdiParent = Application.OpenForms["Frm_Menu"];
                frm.Show();
            }
        }

        
     

    
        #endregion

    #region Formulaires
        public Frm_FacturePartenaireVisualiser(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }

        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }
        private void Frm_FactureAssurance_Load(object sender, EventArgs e)
        {
            
               
        }
	#endregion

    #region Boutons de commandes


       



         private void btn_ActualiserPeriode_Click(object sender, EventArgs e)
         {
             lstFacture = Facture.Liste(null, null, null, null, null, oPartenaire.IdPersonne, null, null, null, null, null, null, null, null, false, null, null, null, null);
             bds_FactureClients.DataSource = lstFacture.FindAll(x => /*x.IdFacturePartenaire == ""  &&*/
                                                                 x.DateFacture >= dtp_DateDebut.Value.Date && x.DateFacture <= dtp_DateDeFin.Value.Date);

            
         }

         private void btn_choixPartenaire_Click(object sender, EventArgs e)
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

         private void rmi_Detaillee_Click(object sender, EventArgs e)
         {
             AfficherFacture(true);
         }

         private void rmi_DetailleSansSynth_Click(object sender, EventArgs e)
         {
             AfficherFacture(false);
         }

       
	#endregion

        



    
       


        

     
       
       

    }
}
