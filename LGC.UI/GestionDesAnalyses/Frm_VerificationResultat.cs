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
using Telerik.WinControls.UI;
using LGC.UI.Crystal;

namespace LGC.UI.GestionDesAnalyses
{
    public partial class Frm_VerificationResultat : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
       
        string sortie;
        string Statut = "";
        int index;
        
        string[] message;
        List<ResultatParametreAnalyse> lstResultatParametreAnalyse = new List<ResultatParametreAnalyse>();
        List<AnalyseDemande> lstInterpretation = new List<AnalyseDemande>();
        List<ResultatDemande> lstResultatDemande = new List<ResultatDemande>();
        List<DemandeAnalyse> lstDemandeAnalyse = new List<DemandeAnalyse>();
        List<UniteMesure> lstUniteMesure = new List<UniteMesure>();
        #endregion

        #region Autres
        private void activerDesactiverControle(bool condition)
        {
            
            dgv_ListeParametre.AllowEditRow = condition;
            
            dgv_ListeResultat.Enabled = !condition;
            
            btn_Annuler.Visible = condition;
            btn_Enregistrer.Enabled = condition;
            btn_Nouveau.Visible = !condition;
            btn_Actualiser.Enabled = !condition;
            
        }
        
        private void RAZ()
        {
            txt_num.Text = "";
            mcb_Demandes.Text = "";
            //dgv_ListeParametre.Rows.Clear();
        
            dtp_dateOperation.Value = DateTime.Now;
            //for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
            //{
            //    dgv_ListeParametre.Rows.RemoveAt(i);
            //    i--;
            //}
            bds_ResultatParametreAnalyse.DataSource = new List<ResultatParametreAnalyse>();
            //for (int i = 0; i < dgv_ListeInterpretation.RowCount; i++)
            //{
            //    dgv_ListeInterpretation.Rows.RemoveAt(i);
            //    i--;
            //}

            bds_Interpretation.DataSource = new List<AnalyseDemande>();
            
        }

       
        private void constituerObjetResultat(ResultatDemande obj, string Statut)
        {
            obj.NumDemande = Convert.ToDecimal(mcb_Demandes.Text.Trim());
            obj.EstVerifie1 = Statut == "REJETE" ? false : true;
            obj.DateVerification1 = Statut == "REJETE" ? Convert.ToDateTime("01/01/2050") : DateTime.Now;
            obj.EstVerifie2 = Statut == "REJETE" ? false : true;
            obj.DateVerification2 = Statut == "REJETE" ? Convert.ToDateTime("01/01/2050") : DateTime.Now;
            obj.DateOperation = dtp_dateOperation.Value;
            obj.EstTransmi = Statut == "REJETE" ? false : true;
            obj.Conclusion = "";
            obj.Statut = Statut.Trim();
        }

        private void creerObjetResultatParametreAnalyse(ResultatParametreAnalyse obj, decimal idResultat, int l)
        {
           
            obj.EstValide = dgv_ListeParametre.Rows[l].Cells["Valide"].Value == null || 
                Convert.ToBoolean(dgv_ListeParametre.Rows[l].Cells["Valide"].Value.ToString()) == false ?  "NON" : "OUI";
           obj.MotifRejet = dgv_ListeParametre.Rows[l].Cells["MotifRejet"].Value == null ? "" : dgv_ListeParametre.Rows[l].Cells["MotifRejet"].Value.ToString();
           obj.Unite = dgv_ListeParametre.Rows[l].Cells["Unite"].Value.ToString();
           obj.ValeurResultat = dgv_ListeParametre.Rows[l].Cells["ValeurResultat"].Value.ToString();
            

        }
        
        private void detaillerObjetResultatDemande(ResultatDemande obj)
        {
            txt_num.Text = Convert.ToString(obj.IdResultatDemande);
            mcb_Demandes.Text = Convert.ToString(obj.NumDemande);
            dtp_dateOperation.Value = Convert.ToDateTime(obj.DateOperation);
           
            if (obj.Statut.Trim() == "EN ATTENTE")
            {
                ChargerListeResultatParametreAnalyse(obj);
                
            }
            else if (obj.Statut.Trim() == "REJETE")
            {
                ChargerListeResultatParametreAnalyseRejeter(obj);
                
            }

            ChargerListeInterpretation(obj.NumDemande);
        }
        private void ChargerListeResultatParametreAnalyseRejeter(ResultatDemande obj)
        {
            lstResultatParametreAnalyse = ResultatParametreAnalyse.Liste(obj.IdResultatDemande, null,null, null, "NON", null,
                null, null, null, null, null, null, null, null, false, null);
            bds_ResultatParametreAnalyse.DataSource = lstResultatParametreAnalyse;
        }
        
        private void ChargerListeResultatParametreAnalyse(ResultatDemande obj)
        {
            lstResultatParametreAnalyse = ResultatParametreAnalyse.Liste(obj.IdResultatDemande,null, null, null, null, null,
                null, null, null, null, null, null, null, null, false, null);
            bds_ResultatParametreAnalyse.DataSource = lstResultatParametreAnalyse;
        }
        
        
        private void ChargerListeInterpretation(decimal numDemande)
        {
            lstInterpretation = AnalyseDemande.Liste(null, numDemande
                , null, null, null, null, null, null, null, null, false, null, null);
            bds_Interpretation.DataSource = lstInterpretation;
        }
        private void creerObjetResultatInterpretation(AnalyseDemande obj, int l)
        {
            obj.Interpretation = dgv_ListeInterpretation.Rows[l].Cells["Interpretation"].Value.ToString();
        }

        private void ChargerListe(ResultatDemande obj)
        {
            lstResultatDemande = ResultatDemande.Liste(null, null, null, null, false,
                null, null, true, null, null, null, null, null, null, null, false, null);
            bds_Resultat.DataSource = lstResultatDemande;
            if (obj != null)
            {
                int i = 0;
                foreach (ResultatDemande ligne in bds_Resultat.List as List<ResultatDemande>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_Resultat.Position = i;
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
        public Frm_VerificationResultat()
        {
            InitializeComponent();
            dgv_ListeInterpretation.TableElement.RowHeight = 60;
            dgv_ListeParametre.TableElement.RowHeight = 30;
            ConditionalFormattingObject obj = new ConditionalFormattingObject("ConditionValide", ConditionTypes.Equal, "true", "", true);
            obj.CellForeColor = Color.Red;
            obj.RowBackColor = Color.LightGreen;
            this.dgv_ListeParametre.Columns["Valide"].ConditionalFormattingObjectList.Add(obj);
            ConditionalFormattingObject obj1 = new ConditionalFormattingObject("ConditionRejete", ConditionTypes.Equal, "true", "", true);
            obj1.CellForeColor = Color.Red;
            obj1.RowBackColor = Color.Orange;
            this.dgv_ListeParametre.Columns["Rejete"].ConditionalFormattingObjectList.Add(obj1);
        }

        private void Frm_ResultatDemande_Load(object sender, EventArgs e)
        {
            activerDesactiverControle(false);
           
            RAZ();
            ChargerListe(null);
           
        }
        #endregion

        #region bouton de commande
        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            if (dgv_ListeResultat.SelectedRows != null &&
                dgv_ListeResultat.SelectedRows.Count > 0)
            {
                activerDesactiverControle(true);
               dgv_ListeParametre.Focus();
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez selectioner une ligne " +
                    "avant d'entamer la vérification.", CurrentUser.LogicielHote, MessageBoxButtons.OK,
                    RadMessageIcon.Error);
            }
        }
        
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            
            RAZ();
            activerDesactiverControle(false);
            ChargerListe((ResultatDemande)bds_Resultat.Current);
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            ResultatDemande obj = new ResultatDemande();
            ResultatParametreAnalyse objResultatParametreAnalyse = new ResultatParametreAnalyse();
            AnalyseDemande objAnalyseDemande = new AnalyseDemande();

            for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
            {
                if (dgv_ListeParametre.Rows[i].Cells["ValeurResultat"].Value == null ||
                    dgv_ListeParametre.Rows[i].Cells["ValeurResultat"].Value.ToString().Trim() == string.Empty)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Il y a un moins un parametre dont vous n'aviez pas renseigner sa valeur résultat.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    dgv_ListeParametre.Focus();
                    return;
                }

            }

            Statut = "VALIDE";

            #region controle de saisie
           
            for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
            {
                if (dgv_ListeParametre.Rows[i].Cells["Valide"].Value == null ||
                    Convert.ToBoolean(dgv_ListeParametre.Rows[i].Cells["Valide"].Value.ToString().Trim()) == false)
                {
                    if (dgv_ListeParametre.Rows[i].Cells["Rejete"].Value == null ||
                    Convert.ToBoolean(dgv_ListeParametre.Rows[i].Cells["Rejete"].Value.ToString().Trim()) == false)
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, "Il y a un moins une ligne que vous n'aviez pas vérifier.",
                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                        dgv_ListeParametre.Focus();
                        return;
                    }
                    else
                    {
                        if (dgv_ListeParametre.Rows[i].Cells["MotifRejet"].Value == null ||
                        Convert.ToString(dgv_ListeParametre.Rows[i].Cells["MotifRejet"].Value.ToString().Trim()) == string.Empty)
                        {
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Veuillez renseigner les motifs pour les rejet que vous aviez fait.",
                                CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                            dgv_ListeParametre.Focus();
                            return;
                        }
                        Statut = "REJETE";
                    }
                }
               
            }
            #endregion

            

            #region Modification
                 RadMessageBox.ThemeName = this.ThemeName;
                 if (RadMessageBox.Show(this, Statut == "VALIDE" ? "Voulez-vous vraiment valider le résultat sélectionné ?" :
                     "Voulez-vous vraiment rejeter le résultat sélectionné ?", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                     RadMessageIcon.Question) == DialogResult.Yes)
                 {
                     obj = (ResultatDemande)bds_Resultat.Current;
                     constituerObjetResultat(obj, Statut);
                     sortie = obj.Update();
                     message = LGC.Business.Tools.SplitMessage(sortie);
                     if (message[message.Length - 1].Trim() != "")
                     {
                         obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                         for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
                         {
                             bds_ResultatParametreAnalyse.Position = i;
                             objResultatParametreAnalyse = (ResultatParametreAnalyse)bds_ResultatParametreAnalyse.Current;
                             creerObjetResultatParametreAnalyse(objResultatParametreAnalyse, obj.NumLigne, i);
                             objResultatParametreAnalyse.Update();
                         }

                         for (int i = 0; i < dgv_ListeInterpretation.RowCount; i++)
                         {
                             bds_Interpretation.Position = i;
                             objAnalyseDemande = (AnalyseDemande)bds_Interpretation.Current;
                             creerObjetResultatInterpretation(objAnalyseDemande, i);
                             objAnalyseDemande.Update();
                         }
                         activerDesactiverControle(false);
                         
                         ChargerListe((ResultatDemande)bds_Resultat.Current);
                         RadMessageBox.ThemeName = this.ThemeName;
                         RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                             MessageBoxButtons.OK, RadMessageIcon.Info);
                     }
                     else
                     {
                         RadMessageBox.ThemeName = this.ThemeName;
                         RadMessageBox.Show(this, message[4].Trim(), CurrentUser.LogicielHote,
                             MessageBoxButtons.OK, RadMessageIcon.Error);
                     }
                 }
            #endregion
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            ChargerListe(null);
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
            if (dgv_ListeEdition.SelectedRows != null &&
                dgv_ListeEdition.SelectedRows.Count > 0)
            {
                //detaillerObjet((ResultatDemande)bds_Resultat.Current);
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

        
        private void dgv_ListeResultat_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeResultat.SelectedRows != null &&
                dgv_ListeResultat.SelectedRows.Count > 0)
            {
                detaillerObjetResultatDemande((ResultatDemande)bds_Resultat.Current);
            }
            else
            {
                RAZ();
            }
        }

        

        private void dgv_ListeParametre_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
        {
            if (dgv_ListeParametre.SelectedRows != null &&
              dgv_ListeParametre.SelectedRows.Count > 0)
            {
                if (e.Column.Name.ToLower() == "valide" )
                {
                    for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
                    {
                        index = i;
                        if (dgv_ListeParametre.CurrentRow == dgv_ListeParametre.Rows[i])
                        {
                            if (dgv_ListeParametre.Rows[i].Cells["Valide"].Value == null || 
                                Convert.ToBoolean(dgv_ListeParametre.Rows[i].Cells["Valide"].Value.ToString().Trim()) == false)
                            {
                                dgv_ListeParametre.Rows[i].Cells["Rejete"].Value = false;
                                dgv_ListeParametre.Rows[i].Cells["MotifRejet"].Value = "";
                               
                            }
                            break;
                        }
                    }
                }

                if (e.Column.Name.ToLower() == "rejete")
                {
                    for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
                    {
                        index = i;
                        if (dgv_ListeParametre.CurrentRow == dgv_ListeParametre.Rows[i])
                        {
                            if (dgv_ListeParametre.Rows[i].Cells["Rejete"].Value == null || 
                                Convert.ToBoolean(dgv_ListeParametre.Rows[i].Cells["Rejete"].Value.ToString().Trim()) == false)
                            {
                                dgv_ListeParametre.Rows[i].Cells["Valide"].Value = false;

                            }
                            break;
                        }
                    }
                }
            }
        }

        private void MasterTemplate_Click(object sender, EventArgs e)
        {

        }

       

        

        

       
    }
}
