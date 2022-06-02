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
    public partial class Frm_Intrants : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        string[] message;
        List<Intrants> lstIntrants = new List<Intrants>();
        List<CategorieIntrant> lstCategorieIntrant = new List<CategorieIntrant>();
        List<UniteMesure> lstUniteMesure = new List<UniteMesure>();
        public List<IntrantsTypeCoffret> lstIntrantsTypeCoffret = new List<IntrantsTypeCoffret>();
        public List<TypeCoffret> lstTypeCoffret = new List<TypeCoffret>();
        bool nouveauConditionnement = false;
        int ligne = 0;
        #endregion

        #region Autres

        private void ChargerListeCategorieIntrant()
        {
            lstCategorieIntrant = CategorieIntrant.Liste(null,
                null, null, null, null, null, null, false, null);
            bds_CategorieIntrant.DataSource = lstCategorieIntrant;
        }

        private void ChargerListeUnite()
        {
            lstUniteMesure = UniteMesure.Liste(null, null, null, null,
                null, null, null, false, null);
            bds_UniteMesure.DataSource = lstUniteMesure;
        }
        private void ChargerListe(Intrants obj)
        {
            lstIntrants = Intrants.Liste(null,null, null,null,null,null,null,null,null,null,null,null,false,null,null);
            bds_Intrants.DataSource = lstIntrants;
            if (obj != null)
            {
                int i = 0;
                foreach (Intrants ligne in bds_Intrants.List as List<Intrants>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_Intrants.Position = i;
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
            txt_libelle.ReadOnly = etat;
            txt_code.ReadOnly = etat;
            meb_stockCritique.ReadOnly = etat;
            meb_stockSecurite.ReadOnly = etat;
            cb_Unite.ReadOnly = etat;
            cb_categorie.ReadOnly = etat;
            gv_Liste.Enabled = etat;
            btn_Nouveau.Visible = etat;
            btn_Modifier.Visible = etat;
            btn_Annuler.Visible = !etat;
            btn_Enregistrer.Visible = !etat;
            btn_Supprimer.Enabled = etat;
            btn_Actualiser.Enabled = etat;
            pvp_Conditionnement.Enabled = etat;

        }
        private void Viderchamp()
        {
            txt_libelle.Text = "";
            txt_code.Text = "";
            cb_Unite.Text = "";
            cb_categorie.Text = "";
            meb_stockSecurite.Value = 0;
            meb_stockCritique.Value = 0;
            meb_qteDispo.Value = 0;
           


        }
        private void creerObjet(Intrants obj)
        {
            obj.CodeIntrant = txt_code.Text.Trim();
            obj.LibelleIntrant = txt_libelle.Text;
            obj.StockSecurite = Convert.ToDecimal(meb_stockSecurite.Value);
            obj.SeuilCritique = Convert.ToDecimal(meb_stockCritique.Value);
            obj.StockDisponible = nouveau == true ? 0 : Convert.ToDecimal(obj.StockDisponible);
            obj.Code = cb_Unite.Text.Trim();
            obj.CodeCategorie = Convert.ToString(cb_categorie.SelectedValue);
           
        }
        private void Detailler(Intrants obj)
        {
            txt_code.Text = obj.CodeIntrant;
            txt_libelle.Text = obj.LibelleIntrant;
            meb_stockSecurite.Value = obj.StockSecurite;
            meb_stockCritique.Value = obj.SeuilCritique;
            meb_qteDispo.Value = obj.StockDisponible;
            cb_Unite.Text = obj.Code;
            cb_categorie.Text = lstCategorieIntrant.Find(l => l.CodeCategorie.Trim() ==
                obj.CodeCategorie.Trim()).LibelleCategorie;

            ChargerDonnes(obj.CodeIntrant.Trim(), null);
        }

               
        
        #endregion

        #region Formulaire
        public Frm_Intrants()
        {
            InitializeComponent();
        }

        private void Frm_MAJTitre_Load(object sender, EventArgs e)
        {
            ChargerTypeCoffret();
            ChargerListeUnite();
            ChargerListeCategorieIntrant();
            ChargerListe(null);
            Bloquerdebloquer(true);
        } 
        #endregion

        #region Bouton de commande
        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            Intrants obj = (Intrants)bds_Intrants.Current;
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
                    Intrants obj = (Intrants)bds_Intrants.Current;
                    sortie = obj.Delete();
                    message = Tools.SplitMessage(sortie);
                    if (int.Parse(message[0]) > 0)
                    {
                        Viderchamp();
                        ChargerListe(null);
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    else
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
            }
        }
        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            Intrants obj = new Intrants();

            #region Controle de saisie

            if (txt_code.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez renseigner le code de l'Intrants",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_code.Focus();
                return;
            }

            if (txt_libelle.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez renseigner le libellé de l'intrant",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_libelle.Focus();
                return;
            }

            //if (cb_Unite.Text.Trim() == "")
            //{
            //    RadMessageBox.ThemeName = this.ThemeName;
            //    RadMessageBox.Show(this, "veuillez renseigner l'unité de mesure de l'Intrants",
            //        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            //    cb_Unite.Focus();
            //    return;
            //}

            if (cb_categorie.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veuillez renseigner la catégorie de l'intrant",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                cb_categorie.Focus();
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
                obj = (Intrants)bds_Intrants.Current;
                creerObjet(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());


                    Bloquerdebloquer(true);
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
              
                Bloquerdebloquer(false);
                txt_code.ReadOnly = true;
                nouveau = false;

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
            videzGrille();
            Bloquerdebloquer(false);
           

        }
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            Bloquerdebloquer(true);
            Viderchamp();
            ChargerListe((Intrants)bds_Intrants.Current);
        }

        #endregion


        #region DataGridView
        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                
                Detailler((Intrants)bds_Intrants.Current);
               
            }
            else
            {
                Viderchamp();
            }
        }
        #endregion

        #region IntrantsTypeCoffret
        private void creerObjet(IntrantsTypeCoffret obj)
        {
            gv_ListeIntrantsTypeCoffret.EndEdit();
            obj.CodeIntrant = txt_code.Text.Trim();
            obj.CodeTypeCoffret = Convert.ToDecimal(gv_ListeIntrantsTypeCoffret.Rows[ligne].Cells["CodeTypeCoffret"].Value);
            obj.NbAnalyse_qte = Convert.ToDecimal(gv_ListeIntrantsTypeCoffret.Rows[ligne].Cells["NbAnalyse_qte"].Value);
            obj.Mesure1Test = Convert.ToString(gv_ListeIntrantsTypeCoffret.Rows[ligne].Cells["mesure1Test"].Value);
            
           
        }
        public void BloquerdebloquerPC(bool etat)
        {
            gv_ListeIntrantsTypeCoffret.ReadOnly = etat;

            btn_Nouveaupc.Visible = etat;
            btn_Modifierpc.Visible = etat;
            btn_Annulerpc.Visible = !etat;
            btn_Enregistrerpc.Visible = !etat;
            btn_Supprimerpc.Enabled = etat;
        }
        private void videzGrille()
        {
            lstIntrantsTypeCoffret = new List<IntrantsTypeCoffret>();
            bds_IntrantsTypeCoffret.DataSource = lstIntrantsTypeCoffret;
        }
        private void ChargerTypeCoffret()
        {
            lstTypeCoffret = TypeCoffret.Liste(
                null, null, null, null, null,
                null, null, false, null);
            bds_TypeCoffret.DataSource = lstTypeCoffret;
        }
        private void ChargerDonnes(string mIntrant, IntrantsTypeCoffret obj)
        {
            lstIntrantsTypeCoffret = IntrantsTypeCoffret.Liste(
                null, mIntrant.Trim(), null, null, null, null,
                null, null,  false, null);
            bds_IntrantsTypeCoffret.DataSource = lstIntrantsTypeCoffret;
            if (obj != null)
            {
                int i = 0;
                foreach (IntrantsTypeCoffret ligne in bds_IntrantsTypeCoffret.List as List<IntrantsTypeCoffret>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_IntrantsTypeCoffret.Position = i;
                        break;
                    }
                    else
                        i++;
                }
            }

        }
        #endregion

        #region produit conditionnement
        private void btn_Supprimerpc_Click(object sender, EventArgs e)
        {
            if (gv_ListeIntrantsTypeCoffret.SelectedRows != null && gv_ListeIntrantsTypeCoffret.SelectedRows.Count != 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voullez-vous vraiment supprimer la ligne sélectionnée?", CurrentUser.LogicielHote,
                 MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    IntrantsTypeCoffret obj = (IntrantsTypeCoffret)bds_IntrantsTypeCoffret.Current;
                    sortie = obj.Delete();
                    message = Tools.SplitMessage(sortie);
                    if (int.Parse(message[0]) > 0)
                    {
                        ChargerDonnes(txt_code.Text, null);
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(),
                                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    else
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(),
                                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veillez sélèctioner une ligne avant d'entamer la suppression", CurrentUser.LogicielHote,
                MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_Annulerpc_Click(object sender, EventArgs e)
        {
            nouveauConditionnement = false;
            BloquerdebloquerPC(true);
            videzGrille();
            ChargerDonnes(txt_code.Text.Trim(), (IntrantsTypeCoffret)bds_IntrantsTypeCoffret.Current);
        }

        private void btn_Modifierpc_Click(object sender, EventArgs e)
        {
            if (gv_ListeIntrantsTypeCoffret.SelectedRows != null && gv_ListeIntrantsTypeCoffret.SelectedRows.Count != 0)
            {
                BloquerdebloquerPC(false);
                gv_ListeIntrantsTypeCoffret.Focus();
                ligne = gv_ListeIntrantsTypeCoffret.SelectedRows[0].Index;//récupère l'index de la ligne en cours de modification
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veillez sélèctioner une ligne avant d'entamer la modification.",
                                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_Enregistrerpc_Click(object sender, EventArgs e)
        {
            IntrantsTypeCoffret obj = new IntrantsTypeCoffret();

            #region ControlDeSaisie

            if (gv_ListeIntrantsTypeCoffret.Rows[ligne].Cells["codeTypeCoffret"].Value.ToString().Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La sélection du type de coffret est obligatoire", CurrentUser.LogicielHote,
                MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_code.Focus();
                return;
            }

            if (txt_code.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La sélection de l'intrant est obligatoire", CurrentUser.LogicielHote,
                MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_code.Focus();
                return;
            }

            #endregion

            #region Enregistrement

            if (nouveauConditionnement)
            {
                creerObjet(obj);
                sortie = obj.Insert();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    BloquerdebloquerPC(true);
                    nouveauConditionnement = false;
                    ChargerDonnes(txt_code.Text.Trim(), obj);
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(),
                                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
            }


            #endregion

            #region Modification
            else
            {
                obj = lstIntrantsTypeCoffret[ligne];
                creerObjet(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1] != "")
                {
                    BloquerdebloquerPC(true);
                    ChargerDonnes(txt_code.Text.Trim(), obj);
                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), CurrentUser.LogicielHote,
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);

            }


            #endregion
        }

        private void btn_Nouveaupc_Click(object sender, EventArgs e)
        {
            if (txt_code.Text.Trim() != "")
            {
                nouveauConditionnement = true;
                gv_ListeIntrantsTypeCoffret.Rows.AddNew();//créer une nouvelle ligne dans la grille de données
                ligne = gv_ListeIntrantsTypeCoffret.Rows.Count - 1;
                BloquerdebloquerPC(false);                
                gv_ListeIntrantsTypeCoffret.Focus();
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), CurrentUser.LogicielHote,
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
                //envoyer  un message d'erreur
            }
        }
        #endregion
    }
}
