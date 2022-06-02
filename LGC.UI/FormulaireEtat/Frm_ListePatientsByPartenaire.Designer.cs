namespace LGO.UI.Impressions
{
    partial class Frm_ListePatientsByPartenaire
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor1 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem1 = new Telerik.WinControls.UI.GridViewSummaryItem();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.rchk_Partenaires = new Telerik.WinControls.UI.RadCheckBox();
            this.ddl_Distributeur = new Telerik.WinControls.UI.RadDropDownList();
            this.bds_Distributeur = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.rchk_Partenaires)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl_Distributeur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_Distributeur)).BeginInit();
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
            this.radPanel1.Controls.Add(this.rchk_Partenaires);
            this.radPanel1.Controls.Add(this.ddl_Distributeur);
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
            // rchk_Partenaires
            // 
            this.rchk_Partenaires.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.rchk_Partenaires.Location = new System.Drawing.Point(255, 9);
            this.rchk_Partenaires.Name = "rchk_Partenaires";
            this.rchk_Partenaires.Size = new System.Drawing.Size(116, 19);
            this.rchk_Partenaires.TabIndex = 15;
            this.rchk_Partenaires.Text = "PARTENAIRES";
            this.rchk_Partenaires.Click += new System.EventHandler(this.rchk_Partenaires_Click);
            // 
            // ddl_Distributeur
            // 
            this.ddl_Distributeur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddl_Distributeur.AutoCompleteDisplayMember = "SiglePersonneMorale";
            this.ddl_Distributeur.DataSource = this.bds_Distributeur;
            this.ddl_Distributeur.DisplayMember = "Intitule";
            this.ddl_Distributeur.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddl_Distributeur.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Distributeur.Location = new System.Drawing.Point(255, 28);
            this.ddl_Distributeur.Name = "ddl_Distributeur";
            this.ddl_Distributeur.Size = new System.Drawing.Size(356, 21);
            this.ddl_Distributeur.TabIndex = 14;
            this.ddl_Distributeur.ThemeName = "Office2010Blue";
            this.ddl_Distributeur.ValueMember = "IdPersonne";
            this.ddl_Distributeur.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddl_Distributeur_SelectedIndexChanged);
            this.ddl_Distributeur.TextChanged += new System.EventHandler(this.ddl_Distributeur_TextChanged);
            // 
            // bds_Distributeur
            // 
            this.bds_Distributeur.DataSource = typeof(LGC.Business.Parametre.Partenaires);
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
            this.radGroupBox1.HeaderText = "POINT DES PATIENTS PAR PARTENAIRES";
            this.radGroupBox1.Location = new System.Drawing.Point(6, 82);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(877, 388);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "POINT DES PATIENTS PAR PARTENAIRES";
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
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "patient";
            gridViewTextBoxColumn1.HeaderText = "PATIENT";
            gridViewTextBoxColumn1.Name = "patient";
            gridViewTextBoxColumn1.Width = 500;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "partenaire";
            gridViewTextBoxColumn2.HeaderText = "PARTENAIRE";
            gridViewTextBoxColumn2.Name = "partenaire";
            gridViewTextBoxColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn2.Width = 500;
            this.dgv_Liste.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.dgv_Liste.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgv_Liste.MasterTemplate.EnableFiltering = true;
            sortDescriptor1.PropertyName = "partenaire";
            groupDescriptor1.GroupNames.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.dgv_Liste.MasterTemplate.GroupDescriptors.AddRange(new Telerik.WinControls.Data.GroupDescriptor[] {
            groupDescriptor1});
            this.dgv_Liste.MasterTemplate.ShowRowHeaderColumn = false;
            sortDescriptor2.PropertyName = "partenaire";
            this.dgv_Liste.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor2});
            gridViewSummaryItem1.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Count;
            gridViewSummaryItem1.FormatString = "{0:n0}";
            gridViewSummaryItem1.Name = "patient";
            this.dgv_Liste.MasterTemplate.SummaryRowsBottom.Add(new Telerik.WinControls.UI.GridViewSummaryRowItem(new Telerik.WinControls.UI.GridViewSummaryItem[] {
                gridViewSummaryItem1}));
            this.dgv_Liste.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_Liste.Name = "dgv_Liste";
            this.dgv_Liste.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_Liste.ShowGroupPanel = false;
            this.dgv_Liste.Size = new System.Drawing.Size(865, 352);
            this.dgv_Liste.TabIndex = 0;
            this.dgv_Liste.Text = "radGridView1";
            this.dgv_Liste.ThemeName = "Office2010Blue";
            // 
            // Frm_ListePatientsByPartenaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 513);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radPanel1);
            this.Name = "Frm_ListePatientsByPartenaire";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LISTE PERIODIQUES DES PATIENTS";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.Frm_GenerationSouscription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rchk_Partenaires)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl_Distributeur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_Distributeur)).EndInit();
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
        private System.Windows.Forms.BindingSource bds_Distributeur;
        private Telerik.WinControls.UI.RadDropDownList ddl_Distributeur;
        private Telerik.WinControls.UI.RadCheckBox rchk_Partenaires;
    }
}
