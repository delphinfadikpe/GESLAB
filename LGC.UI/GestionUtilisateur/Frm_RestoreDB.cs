using LGC.Business;
using LGC.Business.GestionUtilisateur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace LGC.UI.GestionUtilisateur
{
    public partial class Frm_RestoreDB : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string cheminDossier; 
        string sortie;
        string[] message;
        List<ConfigurationUM> lstChemin = new List<ConfigurationUM>();      
        #endregion

        #region Autre
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }
        #endregion


        public Frm_RestoreDB(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }

        private void btn_ChoixChemin_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.OpenFileDialog openFD = new System.Windows.Forms.OpenFileDialog();
            openFD.Filter = "Fichiers bak(*.bak)|*.bak";

            if (openFD.ShowDialog() == DialogResult.OK)
                {
                    cheminDossier = openFD.FileName;
                    txt_Chemin.Text = cheminDossier;
                    
                }
            
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            StreamReader sr = null;
            string line;
            string[] recuperationT;


            sr = new StreamReader(CurrentUser.AppPath + "/strcbackup.csv");
            line = sr.ReadLine();

            if (line.Length != 0)
            {
                line = Tools.DecryptString(line, "abc123deaoezdf77", "abc123deaoezdf78");
                recuperationT = line.Split(';');

               
                #region sauvegarde de base de donnes

                //string PathtobackUp = txt_Chemin.Text.Trim();

                //string file_name = PathtobackUp + "\\" + "DB_LABO.bak";
                         

               
                {
                    string con = @"Data Source=" + recuperationT[0].Trim() +
                         ";Initial Catalog=" + recuperationT[1].Trim() +
                         ";Persist Security Info=True;User ID=" + recuperationT[2].Trim() +
                         ";Password=" + recuperationT[3].Trim() + "";

                    string PathtoRestore = txt_Chemin.Text.Trim();

                    

                    #region restauration de base de données
                    SqlConnection SqlCon = new SqlConnection();
                    SqlCon.ConnectionString = con;
                    SqlCon.Open();
                    try
                    {
                        if (RadMessageBox.Show(this, "Voulez-vous vraiment restaurer la base de donnée? ", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                            RadMessageIcon.Question) == DialogResult.Yes)
                        {
                            string sqlStmt2 = string.Format("ALTER DATABASE [DB_LABO] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                            SqlCommand bu2 = new SqlCommand(sqlStmt2, SqlCon);
                            bu2.ExecuteNonQuery();

                            string sqlStmt3 = "USE master RESTORE DATABASE [DB_LABO] FROM DISK='" +PathtoRestore + "'WITH REPLACE;";
                            SqlCommand bu3 = new SqlCommand(sqlStmt3, SqlCon);
                            bu3.ExecuteNonQuery();

                            string sqlStmt4 = string.Format("ALTER DATABASE [DB_LABO] SET MULTI_USER");
                            SqlCommand bu4 = new SqlCommand(sqlStmt4, SqlCon);
                            bu4.ExecuteNonQuery();

                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Restauration éffectuée avec succès.",
                                CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                            SqlCon.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                         RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Sauvegarde échouée.", CurrentUser.LogicielHote,
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    #endregion
                }
                



                #endregion
            }
        }

        private void Frm_ConfigCheminProfil_Load(object sender, EventArgs e)

        {
           
            }
        }
    }

