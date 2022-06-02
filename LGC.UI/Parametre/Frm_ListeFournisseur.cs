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
    public partial class Frm_ListeFournisseur : Telerik.WinControls.UI.RadForm
    {
        public Fournisseur oFournisseur = new Fournisseur();

        public Frm_ListeFournisseur()
        {
            InitializeComponent();
        }

        private void Frm_ListePartenaire_Load(object sender, EventArgs e)
        {
            bds_Fournisseur.DataSource = Fournisseur.Liste(null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, false, null);
        }

        private void gv_Liste_DoubleClick(object sender, EventArgs e)
        {
            oFournisseur = ((Fournisseur)bds_Fournisseur.Current) != null ? ((Fournisseur)bds_Fournisseur.Current) : null;
            Close();
        }

        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            //Frm_Personne frm = new Frm_Personne();
            //frm.pv_titres.SelectedPage = frm.pvp_Patient;
            //frm.estailleurs = true;
            //frm.ShowDialog();

            //bds_Fournisseur.DataSource = Patient.Liste(null, null, null, null, null, null, null, null, null, null, null, null,
            //   null, null, null, null, null, null, null, null, null, null, false, null);

            //if (oFournisseur != null)
            //{
            //    int i = 0;
            //    foreach (Patient ligne in bds_Fournisseur.List as List<Patient>)
            //    {
            //        if (ligne.NumLigne == oPatient.NumLigne)
            //        {
            //            bds_Fournisseur.Position = i;
            //            gv_Liste_DoubleClick(null, null);
            //            break;
            //        }
            //        else
            //        {
            //            i++;
            //        }
            //    }
            //}
        }
    }
}
