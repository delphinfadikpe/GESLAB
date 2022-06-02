using LGC.Business.Parametre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace LGC.UI.FormulaireEtat
{
    public partial class Frm_StockIntrant : Telerik.WinControls.UI.RadForm
    {
        List<Intrants> lstIntrants = new List<Intrants>();
        public Frm_StockIntrant()
        {
            InitializeComponent();
        }

        private void Frm_StockIntrant_Load(object sender, EventArgs e)
        {
            btn_Actualiser_Click(null, null);
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            lstIntrants = Intrants.Liste(null, null,null, null, null, null, null, null, null, null, null, null, false, null, null);
            bds_Intrants.DataSource = lstIntrants;
        }
    }
}
