using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using LGC.Business.GestionUtilisateur;
//using LGC.UI.Etats;

namespace LGC.UI.GestionUtilisateur
{
    public partial class Frm_JournalConnexionParUtilisateur : Telerik.WinControls.UI.RadForm
    {
        #region declaration

        private RadMenu rmi_Menu;
        private RadMenu rmi_Menu2;
        private RadMenu rmi_Menu3;

        #endregion

        #region autres et formulaire

        public Frm_JournalConnexionParUtilisateur(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }
     
        private void Frm_JournalConnexionParUtilisateur_Load(object sender, EventArgs e)
        {

            dtp_DateDeb.Value = DateTime.Now;
            dtp_DateFin.Value = DateTime.Now;
        }

        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }
        private void dgv_ListeUtil_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeUtil.SelectedRows != null &&
                dgv_ListeUtil.SelectedRows.Count > 0)
            {
                bds_JournalConnexion.DataSource = JournalConnexion.Liste(null,((JournalConnexion)bds_listeUtilisateur.Current).NumeroUtilisateur,
                    null, null, null, 
                    dtp_DateDeb.Value, dtp_DateFin.Value,
                null, null, null, null, null, null, null, false, null);
                
            }
        }

        #endregion

        #region bouton impression

        private void btn_imprimer_Click(object sender, EventArgs e)
        {
            //TR_JournalConnexionParUtilisateur rpt = new TR_JournalConnexionParUtilisateur();
            //rpt.DataSource = JournalConnexion.Liste(null, 
            //    ((JournalConnexion)bds_listeUtilisateur.Current).NumeroUtilisateur,
            //         null, null, null,dtp_DateDeb.Value, dtp_DateFin.Value, null,
            //         null, null, null, null, null, null, false, null);

            //Frm_ReportViewer frm = new Frm_ReportViewer("POINT DES CONNEXIONS DES UTILISATEURS", 
            //    rpt);          
            //frm.Show();
        }

        private void btn_imprimerTout_Click(object sender, EventArgs e)
        {
            //TR_JournalConnexionParUtilisateur rpt = new TR_JournalConnexionParUtilisateur();
            //rpt.DataSource = JournalConnexion.Liste(null, null, null, null, null,
            //        dtp_DateDeb.Value, dtp_DateFin.Value, null, null, null, null,
            //        null, null, null, false, null);

            //Frm_ReportViewer frm = new Frm_ReportViewer("POINT DES CONNEXIONS DES UTILISATEURS",
            //    rpt);
            //frm.Show();
        }


        #endregion

        #region bouton afficher

        private void btn_Afficher_Click(object sender, EventArgs e)
        {
            bds_listeUtilisateur.DataSource=JournalConnexion.ListeUtilisateur(dtp_DateDeb.Value, dtp_DateFin.Value);
        }

        #endregion

        #region dateTime Picker

        private void dtp_DateDeb_ValueChanged(object sender, EventArgs e)
        {
            bds_JournalConnexion.DataSource = new List<JournalConnexion>();
            bds_listeUtilisateur.DataSource = new List<JournalConnexion>();
        }

        #endregion
    }
}
