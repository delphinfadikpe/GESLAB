using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LGC.Business.GestionDeLaCaisse;

namespace LGG.UI.Parametre
{
    public partial class Frm_ListeFacturePourRistourne : Telerik.WinControls.UI.RadForm
    {
        public FacturePartenaire oFacturePartenaire = new FacturePartenaire();
        decimal idPersonne = 0;

       public Frm_ListeFacturePourRistourne()
        {
            InitializeComponent();
        }

       public Frm_ListeFacturePourRistourne(decimal mIdPersonne)
       {
           InitializeComponent();
           idPersonne = mIdPersonne;
       }

        private void Frm_ListeAssurances_Load(object sender, EventArgs e)
        {
            bds_Facture.DataSource = FacturePartenaire.Liste(null, null, null, null, idPersonne, null, null, null, false, null, null, null, null, null, false, null);
        }

        private void gv_Liste_DoubleClick(object sender, EventArgs e)
        {
            oFacturePartenaire = ((FacturePartenaire)bds_Facture.Current) != null ? ((FacturePartenaire)bds_Facture.Current) : null;
            Close();
        }

        private void MasterTemplate_Click(object sender, EventArgs e)
        {

        }
    }
}
