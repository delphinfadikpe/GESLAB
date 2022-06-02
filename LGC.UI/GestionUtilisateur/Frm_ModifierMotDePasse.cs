using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
//using LGC.Business.Dce;
//using LGC.Business;
//using BS.Business;
using Telerik.WinControls;
//using LGC.Business.GestionDesUtilisateurs;
//using LGC.UI.Etats;
using LGC.UI.GestionUtilisateur;
using LGC.Business.GestionUtilisateur;
using LGC.Business;

namespace LGC.UI.GestionUtilisateur
{
    public partial class Frm_ModifierMotDePasse : Telerik.WinControls.UI.RadForm
    {
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }

        public Frm_ModifierMotDePasse(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }

        private void Cmd_Enregistrer_Click(object sender, EventArgs e)
        {
            if (Tools.HashWithMD5( txt_ancienMotPasse.Text.Trim()) != 
                CurrentUser.OUtilisateur.Password.Trim())
            {
                RadMessageBox.Show(this,"Veuillez entrer l'ancien mot de passe correcte",
                    CurrentUser.LogicielHote,MessageBoxButtons.OK,RadMessageIcon.Error);
                txt_ancienMotPasse.Focus();
            }
            else if (txt_nouveauMotdePasse.Text.Trim() != txt_confirmation.Text.Trim())
            {
                RadMessageBox.Show(this, "Veuillez entrer le même mot de passe au niveau "+
                    "des deux derniers champs.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_confirmation.Focus();
            }
            else
            {
                CurrentUser.OUtilisateur.Password = 
                    Tools.HashWithMD5( txt_confirmation.Text.Trim());
                string mRetour = CurrentUser.OUtilisateur.Update();
                string[] mMessage = LGC.Business.Tools.SplitMessage(mRetour);
                if (mMessage[mMessage.Length - 1].Trim() != "")
                {
                    RadMessageBox.Show(this, mMessage[3].Trim(),
                        CurrentUser.LogicielHote, MessageBoxButtons.OK,
                        RadMessageIcon.Info);
                    this.Close();
                }
                else
                {
                    RadMessageBox.Show(this, 
                        mMessage[3].Trim() == "" ? mMessage[4].Trim() : mMessage[3].Trim(),
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
        }
    }
}
