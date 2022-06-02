namespace LGC.UI.Parametre
{
    partial class Frm_ParamCodeBarre
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
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.cb_encoder = new Telerik.WinControls.UI.RadDropDownList();
            this.chk_showTexte = new Telerik.WinControls.UI.RadCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_encoder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_showTexte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Enregistrer
            // 
            this.btn_Enregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Enregistrer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Enregistrer.Location = new System.Drawing.Point(179, 93);
            this.btn_Enregistrer.Name = "btn_Enregistrer";
            this.btn_Enregistrer.Size = new System.Drawing.Size(122, 24);
            this.btn_Enregistrer.TabIndex = 73;
            this.btn_Enregistrer.Text = "&Enregistrer";
            this.btn_Enregistrer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Enregistrer.ThemeName = "Office2010Blue";
            this.btn_Enregistrer.Click += new System.EventHandler(this.btn_Enregistrer_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "AIDE ROMAS GESCOM.chm";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel5.ForeColor = System.Drawing.Color.Black;
            this.radLabel5.Location = new System.Drawing.Point(12, 12);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(67, 17);
            this.radLabel5.TabIndex = 462;
            this.radLabel5.Text = "ENCODER";
            this.radLabel5.ThemeName = "Office2010Blue";
            // 
            // cb_encoder
            // 
            this.cb_encoder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_encoder.AutoCompleteDisplayMember = "NomPays";
            this.cb_encoder.DisplayMember = "LibelleCategorie";
            this.cb_encoder.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cb_encoder.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_encoder.Location = new System.Drawing.Point(12, 30);
            this.cb_encoder.Name = "cb_encoder";
            this.cb_encoder.Size = new System.Drawing.Size(285, 21);
            this.cb_encoder.TabIndex = 461;
            this.cb_encoder.ThemeName = "Office2010Blue";
            this.cb_encoder.ValueMember = "CodeCategorie";
            // 
            // chk_showTexte
            // 
            this.chk_showTexte.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_showTexte.Location = new System.Drawing.Point(12, 64);
            this.chk_showTexte.Name = "chk_showTexte";
            this.chk_showTexte.Size = new System.Drawing.Size(118, 18);
            this.chk_showTexte.TabIndex = 463;
            this.chk_showTexte.Text = "Afficher Texte";
            // 
            // Frm_ParamCodeBarre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 129);
            this.Controls.Add(this.chk_showTexte);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.cb_encoder);
            this.Controls.Add(this.btn_Enregistrer);
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "702");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_ParamCodeBarre";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PARAMETRAGE DE CODE BARRE";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.Frm_ConfigCheminProfil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_encoder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_showTexte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btn_Enregistrer;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadDropDownList cb_encoder;
        private Telerik.WinControls.UI.RadCheckBox chk_showTexte;



    }
}
