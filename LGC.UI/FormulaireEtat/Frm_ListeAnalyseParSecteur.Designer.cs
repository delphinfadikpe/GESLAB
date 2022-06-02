namespace LGO.UI.Impressions
{
    partial class Frm_ListeAnalyseParSecteur
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor3 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor4 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor4 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor5 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor6 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem2 = new Telerik.WinControls.UI.GridViewSummaryItem();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btn_Generer = new Telerik.WinControls.UI.RadButton();
            this.btn_Enregistrer = new Telerik.WinControls.UI.RadButton();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txt_DateOuverture = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txt_DateFermeture = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.dgv_Liste = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Generer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DateOuverture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DateFermeture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Liste.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanel1.Controls.Add(this.btn_Generer);
            this.radPanel1.Controls.Add(this.btn_Enregistrer);
            this.radPanel1.Controls.Add(this.radLabel5);
            this.radPanel1.Controls.Add(this.txt_DateOuverture);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.txt_DateFermeture);
            this.radPanel1.Location = new System.Drawing.Point(5, 4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(879, 63);
            this.radPanel1.TabIndex = 0;
            this.radPanel1.ThemeName = "Office2010Blue";
            // 
            // btn_Generer
            // 
            this.btn_Generer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Generer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generer.Image = global::LGC.UI.Properties.Resources.actualiser;
            this.btn_Generer.Location = new System.Drawing.Point(617, 21);
            this.btn_Generer.Name = "btn_Generer";
            this.btn_Generer.Size = new System.Drawing.Size(120, 28);
            this.btn_Generer.TabIndex = 2;
            this.btn_Generer.Text = "&Actualiser";
            this.btn_Generer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Generer.ThemeName = "Office2010Blue";
            this.btn_Generer.Click += new System.EventHandler(this.btn_Generer_Click);
            // 
            // btn_Enregistrer
            // 
            this.btn_Enregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Enregistrer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Enregistrer.Location = new System.Drawing.Point(743, 21);
            this.btn_Enregistrer.Name = "btn_Enregistrer";
            this.btn_Enregistrer.Size = new System.Drawing.Size(126, 28);
            this.btn_Enregistrer.TabIndex = 3;
            this.btn_Enregistrer.Text = "&Aperçu";
            this.btn_Enregistrer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Enregistrer.ThemeName = "Office2010Blue";
            this.btn_Enregistrer.Click += new System.EventHandler(this.btn_Enregistrer_Click);
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.ForeColor = System.Drawing.Color.Black;
            this.radLabel5.Location = new System.Drawing.Point(7, 8);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(94, 19);
            this.radLabel5.TabIndex = 1;
            this.radLabel5.Text = "DATE DEBUT";
            // 
            // txt_DateOuverture
            // 
            this.txt_DateOuverture.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DateOuverture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_DateOuverture.Location = new System.Drawing.Point(7, 28);
            this.txt_DateOuverture.Name = "txt_DateOuverture";
            this.txt_DateOuverture.Size = new System.Drawing.Size(108, 21);
            this.txt_DateOuverture.TabIndex = 8;
            this.txt_DateOuverture.TabStop = false;
            this.txt_DateOuverture.Text = "01/09/2014";
            this.txt_DateOuverture.ThemeName = "Office2010Blue";
            this.txt_DateOuverture.Value = new System.DateTime(2014, 9, 1, 15, 19, 38, 0);
            this.txt_DateOuverture.ValueChanged += new System.EventHandler(this.txt_DateOuverture_ValueChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.ForeColor = System.Drawing.Color.Black;
            this.radLabel3.Location = new System.Drawing.Point(121, 8);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(71, 19);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "DATE FIN";
            // 
            // txt_DateFermeture
            // 
            this.txt_DateFermeture.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DateFermeture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_DateFermeture.Location = new System.Drawing.Point(121, 28);
            this.txt_DateFermeture.Name = "txt_DateFermeture";
            this.txt_DateFermeture.Size = new System.Drawing.Size(112, 21);
            this.txt_DateFermeture.TabIndex = 9;
            this.txt_DateFermeture.TabStop = false;
            this.txt_DateFermeture.Text = "01/09/2014";
            this.txt_DateFermeture.ThemeName = "Office2010Blue";
            this.txt_DateFermeture.Value = new System.DateTime(2014, 9, 1, 15, 19, 38, 0);
            this.txt_DateFermeture.ValueChanged += new System.EventHandler(this.txt_DateOuverture_ValueChanged);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.dgv_Liste);
            this.radGroupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "POINT DES ANALYSES PAR SECTEUR";
            this.radGroupBox1.Location = new System.Drawing.Point(6, 82);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(877, 388);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "POINT DES ANALYSES PAR SECTEUR";
            this.radGroupBox1.ThemeName = "Office2010Blue";
            // 
            // dgv_Liste
            // 
            this.dgv_Liste.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Liste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(141)))), ((int)(((byte)(227)))));
            this.dgv_Liste.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv_Liste.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.dgv_Liste.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgv_Liste.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_Liste.Location = new System.Drawing.Point(6, 29);
            // 
            // 
            // 
            this.dgv_Liste.MasterTemplate.AllowAddNewRow = false;
            this.dgv_Liste.MasterTemplate.AllowColumnChooser = false;
            this.dgv_Liste.MasterTemplate.AllowDeleteRow = false;
            this.dgv_Liste.MasterTemplate.AllowDragToGroup = false;
            this.dgv_Liste.MasterTemplate.AllowEditRow = false;
            this.dgv_Liste.MasterTemplate.AllowRowResize = false;
            this.dgv_Liste.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "libelleSecteur";
            gridViewTextBoxColumn3.HeaderText = "SECTEUR";
            gridViewTextBoxColumn3.Name = "libelleSecteur";
            gridViewTextBoxColumn3.Width = 500;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "codeAnalyse";
            gridViewTextBoxColumn4.HeaderText = "ANALYSE";
            gridViewTextBoxColumn4.Name = "codeAnalyse";
            gridViewTextBoxColumn4.Width = 500;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "montant";
            gridViewDecimalColumn2.FormatString = "{0:n0}";
            gridViewDecimalColumn2.HeaderText = "MONTANT";
            gridViewDecimalColumn2.Name = "montant";
            gridViewDecimalColumn2.Width = 150;
            this.dgv_Liste.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDecimalColumn2});
            this.dgv_Liste.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgv_Liste.MasterTemplate.EnableFiltering = true;
            sortDescriptor4.PropertyName = "partenaire";
            groupDescriptor3.GroupNames.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor4});
            sortDescriptor5.PropertyName = "libelleSecteur";
            groupDescriptor4.GroupNames.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor5});
            this.dgv_Liste.MasterTemplate.GroupDescriptors.AddRange(new Telerik.WinControls.Data.GroupDescriptor[] {
            groupDescriptor3,
            groupDescriptor4});
            this.dgv_Liste.MasterTemplate.ShowRowHeaderColumn = false;
            sortDescriptor6.PropertyName = "partenaire";
            this.dgv_Liste.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor6});
            gridViewSummaryItem2.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
            gridViewSummaryItem2.FormatString = "{0:n0}";
            gridViewSummaryItem2.Name = "montant";
            this.dgv_Liste.MasterTemplate.SummaryRowsBottom.Add(new Telerik.WinControls.UI.GridViewSummaryRowItem(new Telerik.WinControls.UI.GridViewSummaryItem[] {
                gridViewSummaryItem2}));
            this.dgv_Liste.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.dgv_Liste.Name = "dgv_Liste";
            this.dgv_Liste.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_Liste.ShowGroupPanel = false;
            this.dgv_Liste.Size = new System.Drawing.Size(865, 352);
            this.dgv_Liste.TabIndex = 0;
            this.dgv_Liste.Text = "radGridView1";
            this.dgv_Liste.ThemeName = "Office2010Blue";
            // 
            // Frm_ListeAnalyseParSecteur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 513);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radPanel1);
            this.Name = "Frm_ListeAnalyseParSecteur";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POINT DES ANALYSES PAR SECTEUR";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.Frm_GenerationSouscription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Generer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DateOuverture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DateFermeture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Liste.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Liste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadDateTimePicker txt_DateOuverture;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDateTimePicker txt_DateFermeture;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView dgv_Liste;
        private Telerik.WinControls.UI.RadGridView MasterTemplate;
        private Telerik.WinControls.UI.RadButton btn_Generer;
        private Telerik.WinControls.UI.RadButton btn_Enregistrer;
    }
}
