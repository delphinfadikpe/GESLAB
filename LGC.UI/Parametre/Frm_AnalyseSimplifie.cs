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
    public partial class Frm_AnalyseSimplifie : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        string[] message;
        List<Analyse> lstAnalyse = new List<Analyse>();
        public Analyse oAnalyse = new Analyse();
        #endregion

        #region Autres
        private void activerDesactiverControle(bool condition)
        {
            txt_Code.ReadOnly = !condition;
            txt_Libelle.ReadOnly = !condition;
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
            meb_cout.Text = "0";
        }

        private void constituerObjet(Analyse obj)
        {
            obj.CodeAnalyse = txt_Code.Text.Trim();
            obj.LibelleAnalyse = txt_Libelle.Text.Trim();
            obj.Cout = Convert.ToDecimal(meb_cout.Value);
            obj.CodeSecteur = "AUCUN";
            obj.Heure = 0;
            obj.Minute = 0;
            obj.Jours = 0;
        }

        private void detaillerObjet(Analyse obj)
        {
            txt_Code.Text = obj.CodeAnalyse.Trim();
            txt_Libelle.Text = obj.LibelleAnalyse.Trim();
            meb_cout.Value = obj.Cout;
        }

        private void ChargerListe(Analyse obj)
        {
            lstAnalyse = Analyse.Liste(null,null,null,null,null,
                null,null,null,null,null,null,null,false,null);
            bds_Analyse.DataSource = lstAnalyse;
            if (obj != null)
            {
                int i = 0;
                foreach (Analyse ligne in bds_Analyse.List as List<Analyse>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_Analyse.Position = i;
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
        public Frm_AnalyseSimplifie()
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
            //if (dgv_Liste.SelectedRows != null &&
            //    dgv_Liste.SelectedRows.Count > 0)
            //{
            //    RadMessageBox.ThemeName = this.ThemeName;
            //    if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne " +
            //        "sélectionnée", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
            //        RadMessageIcon.Question) == DialogResult.Yes)
            //    {
            //        FormeJuridique obj = (FormeJuridique)bds_Analyse.Current;
            //        string res = obj.Delete();
            //         message = LGC.Business.Tools.SplitMessage(res);
            //        if (int.Parse(message[0]) > 0)
            //        {
            //            ChargerListe((FormeJuridique)bds_Analyse.Current);
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
            ChargerListe((Analyse)bds_Analyse.Current);
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            Analyse obj = new Analyse();
            
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
                RadMessageBox.Show(this, "La saisie du libelle est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_Libelle.Focus();
                return;
            }

            if (meb_cout.Text.Trim() == "0")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du cout est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_cout.Focus();
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
                    oAnalyse = obj;
                    ChargerListe(obj);
                    activerDesactiverControle(false);
                    nouveau = false;
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                        MessageBoxButtons.OK, RadMessageIcon.Info);

                    this.Close();
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
                obj = (Analyse)bds_Analyse.Current;
                constituerObjet(obj);
                sortie = obj.Update();
                 message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    oAnalyse = obj;
                    activerDesactiverControle(false);
                    nouveau = false;
                    ChargerListe((Analyse)bds_Analyse.Current);
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.Close();
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
        private void bds_FormeJuridique_CurrentChanged(object sender, EventArgs e)
        {
            
        } 
        #endregion

        #region DataGridView
        private void dgv_Liste_Resize(object sender, EventArgs e)
        {
            //if (dgv_Liste.Width > 650)
            //{
            //    dgv_Liste.Columns["LibelleFormeJuridique"].Width = dgv_Liste.Width -
            //        dgv_Liste.Columns["CodeFormeJuridique"].Width - 7;
            //}
            //else
            //{
            //    dgv_Liste.Columns["LibelleFormeJuridique"].Width = 505;
            //    dgv_Liste.Columns["CodeFormeJuridique"].Width = 138;
            //}
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
        #endregion

        private void dgv_Liste_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            //this.dgv_Liste.EnableAlternatingRowColor = true;
            //this.dgv_Liste.TableElement.AlternatingRowColor = Color.LightGoldenrodYellow;
        }
    }
}
