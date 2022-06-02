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
    public partial class Frm_CommandeFrs : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        string[] message;
        List<Intrants> lstIntrants = new List<Intrants>();
      
        List<Fournisseur> lstFournisseur = new List<Fournisseur>();
        List<CommandeIntrant> lstCommandeIntrant = new List<CommandeIntrant>();
        
        List<IntrantCommander> lstIntrantCommander = new List<IntrantCommander>();
        #endregion

        #region Autres

       

       
        private void ChargerListe(CommandeIntrant obj)
        {
            lstCommandeIntrant = CommandeIntrant.Liste(null, null, null, null, null, null, null, false, null, null, null,null,null,null, null,false, null);
            bds_CommandeIntrant.DataSource = lstCommandeIntrant;
            if (obj != null)
            {
                int i = 0;
                foreach (CommandeIntrant ligne in bds_CommandeIntrant.List as List<CommandeIntrant>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_CommandeIntrant.Position = i;
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


        public void Bloquerdebloquer(bool etat)
        {
            //txt_Code.ReadOnly = etat;
           
            dtp_dateLivraison.ReadOnly = etat;
            mcb_fournisseur.Enabled = !etat;
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
          rddl_typeCoffret.ReadOnly = etat;
           txt_unite.ReadOnly = etat;
           meb_qteCommande.ReadOnly = etat;
           meb_prixUnitaire.ReadOnly = etat;
           btn_AjouterIntrant.Visible  = etat;
           btn_AnnuleIntrant.Visible = !etat;
           btn_SaveIntrant.Visible = !etat;
           btn_SupprimerIntrant.Visible = etat;
           dgv_intrant.Enabled = etat;
        }
        private void Viderchamp()
        {
            txt_statut.Text = "";
            txt_num.Text = "EN CREATION";
            dtp_dateCommande.Value = DateTime.Now;
            dtp_dateLivraison.Value = DateTime.Now;
            mcb_fournisseur.Text = "";
            dgv_ListeIntrantShow.Rows.Clear();
           
        }

        private void ViderchampIntrant()
        {
            txt_unite.Text = "";
            meb_qteCommande.Value = 0;
            meb_qteLivree.Value = 0;
            meb_qteRestante.Value = 0;
            meb_prixUnitaire.Value = 0;
            meb_montantBrut.Value = 0;
            mcb_intrant.Text = "";
            rddl_typeCoffret.Text = "";
            dgv_intrant.Rows.Clear();

        }

        private void ViderchampIntrantSimple()
        {
            txt_unite.Text = "";
            meb_qteCommande.Value = 0;
            meb_qteLivree.Value = 0;
            meb_qteRestante.Value = 0;
            meb_prixUnitaire.Value = 0;
            meb_montantBrut.Value = 0;
            mcb_intrant.Text = "";
            

        }
        private void creerObjetCommandeIntrant(CommandeIntrant obj)
        {
            
            obj.IdPersonne = lstFournisseur.Find(l => l.RaisonSociale.Trim() ==
            mcb_fournisseur.Text.Trim()).IdPersonne;
            obj.DateCommande = Convert.ToDateTime(dtp_dateCommande.Value);
            obj.DateLivraisonPrevu = Convert.ToDateTime(dtp_dateCommande.Value);
            obj.DateDerniereLivraison = nouveau == true ? Convert.ToDateTime("01/01/2050") : obj.DateDerniereLivraison;
            obj.Statut = nouveau == true ? "PAS EXECUTEE" : obj.Statut;
            for (int i = 0; i < dgv_intrant.RowCount; i++)
            {
                obj.MontantGlobale = Convert.ToDecimal(dgv_intrant.Rows[i].Cells["MontantBrut"].Value.ToString());
            }
            
            obj.EstAnnule = false;
            obj.DateAnnulation = Convert.ToDateTime("01/01/2050");
            obj.MotifAnnulation = "";

           
        }

        private void creerObjetIntrantCommande(IntrantCommander obj, decimal numCommande, int l)
        {
            obj.NumCommande= numCommande;
            obj.CodeIntrant = dgv_intrant.Rows[l].Cells["Code"].Value.ToString();
            obj.QteCommande = Convert.ToDecimal(dgv_intrant.Rows[l].Cells["QteCommande"].Value.ToString());
            obj.QteLivree = Convert.ToDecimal(dgv_intrant.Rows[l].Cells["QteLivre"].Value.ToString());
            obj.QteRestante = Convert.ToDecimal(dgv_intrant.Rows[l].Cells["QteRestante"].Value.ToString());
            obj.MontantBut = Convert.ToDecimal(dgv_intrant.Rows[l].Cells["MontantBrut"].Value.ToString());
            obj.PrixUnitaire = Convert.ToDecimal(dgv_intrant.Rows[l].Cells["PU"].Value.ToString());
            obj.CodeTypeCoffret = Convert.ToDecimal(dgv_intrant.Rows[l].Cells["codeTypeCoffret"].Value.ToString());
          
        }
        private void DetaillerCommandeIntrant(CommandeIntrant obj)
        {
            txt_num.Text = Convert.ToString(obj.NumCommande);
            txt_statut.Text = obj.Statut;
            dtp_dateCommande.Value = Convert.ToDateTime(obj.DateCommande);
            dtp_dateLivraison.Value = obj.DateLivraisonPrevu;
            mcb_fournisseur.Text = lstFournisseur.Find(l => l.IdPersonne ==
                obj.IdPersonne).RaisonSociale;

            ChargerListeIntrantCommande(obj);
        }

        private void DetaillerIntrantCommander(IntrantCommander obj)
        {
            mcb_intrant.Text = lstIntrants.Find( l => l.CodeIntrant.Trim()
            == obj.CodeIntrant).LibelleIntrant;
            txt_unite.Text = lstIntrants.Find(l => l.CodeIntrant.Trim()
            == obj.CodeIntrant).Code; 
            meb_qteCommande.Value = obj.QteCommande;
            meb_qteLivree.Value = obj.QteLivree;
            meb_prixUnitaire.Value = obj.PrixUnitaire;
            meb_montantBrut.Value = obj.MontantBut;
            meb_qteRestante.Value = obj.QteRestante;

        }
        private void DetaillerIntrantCommanderDragDrop()
        {
            mcb_intrant.Text = dgv_intrant.CurrentRow.Cells["Libelle"].Value.ToString().Trim();
            txt_unite.Text = dgv_intrant.CurrentRow.Cells["Unite"].Value.ToString().Trim();
            meb_qteCommande.Value = dgv_intrant.CurrentRow.Cells["QteCommande"].Value.ToString().Trim();
            meb_qteLivree.Value = dgv_intrant.CurrentRow.Cells["QteLivre"].Value.ToString().Trim();
            meb_prixUnitaire.Value = dgv_intrant.CurrentRow.Cells["PU"].Value.ToString().Trim();
            meb_montantBrut.Value = dgv_intrant.CurrentRow.Cells["MontantBrut"].Value.ToString().Trim();
            meb_qteRestante.Value = dgv_intrant.CurrentRow.Cells["QteRestante"].Value.ToString().Trim();

        }

        private void ChargerGrilleIntrant()
        {
            int index = dgv_intrant.Rows.Count;

            GridViewRowInfo newRow = dgv_intrant.Rows.NewRow();
            newRow.Cells["Code"].Value = lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                mcb_intrant.Text.Trim()).CodeIntrant.Trim();
            newRow.Cells["Libelle"].Value = mcb_intrant.Text.Trim();
            newRow.Cells["codeTypeCoffret"].Value = rddl_typeCoffret.SelectedValue;
            newRow.Cells["libelleTypeCoffret"].Value = rddl_typeCoffret.Text;
            newRow.Cells["Unite"].Value = txt_unite.Text.Trim();
            newRow.Cells["QteCommande"].Value = meb_qteCommande.Value;
            newRow.Cells["QteLivre"].Value = meb_qteLivree.Value;
            newRow.Cells["PU"].Value = meb_prixUnitaire.Value;
            newRow.Cells["MontantBrut"].Value = meb_montantBrut.Value;
            newRow.Cells["QteRestante"].Value = meb_qteRestante.Value;
           
            dgv_intrant.Rows.Insert(index, newRow);

        }
        
        private void ChargerListeIntrantCommande(CommandeIntrant obj)
        {
            lstIntrantCommander = IntrantCommander.Liste(obj.NumCommande, null,null, null, null,
                null, null, null,  null,null,null,null,null, false, null);
            bds_IntrantCommande.DataSource = lstIntrantCommander;
        }
        private void ChargerListeFournisseur()
        {
            lstFournisseur = Fournisseur.Liste(null, null, null, null,
                null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, false, null);
            bds_Fournisseur.DataSource = lstFournisseur;
        }
        private void ChargerListeIntrant()
        {
            lstIntrants = Intrants.Liste(null,null, null, null, null, null, null, null, null, null, null, null, false, null, null);
            bds_Intrants.DataSource = lstIntrants;
        }
        #endregion

        #region Formulaire
        public Frm_CommandeFrs()
        {
            InitializeComponent();
        }

        private void Frm_MAJTitre_Load(object sender, EventArgs e)
        {
            ChargerListeFournisseur();
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
            CommandeIntrant obj = (CommandeIntrant)bds_CommandeIntrant.Current;
            ChargerListe(obj);
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
            CommandeIntrant obj = new CommandeIntrant();
            IntrantCommander objIntrantCommander = new IntrantCommander();

            #region Controle de saisie

            if (mcb_fournisseur.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez renseigner le fournisseur",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                mcb_fournisseur.Focus();
                return;
            }

            if (dgv_intrant.RowCount == 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez renseigner le(s) intrant(s) commandé(s)",
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
                creerObjetCommandeIntrant(obj);
                sortie = obj.Insert();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {

                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    for (int i = 0; i < dgv_intrant.RowCount; i++)
                    {
                        creerObjetIntrantCommande(objIntrantCommander, obj.NumLigne, i);
                        objIntrantCommander.Insert();
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
                   

                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), CurrentUser.LogicielHote,
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }


            #endregion

            #region Modification
            else
            {
                obj = (CommandeIntrant)bds_CommandeIntrant.Current;
                creerObjetCommandeIntrant(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    for (int i = 0; i < dgv_intrant.RowCount; i++)
                    {
                        creerObjetIntrantCommande(objIntrantCommander, obj.NumLigne, i);
                        objIntrantCommander.Insert();
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
                ChargerListe((CommandeIntrant)bds_CommandeIntrant.Current);
            }
        }

        #endregion


        #region DataGridView
        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                
                DetaillerCommandeIntrant((CommandeIntrant)bds_CommandeIntrant.Current);
               
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
                DetaillerIntrantCommanderDragDrop();
            }
            else
                ViderchampIntrantSimple();
        }

        private void dgv_ListeIntrantShow_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeIntrantShow.SelectedRows != null && dgv_ListeIntrantShow.SelectedRows.Count != 0)
            {
                DetaillerIntrantCommander((IntrantCommander)bds_IntrantCommande.Current);
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

            if (meb_qteCommande.Text.Trim() == "0" || meb_qteCommande.Text.Trim() == "") 
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez renseigner la quantité commandé",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_qteCommande.Focus();
                return;
            }

            if (meb_prixUnitaire.Text.Trim() == "0" || meb_prixUnitaire.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez renseigner le prix unitaire de l'intrant",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_prixUnitaire.Focus();
                return;
            }

            #endregion
            ChargerGrilleIntrant();
            BloquerdebloquerBoutonIntrant(true);
        }

        private void mcb_intrant_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Intrants obj = lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                    mcb_intrant.Text.Trim());
                txt_unite.Text = obj != null ? obj.Code : "";
                bds_IntrantsTypeCoffret.DataSource = IntrantsTypeCoffret.Liste(null, obj.CodeIntrant.Trim(), null, null, null, null, null, null, false, null);
            }
            catch { }
        }

        private void meb_qteCommande_TextChanged(object sender, EventArgs e)
        {
            meb_qteRestante.Value = meb_qteCommande.Value;
            meb_montantBrut.Value = Convert.ToDecimal(meb_qteCommande.Value) * Convert.ToDecimal(meb_prixUnitaire.Value);
        }

        private void meb_prixUnitaire_TextChanged(object sender, EventArgs e)
        {
            meb_montantBrut.Value = Convert.ToDecimal(meb_qteCommande.Value) * Convert.ToDecimal(meb_prixUnitaire.Value);
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
                DetaillerIntrantCommanderDragDrop();
            }
            else
            {
                ViderchampIntrantSimple();
            }
        }
    }
}
