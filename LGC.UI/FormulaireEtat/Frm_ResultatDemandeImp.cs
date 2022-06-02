using LGC.Business;
using LGC.Business.GestionDesAnalyses;
using LGC.UI.Crystal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.RichTextEditor.UI;
using Telerik.WinControls.UI;
using Telerik.WinForms.Documents;
using Telerik.WinForms.Documents.Model;
using Telerik.WinForms.RichTextEditor;

namespace LGC.UI.FormulaireEtat
{
    public partial class Frm_ResultatDemandeImp : Telerik.WinControls.UI.RadForm
    {
        List<ResultatParametreAnalyse> lstResultatParametreAnalyse = new List<ResultatParametreAnalyse>();
        List<AnalyseDemande> lstAnalyse = new List<AnalyseDemande>();
        List<ResultatDemande> lstResultatDemande = new List<ResultatDemande>();
       
        private void ChargerListeResultatParametreAnalyse()
        {
            lstResultatParametreAnalyse = ResultatParametreAnalyse.Liste(null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, false, null);
            bds_ResultatParametreAnalyse.DataSource = new List<ResultatParametreAnalyse>();
        }
        private void ChargerListeAnalyse()
        {
            lstAnalyse = AnalyseDemande.Liste(null, null
                , null, null, null, null, null, null, null, null, false, null, null);
            bds_AnalyseDemande.DataSource = new List<AnalyseDemande>();
        }
        private void ChargerListe()
        {
            lstResultatDemande = ResultatDemande.Liste(null, null, null, null, true,
                null, null, null, null, null, null, null, null, null, null, false, null);
            bds_Resultat.DataSource = new List<ResultatDemande>();
             
        }
        public Frm_ResultatDemandeImp()
        {
            InitializeComponent();
             
        }
       
        private void Frm_ResultatDemandeImp_Load(object sender, EventArgs e)
        {
            meb_DateDebut.Value = DateTime.Now;
            meb_DateFin.Value = DateTime.Now;
            ChargerListe();
            ChargerListeAnalyse();
            ChargerListeResultatParametreAnalyse();
//            RadDocument document = new RadDocument(
//                ); 
//            string randomText = @"On the Insert tab, the galleries include items that
//                                are designed to coordinate with the overall look of 
//                                your document. You can use these galleries to insert tables, 
//                                headers, footers, lists, cover pages, and other document building blocks. 
//                                When you create pictures, charts, or diagrams
//                                , they also coordinate with your current document look"; 
//            RadDocumentEditor documentEditor = new RadDocumentEditor(document); 
//            documentEditor.Insert(randomText); 
//            this.radRichTextEditor1.Document = (RadDocument)document.CreateDeepCopy(); 
//            this.radRichTextEditor1.Document.Sections.First.Headers.Default.Body = document;
            //if (Program.ThemeName == "VisualStudio2012Dark" || Program.ThemeName == "HighContrastBlack")
            //{
            //    this.radRichTextEditor1.Document.StyleRepository["Normal"].SpanProperties.ForeColor =
            //        Telerik.WinControls.RichTextEditor.UI.Colors.White;
            //} 
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            bds_Resultat.DataSource = lstResultatDemande.FindAll(x => x.DateDemande.Date >= meb_DateDebut.Value.Date &&
                x.DateDemande.Date <= meb_DateFin.Value.Date);
             bds_AnalyseDemande.DataSource = lstAnalyse.FindAll(x => x.DateDemande.Date >= meb_DateDebut.Value.Date &&
                x.DateDemande.Date <= meb_DateFin.Value.Date);
             bds_ResultatParametreAnalyse.DataSource = lstResultatParametreAnalyse.FindAll(x => x.DateDemande.Date >= meb_DateDebut.Value.Date &&
                 x.DateDemande.Date <= meb_DateFin.Value.Date);
        }

        private void meb_DateFin_ValueChanged(object sender, EventArgs e)
        {
            bds_Resultat.DataSource = new List<ResultatDemande>();
            bds_AnalyseDemande.DataSource = new List<AnalyseDemande>();
            bds_ResultatParametreAnalyse.DataSource = new List<ResultatParametreAnalyse>();
        }

        private void meb_DateDebut_ValueChanged(object sender, EventArgs e)
        {
            bds_Resultat.DataSource = new List<ResultatDemande>();
            bds_AnalyseDemande.DataSource = new List<AnalyseDemande>();
            bds_ResultatParametreAnalyse.DataSource = new List<ResultatParametreAnalyse>();
        }
        private void btn_Imprimer_Click(object sender, EventArgs e)
        {
            if (bds_Resultat.Current != null)
            {
                ResultatDemande obj = (ResultatDemande)bds_Resultat.Current;
                TR_ResultatDemande rpt = new TR_ResultatDemande();
                rpt.objectDataSource1.DataSource = ResultatDemande.ResultatDemandeFonction(obj.NumDemande);
                rpt.DataSource = rpt.objectDataSource1;
                if (obj.Logo != "" && obj.Logo !=null)
                {

                    try
                    {
                        rpt.ReportParameters["logo"].Value = obj.Logo.Trim();
                    }
                    catch { }
                }
                else if (CurrentUser.OSociete.Logo == "" )
                {
                    try
                    {
                        rpt.ReportParameters["logo"].Value = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "entete_vide.png";
                    }
                    catch { }
                   
                }
                else
                {

                    try
                    {
                        rpt.ReportParameters["logo"].Value = (CurrentUser.ImagePath + "\\" +
                   "logo_" + "(" + CurrentUser.OSociete.NumLigne.ToString() + ").jpg");
                    }
                    catch { }
                   
                }
                
                rpt.txt_date.Value = "Cotonou, le " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                Frm_ReportViewer frm = new Frm_ReportViewer("RESULTAT", rpt);
                frm.ShowDialog();

            }
        }

        private void radCollapsiblePanel1_PanelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
