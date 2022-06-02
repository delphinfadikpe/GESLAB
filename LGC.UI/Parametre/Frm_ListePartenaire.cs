using LGC.Business.Parametre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace LGG.UI.Parametre
{
    public partial class Frm_ListePartenaire : Telerik.WinControls.UI.RadForm
    {
        public Partenaires oPartenaires = new Partenaires();
        public bool estAutrePartenaire = false;

        public Frm_ListePartenaire(bool mEstAutrePartenaire)
        {
            InitializeComponent();
            estAutrePartenaire = mEstAutrePartenaire;
        }

        private void gv_Liste_DoubleClick(object sender, EventArgs e)
        {
            oPartenaires = ((Partenaires)bds_Partenaires.Current) != null ? ((Partenaires)bds_Partenaires.Current) : null;
            Close();
        }

        private void Frm_ListePartenaire_Load(object sender, EventArgs e)
        {
            bds_Partenaires.DataSource = estAutrePartenaire == true ? Partenaires.ListePartenairesAll().FindAll(x => x.IdPersonnePrincipal != 0) : Partenaires.ListePartenairesAll();
        }
    }
}
