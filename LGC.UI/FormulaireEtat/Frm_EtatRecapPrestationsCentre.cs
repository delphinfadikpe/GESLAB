﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using LGO.UI.Crystal;
using Telerik.WinControls.Export;
using Telerik.Windows.Documents.Spreadsheet.Model;
using LGC.Business;
using LGC.Business.Impressions;
using LGC.Business.Parametre;
using LGC.UI.Impressions;
using LGC.UI;

namespace LGO.UI.Impressions
{
    public partial class Frm_EtatRecapPrestationsCentre : Telerik.WinControls.UI.RadForm
    {
        #region Declaration
        DataTable dt;
        //List<PersonneMorale> lstDistributeur = new List<PersonneMorale>();
        private GridViewSpreadExport spreadExporter;
        private string type;
        #endregion

        #region Autres

        private void ChargerListeDistributeur()
        {
            //lstDistributeur = PersonneMorale.Liste(null, null, null, null, null,
            //    null, null, null,
            //    null, null, null, "DISTRIBUTEURS",null,
            //    null, null, null, null, null, null, null, false, null,null,null,null,null);
            //bds_Distributeur.DataSource = lstDistributeur;
        }

      
        #endregion
        
        #region Formulaire
        public Frm_EtatRecapPrestationsCentre(string theme,string mType)
        {
            InitializeComponent();
            this.ThemeName = theme;
            type = mType;
            
        }

        private void Frm_GenerationSouscription_Load(object sender, EventArgs e)
        {
            txt_DateFermeture.Value = DateTime.Now;
            txt_DateOuverture.Value = DateTime.Now;
            //ChargerListeDistributeur();
           

            if (type == "PRESTATION")
            {
                dgv_Liste.Columns["impayesMoisPasse"].IsVisible = true;
                dgv_Liste.Columns["paiementMois"].IsVisible = true;
                dgv_Liste.Columns["restantDu"].IsVisible = true;
                dgv_Liste.Columns["ristourneAreverser"].IsVisible = true;
                dgv_Liste.Columns["montantDu"].IsVisible = false;
                this.Text = "ETAT DES PRESTATIONS DES CENTRES";
                lbl_TypePersonne.Visible = rddl_TypePersonne.Visible = false;
            }
            else if (type == "CREANCE")
            {
                dgv_Liste.Columns["impayesMoisPasse"].IsVisible = true;
                dgv_Liste.Columns["paiementMois"].IsVisible = true;
                dgv_Liste.Columns["restantDu"].IsVisible = true;
                dgv_Liste.Columns["ristourneAreverser"].IsVisible = true;
                dgv_Liste.Columns["montantDu"].IsVisible = false;
                this.Text = "POINT DES CREANCES";
                lbl_TypePersonne.Visible = rddl_TypePersonne.Visible = true;
            }
            else
            {
                dgv_Liste.Columns["impayesMoisPasse"].IsVisible = false;
                dgv_Liste.Columns["paiementMois"].IsVisible = false;
                dgv_Liste.Columns["restantDu"].IsVisible = false;
                dgv_Liste.Columns["ristourneAreverser"].IsVisible = false;
                dgv_Liste.Columns["montantDu"].IsVisible = true;
                this.Text = "POINT DES RISTOURNES";
                lbl_TypePersonne.Visible = rddl_TypePersonne.Visible = false;
            }

        } 
        #endregion

        private void btn_Generer_Click(object sender, EventArgs e)
        {

            if (type == "PRESTATION" )
            {
                dt = Rapport.EtatRecapPrestationsCentre(txt_DateOuverture.Value.Date, txt_DateFermeture.Value.Date,null,null);
              
            }
            else if ( type == "CREANCE")
            {
                    switch(rddl_TypePersonne.Text.Trim())
                    {
                        case "PERSONNE PHYSIQUE":
                            dt = Rapport.EtatRecapPrestationsCentre(txt_DateOuverture.Value.Date, txt_DateFermeture.Value.Date, "PAIEMENT EN FIN DE PERIODE", "PP");
                            break;
                        case"PERSONNE MORALE":
                            dt = Rapport.EtatRecapPrestationsCentre(txt_DateOuverture.Value.Date, txt_DateFermeture.Value.Date, "PAIEMENT EN FIN DE PERIODE", "PM");
                            break;
                        default:
                            dt = Rapport.EtatRecapPrestationsCentre(txt_DateOuverture.Value.Date, txt_DateFermeture.Value.Date, "PAIEMENT EN FIN DE PERIODE", null);
                            break;
                    }
               
            }
            else
            {
                dt = Rapport.EtatRecapPrestationsCentre(txt_DateOuverture.Value.Date, txt_DateFermeture.Value.Date, "RISTOURNE EN FIN DE PERIODE", null);
            }

            dgv_Liste.DataSource = dt;
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            if (type == "PRESTATION")
            {
                TR_EtatRecapPrestationsCentre rpt = new TR_EtatRecapPrestationsCentre();
                rpt.objectDataSource1.DataSource = dt;
                rpt.DataSource = rpt.objectDataSource1;
                rpt.txt_Periode.Value = "DU " + txt_DateOuverture.Value.Date.ToShortDateString() + " AU " + txt_DateFermeture.Value.Date.ToShortDateString();
                rpt.txt_NomApplication.Value = CurrentUser.LogicielHote;
                Frm_ReportViewer frm = new Frm_ReportViewer("ETAT RECAPITULATIF DES PRESTATIONS AVEC LES CENTRES", rpt);
                frm.ShowDialog();
            }
            else if (type == "CREANCE")        
                {
                    TR_CreancePeriodique rpt = new TR_CreancePeriodique();
                    rpt.objectDataSource1.DataSource = dt;
                    rpt.DataSource = rpt.objectDataSource1;
                    rpt.txt_Periode.Value = "DU " + txt_DateOuverture.Value.Date.ToShortDateString() + " AU " + txt_DateFermeture.Value.Date.ToShortDateString();
                    rpt.txt_NomApplication.Value = CurrentUser.LogicielHote;
                    Frm_ReportViewer frm = new Frm_ReportViewer("POINT DES CREANCES", rpt);
                    frm.ShowDialog();
                }
            else 
            {
                TR_PointDesRistournes rpt = new TR_PointDesRistournes();
                rpt.objectDataSource1.DataSource = dt;
                rpt.DataSource = rpt.objectDataSource1;
                rpt.txt_Periode.Value = "DU " + txt_DateOuverture.Value.Date.ToShortDateString() + " AU " + txt_DateFermeture.Value.Date.ToShortDateString();
                rpt.txt_NomApplication.Value = CurrentUser.LogicielHote;
                Frm_ReportViewer frm = new Frm_ReportViewer("POINT DES RISTOURNES", rpt);
                frm.ShowDialog();
            }
        }

        private void ddl_Distributeur_TextChanged(object sender, EventArgs e)
        {

            int numRows = dgv_Liste.Rows.Count;
            for (int i = 0; i < numRows; i++)
            {
                int max = dgv_Liste.Rows.Count - 1;
                dgv_Liste.Rows.Remove(dgv_Liste.Rows[max]);

            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_exporter_Click(object sender, EventArgs e)
        {
            if (dgv_Liste.Rows != null && dgv_Liste.Rows.Count != 0)
            {

                try
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "Excel files|*.xls";
                    //if (dialog.ShowDialog() != DialogResult.OK)
                    //{
                    //    return;
                    //}
                    //if (dialog.FileName.Equals(String.Empty))
                    //{
                    //    RadMessageBox.SetThemeName(this.ThemeName);
                    //    RadMessageBox.Show(this, "Veuillez entrer le nom du fichier.", "OPCCIEL",
                    //        MessageBoxButtons.OK, RadMessageIcon.Error);
                    //    return;
                    //}                          

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        this.spreadExporter = new GridViewSpreadExport(this.dgv_Liste);
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
                RadMessageBox.Show(this, "La grille est vide.", "OPCCIEL",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }


        private void renderer_WorkbookCreated(object sender, WorkbookCreatedEventArgs e)
        {
            Worksheet worksheet = e.Workbook.ActiveWorksheet;
            worksheet.Columns[worksheet.UsedCellRange].AutoFitWidth();
        }

        private void rchk_Partenaires_Click(object sender, EventArgs e)
        {
           
        }

        private void ddl_Distributeur_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            dgv_Liste.DataSource=null;
        }

        private void txt_DateOuverture_ValueChanged(object sender, EventArgs e)
        {
            dgv_Liste.DataSource = null;
        }

        private void rddl_TypePersonne_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            dgv_Liste.DataSource = null;
        }
        

        #region Boutons de commande
       
        #endregion

       
    }
}
