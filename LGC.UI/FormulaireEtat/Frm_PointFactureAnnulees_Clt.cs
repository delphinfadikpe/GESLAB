using LGC.Business;
using LGC.Business.GestionDesAnalyses;
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
using Telerik.WinControls.Export;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace LGC.UI.FormulaireEtat
{
    public partial class Frm_PointFactureAnnulees_Clt : Telerik.WinControls.UI.RadForm
    {
        List<DemandeAnalyse> olstDemandeAnalyse = new List<DemandeAnalyse>();
        public List<DemandeAnalyse> lstDemandeAnalyse = new List<DemandeAnalyse>();
        public Partenaires oPartenaires = new Partenaires();
        private GridViewSpreadExport spreadExporter;

        public Frm_PointFactureAnnulees_Clt(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }

        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            bds_Demandes.DataSource = new List<DemandeAnalyse>();
            olstDemandeAnalyse = DemandeAnalyse.Liste(meb_DateDebut.Value, meb_DateFin.Value);
            bds_Demandes.DataSource = olstDemandeAnalyse.FindAll(x=>x.EstAnnulee==true);
        }

        private void renderer_WorkbookCreated(object sender, WorkbookCreatedEventArgs e)
        {
            Worksheet worksheet = e.Workbook.ActiveWorksheet;
            worksheet.Columns[worksheet.UsedCellRange].AutoFitWidth();
        }

        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                bds_AnalyseDemande.DataSource = new List<AnalyseDemande>();
                if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count > 0)
                {
                    bds_AnalyseDemande.DataSource = AnalyseDemande.Liste(null, ((DemandeAnalyse)bds_Demandes.Current).NumDemande, null, null,
                        null, null, null, null, null, null, false, null, null);
                }
            }
            catch { }
        }

       

        private void chk_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_Exporter_Click(object sender, EventArgs e)
        {
            if (gv_Liste.Rows != null && gv_Liste.Rows.Count != 0)
            {

                try
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "Excel files|*.xls";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        this.spreadExporter = new GridViewSpreadExport(this.gv_Liste);
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

        private void btn_Avoir_Click(object sender, EventArgs e)
        {

        }
    }
}
