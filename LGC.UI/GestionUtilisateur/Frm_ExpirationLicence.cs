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
    public partial class Frm_ExpirationLicence : Telerik.WinControls.UI.RadForm
    {
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(
                this, this.ThemeName);
        }

        public bool connexion = false;
        public Frm_ExpirationLicence()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            connexion = true;
            this.Close();
        }
    }
}
