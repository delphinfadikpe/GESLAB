using LGC.Business;
using LGC.Business.GestionUtilisateur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace LGC.UI.GestionUtilisateur
{
    public partial class Frm_ConfigCheminProfil : Telerik.WinControls.UI.RadForm
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


        public Frm_ConfigCheminProfil(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }

        private void btn_ChoixChemin_Click(object sender, EventArgs e)
        {
            
                FolderBrowserDialog OpenFolder = new FolderBrowserDialog();
               
                if (OpenFolder.ShowDialog() == DialogResult.OK)
                {
                    cheminDossier = OpenFolder.SelectedPath;
                    txt_Chemin.Text = cheminDossier;
                    
                }
            
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
           ConfigurationUM obj = new ConfigurationUM ();
           #region controle de saisie
           
           if (txt_Chemin.Text.Trim() == "")
           {
               RadMessageBox.ThemeName = this.ThemeName;
               RadMessageBox.Show(this, "Le Chemin d'accès du Dossier Profil est Obligatoire.", "USER MANAGER", MessageBoxButtons.OK, RadMessageIcon.Error);
               txt_Chemin.Focus();
               return;
           }
           #endregion

           #region Enregistrement
         
           lstChemin = ConfigurationUM.Liste(null, null, null, null, null, null, false, null);

           if (lstChemin == null || lstChemin.Count == 0 )
           {
               obj.StrPath = txt_Chemin.Text;
               sortie = obj.Insert();
                message = LGC.Business.Tools.SplitMessage(sortie);
               Frm_ConfigCheminProfil_Load(null, null);
               CurrentUser.ImagePath = txt_Chemin.Text;
               if (message[message.Length - 1].Trim() != "")
               
               RadMessageBox.ThemeName = this.ThemeName;
               RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "USER MANAGER", MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
           }
           else
           {
               obj = lstChemin[0];
               obj.StrPath = txt_Chemin.Text;
               sortie = obj.Update();
               Frm_ConfigCheminProfil_Load(null, null);
               CurrentUser.ImagePath = txt_Chemin.Text;
                 message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "VISIT INVENTORY", MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }
           
           }
           #endregion

        private void Frm_ConfigCheminProfil_Load(object sender, EventArgs e)

        {
            lstChemin = ConfigurationUM.Liste(null, null, null, null, null, null, false, null);

            if (lstChemin != null &&  lstChemin.Count != 0)
                
            {
                txt_Chemin.Text = lstChemin[0].StrPath;
            }
            }
        }
    }

