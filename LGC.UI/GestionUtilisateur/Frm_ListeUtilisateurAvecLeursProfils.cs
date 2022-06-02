using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using LGO.Business.GestionUtilisateur;
//using LGO.UI.Etats;

namespace LGO.UI.GestionUtilisateur
{
    public partial class Frm_ListeUtilisateurAvecLeursProfils : Telerik.WinControls.UI.RadForm
    {
        #region declaration

        List<Utilisateur> lstUtilisateur = new List<Utilisateur>();
        private RadMenu rmi_Menu;
        private RadMenu rmi_Menu2;
        private RadMenu rmi_Menu3;

        #endregion

        #region autres et formulaire
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(
                this, this.ThemeName);
        }
        public Frm_ListeUtilisateurAvecLeursProfils(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }

        private void ChargerListe(Utilisateur obj)
        {
            lstUtilisateur = Utilisateur.Liste(null, null, null, null,
                null, null, null, null, null, null, null,null,
                null, null, null, null, null, false, null);
            bds_listeUtilisateur.DataSource = lstUtilisateur;
            if (obj != null)
            {
                int i = 0;
                foreach (Utilisateur ligne in bds_listeUtilisateur.List as List<Utilisateur>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_listeUtilisateur.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        private void Frm_ListeUtilisateurAvecLeursProfils_Load(object sender, EventArgs e)
        {
            ChargerListe(null);
        }

        private void dgv_ListeUtil_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeUtil.SelectedRows != null &&
                dgv_ListeUtil.SelectedRows.Count > 0)
            {
                bds_ProfilsParUtlisateur.DataSource = UtilisateurProfil.Liste(((Utilisateur)bds_listeUtilisateur.Current).NumeroUtilisateur, null, null, null, null, 
                    null, null, false, null);
                
            }
        }

        #endregion

        #region bouton impression

        private void btn_imprimer_Click(object sender, EventArgs e)
        {
            //TR_ListeUtilisateursAvecLeursProfil rpt = new TR_ListeUtilisateursAvecLeursProfil();
            //rpt.DataSource = UtilisateurProfil.Liste(((Utilisateur)bds_listeUtilisateur.Current).NumeroUtilisateur, null, null, null,
            //    null, null, null, false, null);

            //Frm_ReportViewer frm = new Frm_ReportViewer(
            //    "liste des Utilisateurs avec leurs Profils", rpt);          
            //frm.Show();
        }

        private void btn_imprimerTout_Click(object sender, EventArgs e)
        {
            //TR_ListeUtilisateursAvecLeursProfil rpt = new TR_ListeUtilisateursAvecLeursProfil();
            //rpt.DataSource = UtilisateurProfil.Liste(null, null, null, null,
            //    null, null, null, false, null);

            //Frm_ReportViewer frm = new Frm_ReportViewer(
            //    "liste des Utilisateurs avec leurs Profils", rpt);
            //frm.Show();
        }


        #endregion
    }
}
