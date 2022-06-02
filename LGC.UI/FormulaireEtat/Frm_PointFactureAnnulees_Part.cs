using LGC.Business;
using LGC.Business.GestionDeLaCaisse;
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
    public partial class Frm_PointFactureAnnulees_Part : Telerik.WinControls.UI.RadForm
    {
        List<FacturePartenaire> olstFacturePartenaire = new List<FacturePartenaire>();       
        private GridViewSpreadExport spreadExporter;

        public Frm_PointFactureAnnulees_Part(string theme)
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
            bds_FacturePartenaires.DataSource = new List<FacturePartenaire>();
            olstFacturePartenaire = FacturePartenaire.Liste(null, null, null, null, null, null, null, null, null, null, null, null, null, null, true, null);
            bds_FacturePartenaires.DataSource = olstFacturePartenaire.FindAll(x => x.DateFacture >= meb_DateDebut.Value.Date && x.DateFacture <= meb_DateFin.Value.Date);
        }

        private void renderer_WorkbookCreated(object sender, WorkbookCreatedEventArgs e)
        {
            Worksheet worksheet = e.Workbook.ActiveWorksheet;
            worksheet.Columns[worksheet.UsedCellRange].AutoFitWidth();
        }

        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
           
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
    }
}
