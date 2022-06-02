using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
//using LGG.Business.Dce;
//using LGG.Business;
//using BS.Business;
using Telerik.WinControls;
//using LGG.Business.GestionDesUtilisateurs;
//using LGG.UI.Etats;
using LGG.UI.GestionUtilisateur;
using LGG.Business.GestionUtilisateur;
using LGG.Business;
using LGG.Business.Parametre;

namespace LGG.UI.GestionUtilisateur
{
    public partial class Frm_Reglage : Telerik.WinControls.UI.RadForm
    {
        bool isMouseDown = false;
        Point mousePosition;
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }

        public Frm_Reglage(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }

        private void Cmd_Enregistrer_Click(object sender, EventArgs e)
        {
            if (cb_theme.Text.Trim() == "")
            {
                RadMessageBox.Show(this, "Veuillez sélectionner un thème",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                cb_theme.Focus();
            }
            else if (cb_minute.Text.Trim() =="")
            {
                RadMessageBox.Show(this, "Veuillez renseigner tout les champs",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                cb_minute.Focus();
            }
            else
            {
                Reglage obj = new Reglage();
                obj.ThemeName = cb_theme.Text;
                obj.RappelVocal = true;
                if (cb_minute.Text == "Ne pas verrouiller")
                { 
                     obj.MinuteVerrouAuto = 0;
                }
               if (cb_minute.Text == "5minutes d'inativité") 
                {
                    obj.MinuteVerrouAuto = 5;
                }
                 if (cb_minute.Text == "10minutes d'inativité") 
                {
                    obj.MinuteVerrouAuto = 10;
                }
                 if (cb_minute.Text == "15minutes d'inativité") 
                {
                    obj.MinuteVerrouAuto = 15;
                }
                 if (cb_minute.Text == "20minutes d'inativité") 
                {
                    obj.MinuteVerrouAuto = 20;
                }
                 if (cb_minute.Text == "30minutes d'inativité") 
                {
                    obj.MinuteVerrouAuto = 30;
                }
                 if (cb_minute.Text == "40minutes d'inativité") 
                {
                    obj.MinuteVerrouAuto = 40;
                }
                if (cb_minute.Text == "50minutes d'inativité") 
                {
                    obj.MinuteVerrouAuto = 50;
                }
                   if (cb_minute.Text == "60minutes d'inativité") 
                {
                    obj.MinuteVerrouAuto = 60;
                }
                   obj.UserLogin = Convert.ToString(CurrentUser.OUtilisateur.NumLigne);
                
                string mRetour = obj.Update();
                string[] mMessage = Tools.SplitMessage(mRetour);
                if (mMessage[mMessage.Length - 1].Trim() != "")
                {
                    RadMessageBox.Show(this, mMessage[3].Trim(),
                        CurrentUser.LogicielHote, MessageBoxButtons.OK,
                        RadMessageIcon.Info);
                    Frm_Menu frm = new Frm_Menu();
                    frm.ActiverReglage();
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
        

        private void Frm_Reglage_Load(object sender, EventArgs e)
        {
            cb_theme.Items.Add(ThemeSource.StorageTypeProperty.FullName);
        }

        private void radToggleSwitch1_MouseDown(object sender, MouseEventArgs e)
        {
            this.isMouseDown = true;
            this.mousePosition = Control.MousePosition;
        }

        private void radToggleSwitch1_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            int initialX = this.mousePosition.X;
            int currentX = Control.MousePosition.X;
            int dragOffset = SystemInformation.DragSize.Width;
            if (currentX >= initialX - dragOffset &&
                currentX <= initialX + dragOffset)
            {
                e.Cancel = true;
            }

            this.isMouseDown = false;
            this.mousePosition = Point.Empty;
        }

        private void Frm_Reglage_FormClosed(object sender, FormClosedEventArgs e)
        {

            Frm_Menu frm = new Frm_Menu();
            frm.ActiverReglage();
        }

        private void cb_theme_TextChanged(object sender, EventArgs e)
        {
            if (cb_theme.Text.Trim() == "")
            {
                Frm_Menu frm = new Frm_Menu();
                frm.ActiverReglage();
            }
            else
            {
                ThemeResolutionService.ApplicationThemeName = cb_theme.Text.Trim();
            }
            
        }
    }
}
