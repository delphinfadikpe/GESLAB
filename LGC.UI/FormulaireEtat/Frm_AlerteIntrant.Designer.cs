namespace LGC.UI.FormulaireEtat
{
    partial class Frm_AlerteIntrant
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn3 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox7 = new Telerik.WinControls.UI.RadGroupBox();
            this.gv_Liste = new Telerik.WinControls.UI.RadGridView();
            this.chk_estTout = new Telerik.WinControls.UI.RadCheckBox();
            this.bds_Intrants = new System.Windows.Forms.BindingSource(this.components);
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.btn_Actualiser = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox7)).BeginInit();
            this.radGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste.MasterTemplate)).BeginInit();
            this.gv_Liste.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_estTout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_Intrants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
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
            this.gv_Liste.Controls.Add(this.chk_estTout);
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
            this.gv_Liste.MasterTemplate.AllowRowResize = false;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "chk";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "chk";
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "CodeCategorie";
            gridViewTextBoxColumn1.HeaderText = "CODE CATEGODIE";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "CodeCategorie";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 170;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "CodeIntrant";
            gridViewTextBoxColumn2.HeaderText = "CODE INTRANT";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "CodeIntrant";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 165;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "LibelleIntrant";
            gridViewTextBoxColumn3.HeaderText = "LIBELLE INTRANT";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "LibelleIntrant";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 148;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "StockDisponible";
            gridViewDecimalColumn1.HeaderText = "STOCK DISPONIBLE";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsPinned = true;
            gridViewDecimalColumn1.Name = "StockDisponible";
            gridViewDecimalColumn1.PinPosition = Telerik.WinControls.UI.PinnedColumnPosition.Right;
            gridViewDecimalColumn1.ReadOnly = true;
            gridViewDecimalColumn1.Width = 175;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Code";
            gridViewTextBoxColumn4.HeaderText = "UNITE";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.IsPinned = true;
            gridViewTextBoxColumn4.Name = "Code";
            gridViewTextBoxColumn4.PinPosition = Telerik.WinControls.UI.PinnedColumnPosition.Right;
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 103;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "StockSecurite";
            gridViewDecimalColumn2.HeaderText = "STOCK DE SECURITE";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "StockSecurite";
            gridViewDecimalColumn2.ReadOnly = true;
            gridViewDecimalColumn2.Width = 181;
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.FieldName = "SeuilCritique";
            gridViewDecimalColumn3.HeaderText = "SEUIL CRITIQUE";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.Name = "SeuilCritique";
            gridViewDecimalColumn3.ReadOnly = true;
            gridViewDecimalColumn3.Width = 167;
            gridViewDecimalColumn4.EnableExpressionEditor = false;
            gridViewDecimalColumn4.FieldName = "NumLigne";
            gridViewDecimalColumn4.HeaderText = "NumLigne";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.IsVisible = false;
            gridViewDecimalColumn4.Name = "NumLigne";
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "DateCreationServeur";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn1.HeaderText = "DateCreationServeur";
            gridViewDateTimeColumn1.IsAutoGenerated = true;
            gridViewDateTimeColumn1.IsVisible = false;
            gridViewDateTimeColumn1.Name = "DateCreationServeur";
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.FieldName = "DateDernModifClient";
            gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn2.HeaderText = "DateDernModifClient";
            gridViewDateTimeColumn2.IsAutoGenerated = true;
            gridViewDateTimeColumn2.IsVisible = false;
            gridViewDateTimeColumn2.Name = "DateDernModifClient";
            gridViewDateTimeColumn3.EnableExpressionEditor = false;
            gridViewDateTimeColumn3.FieldName = "DateDernModifServeur";
            gridViewDateTimeColumn3.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn3.HeaderText = "DateDernModifServeur";
            gridViewDateTimeColumn3.IsAutoGenerated = true;
            gridViewDateTimeColumn3.IsVisible = false;
            gridViewDateTimeColumn3.Name = "DateDernModifServeur";
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "UserLogin";
            gridViewTextBoxColumn5.HeaderText = "UserLogin";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "UserLogin";
            gridViewCheckBoxColumn2.EnableExpressionEditor = false;
            gridViewCheckBoxColumn2.FieldName = "Supprimer";
            gridViewCheckBoxColumn2.HeaderText = "Supprimer";
            gridViewCheckBoxColumn2.IsAutoGenerated = true;
            gridViewCheckBoxColumn2.IsVisible = false;
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "Supprimer";
            gridViewImageColumn1.DataType = typeof(byte[]);
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.FieldName = "Rowvers";
            gridViewImageColumn1.HeaderText = "Rowvers";
            gridViewImageColumn1.IsAutoGenerated = true;
            gridViewImageColumn1.IsVisible = false;
            gridViewImageColumn1.Name = "Rowvers";
            this.gv_Liste.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn4,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewDateTimeColumn1,
            gridViewDateTimeColumn2,
            gridViewDateTimeColumn3,
            gridViewTextBoxColumn5,
            gridViewCheckBoxColumn2,
            gridViewImageColumn1});
            this.gv_Liste.MasterTemplate.DataSource = this.bds_Intrants;
            this.gv_Liste.MasterTemplate.EnableAlternatingRowColor = true;
            this.gv_Liste.MasterTemplate.EnableFiltering = true;
            this.gv_Liste.MasterTemplate.ShowGroupedColumns = true;
            this.gv_Liste.MasterTemplate.ShowHeaderCellButtons = true;
            this.gv_Liste.MasterTemplate.ShowRowHeaderColumn = false;
            this.gv_Liste.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gv_Liste.Name = "gv_Liste";
            this.gv_Liste.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gv_Liste.ShowGroupPanel = false;
            this.gv_Liste.ShowHeaderCellButtons = true;
            this.gv_Liste.Size = new System.Drawing.Size(919, 432);
            this.gv_Liste.TabIndex = 1;
            this.gv_Liste.Text = "radGridView1";
            this.gv_Liste.ThemeName = "Office2010Blue";
            // 
            // chk_estTout
            // 
            this.chk_estTout.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_estTout.ForeColor = System.Drawing.Color.Red;
            this.chk_estTout.Location = new System.Drawing.Point(18, 9);
            this.chk_estTout.Name = "chk_estTout";
            this.chk_estTout.Size = new System.Drawing.Size(15, 15);
            this.chk_estTout.TabIndex = 467;
            this.chk_estTout.ThemeName = "Office2010Blue";
            this.chk_estTout.ToggleStateChanging += new Telerik.WinControls.UI.StateChangingEventHandler(this.chk_estTout_ToggleStateChanging);
            this.chk_estTout.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chk_estTout_ToggleStateChanged);
            // 
            // bds_Intrants
            // 
            this.bds_Intrants.DataSource = typeof(LGC.Business.Parametre.Intrants);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radButton1);
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
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.radButton1.Image = global::LGC.UI.Properties.Resources.cross1;
            this.radButton1.Location = new System.Drawing.Point(581, 13);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(183, 31);
            this.radButton1.TabIndex = 468;
            this.radButton1.Text = "Bloquer Alerte";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton1.ThemeName = "Office2010Blue";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // btn_Actualiser
            // 
            this.btn_Actualiser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Actualiser.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Actualiser.Image = global::LGC.UI.Properties.Resources.actualiser;
            this.btn_Actualiser.Location = new System.Drawing.Point(770, 13);
            this.btn_Actualiser.Name = "btn_Actualiser";
            this.btn_Actualiser.Size = new System.Drawing.Size(141, 31);
            this.btn_Actualiser.TabIndex = 12;
            this.btn_Actualiser.Text = "&Actualiser";
            this.btn_Actualiser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Actualiser.ThemeName = "Office2010Blue";
            this.btn_Actualiser.Click += new System.EventHandler(this.btn_Actualiser_Click);
            // 
            // Frm_AlerteIntrant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 504);
            this.Controls.Add(this.radGroupBox7);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "Frm_AlerteIntrant";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STOCK INTRANT";
            this.Load += new System.EventHandler(this.Frm_StockIntrant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox7)).EndInit();
            this.radGroupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Liste)).EndInit();
            this.gv_Liste.ResumeLayout(false);
            this.gv_Liste.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_estTout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_Intrants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
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
        private Telerik.WinControls.UI.RadCheckBox chk_estTout;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}
