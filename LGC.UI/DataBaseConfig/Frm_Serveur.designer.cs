using Telerik.WinControls.UI;
namespace LGC.UI.DataBaseConfig
{
    partial class Frm_Serveur
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Moteur de bases de données", 3, 3);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Serveur));
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Moteur de base de données", 3, 3);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.trVwLocal = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.trVwReseau = new System.Windows.Forms.TreeView();
            this.btnAide = new Telerik.WinControls.UI.RadButton();
            this.btnAnnuler = new Telerik.WinControls.UI.RadButton();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAnnuler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(366, 325);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.trVwLocal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(358, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Serveurs locaux";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sélectionner le serveur auquel se connecter :";
            // 
            // trVwLocal
            // 
            this.trVwLocal.ImageKey = "db.ico";
            this.trVwLocal.ImageList = this.imageList1;
            this.trVwLocal.Location = new System.Drawing.Point(6, 41);
            this.trVwLocal.Name = "trVwLocal";
            treeNode1.ImageIndex = 3;
            treeNode1.Name = "Noeud0";
            treeNode1.SelectedImageIndex = 3;
            treeNode1.Text = "Moteur de bases de données";
            this.trVwLocal.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trVwLocal.SelectedImageKey = "servers.ico";
            this.trVwLocal.Size = new System.Drawing.Size(346, 252);
            this.trVwLocal.TabIndex = 0;
            this.toolTip1.SetToolTip(this.trVwLocal, "Serveur SQL local");
            this.trVwLocal.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trVwLocal_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "database.png");
            this.imageList1.Images.SetKeyName(1, "server.png");
            this.imageList1.Images.SetKeyName(2, "Computer.ico");
            this.imageList1.Images.SetKeyName(3, "db.ico");
            this.imageList1.Images.SetKeyName(4, "dbs.ico");
            this.imageList1.Images.SetKeyName(5, "servers.ico");
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.trVwReseau);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(358, 299);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Serveurs réseaux";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sélectionner une instance de SQL Server sur le réseau pour votre connexion :";
            // 
            // trVwReseau
            // 
            this.trVwReseau.ImageIndex = 3;
            this.trVwReseau.ImageList = this.imageList1;
            this.trVwReseau.Location = new System.Drawing.Point(6, 47);
            this.trVwReseau.Name = "trVwReseau";
            treeNode2.ImageIndex = 3;
            treeNode2.Name = "Noeud0";
            treeNode2.SelectedImageIndex = 3;
            treeNode2.Text = "Moteur de base de données";
            this.trVwReseau.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.trVwReseau.SelectedImageKey = "servers.ico";
            this.trVwReseau.Size = new System.Drawing.Size(346, 246);
            this.trVwReseau.StateImageList = this.imageList1;
            this.trVwReseau.TabIndex = 1;
            this.toolTip1.SetToolTip(this.trVwReseau, "Liste des Serveurs SQL disponibles dans le réseau");
            this.trVwReseau.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trVwReseau_AfterSelect);
            // 
            // btnAide
            // 
            this.btnAide.Location = new System.Drawing.Point(302, 343);
            this.btnAide.Name = "btnAide";
            this.btnAide.Size = new System.Drawing.Size(75, 25);
            this.btnAide.TabIndex = 1;
            this.btnAide.Text = "Aide";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Location = new System.Drawing.Point(217, 343);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 25);
            this.btnAnnuler.TabIndex = 2;
            this.btnAnnuler.Text = "Annuler";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(132, 343);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.ThemeName = "Office2010Blue";
            // 
            // Frm_Serveur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(389, 377);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnAide);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Serveur";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rechercher les serveurs";
            this.ThemeName = "Office2010Silver";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAnnuler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private RadButton btnAide;
        private RadButton btnAnnuler;
        private RadButton btnOk;
        private RadLabel label1;
        private RadLabel label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.TreeView trVwLocal;
        public System.Windows.Forms.TreeView trVwReseau;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
    }
}