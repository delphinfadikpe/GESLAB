using Telerik.WinControls.UI;
namespace LGC.UI.GestionUtilisateur
{
    partial class Frm_Connexion
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btn_Annuler = new Telerik.WinControls.UI.RadButton();
            this.btn_Ok = new Telerik.WinControls.UI.RadButton();
            this.Password_label = new Telerik.WinControls.UI.RadLabel();
            this.panel1 = new Telerik.WinControls.UI.RadPanel();
            this.cb_Utilisateur = new Telerik.WinControls.UI.RadDropDownList();
            this.bds_utilisateur = new System.Windows.Forms.BindingSource(this.components);
            this.txt_MotDePasse = new Telerik.WinControls.UI.RadTextBox();
            this.Login_label = new Telerik.WinControls.UI.RadLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.lbl_NomServeur = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Annuler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password_label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Utilisateur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_utilisateur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MotDePasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Login_label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_NomServeur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radLabel1.Location = new System.Drawing.Point(12, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(370, 44);
            this.radLabel1.TabIndex = 38;
            this.radLabel1.Text = "Veuillez entrer vos Paramètres de connexion";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Annuler
            // 
            this.btn_Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Annuler.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Annuler.Location = new System.Drawing.Point(304, 150);
            this.btn_Annuler.Name = "btn_Annuler";
            this.btn_Annuler.Size = new System.Drawing.Size(82, 32);
            this.btn_Annuler.TabIndex = 3;
            this.btn_Annuler.Text = "&Annuler";
            this.btn_Annuler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Annuler.ThemeName = "Office2010Blue";
            this.btn_Annuler.Click += new System.EventHandler(this.btn_Annuler_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ok.Location = new System.Drawing.Point(218, 150);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(73, 32);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "&OK";
            this.btn_Ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Ok.ThemeName = "Office2010Blue";
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // Password_label
            // 
            this.Password_label.BackColor = System.Drawing.Color.Transparent;
            this.Password_label.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Password_label.Location = new System.Drawing.Point(17, 108);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(118, 19);
            this.Password_label.TabIndex = 36;
            this.Password_label.Text = "MOT DE PASSE";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(17, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 10);
            this.panel1.TabIndex = 37;
            // 
            // cb_Utilisateur
            // 
            this.cb_Utilisateur.AutoCompleteDisplayMember = "LoginUtil";
            this.cb_Utilisateur.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Utilisateur.DataSource = this.bds_utilisateur;
            this.cb_Utilisateur.DisplayMember = "Login";
            this.cb_Utilisateur.DropDownSizingMode = ((Telerik.WinControls.UI.SizingMode)((Telerik.WinControls.UI.SizingMode.RightBottom | Telerik.WinControls.UI.SizingMode.UpDown)));
            this.cb_Utilisateur.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Utilisateur.FormatString = "{0}";
            this.cb_Utilisateur.Location = new System.Drawing.Point(140, 71);
            this.cb_Utilisateur.Name = "cb_Utilisateur";
            this.cb_Utilisateur.NullText = "Sélectionner votre identifiant";
            // 
            // 
            // 
            this.cb_Utilisateur.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.cb_Utilisateur.Size = new System.Drawing.Size(242, 21);
            this.cb_Utilisateur.TabIndex = 0;
            this.cb_Utilisateur.ThemeName = "Office2010Blue";
            // 
            // bds_utilisateur
            // 
            this.bds_utilisateur.DataSource = typeof(LGC.Business.GestionUtilisateur.Utilisateur);
            // 
            // txt_MotDePasse
            // 
            this.txt_MotDePasse.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MotDePasse.Location = new System.Drawing.Point(140, 109);
            this.txt_MotDePasse.Name = "txt_MotDePasse";
            this.txt_MotDePasse.NullText = "Entrer votre mot de passe";
            this.txt_MotDePasse.PasswordChar = '*';
            this.txt_MotDePasse.Size = new System.Drawing.Size(242, 21);
            this.txt_MotDePasse.TabIndex = 1;
            this.txt_MotDePasse.ThemeName = "Office2010Blue";
            // 
            // Login_label
            // 
            this.Login_label.BackColor = System.Drawing.Color.Transparent;
            this.Login_label.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Login_label.Location = new System.Drawing.Point(17, 71);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(110, 19);
            this.Login_label.TabIndex = 35;
            this.Login_label.Text = "UTILISATEUR";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "AIDE ROMAS GESCOM.chm";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(73)))), ((int)(((byte)(242)))));
            this.radLabel2.Location = new System.Drawing.Point(17, 192);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(82, 19);
            this.radLabel2.TabIndex = 40;
            this.radLabel2.Text = "SERVEUR:";
            // 
            // lbl_NomServeur
            // 
            this.lbl_NomServeur.BackColor = System.Drawing.Color.Transparent;
            this.lbl_NomServeur.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NomServeur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(13)))), ((int)(((byte)(248)))));
            this.lbl_NomServeur.Location = new System.Drawing.Point(97, 192);
            this.lbl_NomServeur.Name = "lbl_NomServeur";
            this.lbl_NomServeur.Size = new System.Drawing.Size(2, 2);
            this.lbl_NomServeur.TabIndex = 41;
            // 
            // Frm_Connexion
            // 
            this.AcceptButton = this.btn_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 223);
            this.Controls.Add(this.lbl_NomServeur);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btn_Annuler);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cb_Utilisateur);
            this.Controls.Add(this.txt_MotDePasse);
            this.Controls.Add(this.Login_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "101");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Connexion";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONNEXION";
            this.ThemeName = "Office2010Blue";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_connexion_FormClosing);
            this.Load += new System.EventHandler(this.Frm_connexion_Load);
            this.Click += new System.EventHandler(this.Frm_connexion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Annuler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password_label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Utilisateur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_utilisateur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MotDePasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Login_label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_NomServeur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RadLabel radLabel1;
        private RadButton btn_Annuler;
        private RadButton btn_Ok;
        private RadLabel Password_label;
        private RadPanel panel1;
        public RadDropDownList cb_Utilisateur;
        private System.Windows.Forms.BindingSource bds_utilisateur;
        private RadTextBox txt_MotDePasse;
        private RadLabel Login_label;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private RadLabel radLabel2;
        public RadLabel lbl_NomServeur;
    }
}

