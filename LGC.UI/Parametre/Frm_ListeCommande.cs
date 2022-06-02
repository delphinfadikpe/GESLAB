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
using LGC.Business.GestionDeStock;

namespace LGG.UI.Parametre
{
    public partial class Frm_ListeCommande : Telerik.WinControls.UI.RadForm
    {
        public Fournisseur oFournisseur = new Fournisseur();
        public string numCommande = "";
        public decimal total = 0;

        public Frm_ListeCommande()
        {
            InitializeComponent();
        }

        public Frm_ListeCommande(Fournisseur mFournisseur)
        {
            InitializeComponent();
            oFournisseur = mFournisseur;
        }

        private void Frm_ListePartenaire_Load(object sender, EventArgs e)
        {
            bds_Commande.DataSource = CommandeIntrant.Liste(null,oFournisseur.IdPersonne, null, null, null, null, null, null, null, null, null, null,
                null, null, null,  false, null);
            bds_CommandeIntrant.DataSource = IntrantCommander.Liste(null, null, null,
                    null, null,null, null, null, null, null, null, null, null, false, null);
        }

        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            
                
        }

        private void btn_Inserer_Click(object sender, EventArgs e)
        {
            for(int i=0;i<gv_Liste.RowCount;i++)
            {
                if (Convert.ToBoolean(gv_Liste.Rows[i].Cells["chk"].Value) == true)
                {
                    numCommande += Convert.ToString(gv_Liste.Rows[i].Cells["NumCommande"].Value) + ";";
                    total += Convert.ToDecimal(gv_Liste.Rows[i].Cells["MontantGlobale"].Value);
                }
                
            }
            numCommande = numCommande.Remove(numCommande.Length - 1);
            Close();
        }

        

        
    }
}
