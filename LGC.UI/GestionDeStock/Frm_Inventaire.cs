using LGC.Business;
using LGC.Business.GestionDeStock;
using LGC.Business.GestionUtilisateur;
using LGC.Business.Parametre;
using LGC.UI;
using LGC.UI.Impression;
//using LGG.Business;
//using LGG.Business.Autresoperations;
//using LGG.Business.AutresOperations;
//using LGG.Business.GestionUtilisateur;
//using LGG.Business.Impression;
//using LGG.Business.Parametre;
//using LGG.UI.Impression;
using LGG.UI.Parametre;
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

namespace LGC.UI.Parametre
{
    public partial class Frm_Inventaire : RadForm
    {
        #region Declaration
        List<Intrants> lstIntrants = new List<Intrants>();
        public List<Inventaire> lstInventaire = new List<Inventaire>();
        public List<TypeInventaire> lstTypeInventaire = new List<TypeInventaire>();
        public List<InventaireIntrant> lstInventaireIntrant = new List<InventaireIntrant>();
        //public List<ProduitPointDeVente> lstProduitPointDeVente = new List<ProduitPointDeVente>();
        List<Utilisateur> lstUtilisateur = new List<Utilisateur>();
        public bool nouveau = false;
        public bool modifier = false;
        private Droit _ObjDroit;
        ProfilDroit objPD = null;
        string sortie;
        string[] message;
        #endregion

        #region Autres
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }
        #region Inventaire
        public void Bloquerdebloquer(bool etat)
        {
            gv_Utilisateur.Columns["chkU"].IsVisible = !etat;

            dtp_Date.ReadOnly = etat;
            ddl_TypeInventaire.ReadOnly = etat;

            gv_Liste.Enabled = etat;
            gv_ListeProduit.ReadOnly = etat;

            List<Inventaire> lstInventaire1 = lstInventaire.FindAll(x => x.Etat.Trim() == "EN COURS");
            if (lstInventaire1 != null && lstInventaire1.Count > 0)
            {
                btn_Nouveau.Visible = true;
                btn_Nouveau.Enabled = false;
            }
            else
            {
                btn_Nouveau.Visible = etat;
            }
           
            btn_Modifier.Visible = etat;
            btn_Annuler.Visible = !etat;
            btn_Enregistrer.Visible = !etat;

            if (objPD == null || objPD.Suppression)
            {
                btn_Supprimer.Enabled = false;
            }

            btn_Actualiser.Enabled = etat;
            btn_Retirer.Enabled = !etat;
            btn_Inserer.Enabled = !etat;
        }

        private void Viderchamp()
        {
            txt_numero.Value = 0;
            txt_Etat.Text = "EN COURS";
            meb_Date.Value = "__/__/____";
            dtp_Date.Value = DateTime.Now;
            ddl_TypeInventaire.Text = "PARTIEL";
            videzGrille();
        }

        private void creerObjet(Inventaire obj)
        {
            obj.NumeroInventaire = Convert.ToDecimal(txt_numero.Value);
            obj.DateDebut = dtp_Date.Value;
            obj.Etat = txt_Etat.Text;
            obj.DateFin = meb_Date.Text.Trim() == "__/__/____" ?
                    Convert.ToDateTime("31/12/2050") : Convert.ToDateTime(meb_Date.Value);
            obj.CodeTypeInventaire = lstTypeInventaire.Find(l =>
                l.LibelleTypeInventaire.Trim() ==
                ddl_TypeInventaire.Text.Trim()).CodeTypeInventaire.Trim();
        }

        private void Detailler(Inventaire obj)
        {
            txt_numero.Value = obj.NumeroInventaire;
            dtp_Date.Value = obj.DateDebut;
            txt_Etat.Text = obj.Etat;
            meb_Date.Text = obj.DateFin.ToShortDateString() == "31/12/2050" ?
                    "__/__/____" : obj.DateFin.ToShortDateString();
            ddl_TypeInventaire.Text = obj.LibelleTypeInventaire;
            //affichage des produits de l'inventaire
            ChargerDonnes(obj.NumeroInventaire);
            //affichage des utilisateurs
            ChargerListeUtilisateur(null, obj);
        }

        private void ChargerDonnes(Inventaire obj)
        {
            lstInventaire = Inventaire.Liste(null, null, null, null, null, null, null, null, null, null,
                false, null);
            bds_Inventaire.DataSource = lstInventaire;
            if (obj != null)
            {
                int i = 0;
                foreach (Inventaire ligne in bds_Inventaire.List as List<Inventaire>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_Inventaire.Position = i;
                        break;
                    }
                    else
                        i++;
                }
            }
        }

        private void ChargerListePersonnesConcernnees(Inventaire obj)
        {
            bds_Utilisateur.DataSource = obj.getPersonneConcernneeInventaire();
        }

        private void ChargerTypeInventaire()
        {
            lstTypeInventaire = TypeInventaire.Liste(null, null, null,
                                                    null, null, null,
                                                    null, false, null);
            bds_typeInventaire.DataSource = lstTypeInventaire;
        }
        #endregion

        #region InventaireIntrant
        public void BloquerdebloquerIP(bool etat)
        {
            gv_ListeProduit.ReadOnly = etat;

            btn_Inserer.Visible = etat;
            btn_Retirer.Enabled = etat;
        }

        private void videzGrille()
        {
            lstInventaireIntrant = new List<InventaireIntrant>();
            bds_InventaireIntrant.DataSource = lstInventaireIntrant;
            bds_Utilisateur.DataSource = new List<Utilisateur>();
        }

        private void ChargerDonnes(decimal mNumeroInventaire)
        {
            lstInventaireIntrant = InventaireIntrant.Liste(
                mNumeroInventaire, null, null, null, null, null, null,
                null, null, null, null, null,false, null);
            bds_InventaireIntrant.DataSource = lstInventaireIntrant;
            gv_ListeProduit.DataSource = bds_InventaireIntrant;
        }

        private void ChargerIntrant()
        {
            lstIntrants = Intrants.Liste(null,null, null, null, null, null, null, null, null, null, null, null, false, null, null);
        }

        private void ChargerListeUtilisateur(Utilisateur obj, Inventaire obj1)
        {
            lstUtilisateur = Utilisateur.Liste(null, null, null, null,
                null, null, null, null, null, null, null, null,
                null, null, null, null, null, false, null);

            bds_Utilisateur.DataSource = lstUtilisateur;
            if (nouveau)
            {
                gv_Utilisateur.Columns["chkU"].IsVisible = true;
            }
            else
            {
                if (obj1 != null)
                {
                    int i = 0;
                    foreach (GridViewRowInfo utiRow in gv_Utilisateur.Rows)
                    {
                        List<PersonneConcernneeInventaire> lstPersonneConcernneeInventaire = new List<PersonneConcernneeInventaire>();
                        lstPersonneConcernneeInventaire = PersonneConcernneeInventaire.Liste(Convert.ToString(utiRow.Cells["NumeroUtilisateur"].Value), Convert.ToString(obj1.NumeroInventaire), null, null, null, null, null, false, null);

                        if (lstPersonneConcernneeInventaire != null && lstPersonneConcernneeInventaire.Count > 0)
                        {
                            utiRow.Cells["chkU"].Value = true;
                            utiRow.IsVisible = true;
                        }
                        else
                        {
                            if (!modifier)
                            {
                                utiRow.Cells["chkU"].Value = false;
                                utiRow.IsVisible = false;
                            }
                        }

                        if (obj != null)
                        {
                            if (Convert.ToDecimal(utiRow.Cells["NumLigne"].Value) == obj.NumLigne)
                            {
                                bds_Utilisateur.Position = i;
                                break;
                            }
                            else
                            {
                                i++;
                            }
                        }
                    }
                }
            }
           
        }

        #endregion
        #endregion

        #region Formulaire
        public Frm_Inventaire()
        {
            InitializeComponent();
            //_ObjDroit = mObjDroit;
            RadGridLocalizationProvider.CurrentProvider = new FrenchRadGridLocalizationProvider();
        }
        private void Frm_Inventaire_Load(object sender, EventArgs e)
        {
            //#region Gestion des droits sur les boutons
            //if (CurrentUser.LstDroitReelUser != null
            //    && CurrentUser.LstDroitReelUser.Count > 0)
            //{
            //    if (_ObjDroit != null)
            //    {
            //        objPD = CurrentUser.LstDroitReelUser.Find(l => l.CodeDroit.Trim() == _ObjDroit.CodeDroit);
            //        if (objPD != null)
            //        {
            //            btn_Nouveau.Enabled = objPD.Creation;
            //            btn_Modifier.Enabled = objPD.Modification;
            //            btn_Supprimer.Enabled = false;
            //        }
            //    }
            //}
            //#endregion

            ChargerIntrant();
            ChargerTypeInventaire();
            ChargerListeUtilisateur(null, null);
            ChargerDonnes(null);
            Bloquerdebloquer(true);
            if (nouveau)
                btn_Nouveau_Click(null, null);
        }
        #endregion

        #region Boutons
        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne sélectionnée ?", CurrentUser.LogicielHote,
                 MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    Inventaire obj = (Inventaire)bds_Inventaire.Current;
                    InventaireIntrant.deleteAll(Convert.ToString(obj.NumeroInventaire));
                    sortie = obj.Delete();
                    message = Tools.SplitMessage(sortie);
                    if (int.Parse(message[0]) > 0)
                    {
                        ChargerDonnes(null);
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
                RadMessageBox.Show(this, "Veuillez sélectionner une ligne avant d'entamer la suppression", CurrentUser.LogicielHote,
                MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            Inventaire obj = new Inventaire();

            #region ControlDeSaisie

            if (ddl_TypeInventaire.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner le type de l'inventaire.", CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                ddl_TypeInventaire.Focus();
                return;
            }

            if (gv_ListeProduit.Rows.Count == 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez sélectionner au moins un produit.", CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                btn_Inserer.Focus();
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
                    //enregistrement des produits de l'inventaire
                    for (int i = 0; i < gv_ListeProduit.Rows.Count; i++)
                    {
                        InventaireIntrant objIP = new InventaireIntrant();
                        objIP.NumeroInventaire = obj.NumLigne;
                        objIP.CodeIntrant = gv_ListeProduit.Rows[i].Cells["CodeIntrant"].Value.ToString();
                        objIP.Ecart = Convert.ToDecimal(
                            gv_ListeProduit.Rows[i].Cells["Ecart"].Value.ToString());
                        objIP.StockLogique = Convert.ToDecimal(
                            gv_ListeProduit.Rows[i].Cells["StockLogique"].Value.ToString());
                        objIP.StockPhysique = Convert.ToDecimal(
                            gv_ListeProduit.Rows[i].Cells["StockPhysique"].Value.ToString());
                        objIP.EstRegulariserSurPhysique = Convert.ToBoolean(
                            gv_ListeProduit.Rows[i].Cells["EstRegulariserSurPhysique"].Value.ToString());
                        objIP.Motif = gv_ListeProduit.Rows[i].Cells["Motif"].Value.ToString();
                        string r = objIP.Insert();
                    }

                    foreach (GridViewRowInfo utiRow in gv_Utilisateur.Rows)
                    {
                        if(Convert.ToBoolean(utiRow.Cells["chkU"].Value))
                        {
                            PersonneConcernneeInventaire pci = new PersonneConcernneeInventaire();

                            pci.NumeroInventaire = Convert.ToString(obj.NumLigne);
                            pci.NumeroUtilisateur = Convert.ToString(utiRow.Cells["NumeroUtilisateur"].Value);

                            string u = pci.Insert();
                        }
                    }

                    ChargerDonnes(obj);
                    Bloquerdebloquer(true);
                    nouveau = false;
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), CurrentUser.LogicielHote,
                        MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }
            #endregion

            #region Modification
            else
            {
                obj = (Inventaire)bds_Inventaire.Current;
                creerObjet(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1] != "")
                {
                    //suppression des anciens produits
                    InventaireIntrant.deleteAll(Convert.ToString(obj.NumeroInventaire));
                    //enregistrement des produits de l'inventaire
                   
                    for (int i = 0; i < gv_ListeProduit.Rows.Count; i++)
                    {
                        InventaireIntrant objIP = new InventaireIntrant();
                        objIP.NumeroInventaire = obj.NumeroInventaire;
                        objIP.CodeIntrant = gv_ListeProduit.Rows[i].Cells["CodeIntrant"].Value.ToString();
                        objIP.StockLogique = Convert.ToDecimal(
                           gv_ListeProduit.Rows[i].Cells["StockLogique"].Value.ToString());
                        objIP.StockPhysique = Convert.ToDecimal(
                            gv_ListeProduit.Rows[i].Cells["StockPhysique"].Value.ToString());
                        objIP.Ecart = Convert.ToDecimal(
                            gv_ListeProduit.Rows[i].Cells["Ecart"].Value.ToString());
                        objIP.EstRegulariserSurPhysique = Convert.ToBoolean(
                            gv_ListeProduit.Rows[i].Cells["EstRegulariserSurPhysique"].Value.ToString());
                        objIP.Motif = gv_ListeProduit.Rows[i].Cells["Motif"].Value.ToString();
                        string r = objIP.Insert();
                    }
                    //Supression des anciennes personnes concernées
                    PersonneConcernneeInventaire.deleteAll(Convert.ToString(obj.NumeroInventaire));
                    //Enregistrement des personnes concernées
                    foreach (GridViewRowInfo utiRow in gv_Utilisateur.Rows)
                    {
                        if (Convert.ToBoolean(utiRow.Cells["chkU"].Value))
                        {
                            PersonneConcernneeInventaire pci = new PersonneConcernneeInventaire();

                            pci.NumeroInventaire = Convert.ToString(obj.NumLigne);
                            pci.NumeroUtilisateur = Convert.ToString(utiRow.Cells["NumeroUtilisateur"].Value);

                            string u = pci.Insert();
                        }
                    }
                    modifier = false;
                    ChargerDonnes(obj);
                    Bloquerdebloquer(true);
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
                modifier = true;
                Bloquerdebloquer(false);
                ddl_TypeInventaire.ReadOnly = true;
                txt_Etat.Focus();
                Inventaire obj = (Inventaire)bds_Inventaire.Current;
                ChargerListeUtilisateur(null, obj);
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner une ligne avant d'entamer la modification.",
                                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = (true);
            Viderchamp();
            Bloquerdebloquer(false);
            gv_ListeProduit.DataSource = null;
            dtp_Date.Focus();
            ChargerListeUtilisateur(null, null);
        }

        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            modifier = false;
            ChargerDonnes((Inventaire)bds_Inventaire.Current);
            Bloquerdebloquer(true);
            Viderchamp();
            
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            Inventaire obj = (Inventaire)bds_Inventaire.Current;
            ChargerDonnes(obj);
        }

        private void btn_Retirer_Click(object sender, EventArgs e)
        {
            if (nouveau)
            {
                if (gv_ListeProduit.SelectedRows != null &&
                    gv_ListeProduit.SelectedRows.Count > 0)
                {
                    gv_ListeProduit.Rows.RemoveAt(gv_ListeProduit.SelectedRows[0].Index);
                }
            }
        }

        private void btn_Inserer_Click(object sender, EventArgs e)
        {
            if (nouveau)
            {
                Frm_ListeIntrant frm = new Frm_ListeIntrant();
                frm.ShowDialog();
            }
           
        }

        private void btn_FichePreInventaire_Click(object sender, EventArgs e)
        {
            TR_FichePreInventaire rpt = new TR_FichePreInventaire();
            rpt.objectDataSource1.DataSource = Inventaire.FichePreInventaire(Convert.ToInt32(txt_numero.Value));
            rpt.DataSource = rpt.objectDataSource1;
            Frm_ReportViewer frm = new Frm_ReportViewer("FICHE DE PRE INVENTAIRE", rpt);
            frm.MdiParent = Application.OpenForms["Frm_Menu"];
            frm.Show();
        }

        private void btn_ficheinv_Click(object sender, EventArgs e)
        {
            TR_FicheInventaire rpt = new TR_FicheInventaire();
            rpt.objectDataSource1.DataSource = Inventaire.FicheInventaire(Convert.ToInt32(txt_numero.Value));
            rpt.DataSource = rpt.objectDataSource1;
            Frm_ReportViewer frm = new Frm_ReportViewer("FICHE D'INVENTAIRE", rpt);
            frm.MdiParent = Application.OpenForms["Frm_Menu"];
            frm.Show();
        }
        #endregion

        #region DataGridView
        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                Detailler((Inventaire)bds_Inventaire.Current);
            }
            else
            {
                Viderchamp();
            }
        }

        private void gv_ListeProduit_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (!gv_ListeProduit.ReadOnly)
            {
                if (gv_ListeProduit.SelectedRows != null && gv_ListeProduit.SelectedRows.Count > 0)
                {
                    gv_ListeProduit.SelectedRows[0].Cells["Ecart"].Value =
                        Convert.ToDecimal(gv_ListeProduit.SelectedRows[0].Cells["StockLogique"].Value) -
                        Convert.ToDecimal(gv_ListeProduit.SelectedRows[0].Cells["StockPhysique"].Value);
                }
            }
        }
        #endregion

        #region Zone de liste déroulante
        private void ddl_TypeInventaire_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!ddl_TypeInventaire.ReadOnly)
            {
                gv_ListeProduit.Rows.Clear();
                if (ddl_TypeInventaire.Text.Trim().ToLower() == "totale")
                {
                    foreach (Intrants obj in lstIntrants)
                    {
                        
                        gv_ListeProduit.Rows.Add(obj.CodeIntrant,
                                                 obj.CodeCategorie,
                                                 obj.LibelleIntrant,
                                                 obj.StockDisponible,
                                                 0,
                                                 obj.StockDisponible,
                                                 false,
                                                 "");
                    }
                    btn_Inserer.Enabled = false;
                    btn_Retirer.Enabled = false;
                }
                else
                {
                    btn_Inserer.Enabled = true;
                    btn_Retirer.Enabled = true;
                }
            }
        }
        #endregion

        private void btn_Cloture_Click(object sender, EventArgs e)
        {
            if (!nouveau )
            {
                if (gv_Liste.SelectedRows == null && gv_Liste.SelectedRows.Count == 0)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Veuillez sélectionner un inventaire avant de la clôturer", CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }
                if (gv_Liste.CurrentRow.Cells["Etat"].Value.ToString().Trim() == "CLÖTURER")
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Inventaire déjà clôturé", CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }
            }
            RadMessageBox.ThemeName = this.ThemeName;
            if (RadMessageBox.Show(this,"Voulez-vous vraiment clôturer l'inventaire ?", CurrentUser.LogicielHote,
             MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                if (ddl_TypeInventaire.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner le type de l'inventaire.", CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                ddl_TypeInventaire.Focus();
                return;
            }

            if (gv_ListeProduit.Rows.Count == 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez sélectionner au moins un produit.", CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                btn_Inserer.Focus();
                return;
            }
            
                btn_Enregistrer_Click(null, null);
                Inventaire obj = ((Inventaire)bds_Inventaire.Current);
                obj.Etat = "CLÖTURER";
                obj.DateFin = DateTime.Now;
                 obj.Update();
                 
               
                for (int i = 0; i < gv_ListeProduit.Rows.Count; i++)
                {
                    Intrants objIntra = lstIntrants.Find(x => x.CodeIntrant.Trim() ==
                        gv_ListeProduit.Rows[i].Cells["CodeIntrant"].Value.ToString().Trim() && x.Supprimer == false);
                    if (objIntra != null)
                    {
                        objIntra.StockDisponible = Convert.ToBoolean(
                        gv_ListeProduit.Rows[i].Cells["EstRegulariserSurPhysique"].Value.ToString()) == true ?
                        Convert.ToDecimal(
                        gv_ListeProduit.Rows[i].Cells["StockPhysique"].Value.ToString()) : objIntra.StockDisponible;
                        objIntra.Update();
                    }
                    
                }
                btn_Nouveau.Enabled = true;
                ChargerDonnes(obj);
            }

        }
    }
}