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

namespace LGC.UI.Parametre
{
    public partial class Frm_Antibiotiques : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        string[] message;
        List<Antibiotiques> lstAntibiotiques = new List<Antibiotiques>();
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

        private void constituerObjet(Antibiotiques obj)
        {
            obj.Code = txt_Code.Text.Trim();
            obj.Libelle = txt_Libelle.Text.Trim();
            obj.Type = "";
        }

        private void detaillerObjet(Antibiotiques obj)
        {
            txt_Code.Text = obj.Code.Trim();
            txt_Libelle.Text = obj.Libelle.Trim();
        }

        private void ChargerListe(Antibiotiques obj)
        {
            lstAntibiotiques = Antibiotiques.Liste(null, null, null, null, null,
                null, null,null, false, null);
            bds_Antibitotique.DataSource = lstAntibiotiques;
            if (obj != null)
            {
                int i = 0;
                foreach (Antibiotiques ligne in bds_Antibitotique.List as List<Antibiotiques>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_Antibitotique.Position = i;
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
        public Frm_Antibiotiques()
        {
            InitializeComponent();
        }

        private void Frm_Langue_Load(object sender, EventArgs e)
        {
            activerDesactiverControle(false);
            ChargerListe(null);
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
            //        Langue obj = (Langue)bds_Langue.Current;
            //        string res = obj.Delete();
            //        message =LGC.Business.Tools.SplitMessage(res);
            //        if (int.Parse(message[0]) > 0)
            //        {
            //            ChargerListe((Langue)bds_Langue.Current);
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
            ChargerListe((Antibiotiques)bds_Antibitotique.Current);
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            Antibiotiques obj = new Antibiotiques();

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
                sortie = obj.Insert();
                message =LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
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
                obj = (Antibiotiques)bds_Antibitotique.Current;
                constituerObjet(obj);
                sortie = obj.Update();
                message =LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    activerDesactiverControle(false);
                    nouveau = false;
                    ChargerListe((Antibiotiques)bds_Antibitotique.Current);
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
        private void bds_Langue_CurrentChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region DataGridView
        //private void dgv_Liste_Resize(object sender, EventArgs e)
        //{
        //    if (dgv_Liste.Width > 650)
        //    {
        //        dgv_Liste.Columns["libelleLangue"].Width = dgv_Liste.Width -
        //            dgv_Liste.Columns["codeLangue"].Width - 7;
        //    }
        //    else
        //    {
        //        dgv_Liste.Columns["libelleLangue"].Width = 505;
        //        dgv_Liste.Columns["codeLangue"].Width = 138;
        //    }
        //}

        private void dgv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Liste.SelectedRows != null &&
                dgv_Liste.SelectedRows.Count > 0)
            {
                detaillerObjet((Antibiotiques)bds_Antibitotique.Current);
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
    }
}
