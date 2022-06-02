namespace LGC.UI.Impressions
{
    partial class TR_CodeBarre
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Barcodes.Code11Encoder code11Encoder1 = new Telerik.Reporting.Barcodes.Code11Encoder();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.groupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.panel2 = new Telerik.Reporting.Panel();
            this.groupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.panel1 = new Telerik.Reporting.Panel();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel3 = new Telerik.Reporting.Panel();
            this.bc_Chaine = new Telerik.Reporting.Barcode();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.txt_numDemande = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // groupFooterSection
            // 
            this.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D);
            this.groupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel2});
            this.groupFooterSection.Name = "groupFooterSection";
            // 
            // panel2
            // 
            this.panel2.Docking = Telerik.Reporting.DockingStyle.Top;
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.7199001312255859D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.panel2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(210)))), ((int)(((byte)(252)))));
            this.panel2.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.panel2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // groupHeaderSection
            // 
            this.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269D);
            this.groupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.groupHeaderSection.Name = "groupHeaderSection";
            // 
            // panel1
            // 
            this.panel1.Docking = Telerik.Reporting.DockingStyle.Bottom;
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txt_numDemande});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.2000001072883606D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.7199001312255859D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.panel1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(210)))), ((int)(((byte)(252)))));
            this.panel1.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.panel1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel3});
            this.detail.Name = "detail";
            // 
            // panel3
            // 
            this.panel3.Docking = Telerik.Reporting.DockingStyle.Fill;
            this.panel3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.bc_Chaine});
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.7199001312255859D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.panel3.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.panel3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // bc_Chaine
            // 
            this.bc_Chaine.Encoder = code11Encoder1;
            this.bc_Chaine.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.05291646346449852D), Telerik.Reporting.Drawing.Unit.Cm(0.099999949336051941D));
            this.bc_Chaine.Name = "bc_Chaine";
            this.bc_Chaine.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.6000003814697266D), Telerik.Reporting.Drawing.Unit.Cm(0.59999990463256836D));
            this.bc_Chaine.Stretch = true;
            this.bc_Chaine.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.bc_Chaine.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.bc_Chaine.Value = "=Fields.NumLigne";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(LGC.Business.GestionDesAnalyses.PrelevementAnalyseDemande);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // txt_numDemande
            // 
            this.txt_numDemande.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.txt_numDemande.Name = "txt_numDemande";
            this.txt_numDemande.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.6000003814697266D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.txt_numDemande.Style.Font.Bold = true;
            this.txt_numDemande.Style.Font.Italic = true;
            this.txt_numDemande.Style.Font.Name = "Comic Sans MS";
            this.txt_numDemande.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.txt_numDemande.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txt_numDemande.Value = "Demande N° ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.6000003814697266D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Italic = true;
            this.textBox1.Style.Font.Name = "Comic Sans MS";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Value = "= Fields.CodeAnalyse + \"-\" + Fields.CodePrelevement";
            // 
            // TR_CodeBarre
            // 
            this.DataSource = this.objectDataSource1;
            group1.GroupFooter = this.groupFooterSection;
            group1.GroupHeader = this.groupHeaderSection;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.NumLigne"));
            group1.Name = "grpChaine";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection,
            this.groupFooterSection,
            this.detail});
            this.Name = "TR_CodeBarre";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperSize = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(78D), Telerik.Reporting.Drawing.Unit.Mm(18D));
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(7.7199001312255859D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Panel panel3;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.GroupFooterSection groupFooterSection;
        private Telerik.Reporting.Panel panel2;
        public Telerik.Reporting.ObjectDataSource objectDataSource1;
        public Telerik.Reporting.Barcode bc_Chaine;
        private Telerik.Reporting.TextBox textBox1;
        public Telerik.Reporting.TextBox txt_numDemande;
    }
}