using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LGC.Business.Parametre;
using Telerik.WinControls.UI.Localization;
using LGC.UI;
using LGC.Business; 
//using BGS.Business.School;

namespace LGC.UI.Parametre
{
    public partial class Frm_TrancheAgePatient : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        string[] message;
        List<TrancheAgePatient> lstTrancheAgePatient = new List<TrancheAgePatient>();
        
        #endregion

        #region Autres
        private void activerDesactiverControle(bool condition)
        {
            txt_Code.ReadOnly = !condition;
            txt_Libelle.ReadOnly = !condition;
            chk_estAge.ReadOnly = !condition;

            dgv_Liste.Enabled = !condition;

            btn_Annuler.Visible = condition;
            btn_Enregistrer.Visible = condition;
            btn_Nouveau.Visible = !condition;
            btn_Modifier.Visible = !condition;
            btn_Supprimer.Enabled = !condition;
            btn_Actualiser.Enabled = !condition;
        }

        private void RAZ()
        {
            txt_Code.Text = "";
            txt_Libelle.Text = "";
            txt_PerioAgeMin.Text = "";
            txt_PerioAgeMax.Text = "";
            txt_ageMax.Value = 0;
            txt_ageMin.Value = 0;
           
        }

        private void constituerObjet(TrancheAgePatient obj)
        {
            obj.CodeTranche = txt_Code.Text.Trim();
            obj.NomAttribue = txt_Libelle.Text.Trim();
            obj.PeriodiciteMax = txt_PerioAgeMax.Text.Trim();
            obj.PeriodiciteMin = txt_PerioAgeMin.Text.Trim();
            obj.MinTranche = txt_ageMin.Value;
            obj.MaxTranche = txt_ageMax.Value;
            
        }

        private void detaillerObjet(TrancheAgePatient obj)
        {
            txt_Code.Text = obj.CodeTranche.Trim();
            txt_Libelle.Text = obj.NomAttribue.Trim();
            txt_PerioAgeMin.Text = obj.PeriodiciteMin.Trim();
            txt_PerioAgeMax.Text = obj.PeriodiciteMax.Trim();
            txt_ageMax.Value = obj.MaxTranche;
            txt_ageMin.Value = obj.MinTranche;
           
        }

        private void ChargerListe(TrancheAgePatient obj)
        {
            lstTrancheAgePatient = TrancheAgePatient.Liste(null,null,null,null,null,
                null, null, null, null,null,null, false, null);
            bds_TrancheAgePatient.DataSource = lstTrancheAgePatient;
            if (obj != null)
            {
                int i = 0;
                foreach (TrancheAgePatient ligne in bds_TrancheAgePatient.List as List<TrancheAgePatient>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_TrancheAgePatient.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }
        #endregion

        #region Formulaire
        public Frm_TrancheAgePatient()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new FrenchRadGridLocalizationProvider();
            this.ThemeName = LGC.Business.CurrentUser.ThemeName;
        }

        private void Frm_Matières_Load(object sender, EventArgs e)
        {
           
            activerDesactiverControle(false);
            ChargerListe(null);
            if (nouveau)
                btn_Nouveau_Click(null, null);
        }
        #endregion

        #region Bouton de commande
        public void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = true;
            activerDesactiverControle(true);
            RAZ();
            txt_Code.Focus();
        }

        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (dgv_Liste.SelectedRows != null &&
                dgv_Liste.SelectedRows.Count > 0)
            {
                nouveau = false;
                activerDesactiverControle(true);
                txt_Code.ReadOnly = true;
                txt_Libelle.Focus();
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez selectioner une ligne " +
                    "avant d'entamer la modification.", CurrentUser.LogicielHote, MessageBoxButtons.OK,
                    RadMessageIcon.Error);
            }
        }

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            if (dgv_Liste.SelectedRows != null &&
                dgv_Liste.SelectedRows.Count > 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne " +
                    "sélectionnée", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                    RadMessageIcon.Question) == DialogResult.Yes)
                {
                    TrancheAgePatient obj = (TrancheAgePatient)bds_TrancheAgePatient.Current;
                    string res = obj.Delete();
                     message = LGC.Business.Tools.SplitMessage(res);
                    if (int.Parse(message[0]) > 0)
                    {
                        ChargerListe((TrancheAgePatient)bds_TrancheAgePatient.Current);
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    else
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        MessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner la ligne à supprimer.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            RAZ();
            activerDesactiverControle(false);
            ChargerListe((TrancheAgePatient)bds_TrancheAgePatient.Current);
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            TrancheAgePatient obj = new TrancheAgePatient();
            
            #region controle de saisie
            if (txt_Code.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du code est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_Code.Focus();
                return;
            }

            if (txt_Libelle.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du nom est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_Libelle.Focus();
                return;
            }
            if (txt_ageMax.Text.Trim() == "" )
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La précision de l'âge minimal est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_ageMax.Focus();
                return;
            }
            if (txt_PerioAgeMin.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La sélection de périodicité de l'âge minimal est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_PerioAgeMin.Focus();
                return;
            }

            if (txt_ageMax.Text.Trim() == "" || txt_ageMax.Text.Trim() == "0")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La précision de l'âge maximal est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_ageMax.Focus();
                return;
            }

            if (txt_PerioAgeMax.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La sélection de périodicité de l'âge maximal est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_PerioAgeMax.Focus();
                return;
            }
            #endregion

            #region Enregistrement
            if (nouveau)
            {
                constituerObjet(obj);
                sortie = obj.Insert();
                 message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length-1].Trim());
                    ChargerListe(obj);
                    activerDesactiverControle(false);
                    nouveau = false;
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                        MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            #endregion

            #region Modification
            else
            {
                obj = (TrancheAgePatient)bds_TrancheAgePatient.Current;
                constituerObjet(obj);
                sortie = obj.Update();
                 message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    activerDesactiverControle(false);
                    nouveau = false;
                    ChargerListe((TrancheAgePatient)bds_TrancheAgePatient.Current);
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
        private void bds_TrancheAgePatient_CurrentChanged(object sender, EventArgs e)
        {
            
        } 
        #endregion

        #region DataGridView
        private void dgv_Liste_Resize(object sender, EventArgs e)
        {
            //if (dgv_Liste.Width > 650)
            //{
            //    dgv_Liste.Columns["NomTrancheAgePatient"].Width = dgv_Liste.Width -
            //        dgv_Liste.Columns["CodeTrancheAgePatient"].Width - 7;
            //}
            //else
            //{
            //    dgv_Liste.Columns["NomTrancheAgePatient"].Width = 505;
            //    dgv_Liste.Columns["CodeTrancheAgePatient"].Width = 138;
            //}
        }

        private void dgv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Liste.SelectedRows != null &&
                dgv_Liste.SelectedRows.Count > 0)
            {
                detaillerObjet((TrancheAgePatient)bds_TrancheAgePatient.Current);
            }
            else
            {
                RAZ();
            }
        }
        #endregion

        private void dgv_Liste_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            //this.dgv_Liste.EnableAlternatingRowColor = true;
            //this.dgv_Liste.TableElement.AlternatingRowColor = Color.LightGoldenrodYellow;
        }

        private void chk_estAge_ToggleStateChanging(object sender, Telerik.WinControls.UI.StateChangingEventArgs args)
        {
            if (chk_estAge.Checked == false)
            {
                txt_ageMax.ReadOnly = false;
               
                txt_ageMin.ReadOnly = false;

                txt_PerioAgeMax.ReadOnly = false;
                txt_PerioAgeMin.ReadOnly = false;
                txt_ageMax.Value = 0;
                txt_ageMin.Value = 0;
                txt_PerioAgeMax.SelectedIndex = 0;
                txt_PerioAgeMin.SelectedIndex = 0;
                txt_PerioAgeMax.Text = "";
                txt_PerioAgeMin.Text = "";
            }
            else
            {
                txt_ageMax.ReadOnly = true;
                txt_ageMax.Value = 100;
                txt_ageMin.Value = 0;
                txt_PerioAgeMax.SelectedIndex = 3;
                txt_PerioAgeMin.SelectedIndex = 0;
                txt_PerioAgeMax.Text = "Année(s)";
                txt_PerioAgeMin.Text = "Jour(s)";
                txt_ageMin.ReadOnly = true;
                txt_PerioAgeMax.ReadOnly = true;
                txt_PerioAgeMin.ReadOnly = true;
            }
        }
    }
}
