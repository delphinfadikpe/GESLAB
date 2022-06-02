using LGC.Business;
using LGCUI.DataBaseConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace LGC.UI.Parametre
{
    public partial class Frm_ConfigSaveRestoreDB : Telerik.WinControls.UI.RadForm
    {
        public Frm_ConfigSaveRestoreDB(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }

        private void btn_Serveur_Click(object sender, EventArgs e)
        {
            try
            {

                
                using (Frm_Resaux frm = new Frm_Resaux())
                {
                    frm.ShowDialog();
                    txt_BD.Text = frm.bd.Trim();
                    txt_Serveur.Text = frm.serveur.Trim();
                    txt_Connexion.Text = frm.util.Trim();
                    txt_MotDePAsse.Text=frm.mp.Trim();
                }

            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, CurrentUser.MessageErreur, CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {


            #region controles
           
            if (txt_Serveur.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Serveur de restauration obligatoire", CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            if (txt_Connexion.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Connexion obligatoire", CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            if (txt_MotDePAsse.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Mot de passe obligatoire", CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            if (txt_BD.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Base de données obligatoire", CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            #endregion


            try
            {

                string chaineCrypte = "";
               
                    chaineCrypte = txt_Serveur.Text.Trim() + ";" + txt_BD.Text.Trim() +
                           ";" + txt_Connexion.Text.Trim() + ";" + txt_MotDePAsse.Text.Trim() ;
                    chaineCrypte = CurrentUser.EncryptString(chaineCrypte, "abc123deaoezdf77",
                        "abc123deaoezdf78");
                    using (StreamWriter sw = new StreamWriter(CurrentUser.AppPath + "/strcbackup.csv", false, Encoding.Default))
                    {
                        sw.Write(chaineCrypte);
                        sw.Flush();
                        sw.Close();
                    }

                    RadMessageBox.Show("Paramétrage réussi !", CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                

            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, CurrentUser.MessageErreur, CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void Frm_ConfigSaveRestoreDB_Load(object sender, EventArgs e)
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

                                  
                    txt_Serveur.Text = recuperationT[0].Trim();
                    txt_BD.Text = recuperationT[1].Trim();
                    txt_Connexion.Text = recuperationT[2].Trim();
                    txt_MotDePAsse.Text = recuperationT[3].Trim();
                btn_Enregistrer.Enabled = true;

            }
        }

        private void btn_CheminS_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_CheminR_Click(object sender, EventArgs e)
        {
           
        }
    }
}
