using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LGC.Business.GestionUtilisateur;
using LGC.Business;

namespace LGC.UI.GestionUtilisateur
{
    public partial class Frm_Securite : Telerik.WinControls.UI.RadForm
    {
        #region Declaration
        List<Securite> lstSecurite = new List<Securite>();
        string sortie;
        string[] message;
        #endregion

        #region autres
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(
                this, this.ThemeName);
        } 
        #endregion

        #region Formulaire
        public Frm_Securite(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }

        private void Frm_Securite_Load(object sender, EventArgs e)
        {
            this.Size=new System.Drawing.Size(419, 149);
            lstSecurite = Securite.Liste(null, null, null, null,
                null, null, false, null);
            if (lstSecurite != null &&
                lstSecurite.Count != 0)
            {
                try
                {
                    meb_ancienneDate.Value = Convert.ToDateTime(
                                Tools.DecryptString(lstSecurite[0].Str,
                                "abc123deaoezdf77", "abc123deaoezdf78"));
                }
                catch
                {
                    meb_ancienneDate.Value = DateTime.Now;
                }
            }
            else
            {
                meb_ancienneDate.Value = DateTime.Now;
            }
            me_nbMois.Value = 3;
        } 
        #endregion

        #region MaskedEditBox
        private void me_nbMois_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtp_NouvelleDate.Value = Convert.ToDateTime(meb_ancienneDate.Value).AddMonths(
                        Convert.ToInt32(me_nbMois.Value));
            }
            catch 
            {
            }
        } 
        #endregion

        #region Bouton de commande
        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            if (lstSecurite != null &&
                lstSecurite.Count != 0)
            {
                lstSecurite[0].Str = Tools.EncryptString(
                    dtp_NouvelleDate.Value.ToShortDateString(), 
                    "abc123deaoezdf77", "abc123deaoezdf78");
                sortie = lstSecurite[0].Update();
                 message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    Frm_Securite_Load(null, null);
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() :
                    message[3].Trim()
                , CurrentUser.LogicielHote, MessageBoxButtons.OK,
                message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info :
                RadMessageIcon.Error);
            }
            else
            {
                Securite obj = new Securite();
                obj.Str = Tools.EncryptString(
                    dtp_NouvelleDate.Value.ToShortDateString(),
                    "abc123deaoezdf77", "abc123deaoezdf78");
                sortie = obj.Insert();
                 message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    Frm_Securite_Load(null, null);
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() :
                    message[3].Trim()
                , CurrentUser.LogicielHote, MessageBoxButtons.OK,
                message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info :
                RadMessageIcon.Error);
            }
        } 
        #endregion
    }
}
