using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Data.Sql;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using LGC.UI;
using LGC.Business;

namespace LGC.UI.DataBaseConfig
{
    public partial class Frm_Serveur : RadForm
    {
        public bool srvReseauVisite = false;
        public string selectedServer;

        /// <summary>
        /// Contient toutes les instances de Sql Server 2000/2005 qui sont dans le réseau réseau local
        /// </summary>
        private DataTable sqlServers = null;
        /// <summary>
        /// Contient toutes les databases qui sont dans l'instance de sql server sélectionné
        /// </summary>
        private DataTable databases = null;

        public Frm_Serveur()
        {
            InitializeComponent();
            if (Application.OpenForms["Frm_Menu"] != null)
            {
                this.ThemeName = ((RadForm)Application.OpenForms["Frm_Menu"]).ThemeName;
                RadMessageBox.ThemeName = "Office2010Blue";
            }
            else
            {
                this.ThemeName = "Office2010Blue";
                RadMessageBox.ThemeName = "Office2010Blue";
            }
            //this.ThemeName = LGG.UI.Properties.Settings.Default.theme.Trim();
        }

        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }

        public Frm_Serveur(int page)
        {
            InitializeComponent();

            tabControl1.SelectedIndex = page;
            if (Application.OpenForms["Frm_Menu"] != null)
            {
                this.ThemeName = ((RadForm)Application.OpenForms["Frm_Menu"]).ThemeName;
                RadMessageBox.ThemeName = "Office2010Blue";
            }
            else
            {
                this.ThemeName = "Office2010Blue";
                RadMessageBox.ThemeName = "Office2010Blue";
            }
        }


        public static string MessageErreur = "Une erreur s'est produite lors de l'exécution de cette instruction.\n Veuillez conctacter l'administrateur";


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
            if (tabControl1.SelectedIndex == 1)
            {
                if (srvReseauVisite == false)
                {
                    srvReseauVisite = true;

                    try
                    {
                        listerServeurReseau();
                    }
                    catch (Exception ex)
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, CurrentUser.MessageErreur, CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
            }
        }

        private void listerServeurReseau()
        {
            this.Cursor = Cursors.WaitCursor;

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
                            if ((srv["InstanceName"].ToString() == string.Empty) || (srv["InstanceName"].ToString() == ""))
                            {
                                //this.cboServeur.Items.Add(srv["ServerName"].ToString());

                                TreeNode nd = new TreeNode();
                                nd.Text = srv["ServerName"].ToString();
                                nd.SelectedImageIndex = 5;
                                nd.ImageIndex = 5;

                                this.trVwReseau.Nodes[0].Nodes.Add(nd);
                            }
                            else
                            {
                                //this.cboServeur.Items.Add(srv["ServerName"].ToString() + @"\" + srv["InstanceName"].ToString());

                                TreeNode nd = new TreeNode();
                                nd.Text = srv["ServerName"].ToString() + @"\" + srv["InstanceName"].ToString();
                                nd.SelectedImageIndex = 5;
                                nd.ImageIndex = 5;

                                this.trVwReseau.Nodes[0].Nodes.Add(nd);
                            }

                        }
                    } 
                }
                
            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, CurrentUser.MessageErreur, CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void trVwReseau_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Parent == trVwReseau.Nodes[0])
                {
                    btnOk.Enabled = true;
                    selectedServer = e.Node.Text;
                    
                }
                else btnOk.Enabled = false;
            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, CurrentUser.MessageErreur, CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void trVwLocal_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Parent == trVwLocal.Nodes[0])
                {
                    btnOk.Enabled = true;
                    selectedServer = e.Node.Text;
                }
                else btnOk.Enabled = false;
            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, CurrentUser.MessageErreur, CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }
}
