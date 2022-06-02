namespace LGG.UI.Parametre
{
    partial class Frm_ListeCommande
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn7 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn8 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewRelation gridViewRelation1 = new Telerik.WinControls.UI.GridViewRelation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ListeCommande));
            this.gridViewTemplate1 = new Telerik.WinControls.UI.GridViewTemplate();
            this.bds_CommandeIntrant = new System.Windows.Forms.BindingSource(this.components);
            this.gv_Liste = new Telerik.WinControls.UI.RadGridView();
            this.bds_Commande = new System.Windows.Forms.BindingSource(this.components);
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.splitPanel3 = new Telerik.WinControls.UI.SplitPanel();
            this.btn_Inserer = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_CommandeIntrant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_Commande)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel3)).BeginInit();
            this.splitPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Inserer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewTemplate1
            // 
            this.gridViewTemplate1.AllowAddNewRow = false;
            this.gridViewTemplate1.AllowDeleteRow = false;
            this.gridViewTemplate1.AllowEditRow = false;
            this.gridViewTemplate1.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Intrant";
            gridViewTextBoxColumn1.HeaderText = "INTRANT";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "Intrant";
            gridViewTextBoxColumn1.Width = 300;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "NumCommande";
            gridViewDecimalColumn1.HeaderText = "NumCommande";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "NumCommande";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "CodeIntrant";
            gridViewTextBoxColumn2.HeaderText = "CodeIntrant";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "CodeIntrant";
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "QteCommande";
            gridViewDecimalColumn2.FormatString = "{0:n2}";
            gridViewDecimalColumn2.HeaderText = "QTE CMDEE";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "QteCommande";
            gridViewDecimalColumn2.Width = 109;
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.FieldName = "QteLivree";
            gridViewDecimalColumn3.FormatString = "{0:n2}";
            gridViewDecimalColumn3.HeaderText = "QTE LIVREE";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.Name = "QteLivree";
            gridViewDecimalColumn3.Width = 89;
            gridViewDecimalColumn4.EnableExpressionEditor = false;
            gridViewDecimalColumn4.FieldName = "QteRestante";
            gridViewDecimalColumn4.FormatString = "{0:n2}";
            gridViewDecimalColumn4.HeaderText = "QTE RESTANTE";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.Name = "QteRestante";
            gridViewDecimalColumn4.Width = 112;
            gridViewDecimalColumn5.EnableExpressionEditor = false;
            gridViewDecimalColumn5.FieldName = "PrixUnitaire";
            gridViewDecimalColumn5.FormatString = "{0:n0}";
            gridViewDecimalColumn5.HeaderText = "PU";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.Name = "PrixUnitaire";
            gridViewDecimalColumn5.Width = 87;
            gridViewDecimalColumn6.EnableExpressionEditor = false;
            gridViewDecimalColumn6.FieldName = "MontantBut";
            gridViewDecimalColumn6.FormatString = "{0:n0}";
            gridViewDecimalColumn6.HeaderText = "MONTANT";
            gridViewDecimalColumn6.IsAutoGenerated = true;
            gridViewDecimalColumn6.Name = "MontantBut";
            gridViewDecimalColumn6.Width = 87;
            this.gridViewTemplate1.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewDecimalColumn5,
            gridViewDecimalColumn6});
            this.gridViewTemplate1.DataSource = this.bds_CommandeIntrant;
            this.gridViewTemplate1.EnableGrouping = false;
            this.gridViewTemplate1.ViewDefinition = tableViewDefinition1;
            // 
            // bds_CommandeIntrant
            // 
            this.bds_CommandeIntrant.DataSource = typeof(LGC.Business.GestionDeStock.IntrantCommander);
            // 
            // gv_Liste
            // 
            this.gv_Liste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gv_Liste.Cursor = System.Windows.Forms.Cursors.Default;
            this.gv_Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_Liste.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.gv_Liste.ForeColor = System.Drawing.Color.Black;
            this.gv_Liste.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gv_Liste.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gv_Liste.MasterTemplate.AllowAddNewRow = false;
            this.gv_Liste.MasterTemplate.AutoGenerateColumns = false;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "chk";
            gridViewDecimalColumn7.EnableExpressionEditor = false;
            gridViewDecimalColumn7.FieldName = "NumCommande";
            gridViewDecimalColumn7.HeaderText = "COMMANDE N°";
            gridViewDecimalColumn7.IsAutoGenerated = true;
            gridViewDecimalColumn7.Name = "NumCommande";
            gridViewDecimalColumn7.ReadOnly = true;
            gridViewDecimalColumn7.Width = 188;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "DateCommande";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            gridViewDateTimeColumn1.FormatString = "{0:d}";
            gridViewDateTimeColumn1.HeaderText = "DATE";
            gridViewDateTimeColumn1.IsAutoGenerated = true;
            gridViewDateTimeColumn1.Name = "DateCommande";
            gridViewDateTimeColumn1.ReadOnly = true;
            gridViewDateTimeColumn1.Width = 131;
            gridViewDecimalColumn8.EnableExpressionEditor = false;
            gridViewDecimalColumn8.FieldName = "MontantGlobale";
            gridViewDecimalColumn8.FormatString = "{0:n0}";
            gridViewDecimalColumn8.HeaderText = "MONTANT";
            gridViewDecimalColumn8.IsAutoGenerated = true;
            gridViewDecimalColumn8.Name = "MontantGlobale";
            gridViewDecimalColumn8.ReadOnly = true;
            gridViewDecimalColumn8.Width = 247;
            this.gv_Liste.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewDecimalColumn7,
            gridViewDateTimeColumn1,
            gridViewDecimalColumn8});
            this.gv_Liste.MasterTemplate.DataSource = this.bds_Commande;
            this.gv_Liste.MasterTemplate.EnableFiltering = true;
            this.gv_Liste.MasterTemplate.EnableGrouping = false;
            this.gv_Liste.MasterTemplate.Templates.AddRange(new Telerik.WinControls.UI.GridViewTemplate[] {
            this.gridViewTemplate1});
            this.gv_Liste.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gv_Liste.Name = "gv_Liste";
            gridViewRelation1.ChildColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ChildColumnNames")));
            gridViewRelation1.ChildTemplate = this.gridViewTemplate1;
            gridViewRelation1.ParentColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ParentColumnNames")));
            gridViewRelation1.ParentTemplate = this.gv_Liste.MasterTemplate;
            this.gv_Liste.Relations.AddRange(new Telerik.WinControls.UI.GridViewRelation[] {
            gridViewRelation1});
            this.gv_Liste.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gv_Liste.Size = new System.Drawing.Size(726, 501);
            this.gv_Liste.TabIndex = 3;
            this.gv_Liste.Text = "radGridView1";
            this.gv_Liste.ThemeName = "Office2010Blue";
            this.gv_Liste.SelectionChanged += new System.EventHandler(this.gv_Liste_SelectionChanged);
            // 
            // bds_Commande
            // 
            this.bds_Commande.DataSource = typeof(LGC.Business.GestionDeStock.CommandeIntrant);
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel3);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            this.radSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radSplitContainer1.Size = new System.Drawing.Size(726, 548);
            this.radSplitContainer1.TabIndex = 4;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.Text = "radSplitContainer1";
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.gv_Liste);
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.splitPanel1.Size = new System.Drawing.Size(726, 501);
            this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.4209559F);
            this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 228);
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            // 
            // splitPanel3
            // 
            this.splitPanel3.Controls.Add(this.btn_Inserer);
            this.splitPanel3.Location = new System.Drawing.Point(0, 505);
            this.splitPanel3.Name = "splitPanel3";
            // 
            // 
            // 
            this.splitPanel3.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.splitPanel3.Size = new System.Drawing.Size(726, 43);
            this.splitPanel3.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.4209559F);
            this.splitPanel3.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -313);
            this.splitPanel3.TabIndex = 2;
            this.splitPanel3.TabStop = false;
            this.splitPanel3.Text = "splitPanel3";
            // 
            // btn_Inserer
            // 
            this.btn_Inserer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Inserer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Inserer.Location = new System.Drawing.Point(616, 7);
            this.btn_Inserer.Name = "btn_Inserer";
            this.btn_Inserer.Size = new System.Drawing.Size(107, 31);
            this.btn_Inserer.TabIndex = 12;
            this.btn_Inserer.Text = "&Insérer";
            this.btn_Inserer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Inserer.ThemeName = "Office2010Blue";
            this.btn_Inserer.Click += new System.EventHandler(this.btn_Inserer_Click);
            // 
            // Frm_ListeCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 548);
            this.Controls.Add(this.radSplitContainer1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.Name = "Frm_ListeCommande";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[LISTE DES COMMANDES]";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.Frm_ListePartenaire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_CommandeIntrant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_Commande)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel3)).EndInit();
            this.splitPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Inserer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bds_Commande;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.RadGridView gv_Liste;
        private System.Windows.Forms.BindingSource bds_CommandeIntrant;
        private Telerik.WinControls.UI.SplitPanel splitPanel3;
        private Telerik.WinControls.UI.RadButton btn_Inserer;
        private Telerik.WinControls.UI.GridViewTemplate gridViewTemplate1;
    }
}
