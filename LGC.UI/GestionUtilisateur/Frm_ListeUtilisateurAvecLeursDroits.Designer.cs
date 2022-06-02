namespace LGC.UI.GestionUtilisateur
{
    partial class Frm_ListeUtilisateurAvecLeursDroits
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn3 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox6 = new Telerik.WinControls.UI.RadGroupBox();
            this.dgv_ListeUtilisateur = new Telerik.WinControls.UI.RadGridView();
            this.bds_listeUtilisateur = new System.Windows.Forms.BindingSource(this.components);
            this.radGroupBox7 = new Telerik.WinControls.UI.RadGroupBox();
            this.dgv_listeDroitParUtil = new Telerik.WinControls.UI.RadGridView();
            this.bds_DroitsParUtlisateur = new System.Windows.Forms.BindingSource(this.components);
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btn_imprimerTout = new Telerik.WinControls.UI.RadButton();
            this.btn_imprimer = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).BeginInit();
            this.radGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListeUtilisateur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListeUtilisateur.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_listeUtilisateur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox7)).BeginInit();
            this.radGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listeDroitParUtil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listeDroitParUtil.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_DroitsParUtlisateur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_imprimerTout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_imprimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox6
            // 
            this.radGroupBox6.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox6.Controls.Add(this.dgv_ListeUtilisateur);
            this.radGroupBox6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox6.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox6.HeaderText = "LISTE DES UTILISATEURS";
            this.radGroupBox6.Location = new System.Drawing.Point(9, 60);
            this.radGroupBox6.Name = "radGroupBox6";
            this.radGroupBox6.Size = new System.Drawing.Size(397, 518);
            this.radGroupBox6.TabIndex = 49;
            this.radGroupBox6.Text = "LISTE DES UTILISATEURS";
            this.radGroupBox6.ThemeName = "Office2010Blue";
            // 
            // dgv_ListeUtilisateur
            // 
            this.dgv_ListeUtilisateur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dgv_ListeUtilisateur.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv_ListeUtilisateur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ListeUtilisateur.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.dgv_ListeUtilisateur.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgv_ListeUtilisateur.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_ListeUtilisateur.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.dgv_ListeUtilisateur.MasterTemplate.AllowAddNewRow = false;
            this.dgv_ListeUtilisateur.MasterTemplate.AllowDeleteRow = false;
            this.dgv_ListeUtilisateur.MasterTemplate.AllowEditRow = false;
            this.dgv_ListeUtilisateur.MasterTemplate.AllowRowResize = false;
            this.dgv_ListeUtilisateur.MasterTemplate.AutoGenerateColumns = false;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "NumeroUtilisateur";
            gridViewDecimalColumn1.HeaderText = "NumeroUtilisateur";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "NumeroUtilisateur";
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "NomUtilisateur";
            gridViewTextBoxColumn1.HeaderText = "NOM";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "NomUtilisateur";
            gridViewTextBoxColumn1.Width = 181;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "PrenomUtilisateur";
            gridViewTextBoxColumn2.HeaderText = "PRENOM";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "PrenomUtilisateur";
            gridViewTextBoxColumn2.Width = 196;
            this.dgv_ListeUtilisateur.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.dgv_ListeUtilisateur.MasterTemplate.DataSource = this.bds_listeUtilisateur;
            this.dgv_ListeUtilisateur.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgv_ListeUtilisateur.MasterTemplate.EnableFiltering = true;
            this.dgv_ListeUtilisateur.MasterTemplate.EnableGrouping = false;
            this.dgv_ListeUtilisateur.MasterTemplate.ShowRowHeaderColumn = false;
            this.dgv_ListeUtilisateur.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgv_ListeUtilisateur.Name = "dgv_ListeUtilisateur";
            this.dgv_ListeUtilisateur.ReadOnly = true;
            this.dgv_ListeUtilisateur.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_ListeUtilisateur.Size = new System.Drawing.Size(393, 498);
            this.dgv_ListeUtilisateur.TabIndex = 0;
            this.dgv_ListeUtilisateur.Text = "radGridView1";
            this.dgv_ListeUtilisateur.ThemeName = "Office2010Blue";
            this.dgv_ListeUtilisateur.SelectionChanged += new System.EventHandler(this.dgv_Listeutil_SelectionChanged);
            // 
            // bds_listeUtilisateur
            // 
            this.bds_listeUtilisateur.DataSource = typeof(LGC.Business.GestionUtilisateur.Utilisateur);
            // 
            // radGroupBox7
            // 
            this.radGroupBox7.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox7.Controls.Add(this.dgv_listeDroitParUtil);
            this.radGroupBox7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox7.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox7.HeaderText = "LISTE DES DROITS";
            this.radGroupBox7.Location = new System.Drawing.Point(415, 60);
            this.radGroupBox7.Name = "radGroupBox7";
            this.radGroupBox7.Size = new System.Drawing.Size(392, 518);
            this.radGroupBox7.TabIndex = 50;
            this.radGroupBox7.Text = "LISTE DES DROITS";
            this.radGroupBox7.ThemeName = "Office2010Blue";
            // 
            // dgv_listeDroitParUtil
            // 
            this.dgv_listeDroitParUtil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dgv_listeDroitParUtil.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv_listeDroitParUtil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_listeDroitParUtil.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.dgv_listeDroitParUtil.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgv_listeDroitParUtil.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_listeDroitParUtil.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.dgv_listeDroitParUtil.MasterTemplate.AllowAddNewRow = false;
            this.dgv_listeDroitParUtil.MasterTemplate.AllowDeleteRow = false;
            this.dgv_listeDroitParUtil.MasterTemplate.AllowEditRow = false;
            this.dgv_listeDroitParUtil.MasterTemplate.AllowRowResize = false;
            this.dgv_listeDroitParUtil.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "CodeDroit";
            gridViewTextBoxColumn3.HeaderText = "CodeDroit";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "CodeDroit";
            gridViewTextBoxColumn3.Width = 101;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "LibelleDroit";
            gridViewTextBoxColumn4.HeaderText = "DROITS";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "LibelleDroit";
            gridViewTextBoxColumn4.Width = 444;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "Creation";
            gridViewCheckBoxColumn1.HeaderText = "C";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "Creation";
            gridViewCheckBoxColumn2.EnableExpressionEditor = false;
            gridViewCheckBoxColumn2.FieldName = "Modification";
            gridViewCheckBoxColumn2.HeaderText = "M";
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "Modification";
            gridViewCheckBoxColumn3.EnableExpressionEditor = false;
            gridViewCheckBoxColumn3.FieldName = "Suppression";
            gridViewCheckBoxColumn3.HeaderText = "S";
            gridViewCheckBoxColumn3.MinWidth = 20;
            gridViewCheckBoxColumn3.Name = "Suppression";
            this.dgv_listeDroitParUtil.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCheckBoxColumn1,
            gridViewCheckBoxColumn2,
            gridViewCheckBoxColumn3});
            this.dgv_listeDroitParUtil.MasterTemplate.DataSource = this.bds_DroitsParUtlisateur;
            this.dgv_listeDroitParUtil.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgv_listeDroitParUtil.MasterTemplate.EnableFiltering = true;
            this.dgv_listeDroitParUtil.MasterTemplate.EnableGrouping = false;
            this.dgv_listeDroitParUtil.MasterTemplate.ShowRowHeaderColumn = false;
            this.dgv_listeDroitParUtil.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.dgv_listeDroitParUtil.Name = "dgv_listeDroitParUtil";
            this.dgv_listeDroitParUtil.ReadOnly = true;
            this.dgv_listeDroitParUtil.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_listeDroitParUtil.Size = new System.Drawing.Size(388, 498);
            this.dgv_listeDroitParUtil.TabIndex = 0;
            this.dgv_listeDroitParUtil.Text = "radGridView1";
            this.dgv_listeDroitParUtil.ThemeName = "Office2010Blue";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.btn_imprimerTout);
            this.radGroupBox1.Controls.Add(this.btn_imprimer);
            this.radGroupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(14, 7);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(392, 47);
            this.radGroupBox1.TabIndex = 51;
            this.radGroupBox1.ThemeName = "Office2010Blue";
            // 
            // btn_imprimerTout
            // 
            this.btn_imprimerTout.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imprimerTout.Image = global::LGC.UI.Properties.Resources.print;
            this.btn_imprimerTout.Location = new System.Drawing.Point(237, 10);
            this.btn_imprimerTout.Name = "btn_imprimerTout";
            this.btn_imprimerTout.Size = new System.Drawing.Size(147, 26);
            this.btn_imprimerTout.TabIndex = 50;
            this.btn_imprimerTout.Text = "    Imprimer Tout";
            this.btn_imprimerTout.ThemeName = "Office2010Blue";
            this.btn_imprimerTout.Click += new System.EventHandler(this.btn_imprimerTout_Click);
            // 
            // btn_imprimer
            // 
            this.btn_imprimer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imprimer.Image = global::LGC.UI.Properties.Resources.print;
            this.btn_imprimer.Location = new System.Drawing.Point(5, 10);
            this.btn_imprimer.Name = "btn_imprimer";
            this.btn_imprimer.Size = new System.Drawing.Size(138, 26);
            this.btn_imprimer.TabIndex = 49;
            this.btn_imprimer.Text = " &Imprimer";
            this.btn_imprimer.ThemeName = "Office2010Blue";
            this.btn_imprimer.Click += new System.EventHandler(this.btn_imprimer_Click);
            // 
            // Frm_ListeUtilisateurAvecLeursDroits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 586);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radGroupBox7);
            this.Controls.Add(this.radGroupBox6);
            this.Name = "Frm_ListeUtilisateurAvecLeursDroits";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liste des Droits Par Utilisateur";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.Frm_ListeUtilisateurAvecLeursDroits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).EndInit();
            this.radGroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListeUtilisateur.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListeUtilisateur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_listeUtilisateur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox7)).EndInit();
            this.radGroupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listeDroitParUtil.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listeDroitParUtil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_DroitsParUtlisateur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_imprimerTout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_imprimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox6;
        private Telerik.WinControls.UI.RadGridView dgv_ListeUtilisateur;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox7;
        private Telerik.WinControls.UI.RadGridView dgv_listeDroitParUtil;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btn_imprimerTout;
        private Telerik.WinControls.UI.RadButton btn_imprimer;
        private System.Windows.Forms.BindingSource bds_listeUtilisateur;
        private System.Windows.Forms.BindingSource bds_DroitsParUtlisateur;

    }
}
