using LGC.Business.GestionDesAnalyses;
using LGC.Business.Parametre;
using LGG.UI.Parametre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace LGC.UI.GestionDesAnalyses
{
    public partial class Frm_RecalculDemande : Telerik.WinControls.UI.RadForm
    {
        List<DemandeAnalyse> olstDemandeAnalyse = new List<DemandeAnalyse>();
        public List<DemandeAnalyse> lstDemandeAnalyse = new List<DemandeAnalyse>();
        public Partenaires oPartenaires = new Partenaires();

        public Frm_RecalculDemande(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }

        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            bds_Demandes.DataSource = new List<DemandeAnalyse>();
            olstDemandeAnalyse = DemandeAnalyse.Liste(meb_DateDebut.Value, meb_DateFin.Value);
            bds_Demandes.DataSource = olstDemandeAnalyse.FindAll(x => x.IdPersonnePartenaire == oPartenaires.IdPersonne && x.EstAnnulee == false);
        }

        private void btn_ChoixPartenaire_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_ListePartenaire frm = new Frm_ListePartenaire(false);
                frm.ShowDialog();
                oPartenaires = frm.oPartenaires;
                txt_Partenaire.Text = oPartenaires.NomSigle + " " + oPartenaires.PrenomRaisonSociale;
            }
            catch { }
        }

        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                bds_AnalyseDemande.DataSource = new List<AnalyseDemande>();
                if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count > 0)
                {
                    bds_AnalyseDemande.DataSource = AnalyseDemande.Liste(null, ((DemandeAnalyse)bds_Demandes.Current).NumDemande, null, null,
                        null, null, null, null, null, null, false, null, null);
                }
            }
            catch { }
        }

        private void btn_Recalculer_Click(object sender, EventArgs e)
        {
            string numDemande = "";

            if (txt_Partenaire.Text.Trim() == string.Empty)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez obligatoirement sélectionner un partenaire", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

            if (Convert.ToDecimal(gv_Liste.SelectedRows[0].Cells["MontantDemande"].Value) != Convert.ToDecimal(gv_Liste.SelectedRows[0].Cells["Reste"].Value))
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Cette demande a déja fait l'objte d'un règlement", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            for(int i=0;i<gv_Liste.RowCount;i++)
            {
                if (Convert.ToBoolean(gv_Liste.Rows[i].Cells["chk"].Value) == true)
                {
                    if (Convert.ToString(gv_Liste.Rows[i].Cells["Reference"].Value) != string.Empty)
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, "la demande N° " + Convert.ToString(gv_Liste.Rows[i].Cells["NumDemande"].Value) + " a déjé été normalisée", "GESLAB",
                        MessageBoxButtons.OK, RadMessageIcon.Error);
                        return;
                    }
                    numDemande += Convert.ToString(gv_Liste.Rows[i].Cells["NumDemande"].Value) + ";";
                }
            }

            if(numDemande.Trim()!=string.Empty)
            {
                DemandeAnalyse.RecalculDemande(numDemande);
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Recalcul terminé", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Info);
                btn_Actualiser_Click(null, null);

            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez obligatoirement sélectionner une demande", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void chk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gv_Liste.RowCount; i++)
            {
                gv_Liste.Rows[i].Cells["chk"].Value = !chk.Checked;
            }
        }
    }
}
