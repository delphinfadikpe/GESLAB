using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace LGC.UI
{
    public partial class Frm_ReportViewer : Telerik.WinControls.UI.RadForm
    {
        public Frm_ReportViewer(string titre, Telerik.Reporting.Report rpt)
        {
            InitializeComponent();

            this.Text = "Apercu-" + titre.Trim();

            Telerik.Reporting.InstanceReportSource reportSource = new Telerik.Reporting.InstanceReportSource();
            reportSource.ReportDocument = rpt;

            this.reportViewer1.ReportSource = reportSource;
            this.reportViewer1.RefreshReport();
            this.reportViewer1.ViewMode = Telerik.ReportViewer.WinForms.ViewMode.PrintPreview;
        }
    }
}
