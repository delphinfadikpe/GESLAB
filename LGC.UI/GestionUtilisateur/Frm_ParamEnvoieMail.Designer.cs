namespace LGO.UI.GestionUtilisateur
{
    partial class Frm_ParamEnvoieMail
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
            this.txt_Mail = new Telerik.WinControls.UI.RadTextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.chk_protocole = new Telerik.WinControls.UI.RadCheckBox();
            this.txt_Mdp = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txt_Smtp = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txt_Message = new Telerik.WinControls.UI.RadTextBox();
            this.msk_port = new Telerik.WinControls.UI.RadMaskedEditBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_protocole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mdp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Smtp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Message)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msk_port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Enregistrer
            // 
            this.btn_Enregistrer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Enregistrer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Enregistrer.Location = new System.Drawing.Point(264, 403);
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
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.AutoSize = false;
            this.radLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(8, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(234, 19);
            this.radLabel1.TabIndex = 69;
            this.radLabel1.Text = "MAIL";
            this.radLabel1.ThemeName = "Office2010Blue";
            // 
            // txt_Mail
            // 
            this.txt_Mail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Mail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Mail.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Mail.Location = new System.Drawing.Point(8, 32);
            this.txt_Mail.Name = "txt_Mail";
            this.txt_Mail.Size = new System.Drawing.Size(378, 21);
            this.txt_Mail.TabIndex = 68;
            this.txt_Mail.ThemeName = "Office2010Blue";
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "AIDE ROMAS GESCOM.chm";
            // 
            // chk_protocole
            // 
            this.chk_protocole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_protocole.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.chk_protocole.Location = new System.Drawing.Point(193, 175);
            this.chk_protocole.Name = "chk_protocole";
            // 
            // 
            // 
            this.chk_protocole.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.chk_protocole.RootElement.AngleTransform = 0F;
            this.chk_protocole.RootElement.FlipText = false;
            this.chk_protocole.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.chk_protocole.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.helpProvider1.SetShowHelp(this.chk_protocole, true);
            this.chk_protocole.Size = new System.Drawing.Size(193, 19);
            this.chk_protocole.TabIndex = 90;
            this.chk_protocole.Text = "utilise le protocole SSL";
            // 
            // txt_Mdp
            // 
            this.txt_Mdp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Mdp.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.txt_Mdp.Location = new System.Drawing.Point(8, 84);
            this.txt_Mdp.Name = "txt_Mdp";
            this.txt_Mdp.PasswordChar = '*';
            // 
            // 
            // 
            this.txt_Mdp.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.txt_Mdp.RootElement.AngleTransform = 0F;
            this.txt_Mdp.RootElement.FlipText = false;
            this.txt_Mdp.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Mdp.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.helpProvider1.SetShowHelp(this.txt_Mdp, true);
            this.txt_Mdp.Size = new System.Drawing.Size(374, 21);
            this.txt_Mdp.TabIndex = 94;
            this.txt_Mdp.ThemeName = "Office2010Blue";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.AutoSize = false;
            this.radLabel2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(8, 59);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(234, 19);
            this.radLabel2.TabIndex = 76;
            this.radLabel2.Text = "MOT DE PASSE DU COMPTE";
            this.radLabel2.ThemeName = "Office2010Blue";
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel3.AutoSize = false;
            this.radLabel3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(8, 153);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(234, 19);
            this.radLabel3.TabIndex = 80;
            this.radLabel3.Text = "PORT";
            this.radLabel3.ThemeName = "Office2010Blue";
            // 
            // radLabel4
            // 
            this.radLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel4.AutoSize = false;
            this.radLabel4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(8, 106);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(234, 19);
            this.radLabel4.TabIndex = 78;
            this.radLabel4.Text = "SMTP";
            this.radLabel4.ThemeName = "Office2010Blue";
            // 
            // txt_Smtp
            // 
            this.txt_Smtp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Smtp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Smtp.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Smtp.Location = new System.Drawing.Point(8, 126);
            this.txt_Smtp.Name = "txt_Smtp";
            this.txt_Smtp.Size = new System.Drawing.Size(378, 21);
            this.txt_Smtp.TabIndex = 77;
            this.txt_Smtp.ThemeName = "Office2010Blue";
            // 
            // radLabel5
            // 
            this.radLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel5.AutoSize = false;
            this.radLabel5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(8, 200);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(234, 19);
            this.radLabel5.TabIndex = 92;
            this.radLabel5.Text = "INFOS DE BAS DE PAGE AVIS";
            this.radLabel5.ThemeName = "Office2010Blue";
            // 
            // txt_Message
            // 
            this.txt_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Message.AutoSize = false;
            this.txt_Message.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Message.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Message.Location = new System.Drawing.Point(8, 220);
            this.txt_Message.Name = "txt_Message";
            this.txt_Message.Size = new System.Drawing.Size(378, 177);
            this.txt_Message.TabIndex = 91;
            this.txt_Message.ThemeName = "Office2010Blue";
            // 
            // msk_port
            // 
            this.msk_port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msk_port.Location = new System.Drawing.Point(8, 175);
            this.msk_port.Name = "msk_port";
            this.msk_port.Size = new System.Drawing.Size(179, 20);
            this.msk_port.TabIndex = 93;
            this.msk_port.TabStop = false;
            // 
            // Frm_ParamEnvoieMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 439);
            this.Controls.Add(this.txt_Mdp);
            this.Controls.Add(this.msk_port);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.txt_Message);
            this.Controls.Add(this.chk_protocole);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.txt_Smtp);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.btn_Enregistrer);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.txt_Mail);
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "702");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_ParamEnvoieMail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PARAMETRAGE D\'ENVOIE DE MAIL";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.Frm_ConfigCheminProfil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_protocole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mdp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Smtp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Message)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msk_port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btn_Enregistrer;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txt_Mail;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txt_Smtp;
        private Telerik.WinControls.UI.RadCheckBox chk_protocole;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txt_Message;
        private Telerik.WinControls.UI.RadMaskedEditBox msk_port;
        private Telerik.WinControls.UI.RadTextBox txt_Mdp;



    }
}
