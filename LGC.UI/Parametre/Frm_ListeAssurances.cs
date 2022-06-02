using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LGC.Business.Parametre;

namespace LGG.UI.Parametre
{
    public partial class Frm_ListeAssurances : Telerik.WinControls.UI.RadForm
    {
       public  Assurance oAssurance = new Assurance();

        public Frm_ListeAssurances()
        {
            InitializeComponent();
        }

        private void Frm_ListeAssurances_Load(object sender, EventArgs e)
        {
            bds_Assurances.DataSource = Assurance.Liste(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,null,null,null,null,null, false, null);
        }

        private void gv_Liste_DoubleClick(object sender, EventArgs e)
        {
            oAssurance = ((Assurance)bds_Assurances.Current) != null ? ((Assurance)bds_Assurances.Current) : null;
            Close();
        }
    }
}
