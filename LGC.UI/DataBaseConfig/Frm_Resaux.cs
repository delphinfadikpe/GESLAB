using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Localization;
using LGC.UI;
using LGC.Business;
using LGC.UI.DataBaseConfig;


namespace LGCUI.DataBaseConfig
{
    public partial class Frm_Resaux : RadForm
    {
        bool deja, connexionReussie = false;
        
        /// <summary>
        /// Contient toutes les instances de Sql Server 2000/2005 qui sont dans le réseau réseau local
        /// </summary>
        private DataTable sqlServers = null;
        /// <summary>
        /// Contient toutes les databases qui sont dans l'instance de sql server sélectionné
        /// </summary>
        private DataTable databases = null;

        public string serveur="";
        public string util="";
        public string mp="";
        public string bd="";
        public string modeCon = "";

        public Frm_Resaux()
        {
            InitializeComponent();
            //RadMessageLocalizationProvider.CurrentProvider = new UI.RadMessageBoxLocalization();
            RadGridLocalizationProvider.CurrentProvider = new FrenchRadGridLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new RadMessageLocalizationProvider();
            //// Localize GridView
            //RadGridLocalizationProvider.CurrentProvider = new UI.RadGridLocalization();

            if (Application.OpenForms["Frm_Menu"] != null)
            {
                //this.ThemeName = Properties.Settings.Default.theme.Trim();
                RadMessageBox.ThemeName = "Office2010Blue";
            }
            else
            {
                this.ThemeName = "Office2010Blue";
                RadMessageBox.ThemeName = "Office2010Blue";
            }
        }

        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            cboAuthentification.SelectedIndex = 1;
        }

        private void btnSuivant1_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedIndex = 1;
                deja = true;
            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, CurrentUser.MessageErreur, CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnPrecedent1_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, CurrentUser.MessageErreur, CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnPrecedent2_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, CurrentUser.MessageErreur, CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnSuivant2_Click(object sender, EventArgs e)
        {
            if ((cboServeur.Text.Trim() == string.Empty) || (cboServeur.Text.Trim() == null) || (cboServeur.Text.Trim() == ""))
            {
                RadMessageBox.Show("Serveur obligatoire !");
                return;
            }

            if (cboAuthentification.Text.Trim() == "")
            {
                RadMessageBox.Show("Authentifictaion obligatoire !");
                return;
            }

            if (cboAuthentification.SelectedIndex == 1 && txtUtilisateur.Text.Trim() == "")
            {
                RadMessageBox.Show("Utilisateur obligatoire !");
                return;
            }

            if (cboAuthentification.SelectedIndex == 1 && txtPassword.Text.Trim() == "")
            {
                RadMessageBox.Show("Mot de passe obligatoire !");
                return;
            }

            if (cboDatabase.Text.Trim() == "")
            {
                RadMessageBox.Show("base de données obligatoire !");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //srv.Connect(cboServeur.Text.Trim(), txtUtilisateur.Text, txtPassword.Text);
                SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
                connectionBuilder.DataSource = cboServeur.Text.Trim();
                connectionBuilder.PersistSecurityInfo = true;

                if (cboAuthentification.SelectedIndex == 1)
                {
                    connectionBuilder.UserID = txtUtilisateur.Text.Trim();
                    connectionBuilder.Password = txtPassword.Text.Trim();
                }
                else
                    connectionBuilder.IntegratedSecurity = true;

                using (SqlConnection dbConnection = new SqlConnection(connectionBuilder.ConnectionString))
                {
                    dbConnection.Open();
                    //databases = dbConnection.GetSchema(SqlClientMetaDataCollectionNames.Databases);

                    dbConnection.Close();
                }

                connexionReussie = true;
                Cursor.Current = Cursors.Default;
                                                
            }
            catch (Exception ex)
            {
                connexionReussie = false;
                Cursor.Current = Cursors.Default;
                cboDatabase.Items.Clear();

                if (RadMessageBox.Show("La connexion au serveur '" + cboServeur.Text + "' a échoué !" +
                    "\n" +
                    ex.Message +
                    "\n" +
                    "Voulez-vous continuer la configuration malgré tout ???", CurrentUser.LogicielHote, MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (cboDatabase.Text.Trim() != "")
                    {
                        tabControl1.SelectedIndex = 2;
                        //srv.DisConnect();
                    }
                    else
                    {
                        RadMessageBox.Show("Saisissez l'adresse du serveur sous la forme :'" + " NOM ou Adresse IP du serveur \\" + "Nom de l'instance '"
                                        + "\n"
                                        + "Exemple : SERVEUR\\MSSQLSERVER");
                        return;
                    }
                }
                
            }
            finally
            {
                //srv.DisConnect();
            }

            this.Cursor = Cursors.Default;
            if ((connexionReussie == true) && (cboDatabase.SelectedIndex != -1))//test réussi, BD sélectionnée
            {
                tabControl1.SelectedIndex = 2;
            }
            else
            {
                if ((connexionReussie == true) && (cboDatabase.SelectedIndex == -1))//test réussi mais BD non sélectionnée
                {
                    RadMessageBox.Show("Veuillez choisir la base de données !", "Base de données manquante", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    cboDatabase.Focus();
                }
            }

            serveur = cboServeur.Text.Trim();
            util = txtUtilisateur.Text.Trim();
            mp = txtPassword.Text;
            bd = cboDatabase.Text;
            if (cboAuthentification.SelectedIndex == 1)
            {
                modeCon = "S";
            }
            else
            {
                modeCon = "W";
            }
        }

        private void btnTerminer_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTester_Click(object sender, EventArgs e)
        {
            if ((cboServeur.Text.Trim() == string.Empty) || (cboServeur.Text.Trim() == null) || (cboServeur.Text.Trim() == ""))
            {
                RadMessageBox.Show("Serveur obligatoire !", CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            if (cboAuthentification.Text.Trim() == "")
            {
                RadMessageBox.Show("Authentifictaion obligatoire !", CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            if (cboAuthentification.SelectedIndex == 1 && txtUtilisateur.Text.Trim() == "")
            {
                RadMessageBox.Show("Utilisateur obligatoire !", CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            if (cboAuthentification.SelectedIndex == 1 && txtPassword.Text.Trim() == "")
            {
                RadMessageBox.Show("Mot de passe obligatoire !", CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            TesterConnexion();
            this.Cursor = Cursors.Default;
        }
    
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (deja == false)
                {
                    this.Cursor = Cursors.WaitCursor;

                    listerServeurLocal();

                    this.Cursor = Cursors.Default;
                }
            }
        }

        private string GetNomMachineLocal()
        {
            // Nom de la machine
            return Environment.MachineName;
        }

        private void listerServeurLocal()
        {
            try
            {
                // Créer une collection de SQL Servers                 
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                sqlServers = instance.GetDataSources();

                // Parcourir la collection une à une
                if (sqlServers.Rows.Count != 0)
                {
                    for (int i = 0; i < sqlServers.Rows.Count; i++)
                    {
                        DataRow srv = sqlServers.Rows[i];
                        if (srv != null)
                        {
                            if ((srv["ServerName"].ToString().Contains("(local)")) || (srv["ServerName"].ToString().Contains(GetNomMachineLocal())))
                            {
                                //this.cboServeur.Items.Add(GetNomMachineLocal());
                                if ((srv["InstanceName"].ToString() == string.Empty) || (srv["InstanceName"].ToString() == ""))
                                {
                                    this.cboServeur.Items.Add(srv["ServerName"].ToString());
                                }
                                else
                                {
                                    this.cboServeur.Items.Add(srv["ServerName"].ToString() + @"\" + srv["InstanceName"].ToString());
                                }
                            }
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
        }

        private void TesterConnexion()
        {            
            cboDatabase.Items.Clear();
            try
            {
                Cursor.Current = Cursors.AppStarting;
                                
                SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
                connectionBuilder.DataSource = cboServeur.Text.Trim();
                connectionBuilder.PersistSecurityInfo = true;
                connectionBuilder.ConnectTimeout = 120;

                if (cboAuthentification.SelectedIndex == 1)
                {
                    connectionBuilder.UserID = txtUtilisateur.Text.Trim();
                    connectionBuilder.Password = txtPassword.Text.Trim();
                }
                else
                    connectionBuilder.IntegratedSecurity = true;

                using (SqlConnection dbConnection = new SqlConnection(connectionBuilder.ConnectionString))
                {
                    dbConnection.Open();
                    databases = dbConnection.GetSchema(SqlClientMetaDataCollectionNames.Databases);
                    
                    dbConnection.Close();
                }

                // parcourir chaque database sur le serveur et l'ajouter au combo box
                for (int j = 0; j < databases.Rows.Count; j++ )
                {
                    if (databases.Rows[j] != null)
                        cboDatabase.Items.Add(databases.Rows[j]["database_name"].ToString());
                }

                if (this.cboDatabase.Items.Count != 0)
                    cboDatabase.Focus();

                connexionReussie = true;
                Cursor.Current = Cursors.Default;
                RadMessageBox.Show("Connexion réussie !", CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            catch (Exception ex)
            {
                connexionReussie = false;
                Cursor.Current = Cursors.Default;
                RadMessageBox.Show("Generateur de la connexion avec le serveur !" + 
                    "\n" +
                    ex.Message, CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                //srv.DisConnect();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlServers = null;
            databases = null;
        }

        private void btnReseau_Click(object sender, EventArgs e)
        {
            using (Frm_Serveur f = new Frm_Serveur(0))
            {
                if (cboServeur.Items.Count > 0)//un serveur local disponible
                {
                    for (int i = 0; i < cboServeur.Items.Count; i++)
                    {                        
                            TreeNode trn = new TreeNode();//créer le noeud du serveur local
                            trn.Text = cboServeur.Items[i].ToString();
                            trn.SelectedImageIndex = 5;
                            trn.ImageIndex = 5;

                            f.trVwLocal.Nodes[0].Nodes.Add(trn);//ajouter le serveur local                        
                    }
                }

                if (f.ShowDialog() == DialogResult.OK)
                {                    
                    cboServeur.Text = f.selectedServer;                    
                }
                else
                {
                    cboServeur.SelectedIndex = -1;
                }
            }
        }

        private void cboAuthentification_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboAuthentification.SelectedIndex == 0)
            {
                txtUtilisateur.Enabled = false;
                txtPassword.Enabled = false;
                txtUtilisateur.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                txtUtilisateur.Enabled = true;
                txtPassword.Enabled = true;
            }
        }
    }
}
