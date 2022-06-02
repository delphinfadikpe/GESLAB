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
using LGC.Business.GestionDeStock;
using Telerik.WinControls.UI;

namespace LGC.UI.GestionDesAnalyses
{
    public partial class Frm_DestockageAnalyse : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        decimal totalQteSaisie;
    
        decimal qteDestockee;
      
        string[] message;
        List<DestokageAnalyse> lstDestokageAnalyse = new List<DestokageAnalyse>();
        List<IntrantAnalyseDestocke> lstIntrantAnalyseDestocke = new List<IntrantAnalyseDestocke>();
        
        #endregion

        #region Autres
        private void activerDesactiverControle(bool condition)
        {
            btn_AjouterParametre.Enabled = condition;
            btn_SupprimerParametre.Enabled = condition;
            btn_Annuler.Visible = condition;
             dgv_ListeDestockageDemande.AllowEditRow =  condition;
            dgv_ListeDestockageDemande.Columns["QuantiteMax"].IsVisible = condition;
            dgv_ListeDestockageDemande.Columns["QuantiteMin"].IsVisible = condition;
            dgv_ListeDestockageDemande.Columns["stockDisponible"].IsVisible = condition;
            dgv_ListeDestockage.Enabled = !condition;
            btn_Enregistrer.Visible = condition;
            btn_Nouveau.Visible = !condition;
            btn_Modifier.Visible = !condition;
            btn_Supprimer.Enabled = !condition;
            btn_Actualiser.Enabled = !condition;
            
            
        }
        
        private void RAZ()
        {
           bds_IntrantAnalyseDestocke.DataSource = new List<PrelevementAnalyseDemande>();
            //dt.Rows.Clear();
        }


        private void creerObjetDestokageAnalyse(DestokageAnalyse obj)
        {
            obj.IdDestockage = nouveau == true ? 0 : obj.IdDestockage;
            obj.DateDestockage = nouveau == true ? DateTime.Now : obj.DateDestockage;
        }

        private void creerObjetIntrantAnalyseDestocke(IntrantAnalyseDestocke obj, decimal idDestockage, int l)
        {
            obj.CodeIntrant = dgv_ListeDestockageDemande.Rows[l].Cells["CodeIntrant"].Value.ToString();
            obj.IdDestockage = idDestockage;
            obj.CodeAnalyse = dgv_ListeDestockageDemande.Rows[l].Cells["CodeAnalyse"].Value.ToString();
            obj.NumDemande = Convert.ToDecimal(dgv_ListeDestockageDemande.Rows[l].Cells["NumDemande"].Value.ToString());
            obj.QteDesctocke = Convert.ToBoolean(dgv_ListeDestockageDemande.Rows[l].Cells["chk"].Value.ToString()) == false ? 0 :
                Convert.ToDecimal(dgv_ListeDestockageDemande.Rows[l].Cells["QteDesctocke"].Value.ToString());
       }

        private void detaillerObjetIntrantAnalyseDestocke(DestokageAnalyse obj)
        {
            ChargerListeIntrantAnalyseDestocke(obj);
        }



        private void ChargerListeIntrantAnalyseDestocke(DestokageAnalyse obj)
        {
            lstIntrantAnalyseDestocke = IntrantAnalyseDestocke.Liste( null,
                obj.IdDestockage, null, null, null, null, null, null,null,null,false,null);
            bds_IntrantAnalyseDestocke.DataSource = lstIntrantAnalyseDestocke;
            dgv_ListeDestockageDemande.DataSource = bds_IntrantAnalyseDestocke;
        }
        private void ChargerListeDestokageAnalyse(DestokageAnalyse obj)
        {
            lstDestokageAnalyse = DestokageAnalyse.Liste(null, null, null, null, null,
                null, null,false,null);
            bds_Destockage.DataSource = lstDestokageAnalyse;
            if (obj != null)
            {
                int i = 0;
                foreach (DestokageAnalyse ligne in bds_Destockage.List as List<DestokageAnalyse>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_Destockage.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
       
        #endregion
        
        #region Formulaire
        public Frm_DestockageAnalyse(DataTable dt1)
        {
            InitializeComponent();
            
            ConditionalFormattingObject obj = new ConditionalFormattingObject("ConditionQteSuffisante", ConditionTypes.Equal, "true", "", true);
            obj.CellForeColor = Color.Red;
            obj.RowBackColor = Color.LightGreen;
            this.dgv_ListeDestockageDemande.Columns["chk"].ConditionalFormattingObjectList.Add(obj);
            ConditionalFormattingObject obj1 = new ConditionalFormattingObject("ConditionQteInSuffisante", ConditionTypes.Equal, "false", "", true);
            obj1.CellForeColor = Color.Red;
            obj1.RowBackColor = Color.Red;
            this.dgv_ListeDestockageDemande.Columns["chk"].ConditionalFormattingObjectList.Add(obj1);
            dgv_ListeDestockageDemande.DataSource = dt1;
            nouveau = true;
            if (nouveau)
                btn_Nouveau_Click(null, null);
            btn_AjouterParametre.Enabled = false;
            btn_SupprimerParametre.Enabled = false;
            btn_Annuler.Enabled = false;
        }
            //activerDesactiverControle(false);
        private void Frm_ResultatDemande_Load(object sender, EventArgs e)
        {
            

            //ChargerListeDestokageAnalyse(null);
            //RAZ(); 
           
        }
        #endregion

        #region bouton de commande
        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = true;
            activerDesactiverControle(true);
            RAZ();
           
        }
        

        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (dgv_ListeDestockageDemande.RowCount > 0)
            {
                nouveau = false;
                activerDesactiverControle(true);
               btn_AjouterParametre.Focus();
                    
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
            ChargerListeDestokageAnalyse((DestokageAnalyse)bds_Destockage.Current);
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            DestokageAnalyse obj = new DestokageAnalyse();
            IntrantAnalyseDestocke objIntrantAnalyseDestocke = new IntrantAnalyseDestocke();
            int nbReussi = 0, nbEchec = 0;
            #region controle de saisie
            if (dgv_ListeDestockageDemande.RowCount == 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La grille est vide",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                btn_AjouterParametre.Focus();
                return;
            }
            
           

            #endregion

            #region Enregistrement
            if (nouveau)
            {
                creerObjetDestokageAnalyse(obj);
                sortie = obj.Insert();
                 message = LGC.Business.Tools.SplitMessage(sortie);
                 if (message[message.Length - 1].Trim() != "")
                 {
                     obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                     nbReussi = 0; nbEchec = 0;

                     for (int i = 0; i < dgv_ListeDestockageDemande.RowCount; i++)
                     {
                         creerObjetIntrantAnalyseDestocke(objIntrantAnalyseDestocke, Convert.ToDecimal(obj.NumLigne), i);
                         sortie = objIntrantAnalyseDestocke.Insert();
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

                     ChargerListeDestokageAnalyse(obj);
                     //activerDesactiverControle(false);
                     btn_Enregistrer.Enabled = false;
                     nouveau = false;
                     RadMessageBox.ThemeName = this.ThemeName;
                     RadMessageBox.Show(this, nbEchec != 0 ? nbReussi + " Déstockage(s) enrégistré(s) avec succès /n" +
                     "Et " + nbEchec + "Echec" : nbReussi + " Déstockage(s) enrégistré(s) avec succès", CurrentUser.LogicielHote,
                         MessageBoxButtons.OK, RadMessageIcon.Info);
                 }
               
                
            }
            #endregion

            #region Modification
            else
            {
                obj = (DestokageAnalyse)bds_Destockage.Current;
                     nbReussi = 0; nbEchec = 0;
                     for (int i = 0; i < dgv_ListeDestockageDemande.RowCount; i++)
                     {
                         bds_IntrantAnalyseDestocke.Position = i;
                         objIntrantAnalyseDestocke = (IntrantAnalyseDestocke)bds_IntrantAnalyseDestocke.Current;
                         if (Convert.ToDecimal(dgv_ListeDestockageDemande.Rows[i].Cells["NumLigne"].Value.ToString().Trim()) != 
                             0)
                         {
                             objIntrantAnalyseDestocke.NumLigne = Convert.ToDecimal(dgv_ListeDestockageDemande.Rows[i].Cells["NumLigne"].Value.ToString().Trim());
                             creerObjetIntrantAnalyseDestocke(objIntrantAnalyseDestocke, obj.NumLigne, i);
                             sortie = obj.Update();
                         }
                         else
                         {
                             creerObjetIntrantAnalyseDestocke(objIntrantAnalyseDestocke, obj.NumLigne, i);
                             sortie = objIntrantAnalyseDestocke.Insert();
                             message = LGC.Business.Tools.SplitMessage(sortie);
                         }
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
                     //activerDesactiverControle(false);
                     btn_Enregistrer.Enabled = false;
                     nouveau = false;
                     ChargerListeDestokageAnalyse(obj);
                     RadMessageBox.ThemeName = this.ThemeName;
                     RadMessageBox.Show(this, nbEchec != 0 ? nbReussi + " Déstockage(s) modifié(s) avec succès /n" +
                         "Et " + nbEchec + "Echec" : nbReussi + " Déstockage(s) modifié(s) avec succès", CurrentUser.LogicielHote,
                             MessageBoxButtons.OK, RadMessageIcon.Info);
               
                 
               
            }
            #endregion
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            ChargerListeDestokageAnalyse(null);

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

        private void dgv_ListeDestockage_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_ListeDestockage.SelectedRows != null &&
                    dgv_ListeDestockage.SelectedRows.Count > 0)
                {
                    detaillerObjetIntrantAnalyseDestocke((DestokageAnalyse)bds_Destockage.Current);
                }
                else
                {
                    RAZ();
                }
            }
            catch { }
        }

        private void dgv_ListeDestockageDemande_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgv_ListeDestockageDemande.SelectedRows != null &&
                 dgv_ListeDestockageDemande.SelectedRows.Count > 0)
                {
                    if (e.Column.Name.ToLower() == "qtedesctocke")
                    {
                        qteDestockee = Convert.ToDecimal(dgv_ListeDestockageDemande.CurrentRow.Cells["QteDesctocke"].Value.ToString().Trim());

                    }
                }
            }
            catch { }
        }

        private void dgv_ListeDestockageDemande_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (dgv_ListeDestockageDemande.SelectedRows != null &&
                dgv_ListeDestockageDemande.SelectedRows.Count > 0)
                {
                    if (e.Column.Name.ToLower() == "qtedesctocke")
                    {
                        if (Convert.ToDecimal(dgv_ListeDestockageDemande.CurrentRow.Cells["QteDesctocke"].Value.ToString().Trim()) >
                            Convert.ToDecimal(dgv_ListeDestockageDemande.CurrentRow.Cells["stockDisponible"].Value.ToString().Trim()))
                        {
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "La quantité déstockée ne peut pas être supérieure à la quantité disponible en stock.",
                                CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                            dgv_ListeDestockageDemande.CurrentRow.Cells["QteDesctocke"].Value = qteDestockee;
                            return;
                        }
                        //if (Convert.ToDecimal(dgv_ListeDestockageDemande.CurrentRow.Cells["QteDesctocke"].Value.ToString().Trim()) < 
                        //    Convert.ToDecimal(dgv_ListeDestockageDemande.CurrentRow.Cells["QuantiteMin"].Value.ToString().Trim()))
                        //{
                        //    RadMessageBox.ThemeName = this.ThemeName;
                        //    RadMessageBox.Show(this, "La quantité déstockée ne peut pas être inférieure à la quantité minimale.",
                        //        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                        //    dgv_ListeDestockageDemande.CurrentRow.Cells["QteDesctocke"].Value = qteDestockee;
                        //    return;
                        //}

                        //if (Convert.ToDecimal(dgv_ListeDestockageDemande.CurrentRow.Cells["QteDesctocke"].Value.ToString().Trim()) >
                        //    Convert.ToDecimal(dgv_ListeDestockageDemande.CurrentRow.Cells["QuantiteMax"].Value.ToString().Trim()))
                        //{
                        //    RadMessageBox.ThemeName = this.ThemeName;
                        //    RadMessageBox.Show(this, "La quantité déstockée ne peut pas être supérieure à la quantité maximale.",
                        //        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                        //    dgv_ListeDestockageDemande.CurrentRow.Cells["QteDesctocke"].Value = qteDestockee;
                        //    return;
                        //}
                        totalQteSaisie = 0;
                        for (int i = 0; i < dgv_ListeDestockageDemande.RowCount; i++)
                        {
                            if (dgv_ListeDestockageDemande.CurrentRow.Cells["CodeIntrant"].Value.ToString().Trim() ==
                                dgv_ListeDestockageDemande.Rows[i].Cells["CodeIntrant"].Value.ToString().Trim())
                            {
                                totalQteSaisie += Convert.ToDecimal(dgv_ListeDestockageDemande.Rows[i].Cells["QteDesctocke"].Value.ToString().Trim());
                                dgv_ListeDestockageDemande.Rows[i].Cells["QteDispoReelle"].Value =
                                    Convert.ToDecimal(dgv_ListeDestockageDemande.Rows[i].Cells["stockDisponible"].Value.ToString().Trim()) - totalQteSaisie;
                                dgv_ListeDestockageDemande.Rows[i].Cells["chk"].Value =
                                    Convert.ToDecimal(dgv_ListeDestockageDemande.Rows[i].Cells["QteDispoReelle"].Value.ToString().Trim()) < 0 ? false : true;
                            }

                        }
                    }
                }
            }
            catch { }
        }

        private void btn_AjouterParametre_Click(object sender, EventArgs e)
        {
            Frm_ListeDemande frm = new Frm_ListeDemande();
            frm.ShowDialog();
        }

        private void dgv_ListeDestockageDemande_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radSplitContainer1_Click(object sender, EventArgs e)
        {

        }

       

  
    }
}
