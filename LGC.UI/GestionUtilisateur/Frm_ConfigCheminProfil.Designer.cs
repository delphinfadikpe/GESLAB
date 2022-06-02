namespace LGC.UI.GestionUtilisateur
{
    partial class Frm_ConfigCheminProfil
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
            this.btn_Enregistrer = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txt_Chemin = new Telerik.WinControls.UI.RadTextBox();
            this.btn_ChoixChemin = new Telerik.WinControls.UI.RadButton();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Chemin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ChoixChemin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Enregistrer
            // 
            this.btn_Enregistrer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Enregistrer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Enregistrer.Location = new System.Drawing.Point(260, 46);
            this.btn_Enregistrer.Name = "btn_Enregistrer";
            this.btn_Enregistrer.Size = new System.Drawing.Size(122, 24);
            this.btn_Enregistrer.TabIndex = 73;
            this.btn_Enregistrer.Text = "&Enregistrer";
            this.btn_Enregistrer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Enregistrer.ThemeName = "Office2010Blue";
            this.btn_Enregistrer.Click += new System.EventHandler(this.btn_Enregistrer_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radLabel1.AutoSize = false;
            this.radLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(6, 2);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(234, 19);
            this.radLabel1.TabIndex = 69;
            this.radLabel1.Text = "CHEMIN DU DOSSIER PROFIL";
            this.radLabel1.ThemeName = "Office2010Blue";
            // 
            // txt_Chemin
            // 
            this.txt_Chemin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_Chemin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Chemin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Chemin.Location = new System.Drawing.Point(6, 22);
            this.txt_Chemin.Name = "txt_Chemin";
            this.txt_Chemin.ReadOnly = true;
            this.txt_Chemin.Size = new System.Drawing.Size(339, 21);
            this.txt_Chemin.TabIndex = 68;
            this.txt_Chemin.ThemeName = "Office2010Blue";
            // 
            // btn_ChoixChemin
            // 
            this.btn_ChoixChemin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ChoixChemin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChoixChemin.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_ChoixChemin.Location = new System.Drawing.Point(351, 22);
            this.btn_ChoixChemin.Name = "btn_ChoixChemin";
            this.btn_ChoixChemin.Size = new System.Drawing.Size(31, 21);
            this.btn_ChoixChemin.TabIndex = 74;
            this.btn_ChoixChemin.Text = "...";
            this.btn_ChoixChemin.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ChoixChemin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_ChoixChemin.ThemeName = "Office2010Blue";
            this.btn_ChoixChemin.Click += new System.EventHandler(this.btn_ChoixChemin_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "AIDE ROMAS GESCOM.chm";
            // 
            // Frm_ConfigCheminProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 72);
            this.Controls.Add(this.btn_ChoixChemin);
            this.Controls.Add(this.btn_Enregistrer);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.txt_Chemin);
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "702");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.KeyPreview = true;
            this.Name = "Frm_ConfigCheminProfil";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONFIGURATION DU CHEMIN PROFIL";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.Frm_ConfigCheminProfil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Chemin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ChoixChemin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btn_Enregistrer;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txt_Chemin;
        private Telerik.WinControls.UI.RadButton btn_ChoixChemin;
        private System.Windows.Forms.HelpProvider helpProvider1;



    }
}
