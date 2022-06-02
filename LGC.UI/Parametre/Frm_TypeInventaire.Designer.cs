namespace LGG.UI.Parametre
{
    partial class Frm_TypeInventaire
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TypeInventaire));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn3 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gv_Liste = new Telerik.WinControls.UI.RadGridView();
            this.bds_typeInventaire = new System.Windows.Forms.BindingSource(this.components);
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.btn_Actualiser = new Telerik.WinControls.UI.RadButton();
            this.gb_Liste = new Telerik.WinControls.UI.RadGroupBox();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.gb_Detail = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txt_libelle = new Telerik.WinControls.UI.RadTextBox();
            this.txt_code = new Telerik.WinControls.UI.RadTextBox();
            this.lbl_Libelle = new Telerik.WinControls.UI.RadLabel();
            this.lbl_Code = new Telerik.WinControls.UI.RadLabel();
            this.btn_Supprimer = new Telerik.WinControls.UI.RadButton();
            this.btn_Modifier = new Telerik.WinControls.UI.RadButton();
            this.btn_Nouveau = new Telerik.WinControls.UI.RadButton();
            this.btn_Enregistrer = new Telerik.WinControls.UI.RadButton();
            this.btn_Annuler = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_typeInventaire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Actualiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_Liste)).BeginInit();
            this.gb_Liste.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gb_Detail)).BeginInit();
            this.gb_Detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_libelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Libelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Supprimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Modifier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Nouveau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Annuler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_Liste
            // 
            this.gv_Liste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gv_Liste.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.gv_Liste, "gv_Liste");
            this.gv_Liste.ForeColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.gv_Liste.MasterTemplate.AllowAddNewRow = false;
            this.gv_Liste.MasterTemplate.AllowColumnChooser = false;
            this.gv_Liste.MasterTemplate.AllowDeleteRow = false;
            this.gv_Liste.MasterTemplate.AllowDragToGroup = false;
            this.gv_Liste.MasterTemplate.AllowEditRow = false;
            this.gv_Liste.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "CodeTypeInventaire";
            resources.ApplyResources(gridViewTextBoxColumn1, "gridViewTextBoxColumn1");
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "CodeTypeInventaire";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 76;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "LibelleTypeInventaire";
            resources.ApplyResources(gridViewTextBoxColumn2, "gridViewTextBoxColumn2");
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "LibelleTypeInventaire";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 314;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "DateCreationServeur";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn1.IsAutoGenerated = true;
            gridViewDateTimeColumn1.IsVisible = false;
            gridViewDateTimeColumn1.Name = "DateCreationServeur";
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.FieldName = "DateDernModifClient";
            gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn2.IsAutoGenerated = true;
            gridViewDateTimeColumn2.IsVisible = false;
            gridViewDateTimeColumn2.Name = "DateDernModifClient";
            gridViewDateTimeColumn3.EnableExpressionEditor = false;
            gridViewDateTimeColumn3.FieldName = "DateDernModifServeur";
            gridViewDateTimeColumn3.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn3.IsAutoGenerated = true;
            gridViewDateTimeColumn3.IsVisible = false;
            gridViewDateTimeColumn3.Name = "DateDernModifServeur";
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "NumLigne";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "NumLigne";
            gridViewImageColumn1.DataType = typeof(byte[]);
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.FieldName = "Rowvers";
            gridViewImageColumn1.IsAutoGenerated = true;
            gridViewImageColumn1.IsVisible = false;
            gridViewImageColumn1.Name = "Rowvers";
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "Supprimer";
            gridViewCheckBoxColumn1.IsAutoGenerated = true;
            gridViewCheckBoxColumn1.IsVisible = false;
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "Supprimer";
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "UserLogin";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "UserLogin";
            this.gv_Liste.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDateTimeColumn1,
            gridViewDateTimeColumn2,
            gridViewDateTimeColumn3,
            gridViewDecimalColumn1,
            gridViewImageColumn1,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn3});
            this.gv_Liste.MasterTemplate.DataSource = this.bds_typeInventaire;
            this.gv_Liste.MasterTemplate.EnableFiltering = true;
            this.gv_Liste.MasterTemplate.EnableGrouping = false;
            this.gv_Liste.MasterTemplate.ShowRowHeaderColumn = false;
            this.gv_Liste.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gv_Liste.Name = "gv_Liste";
            // 
            // 
            // 
            this.gv_Liste.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("gv_Liste.RootElement.Alignment")));
            this.gv_Liste.RootElement.AngleTransform = ((float)(resources.GetObject("gv_Liste.RootElement.AngleTransform")));
            this.gv_Liste.RootElement.FlipText = ((bool)(resources.GetObject("gv_Liste.RootElement.FlipText")));
            this.gv_Liste.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("gv_Liste.RootElement.Margin")));
            this.gv_Liste.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("gv_Liste.RootElement.TextOrientation")));
            this.gv_Liste.TabStop = false;
            this.gv_Liste.ThemeName = "Office2010Blue";
            this.gv_Liste.SelectionChanged += new System.EventHandler(this.gv_Liste_SelectionChanged);
            // 
            // bds_typeInventaire
            // 
            this.bds_typeInventaire.DataSource = typeof(LGC.Business.Parametre.TypeInventaire);
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            resources.ApplyResources(this.radSplitContainer1, "radSplitContainer1");
            this.radSplitContainer1.Name = "radSplitContainer1";
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("radSplitContainer1.RootElement.Alignment")));
            this.radSplitContainer1.RootElement.AngleTransform = ((float)(resources.GetObject("radSplitContainer1.RootElement.AngleTransform")));
            this.radSplitContainer1.RootElement.FlipText = ((bool)(resources.GetObject("radSplitContainer1.RootElement.FlipText")));
            this.radSplitContainer1.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("radSplitContainer1.RootElement.Margin")));
            this.radSplitContainer1.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("radSplitContainer1.RootElement.TextOrientation")));
            this.radSplitContainer1.TabStop = false;
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.btn_Actualiser);
            this.splitPanel1.Controls.Add(this.gb_Liste);
            resources.ApplyResources(this.splitPanel1, "splitPanel1");
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("splitPanel1.RootElement.Alignment")));
            this.splitPanel1.RootElement.AngleTransform = ((float)(resources.GetObject("splitPanel1.RootElement.AngleTransform")));
            this.splitPanel1.RootElement.FlipText = ((bool)(resources.GetObject("splitPanel1.RootElement.FlipText")));
            this.splitPanel1.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("splitPanel1.RootElement.Margin")));
            this.splitPanel1.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("splitPanel1.RootElement.TextOrientation")));
            this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.020908F, 0F);
            this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(-23, 0);
            this.splitPanel1.TabStop = false;
            // 
            // btn_Actualiser
            // 
            resources.ApplyResources(this.btn_Actualiser, "btn_Actualiser");
            this.btn_Actualiser.Image = global::LGC.UI.Properties.Resources.actualiser;
            this.btn_Actualiser.Name = "btn_Actualiser";
            // 
            // 
            // 
            this.btn_Actualiser.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("btn_Actualiser.RootElement.Alignment")));
            this.btn_Actualiser.RootElement.AngleTransform = ((float)(resources.GetObject("btn_Actualiser.RootElement.AngleTransform")));
            this.btn_Actualiser.RootElement.FlipText = ((bool)(resources.GetObject("btn_Actualiser.RootElement.FlipText")));
            this.btn_Actualiser.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("btn_Actualiser.RootElement.Margin")));
            this.btn_Actualiser.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("btn_Actualiser.RootElement.TextOrientation")));
            this.btn_Actualiser.ThemeName = "Office2010Blue";
            this.btn_Actualiser.Click += new System.EventHandler(this.btn_Actualiser_Click);
            // 
            // gb_Liste
            // 
            this.gb_Liste.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            resources.ApplyResources(this.gb_Liste, "gb_Liste");
            this.gb_Liste.Controls.Add(this.gv_Liste);
            this.gb_Liste.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gb_Liste.Name = "gb_Liste";
            // 
            // 
            // 
            this.gb_Liste.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("gb_Liste.RootElement.Alignment")));
            this.gb_Liste.RootElement.AngleTransform = ((float)(resources.GetObject("gb_Liste.RootElement.AngleTransform")));
            this.gb_Liste.RootElement.FlipText = ((bool)(resources.GetObject("gb_Liste.RootElement.FlipText")));
            this.gb_Liste.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("gb_Liste.RootElement.Margin")));
            this.gb_Liste.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("gb_Liste.RootElement.TextOrientation")));
            this.gb_Liste.TabStop = false;
            this.gb_Liste.ThemeName = "Office2010Blue";
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.gb_Detail);
            this.splitPanel2.Controls.Add(this.btn_Supprimer);
            this.splitPanel2.Controls.Add(this.btn_Modifier);
            this.splitPanel2.Controls.Add(this.btn_Nouveau);
            this.splitPanel2.Controls.Add(this.btn_Enregistrer);
            this.splitPanel2.Controls.Add(this.btn_Annuler);
            resources.ApplyResources(this.splitPanel2, "splitPanel2");
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("splitPanel2.RootElement.Alignment")));
            this.splitPanel2.RootElement.AngleTransform = ((float)(resources.GetObject("splitPanel2.RootElement.AngleTransform")));
            this.splitPanel2.RootElement.FlipText = ((bool)(resources.GetObject("splitPanel2.RootElement.FlipText")));
            this.splitPanel2.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("splitPanel2.RootElement.Margin")));
            this.splitPanel2.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("splitPanel2.RootElement.TextOrientation")));
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.020908F, 0F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(23, 0);
            this.splitPanel2.TabStop = false;
            // 
            // gb_Detail
            // 
            this.gb_Detail.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            resources.ApplyResources(this.gb_Detail, "gb_Detail");
            this.gb_Detail.Controls.Add(this.radLabel1);
            this.gb_Detail.Controls.Add(this.radLabel2);
            this.gb_Detail.Controls.Add(this.txt_libelle);
            this.gb_Detail.Controls.Add(this.txt_code);
            this.gb_Detail.Controls.Add(this.lbl_Libelle);
            this.gb_Detail.Controls.Add(this.lbl_Code);
            this.gb_Detail.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gb_Detail.Name = "gb_Detail";
            // 
            // 
            // 
            this.gb_Detail.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("gb_Detail.RootElement.Alignment")));
            this.gb_Detail.RootElement.AngleTransform = ((float)(resources.GetObject("gb_Detail.RootElement.AngleTransform")));
            this.gb_Detail.RootElement.FlipText = ((bool)(resources.GetObject("gb_Detail.RootElement.FlipText")));
            this.gb_Detail.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("gb_Detail.RootElement.Margin")));
            this.gb_Detail.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("gb_Detail.RootElement.TextOrientation")));
            this.gb_Detail.ThemeName = "Office2010Blue";
            // 
            // radLabel1
            // 
            resources.ApplyResources(this.radLabel1, "radLabel1");
            this.radLabel1.ForeColor = System.Drawing.Color.Red;
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("radLabel1.RootElement.Alignment")));
            this.radLabel1.RootElement.AngleTransform = ((float)(resources.GetObject("radLabel1.RootElement.AngleTransform")));
            this.radLabel1.RootElement.FlipText = ((bool)(resources.GetObject("radLabel1.RootElement.FlipText")));
            this.radLabel1.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("radLabel1.RootElement.Margin")));
            this.radLabel1.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("radLabel1.RootElement.TextOrientation")));
            this.radLabel1.ThemeName = "Office2010Blue";
            // 
            // radLabel2
            // 
            resources.ApplyResources(this.radLabel2, "radLabel2");
            this.radLabel2.ForeColor = System.Drawing.Color.Red;
            this.radLabel2.Name = "radLabel2";
            // 
            // 
            // 
            this.radLabel2.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("radLabel2.RootElement.Alignment")));
            this.radLabel2.RootElement.AngleTransform = ((float)(resources.GetObject("radLabel2.RootElement.AngleTransform")));
            this.radLabel2.RootElement.FlipText = ((bool)(resources.GetObject("radLabel2.RootElement.FlipText")));
            this.radLabel2.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("radLabel2.RootElement.Margin")));
            this.radLabel2.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("radLabel2.RootElement.TextOrientation")));
            this.radLabel2.ThemeName = "Office2010Blue";
            // 
            // txt_libelle
            // 
            resources.ApplyResources(this.txt_libelle, "txt_libelle");
            this.txt_libelle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_libelle.Name = "txt_libelle";
            // 
            // 
            // 
            this.txt_libelle.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("txt_libelle.RootElement.Alignment")));
            this.txt_libelle.RootElement.AngleTransform = ((float)(resources.GetObject("txt_libelle.RootElement.AngleTransform")));
            this.txt_libelle.RootElement.FlipText = ((bool)(resources.GetObject("txt_libelle.RootElement.FlipText")));
            this.txt_libelle.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("txt_libelle.RootElement.Margin")));
            this.txt_libelle.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("txt_libelle.RootElement.TextOrientation")));
            this.txt_libelle.ThemeName = "Office2010Blue";
            // 
            // txt_code
            // 
            this.txt_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txt_code, "txt_code");
            this.txt_code.Name = "txt_code";
            // 
            // 
            // 
            this.txt_code.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("txt_code.RootElement.Alignment")));
            this.txt_code.RootElement.AngleTransform = ((float)(resources.GetObject("txt_code.RootElement.AngleTransform")));
            this.txt_code.RootElement.FlipText = ((bool)(resources.GetObject("txt_code.RootElement.FlipText")));
            this.txt_code.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("txt_code.RootElement.Margin")));
            this.txt_code.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("txt_code.RootElement.TextOrientation")));
            this.txt_code.ThemeName = "Office2010Blue";
            // 
            // lbl_Libelle
            // 
            resources.ApplyResources(this.lbl_Libelle, "lbl_Libelle");
            this.lbl_Libelle.Name = "lbl_Libelle";
            // 
            // 
            // 
            this.lbl_Libelle.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("lbl_Libelle.RootElement.Alignment")));
            this.lbl_Libelle.RootElement.AngleTransform = ((float)(resources.GetObject("lbl_Libelle.RootElement.AngleTransform")));
            this.lbl_Libelle.RootElement.FlipText = ((bool)(resources.GetObject("lbl_Libelle.RootElement.FlipText")));
            this.lbl_Libelle.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("lbl_Libelle.RootElement.Margin")));
            this.lbl_Libelle.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("lbl_Libelle.RootElement.TextOrientation")));
            this.lbl_Libelle.ThemeName = "Office2010Blue";
            // 
            // lbl_Code
            // 
            resources.ApplyResources(this.lbl_Code, "lbl_Code");
            this.lbl_Code.Name = "lbl_Code";
            // 
            // 
            // 
            this.lbl_Code.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("lbl_Code.RootElement.Alignment")));
            this.lbl_Code.RootElement.AngleTransform = ((float)(resources.GetObject("lbl_Code.RootElement.AngleTransform")));
            this.lbl_Code.RootElement.FlipText = ((bool)(resources.GetObject("lbl_Code.RootElement.FlipText")));
            this.lbl_Code.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("lbl_Code.RootElement.Margin")));
            this.lbl_Code.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("lbl_Code.RootElement.TextOrientation")));
            this.lbl_Code.ThemeName = "Office2010Blue";
            // 
            // btn_Supprimer
            // 
            resources.ApplyResources(this.btn_Supprimer, "btn_Supprimer");
            this.btn_Supprimer.Image = global::LGC.UI.Properties.Resources.cross;
            this.btn_Supprimer.Name = "btn_Supprimer";
            // 
            // 
            // 
            this.btn_Supprimer.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("btn_Supprimer.RootElement.Alignment")));
            this.btn_Supprimer.RootElement.AngleTransform = ((float)(resources.GetObject("btn_Supprimer.RootElement.AngleTransform")));
            this.btn_Supprimer.RootElement.FlipText = ((bool)(resources.GetObject("btn_Supprimer.RootElement.FlipText")));
            this.btn_Supprimer.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("btn_Supprimer.RootElement.Margin")));
            this.btn_Supprimer.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("btn_Supprimer.RootElement.TextOrientation")));
            this.btn_Supprimer.ThemeName = "Office2010Blue";
            this.btn_Supprimer.Click += new System.EventHandler(this.btn_Supprimer_Click);
            // 
            // btn_Modifier
            // 
            resources.ApplyResources(this.btn_Modifier, "btn_Modifier");
            this.btn_Modifier.Image = global::LGC.UI.Properties.Resources.icon_write;
            this.btn_Modifier.Name = "btn_Modifier";
            // 
            // 
            // 
            this.btn_Modifier.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("btn_Modifier.RootElement.Alignment")));
            this.btn_Modifier.RootElement.AngleTransform = ((float)(resources.GetObject("btn_Modifier.RootElement.AngleTransform")));
            this.btn_Modifier.RootElement.FlipText = ((bool)(resources.GetObject("btn_Modifier.RootElement.FlipText")));
            this.btn_Modifier.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("btn_Modifier.RootElement.Margin")));
            this.btn_Modifier.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("btn_Modifier.RootElement.TextOrientation")));
            this.btn_Modifier.ThemeName = "Office2010Blue";
            this.btn_Modifier.Click += new System.EventHandler(this.btn_Modifier_Click);
            // 
            // btn_Nouveau
            // 
            resources.ApplyResources(this.btn_Nouveau, "btn_Nouveau");
            this.btn_Nouveau.Image = global::LGC.UI.Properties.Resources.Add;
            this.btn_Nouveau.Name = "btn_Nouveau";
            // 
            // 
            // 
            this.btn_Nouveau.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("btn_Nouveau.RootElement.Alignment")));
            this.btn_Nouveau.RootElement.AngleTransform = ((float)(resources.GetObject("btn_Nouveau.RootElement.AngleTransform")));
            this.btn_Nouveau.RootElement.FlipText = ((bool)(resources.GetObject("btn_Nouveau.RootElement.FlipText")));
            this.btn_Nouveau.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("btn_Nouveau.RootElement.Margin")));
            this.btn_Nouveau.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("btn_Nouveau.RootElement.TextOrientation")));
            this.btn_Nouveau.ThemeName = "Office2010Blue";
            this.btn_Nouveau.Click += new System.EventHandler(this.btn_Nouveau_Click);
            // 
            // btn_Enregistrer
            // 
            resources.ApplyResources(this.btn_Enregistrer, "btn_Enregistrer");
            this.btn_Enregistrer.Image = global::LGC.UI.Properties.Resources.saveHS;
            this.btn_Enregistrer.Name = "btn_Enregistrer";
            // 
            // 
            // 
            this.btn_Enregistrer.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("btn_Enregistrer.RootElement.Alignment")));
            this.btn_Enregistrer.RootElement.AngleTransform = ((float)(resources.GetObject("btn_Enregistrer.RootElement.AngleTransform")));
            this.btn_Enregistrer.RootElement.FlipText = ((bool)(resources.GetObject("btn_Enregistrer.RootElement.FlipText")));
            this.btn_Enregistrer.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("btn_Enregistrer.RootElement.Margin")));
            this.btn_Enregistrer.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("btn_Enregistrer.RootElement.TextOrientation")));
            this.btn_Enregistrer.ThemeName = "Office2010Blue";
            this.btn_Enregistrer.Click += new System.EventHandler(this.btn_Enregistrer_Click);
            // 
            // btn_Annuler
            // 
            resources.ApplyResources(this.btn_Annuler, "btn_Annuler");
            this.btn_Annuler.Image = global::LGC.UI.Properties.Resources.Edit_UndoHS;
            this.btn_Annuler.Name = "btn_Annuler";
            // 
            // 
            // 
            this.btn_Annuler.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("btn_Annuler.RootElement.Alignment")));
            this.btn_Annuler.RootElement.AngleTransform = ((float)(resources.GetObject("btn_Annuler.RootElement.AngleTransform")));
            this.btn_Annuler.RootElement.FlipText = ((bool)(resources.GetObject("btn_Annuler.RootElement.FlipText")));
            this.btn_Annuler.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("btn_Annuler.RootElement.Margin")));
            this.btn_Annuler.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("btn_Annuler.RootElement.TextOrientation")));
            this.btn_Annuler.ThemeName = "Office2010Blue";
            this.btn_Annuler.Click += new System.EventHandler(this.btn_Annuler_Click);
            // 
            // Frm_TypeInventaire
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radSplitContainer1);
            this.Name = "Frm_TypeInventaire";
            // 
            // 
            // 
            this.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("Frm_TypeInventaire.RootElement.Alignment")));
            this.RootElement.AngleTransform = ((float)(resources.GetObject("Frm_TypeInventaire.RootElement.AngleTransform")));
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.FlipText = ((bool)(resources.GetObject("Frm_TypeInventaire.RootElement.FlipText")));
            this.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("Frm_TypeInventaire.RootElement.Margin")));
            this.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("Frm_TypeInventaire.RootElement.TextOrientation")));
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.Frm_TypeInventaire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_typeInventaire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Actualiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_Liste)).EndInit();
            this.gb_Liste.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gb_Detail)).EndInit();
            this.gb_Detail.ResumeLayout(false);
            this.gb_Detail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_libelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Libelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Supprimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Modifier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Nouveau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Annuler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.RadGroupBox gb_Liste;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private Telerik.WinControls.UI.RadGroupBox gb_Detail;
        private Telerik.WinControls.UI.RadLabel lbl_Code;
        private Telerik.WinControls.UI.RadLabel lbl_Libelle;
        private Telerik.WinControls.UI.RadTextBox txt_libelle;
        private Telerik.WinControls.UI.RadTextBox txt_code;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btn_Supprimer;
        private Telerik.WinControls.UI.RadButton btn_Nouveau;
        private Telerik.WinControls.UI.RadButton btn_Annuler;
        private Telerik.WinControls.UI.RadButton btn_Enregistrer;
        private Telerik.WinControls.UI.RadButton btn_Modifier;
        private Telerik.WinControls.UI.RadButton btn_Actualiser;
        private Telerik.WinControls.UI.RadGridView gv_Liste;
        private System.Windows.Forms.BindingSource bds_typeInventaire;
    }
}
