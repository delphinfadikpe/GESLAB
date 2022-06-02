using LGC.Business;
using LGC.Business.Parametre;
using LGC.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace LGG.UI.Parametre
{
    public partial class Frm_TypeInventaire : RadForm
    {
        #region Declaration
        public List<TypeInventaire> lstTypeInventaire = new List<TypeInventaire>();
        public bool nouveau = false;
        string sortie;
        string[] message;

        #endregion

        #region Autres
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }

        public void Bloquerdebloquer(bool etat)
        {
            txt_code.ReadOnly = etat;
            txt_libelle.ReadOnly = etat;

            gv_Liste.Enabled = etat;

            btn_Nouveau.Visible = etat;
            btn_Modifier.Visible = etat;
            btn_Annuler.Visible = !etat;
            btn_Enregistrer.Visible = !etat;
            btn_Supprimer.Enabled = etat;
            btn_Actualiser.Enabled = etat;
        }
        private void Viderchamp()
        {
            txt_code.Text = "";
            txt_libelle.Text = "";
        }
        private void creerObjet(TypeInventaire obj)
        {
            obj.CodeTypeInventaire = txt_code.Text;
            obj.LibelleTypeInventaire = txt_libelle.Text;
        }
        private void Detailler(TypeInventaire obj)
        {
            txt_code.Text = obj.CodeTypeInventaire;
            txt_libelle.Text = obj.LibelleTypeInventaire;
        }
        private void ChargerDonnes(TypeInventaire obj)
        {
            lstTypeInventaire = TypeInventaire.Liste(null, null, null, null, null, null, null, false, null);
            bds_typeInventaire.DataSource = lstTypeInventaire;
            if (obj != null)
            {
                int i = 0;
                foreach (TypeInventaire ligne in bds_typeInventaire.List as List<TypeInventaire>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_typeInventaire.Position = i;
                        break;
                    }
                    else
                        i++;
                }
            }
        }
        #endregion

        #region Formulaire
        public Frm_TypeInventaire()
        {
            InitializeComponent();
            
            RadGridLocalizationProvider.CurrentProvider = new FrenchRadGridLocalizationProvider();
     
        }

        private void Frm_TypeInventaire_Load(object sender, EventArgs e)
        {
            Bloquerdebloquer(true);
            ChargerDonnes(null);
            if (nouveau)
                btn_Modifier_Click(null, null);
        }
        #endregion

        #region Boutons
        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne sélectionnée?", "GESCOM",
                MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    TypeInventaire obj = (TypeInventaire)bds_typeInventaire.Current;
                    sortie = obj.Delete();
                    message = Tools.SplitMessage(sortie);
                    if (int.Parse(message[0]) > 0)
                    {
                        ChargerDonnes(null);
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), "GESCOM", MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    else
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), "GESCOM", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
            }
        }
        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            TypeInventaire obj = new TypeInventaire();

            #region Controle de saisie
            if (txt_code.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du CODE est obligatoire",
                    "GESCOM", MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_code.Focus();
                return;
            }
            if (txt_libelle.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du DENOMITION est obligatoire",
                    "GESCOM", MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_libelle.Focus();
                return;
            }

            #endregion

            #region Enregistrement
            if (nouveau)
            {
                creerObjet(obj);
                sortie = obj.Insert();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    Bloquerdebloquer(true);
                    nouveau = false;
                    ChargerDonnes(obj);
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "GESCOM",
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }
            #endregion

            #region Modification
            else
            {
                obj = (TypeInventaire)bds_typeInventaire.Current;
                creerObjet(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1] != "")
                {
                    Bloquerdebloquer(true);
                    ChargerDonnes(obj);
                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "GESCOM",
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);

            }
            #endregion
        }
        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                Bloquerdebloquer(false);
                txt_code.ReadOnly = true;
                txt_libelle.Focus();
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veillez sélèctioner une ligne avant la modification",
                    "GESCOM", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = (true);
            Viderchamp();
            Bloquerdebloquer(false);
            txt_code.Focus();
        }
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            Bloquerdebloquer(true);
            Viderchamp();
            ChargerDonnes((TypeInventaire)bds_typeInventaire.Current);
        }
        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            TypeInventaire obj = (TypeInventaire)bds_typeInventaire.Current;
            ChargerDonnes(obj);
        }
        #endregion

        #region DataGridView
        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                Detailler((TypeInventaire)bds_typeInventaire.Current);
            }
            else
            {
                Viderchamp();
            }
        }
        #endregion
    }
}
