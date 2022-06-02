namespace LGC.UI.FormulaireEtat
{
    partial class Frm_StockIntrant
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn7 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn8 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn4 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn5 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn6 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox7 = new Telerik.WinControls.UI.RadGroupBox();
            this.gv_Liste = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.bds_Intrants = new System.Windows.Forms.BindingSource(this.components);
            this.btn_Actualiser = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox7)).BeginInit();
            this.radGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bds_Intrants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Actualiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox7
            // 
            this.radGroupBox7.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox7.Controls.Add(this.gv_Liste);
            this.radGroupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox7.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox7.HeaderText = "LISTE ";
            this.radGroupBox7.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox7.Name = "radGroupBox7";
            this.radGroupBox7.Size = new System.Drawing.Size(923, 452);
            this.radGroupBox7.TabIndex = 903;
            this.radGroupBox7.TabStop = false;
            this.radGroupBox7.Text = "LISTE ";
            this.radGroupBox7.ThemeName = "Office2010Blue";
            // 
            // gv_Liste
            // 
            this.gv_Liste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gv_Liste.Cursor = System.Windows.Forms.Cursors.Default;
            this.gv_Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_Liste.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.gv_Liste.ForeColor = System.Drawing.Color.Black;
            this.gv_Liste.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gv_Liste.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.gv_Liste.MasterTemplate.AllowAddNewRow = false;
            this.gv_Liste.MasterTemplate.AllowColumnChooser = false;
            this.gv_Liste.MasterTemplate.AllowDeleteRow = false;
            this.gv_Liste.MasterTemplate.AllowDragToGroup = false;
            this.gv_Liste.MasterTemplate.AllowEditRow = false;
            this.gv_Liste.MasterTemplate.AllowRowResize = false;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "CodeCategorie";
            gridViewTextBoxColumn6.HeaderText = "CODE CATEGODIE";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "CodeCategorie";
            gridViewTextBoxColumn6.Width = 170;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "CodeIntrant";
            gridViewTextBoxColumn7.HeaderText = "CODE INTRANT";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "CodeIntrant";
            gridViewTextBoxColumn7.Width = 165;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "LibelleIntrant";
            gridViewTextBoxColumn8.HeaderText = "LIBELLE INTRANT";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.Name = "LibelleIntrant";
            gridViewTextBoxColumn8.Width = 148;
            gridViewDecimalColumn5.EnableExpressionEditor = false;
            gridViewDecimalColumn5.FieldName = "StockDisponible";
            gridViewDecimalColumn5.HeaderText = "STOCK DISPONIBLE";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.IsPinned = true;
            gridViewDecimalColumn5.Name = "StockDisponible";
            gridViewDecimalColumn5.PinPosition = Telerik.WinControls.UI.PinnedColumnPosition.Right;
            gridViewDecimalColumn5.Width = 175;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "Code";
            gridViewTextBoxColumn9.HeaderText = "UNITE";
            gridViewTextBoxColumn9.IsAutoGenerated = true;
            gridViewTextBoxColumn9.IsPinned = true;
            gridViewTextBoxColumn9.Name = "Code";
            gridViewTextBoxColumn9.PinPosition = Telerik.WinControls.UI.PinnedColumnPosition.Right;
            gridViewTextBoxColumn9.Width = 103;
            gridViewDecimalColumn6.EnableExpressionEditor = false;
            gridViewDecimalColumn6.FieldName = "StockSecurite";
            gridViewDecimalColumn6.HeaderText = "STOCK DE SECURITE";
            gridViewDecimalColumn6.IsAutoGenerated = true;
            gridViewDecimalColumn6.Name = "StockSecurite";
            gridViewDecimalColumn6.Width = 181;
            gridViewDecimalColumn7.EnableExpressionEditor = false;
            gridViewDecimalColumn7.FieldName = "SeuilCritique";
            gridViewDecimalColumn7.HeaderText = "SEUIL CRITIQUE";
            gridViewDecimalColumn7.IsAutoGenerated = true;
            gridViewDecimalColumn7.Name = "SeuilCritique";
            gridViewDecimalColumn7.Width = 167;
            gridViewDecimalColumn8.EnableExpressionEditor = false;
            gridViewDecimalColumn8.FieldName = "NumLigne";
            gridViewDecimalColumn8.HeaderText = "NumLigne";
            gridViewDecimalColumn8.IsAutoGenerated = true;
            gridViewDecimalColumn8.IsVisible = false;
            gridViewDecimalColumn8.Name = "NumLigne";
            gridViewDateTimeColumn4.EnableExpressionEditor = false;
            gridViewDateTimeColumn4.FieldName = "DateCreationServeur";
            gridViewDateTimeColumn4.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn4.HeaderText = "DateCreationServeur";
            gridViewDateTimeColumn4.IsAutoGenerated = true;
            gridViewDateTimeColumn4.IsVisible = false;
            gridViewDateTimeColumn4.Name = "DateCreationServeur";
            gridViewDateTimeColumn5.EnableExpressionEditor = false;
            gridViewDateTimeColumn5.FieldName = "DateDernModifClient";
            gridViewDateTimeColumn5.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn5.HeaderText = "DateDernModifClient";
            gridViewDateTimeColumn5.IsAutoGenerated = true;
            gridViewDateTimeColumn5.IsVisible = false;
            gridViewDateTimeColumn5.Name = "DateDernModifClient";
            gridViewDateTimeColumn6.EnableExpressionEditor = false;
            gridViewDateTimeColumn6.FieldName = "DateDernModifServeur";
            gridViewDateTimeColumn6.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn6.HeaderText = "DateDernModifServeur";
            gridViewDateTimeColumn6.IsAutoGenerated = true;
            gridViewDateTimeColumn6.IsVisible = false;
            gridViewDateTimeColumn6.Name = "DateDernModifServeur";
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "UserLogin";
            gridViewTextBoxColumn10.HeaderText = "UserLogin";
            gridViewTextBoxColumn10.IsAutoGenerated = true;
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "UserLogin";
            gridViewCheckBoxColumn2.EnableExpressionEditor = false;
            gridViewCheckBoxColumn2.FieldName = "Supprimer";
            gridViewCheckBoxColumn2.HeaderText = "Supprimer";
            gridViewCheckBoxColumn2.IsAutoGenerated = true;
            gridViewCheckBoxColumn2.IsVisible = false;
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "Supprimer";
            gridViewImageColumn2.DataType = typeof(byte[]);
            gridViewImageColumn2.EnableExpressionEditor = false;
            gridViewImageColumn2.FieldName = "Rowvers";
            gridViewImageColumn2.HeaderText = "Rowvers";
            gridViewImageColumn2.IsAutoGenerated = true;
            gridViewImageColumn2.IsVisible = false;
            gridViewImageColumn2.Name = "Rowvers";
            this.gv_Liste.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewDecimalColumn5,
            gridViewTextBoxColumn9,
            gridViewDecimalColumn6,
            gridViewDecimalColumn7,
            gridViewDecimalColumn8,
            gridViewDateTimeColumn4,
            gridViewDateTimeColumn5,
            gridViewDateTimeColumn6,
            gridViewTextBoxColumn10,
            gridViewCheckBoxColumn2,
            gridViewImageColumn2});
            this.gv_Liste.MasterTemplate.DataSource = this.bds_Intrants;
            this.gv_Liste.MasterTemplate.EnableAlternatingRowColor = true;
            this.gv_Liste.MasterTemplate.EnableFiltering = true;
            this.gv_Liste.MasterTemplate.ShowGroupedColumns = true;
            this.gv_Liste.MasterTemplate.ShowHeaderCellButtons = true;
            this.gv_Liste.MasterTemplate.ShowRowHeaderColumn = false;
            this.gv_Liste.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gv_Liste.Name = "gv_Liste";
            this.gv_Liste.ReadOnly = true;
            this.gv_Liste.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gv_Liste.ShowGroupPanel = false;
            this.gv_Liste.ShowHeaderCellButtons = true;
            this.gv_Liste.Size = new System.Drawing.Size(919, 432);
            this.gv_Liste.TabIndex = 1;
            this.gv_Liste.Text = "radGridView1";
            this.gv_Liste.ThemeName = "Office2010Blue";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btn_Actualiser);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radGroupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 452);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(923, 52);
            this.radGroupBox1.TabIndex = 902;
            this.radGroupBox1.ThemeName = "Office2010Blue";
            // 
            // bds_Intrants
            // 
            this.bds_Intrants.DataSource = typeof(LGC.Business.Parametre.Intrants);
            // 
            // btn_Actualiser
            // 
            this.btn_Actualiser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Actualiser.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Actualiser.Image = global::LGC.UI.Properties.Resources.actualiser;
            this.btn_Actualiser.Location = new System.Drawing.Point(804, 13);
            this.btn_Actualiser.Name = "btn_Actualiser";
            this.btn_Actualiser.Size = new System.Drawing.Size(107, 31);
            this.btn_Actualiser.TabIndex = 12;
            this.btn_Actualiser.Text = "&Actualiser";
            this.btn_Actualiser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Actualiser.ThemeName = "Office2010Blue";
            this.btn_Actualiser.Click += new System.EventHandler(this.btn_Actualiser_Click);
            // 
            // Frm_StockIntrant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 504);
            this.Controls.Add(this.radGroupBox7);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "Frm_StockIntrant";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALERTE D\'INTRANT";
            this.Load += new System.EventHandler(this.Frm_StockIntrant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox7)).EndInit();
            this.radGroupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bds_Intrants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Actualiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox7;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btn_Actualiser;
        private Telerik.WinControls.UI.RadGridView gv_Liste;
        private System.Windows.Forms.BindingSource bds_Intrants;
    }
}
