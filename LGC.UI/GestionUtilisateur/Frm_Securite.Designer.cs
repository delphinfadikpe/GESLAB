namespace LGC.UI.GestionUtilisateur
{
    partial class Frm_Securite
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
            this.radGroupBox8 = new Telerik.WinControls.UI.RadGroupBox();
            this.me_nbMois = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.meb_ancienneDate = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.btn_Enregistrer = new Telerik.WinControls.UI.RadButton();
            this.radLabel16 = new Telerik.WinControls.UI.RadLabel();
            this.dtp_NouvelleDate = new Telerik.WinControls.UI.RadDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox8)).BeginInit();
            this.radGroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.me_nbMois)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meb_ancienneDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NouvelleDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox8
            // 
            this.radGroupBox8.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox8.Controls.Add(this.me_nbMois);
            this.radGroupBox8.Controls.Add(this.radLabel3);
            this.radGroupBox8.Controls.Add(this.radLabel2);
            this.radGroupBox8.Controls.Add(this.radLabel1);
            this.radGroupBox8.Controls.Add(this.meb_ancienneDate);
            this.radGroupBox8.Controls.Add(this.btn_Enregistrer);
            this.radGroupBox8.Controls.Add(this.radLabel16);
            this.radGroupBox8.Controls.Add(this.dtp_NouvelleDate);
            this.radGroupBox8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox8.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox8.HeaderText = "";
            this.radGroupBox8.Location = new System.Drawing.Point(3, 5);
            this.radGroupBox8.Name = "radGroupBox8";
            this.radGroupBox8.Size = new System.Drawing.Size(403, 107);
            this.radGroupBox8.TabIndex = 49;
            this.radGroupBox8.ThemeName = "Office2010Blue";
            // 
            // me_nbMois
            // 
            this.me_nbMois.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.me_nbMois.Location = new System.Drawing.Point(148, 34);
            this.me_nbMois.Mask = "N0";
            this.me_nbMois.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.me_nbMois.Name = "me_nbMois";
            this.me_nbMois.Size = new System.Drawing.Size(50, 21);
            this.me_nbMois.TabIndex = 54;
            this.me_nbMois.TabStop = false;
            this.me_nbMois.Text = "0";
            this.me_nbMois.ValueChanged += new System.EventHandler(this.me_nbMois_ValueChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(204, 36);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(62, 19);
            this.radLabel3.TabIndex = 53;
            this.radLabel3.Text = "(MOIS)";
            this.radLabel3.ThemeName = "Office2010Blue";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(148, 9);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(76, 19);
            this.radLabel2.TabIndex = 52;
            this.radLabel2.Text = "AJOUTER";
            this.radLabel2.ThemeName = "Office2010Blue";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(5, 9);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(131, 19);
            this.radLabel1.TabIndex = 50;
            this.radLabel1.Text = "ANCIENNE DATE";
            this.radLabel1.ThemeName = "Office2010Blue";
            // 
            // meb_ancienneDate
            // 
            this.meb_ancienneDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meb_ancienneDate.Location = new System.Drawing.Point(5, 34);
            this.meb_ancienneDate.Mask = "d";
            this.meb_ancienneDate.MaskType = Telerik.WinControls.UI.MaskType.DateTime;
            this.meb_ancienneDate.Name = "meb_ancienneDate";
            this.meb_ancienneDate.ReadOnly = true;
            this.meb_ancienneDate.SelectedText = "15";
            this.meb_ancienneDate.SelectionLength = 2;
            this.meb_ancienneDate.Size = new System.Drawing.Size(126, 21);
            this.meb_ancienneDate.TabIndex = 49;
            this.meb_ancienneDate.TabStop = false;
            this.meb_ancienneDate.Text = "15/06/2015";
            // 
            // btn_Enregistrer
            // 
            this.btn_Enregistrer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Enregistrer.Location = new System.Drawing.Point(270, 73);
            this.btn_Enregistrer.Name = "btn_Enregistrer";
            this.btn_Enregistrer.Size = new System.Drawing.Size(126, 26);
            this.btn_Enregistrer.TabIndex = 48;
            this.btn_Enregistrer.Text = " &ENREGISTRER";
            this.btn_Enregistrer.ThemeName = "Office2010Blue";
            this.btn_Enregistrer.Click += new System.EventHandler(this.btn_Enregistrer_Click);
            // 
            // radLabel16
            // 
            this.radLabel16.Location = new System.Drawing.Point(270, 9);
            this.radLabel16.Name = "radLabel16";
            this.radLabel16.Size = new System.Drawing.Size(130, 19);
            this.radLabel16.TabIndex = 31;
            this.radLabel16.Text = "NOUVELLE DATE";
            this.radLabel16.ThemeName = "Office2010Blue";
            // 
            // dtp_NouvelleDate
            // 
            this.dtp_NouvelleDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_NouvelleDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_NouvelleDate.Location = new System.Drawing.Point(273, 33);
            this.dtp_NouvelleDate.Name = "dtp_NouvelleDate";
            this.dtp_NouvelleDate.Size = new System.Drawing.Size(118, 21);
            this.dtp_NouvelleDate.TabIndex = 33;
            this.dtp_NouvelleDate.TabStop = false;
            this.dtp_NouvelleDate.Text = "24/11/2014";
            this.dtp_NouvelleDate.ThemeName = "Office2010Blue";
            this.dtp_NouvelleDate.Value = new System.DateTime(2014, 11, 24, 19, 31, 32, 822);
            // 
            // Frm_Securite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 116);
            this.Controls.Add(this.radGroupBox8);
            this.Name = "Frm_Securite";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LICENCE";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.Frm_Securite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox8)).EndInit();
            this.radGroupBox8.ResumeLayout(false);
            this.radGroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.me_nbMois)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meb_ancienneDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Enregistrer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NouvelleDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox8;
        private Telerik.WinControls.UI.RadButton btn_Enregistrer;
        private Telerik.WinControls.UI.RadLabel radLabel16;
        private Telerik.WinControls.UI.RadDateTimePicker dtp_NouvelleDate;
        private Telerik.WinControls.UI.RadMaskedEditBox meb_ancienneDate;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadMaskedEditBox me_nbMois;
    }
}
