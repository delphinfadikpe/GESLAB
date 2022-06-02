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
    public partial class Frm_EntreSortieStock : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        string[] message;
        string typeOperation;
        List<Intrants> lstIntrants = new List<Intrants>();
        List<EntreSortieStock> lstEntreSortieStock = new List<EntreSortieStock>();
        List<InrantSortieStock> lstInrantSortieStock = new List<InrantSortieStock>();
        #endregion

        #region Autres
        private void ChargerListe(EntreSortieStock obj)
        {
            
            lstEntreSortieStock = EntreSortieStock.Liste(null, null, typeOperation.Trim(), null, null, null, null, null, false, null);
            bds_EntreSortieStock.DataSource = lstEntreSortieStock;
            if (obj != null)
            {
                int i = 0;
                foreach (EntreSortieStock ligne in bds_EntreSortieStock.List as List<EntreSortieStock>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_EntreSortieStock.Position = i;
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


            dtp_dateOperation.ReadOnly = etat;
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
            txt_Motif.ReadOnly = etat;
            meb_qte.ReadOnly = etat;
            meb_qteDisponible.ReadOnly = etat;
            btn_AjouterIntrant.Visible = etat;
            btn_AnnuleIntrant.Visible = !etat;
            btn_SaveIntrant.Visible = !etat;
            btn_SupprimerIntrant.Visible = etat;
            dgv_intrant.Enabled = etat;
        }
        private void Viderchamp()
        {
            
            txt_num.Text = "EN CREATION";
            
            dtp_dateOperation.Value = DateTime.Now;
           
            dgv_ListeIntrantShow.Rows.Clear();
           
        }

        private void ViderchampIntrant()
        {
            txt_Motif.Text = "";
            meb_qte.Value = 0;
           
            meb_qteDisponible.Value = 0;
           
            mcb_intrant.Text = "";
            dgv_intrant.Rows.Clear();

        }

        private void ViderchampIntrantSimple()
        {
            txt_Motif.Text = "";
            meb_qte.Value = 0;
           
            meb_qteDisponible.Value = 0;
            
            mcb_intrant.Text = "";
            

        }
        private void creerObjetEntreSortieStock(EntreSortieStock obj)
        {

            obj.DateEntreSortie = dtp_dateOperation.Value;
            obj.TypeOperation = typeOperation;
              
        }

        private void creerObjetInrantSortieStock(InrantSortieStock obj, decimal numCommande, int l)
        {
            
            obj.CodeIntrant = dgv_intrant.Rows[l].Cells["Code"].Value.ToString();
            obj.NumEntreSortie = numCommande;
            obj.MotifEntreSortie = Convert.ToString(dgv_intrant.Rows[l].Cells["Motif"].Value.ToString());
            obj.QteEntreSortie = Convert.ToDecimal(dgv_intrant.Rows[l].Cells["QteEntreSortie"].Value.ToString());
            
        }
        private void DetaillerEntreSortieStock(EntreSortieStock obj)
        {
            txt_num.Text = Convert.ToString(obj.NumEntreSortie);
            dtp_dateOperation.Value = obj.DateEntreSortie;
            ChargerListeInrantSortieStock(obj);
        }

        private void DetaillerInrantSortieStock(InrantSortieStock obj)
        {
            mcb_intrant.Text = lstIntrants.Find(l => l.CodeIntrant.Trim()
            == obj.CodeIntrant).LibelleIntrant;
            txt_Motif.Text = obj.MotifEntreSortie;
            meb_qte.Value = obj.QteEntreSortie;
            meb_qteDisponible.Value = lstIntrants.Find(l => l.CodeIntrant.Trim()
            == obj.CodeIntrant).StockDisponible;
            
        }
        private void DetaillerIntrantCommanderDragDrop()
        {
            mcb_intrant.Text = dgv_intrant.CurrentRow.Cells["Libelle"].Value.ToString().Trim();
            txt_Motif.Text = dgv_intrant.CurrentRow.Cells["Motif"].Value.ToString().Trim();
            meb_qte.Value = dgv_intrant.CurrentRow.Cells["QteEntreSortie"].Value.ToString().Trim();
            meb_qteDisponible.Value = lstIntrants.Find(l => l.CodeIntrant.Trim()
            == dgv_intrant.CurrentRow.Cells["Code"].Value.ToString().Trim()).StockDisponible;
           

        }

        private void ChargerGrilleIntrant()
        {
            int index = dgv_intrant.Rows.Count;

            GridViewRowInfo newRow = dgv_intrant.Rows.NewRow();
            newRow.Cells["Code"].Value = lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                mcb_intrant.Text.Trim()).CodeIntrant.Trim();
            newRow.Cells["Libelle"].Value = mcb_intrant.Text.Trim();
            newRow.Cells["QteEntreSortie"].Value = meb_qte.Value;
            newRow.Cells["Motif"].Value = txt_Motif.Text.Trim();
            dgv_intrant.Rows.Insert(index, newRow);

        }

        private void ChargerListeInrantSortieStock(EntreSortieStock obj)
        {
            
            lstInrantSortieStock = InrantSortieStock.Liste(null, obj.NumEntreSortie, null, null,
                null, null, null, null, null, false, null);
            bds_InrantSortieStock.DataSource = lstInrantSortieStock;
            
            //foreach(InrantSortieStock mligne in lstInrantSortieStock)
            //{
            //    int index = dgv_intrant.Rows.Count;

            //    GridViewRowInfo newRow = dgv_intrant.Rows.NewRow();
            //    newRow.Cells["Code"].Value = mligne.CodeIntrant.Trim();
            //    newRow.Cells["Libelle"].Value = mligne.Intrant.Trim();
            //    newRow.Cells["QteEntreSortie"].Value = mligne.QteEntreSortie;
            //    newRow.Cells["Motif"].Value = mligne.MotifEntreSortie;
            //    dgv_intrant.Rows.Insert(index, newRow);
            //}
        }
       
        private void ChargerListeIntrant()
        {
            lstIntrants = Intrants.Liste(null,null, null, null, null, null, null, null, null, null, null, null, false, null, null);
            bds_Intrants.DataSource = lstIntrants;
        }
        #endregion

        #region Formulaire
        public Frm_EntreSortieStock()
        {
            InitializeComponent();
        }

        private void Frm_MAJTitre_Load(object sender, EventArgs e)
        {
            
            ChargerListeIntrant();
            pv_titres_SelectedPageChanged(null, null);
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
            EntreSortieStock obj = (EntreSortieStock)bds_EntreSortieStock.Current;
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
            EntreSortieStock obj = new EntreSortieStock();
            InrantSortieStock objInrantSortieStock = new InrantSortieStock();

            #region Controle de saisie
            if (dgv_intrant.RowCount == 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, typeOperation == "ENTRE" ? "veuillez renseigner le(s) intrant(s) entré(s) en stock" :
                "veuillez renseigner le(s) intrant(s) sorti(s) du stock",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                dgv_intrant.Focus();
                return;
            }


            #endregion

            #region Enregistrement
            if (nouveau)
            {
                creerObjetEntreSortieStock(obj);
                sortie = obj.Insert();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {

                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    for (int i = 0; i < dgv_intrant.RowCount; i++)
                    {
                        creerObjetInrantSortieStock(objInrantSortieStock, obj.NumLigne, i);
                        objInrantSortieStock.Insert();
                    }
                    ChargerListeIntrant();
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
                obj = (EntreSortieStock)bds_EntreSortieStock.Current;
                creerObjetEntreSortieStock(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    for (int i = 0; i < dgv_intrant.RowCount; i++)
                    {
                        creerObjetInrantSortieStock(objInrantSortieStock, obj.NumLigne, i);
                        objInrantSortieStock.Insert();
                    }
                    ChargerListeIntrant();
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
                RadMessageBox.Show(this, "veillez sélectioner une ligne avant la modification",
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
                ChargerListe((EntreSortieStock)bds_EntreSortieStock.Current);
            }
        }

        #endregion


        #region DataGridView
        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {

                DetaillerEntreSortieStock((EntreSortieStock)bds_EntreSortieStock.Current);
               
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
                DetaillerInrantSortieStock((InrantSortieStock)bds_InrantSortieStock.Current);
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

            if (meb_qte.Text.Trim() == "0" || meb_qte.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, typeOperation == "ENTRE" ? "veuillez renseigner la quantité entrée en stock" :
                "veuillez renseigner la quantité sortie du stock",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_qte.Focus();
                return;
            }
            Intrants obj1 = lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                   mcb_intrant.Text.Trim());
            decimal qteEntreSortieGrille = 0;
            for (int i = 0; i < dgv_intrant.RowCount; i++)
            {
               if (obj1 != null)
                {
                    if (dgv_intrant.Rows[i].Cells["Code"].Value.ToString().Trim() ==
                    (lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                    mcb_intrant.Text.Trim()).CodeIntrant))
                    {
                        qteEntreSortieGrille += Convert.ToDecimal(dgv_intrant.Rows[i].Cells["QteEntreSortie"].Value.ToString().Trim());
                    }

                }

            }
            if (typeOperation != "ENTRE" && qteEntreSortieGrille + Convert.ToDecimal(meb_qte.Value) > obj1.StockDisponible)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La quantité que vous voulez sortir est supérieur à la quantité disponible",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_qteDisponible.Focus();
                return;
            }

            #endregion
            ChargerGrilleIntrant();
            BloquerdebloquerBoutonIntrant(true);
        }

        private void mcb_intrant_TextChanged(object sender, EventArgs e)
        {
            Intrants obj = lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                mcb_intrant.Text.Trim() );
            if (obj != null)
            {
                decimal qteEntreSortieGrille = 0;
                for (int i = 0; i < dgv_intrant.RowCount; i++)
                {

                    if (obj != null)
                    {
                        if (dgv_intrant.Rows[i].Cells["Code"].Value.ToString().Trim() ==
                        (lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                        mcb_intrant.Text.Trim()).CodeIntrant))
                        {
                            qteEntreSortieGrille += Convert.ToDecimal(dgv_intrant.Rows[i].Cells["QteEntreSortie"].Value.ToString().Trim());
                        }

                    }

                }

                meb_qteDisponible.Value = typeOperation == "ENTRE" ? obj.StockDisponible + qteEntreSortieGrille :
                obj.StockDisponible - qteEntreSortieGrille;
            }
            else 
                meb_qteDisponible.Value = 0;
           
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

        private void meb_qte_ValueChanged(object sender, EventArgs e)
        {
            Intrants obj = lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                mcb_intrant.Text.Trim());
            if (obj != null)
            {
                decimal qteEntreSortieGrille = 0;
                for (int i = 0; i < dgv_intrant.RowCount; i++)
                {

                    if (obj != null)
                    {
                        if (dgv_intrant.Rows[i].Cells["Code"].Value.ToString().Trim() ==
                        (lstIntrants.Find(l => l.LibelleIntrant.Trim() ==
                        mcb_intrant.Text.Trim()).CodeIntrant))
                        {
                            qteEntreSortieGrille += Convert.ToDecimal(dgv_intrant.Rows[i].Cells["QteEntreSortie"].Value.ToString().Trim());
                        }

                    }

                }

                meb_qteDisponible.Value = typeOperation == "ENTRE" ? obj.StockDisponible + qteEntreSortieGrille + Convert.ToDecimal(meb_qte.Value):
                obj.StockDisponible - qteEntreSortieGrille - Convert.ToDecimal(meb_qte.Value);
            }
            else
                meb_qteDisponible.Value = 0;
        }

        private void pv_titres_SelectedPageChanged(object sender, EventArgs e)
        {
            bds_InrantSortieStock.DataSource = new List<InrantSortieStock>();
            ViderchampIntrant();
            ChargerListeIntrant();
            typeOperation = pv_titres.SelectedPage.Text.Trim();
            bds_EntreSortieStock.DataSource = new List<EntreSortieStock>();
            ChargerListe(null);
            gb_Liste.Text =  typeOperation == "ENTRE" ? "LISTE DES ENTRES" : "LISTE DES SORTIES";
            lbl_qte.Text =  typeOperation == "ENTRE" ? "QTE ENTREE" : "QTE SORTIE";
            dck_intrantWin.Text = typeOperation == "ENTRE" ? "LISTE DES ENTREES EN STOCK" : "LISTE DES SORTIES DE STOCK";
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
