using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LGC.Business.Parametre;
using LGC.Business;
using LGC.Business.GestionDesAnalyses;
using LGG.UI.Parametre;
using LGC.UI.Impressions;

namespace LGC.UI.GestionDesAnalyses
{
    public partial class Frm_PrelevementAnalyseDemande : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        string unite = "";
        int index;
        DataTable dt;
        string[] message;
        List<ResultatParametreAnalyse> lstResultatParametreAnalyse = new List<ResultatParametreAnalyse>();
        List<AnalyseDemande> lstInterpretation = new List<AnalyseDemande>();
        List<PrelevementAnalyseDemande> lstPrelevementAnalyseDemande = new List<PrelevementAnalyseDemande>();
        List<DemandeAnalyse> lstDemandeAnalyse = new List<DemandeAnalyse>();
        List<UniteMesure> lstUniteMesure = new List<UniteMesure>();
        Telerik.Reporting.Barcodes.PostnetEncoder PostnetEncoder = new Telerik.Reporting.Barcodes.PostnetEncoder();
        #endregion

        #region Autres
        private void activerDesactiverControle(bool condition)
        {
            dtp_dateOperation.ReadOnly = !condition;
            chk_estTout.ReadOnly = condition;
            dgv_ListePrelevement.AllowEditRow = condition;
            btn_Annuler.Visible = condition;
            btn_Enregistrer.Visible = condition;
            btn_Nouveau.Visible = !condition;
            btn_Modifier.Visible = !condition;
            btn_Supprimer.Enabled = !condition;
            btn_Actualiser.Enabled = !condition;
            btn_ImprimerCodeBarre.Enabled = !condition;
            btn_Transmettre.Enabled = !condition;
            
        }
        
        private void RAZ()
        {
           
            mcb_Demandes.Text = "";
            dtp_dateOperation.Value = DateTime.Now;
            bds_PrelevementAnalyseDemande.DataSource = new List<PrelevementAnalyseDemande>();
            //dt.Rows.Clear();
        }




        private void creerObjetPrelevementAnalyseDemande(PrelevementAnalyseDemande obj, int l)
        {
            obj.NumDemande = Convert.ToDecimal(mcb_Demandes.Text.Trim());
            obj.CodeAnalyse = dgv_ListePrelevement.Rows[l].Cells["CodeAnalyse"].Value.ToString();
            obj.CodePrelevement = dgv_ListePrelevement.Rows[l].Cells["CodePrelevement"].Value.ToString();
            obj.IdCodeBarPrelevement = nouveau == true ? 0 : obj.IdCodeBarPrelevement;
            obj.DatePrelevement = dtp_dateOperation.Value;
            obj.HeurePrelevement = DateTime.Now.ToLocalTime();
            obj.QtePrelevee = dgv_ListePrelevement.Rows[l].Cells["QtePrelevee"].Value == null ? 0 : 
                Convert.ToDecimal(dgv_ListePrelevement.Rows[l].Cells["QtePrelevee"].Value.ToString());
            obj.Tube = dgv_ListePrelevement.Rows[l].Cells["Tube"].Value == null ? "" : 
                dgv_ListePrelevement.Rows[l].Cells["Tube"].Value.ToString().Trim();
        }

        private void detaillerObjetPrelevementAnalyseDemande(PrelevementAnalyseDemande obj)
        {
           mcb_Demandes.Text = Convert.ToString(obj.NumDemande);
            dtp_dateOperation.Value = Convert.ToDateTime(obj.DatePrelevement);
           
        }
        
        private void ChargerListePrelevementAnalyse(decimal numDemande)
        {
            
            bds_PrelevementAnalyseDemande.DataSource = new List<PrelevementAnalyseDemande>();
            dt = PrelevementAnalyseDemande.PrelevementAnalyse(numDemande);
            bds_PrelevementAnalyseDemande.DataSource = dt;
            
        }

        private void ChargerListePrelevementDemande(PrelevementAnalyseDemande obj)
        {
            lstPrelevementAnalyseDemande = PrelevementAnalyseDemande.Liste(Convert.ToDecimal(mcb_Demandes.Text.Trim()), null, null, null, null,
                null, null, null, null, null, null, null,false,null,null);
            bds_PrelevementAnalyseDemande.DataSource = lstPrelevementAnalyseDemande;
            if (obj != null)
            {
                int i = 0;
                foreach (PrelevementAnalyseDemande ligne in bds_PrelevementAnalyseDemande.List as List<PrelevementAnalyseDemande>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_PrelevementAnalyseDemande.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        private void ChargerListeToutPrelevement()
        {
            lstPrelevementAnalyseDemande = PrelevementAnalyseDemande.Liste(null, null, null, null, null,
                null, null, null, null, null, null, null, false, null, null);
            bds_PrelevementAnalyseDemande.DataSource = lstPrelevementAnalyseDemande;
            
        }
        private void ChargerListeDemandesEnInstanceDePrelevement()
        {
            lstDemandeAnalyse = DemandeAnalyse.Liste(null, null, null, null,null,
                null, null, null, null, null, null, null, null, "DEMANDE SAISIE", null, null,null,null,null,null,null,null,null,null,false, null);
            bds_Demandes.DataSource = lstDemandeAnalyse;
        }

        private void ChargerListeToutesDemandes()
        {
            lstDemandeAnalyse = DemandeAnalyse.Liste(null, null, null, null, null,
                null, null, null, null, null, false, null, null,null, null, null, null, null, null, null, null, null, null, null,  false, null);
            bds_Demandes.DataSource = lstDemandeAnalyse;
        }
        #endregion
        
        #region Formulaire
        public Frm_PrelevementAnalyseDemande()
        {
            InitializeComponent();
        }

        private void Frm_ResultatDemande_Load(object sender, EventArgs e)
        {
            activerDesactiverControle(false);
            ChargerListeToutesDemandes();
            RAZ(); 
           if (nouveau)
                btn_Nouveau_Click(null, null);
        }
        #endregion

        #region bouton de commande
        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = true;
            activerDesactiverControle(true);
            RAZ();
            ChargerListeDemandesEnInstanceDePrelevement();
            mcb_Demandes.Focus();
        }
        

        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (dgv_ListePrelevement.RowCount > 0)
            {
                if (mcb_Demandes.Text.Trim() != "")
                {
                    DemandeAnalyse obj = lstDemandeAnalyse.Find(l => l.NumDemande == Convert.ToDecimal(mcb_Demandes.Text.Trim())
                  && (l.NiveauExecution.Trim() == "EDITION DE RESULTAT" || l.NiveauExecution.Trim() == "VALIDATION DE RESULTAT" ||
                  l.NiveauExecution.Trim() == "RESULTAT VALIDE"));

                    if (obj == null)
                    {
                        nouveau = false;
                        activerDesactiverControle(true);
                        mcb_Demandes.Enabled = false;
                        dtp_dateOperation.ReadOnly = true;
                        dgv_ListePrelevement.Focus();
                    }
                    else
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, "Vous ne pouvez plus modifier ce prélevement car la demande n'est plus cette étape.",
                            CurrentUser.LogicielHote, MessageBoxButtons.OK,
                            RadMessageIcon.Error);
                    }

                }
                else
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Veuillez sélectionner la demande d'abord.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK,
                        RadMessageIcon.Error);
                }
              
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La grille est vide", CurrentUser.LogicielHote, MessageBoxButtons.OK,
                    RadMessageIcon.Error);
            }
        }

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            //if (dgv_ListeResultat.SelectedRows != null &&
            //    dgv_ListeResultat.SelectedRows.Count > 0)
            //{
            //    RadMessageBox.ThemeName = this.ThemeName;
            //    if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne " +
            //        "sélectionnée", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
            //        RadMessageIcon.Question) == DialogResult.Yes)
            //    {
            //        ResultatDemande obj = (ResultatDemande)bds_Resultat.Current;
            //        string res = obj.Delete();
            //        message = LGC.Business.Tools.SplitMessage(res);
            //        if (int.Parse(message[0]) > 0)
            //        {
            //            ChargerListe((ResultatDemande)bds_Resultat.Current);
            //            RadMessageBox.ThemeName = this.ThemeName;
            //            RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
            //                MessageBoxButtons.OK, RadMessageIcon.Info);
            //        }
            //        else
            //        {
            //            RadMessageBox.ThemeName = this.ThemeName;
            //            MessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
            //                MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //else
            //{
            //    RadMessageBox.ThemeName = this.ThemeName;
            //    RadMessageBox.Show(this, "Veuillez sélectionner la ligne à supprimer.",
            //        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            //}
        }

        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            RAZ();
            activerDesactiverControle(false);
            mcb_Demandes.Enabled = true;
            ChargerListeToutesDemandes();
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            PrelevementAnalyseDemande obj = new PrelevementAnalyseDemande();
            int nbReussi = 0, nbEchec = 0;
            #region controle de saisie
            if (mcb_Demandes.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La sélection de la demande est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                mcb_Demandes.Focus();
                return;
            }
            for (int i = 0; i < dgv_ListePrelevement.RowCount; i++)
            {
                if (dgv_ListePrelevement.Rows[i].Cells["QtePrelevee"].Value == null ||
                    dgv_ListePrelevement.Rows[i].Cells["QtePrelevee"].Value.ToString().Trim() == string.Empty)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Il y a un moins un prélevement dont vous n'aviez pas renseigné sa quantité.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    dgv_ListePrelevement.Focus();
                    return;
                }

            }
           

            #endregion

            #region Enregistrement
            if (nouveau)
            {
                nbReussi = 0; nbEchec = 0;
                    
                    for (int i = 0; i < dgv_ListePrelevement.RowCount; i++)
                    {
                        creerObjetPrelevementAnalyseDemande(obj, i);
                        sortie = obj.Insert();
                        message = LGC.Business.Tools.SplitMessage(sortie);
                        if (message[message.Length - 1].Trim() != "")
                         {
                             nbReussi++;
                             
                         }
                        else
                        {
                            nbEchec++;
                        }
                    }

                    ChargerListePrelevementDemande(obj);
                    activerDesactiverControle(false);
                    nouveau = false;
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, nbEchec != 0 ? nbReussi + " Prélevement(s) enrégistré(s) avec succès /n" +
                    "Et " + nbEchec + "Echec" : nbReussi + " Prélevement(s) enrégistré(s) avec succès" , CurrentUser.LogicielHote,
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                
            }
            #endregion

            #region Modification
            else
            {
                nbReussi = 0; nbEchec = 0;
                    for (int i = 0; i < dgv_ListePrelevement.RowCount; i++)
                    {
                        bds_PrelevementAnalyseDemande.Position = i;
                        obj = (PrelevementAnalyseDemande)bds_PrelevementAnalyseDemande.Current;
                        creerObjetPrelevementAnalyseDemande(obj, i);
                        sortie = obj.Update();
                        message = LGC.Business.Tools.SplitMessage(sortie);
                        if (message[message.Length - 1].Trim() != "")
                        {
                            nbReussi++;
                           
                        }
                        else
                        {
                            nbEchec++;
                        }
                    }
                    activerDesactiverControle(false);
                    mcb_Demandes.Enabled = true;
                    nouveau = false;
                    ChargerListePrelevementDemande(obj);
                    RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, nbEchec != 0 ? nbReussi + " Prélevement(s) modifié(s) avec succès /n" +
                    "Et " + nbEchec + "Echec" : nbReussi + " Prélevement(s) modifié(s) avec succès" , CurrentUser.LogicielHote,
                        MessageBoxButtons.OK, RadMessageIcon.Info);
               
            }
            #endregion
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            ChargerListeToutesDemandes();

        }
        #endregion

        #region BindingSource
        private void bds_ResultatDemande_CurrentChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region DataGridView
        private void dgv_Liste_Resize(object sender, EventArgs e)
        {
        //    if (dgv_ListeEdition.Width > 650)
        //    {
        //        dgv_ListeEdition.Columns["libelleResultatDemande"].Width = dgv_ListeEdition.Width -
        //            dgv_ListeEdition.Columns["codeResultatDemande"].Width - 7;
        //    }
        //    else
        //    {
        //        dgv_ListeEdition.Columns["libelleResultatDemande"].Width = 505;
        //        dgv_ListeEdition.Columns["codeResultatDemande"].Width = 138;
        //    }
        }

        private void dgv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListePrelevement.SelectedRows != null &&
                dgv_ListePrelevement.SelectedRows.Count > 0)
            {
                detaillerObjetPrelevementAnalyseDemande((PrelevementAnalyseDemande)bds_PrelevementAnalyseDemande.Current);
            }
            else
            {
                RAZ();
            }
        }
      
        private void dgv_Liste_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            Program.activerGridViewTooltipText(sender, e);
        }
        #endregion

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void radMultiColumnComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_Motif_TextChanged(object sender, EventArgs e)
        {

        }

        private void radLabel3_Click(object sender, EventArgs e)
        {

        }

        private void mcb_Demandes_TextChanged(object sender, EventArgs e)
        {
            if (mcb_Demandes.Text.Trim() != "")
            {
                chk_estTout.Checked = false;
                if (nouveau)
                {
                    ChargerListePrelevementAnalyse(Convert.ToDecimal(mcb_Demandes.Text.Trim()));
                }
                else
                {
                    ChargerListePrelevementDemande(null);
                }
                
            }
            else
            {
                RAZ();
            }
        }

        private void dgv_ListeResultat_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListePrelevement.SelectedRows != null &&
                dgv_ListePrelevement.SelectedRows.Count > 0)
            {
                detaillerObjetPrelevementAnalyseDemande((PrelevementAnalyseDemande)bds_PrelevementAnalyseDemande.Current);
            }
            else
            {
                RAZ();
            }
        }

        private void dgv_ListePrelevement_Click(object sender, EventArgs e)
        {

        }

        private void chk_estActifUtil_ToggleStateChanging(object sender, Telerik.WinControls.UI.StateChangingEventArgs args)
        {
            if (chk_estTout.Checked == false)
            {
                mcb_Demandes.Text = "";
                ChargerListeToutPrelevement();
            }
            else
            {
                RAZ();
            }
        }

        private void btn_ImprimerCodeBarre_Click(object sender, EventArgs e)
        {
            if (mcb_Demandes.Text.Trim() != "" && dgv_ListePrelevement.RowCount > 0)
            {
                TR_CodeBarre rpt = new TR_CodeBarre();
                rpt.objectDataSource1.DataSource = PrelevementAnalyseDemande.Liste(Convert.ToDecimal(mcb_Demandes.Text.Trim()), null, null, null, null,
                    null, null, null, null, null, null, null, false, null, null);
                rpt.DataSource = rpt.objectDataSource1;
                #region Encoder
                switch (dgv_ListePrelevement.Rows[0].Cells["Encoder"].Value.ToString().Trim())
                {
                    case ("Code128"):
                        {

                            break;
                        }
                    case ("Codabar"):
                        {
                            break;
                        }
                    case ("Code11"):
                        {
                            break;
                        }
                    case ("Code25Standard"):
                        {
                            break;
                        }
                    case ("Code25Interleaved"):
                        {
                            break;
                        }
                    case ("Code39"):
                        {
                            break;
                        }
                    case ("Code39Extended"):
                        {
                            break;
                        }
                    case ("Code93"):
                        {
                            break;
                        }
                    case ("Code93Extended"):
                        {
                            break;
                        }
                    case ("Code128A"):
                        {
                            break;
                        }
                    case ("Code128B"):
                        {
                            break;
                        }
                    case ("Code128C"):
                        {
                            break;
                        }
                    case ("CodeMSI"):
                        {
                            break;
                        }
                    case ("EAN8"):
                        {
                            break;
                        }
                    case ("EAN13"):
                        {
                            break;
                        }
                    case ("EAN128"):
                        {
                            break;
                        }
                    case ("EAN128A"):
                        {
                            break;
                        }
                    case ("EAN128B"):
                        {
                            break;
                        }
                    case ("EAN128C"):
                        {
                            break;
                        }
                    case ("Postnet"):
                        {
                            break;
                        }
                    case ("UPCA"):
                        {
                            break;
                        }
                    case ("UPCE"):
                        {
                            break;
                        }
                    case ("UPCSupplement2"):
                        {
                            break;
                        }
                    case ("UPCSupplement5"):
                        {
                            break;
                        }
                    case ("QRCode"):
                        {
                            break;
                        }

                    case ("PDF417"):
                        {
                            break;
                        }

                } 
                #endregion
                 //rpt.bc_Chaine.Encoder = PostnetEncoder;
               
                 rpt.txt_numDemande.Value = "Demande N° : " + mcb_Demandes.Text.Trim();
                 Frm_ReportViewer frm = new Frm_ReportViewer("CODE  BARRE", rpt);
                frm.ShowDialog();

            }
            else
            {
                RAZ();
            }
           
        }

        private void mcb_Demandes_DropDownOpening(object sender, CancelEventArgs args)
        {
            mcb_Demandes_TextChanged(null, null);
        }

        private void chk_estTout_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

        }

  
    }
}
