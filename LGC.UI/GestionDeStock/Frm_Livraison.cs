using LGC.Business;
using LGC.Business.GestionDeStock;
using LGC.Business.Parametre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace LGC.UI.GestionDeStock
{
    public partial class Frm_Livraison : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        string[] message;
        
        List<Intrants> lstIntrants = new List<Intrants>();
      List<IntrantLivrer> lstIntrantLivrer = new List<IntrantLivrer>();
       
        List<CommandeIntrant> lstCommandeIntrant = new List<CommandeIntrant>();
        List<Livraison> lstLivraison = new List<Livraison>();
        List<IntrantCommander> lstIntrantCommander = new List<IntrantCommander>();
        #endregion

        #region Autres
         private void ChargerListe(Livraison obj)
        {
            lstLivraison = Livraison.Liste(null, null, null, null, null, null, null, null, null, false, null, null, null, null, null, false, null);
            bds_Livraison.DataSource = lstLivraison;
            if (obj != null)
            {
                int i = 0;
                foreach (Livraison ligne in bds_Livraison.List as List<Livraison>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_Livraison.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        private void ChargerListeIntrant()
        {
            lstIntrants = Intrants.Liste(null, null,null, null, null, null, null, null, null, null, null, null, false, null, null);
            //bds_Intrants.DataSource = lstIntrants;
        }
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }


        public void Bloquerdebloquer(bool etat)
        {
            //txt_Code.ReadOnly = etat;
           
            dtp_dateLivraison.ReadOnly = etat;
            mcb_Commandes.Enabled = !etat;
            
            lbl_tva.ReadOnly = etat;
            meb_remise.ReadOnly = etat;
            lbl_aib.ReadOnly = etat;
            gv_Liste.Enabled = etat;
            btn_Nouveau.Visible = etat;
            btn_Modifier.Visible = etat;
            btn_Annuler.Visible = !etat;
            btn_Enregistrer.Visible = !etat;
            btn_Supprimer.Enabled = etat;
            btn_Actualiser.Enabled = etat;
            dgv_ListeIntrantShow.Visible = etat;
            dgv_ListeIntrantShow.BringToFront();
            dgv_intrant.Visible = !etat;
            dgv_intrant.BringToFront();
            
           
        }
        public void BloquerdebloquerBoutonIntrant(bool etat)
        {
            mcb_intrant.Enabled = !etat;
            meb_qteLivre.ReadOnly = etat;
            meb_prixRevient.ReadOnly = etat;
            btn_AjouterIntrant.Visible = etat;
            btn_AnnuleIntrant.Visible = !etat;
            btn_SaveIntrant.Visible = !etat;
            btn_SupprimerIntrant.Visible = etat;
            dgv_intrant.Enabled = etat;
        }
        private void Viderchamp()
        {
           
            txt_num.Text = "EN CREATION";
           dtp_dateLivraison.Value = DateTime.Now;
            mcb_Commandes.Text = "";
            meb_montantBrut.Value = 0;
            meb_TVA.Value = 0;
            meb_remise.Value = 0;
            meb_AIB.Value = 0;
            lbl_tva.Text = "TVA(%)";
            lbl_aib.Text = "AIB(%)";
            dgv_ListeIntrantShow.Rows.Clear();
           
        }

        private void ViderchampIntrant()
        {
            
            
            meb_qteLivre.Value = 0;
            meb_qteRestante.Value = 0;
            meb_qteDejaLivree.Value = 0;
            meb_qteCommande.Value = 0;
            meb_prixRevient.Value = 0;
            meb_montantBrutLigne.Value = 0;
            mcb_intrant.Text = "";
            dgv_intrant.Rows.Clear();

        }

        private void ViderchampIntrantSimple()
        {
            meb_qteLivre.Value = 0;
            meb_qteRestante.Value = 0;
            meb_qteDejaLivree.Value = 0;
            meb_qteCommande.Value = 0;
            meb_prixRevient.Value = 0;
            meb_montantBrutLigne.Value = 0;
            mcb_intrant.Text = "";
            

        }
        private void creerObjetLivraison(Livraison obj)
        {

            obj.DateLivraison = dtp_dateLivraison.Value;
            obj.TVA = lbl_tva.Text.Trim() == "TVA(%)" ? 0 : Convert.ToDecimal(lbl_tva.Text.ToString().Substring(4, lbl_tva.Text.ToString().Length - 6));
            obj.MotantBrut = Convert.ToDecimal(meb_montantBrut.Value);
            obj.AIB = lbl_aib.Text.Trim() == "AIB(%)" ? 0 :  Convert.ToDecimal(lbl_aib.Text.ToString().Substring(4, lbl_aib.Text.ToString().Length - 6));
            obj.Remise = Convert.ToDecimal(meb_remise.Value);
            obj.MontantNet = Convert.ToDecimal(meb_montantNet.Value);
            obj.EstAnnule = false;
            obj.DateAnnulation = Convert.ToDateTime("01/01/2050");
            obj.MotifAnnulation = "";

           
        }

        private void creerObjetIntrantLivrer(IntrantLivrer obj, decimal numLivraison, int l)
        {
            obj.NumLivraison = numLivraison;
            obj.NumCommande= Convert.ToDecimal(mcb_Commandes.Text.Trim());
            obj.CodeIntrant = dgv_intrant.Rows[l].Cells["codeIntrant"].Value.ToString();
            obj.QteLivree = Convert.ToDecimal(dgv_intrant.Rows[l].Cells["qteLivree"].Value.ToString());
            obj.PrixRevient = Convert.ToDecimal(dgv_intrant.Rows[l].Cells["prixRevient"].Value.ToString());
            obj.MontantBrut = Convert.ToDecimal(dgv_intrant.Rows[l].Cells["montantBrut"].Value.ToString());
            obj.CodeTypeCoffret = Convert.ToString(dgv_intrant.Rows[l].Cells["codeTypeCoffret"].Value.ToString());
        }
        private void DetaillerLivraison(Livraison obj)
        {
            txt_num.Text = Convert.ToString(obj.NumLivraison);
            dtp_dateLivraison.Value = obj.DateLivraison;
            meb_remise.Value = Convert.ToDecimal(obj.Remise);
            meb_TVA.Value = Convert.ToDecimal(obj.TVA) * (Convert.ToDecimal(obj.MotantBrut) - Convert.ToDecimal(obj.Remise)) / 100;
            lbl_tva.Text = "TVA(" + Convert.ToInt32(obj.TVA) + ")";
            meb_AIB.Value = Convert.ToDecimal(obj.AIB) * (Convert.ToDecimal(obj.MotantBrut) - Convert.ToDecimal(obj.Remise)) / 100;
            lbl_aib.Text = "AIB(" + Convert.ToInt32(obj.AIB) + ")";
            meb_montantHT.Value = Convert.ToDecimal(obj.MotantBrut)
                - Convert.ToDecimal(meb_remise.Value);
            meb_montantNet.Value = Convert.ToDecimal(meb_montantHT.Value)
                + Convert.ToDecimal(meb_TVA.Value)  - Convert.ToDecimal(meb_AIB.Value);
            meb_montantBrut.Value = Convert.ToDecimal(obj.MotantBrut);
            ChargerListeIntrantLivrer(obj);
           
        }

        private void DetaillerIntrantLivrer(IntrantLivrer obj)
        {
            mcb_intrant.Text = lstIntrants.Find(l => l.CodeIntrant.Trim()
            == obj.CodeIntrant).LibelleIntrant;
            meb_qteLivre.Value = obj.QteLivree;
            meb_prixRevient.Value = obj.PrixRevient;
            meb_montantBrutLigne.Value = obj.MontantBrut;
            meb_qteCommande.Value = lstIntrantCommander.Find(l => l.CodeIntrant.Trim()
            == obj.CodeIntrant).QteCommande;
            meb_qteRestante.Value = lstIntrantCommander.Find(l => l.CodeIntrant.Trim()
            == obj.CodeIntrant).QteRestante;
            meb_qteDejaLivree.Value = lstIntrantCommander.Find(l => l.CodeIntrant.Trim()
            == obj.CodeIntrant).QteLivree;

        }
        private void DetaillerIntrantLivrerDragDrop()
        {
            mcb_intrant.Text = dgv_intrant.CurrentRow.Cells["Libelle"].Value.ToString().Trim();
            meb_qteLivre.Value = dgv_intrant.CurrentRow.Cells["qteLivree"].Value.ToString().Trim();
            meb_prixRevient.Value = dgv_intrant.CurrentRow.Cells["prixRevient"].Value.ToString().Trim();
            meb_montantBrutLigne.Value = dgv_intrant.CurrentRow.Cells["montantBrut"].Value.ToString().Trim();
            meb_qteCommande.Value = dgv_intrant.CurrentRow.Cells["qteCommandee"].Value.ToString().Trim();
            meb_qteRestante.Value = dgv_intrant.CurrentRow.Cells["qteRestante"].Value.ToString().Trim();
        }

        private void ChargerGrilleIntrant()
        {
            int index = dgv_intrant.Rows.Count;

            GridViewRowInfo newRow = dgv_intrant.Rows.NewRow();
            newRow.Cells["codeIntrant"].Value = lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                mcb_intrant.Text.Trim()).CodeIntrant.Trim();
            newRow.Cells["Libelle"].Value = mcb_intrant.Text.Trim();
            newRow.Cells["qteLivree"].Value = meb_qteLivre.Value;
            newRow.Cells["prixRevient"].Value = meb_prixRevient.Value;
            newRow.Cells["montantBrut"].Value = meb_montantBrutLigne.Value;
            newRow.Cells["qteRestante"].Value = meb_qteRestante.Value;
            newRow.Cells["qteCommandee"].Value = meb_qteCommande.Value;
            newRow.Cells["codeTypeCoffret"].Value = rddl_typeCoffret.SelectedValue;
            newRow.Cells["libelleTypeCoffret"].Value = rddl_typeCoffret.Text;
            dgv_intrant.Rows.Insert(index, newRow);

        }

        private void ChargerListeIntrantLivrer(Livraison obj)
        {
            lstIntrantLivrer = IntrantLivrer.Liste(null, null, obj.NumLivraison, null,
                null, null, null,null,  null,null,null,null,false,null);
            mcb_Commandes.Text = lstIntrantLivrer.Count != 0 ? lstIntrantLivrer[0].NumCommande.ToString().Trim() : "";
            bds_IntrantLivrer.DataSource = lstIntrantLivrer;
        }
        private void ChargerListeCommandeIntrant()
        {
            lstCommandeIntrant = CommandeIntrant.Liste(null, null, null, null, null, null, null, false, null, null, null, null, null, null, null, false, null);
            bds_CommandeIntrant.DataSource = lstCommandeIntrant;
        }
        private void ChargerListeIntrantCommande(decimal numCommande)
        {
            
                lstIntrantCommander = IntrantCommander.Liste(numCommande, null, null, null,
              null, null, null,null, null, null, null, null, null, false, null);
                bds_IntrantCommande.DataSource = lstIntrantCommander;
            
           
        }

        //private void ChargerListeIntrantCommande(CommandeIntrant obj)
        //{
        //    lstIntrantCommander = IntrantCommander.Liste(obj.NumCommande, null, null, null,
        //       null, null, null, null, null, null, null, null, false, null);
        //    bds_IntrantCommande.DataSource = lstIntrantCommander;
        //}

        private void Calculer()
        {
            decimal montantHT = 0;
            for (int i = 0; i < dgv_intrant.RowCount; i++)
            {
                montantHT += Convert.ToDecimal(dgv_intrant.Rows[i].Cells["montantBrut"].Value.ToString().Trim());
            }
            meb_montantBrut.Value = montantHT;
            meb_montantHT.Value = montantHT  - Convert.ToDecimal(meb_remise.Value);
            meb_montantNet.Value = Convert.ToDecimal(meb_montantHT.Value) - Convert.ToDecimal(meb_AIB.Value) + Convert.ToDecimal(meb_TVA.Value);
        }

       
        #endregion

        #region Formulaire
        public Frm_Livraison()
        {
            InitializeComponent();
        }

        private void Frm_MAJTitre_Load(object sender, EventArgs e)
        {
            ChargerListeCommandeIntrant();
            ChargerListeIntrant();
            ChargerListe(null);
            Bloquerdebloquer(true);
            BloquerdebloquerBoutonIntrant(true);
            btn_AjouterIntrant.Visible = true;
            btn_AjouterIntrant.BringToFront();
            btn_AjouterIntrant.Enabled = false;
            btn_SaveIntrant.Visible = false;
            btn_SupprimerIntrant.Visible = true;
            btn_SupprimerIntrant.BringToFront();
            btn_SupprimerIntrant.Enabled = false;
            btn_AnnuleIntrant.Visible = false;
        } 
        #endregion

        #region Bouton de commande
        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            Livraison obj = (Livraison)bds_Livraison.Current;
        }

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
               
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voullez-vous vraiment supprimer la ligne sélectionnée?", CurrentUser.LogicielHote,
                MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    //CommandeIntrant obj = (CommandeIntrant)bds_CommandeIntrant.Current;
                    //sortie = obj.Delete();
                    //message = Tools.SplitMessage(sortie);
                    //if (int.Parse(message[0]) > 0)
                    //{
                    //    Viderchamp();
                    //    ChargerListe(null);
                    //    RadMessageBox.ThemeName = this.ThemeName;
                    //    RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                    //}
                    //else
                    //{
                    //    RadMessageBox.ThemeName = this.ThemeName;
                    //    RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    //}
                }
            }
        }
        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            Livraison obj = new Livraison();
            IntrantLivrer objIntrantLivrer = new IntrantLivrer();

            #region Controle de saisie

            if (mcb_Commandes.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez renseigner la commande",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                mcb_Commandes.Focus();
                return;
            }

            if (dgv_intrant.RowCount == 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez renseigner le(s) intrant(s) livrée(s)",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                dgv_intrant.Focus();
                return;
            }

            if (rddl_typeCoffret.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez sélectionner une valeur pour le type de coffret",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                rddl_typeCoffret.Focus();
                return;
            }
            #endregion

            #region Enregistrement
            if (nouveau)
            {
                creerObjetLivraison(obj);
                sortie = obj.Insert();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {

                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    for (int i = 0; i < dgv_intrant.RowCount; i++)
                    {
                        creerObjetIntrantLivrer(objIntrantLivrer, obj.NumLigne, i);
                        objIntrantLivrer.Insert();
                    }

                    Bloquerdebloquer(true);
                    BloquerdebloquerBoutonIntrant(true);
                    btn_AjouterIntrant.Visible = true;
                    btn_AjouterIntrant.BringToFront();
                    btn_AjouterIntrant.Enabled = false;
                    btn_SaveIntrant.Visible = false;
                    btn_SupprimerIntrant.Visible = true;
                    btn_SupprimerIntrant.BringToFront();
                    btn_SupprimerIntrant.Enabled = false;
                    btn_AnnuleIntrant.Visible = false;
                    nouveau = false;
                    ChargerListe(obj);
                    mcb_Commandes_TextChanged(null, null);
                   

                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), CurrentUser.LogicielHote,
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }


            #endregion

            #region Modification
            else
            {
                obj = (Livraison)bds_Livraison.Current;
                creerObjetLivraison(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    for (int i = 0; i < dgv_intrant.RowCount; i++)
                    {
                        creerObjetIntrantLivrer(objIntrantLivrer, obj.NumLigne, i);
                        objIntrantLivrer.Insert();
                    }

                    Bloquerdebloquer(true);
                    BloquerdebloquerBoutonIntrant(true);
                    btn_AjouterIntrant.Visible = true;
                    btn_AjouterIntrant.BringToFront();
                    btn_AjouterIntrant.Enabled = false;
                    btn_SaveIntrant.Visible = false;
                    btn_SupprimerIntrant.Visible = true;
                    btn_SupprimerIntrant.BringToFront();
                    btn_SupprimerIntrant.Enabled = false;
                    btn_AnnuleIntrant.Visible = false;
                    nouveau = false;
                    ChargerListe(obj);
                    mcb_Commandes_TextChanged(null, null);

                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), CurrentUser.LogicielHote,
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);


            }
            #endregion




        }
        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
              

                //Bloquerdebloquer(false);
                //nouveau = false;

            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veillez sélèctioner une ligne avant la modification",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = (true);
            Viderchamp();
            ViderchampIntrant();
            Bloquerdebloquer(false);
            BloquerdebloquerBoutonIntrant(false);
            btn_AjouterIntrant.Enabled = true;
            btn_SupprimerIntrant.Enabled = true;
           

        }
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            Bloquerdebloquer(true);
            Viderchamp();
            ViderchampIntrant();
            btn_AjouterIntrant.Visible = true;
            btn_AjouterIntrant.BringToFront();
            btn_AjouterIntrant.Enabled = false;
            btn_SaveIntrant.Visible = false;
            btn_SupprimerIntrant.Visible = true;
            btn_SupprimerIntrant.BringToFront();
            btn_SupprimerIntrant.Enabled = false;
            btn_AnnuleIntrant.Visible = false;
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                ChargerListe((Livraison)bds_Livraison.Current);
            }
        }

        #endregion


        #region DataGridView
        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                
                DetaillerLivraison((Livraison)bds_Livraison.Current);
               
            }
            else
            {
                Viderchamp();
                ViderchampIntrant();
            }
        }
        #endregion


        private void btn_AnnuleIntrant_Click(object sender, EventArgs e)
        {
            BloquerdebloquerBoutonIntrant(true);
            ViderchampIntrantSimple();
            if (dgv_intrant.SelectedRows != null && dgv_intrant.SelectedRows.Count != 0)
            {
                DetaillerIntrantLivrerDragDrop();
            }
            else
                ViderchampIntrantSimple();
        }

        private void dgv_ListeIntrantShow_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeIntrantShow.SelectedRows != null && dgv_ListeIntrantShow.SelectedRows.Count != 0)
            {
                DetaillerIntrantLivrer((IntrantLivrer)bds_IntrantLivrer.Current);
            }
             else
            {
               
                ViderchampIntrantSimple();
            }
        }

        private void btn_SaveIntrant_Click(object sender, EventArgs e)
        {
            #region Controle de saisie

            if (mcb_intrant.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez sélectionner l'intrant",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                mcb_intrant.Focus();
                return;
            }

            if (meb_qteLivre.Text.Trim() == "0" || meb_qteLivre.Text.Trim() == "") 
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez renseigner la quantité livré",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_qteLivre.Focus();
                return;
            }

            if (meb_prixRevient.Text.Trim() == "0" || meb_prixRevient.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez renseigner le prix de revient de l'intrant",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_prixRevient.Focus();
                return;
            }
            decimal qteRestanteGrille = 0;
            for (int i = 0; i < dgv_intrant.RowCount; i++)
            {
                Intrants obj = lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                    mcb_intrant.Text.Trim());
                if (obj != null)
                {
                    if (dgv_intrant.Rows[i].Cells["codeIntrant"].Value.ToString().Trim() ==
                    (lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                mcb_intrant.Text.Trim()).CodeIntrant.Trim()))
                    {
                        qteRestanteGrille += Convert.ToDecimal(dgv_intrant.Rows[i].Cells["qteLivree"].Value.ToString().Trim());
                    }
               
                }
                
            }
            if (Convert.ToDecimal(meb_qteLivre.Value) > Convert.ToDecimal(meb_qteCommande.Value) - Convert.ToDecimal(meb_qteDejaLivree.Value) - qteRestanteGrille)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La quantité livrée ne doit pas être supérieure à la quantité restante",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_qteLivre.Focus();
                return;
            }

            #endregion
            ChargerGrilleIntrant();
            BloquerdebloquerBoutonIntrant(true);
            Calculer();
        }

        private void mcb_intrant_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bds_IntrantCommander_1.DataSource = IntrantCommander.Liste(Convert.ToDecimal(mcb_Commandes.Text.Trim()),
                    lstIntrantCommander.Find(l => l.Intrant.Trim() == mcb_intrant.Text.Trim()).CodeIntrant.Trim(),
                    null, null, null, null, null, null, null, null, null, null, null, false, null);
                rddl_typeCoffret_SelectedIndexChanged(null,null);
            }
            catch { }
          
        }

        private void meb_qteCommande_TextChanged(object sender, EventArgs e)
        {
            meb_montantBrutLigne.Value = Convert.ToDecimal(meb_qteLivre.Value) * Convert.ToDecimal(meb_prixRevient.Value);
        }

        private void meb_prixUnitaire_TextChanged(object sender, EventArgs e)
        {
            meb_montantBrutLigne.Value = Convert.ToDecimal(meb_qteLivre.Value) * Convert.ToDecimal(meb_prixRevient.Value);
        }

        private void btn_AjouterIntrant_Click(object sender, EventArgs e)
        {
            ViderchampIntrantSimple();
            BloquerdebloquerBoutonIntrant(false);
        }

        private void btn_SupprimerIntrant_Click(object sender, EventArgs e)
        {
            if (dgv_intrant.SelectedRows != null && dgv_intrant.SelectedRows.Count != 0)
            {
                dgv_intrant.Rows.RemoveAt(dgv_intrant.CurrentRow.Index);
            }
            
        }

        private void dgv_intrant_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_intrant.SelectedRows != null && dgv_intrant.SelectedRows.Count != 0)
            {
                DetaillerIntrantLivrerDragDrop();
            }
            else
            {
                ViderchampIntrantSimple();
            }
        }

        private void meb_TVA_ValueChanged(object sender, EventArgs e)
        {
            if (meb_TVA.ReadOnly ==false)
            {
                Calculer();
            }
           
        }

        private void meb_remise_ValueChanged(object sender, EventArgs e)
        {
            if (lbl_tva.ReadOnly == false)
            {
                Calculer();
            }
        }

        private void meb_AIB_ValueChanged(object sender, EventArgs e)
        {
            if (lbl_tva.ReadOnly == false)
            {
                Calculer();
            }
        }

        private void meb_TVA_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void mcb_Commandes_TextChanged(object sender, EventArgs e)
        {
            if (mcb_Commandes.Text.Trim() != string.Empty)
            {
                ChargerListeIntrantCommande(Convert.ToDecimal(mcb_Commandes.Text.Trim()));
            }
               
            
        }

        private void meb_prixRevient_ValueChanged(object sender, EventArgs e)
        {
            meb_montantBrutLigne.Value = Convert.ToDecimal(meb_qteLivre.Value) * Convert.ToDecimal(meb_prixRevient.Value);
        }

        private void meb_qteLivre_ValueChanged(object sender, EventArgs e)
        {
            decimal qteRestanteGrille = 0;
            for (int i = 0; i < dgv_intrant.RowCount; i++)
            {
                Intrants obj1 = lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                    mcb_intrant.Text.Trim());
                if (obj1 != null)
                {
                    if (dgv_intrant.Rows[i].Cells["codeIntrant"].Value.ToString().Trim() ==
                    (lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                    mcb_intrant.Text.Trim()).CodeIntrant))
                    {
                        qteRestanteGrille += Convert.ToDecimal(dgv_intrant.Rows[i].Cells["qteLivree"].Value.ToString().Trim());
                    }

                }

            }
            meb_montantBrutLigne.Value = Convert.ToDecimal(meb_qteLivre.Value) * Convert.ToDecimal(meb_prixRevient.Value);
            meb_qteRestante.Value = Convert.ToDecimal(meb_qteCommande.Value) - Convert.ToDecimal(meb_qteDejaLivree.Value) - Convert.ToDecimal(meb_qteLivre.Value) - qteRestanteGrille;
        }

        private void meb_TVA_Enter(object sender, EventArgs e)
        {
            //if (meb_TVA.ReadOnly == false)
            //{
            //    string var = lbl_tva.Text.ToString().Substring(4, lbl_tva.Text.ToString().Length - 6);
            //    meb_TVA.Value = lbl_tva.Text.ToString().IndexOf("%") == 4 ? 0 :
            //        Convert.ToDecimal(lbl_tva.Text.ToString().Substring(4, lbl_tva.Text.ToString().Length - 6));
            //}
        }

        private void meb_AIB_Enter(object sender, EventArgs e)
        {
            //if (meb_AIB.ReadOnly == false)
            //{
            //    meb_AIB.Value = lbl_aib.Text.ToString().IndexOf("%") == 4 ? 0 :
            //        Convert.ToDecimal(lbl_aib.Text.ToString().Substring(4, lbl_aib.Text.ToString().Length - 6));
            //}
        }

        private void meb_AIB_Leave(object sender, EventArgs e)
        {
            //if (meb_AIB.ReadOnly == false)
            //{
            //    lbl_aib.Text = Convert.ToDecimal(meb_AIB.Value) == 0 ? "AIB(%)" : "AIB(" + meb_AIB.Value + "%)";
            //    meb_AIB.Value = Convert.ToDecimal(lbl_aib.Text.ToString().IndexOf("%") == 4 ? 0 :
            //        Convert.ToDecimal(lbl_aib.Text.ToString().Substring(4, lbl_aib.Text.ToString().Length - 6)))
            //         * Convert.ToDecimal(meb_montantBrut.Value) / 100;
            //}
            
        }

        private void meb_TVA_Leave(object sender, EventArgs e)
        {
            //if (meb_TVA.ReadOnly == false)
            //{
               
            //   lbl_tva.Text = Convert.ToDecimal(meb_TVA.Value) == 0 ? "TVA(%)" : "TVA(" + meb_TVA.Value + "%)";
            //   meb_TVA.Value = Convert.ToDecimal(lbl_tva.Text.ToString().IndexOf("%") == 4 ? 0 :
            //        Convert.ToDecimal(lbl_tva.Text.ToString().Substring(4, lbl_tva.Text.ToString().Length - 6)))
            //        * Convert.ToDecimal(meb_montantBrut.Value) / 100;
            //}
        }

        private void lbl_tva_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

            lbl_tva.Text = lbl_tva.Checked && CurrentUser.OSociete.Tva != 0 ? "TVA(" + Convert.ToInt32(CurrentUser.OSociete.Tva) + "%)" : "TVA(%)";
            meb_TVA.Value = Convert.ToDecimal(lbl_tva.Text.ToString().IndexOf("%") == 4 ? 0 :
                    (Convert.ToDecimal(lbl_tva.Text.ToString().Substring(4, lbl_tva.Text.ToString().Length - 6)))
                    * Convert.ToDecimal(meb_montantHT.Value) / 100);

        }

        private void lbl_aib_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            lbl_aib.Text = lbl_aib.Checked && CurrentUser.OSociete.Aib != 0 ? "AIB(" + Convert.ToInt32(CurrentUser.OSociete.Aib) + "%)" : "AIB(%)";
            meb_AIB.Value = Convert.ToDecimal(lbl_aib.Text.ToString().IndexOf("%") == 4 ? 0 :
                    (Convert.ToDecimal(lbl_aib.Text.ToString().Substring(4, lbl_aib.Text.ToString().Length - 6)))
                    * Convert.ToDecimal(meb_montantHT.Value) / 100);
        }

        private void rddl_typeCoffret_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (btn_Nouveau.Visible==false)
            {

                IntrantCommander obj = lstIntrantCommander.Find(l => l.Intrant.Trim() ==
                    mcb_intrant.Text.Trim() && l.LibelleTypeCoffret.Trim() == rddl_typeCoffret.Text.Trim());
                meb_qteCommande.Text = obj != null ? Convert.ToString(obj.QteCommande) : "0";
                meb_qteDejaLivree.Text = obj != null ? Convert.ToString(obj.QteLivree) : "0";
                decimal qteRestanteGrille = 0;
                for (int i = 0; i < dgv_intrant.RowCount; i++)
                {
                    Intrants obj1 = lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                        mcb_intrant.Text.Trim());
                    if (obj1 != null)
                    {
                        if (dgv_intrant.Rows[i].Cells["codeIntrant"].Value.ToString().Trim() ==
                        (lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                        mcb_intrant.Text.Trim()).CodeIntrant) && rddl_typeCoffret.Text.Trim() == dgv_intrant.Rows[i].Cells["libelleTypeCoffret"].Value.ToString().Trim())
                        {
                            qteRestanteGrille += Convert.ToDecimal(dgv_intrant.Rows[i].Cells["qteLivree"].Value.ToString().Trim());
                        }

                    }

                }
                meb_qteRestante.Text = obj != null ? Convert.ToString(obj.QteRestante - qteRestanteGrille) : "0";
            }
        }
    }
}
