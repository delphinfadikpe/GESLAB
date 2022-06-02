namespace LGC.UI.Impressions
{
    partial class TR_StatistiqueCaisseDepense
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.txt_NomApplication = new Telerik.Reporting.TextBox();
            this.shape19 = new Telerik.Reporting.Shape();
            this.txt_Devise = new Telerik.Reporting.TextBox();
            this.txt_Ligne1 = new Telerik.Reporting.TextBox();
            this.txt_Ligne2 = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.panel5 = new Telerik.Reporting.Panel();
            this.shape15 = new Telerik.Reporting.Shape();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel2 = new Telerik.Reporting.Panel();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.shape7 = new Telerik.Reporting.Shape();
            this.shape10 = new Telerik.Reporting.Shape();
            this.shape12 = new Telerik.Reporting.Shape();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.shape2 = new Telerik.Reporting.Shape();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.shape11 = new Telerik.Reporting.Shape();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.shape14 = new Telerik.Reporting.Shape();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.panel6 = new Telerik.Reporting.Panel();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.shape5 = new Telerik.Reporting.Shape();
            this.shape3 = new Telerik.Reporting.Shape();
            this.shape6 = new Telerik.Reporting.Shape();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.shape1 = new Telerik.Reporting.Shape();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.shape9 = new Telerik.Reporting.Shape();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.shape13 = new Telerik.Reporting.Shape();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.txt_DateDebut = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.txt_DateFin = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.txt_Titre = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.pb_imageEntete = new Telerik.Reporting.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(LGC.DataAccess.Impressions.ImpressionsDataSet.FT_StatistiquesCaisseDataTable);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox24,
            this.textBox23,
            this.txt_NomApplication,
            this.shape19,
            this.txt_Devise,
            this.txt_Ligne1,
            this.txt_Ligne2});
            this.pageFooter.Name = "pageFooter";
            // 
            // textBox24
            // 
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269D), Telerik.Reporting.Drawing.Unit.Cm(2.8000009059906006D));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox24.Style.Font.Bold = true;
            this.textBox24.Style.Font.Name = "Times New Roman";
            this.textBox24.Value = "Imprmé le {ExecutionTime} ";
            // 
            // textBox23
            // 
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(24.700000762939453D), Telerik.Reporting.Drawing.Unit.Cm(2.8143880367279053D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.5300016403198242D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox23.Style.Font.Bold = true;
            this.textBox23.Style.Font.Name = "Times New Roman";
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.Value = "Page {PageNumber}";
            // 
            // txt_NomApplication
            // 
            this.txt_NomApplication.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.59999942779541D), Telerik.Reporting.Drawing.Unit.Cm(2.8000001907348633D));
            this.txt_NomApplication.Name = "txt_NomApplication";
            this.txt_NomApplication.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.7302026748657227D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.txt_NomApplication.Style.Font.Bold = true;
            this.txt_NomApplication.Style.Font.Name = "Times New Roman";
            this.txt_NomApplication.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txt_NomApplication.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txt_NomApplication.Value = "NOM APPLICATION";
            // 
            // shape19
            // 
            this.shape19.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.30000004172325134D), Telerik.Reporting.Drawing.Unit.Cm(0.20000070333480835D));
            this.shape19.Name = "shape19";
            this.shape19.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(28.899894714355469D), Telerik.Reporting.Drawing.Unit.Cm(0.15062467753887177D));
            this.shape19.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape19.Style.Color = System.Drawing.Color.Black;
            this.shape19.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // txt_Devise
            // 
            this.txt_Devise.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.30010038614273071D), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433D));
            this.txt_Devise.Name = "txt_Devise";
            this.txt_Devise.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(28.899692535400391D), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433D));
            this.txt_Devise.Style.Font.Bold = true;
            this.txt_Devise.Style.Font.Name = "Times New Roman";
            this.txt_Devise.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txt_Devise.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txt_Devise.Value = "";
            // 
            // txt_Ligne1
            // 
            this.txt_Ligne1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.30000004172325134D), Telerik.Reporting.Drawing.Unit.Cm(1.0000003576278687D));
            this.txt_Ligne1.Name = "txt_Ligne1";
            this.txt_Ligne1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(28.899894714355469D), Telerik.Reporting.Drawing.Unit.Cm(0.39999979734420776D));
            this.txt_Ligne1.Style.Font.Bold = true;
            this.txt_Ligne1.Style.Font.Name = "Times New Roman";
            this.txt_Ligne1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txt_Ligne1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txt_Ligne1.Value = "";
            // 
            // txt_Ligne2
            // 
            this.txt_Ligne2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.30000004172325134D), Telerik.Reporting.Drawing.Unit.Cm(1.4000000953674316D));
            this.txt_Ligne2.Name = "txt_Ligne2";
            this.txt_Ligne2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(28.899894714355469D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.txt_Ligne2.Style.Font.Bold = true;
            this.txt_Ligne2.Style.Font.Name = "Times New Roman";
            this.txt_Ligne2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txt_Ligne2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txt_Ligne2.Value = "";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(3.4710330963134766D);
            this.reportFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel5});
            this.reportFooter.Name = "reportFooter";
            // 
            // panel5
            // 
            this.panel5.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.panel5.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.shape15,
            this.textBox26,
            this.textBox27});
            this.panel5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.30000004172325134D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel5.Name = "panel5";
            this.panel5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(28.999795913696289D), Telerik.Reporting.Drawing.Unit.Cm(0.90000033378601074D));
            this.panel5.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel5.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.panel5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel5.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // shape15
            // 
            this.shape15.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(26.399904251098633D), Telerik.Reporting.Drawing.Unit.Cm(-4.0372211174144468E-07D));
            this.shape15.Name = "shape15";
            this.shape15.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(0.90000075101852417D));
            this.shape15.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape15.Style.Color = System.Drawing.Color.Blue;
            this.shape15.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // textBox26
            // 
            this.textBox26.Format = "{0:N0}";
            this.textBox26.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(26.59990119934082D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2999985218048096D), Telerik.Reporting.Drawing.Unit.Cm(0.80000042915344238D));
            this.textBox26.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox26.Style.Font.Bold = true;
            this.textBox26.Style.Font.Name = "Times New Roman";
            this.textBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox26.Value = "= Sum(Fields.montant)";
            // 
            // textBox27
            // 
            this.textBox27.Format = "{0:N4}";
            this.textBox27.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.099999949336051941D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(26.299703598022461D), Telerik.Reporting.Drawing.Unit.Cm(0.77103334665298462D));
            this.textBox27.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox27.Style.Font.Bold = true;
            this.textBox27.Style.Font.Name = "Times New Roman";
            this.textBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox27.Value = "TOTAL............................................................................" +
    "................................................................................" +
    "....................";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.62896633148193359D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel2});
            this.detail.Name = "detail";
            // 
            // panel2
            // 
            this.panel2.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox15,
            this.textBox17,
            this.textBox18,
            this.shape7,
            this.shape10,
            this.shape12,
            this.textBox21,
            this.shape2,
            this.textBox6,
            this.textBox11,
            this.shape11,
            this.textBox16,
            this.shape14});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.30000004172325134D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(28.999898910522461D), Telerik.Reporting.Drawing.Unit.Cm(0.62886619567871094D));
            this.panel2.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel2.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.panel2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel2.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox15
            // 
            this.textBox15.Format = "{0:d}";
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.099999949336051941D), Telerik.Reporting.Drawing.Unit.Cm(4.0372211174144468E-07D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3528165817260742D), Telerik.Reporting.Drawing.Unit.Cm(0.53489953279495239D));
            this.textBox15.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox15.Style.Font.Name = "Times New Roman";
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.Value = "=  Fields.dateOperation";
            // 
            // textBox17
            // 
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.6998996734619141D), Telerik.Reporting.Drawing.Unit.Cm(4.0372211174144468E-07D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2999999523162842D), Telerik.Reporting.Drawing.Unit.Cm(0.53489953279495239D));
            this.textBox17.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox17.Style.Font.Name = "Times New Roman";
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox17.Value = "= Fields.modeReglement";
            // 
            // textBox18
            // 
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.1999015808105469D), Telerik.Reporting.Drawing.Unit.Cm(4.0372211174144468E-07D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.3999998569488525D), Telerik.Reporting.Drawing.Unit.Cm(0.53489953279495239D));
            this.textBox18.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox18.Style.Font.Name = "Times New Roman";
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.Value = "=  Fields.reference";
            // 
            // shape7
            // 
            this.shape7.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(26.399900436401367D), Telerik.Reporting.Drawing.Unit.Cm(-4.0372211174144468E-07D));
            this.shape7.Name = "shape7";
            this.shape7.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(0.62886655330657959D));
            this.shape7.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape7.Style.Color = System.Drawing.Color.Blue;
            this.shape7.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // shape10
            // 
            this.shape10.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.9999003410339355D), Telerik.Reporting.Drawing.Unit.Cm(-4.0372211174144468E-07D));
            this.shape10.Name = "shape10";
            this.shape10.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(0.62283170223236084D));
            this.shape10.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape10.Style.Color = System.Drawing.Color.Blue;
            this.shape10.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // shape12
            // 
            this.shape12.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.4998998641967773D), Telerik.Reporting.Drawing.Unit.Cm(-4.0372211174144468E-07D));
            this.shape12.Name = "shape12";
            this.shape12.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(0.62886655330657959D));
            this.shape12.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape12.Style.Color = System.Drawing.Color.Blue;
            this.shape12.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // textBox21
            // 
            this.textBox21.Format = "{0:N0}";
            this.textBox21.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(26.59990119934082D), Telerik.Reporting.Drawing.Unit.Cm(0.034900162369012833D));
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2999985218048096D), Telerik.Reporting.Drawing.Unit.Cm(0.52896600961685181D));
            this.textBox21.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox21.Style.Font.Name = "Times New Roman";
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox21.Value = "=  Fields.montant";
            // 
            // shape2
            // 
            this.shape2.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.59999942779541D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.shape2.Name = "shape2";
            this.shape2.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(0.62886655330657959D));
            this.shape2.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape2.Style.Color = System.Drawing.Color.Blue;
            this.shape2.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.7999992370605469D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.9999985694885254D), Telerik.Reporting.Drawing.Unit.Cm(0.53489953279495239D));
            this.textBox6.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox6.Style.Font.Name = "Times New Roman";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "=   Fields.fournisseur";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(20.799999237060547D), Telerik.Reporting.Drawing.Unit.Cm(0.026458332315087318D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.59999942779541D), Telerik.Reporting.Drawing.Unit.Cm(0.53489953279495239D));
            this.textBox11.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox11.Style.Font.Name = "Times New Roman";
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.Value = "=   Fields.autreSortie";
            // 
            // shape11
            // 
            this.shape11.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.800000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.shape11.Name = "shape11";
            this.shape11.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(0.62886655330657959D));
            this.shape11.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape11.Style.Color = System.Drawing.Color.Blue;
            this.shape11.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // textBox16
            // 
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15D), Telerik.Reporting.Drawing.Unit.Cm(0.026458332315087318D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.5999984741210938D), Telerik.Reporting.Drawing.Unit.Cm(0.53489953279495239D));
            this.textBox16.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox16.Style.Font.Name = "Times New Roman";
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.Value = "=    Fields.partenaire";
            // 
            // shape14
            // 
            this.shape14.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(20.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.shape14.Name = "shape14";
            this.shape14.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(0.62886655330657959D));
            this.shape14.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape14.Style.Color = System.Drawing.Color.Blue;
            this.shape14.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(4.1000008583068848D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel6,
            this.panel1,
            this.textBox2,
            this.textBox3,
            this.textBox1,
            this.txt_DateDebut,
            this.textBox9,
            this.txt_DateFin,
            this.textBox12,
            this.txt_Titre});
            this.reportHeader.Name = "reportHeader";
            this.reportHeader.Style.Visible = true;
            // 
            // panel6
            // 
            this.panel6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433D), Telerik.Reporting.Drawing.Unit.Cm(1.0000001192092896D));
            this.panel6.Name = "panel6";
            this.panel6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(28.699897766113281D), Telerik.Reporting.Drawing.Unit.Cm(0.80000019073486328D));
            this.panel6.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel6.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.panel6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox5,
            this.textBox7,
            this.textBox8,
            this.shape5,
            this.shape3,
            this.shape6,
            this.textBox13,
            this.shape1,
            this.textBox4,
            this.textBox10,
            this.shape9,
            this.textBox14,
            this.shape13});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.300100177526474D), Telerik.Reporting.Drawing.Unit.Cm(3D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(28.999898910522461D), Telerik.Reporting.Drawing.Unit.Cm(1.1000006198883057D));
            this.panel1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.panel1.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.panel1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.2000001072883606D), Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2998998165130615D), Telerik.Reporting.Drawing.Unit.Cm(0.70000004768371582D));
            this.textBox5.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.textBox5.Style.Font.Name = "Times New Roman";
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "DATE OP.";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.6998996734619141D), Telerik.Reporting.Drawing.Unit.Cm(0.099999949336051941D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2999999523162842D), Telerik.Reporting.Drawing.Unit.Cm(0.85311728715896606D));
            this.textBox7.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.textBox7.Style.Font.Name = "Times New Roman";
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "MODE REGLEMENT";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.1999001502990723D), Telerik.Reporting.Drawing.Unit.Cm(0.099999949336051941D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.3999998569488525D), Telerik.Reporting.Drawing.Unit.Cm(0.85311728715896606D));
            this.textBox8.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.textBox8.Style.Font.Name = "Times New Roman";
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "REFERENCE";
            // 
            // shape5
            // 
            this.shape5.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(26.399900436401367D), Telerik.Reporting.Drawing.Unit.Cm(0.10603398084640503D));
            this.shape5.Name = "shape5";
            this.shape5.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(0.98189646005630493D));
            this.shape5.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape5.Style.Color = System.Drawing.Color.Blue;
            this.shape5.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // shape3
            // 
            this.shape3.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.9999003410339355D), Telerik.Reporting.Drawing.Unit.Cm(0.099999144673347473D));
            this.shape3.Name = "shape3";
            this.shape3.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(0.97586160898208618D));
            this.shape3.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape3.Style.Color = System.Drawing.Color.Blue;
            this.shape3.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // shape6
            // 
            this.shape6.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.4999003410339355D), Telerik.Reporting.Drawing.Unit.Cm(0.099999144673347473D));
            this.shape6.Name = "shape6";
            this.shape6.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(0.98189646005630493D));
            this.shape6.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape6.Style.Color = System.Drawing.Color.Blue;
            this.shape6.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(26.59990119934082D), Telerik.Reporting.Drawing.Unit.Cm(0.10603438317775726D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2999985218048096D), Telerik.Reporting.Drawing.Unit.Cm(0.89396589994430542D));
            this.textBox13.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.textBox13.Style.Font.Name = "Times New Roman";
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "MONTANT";
            // 
            // shape1
            // 
            this.shape1.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.5998992919921875D), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(1.0470839738845825D));
            this.shape1.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape1.Style.Color = System.Drawing.Color.Blue;
            this.shape1.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.7998991012573242D), Telerik.Reporting.Drawing.Unit.Cm(0.14688298106193543D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.0000009536743164D), Telerik.Reporting.Drawing.Unit.Cm(0.85311728715896606D));
            this.textBox4.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.textBox4.Style.Font.Name = "Times New Roman";
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "FOURNISSEUR";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(20.799900054931641D), Telerik.Reporting.Drawing.Unit.Cm(0.10000035166740418D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.6000003814697266D), Telerik.Reporting.Drawing.Unit.Cm(0.85311728715896606D));
            this.textBox10.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.textBox10.Style.Font.Name = "Times New Roman";
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "AUTRE SORTIE";
            // 
            // shape9
            // 
            this.shape9.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.799900054931641D), Telerik.Reporting.Drawing.Unit.Cm(0.034811343997716904D));
            this.shape9.Name = "shape9";
            this.shape9.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(1.0470839738845825D));
            this.shape9.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape9.Style.Color = System.Drawing.Color.Blue;
            this.shape9.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.999900817871094D), Telerik.Reporting.Drawing.Unit.Cm(0.10000035166740418D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.6000003814697266D), Telerik.Reporting.Drawing.Unit.Cm(0.85311728715896606D));
            this.textBox14.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.textBox14.Style.Font.Name = "Times New Roman";
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Value = "RISTOURNES";
            // 
            // shape13
            // 
            this.shape13.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(20.599899291992188D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.shape13.Name = "shape13";
            this.shape13.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D), Telerik.Reporting.Drawing.Unit.Cm(1.0470839738845825D));
            this.shape13.Style.BorderColor.Default = System.Drawing.Color.Blue;
            this.shape13.Style.Color = System.Drawing.Color.Blue;
            this.shape13.Style.LineColor = System.Drawing.Color.Blue;
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(22.19999885559082D), Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8999991416931152D), Telerik.Reporting.Drawing.Unit.Cm(0.59999990463256836D));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Name = "Times New Roman";
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "Cotonou, le";
            // 
            // textBox3
            // 
            this.textBox3.Format = "{0:D}";
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(25.100198745727539D), Telerik.Reporting.Drawing.Unit.Cm(0.20000030100345612D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.9996006488800049D), Telerik.Reporting.Drawing.Unit.Cm(0.59999990463256836D));
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Name = "Times New Roman";
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "=ExecutionTime";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.50010025501251221D), Telerik.Reporting.Drawing.Unit.Cm(2.1000001430511475D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8998996019363403D), Telerik.Reporting.Drawing.Unit.Cm(0.59999990463256836D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "Times New Roman";
            this.textBox1.Style.Font.Underline = true;
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "PERIODE:";
            // 
            // txt_DateDebut
            // 
            this.txt_DateDebut.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(2.1000001430511475D));
            this.txt_DateDebut.Name = "txt_DateDebut";
            this.txt_DateDebut.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8999991416931152D), Telerik.Reporting.Drawing.Unit.Cm(0.59999990463256836D));
            this.txt_DateDebut.Style.Font.Bold = true;
            this.txt_DateDebut.Style.Font.Name = "Times New Roman";
            this.txt_DateDebut.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txt_DateDebut.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txt_DateDebut.Value = "";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.4001998901367188D), Telerik.Reporting.Drawing.Unit.Cm(2.1000001430511475D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.89980036020278931D), Telerik.Reporting.Drawing.Unit.Cm(0.59999990463256836D));
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Font.Name = "Times New Roman";
            this.textBox9.Style.Font.Underline = false;
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "DU";
            // 
            // txt_DateFin
            // 
            this.txt_DateFin.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.1000003814697266D), Telerik.Reporting.Drawing.Unit.Cm(2.1000001430511475D));
            this.txt_DateFin.Name = "txt_DateFin";
            this.txt_DateFin.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8999991416931152D), Telerik.Reporting.Drawing.Unit.Cm(0.59999990463256836D));
            this.txt_DateFin.Style.Font.Bold = true;
            this.txt_DateFin.Style.Font.Name = "Times New Roman";
            this.txt_DateFin.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txt_DateFin.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txt_DateFin.Value = "";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.7999997138977051D), Telerik.Reporting.Drawing.Unit.Cm(2.1000001430511475D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.89980036020278931D), Telerik.Reporting.Drawing.Unit.Cm(0.59999990463256836D));
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Font.Name = "Times New Roman";
            this.textBox12.Style.Font.Underline = false;
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.Value = "DU";
            // 
            // txt_Titre
            // 
            this.txt_Titre.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269D), Telerik.Reporting.Drawing.Unit.Cm(1.100000262260437D));
            this.txt_Titre.Name = "txt_Titre";
            this.txt_Titre.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(28.5D), Telerik.Reporting.Drawing.Unit.Cm(0.59999990463256836D));
            this.txt_Titre.Style.Font.Bold = true;
            this.txt_Titre.Style.Font.Name = "Times New Roman";
            this.txt_Titre.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txt_Titre.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txt_Titre.Value = "";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(3.2999997138977051D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pb_imageEntete});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.PrintOnLastPage = false;
            this.pageHeaderSection1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // pb_imageEntete
            // 
            this.pb_imageEntete.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.099999949336051941D), Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D));
            this.pb_imageEntete.Name = "pb_imageEntete";
            this.pb_imageEntete.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(29.400001525878906D), Telerik.Reporting.Drawing.Unit.Cm(2.9000000953674316D));
            this.pb_imageEntete.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            // 
            // TR_StatistiqueCaisseDepense
            // 
            this.DataSource = this.objectDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail,
            this.pageHeaderSection1});
            this.Name = "TR_JournalEcritures";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            styleRule2.Style.Font.Name = "Calibri";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            styleRule3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            styleRule3.Style.Font.Name = "Calibri";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            styleRule4.Style.Font.Name = "Calibri";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule5.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            styleRule5.Style.Font.Name = "Calibri";
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(29.571460723876953D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.Shape shape7;
        private Telerik.Reporting.Shape shape10;
        private Telerik.Reporting.Shape shape12;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox23;
        public Telerik.Reporting.TextBox txt_NomApplication;
        public Telerik.Reporting.ObjectDataSource objectDataSource1;
        public Telerik.Reporting.TextBox txt_Titre;
        private Telerik.Reporting.Panel panel5;
        private Telerik.Reporting.Shape shape15;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.Shape shape5;
        private Telerik.Reporting.Shape shape3;
        private Telerik.Reporting.Shape shape6;
        private Telerik.Reporting.Panel panel6;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        public Telerik.Reporting.PictureBox pb_imageEntete;
        private Telerik.Reporting.Shape shape19;
        public Telerik.Reporting.TextBox txt_Devise;
        public Telerik.Reporting.TextBox txt_Ligne1;
        public Telerik.Reporting.TextBox txt_Ligne2;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox1;
        public Telerik.Reporting.TextBox txt_DateDebut;
        private Telerik.Reporting.TextBox textBox9;
        public Telerik.Reporting.TextBox txt_DateFin;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.Shape shape2;
        private Telerik.Reporting.Shape shape1;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.Shape shape11;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.Shape shape14;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.Shape shape9;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.Shape shape13;

    }
}