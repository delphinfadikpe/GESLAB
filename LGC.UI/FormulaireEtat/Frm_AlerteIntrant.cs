using LGC.Business;
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
    public partial class Frm_AlerteIntrant : Telerik.WinControls.UI.RadForm
    {
        List<Intrants> lstIntrants = new List<Intrants>();
        string formSource;
        public Frm_AlerteIntrant(string pFormSource)
        {
            InitializeComponent();
            this.formSource = pFormSource;
        }

        private void Frm_StockIntrant_Load(object sender, EventArgs e)
        {
            btn_Actualiser_Click(null, null);
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            
                lstIntrants = Intrants.Liste(null, null, null, null, null, null, null, null, null, null, null, null, false, null, null);
                
                if (formSource.Trim().ToUpper() == "SECURITE")
                {
                    bds_Intrants.DataSource = lstIntrants.FindAll(x => x.StockDisponible <= x.StockSecurite &&
                        x.StockDisponible > x.SeuilCritique);
                }
                else if (formSource.Trim().ToUpper() == "CRITIQUE")
                {
                    bds_Intrants.DataSource = lstIntrants.FindAll(x => x.StockDisponible <= x.SeuilCritique);
                }
            
        }

        private void chk_estTout_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

        }

        private void chk_estTout_ToggleStateChanging(object sender, Telerik.WinControls.UI.StateChangingEventArgs args)
        {
            if (chk_estTout.Checked == false)
            {
                for (int i = 0; i < gv_Liste.RowCount; i++)
                {
                    gv_Liste.Rows[i].Cells["chk"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < gv_Liste.RowCount; i++)
                {
                    gv_Liste.Rows[i].Cells["chk"].Value = false;
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (gv_Liste.RowCount > 0)
            {
                int nb = 0;
                for (int i = 0; i < gv_Liste.RowCount; i++)
                {
                    if (Convert.ToBoolean(gv_Liste.Rows[i].Cells["chk"].Value) == true)
                    {
                        nb++;
                        bds_Intrants.Position = i;
                        Intrants obj = (Intrants)bds_Intrants.Current;
                        if (obj != null)
                        {
                            obj.EstArreteAlerte = true;
                            obj.Update();
                        }
                    }
                }
                if (nb != 0)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, nb + " Alerte bloqué", CurrentUser.LogicielHote,
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Aucune ligne cochée.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK,
                        RadMessageIcon.Error);
                }
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La grille est vide.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK,
                    RadMessageIcon.Error);
            }
        }
    }
}
