using LGC.Business;
using LGC.Business.Impressions;
using LGC.UI;
using LGO.UI.Crystal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace LGO.UI.Impressions
{
    public partial class Frm_PointPeriodique : Telerik.WinControls.UI.RadForm
    {
        #region Declaration
        DataTable dt;
        string typePoint = "";
        
        #endregion

        #region Autres

       
        #endregion
        
        #region Formulaire
        public Frm_PointPeriodique()
        {
            InitializeComponent();
            
        }

        private void Frm_GenerationSouscription_Load(object sender, EventArgs e)
        {
            txt_DateFermeture.Value =DateTime.Now;
            txt_DateOuverture.Value = DateTime.Now;
        } 
        #endregion

        private void btn_Generer_Click(object sender, EventArgs e)
        {
            DateTime dateDebut = txt_DateOuverture.Value.Date.AddHours(Convert.ToDouble(se_heure.Value)).AddMinutes(Convert.ToDouble(se_minute.Value));
            DateTime dateFin = txt_DateFermeture.Value.Date.AddHours(Convert.ToDouble(se_heure1.Value)).AddMinutes(Convert.ToDouble(se_minute1.Value));
            dt = Rapport.PointPeriodique(dateDebut, dateFin, typePoint);
            gv_Liste.DataSource = dt;
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            if (rchk_Afficher.Checked == true)
            {
                TR_PointPeriodique rpt = new TR_PointPeriodique();
                rpt.objectDataSource1.DataSource = dt;
                rpt.DataSource = rpt.objectDataSource1;
                rpt.txt_Fermeture.Value = txt_DateOuverture.Value.Date.ToShortDateString();
                rpt.txt_DateOuverture.Value = txt_DateOuverture.Value.Date.ToShortDateString();
                rpt.txt_heureMinute.Value = "de " + se_heure.Value + " h : " + se_minute.Value + "min à " + se_heure1.Value + " h : " + se_minute1.Value + " min";
                rpt.ReportParameters["user"].Value = CurrentUser.OUtilisateur.NomUtilisateur + " " + CurrentUser.OUtilisateur.PrenomUtilisateur;
                Frm_ReportViewer frm = new Frm_ReportViewer(rpt.txt_titre.Value, rpt);
                frm.ShowDialog();
            }
            else
            {
                TR_PointPeriodiqueSansAnalyse rpt = new TR_PointPeriodiqueSansAnalyse();
                rpt.objectDataSource1.DataSource = dt;
                rpt.DataSource = rpt.objectDataSource1;
                rpt.txt_Fermeture.Value = txt_DateFermeture.Value.Date.ToShortDateString();
                rpt.txt_DateOuverture.Value = txt_DateOuverture.Value.Date.ToShortDateString();
                rpt.txt_heureMinute.Value = "de " + se_heure.Value + " h : " + se_minute.Value + "min à " + se_heure1.Value + " h : " + se_minute1.Value + " min";
                rpt.ReportParameters["user"].Value = CurrentUser.OUtilisateur.NomUtilisateur + " " + CurrentUser.OUtilisateur.PrenomUtilisateur;
                Frm_ReportViewer frm = new Frm_ReportViewer(rpt.txt_titre.Value, rpt);
                frm.ShowDialog();
            }
        }

        private void rddl_TypeOp_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            typePoint = rddl_TypeOp.Text.Trim();
            gv_Liste.DataSource = null;
            if(typePoint=="JOURNALIER")
            {
                txt_DateFermeture.Enabled = false;
                se_heure.Enabled = true;
                se_minute.Enabled = true;
                se_heure1.Enabled = true;
                se_minute1.Enabled = true;
                txt_DateFermeture.Value = txt_DateOuverture.Value;
            }
            else
            {
                txt_DateFermeture.Enabled = true;
                se_heure.Enabled = false;
                se_minute.Enabled = false;
                se_heure1.Enabled = false;
                se_minute1.Enabled = false;
            }
        }

        private void txt_DateOuverture_ValueChanged(object sender, EventArgs e)
        {
            if (typePoint == "JOURNALIER")
            {
               
                txt_DateFermeture.Value = txt_DateOuverture.Value;
            }
           
        }

       

        

        #region Boutons de commande
       
        #endregion

       
    }
}
