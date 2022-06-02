namespace LGC.UI.Impressions
{
    partial class TR_PointDesRistournes
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
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.shape7 = new Telerik.Reporting.Shape();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.txt_NomApplication = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.shape8 = new Telerik.Reporting.Shape();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.shape13 = new Telerik.Reporting.Shape();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.shape17 = new Telerik.Reporting.Shape();
            this.shape5 = new Telerik.Reporting.Shape();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.shape15 = new Telerik.Reporting.Shape();
            this.shape28 = new Telerik.Reporting.Shape();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.panel3 = new Telerik.Reporting.Panel();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.txt_Periode = new Telerik.Reporting.TextBox();
            this.panel2 = new Telerik.Reporting.Panel();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.shape6 = new Telerik.Reporting.Shape();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.shape12 = new Telerik.Reporting.Shape();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.shape16 = new Telerik.Reporting.Shape();
            this.shape4 = new Telerik.Reporting.Shape();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.shape14 = new Telerik.Reporting.Shape();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.shape30 = new Telerik.Reporting.Shape();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.pb_imageEntete = new Telerik.Reporting.PictureBox();
            this.reportFooterSection1 = new Telerik.Reporting.ReportFooterSection();
            this.panel4 = new Telerik.Reporting.Panel();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.shape19 = new Telerik.Reporting.Shape();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.shape22 = new Telerik.Reporting.Shape();
            this.textBox29 = new Telerik.Reporting.TextBox();
            this.shape24 = new Telerik.Reporting.Shape();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.shape23 = new Telerik.Reporting.Shape();
            this.shape1 = new Telerik.Reporting.Shape();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.CalculatedFields.AddRange(new Telerik.Reporting.CalculatedField[] {
            new Telerik.Reporting.CalculatedField("TOTHT", typeof(decimal), "=Round(Fields.montantFacture / 1.18)"),
            new Telerik.Reporting.CalculatedField("TVA", typeof(decimal), "=Fields.montantFacture - Fields.TOTHT")});
            this.objectDataSource1.DataSource = typeof(LGC.DataAccess.Impressions.ImpressionsDataSet.FT_EtatRecapPrestationsCentreDataTable);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(1.5000004768371582D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.shape7,
            this.textBox24,
            this.txt_NomApplication,
            this.textBox25});
            this.pageFooter.Name = "pageFooter";
            // 
            // shape7
            // 
            this.shape7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Cm(0.0743744969367981D));
            this.shape7.Name = "shape7";
            this.shape7.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(20.69999885559082D), Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D));
            this.shape7.Style.Color = System.Drawing.Color.Black;
            // 
            // textBox24
            // 
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(17.19999885559082D), Telerik.Reporting.Drawing.Unit.Cm(0.30000025033950806D));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2999999523162842D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox24.Style.Font.Bold = true;
            this.textBox24.Style.Font.Name = "Times New Roman";
            this.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox24.Value = "Page {PageNumber}";
            // 
            // txt_NomApplication
            // 
            this.txt_NomApplication.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.40000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.30000025033950806D));
            this.txt_NomApplication.Name = "txt_NomApplication";
            this.txt_NomApplication.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.7302026748657227D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.txt_NomApplication.Style.Font.Bold = true;
            this.txt_NomApplication.Style.Font.Name = "Times New Roman";
            this.txt_NomApplication.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txt_NomApplication.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txt_NomApplication.Value = "NOM APPLICATION";
            // 
            // textBox25
            // 
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.49999994039535522D), Telerik.Reporting.Drawing.Unit.Cm(0.30000025033950806D));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox25.Style.Font.Bold = true;
            this.textBox25.Style.Font.Name = "Times New Roman";
            this.textBox25.Value = "Imprmé le {ExecutionTime} ";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.65500038862228394D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.detail.Name = "detail";
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox8,
            this.shape8,
            this.textBox10,
            this.shape13,
            this.textBox17,
            this.shape17,
            this.shape5,
            this.textBox20,
            this.textBox18,
            this.shape15,
            this.shape28});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.50479161739349365D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.995206832885742D), Telerik.Reporting.Drawing.Unit.Cm(0.65500038862228394D));
            this.panel1.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            // 
            // textBox8
            // 
            this.textBox8.Format = "{0}";
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.1772916316986084D), Telerik.Reporting.Drawing.Unit.Cm(0.093959055840969086D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.2998003959655762D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox8.Style.Font.Bold = false;
            this.textBox8.Style.Font.Name = "Times New Roman";
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "= Fields.centre";
            // 
            // shape8
            // 
            this.shape8.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.495208740234375D), Telerik.Reporting.Drawing.Unit.Cm(0.014709211885929108D));
            this.shape8.Name = "shape8";
            this.shape8.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.60425049066543579D));
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:N0}";
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.6952085494995117D), Telerik.Reporting.Drawing.Unit.Cm(0.0793749988079071D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7000011205673218D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox10.Style.Font.Bold = false;
            this.textBox10.Style.Font.Name = "Times New Roman";
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "= Fields.valeurPrestations";
            // 
            // shape13
            // 
            this.shape13.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.495207786560059D), Telerik.Reporting.Drawing.Unit.Cm(0.026458332315087318D));
            this.shape13.Name = "shape13";
            this.shape13.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.60425049066543579D));
            // 
            // textBox17
            // 
            this.textBox17.Format = "{0:N0}";
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.695208549499512D), Telerik.Reporting.Drawing.Unit.Cm(0.0793749988079071D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8002007007598877D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox17.Style.Font.Bold = false;
            this.textBox17.Style.Font.Name = "Times New Roman";
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox17.Value = "= Fields.valeurNettePrestation";
            // 
            // shape17
            // 
            this.shape17.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.495208740234375D), Telerik.Reporting.Drawing.Unit.Cm(0.026458332315087318D));
            this.shape17.Name = "shape17";
            this.shape17.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.60425049066543579D));
            // 
            // shape5
            // 
            this.shape5.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.0447999238967896D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.shape5.Name = "shape5";
            this.shape5.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.60425049066543579D));
            // 
            // textBox20
            // 
            this.textBox20.Format = "{0:N0}";
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.077291794121265411D), Telerik.Reporting.Drawing.Unit.Cm(0.093959055840969086D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.96730828285217285D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox20.Style.Font.Bold = false;
            this.textBox20.Style.Font.Name = "Times New Roman";
            this.textBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox20.Value = "= Fields.num";
            // 
            // textBox18
            // 
            this.textBox18.Format = "{0:N0}";
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.695209503173828D), Telerik.Reporting.Drawing.Unit.Cm(0.0793749988079071D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8002007007598877D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox18.Style.Font.Bold = false;
            this.textBox18.Style.Font.Name = "Times New Roman";
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.Value = "= Fields.montantDu";
            // 
            // shape15
            // 
            this.shape15.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.495208740234375D), Telerik.Reporting.Drawing.Unit.Cm(0.026458332315087318D));
            this.shape15.Name = "shape15";
            this.shape15.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.60425049066543579D));
            // 
            // shape28
            // 
            this.shape28.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape28.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(17.262718200683594D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.shape28.Name = "shape28";
            this.shape28.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.63862627744674683D));
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(5.5618000030517578D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel3,
            this.panel2,
            this.pb_imageEntete});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // panel3
            // 
            this.panel3.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.panel3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox13,
            this.textBox1,
            this.txt_Periode});
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.5047914981842041D), Telerik.Reporting.Drawing.Unit.Cm(2.6458332538604736D));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(20.032691955566406D), Telerik.Reporting.Drawing.Unit.Cm(1.7159668207168579D));
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.40000081062316895D), Telerik.Reporting.Drawing.Unit.Cm(0.299999862909317D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.532691955566406D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Name = "Times New Roman";
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "POINT DES RISTOURNES";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.35542502999305725D), Telerik.Reporting.Drawing.Unit.Cm(0.95416653156280518D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.04437518119812D), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "Times New Roman";
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "PERIODE:";
            // 
            // txt_Periode
            // 
            this.txt_Periode.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5000007152557373D), Telerik.Reporting.Drawing.Unit.Cm(0.95416653156280518D));
            this.txt_Periode.Name = "txt_Periode";
            this.txt_Periode.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.432689666748047D), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433D));
            this.txt_Periode.Style.Font.Bold = true;
            this.txt_Periode.Style.Font.Name = "Times New Roman";
            this.txt_Periode.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.txt_Periode.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txt_Periode.Value = "";
            // 
            // panel2
            // 
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.shape6,
            this.textBox9,
            this.textBox11,
            this.shape12,
            this.textBox6,
            this.shape16,
            this.shape4,
            this.textBox19,
            this.textBox16,
            this.shape14,
            this.textBox15,
            this.shape30,
            this.textBox27});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.5047914981842041D), Telerik.Reporting.Drawing.Unit.Cm(4.4449996948242188D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.995206832885742D), Telerik.Reporting.Drawing.Unit.Cm(1.1168003082275391D));
            this.panel2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panel2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.1952084302902222D), Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.2998003959655762D), Telerik.Reporting.Drawing.Unit.Cm(0.92270851135253906D));
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Font.Name = "Times New Roman";
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "CABINET";
            // 
            // shape6
            // 
            this.shape6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.495208740234375D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.shape6.Name = "shape6";
            this.shape6.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(1.0550001859664917D));
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.6952085494995117D), Telerik.Reporting.Drawing.Unit.Cm(0.055000275373458862D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7999999523162842D), Telerik.Reporting.Drawing.Unit.Cm(0.99999988079071045D));
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Font.Name = "Times New Roman";
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "TOTAL";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.695208549499512D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.30000114440918D), Telerik.Reporting.Drawing.Unit.Cm(0.55500000715255737D));
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Font.Name = "Times New Roman";
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.Value = "PAIEMENT ";
            // 
            // shape12
            // 
            this.shape12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.495207786560059D), Telerik.Reporting.Drawing.Unit.Cm(0.055000275373458862D));
            this.shape12.Name = "shape12";
            this.shape12.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.99999988079071045D));
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.695208549499512D), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7999999523162842D), Telerik.Reporting.Drawing.Unit.Cm(1.0020835399627686D));
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Name = "Times New Roman";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "RISTOURNES";
            // 
            // shape16
            // 
            this.shape16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.495208740234375D), Telerik.Reporting.Drawing.Unit.Cm(0.055000275373458862D));
            this.shape16.Name = "shape16";
            this.shape16.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.99999988079071045D));
            // 
            // shape4
            // 
            this.shape4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.0627167224884033D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.shape4.Name = "shape4";
            this.shape4.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(1.0550001859664917D));
            // 
            // textBox19
            // 
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.052099533379077911D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.010417103767395D), Telerik.Reporting.Drawing.Unit.Cm(1.0020835399627686D));
            this.textBox19.Style.Font.Bold = true;
            this.textBox19.Style.Font.Name = "Times New Roman";
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox19.Value = "N°";
            // 
            // textBox16
            // 
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.695209503173828D), Telerik.Reporting.Drawing.Unit.Cm(0.026458332315087318D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7999999523162842D), Telerik.Reporting.Drawing.Unit.Cm(1.07937490940094D));
            this.textBox16.Style.Font.Bold = true;
            this.textBox16.Style.Font.Name = "Times New Roman";
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.Value = "MONTANT";
            // 
            // shape14
            // 
            this.shape14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.495208740234375D), Telerik.Reporting.Drawing.Unit.Cm(0.026458332315087318D));
            this.shape14.Name = "shape14";
            this.shape14.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(1.0285418033599854D));
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.695208549499512D), Telerik.Reporting.Drawing.Unit.Cm(0.55520027875900269D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5673089027404785D), Telerik.Reporting.Drawing.Unit.Cm(0.55500000715255737D));
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Font.Name = "Times New Roman";
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.Value = "DATE";
            // 
            // shape30
            // 
            this.shape30.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape30.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(17.262718200683594D), Telerik.Reporting.Drawing.Unit.Cm(0.55500000715255737D));
            this.shape30.Name = "shape30";
            this.shape30.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.53777402639389038D));
            // 
            // textBox27
            // 
            this.textBox27.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(17.395009994506836D), Telerik.Reporting.Drawing.Unit.Cm(0.55520027875900269D));
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6001996994018555D), Telerik.Reporting.Drawing.Unit.Cm(0.55500000715255737D));
            this.textBox27.Style.Font.Bold = true;
            this.textBox27.Style.Font.Name = "Times New Roman";
            this.textBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox27.Value = "MONTANT PAYE";
            // 
            // pb_imageEntete
            // 
            this.pb_imageEntete.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.5D), Telerik.Reporting.Drawing.Unit.Cm(0.15874999761581421D));
            this.pb_imageEntete.Name = "pb_imageEntete";
            this.pb_imageEntete.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(20D), Telerik.Reporting.Drawing.Unit.Cm(2.2999999523162842D));
            this.pb_imageEntete.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            // 
            // reportFooterSection1
            // 
            this.reportFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.65862500667572021D);
            this.reportFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel4});
            this.reportFooterSection1.Name = "reportFooterSection1";
            // 
            // panel4
            // 
            this.panel4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox23,
            this.shape19,
            this.textBox26,
            this.shape22,
            this.textBox29,
            this.shape24,
            this.textBox30,
            this.shape23,
            this.shape1});
            this.panel4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.49999994039535522D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel4.Name = "panel4";
            this.panel4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.995206832885742D), Telerik.Reporting.Drawing.Unit.Cm(0.65862500667572021D));
            this.panel4.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            // 
            // textBox23
            // 
            this.textBox23.Format = "{0}";
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.082083359360694885D), Telerik.Reporting.Drawing.Unit.Cm(0.093959055840969086D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.39500904083252D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox23.Style.Font.Bold = true;
            this.textBox23.Style.Font.Italic = true;
            this.textBox23.Style.Font.Name = "Times New Roman";
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.Value = "TOTAL";
            // 
            // shape19
            // 
            this.shape19.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.495208740234375D), Telerik.Reporting.Drawing.Unit.Cm(0.014709211885929108D));
            this.shape19.Name = "shape19";
            this.shape19.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.60787510871887207D));
            // 
            // textBox26
            // 
            this.textBox26.Format = "{0:N0}";
            this.textBox26.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.6952085494995117D), Telerik.Reporting.Drawing.Unit.Cm(0.0793749988079071D));
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7000011205673218D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox26.Style.Font.Bold = true;
            this.textBox26.Style.Font.Italic = true;
            this.textBox26.Style.Font.Name = "Times New Roman";
            this.textBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox26.Value = "= Sum(Fields.valeurPrestations) ";
            // 
            // shape22
            // 
            this.shape22.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape22.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.5D), Telerik.Reporting.Drawing.Unit.Cm(0.026458332315087318D));
            this.shape22.Name = "shape22";
            this.shape22.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.60787510871887207D));
            // 
            // textBox29
            // 
            this.textBox29.Format = "{0:N0}";
            this.textBox29.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.695208549499512D), Telerik.Reporting.Drawing.Unit.Cm(0.0793749988079071D));
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8002007007598877D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox29.Style.Font.Bold = true;
            this.textBox29.Style.Font.Italic = true;
            this.textBox29.Style.Font.Name = "Times New Roman";
            this.textBox29.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox29.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox29.Value = "= Sum(Fields.valeurNettePrestation)";
            // 
            // shape24
            // 
            this.shape24.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.495208740234375D), Telerik.Reporting.Drawing.Unit.Cm(0.026458332315087318D));
            this.shape24.Name = "shape24";
            this.shape24.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.60787510871887207D));
            // 
            // textBox30
            // 
            this.textBox30.Format = "{0:N0}";
            this.textBox30.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.700000762939453D), Telerik.Reporting.Drawing.Unit.Cm(0.0793749988079071D));
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8002007007598877D), Telerik.Reporting.Drawing.Unit.Cm(0.42950865626335144D));
            this.textBox30.Style.Font.Bold = true;
            this.textBox30.Style.Font.Italic = true;
            this.textBox30.Style.Font.Name = "Times New Roman";
            this.textBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox30.Value = "= Sum(Fields.montantDu)";
            // 
            // shape23
            // 
            this.shape23.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.500000953674316D), Telerik.Reporting.Drawing.Unit.Cm(0.026458332315087318D));
            this.shape23.Name = "shape23";
            this.shape23.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.60787510871887207D));
            // 
            // shape1
            // 
            this.shape1.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(17.267509460449219D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D), Telerik.Reporting.Drawing.Unit.Cm(0.63862627744674683D));
            // 
            // TR_PointDesRistournes
            // 
            this.DataSource = this.objectDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageFooter,
            this.detail,
            this.reportHeaderSection1,
            this.reportFooterSection1});
            this.Name = "TR_Facture";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.Black;
            styleRule1.Style.Font.Bold = true;
            styleRule1.Style.Font.Italic = false;
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule1.Style.Font.Strikeout = false;
            styleRule1.Style.Font.Underline = false;
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(20.999898910522461D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.DetailSection detail;
        public Telerik.Reporting.ObjectDataSource objectDataSource1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.Shape shape7;
        private Telerik.Reporting.TextBox textBox24;
        public Telerik.Reporting.TextBox txt_NomApplication;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.Panel panel3;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.Panel panel2;
        public Telerik.Reporting.PictureBox pb_imageEntete;
        public Telerik.Reporting.TextBox txt_Periode;
        private Telerik.Reporting.Shape shape5;
        public Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.Shape shape4;
        public Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.Shape shape8;
        public Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.Shape shape6;
        public Telerik.Reporting.TextBox textBox9;
        public Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.Shape shape13;
        public Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.Shape shape17;
        public Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.Shape shape12;
        public Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.Shape shape16;
        public Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.ReportFooterSection reportFooterSection1;
        private Telerik.Reporting.Panel panel4;
        public Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.Shape shape19;
        public Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.Shape shape22;
        public Telerik.Reporting.TextBox textBox29;
        private Telerik.Reporting.Shape shape24;
        public Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.Shape shape15;
        public Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.Shape shape14;
        public Telerik.Reporting.TextBox textBox30;
        private Telerik.Reporting.Shape shape23;
        private Telerik.Reporting.Shape shape28;
        public Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.Shape shape30;
        public Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.Shape shape1;

    }
}