using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LGC.Business;
using LGC.Business.Parametre;
using LGC.UI.Parametre;

namespace LGG.UI.Parametre
{
    public partial class Frm_ListePatient : Telerik.WinControls.UI.RadForm
    {
        public Patient oPatient = new Patient();

        public Frm_ListePatient()
        {
            InitializeComponent();
        }

        private void Frm_ListePartenaire_Load(object sender, EventArgs e)
        {
            bds_Patient.DataSource = Patient.Liste(null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, false, null);
        }

        private void gv_Liste_DoubleClick(object sender, EventArgs e)
        {
            oPatient = ((Patient)bds_Patient.Current) != null ? ((Patient)bds_Patient.Current) : null;
            Close();
        }

        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            Frm_Personne frm = new Frm_Personne();

            frm.pv_titres.SelectedPage = frm.pvp_Patient;
            frm.libelleTypePersonne = frm.pvp_Patient.Text.Trim();
            frm.estailleurs = true;
            frm.ShowDialog();

            bds_Patient.DataSource = Patient.Liste(null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, false, null);

            if (oPatient != null)
            {
                int i = 0;
                foreach (Patient ligne in bds_Patient.List as List<Patient>)
                {
                    if (ligne.NumLigne == oPatient.NumLigne)
                    {
                        bds_Patient.Position = i;
                        gv_Liste_DoubleClick(null, null);
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
    }
}
