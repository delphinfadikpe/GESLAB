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
    public partial class Frm_SecteursBiologique : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        string[] message;
        List<SecteursBiologique> lstSecteursBiologique = new List<SecteursBiologique>();
        List<CategorieIntrant> lstCategorieIntrant = new List<CategorieIntrant>();
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
           
        }
        private void constituerObjetCategorieIntrant(CategorieIntrant obj)
        {
            obj.CodeCategorie = txt_Code.Text.Trim();
            obj.LibelleCategorie = txt_Libelle.Text.Trim();

        }
        private void constituerObjet(SecteursBiologique obj)
        {
            obj.CodeSecteur = txt_Code.Text.Trim();
            obj.LibelleSecteur = txt_Libelle.Text.Trim();
            
        }

        private void detaillerObjet(SecteursBiologique obj)
        {
            txt_Code.Text = obj.CodeSecteur.Trim();
            txt_Libelle.Text = obj.LibelleSecteur.Trim();
           
        }

        private void ChargerListe(SecteursBiologique obj)
        {
            lstSecteursBiologique = SecteursBiologique.Liste(null,
                null, null, null, null,null,null, false, null);
            bds_SecteursBiologique.DataSource = lstSecteursBiologique;
            if (obj != null)
            {
                int i = 0;
                foreach (SecteursBiologique ligne in bds_SecteursBiologique.List as List<SecteursBiologique>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_SecteursBiologique.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        private void ChargerListeCategorieIntrant()
        {
            lstCategorieIntrant = CategorieIntrant.Liste(null,
                  null, null, null, null, null, null, false, null);
        }
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }
        #endregion

        #region Formulaire
        public Frm_SecteursBiologique()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new FrenchRadGridLocalizationProvider();
            this.ThemeName = LGC.Business.CurrentUser.ThemeName;
        }

        private void Frm_Matières_Load(object sender, EventArgs e)
        {
           
            activerDesactiverControle(false);
            ChargerListe(null);
            ChargerListeCategorieIntrant();
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
                    SecteursBiologique obj = (SecteursBiologique)bds_SecteursBiologique.Current;
                    CategorieIntrant objCate = new CategorieIntrant();
                    objCate = lstCategorieIntrant.Find(x => x.CodeCategorie.Trim() ==
                     obj.CodeSecteur.Trim());
                    objCate.Delete();
                    string res = obj.Delete();
                     message = LGC.Business.Tools.SplitMessage(res);
                    if (int.Parse(message[0]) > 0)
                    {
                        ChargerListe((SecteursBiologique)bds_SecteursBiologique.Current);
                        ChargerListeCategorieIntrant();
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
            ChargerListe((SecteursBiologique)bds_SecteursBiologique.Current);
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            SecteursBiologique obj = new SecteursBiologique();
            CategorieIntrant objCate = new CategorieIntrant();
            
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

           
            #endregion

            #region Enregistrement
            if (nouveau)
            {
                constituerObjet(obj);
                constituerObjetCategorieIntrant(objCate);
                objCate.Insert();
                sortie = obj.Insert();
                 message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length-1].Trim());
                    ChargerListe(obj);
                    ChargerListeCategorieIntrant();
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
                obj = (SecteursBiologique)bds_SecteursBiologique.Current;
                objCate = lstCategorieIntrant.Find(x => x.CodeCategorie.Trim() ==
                    obj.CodeSecteur.Trim());
                constituerObjet(obj);
                constituerObjetCategorieIntrant(objCate);
                objCate.Update();
                sortie = obj.Update();
                 message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    activerDesactiverControle(false);
                    nouveau = false;
                    ChargerListe((SecteursBiologique)bds_SecteursBiologique.Current);
                    ChargerListeCategorieIntrant();
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
        private void bds_SecteursBiologique_CurrentChanged(object sender, EventArgs e)
        {
            
        } 
        #endregion

        #region DataGridView
        private void dgv_Liste_Resize(object sender, EventArgs e)
        {
            if (dgv_Liste.Width > 650)
            {
                dgv_Liste.Columns["NomSecteursBiologique"].Width = dgv_Liste.Width -
                    dgv_Liste.Columns["CodeSecteursBiologique"].Width - 7;
            }
            else
            {
                dgv_Liste.Columns["NomSecteursBiologique"].Width = 505;
                dgv_Liste.Columns["CodeSecteursBiologique"].Width = 138;
            }
        }

        private void dgv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Liste.SelectedRows != null &&
                dgv_Liste.SelectedRows.Count > 0)
            {
                detaillerObjet((SecteursBiologique)bds_SecteursBiologique.Current);
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
