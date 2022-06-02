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

namespace LGC.UI.Parametre
{
    public partial class Frm_SecteurActivite : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        string[] message;
        List<SecteurActivite> lstSecteurActivite = new List<SecteurActivite>();
        #endregion

        #region Autres
        private void activerDesactiverControle(bool condition)
        {
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
            txt_Libelle.Text = "";
        }

        private void constituerObjet(SecteurActivite obj)
        {
            obj.LibelleSecteurActivite = txt_Libelle.Text.Trim();
        }

        private void detaillerObjet(SecteurActivite obj)
        {
            txt_Libelle.Text = obj.LibelleSecteurActivite.Trim();
        }

        private void ChargerListe(SecteurActivite obj)
        {
            lstSecteurActivite = SecteurActivite.Liste(null,null,null,
                null,null,null,false,null);
            bds_SecteurActivite.DataSource = lstSecteurActivite;
            if (obj != null)
            {
                int i = 0;
                foreach (SecteurActivite ligne in bds_SecteurActivite.List as List<SecteurActivite>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_SecteurActivite.Position = i;
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
        public Frm_SecteurActivite()
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
            txt_Libelle.Focus();
        }

        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (dgv_Liste.SelectedRows != null &&
                dgv_Liste.SelectedRows.Count > 0)
            {
                //nouveau = false;
                //activerDesactiverControle(true);
                //txt_code.ReadOnly = true;
                //txt_Libelle.Focus();
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
                    SecteurActivite obj = (SecteurActivite)bds_SecteurActivite.Current;
                    string res = obj.Delete();
                     message = LGC.Business.Tools.SplitMessage(res);
                    if (int.Parse(message[0]) > 0)
                    {
                        ChargerListe((SecteurActivite)bds_SecteurActivite.Current);
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
            ChargerListe((SecteurActivite)bds_SecteurActivite.Current);
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            SecteurActivite obj = new SecteurActivite();
            
            #region controle de saisie

            if (txt_Libelle.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du nom est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_Libelle.Focus();
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
                obj = (SecteurActivite)bds_SecteurActivite.Current;
                constituerObjet(obj);
                sortie = obj.Update();
                 message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    activerDesactiverControle(false);
                    nouveau = false;
                    ChargerListe((SecteurActivite)bds_SecteurActivite.Current);
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
        private void bds_SecteurActivite_CurrentChanged(object sender, EventArgs e)
        {
            
        } 
        #endregion

        #region DataGridView
        private void dgv_Liste_Resize(object sender, EventArgs e)
        {
            if (dgv_Liste.Width > 650)
            {
                dgv_Liste.Columns["LibelleSecteurActivite"].Width = dgv_Liste.Width-4;
            }
            else
            {
                dgv_Liste.Columns["LibelleSecteurActivite"].Width = 646;
            }
        }

        private void dgv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (bds_SecteurActivite.Current != null)
            {
                detaillerObjet((SecteurActivite)bds_SecteurActivite.Current);
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
