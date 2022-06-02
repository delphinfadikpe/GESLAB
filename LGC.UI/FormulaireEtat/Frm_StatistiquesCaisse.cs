using LGC.Business;
using LGC.Business.Impressions;
using LGC.Business.Parametre;
using LGC.UI.Impressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace LGC.UI.FormulaireEtat
{
    public partial class Frm_StatistiquesCaisse : Telerik.WinControls.UI.RadForm
    {
        DataTable dt = new DataTable();
        string entete = "";


        public Frm_StatistiquesCaisse()
        {
            InitializeComponent();
        }

        private void viderChamp()
        {
            rddl_Partenaires.Text="";
            rddl_Assurances.Text="";
            rddl_Clients.Text="";
            rddl_Fournisseurs.Text="";
            rddl_Ristournes.Text="";
            rb_Partenaires.IsChecked=false;
            rb_Assurances.IsChecked=false;
            rb_Clients.IsChecked=false;
            rb_AutresRecettes.IsChecked=false;
            rb_ToutesLesRecettes.IsChecked=false;
            rb_Fournisseurs.IsChecked=false;
            rb_Ristournes.IsChecked=false;
            rb_AutresDepenses.IsChecked=false;
            rb_ToutesLesDepenses.IsChecked=false;
            chk_Partenaires.Checked=false;
            chk_Assurances.Checked=false;
            chk_Clients.Checked=false;
            chk_Fournisseurs.Checked=false;
            chk_Ristournes.Checked = false;
        }

        private void ddl_TypeOperation_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //gv_Liste.DataSource = new System.Data.DataTable();
            switch (ddl_TypeOperation.Text.Trim())
            {
                case "RECETTES":
                    gb_Recettes.Enabled = true;
                    gb_Depenses.Enabled = false;
                    viderChamp();
                    rb_ToutesLesRecettes.IsChecked = true;
                    rddl_Assurances.Enabled = false;
                    rddl_Clients.Enabled = false;
                    rddl_Partenaires.Enabled = false;
                    break;

                case "DEPENSES":
                    gb_Recettes.Enabled = false;
                    gb_Depenses.Enabled = true;
                    viderChamp();
                    rb_ToutesLesDepenses.IsChecked = true;
                    rddl_Fournisseurs.Enabled = false;
                    rddl_Ristournes.Enabled = false;
                    break;
                default:
                    gb_Recettes.Enabled = false;
                    gb_Depenses.Enabled = false;
                    viderChamp();
                     gv_Liste.Columns["patient"].IsVisible = true;
                    gv_Liste.Columns["assurance"].IsVisible = true;
                    gv_Liste.Columns["partenaire"].IsVisible = true;
                    gv_Liste.Columns["fournisseur"].IsVisible = true;
                    gv_Liste.Columns["autreEntree"].IsVisible = true;
                    gv_Liste.Columns["autreSortie"].IsVisible = true;
                    break;
            }
        }

        private void Frm_StatistiquesCaisse_Load(object sender, EventArgs e)
        {
            meb_DateDebut.Value = DateTime.Now;
            meb_DateFin.Value = DateTime.Now;
            ddl_TypeOperation.Text = "TOUT";
            ddl_TypeOperation_SelectedIndexChanged(null, null);
            bds_Partenaires.DataSource = Partenaires.ListePartenairesAll();
            bds_Ristournes.DataSource = Partenaires.ListePartenairesAll();
            bds_Assurances.DataSource = Assurance.Liste(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);
            bds_Clients.DataSource = Patient.Liste(null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, false, null);
            bds_Fournisseurs.DataSource = Fournisseur.Liste(null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, false, null);
            viderChamp();
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            switch (ddl_TypeOperation.Text.Trim())
            {
                case "RECETTES":
                    if (rb_ToutesLesRecettes.IsChecked == true)
                    {
                        gv_Liste.DataSource =dt= Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), null, null, null, null, null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                       
                    }
                    if (rb_AutresRecettes.IsChecked == true)
                    {
                        gv_Liste.DataSource =dt= Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), null, null, null, null, "TOUT", meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                       
                    }
                    if(rb_Partenaires.IsChecked==true)
                    {
                        if (chk_Partenaires.Checked == true)
                        {
                            gv_Liste.DataSource =dt= Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), null, ((Partenaires)bds_Partenaires.Current).IdPersonne.ToString().Trim(), null, null, null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                        }
                        else
                        {
                            gv_Liste.DataSource =dt= Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), null, "TOUT", null, null, null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                        }
                    }

                    if (rb_Assurances.IsChecked == true)
                    {
                        if (chk_Assurances.Checked == true)
                        {
                            gv_Liste.DataSource = dt = Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), null, null, ((Assurance)bds_Assurances.Current).IdPersonne.ToString().Trim(), null, null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                        }
                        else
                        {
                            gv_Liste.DataSource = dt = Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), null, null, "TOUT", null, null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                        }
                    }

                    if (rb_Clients.IsChecked == true)
                    {
                        if (chk_Clients.Checked == true)
                        {
                            gv_Liste.DataSource = dt = Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), ((Patient)bds_Clients.Current).IdPersonne.ToString().Trim(), null, null, null, null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                        }
                        else
                        {
                            gv_Liste.DataSource = dt = Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), "TOUT", null, null, null, null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                        }
                      
                    }
                       
                       break;

                case "DEPENSES":
                       if (rb_ToutesLesDepenses.IsChecked == true)
                       {
                           gv_Liste.DataSource = dt = Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), null, null, null, null, null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                          
                       }
                       if (rb_AutresDepenses.IsChecked == true)
                       {
                           gv_Liste.DataSource = dt = Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), null, null, null, null, "TOUT", meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                          
                       }
                    if (rb_Fournisseurs.IsChecked == true)
                    {
                        if (chk_Fournisseurs.Checked == true)
                        {
                            gv_Liste.DataSource = dt = Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), null, null, null, ((Fournisseur)bds_Fournisseurs.Current).IdPersonne.ToString().Trim(), null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);

                        }
                        else
                        {
                            gv_Liste.DataSource = dt = Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), null, null, null, "TOUT", null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                        }
                        
                    }

                    if (rb_Ristournes.IsChecked == true)
                    {
                        if (chk_Ristournes.Checked == true)
                        {
                            gv_Liste.DataSource = dt = Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), null, ((Partenaires)bds_Ristournes.Current).IdPersonne.ToString().Trim(), null, null, null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                        }
                        else
                        {
                            gv_Liste.DataSource = dt = Rapport.StatistiquesCaisse(ddl_TypeOperation.Text.Trim(), null, "TOUT", null, null, null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                        }

                    }                       
                       
                       break;
                    
                default:
                       gv_Liste.DataSource = dt = Rapport.StatistiquesCaisse(null, null, null, null, null, null, meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
                   
                    break;
            }
        }

        private void chk_Partenaires_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
               
            
        }

        private void chk_Assurances_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            
        }

        private void chk_Clients_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rb_Clients.IsChecked == false)
            {
                rb_Clients.IsChecked = true;
            }
            
            rddl_Clients.Text = string.Empty;
            rddl_Clients.Enabled = chk_Clients.Checked == true ? true : false;
        }

        private void chk_Partenaires_Click(object sender, EventArgs e)
        {
            if (rb_Partenaires.IsChecked == false )
            {
                rb_Partenaires.IsChecked = true;
            }

            rddl_Partenaires.Text = string.Empty;
            rddl_Partenaires.Enabled = chk_Partenaires.Checked == false ? true : false;
        }

        private void rb_Partenaires_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rddl_Partenaires.Enabled = false;
            chk_Partenaires.Checked = false;
            rddl_Assurances.Enabled = false;
            chk_Assurances.Checked = false;
            rddl_Clients.Enabled = false;
            chk_Clients.Checked = false;
            gv_Liste.Columns["patient"].IsVisible = false;
            gv_Liste.Columns["assurance"].IsVisible = false;
            gv_Liste.Columns["partenaire"].IsVisible = true;
            gv_Liste.Columns["fournisseur"].IsVisible = false;
            gv_Liste.Columns["autreEntree"].IsVisible = false;
            gv_Liste.Columns["autreSortie"].IsVisible = false;
            gv_Liste.DataSource = null;
        }

        private void rb_Assurances_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rddl_Partenaires.Enabled = false;
            chk_Partenaires.Checked = false;
           
            chk_Assurances.Checked = false;
            rddl_Clients.Enabled = false;
            chk_Clients.Checked = false;
            gv_Liste.Columns["patient"].IsVisible = false;
            gv_Liste.Columns["assurance"].IsVisible = true;
            gv_Liste.Columns["partenaire"].IsVisible = false;
            gv_Liste.Columns["fournisseur"].IsVisible = false;
            gv_Liste.Columns["autreEntree"].IsVisible = false;
            gv_Liste.Columns["autreSortie"].IsVisible = false;
            gv_Liste.DataSource = null;
        }

        private void rb_Clients_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rddl_Partenaires.Enabled = false;
            chk_Partenaires.Checked = false;
            rddl_Assurances.Enabled = false;
            chk_Assurances.Checked = false;            
            chk_Clients.Checked = false;
            gv_Liste.Columns["patient"].IsVisible = true;
            gv_Liste.Columns["assurance"].IsVisible = false;
            gv_Liste.Columns["partenaire"].IsVisible = false;
            gv_Liste.Columns["fournisseur"].IsVisible = false;
            gv_Liste.Columns["autreEntree"].IsVisible = false;
            gv_Liste.Columns["autreSortie"].IsVisible = false;
            gv_Liste.DataSource = null;
        }

        private void rb_AutresRecettes_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rddl_Partenaires.Enabled = false;
            chk_Partenaires.Checked = false;
            rddl_Assurances.Enabled = false;
            chk_Assurances.Checked = false;
            rddl_Clients.Enabled = false;
            chk_Clients.Checked = false;
            gv_Liste.Columns["patient"].IsVisible = false;
            gv_Liste.Columns["assurance"].IsVisible = false;
            gv_Liste.Columns["partenaire"].IsVisible = false;
            gv_Liste.Columns["fournisseur"].IsVisible = false;
            gv_Liste.Columns["autreEntree"].IsVisible = true;
            gv_Liste.Columns["autreSortie"].IsVisible = false;
            gv_Liste.DataSource = null;
        }

        private void rb_ToutesLesRecettes_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rddl_Partenaires.Enabled = false;
            chk_Partenaires.Checked = false;
            rddl_Assurances.Enabled = false;
            chk_Assurances.Checked = false;
            rddl_Clients.Enabled = false;
            chk_Clients.Checked = false;
            gv_Liste.Columns["patient"].IsVisible = true;
            gv_Liste.Columns["assurance"].IsVisible = true;
            gv_Liste.Columns["partenaire"].IsVisible = true;
            gv_Liste.Columns["fournisseur"].IsVisible = false;
            gv_Liste.Columns["autreEntree"].IsVisible = true;
            gv_Liste.Columns["autreSortie"].IsVisible = false;
            gv_Liste.DataSource = null;
        }

        private void rb_Fournisseurs_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rddl_Fournisseurs.Enabled = false;
            chk_Fournisseurs.Checked = false;
            rddl_Ristournes.Enabled = false;
            chk_Ristournes.Checked = false;
            gv_Liste.Columns["patient"].IsVisible = false;
            gv_Liste.Columns["assurance"].IsVisible = false;
            gv_Liste.Columns["partenaire"].IsVisible = false;
            gv_Liste.Columns["fournisseur"].IsVisible = true;
            gv_Liste.Columns["autreEntree"].IsVisible = false;
            gv_Liste.Columns["autreSortie"].IsVisible = false;
            gv_Liste.DataSource = null;
        }

        private void rb_Ristournes_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rddl_Fournisseurs.Enabled = false;
            chk_Fournisseurs.Checked = false;
            rddl_Ristournes.Enabled = false;
            chk_Ristournes.Checked = false;
            gv_Liste.Columns["patient"].IsVisible = false;
            gv_Liste.Columns["assurance"].IsVisible = false;
            gv_Liste.Columns["partenaire"].IsVisible = true;
            gv_Liste.Columns["fournisseur"].IsVisible = false;
            gv_Liste.Columns["autreEntree"].IsVisible = false;
            gv_Liste.Columns["autreSortie"].IsVisible = false;
            gv_Liste.DataSource = null;
        }

        private void rb_AutresDepenses_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rddl_Fournisseurs.Enabled = false;
            chk_Fournisseurs.Checked = false;
            rddl_Ristournes.Enabled = false;
            chk_Ristournes.Checked = false;
            gv_Liste.Columns["patient"].IsVisible = false;
            gv_Liste.Columns["assurance"].IsVisible = false;
            gv_Liste.Columns["partenaire"].IsVisible = false;
            gv_Liste.Columns["fournisseur"].IsVisible = false;
            gv_Liste.Columns["autreEntree"].IsVisible = false;
            gv_Liste.Columns["autreSortie"].IsVisible = true;
            gv_Liste.DataSource = null;
        }

        private void chk_Assurances_Click(object sender, EventArgs e)
        {
            if (rb_Assurances.IsChecked == false)
            {
                rb_Assurances.IsChecked = true;
            }

            rddl_Assurances.Text = string.Empty;
            rddl_Assurances.Enabled = chk_Assurances.Checked == false ? true : false;
        }

        private void chk_Clients_Click(object sender, EventArgs e)
        {
            if (rb_Clients.IsChecked == false)
            {
                rb_Clients.IsChecked = true;
            }

            rddl_Clients.Text = string.Empty;
            rddl_Clients.Enabled = chk_Clients.Checked == false ? true : false;
        }

        private void chk_Fournisseurs_Click(object sender, EventArgs e)
        {
            if (rb_Fournisseurs.IsChecked == false)
            {
                rb_Fournisseurs.IsChecked = true;
            }

            rddl_Fournisseurs.Text = string.Empty;
            rddl_Fournisseurs.Enabled = chk_Fournisseurs.Checked == false ? true : false;
        }

        private void chk_Ristournes_Click(object sender, EventArgs e)
        {
            if (rb_Ristournes.IsChecked == false)
            {
                rb_Ristournes.IsChecked = true;
            }

            rddl_Ristournes.Text = string.Empty;
            rddl_Ristournes.Enabled = chk_Ristournes.Checked == false ? true : false;
        }

        private void rb_ToutesLesDepenses_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rddl_Fournisseurs.Enabled = false;
            chk_Fournisseurs.Checked = false;
            rddl_Ristournes.Enabled = false;
            chk_Ristournes.Checked = false;
            gv_Liste.Columns["patient"].IsVisible = false;
            gv_Liste.Columns["assurance"].IsVisible = false;
            gv_Liste.Columns["partenaire"].IsVisible = true;
            gv_Liste.Columns["fournisseur"].IsVisible = true;
            gv_Liste.Columns["autreEntree"].IsVisible = false;
            gv_Liste.Columns["autreSortie"].IsVisible = true;
            gv_Liste.DataSource = null;
        }

        private void btn_Aperçu_Click(object sender, EventArgs e)
        {
            switch (ddl_TypeOperation.Text.Trim())
            {
                case "RECETTES":
                    if (rb_ToutesLesRecettes.IsChecked == true)
                    {
                        {

                            TR_StatistiqueCaisseRecettes rpt = new TR_StatistiqueCaisseRecettes();
                            rpt.objectDataSource1.DataSource = dt;
                            rpt.DataSource = rpt.objectDataSource1;
                            try
                            {
                                rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                            }
                            catch { }

                            entete = "POINT DES RECETTES";
                            rpt.txt_NomApplication.Value = "GESLAB";
                            rpt.txt_Titre.Value = entete;
                            rpt.txt_DateDebut.Value = meb_DateDebut.Value.Date.ToShortDateString();
                            rpt.txt_DateFin.Value = meb_DateFin.Value.Date.ToShortDateString();
                            rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                            rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                                CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                            rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                            Frm_ReportViewer frm = new Frm_ReportViewer("POINT DE CAISSE", rpt);
                            frm.MdiParent = Application.OpenForms["Frm_Menu"];
                            frm.Show();
                        }
                    }
                    if (rb_AutresRecettes.IsChecked == true)
                    {
                        {

                            TR_StatistiqueCaisseAutreEntree rpt = new TR_StatistiqueCaisseAutreEntree();
                            rpt.objectDataSource1.DataSource = dt;
                            rpt.DataSource = rpt.objectDataSource1;
                            try
                            {
                                rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                            }
                            catch { }

                            entete = "POINT DES AUTRES RECETTES";
                            rpt.txt_NomApplication.Value = "GESLAB";
                            rpt.txt_Titre.Value = entete;
                            rpt.txt_DateDebut.Value = meb_DateDebut.Value.Date.ToShortDateString();
                            rpt.txt_DateFin.Value = meb_DateFin.Value.Date.ToShortDateString();
                            rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                            rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                                CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                            rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                            Frm_ReportViewer frm = new Frm_ReportViewer("POINT DE CAISSE", rpt);
                            frm.MdiParent = Application.OpenForms["Frm_Menu"];
                            frm.Show();
                        }
                    }
                    if (rb_Partenaires.IsChecked == true)
                    {
                        if (chk_Partenaires.Checked == true)
                        {
                            entete = "POINT DES RECETTES DU PARTENAIRE [" + ((Partenaires)bds_Partenaires.Current).NomSigle + " " + ((Partenaires)bds_Partenaires.Current).PrenomRaisonSociale + "]";
                        }
                        else
                        {
                            entete = "POINT DES RECETTES DES PARTENAIRES";
                        }

                       
                        {
                            

                            TR_StatistiqueCaissePartenaire rpt = new TR_StatistiqueCaissePartenaire();
                            rpt.objectDataSource1.DataSource = dt;
                            rpt.DataSource = rpt.objectDataSource1;
                            try
                            {
                                rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                            }
                            catch { }

                            rpt.txt_NomApplication.Value = "GESLAB";
                            rpt.txt_Titre.Value =entete;
                            rpt.txt_DateDebut.Value = meb_DateDebut.Value.Date.ToShortDateString();
                            rpt.txt_DateFin.Value = meb_DateFin.Value.Date.ToShortDateString();
                            rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                            rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                                CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                            rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                            Frm_ReportViewer frm = new Frm_ReportViewer("POINT DE CAISSE", rpt);
                            frm.MdiParent = Application.OpenForms["Frm_Menu"];
                            frm.Show();
                        }
                    }

                    if (rb_Assurances.IsChecked == true)
                    {
                        if (chk_Assurances.Checked == true)
                        {
                            entete = "POINT DES RECETTES DE [" + ((Assurance)bds_Assurances.Current).SiglePersonneMorale + " " + ((Assurance)bds_Assurances.Current).RaisonSociale + "]";
                        }
                        else
                        {
                            entete = "POINT DES RECETTES DES ASSURANCES";
                        }

                        {

                            TR_StatistiqueCaisseAssurance rpt = new TR_StatistiqueCaisseAssurance();
                            rpt.objectDataSource1.DataSource = dt;
                            rpt.DataSource = rpt.objectDataSource1;
                            try
                            {
                                rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                            }
                            catch { }

                            rpt.txt_NomApplication.Value = "GESLAB";
                            rpt.txt_Titre.Value = entete;
                            rpt.txt_DateDebut.Value = meb_DateDebut.Value.Date.ToShortDateString();
                            rpt.txt_DateFin.Value = meb_DateFin.Value.Date.ToShortDateString();
                            rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                            rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                                CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                            rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                            Frm_ReportViewer frm = new Frm_ReportViewer("POINT DE CAISSE", rpt);
                            frm.MdiParent = Application.OpenForms["Frm_Menu"];
                            frm.Show();
                        }
                    }

                    if (rb_Clients.IsChecked == true)
                    {
                        if (chk_Clients.Checked == true)
                        {
                            entete = "POINT DES RECETTES DE [" + ((Patient)bds_Clients.Current).NomPersonnePhysique + " " + ((Patient)bds_Clients.Current).PrenomPersonnePhysique + "]";
                        }
                        else
                        {
                            entete = "POINT DES RECETTES DES CLIENTS";
                        }

                        {

                            TR_StatistiqueCaissePatient rpt = new TR_StatistiqueCaissePatient();
                            rpt.objectDataSource1.DataSource = dt;
                            rpt.DataSource = rpt.objectDataSource1;
                            try
                            {
                                rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                            }
                            catch { }

                            rpt.txt_NomApplication.Value = "GESLAB";
                            rpt.txt_Titre.Value = entete;
                            rpt.txt_DateDebut.Value = meb_DateDebut.Value.Date.ToShortDateString();
                            rpt.txt_DateFin.Value = meb_DateFin.Value.Date.ToShortDateString();
                            rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                            rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                                CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                            rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                            Frm_ReportViewer frm = new Frm_ReportViewer("POINT DE CAISSE", rpt);
                            frm.MdiParent = Application.OpenForms["Frm_Menu"];
                            frm.Show();
                        }
                    }

                    break;

                case "DEPENSES":
                    if (rb_ToutesLesDepenses.IsChecked == true)
                    {
                        {

                            TR_StatistiqueCaisseDepense rpt = new TR_StatistiqueCaisseDepense();
                            rpt.objectDataSource1.DataSource = dt;
                            rpt.DataSource = rpt.objectDataSource1;
                            try
                            {
                                rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                            }
                            catch { }

                            entete = "POINT DES DEPENSES";
                            rpt.txt_NomApplication.Value = "GESLAB";
                            rpt.txt_Titre.Value = entete;
                            rpt.txt_DateDebut.Value = meb_DateDebut.Value.Date.ToShortDateString();
                            rpt.txt_DateFin.Value = meb_DateFin.Value.Date.ToShortDateString();
                            rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                            rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                                CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                            rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                            Frm_ReportViewer frm = new Frm_ReportViewer("POINT DE CAISSE", rpt);
                            frm.MdiParent = Application.OpenForms["Frm_Menu"];
                            frm.Show();
                        }
                    }
                    if (rb_AutresDepenses.IsChecked == true)
                    {
                        {

                            TR_StatistiqueCaisseAutreSortie rpt = new TR_StatistiqueCaisseAutreSortie();
                            rpt.objectDataSource1.DataSource = dt;
                            rpt.DataSource = rpt.objectDataSource1;
                            try
                            {
                                rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                            }
                            catch { }

                            entete = "POINT DES AUTRES DEPENSES";
                            rpt.txt_NomApplication.Value = "GESLAB";
                            rpt.txt_Titre.Value = entete;
                            rpt.txt_DateDebut.Value = meb_DateDebut.Value.Date.ToShortDateString();
                            rpt.txt_DateFin.Value = meb_DateFin.Value.Date.ToShortDateString();
                            rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                            rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                                CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                            rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                            Frm_ReportViewer frm = new Frm_ReportViewer("POINT DE CAISSE", rpt);
                            frm.MdiParent = Application.OpenForms["Frm_Menu"];
                            frm.Show();
                        }
                    }
                    if (rb_Fournisseurs.IsChecked == true)
                    {
                        if (chk_Fournisseurs.Checked == true)
                        {
                            entete = "POINT DES DEPENSES POUR [" + ((Fournisseur)bds_Fournisseurs.Current).SiglePersonneMorale + " " + ((Fournisseur)bds_Fournisseurs.Current).RaisonSociale + "]";
                        }
                        else
                        {
                            entete = "POINT DES DEPENSES FOURNISSEURS";
                        }

                        TR_StatistiqueCaisseFournisseur rpt = new TR_StatistiqueCaisseFournisseur();
                        rpt.objectDataSource1.DataSource = dt;
                        rpt.DataSource = rpt.objectDataSource1;
                        try
                        {
                            rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                        }
                        catch { }

                        rpt.txt_NomApplication.Value = "GESLAB";
                        rpt.txt_Titre.Value = entete;
                        rpt.txt_DateDebut.Value = meb_DateDebut.Value.Date.ToShortDateString();
                        rpt.txt_DateFin.Value = meb_DateFin.Value.Date.ToShortDateString();
                        rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                        rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                            CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                        rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                        Frm_ReportViewer frm = new Frm_ReportViewer("POINT DE CAISSE", rpt);
                        frm.MdiParent = Application.OpenForms["Frm_Menu"];
                        frm.Show();

                    }

                    if (rb_Ristournes.IsChecked == true)
                    {
                        if (chk_Ristournes.Checked == true)
                        {
                            entete = "POINT DES RISTOURNES POUR [" + ((Partenaires)bds_Ristournes.Current).NomSigle + " " + ((Partenaires)bds_Ristournes.Current).PrenomRaisonSociale + "]";
                        }
                        else
                        {
                            entete = "POINT DES RISTOURNES ";
                        }

                        TR_StatistiqueCaisseRistourne rpt = new TR_StatistiqueCaisseRistourne();
                        rpt.objectDataSource1.DataSource = dt;
                        rpt.DataSource = rpt.objectDataSource1;
                        try
                        {
                            rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                        }
                        catch { }

                        rpt.txt_NomApplication.Value = "GESLAB";
                        rpt.txt_Titre.Value = entete;
                        rpt.txt_DateDebut.Value = meb_DateDebut.Value.Date.ToShortDateString();
                        rpt.txt_DateFin.Value = meb_DateFin.Value.Date.ToShortDateString();
                        rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                        rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                            CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                        rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                        Frm_ReportViewer frm = new Frm_ReportViewer("POINT DE CAISSE", rpt);
                        frm.MdiParent = Application.OpenForms["Frm_Menu"];
                        frm.Show();
                    }

                    break;

                default:
                    {

                        TR_StatistiqueCaisseTOUT rpt = new TR_StatistiqueCaisseTOUT();
                        rpt.objectDataSource1.DataSource = dt;
                        rpt.DataSource = rpt.objectDataSource1;
                        rpt.ReportParameters["montantDeb"].Value =Convert.ToInt32(Rapport.SoldeCaisse(meb_DateDebut.Value.Date.AddDays(-1)));
                        try
                        {
                            rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                        }
                        catch { }

                        try
                        {
                            entete = "POINT PERIODIQUE DES RECETTES ET DEPENSES ";
                            rpt.txt_NomApplication.Value = "GESLAB";
                            rpt.txt_Titre.Value = entete;
                            rpt.txt_DateDebut.Value = meb_DateDebut.Value.Date.ToShortDateString();
                            rpt.txt_DateFin.Value = meb_DateFin.Value.Date.ToShortDateString();
                            rpt.txt_debut.Value = "SOLDE DE LA CAISSE AU " + meb_DateDebut.Value.Date.AddDays(-1).ToShortDateString();
                            rpt.txt_Fin.Value = "POINT DE LA CAISSE AU  " + meb_DateFin.Value.Date.ToShortDateString();
                            rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                            rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                                CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                            rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                            Frm_ReportViewer frm = new Frm_ReportViewer("POINT DE CAISSE", rpt);
                            frm.MdiParent = Application.OpenForms["Frm_Menu"];
                            frm.Show();
                        }
                        catch { }
                    }
                    break;
            }
        }
    }
}
