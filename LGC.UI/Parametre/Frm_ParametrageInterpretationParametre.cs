using LGC.Business;
using LGC.Business.Parametre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace LGC.UI.Parametre
{
    public partial class Frm_ParametrageInterpretationParametre : Telerik.WinControls.UI.RadForm
    {
        #region Declaration
        public bool nouveau = false;
        string sortie;
        string[] message;
        List<Analyse> lstAnalyse = new List<Analyse>();
        List<ParametreAnalyse> lstParametreAnalyse = new List<ParametreAnalyse>();
        List<ParametrageInterpretationParametre> lstParametrageInterpretationParametre = new List<ParametrageInterpretationParametre>();

        #endregion

        #region Autres
        private void activerDesactiverControle(bool condition)
        {
            rb_Palier.ReadOnly = !condition;
            rb_ValeurFixe.ReadOnly = !condition;
            txt_Interpretation.ReadOnly = !condition;
            dgv_Liste.Enabled = !condition;
            dgv_ListeParametreShow.Enabled = !condition;
            dgv_ListeInterpretation.Enabled = !condition;
            rb_Palier_ToggleStateChanged(null, null);

            btn_AnnuleIntrant.Visible = condition;
            btn_SaveIntrant.Visible = condition;
            btn_AjouterIntrant.Visible = !condition;
            btn_Modif.Visible = !condition;
            btn_SupprimerIntrant.Enabled = !condition;
            btn_Actualiser.Enabled = !condition;
        }
        private void RAZ()
        {
            rb_Palier.CheckState = CheckState.Checked;
            rb_ValeurFixe.CheckState = CheckState.Unchecked;
            txt_Interpretation.Text = "";
            RAZBorne();
        }
        private void RAZBorne()
        {
            meb_borneInf.Value = 0;
            meb_borneSup.Value = 0;
            txt_valeurFixe.Text = "";
        }
        private void activerDesactiverControleBorne(bool condition, bool tout)
        {
            if (tout == true)
            {
                meb_borneInf.ReadOnly = true;
                meb_borneSup.ReadOnly = true;
                txt_valeurFixe.ReadOnly = true;
            }
            else
            {
                meb_borneInf.ReadOnly = !condition;
                meb_borneSup.ReadOnly = !condition;
                txt_valeurFixe.ReadOnly = condition;
            }
          
        }
        
        private void ChargerListeInterpretation(ParametreAnalyse obj, ParametrageInterpretationParametre obj1)
        {
            lstParametrageInterpretationParametre = ParametrageInterpretationParametre.Liste(obj.CodeAnalyse, obj.LibelleParametre, null, null, null, null, null, null, null, null,
            null, false, null);
            bds_ParametrageInterpretationParametre.DataSource = lstParametrageInterpretationParametre;

            if (obj1 != null)
            {
                int i = 0;
                foreach (ParametrageInterpretationParametre ligne in bds_ParametrageInterpretationParametre.List as List<ParametrageInterpretationParametre>)
                {
                    if (ligne.NumLigne == obj1.NumLigne)
                    {
                        bds_ParametrageInterpretationParametre.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        private void ChargerListeParametreAnalyse(Analyse obj)
        {
            if (obj != null)
            {
                lstParametreAnalyse = ParametreAnalyse.Liste(obj.CodeAnalyse, null, null, null, null, null, null, null, false, null);
                bds_ParametreAnalyse.DataSource = lstParametreAnalyse;
            }
        }
        private void detaillerObjet(Analyse obj)
        {
            ChargerListeParametreAnalyse(obj);
        }
        private void constituerObjetInterpretation(ParametrageInterpretationParametre obj, ParametreAnalyse obj1)
        {
            obj.CodeAnalyse = obj1.CodeAnalyse.Trim();
            obj.LibelleParametre = obj1.LibelleParametre.Trim();
          obj.BorneInferieure =  Convert.ToDecimal(meb_borneInf.Text);
           obj.BorneSuperieure = Convert.ToDecimal(meb_borneSup.Text);
          obj.Valeur = txt_valeurFixe.Text;
          obj.Interpretation = txt_Interpretation.Text.Trim();

        }
        private void detaillerObjetInterpretation(ParametrageInterpretationParametre obj)
        {
            rb_Palier.CheckState = txt_valeurFixe.Text.Trim() == "" ? CheckState.Checked : CheckState.Unchecked;
            rb_ValeurFixe.CheckState = txt_valeurFixe.Text.Trim() != "" ? CheckState.Checked : CheckState.Unchecked;
            meb_borneInf.Text = Convert.ToString(obj.BorneInferieure);
            meb_borneSup.Text = Convert.ToString(obj.BorneSuperieure);
            txt_valeurFixe.Text = obj.Valeur;
            txt_Interpretation.Text = obj.Interpretation;
           
        }
        private void ChargerListe()
        {
            lstAnalyse = Analyse.Liste(null, null, null, null,
                null, null, null, null, null, null, null, null, false, null);
            bds_Analyse.DataSource = lstAnalyse;
        } 
        #endregion

        public Frm_ParametrageInterpretationParametre()
        {
            InitializeComponent();
        }

        private void Frm_ParametrageInterpretationParametre_Load(object sender, EventArgs e)
        {
            activerDesactiverControle(false);
            ChargerListe();
            if (nouveau)
                btn_AjouterIntrant_Click(null, null);
        }

        private void dgv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Liste.SelectedRows != null &&
                dgv_Liste.SelectedRows.Count > 0)
            {
                detaillerObjet((Analyse)bds_Analyse.Current);
            }
            else
            {
                RAZ();
            }
        }

        private void dgv_ListeParametreShow_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeParametreShow.SelectedRows != null &&
              dgv_ListeParametreShow.SelectedRows.Count > 0)
            {
                ChargerListeInterpretation((ParametreAnalyse)bds_ParametreAnalyse.Current,
                    null);
            }
        }

        private void rb_Palier_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rb_Palier.IsChecked && rb_Palier.ReadOnly == false)
            {
                activerDesactiverControleBorne(true, false);
                RAZBorne();
            }
            else if (rb_Palier.ReadOnly == false)
            {
                activerDesactiverControleBorne(false, false);
                RAZBorne();
            }
        }

        private void btn_AnnuleIntrant_Click(object sender, EventArgs e)
        {
            nouveau = false;
            RAZ();
            activerDesactiverControle(false);
            activerDesactiverControleBorne(false, true);
            ChargerListeParametreAnalyse((Analyse)bds_Analyse.Current);
        }

        private void btn_SupprimerIntrant_Click(object sender, EventArgs e)
        {
            if (dgv_ListeInterpretation.SelectedRows != null &&
                dgv_ListeInterpretation.SelectedRows.Count > 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne " +
                    "sélectionnée", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                    RadMessageIcon.Question) == DialogResult.Yes)
                {
                    ParametrageInterpretationParametre obj = (ParametrageInterpretationParametre)bds_ParametrageInterpretationParametre.Current;
                    string res = obj.Delete();
                    message = LGC.Business.Tools.SplitMessage(res);
                    if (int.Parse(message[0]) > 0)
                    {
                        ChargerListeInterpretation((ParametreAnalyse)bds_ParametreAnalyse.Current,
                            (ParametrageInterpretationParametre)bds_ParametrageInterpretationParametre.Current);
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

        private void btn_AjouterIntrant_Click(object sender, EventArgs e)
        {
            if (dgv_ListeParametreShow.SelectedRows != null &&
                dgv_ListeParametreShow.SelectedRows.Count > 0)
            {
                nouveau = true;
                activerDesactiverControle(true);
                rb_Palier.Focus();
                RAZ();   
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner le parametre d'abord.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_SaveIntrant_Click(object sender, EventArgs e)
        {
            ParametrageInterpretationParametre obj = new ParametrageInterpretationParametre();

            #region controle de saisie
            if (rb_Palier.IsChecked && Convert.ToDecimal(meb_borneSup.Value) == 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie de la borne supérieure est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                rb_Palier.Focus();
                return;
            }
            else if (rb_Palier.IsChecked && Convert.ToDecimal(meb_borneSup.Value) <= Convert.ToDecimal(meb_borneInf.Value))
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La borne inférieur ne doit pas être inférieure ou égale à la borne supérieure.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_borneSup.Focus();
                return;
            }

            if (rb_ValeurFixe.IsChecked && txt_valeurFixe.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie de la valeur fixe est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_valeurFixe.Focus();
                return;
            }

            if (txt_Interpretation.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie de l'intépretation est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_Interpretation.Focus();
                return;
            }
            #endregion

            #region Enregistrement
            if (nouveau)
            {
                constituerObjetInterpretation(obj, (ParametreAnalyse)bds_ParametreAnalyse.Current);
                sortie = obj.Insert();
                message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    ChargerListeInterpretation((ParametreAnalyse)bds_ParametreAnalyse.Current, obj);
                    activerDesactiverControle(false);
                    activerDesactiverControleBorne(false, true);
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
                obj = (ParametrageInterpretationParametre)bds_ParametrageInterpretationParametre.Current;
                constituerObjetInterpretation(obj, (ParametreAnalyse)bds_ParametreAnalyse.Current);
                sortie = obj.Update();
                message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    activerDesactiverControle(false);
                    activerDesactiverControleBorne(false, true);
                    nouveau = false;
                    ChargerListeInterpretation((ParametreAnalyse)bds_ParametreAnalyse.Current, obj);
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

        private void btn_Modif_Click(object sender, EventArgs e)
        {
            if (dgv_ListeInterpretation.SelectedRows != null &&
                dgv_ListeInterpretation.SelectedRows.Count > 0)
            {
                nouveau = false;
                activerDesactiverControle(true);
                
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez selectioner une ligne " +
                    "avant d'entamer la modification.", CurrentUser.LogicielHote, MessageBoxButtons.OK,
                    RadMessageIcon.Error);
            }
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            ChargerListe();
        }
    }
}
