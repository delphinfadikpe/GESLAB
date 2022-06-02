﻿namespace LGC.UI.Parametre
{
    partial class Frm_UniteMesure
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn3 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.dgv_Liste = new Telerik.WinControls.UI.RadGridView();
            this.bds_UniteMesure = new System.Windows.Forms.BindingSource(this.components);
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.txt_Code = new Telerik.WinControls.UI.RadTextBox();
            this.txt_Libelle = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.btn_Supprimer = new Telerik.WinControls.UI.RadButton();
            this.btn_Modifier = new Telerik.WinControls.UI.RadButton();
            this.btn_Enregistrer = new Telerik.WinControls.UI.RadButton();
            this.btn_Nouveau = new Telerik.WinControls.UI.RadButton();
            this.btn_Annuler = new Telerik.WinControls.UI.RadButton();
            this.btn_Actualiser = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Liste.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_UniteMesure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Libelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Supprimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Modifier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Nouveau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Annuler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Actualiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.radGroupBox1.HeaderText = "LISTE";
            this.radGroupBox1.Location = new System.Drawing.Point(7, 2);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(668, 365);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.TabStop = false;
            this.radGroupBox1.Text = "LISTE";
            this.radGroupBox1.ThemeName = "Office2010Blue";
            // 
            // dgv_Liste
            // 
            this.dgv_Liste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dgv_Liste.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv_Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Liste.EnableHotTracking = false;
            this.dgv_Liste.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgv_Liste.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgv_Liste.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_Liste.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.dgv_Liste.MasterTemplate.AllowAddNewRow = false;
            this.dgv_Liste.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "NumLigne";
            gridViewDecimalColumn1.HeaderText = "NumLigne";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "NumLigne";
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "DateCreationServeur";
            gridViewDateTimeColumn1.HeaderText = "DateCreationServeur";
            gridViewDateTimeColumn1.IsAutoGenerated = true;
            gridViewDateTimeColumn1.IsVisible = false;
            gridViewDateTimeColumn1.Name = "DateCreationServeur";
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.FieldName = "DateDernModifClient";
            gridViewDateTimeColumn2.HeaderText = "DateDernModifClient";
            gridViewDateTimeColumn2.IsAutoGenerated = true;
            gridViewDateTimeColumn2.IsVisible = false;
            gridViewDateTimeColumn2.Name = "DateDernModifClient";
            gridViewDateTimeColumn3.EnableExpressionEditor = false;
            gridViewDateTimeColumn3.FieldName = "DateDernModifServeur";
            gridViewDateTimeColumn3.HeaderText = "DateDernModifServeur";
            gridViewDateTimeColumn3.IsAutoGenerated = true;
            gridViewDateTimeColumn3.IsVisible = false;
            gridViewDateTimeColumn3.Name = "DateDernModifServeur";
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "UserLogin";
            gridViewTextBoxColumn1.HeaderText = "UserLogin";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "UserLogin";
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "Supprimer";
            gridViewCheckBoxColumn1.HeaderText = "Supprimer";
            gridViewCheckBoxColumn1.IsAutoGenerated = true;
            gridViewCheckBoxColumn1.IsVisible = false;
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "Supprimer";
            gridViewImageColumn1.DataType = typeof(byte[]);
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.FieldName = "Rowvers";
            gridViewImageColumn1.HeaderText = "Rowvers";
            gridViewImageColumn1.IsAutoGenerated = true;
            gridViewImageColumn1.IsVisible = false;
            gridViewImageColumn1.Name = "Rowvers";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Code";
            gridViewTextBoxColumn2.HeaderText = "Code";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "Code";
            gridViewTextBoxColumn2.Width = 333;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Libelle";
            gridViewTextBoxColumn3.HeaderText = "Libelle";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "Libelle";
            gridViewTextBoxColumn3.Width = 331;
            this.dgv_Liste.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewDateTimeColumn1,
            gridViewDateTimeColumn2,
            gridViewDateTimeColumn3,
            gridViewTextBoxColumn1,
            gridViewCheckBoxColumn1,
            gridViewImageColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.dgv_Liste.MasterTemplate.DataSource = this.bds_UniteMesure;
            this.dgv_Liste.MasterTemplate.EnableFiltering = true;
            this.dgv_Liste.MasterTemplate.EnableGrouping = false;
            this.dgv_Liste.MasterTemplate.EnableSorting = false;
            this.dgv_Liste.MasterTemplate.ShowRowHeaderColumn = false;
            this.dgv_Liste.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_Liste.Name = "dgv_Liste";
            this.dgv_Liste.ReadOnly = true;
            this.dgv_Liste.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_Liste.ShowGroupPanel = false;
            this.dgv_Liste.Size = new System.Drawing.Size(664, 345);
            this.dgv_Liste.TabIndex = 0;
            this.dgv_Liste.SelectionChanged += new System.EventHandler(this.dgv_Liste_SelectionChanged);
            // 
            // bds_UniteMesure
            // 
            this.bds_UniteMesure.DataSource = typeof(LGC.Business.Parametre.UniteMesure);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.txt_Code);
            this.radGroupBox2.Controls.Add(this.txt_Libelle);
            this.radGroupBox2.Controls.Add(this.radLabel1);
            this.radGroupBox2.Controls.Add(this.radLabel2);
            this.radGroupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox2.HeaderText = "DETAIL";
            this.radGroupBox2.Location = new System.Drawing.Point(7, 373);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(667, 71);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.TabStop = false;
            this.radGroupBox2.Text = "DETAIL";
            this.radGroupBox2.ThemeName = "Office2010Blue";
            // 
            // txt_Code
            // 
            this.txt_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_Code.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Code.Location = new System.Drawing.Point(5, 43);
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.Size = new System.Drawing.Size(122, 21);
            this.txt_Code.TabIndex = 7;
            this.txt_Code.TabStop = false;
            this.txt_Code.ThemeName = "Office2010Blue";
            // 
            // txt_Libelle
            // 
            this.txt_Libelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Libelle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Libelle.Location = new System.Drawing.Point(133, 43);
            this.txt_Libelle.Name = "txt_Libelle";
            this.txt_Libelle.ReadOnly = true;
            this.txt_Libelle.Size = new System.Drawing.Size(525, 21);
            this.txt_Libelle.TabIndex = 1;
            this.txt_Libelle.TabStop = false;
            this.txt_Libelle.ThemeName = "Office2010Blue";
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.Black;
            this.radLabel1.Location = new System.Drawing.Point(5, 22);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(39, 17);
            this.radLabel1.TabIndex = 8;
            this.radLabel1.Text = "CODE";
            this.radLabel1.ThemeName = "Office2010Blue";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.ForeColor = System.Drawing.Color.Black;
            this.radLabel2.Location = new System.Drawing.Point(133, 21);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(33, 17);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "NOM";
            this.radLabel2.ThemeName = "Office2010Blue";
            // 
            // btn_Supprimer
            // 
            this.btn_Supprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Supprimer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Supprimer.Image = global::LGC.UI.Properties.Resources.cross;
            this.btn_Supprimer.Location = new System.Drawing.Point(573, 450);
            this.btn_Supprimer.Name = "btn_Supprimer";
            this.btn_Supprimer.Size = new System.Drawing.Size(102, 28);
            this.btn_Supprimer.TabIndex = 4;
            this.btn_Supprimer.Text = "&Supprimer";
            this.btn_Supprimer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Supprimer.ThemeName = "Office2010Blue";
            this.btn_Supprimer.Click += new System.EventHandler(this.btn_Supprimer_Click);
            // 
            // btn_Modifier
            // 
            this.btn_Modifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Modifier.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modifier.Image = global::LGC.UI.Properties.Resources.icon_write;
            this.btn_Modifier.Location = new System.Drawing.Point(451, 450);
            this.btn_Modifier.Name = "btn_Modifier";
            this.btn_Modifier.Size = new System.Drawing.Size(116, 28);
            this.btn_Modifier.TabIndex = 3;
            this.btn_Modifier.Text = "&Modifier";
            this.btn_Modifier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Modifier.ThemeName = "Office2010Blue";
            this.btn_Modifier.Click += new System.EventHandler(this.btn_Modifier_Click);
            // 
            // btn_Enregistrer
            // 
            this.btn_Enregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Enregistrer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Enregistrer.Image = global::LGC.UI.Properties.Resources.saveHS;
            this.btn_Enregistrer.Location = new System.Drawing.Point(451, 450);
            this.btn_Enregistrer.Name = "btn_Enregistrer";
            this.btn_Enregistrer.Size = new System.Drawing.Size(116, 28);
            this.btn_Enregistrer.TabIndex = 6;
            this.btn_Enregistrer.Text = "&Enregistrer";
            this.btn_Enregistrer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Enregistrer.ThemeName = "Office2010Blue";
            this.btn_Enregistrer.Click += new System.EventHandler(this.btn_Enregistrer_Click);
            // 
            // btn_Nouveau
            // 
            this.btn_Nouveau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Nouveau.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Nouveau.Image = global::LGC.UI.Properties.Resources.Add;
            this.btn_Nouveau.Location = new System.Drawing.Point(343, 450);
            this.btn_Nouveau.Name = "btn_Nouveau";
            this.btn_Nouveau.Size = new System.Drawing.Size(102, 28);
            this.btn_Nouveau.TabIndex = 2;
            this.btn_Nouveau.Text = "&Nouveau";
            this.btn_Nouveau.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Nouveau.ThemeName = "Office2010Blue";
            this.btn_Nouveau.Click += new System.EventHandler(this.btn_Nouveau_Click);
            // 
            // btn_Annuler
            // 
            this.btn_Annuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Annuler.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Annuler.Image = global::LGC.UI.Properties.Resources.Edit_UndoHS;
            this.btn_Annuler.Location = new System.Drawing.Point(343, 450);
            this.btn_Annuler.Name = "btn_Annuler";
            this.btn_Annuler.Size = new System.Drawing.Size(102, 28);
            this.btn_Annuler.TabIndex = 5;
            this.btn_Annuler.Text = "&Annuler";
            this.btn_Annuler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Annuler.ThemeName = "Office2010Blue";
            this.btn_Annuler.Click += new System.EventHandler(this.btn_Annuler_Click);
            // 
            // btn_Actualiser
            // 
            this.btn_Actualiser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Actualiser.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Actualiser.Image = global::LGC.UI.Properties.Resources.actualiser;
            this.btn_Actualiser.Location = new System.Drawing.Point(7, 450);
            this.btn_Actualiser.Name = "btn_Actualiser";
            this.btn_Actualiser.Size = new System.Drawing.Size(102, 28);
            this.btn_Actualiser.TabIndex = 11;
            this.btn_Actualiser.Text = "A&ctualiser";
            this.btn_Actualiser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Actualiser.ThemeName = "Office2010Blue";
            this.btn_Actualiser.Click += new System.EventHandler(this.btn_Actualiser_Click);
            // 
            // Frm_UniteMesure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 487);
            this.Controls.Add(this.btn_Actualiser);
            this.Controls.Add(this.btn_Supprimer);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.btn_Nouveau);
            this.Controls.Add(this.btn_Annuler);
            this.Controls.Add(this.btn_Modifier);
            this.Controls.Add(this.btn_Enregistrer);
            this.MinimumSize = new System.Drawing.Size(689, 517);
            this.Name = "Frm_UniteMesure";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UNITE DE MESURE";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.Frm_Matières_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Liste.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Liste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_UniteMesure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Libelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Supprimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Modifier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Nouveau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Annuler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Actualiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        //private Telerik.WinControls.UI.RadGridView dgv_Liste;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadTextBox txt_Libelle;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        private Telerik.WinControls.UI.RadButton btn_Supprimer;
        private Telerik.WinControls.UI.RadButton btn_Modifier;
        private Telerik.WinControls.UI.RadButton btn_Enregistrer;
        private Telerik.WinControls.UI.RadButton btn_Nouveau;
        private Telerik.WinControls.UI.RadButton btn_Annuler;
        private System.Windows.Forms.BindingSource bds_UniteMesure;
        private Telerik.WinControls.UI.RadButton btn_Actualiser;
        private Telerik.WinControls.UI.RadGridView dgv_Liste;
        private Telerik.WinControls.UI.RadTextBox txt_Code;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
