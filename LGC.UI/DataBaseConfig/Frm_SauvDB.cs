using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.IO;
using System.Diagnostics;
using Telerik.WinControls;
using System.Data.SqlClient;
using LGC.Business;
using System.Threading;
using LGC.UI; 

namespace LGC.UI.DataBaseConfig
{
    public partial class Frm_SauvDB : RadForm
    {
        #region Declaration
        int i=0;
        Thread th;
        delegate void Tache();
        Tache sauvRestau;
        Exception exTh = null;
        string mode = "S";
        #endregion

        #region Autres
        private void SauvegarderRestaurer()
        {
            try
            {
                SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
                connectionBuilder.DataSource = CurrentUser.NomServeurProduction.Trim();
                connectionBuilder.PersistSecurityInfo = true;

                if (CurrentUser.ModeCon.Trim() == "S")
                {
                    connectionBuilder.UserID = CurrentUser.NomUtilisateur.Trim();
                    connectionBuilder.Password = CurrentUser.Pwd.Trim();
                    connectionBuilder.InitialCatalog = "DB_TITRESCIEL";
                }
                else
                    connectionBuilder.IntegratedSecurity = true;

                using (SqlConnection dbConnection = new SqlConnection(connectionBuilder.ConnectionString))
                {
                    dbConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    if (mode == "S")
                    {
                        sqlCmd.CommandText = "PS_Sauvegarder_DB";
                        sqlCmd.Parameters.Add(
                            new global::System.Data.SqlClient.SqlParameter("@cheminSauv",
                                txt_CheminSauvegardeRestauration.Text.Trim()));
                        sqlCmd.Parameters.Add(
                            new global::System.Data.SqlClient.SqlParameter("@boursika",
                                chk_boursika.ToggleState ==
                                Telerik.WinControls.Enumerations.ToggleState.On ? true : false));
                       
                    }
                    sqlCmd.Connection = dbConnection;
                    i = sqlCmd.ExecuteNonQuery();

                    //faire la copie ou le deplacement
                    if (rb_copie.IsChecked)
                    {
                        //boursika
                        if (chk_boursika.ToggleState ==
                                Telerik.WinControls.Enumerations.ToggleState.On)
                        {
                            string bsk2 = txt_cheminCopieDeplacement.Text.Trim() + "\\SCHOOLTIC_" +
                                DateTime.Now.ToString().Substring(0, 10).Replace('/', '-') + ".bak";
                            if (File.Exists(bsk2))
                            {
                                File.Delete(bsk2);
                            }
                            File.Copy(txt_CheminSauvegardeRestaurationReseau.Text.Trim() + "\\SCHOOLTIC_" +
                                DateTime.Now.ToString().Substring(0, 10).Replace('/', '-') + ".bak",
                                bsk2);
                        }

                        ////titres
                        //if (chk_Titres.ToggleState ==
                        //        Telerik.WinControls.Enumerations.ToggleState.On)
                        //{
                        //    string titre = txt_cheminCopieDeplacement.Text.Trim() + "\\titres_" +
                        //        DateTime.Now.ToString().Substring(0, 10).Replace('/', '-') + ".bak";
                        //    if (File.Exists(titre))
                        //    {
                        //        File.Delete(titre);
                        //    }
                        //    File.Copy(txt_CheminSauvegardeRestaurationReseau.Text.Trim() + "\\titres_" +
                        //        DateTime.Now.ToString().Substring(0, 10).Replace('/', '-') + ".bak",
                        //        titre);
                        //}

                        ////personne
                        //if (chk_personne.ToggleState ==
                        //        Telerik.WinControls.Enumerations.ToggleState.On)
                        //{
                        //    string personne = txt_cheminCopieDeplacement.Text.Trim() + "\\personne_" +
                        //        DateTime.Now.ToString().Substring(0, 10).Replace('/', '-') + ".bak";
                        //    if (File.Exists(personne))
                        //    {
                        //        File.Delete(personne);
                        //    }
                        //    File.Copy(txt_CheminSauvegardeRestaurationReseau.Text.Trim() + "\\personne_" +
                        //        DateTime.Now.ToString().Substring(0, 10).Replace('/', '-') + ".bak",
                        //        personne);
                        //}

                        //compta
                        //if (chk_comptabilité.ToggleState ==
                        //        Telerik.WinControls.Enumerations.ToggleState.On)
                        //{
                        //    string compta = txt_cheminCopieDeplacement.Text.Trim() + "\\compta_" +
                        //        DateTime.Now.ToString().Substring(0, 10).Replace('/', '-') + ".bak";
                        //    if (File.Exists(compta))
                        //    {
                        //        File.Delete(compta);
                        //    }
                        //    File.Copy(txt_CheminSauvegardeRestaurationReseau.Text.Trim() + "\\compta_" +
                        //        DateTime.Now.ToString().Substring(0, 10).Replace('/', '-') + ".bak",
                        //        compta);
                        //}
                    }
                    else if (rb_deplacement.IsChecked)
                    {

                    }
                    dbConnection.Close();
                }
                

                //mise à jour du watting bar
                this.Invoke(sauvRestau);
            }
            catch (Exception ex)
            {
                exTh = ex;
                this.Invoke(sauvRestau);
            }
        }

        private void MajWB()
        {
            wb.Visible = false;
            wb.StopWaiting();
            gb_paramétrage.Enabled = false;
            btn_Executer.Enabled = false;

            if (exTh != null)
            {
                RadMessageBox.Show(this, exTh.Message, CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                exTh = null;
            }
            else if (i < 0)
            {
                RadMessageBox.Show(this, "Sauvegarde effectuée avec succès.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                if (rb_copie.IsChecked || rb_deplacement.IsChecked)
                {
                    if (chk_ouvrirDossier.ToggleState ==
                                Telerik.WinControls.Enumerations.ToggleState.On)
                    {
                        btn_openCD_Click(null, null);
                    }
                }
            }
            else
            {
                RadMessageBox.Show(this, "Sauvegarde effectuée avec succès.",
                   CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        #endregion

        #region Formulaire
        public Frm_SauvDB()
        {
            InitializeComponent();
        }

        private void Frm_SauvDB_Load(object sender, EventArgs e)
        {
            sauvRestau = new Tache(MajWB);
            //formatage de la grille de sauvegarde
            dgv_cheminBaseDonnées.Rows.Add("TIC SCHOLAIRE 1.0", "");
            //dgv_cheminBaseDonnées.Rows.Add("Comptabilité", "");
            //dgv_cheminBaseDonnées.Rows.Add("Titres", "");
            //dgv_cheminBaseDonnées.Rows.Add("Personne", "");
        } 
        #endregion

        #region bouton d'option
        private void rb_rienFaire_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            txt_cheminCopieDeplacement.Enabled = !rb_rienFaire.IsChecked;
            btn_browseCD.Enabled = !rb_rienFaire.IsChecked;
            btn_openCD.Enabled = !rb_rienFaire.IsChecked;
            //btn_browse.Enabled = !rb_rienFaire.IsChecked;

            //txt_CheminSauvegardeRestaurationReseau.Enabled = !rb_rienFaire.IsChecked;
            btn_browseReseau.Enabled = !rb_rienFaire.IsChecked;
            btn_openReseau.Enabled = !rb_rienFaire.IsChecked;
        } 
        #endregion

        #region Bouton de commande
        private void btn_Executer_Click(object sender, EventArgs e)
        {
            try
            {
                wb.Visible = true;
                wb.StartWaiting();

                gb_paramétrage.Enabled = false;
                btn_Executer.Enabled = false;

                if (txt_CheminSauvegardeRestauration.Text.Trim() == "")
                {
                    RadMessageBox.Show(this, "Veuillez spécier le chemin " +
                            "de sauvegarde ou de restauration.",
                       CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }
                if ((rb_copie.IsChecked || rb_deplacement.IsChecked )&&
                    txt_cheminCopieDeplacement.Text.Trim() == "")
                {
                    RadMessageBox.Show(this, "Veuillez spécier le dossier " +
                        "de destination pour la copie ou le déplacement.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }

                th = new Thread(SauvegarderRestaurer);
                th.Start();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(this, ex.Message, CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            fb.ShowDialog();
            txt_CheminSauvegardeRestauration.Text = fb.SelectedPath;
        }

        private void btn_browseCD_Click(object sender, EventArgs e)
        {
            fb_CD.ShowDialog();
            txt_cheminCopieDeplacement.Text = fb_CD.SelectedPath;
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            //if (Directory.Exists(txt_CheminSauvegardeRestauration.Text.Trim()))
            //{
            //    Process.Start(txt_CheminSauvegardeRestauration.Text.Trim());
            //}
            //else
            //{
            //    RadMessageBox.Show(this, "Ce dossier n'existe pas.",
            //        "Boursika 2.0", MessageBoxButtons.OK, RadMessageIcon.Error);
            //}
        }

        private void btn_openCD_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txt_cheminCopieDeplacement.Text.Trim()))
            {
                Process.Start(txt_cheminCopieDeplacement.Text.Trim());
            }
            else
            {
                RadMessageBox.Show(this, "Ce dossier n'existe pas.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_browseReseau_Click(object sender, EventArgs e)
        {
            fb.ShowDialog();
            txt_CheminSauvegardeRestaurationReseau.Text = fb.SelectedPath;
        }

        private void btn_openReseau_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txt_CheminSauvegardeRestaurationReseau.Text.Trim()))
            {
                Process.Start(txt_CheminSauvegardeRestaurationReseau.Text.Trim());
            }
            else
            {
                RadMessageBox.Show(this, "Ce dossier n'existe pas.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_selectionMultiple_Click(object sender, EventArgs e)
        {
            ofd_Rest.ShowDialog();
        }

        private void btn_browseRest_Click(object sender, EventArgs e)
        {
            fb.ShowDialog();
            txt_DossierServeur.Text = fb.SelectedPath;
        }

        private void btn_OpenRest_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txt_DossierServeur.Text.Trim()))
            {
                Process.Start(txt_DossierServeur.Text.Trim());
            }
            else
            {
                RadMessageBox.Show(this, "Ce dossier n'existe pas.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        #endregion

        #region OpenFileDialog
        private void ofd_Rest_FileOk(object sender, CancelEventArgs e)
        {
            int i = 0;
            foreach (string str in ofd_Rest.FileNames)
            {
                if (i <= 3)
                {
                    string[] chm = str.Split('\\');
                    if (chm[chm.Length - 1].ToLower().StartsWith("D"))
                    {
                        dgv_cheminBaseDonnées.Rows[0].Cells[1].Value = str;
                    }
                    else if (chm[chm.Length - 1].ToLower().StartsWith("c"))
                    {
                        dgv_cheminBaseDonnées.Rows[1].Cells[1].Value = str;
                    }
                    else if (chm[chm.Length - 1].ToLower().StartsWith("t"))
                    {
                        dgv_cheminBaseDonnées.Rows[2].Cells[1].Value = str;
                    }
                    else if (chm[chm.Length - 1].ToLower().StartsWith("p"))
                    {
                        dgv_cheminBaseDonnées.Rows[3].Cells[1].Value = str;
                    }
                }
                i++;
            }
        } 
        #endregion

        #region Case à cocher
        private void chk_DossierServeur_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            txt_DossierServeur.Enabled = (chk_DossierServeur.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On);
            btn_browseRest.Enabled = (chk_DossierServeur.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On);
            btn_OpenRest.Enabled = (chk_DossierServeur.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On);

            txt_cheminDossierServeur.Enabled = (chk_DossierServeur.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On);
        } 
        #endregion
    }
}
