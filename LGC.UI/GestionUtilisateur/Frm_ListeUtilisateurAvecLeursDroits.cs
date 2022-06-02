using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LGC.Business.GestionUtilisateur;
//using LGC.UI.Etats;
using Telerik.WinControls.UI;

namespace LGC.UI.GestionUtilisateur
{
    public partial class Frm_ListeUtilisateurAvecLeursDroits : Telerik.WinControls.UI.RadForm
    {
        #region declaration

        List<Utilisateur> lstUtilisateur = new List<Utilisateur>();
        private RadMenu rmi_Menu;
        private RadMenu rmi_Menu2;
        private RadMenu rmi_Menu3;

        #endregion

        #region autre et formulaire

        public Frm_ListeUtilisateurAvecLeursDroits(string theme)
        {
            InitializeComponent();

            this.ThemeName = theme;

        }

        private void ChargerListe(Utilisateur obj)
        {
            lstUtilisateur = Utilisateur.Liste(null, null, null, null,
                null, null, null, null, null, null, null,
                null, null, null, null,null, null, false, null);
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

        private void Frm_ListeUtilisateurAvecLeursDroits_Load(object sender, EventArgs e)
        {
            ChargerListe(null);
        }

        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }
        #endregion

        #region datagridView

        private void dgv_Listeutil_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeUtilisateur.SelectedRows != null &&
               dgv_ListeUtilisateur.SelectedRows.Count > 0)
            {
                bds_DroitsParUtlisateur.DataSource = ProfilDroit.DroitReelUtilisateur(((Utilisateur)bds_listeUtilisateur.Current).NumeroUtilisateur);

            }
        }

        #endregion datagridView

        #region bouton impression

        private void btn_imprimer_Click(object sender, EventArgs e)
        {
            //TR_ListeUtilisateursAvecLeursDroits rpt = new TR_ListeUtilisateursAvecLeursDroits();
            //rpt.DataSource = LGC.Business.GestionUtilisateur.Etats.Liste(((Utilisateur)bds_listeUtilisateur.Current).NumeroUtilisateur);

            //Frm_ReportViewer frm = new Frm_ReportViewer(
            //    "liste des Utilisateurs avec leurs Droits", rpt);
            //frm.Show();
        }

        private void btn_imprimerTout_Click(object sender, EventArgs e)
        {
            //TR_ListeUtilisateursAvecLeursDroits rpt = new TR_ListeUtilisateursAvecLeursDroits();
            //rpt.DataSource = LGC.Business.GestionUtilisateur.Etats.Liste(null);

            //Frm_ReportViewer frm = new Frm_ReportViewer(
            //    "liste des Utilisateurs avec leurs Droits", rpt);
            //frm.Show();
        }

        #endregion
    }
}
