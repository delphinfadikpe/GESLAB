using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.IO;
using LGC.Business;
using LGCUI.DataBaseConfig;
//using WindowsFormsApplication2.Properties;

namespace LGC.UI.DataBaseConfig
{
    public partial class Frm_ConfigDataBase : RadForm
    {
        public string chaineCrypte = "";
        public string mode = "f";
        public string modeCon = "S";
        public Frm_ConfigDataBase()
        {
            InitializeComponent();
            if (Application.OpenForms["Frm_Menu"] != null)
            {
                //this.ThemeName = Properties.Settings.Default.theme.Trim();
                RadMessageBox.ThemeName = "Office2010Blue";
            }
            else
            {
                if (Application.OpenForms["Frm_Menu"] != null)
                {
                    this.ThemeName = ((RadForm)Application.OpenForms["Frm_Menu"]).ThemeName;
                    RadMessageBox.ThemeName = "Office2010Blue";
                }
                else
                    this.ThemeName = "Office2010Blue"; RadMessageBox.ThemeName = "Office2010Blue";
            }
        }

        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }

        private void btn_Boursika_Click(object sender, EventArgs e)
        {
            try
            {
                using (Frm_Resaux frm = new Frm_Resaux())
                {
                    frm.ShowDialog();
                    switch (((RadButton)sender).Name)
                    {
                        case "btn_BaseProduction":
                            chaineCrypte = frm.serveur.Trim() + ";" + frm.bd.Trim() +
                                ";" + frm.util.Trim() + ";" + frm.mp.Trim() + ";" + frm.modeCon.Trim();
                            chaineCrypte = CurrentUser.EncryptString(chaineCrypte, "abc123deaoezdf77",
                                "abc123deaoezdf78");
                            if (frm.modeCon.Trim() == "S")
                            {
                                txt_BaseProduction.Text = @"Data Source=" + frm.serveur.Trim() +
                                    ";Initial Catalog=" + frm.bd.Trim() +
                                    ";Persist Security Info=True;User ID=" + frm.util.Trim() +
                                    ";Password=" + frm.mp.Trim() + "";
                            }
                            else
                            {
                                txt_BaseProduction.Text = @"Data Source=" + frm.serveur.Trim() +
                                    ";Initial Catalog=" + frm.bd.Trim() +
                                    ";Integrated Security=True";
                            }
                            Txt_ServeurProduction.Text = frm.serveur;
                            txt_userLogin.Text = frm.util.Trim();
                            txt_password.Text = frm.mp.Trim();
                            modeCon = frm.modeCon.Trim();
                            break;
                        case "btn_BaseTest":
                            txt_BaseTest.Text = @"Data Source=" + frm.serveur.Trim() +
                                ";Initial Catalog=" + frm.bd.Trim() +
                                ";Persist Security Info=True;User ID=" + frm.util.Trim() +
                                ";Password=" + frm.mp.Trim() + "";
                            txt_ServeurTest.Text = frm.serveur;
                            break;
                    }
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
            try
            {
                //if (txt_ServeurTest.Text.Trim() == Txt_ServeurProduction.Text.Trim())
                //{
                //    RadMessageBox.Show(this, "La base test ne doit pas être sur le même " +
                //        "serveur que la base production.", "Prospect",
                //        MessageBoxButtons.OK, RadMessageIcon.Info);
                //    return;
                //}
                //Properties.Settings.Default.chaineConnexionProduction = txt_BaseProduction.Text;
                //Properties.Settings.Default.chaineConnexionTest = txt_BaseTest.Text;
                //Properties.Settings.Default.nomServeurProduction = Txt_ServeurProduction.Text;
                //Properties.Settings.Default.nomServeurTest = txt_ServeurTest.Text;
                //Properties.Settings.Default.pwd = txt_password.Text;
                //Properties.Settings.Default.userLogin = txt_userLogin.Text;
                //Properties.Settings.Default.modeCon = modeCon;
                //Properties.Settings.Default.Save();

                //sauvegarde pour l'utilisation actuelle
                //CurrentUser.ChaineConnexionServeur = Properties.Settings.Default.chaineConnexionProduction;
                //CurrentUser.ChaineConnexionTest = Properties.Settings.Default.chaineConnexionTest;
                CurrentUser.NomServeurProduction = Txt_ServeurProduction.Text;
                //CurrentUser.NomServeurTest = Properties.Settings.Default.nomServeurTest;
                //CurrentUser.EstProduction = Properties.Settings.Default.modeProduction;
                //CurrentUser.NomBaseComptabilite = Properties.Settings.Default.nomBaseCompta;
                //CurrentUser.NomBasePersonne = Properties.Settings.Default.nomBasePersonne;
                //CurrentUser.NomBaseTitres = Properties.Settings.Default.nomBaseTitres;
                CurrentUser.Pwd = txt_password.Text;
                CurrentUser.NomUtilisateur = txt_userLogin.Text;
                CurrentUser.ModeCon = modeCon;

                using (StreamWriter sw = new StreamWriter(CurrentUser.AppPath + "/strc.csv", false, Encoding.Default))
                {
                    sw.Write(chaineCrypte);
                    sw.Flush();
                    sw.Close();
                }

                //if (mode == "c")
                //{
                //    RadMessageBox.Show(this, "Paramétrages effectués avec succès.", CurrentUser.LogicielHote,
                //        MessageBoxButtons.OK, RadMessageIcon.Info);

                //}
                //else
                {
                    RadMessageBox.Show(this, "Paramétrages effectués avec succès." +
                        " L'application va redémarer.", CurrentUser.LogicielHote,
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                    //Program.estRestart = true;
                    Application.Restart();
                    
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, CurrentUser.MessageErreur, CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            StreamReader sr = null;
            string line;
            string[] recuperationT;

            sr = new StreamReader(CurrentUser.AppPath + "/strc.csv");
            line = sr.ReadLine();
            chaineCrypte = line;
            line = CurrentUser.DecryptString(line, "abc123deaoezdf77", "abc123deaoezdf78");
            recuperationT = line.Split(';');
            sr.Close();

            Txt_ServeurProduction.Text = recuperationT[0].Trim();
            txt_password.Text = recuperationT[3].Trim();
            txt_userLogin.Text = recuperationT[2].Trim();
            modeCon = recuperationT[4].Trim();

           
          
        }
    }
}
