using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using LGC.Business.Parametre;
using Telerik.WinControls.UI;
using LGC.Business;
namespace LGC.UI.Parametre
{
    public partial class Frm_Analyse : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie,parametreCourant = "";
        string[] message;
        DataTable dt = new DataTable();
        int indexVN;
        List<SecteursBiologique> lstSecteursBiologique = new List<SecteursBiologique>();
        List<Analyse> lstAnalyse = new List<Analyse>();
        List<ValeurNormal> lstValeurNormal = new List<ValeurNormal>();
        List<IntrantAnalyse> lstIntrantAnalyse = new List<IntrantAnalyse>();
        List<Intrants> lstIntrants = new List<Intrants>();
        List<UniteMesure> lstUniteMesure = new List<UniteMesure>();
        List<ParametreAnalyse> lstParametreAnalyse = new List<ParametreAnalyse>();
        List<TypePrelevement> lstTypePrelevement = new List<TypePrelevement>();
        List<TrancheAgePatient> lstTrancheAgePatient = new List<TrancheAgePatient>();
        List<PrelevementAnalyse> lstPrelevementAnalyse = new List<PrelevementAnalyse>();
        List<TypeTube> lstTypeTube = new List<TypeTube>();
        List<Pays> lstPays = new List<Pays>();
        
        //List<Ville> lstVille = new List<Ville>();
        //List<FormeJuridiqueOPC> lstFormeJuridique = new List<FormeJuridiqueOPC>();
        //List<PersonnePhysique> lstPersonnePhysique = new List<PersonnePhysique>();
        //List<Emetteur> lstEmetteur = new List<Emetteur>();
        //List<Registraire> lstRegistraire = new List<Registraire>();
        //List<ClassificationOPC> lstClassificationOPC = new List<ClassificationOPC>();
        //List<TypeAffectationVL> lstTypeAffectation = new List<TypeAffectationVL>();

        #endregion

        #region Autres
        private void activerDesactiverControle(bool condition)
        {

            txt_code.ReadOnly = !condition;
            txt_libelle.ReadOnly = !condition;
            meb_cout.ReadOnly=!condition;
            cb_secteurBiologique.ReadOnly=!condition;
            se_heure.ReadOnly = !condition;
            se_jours.ReadOnly = !condition;
            se_minute.ReadOnly = !condition;
            pnl_tit1.Visible = condition;
            pnl_tit2.Visible = condition;
            pvp_info.Enabled = true;
            pvp_intrant.Enabled = !condition;
            pvp_parametre.Enabled = !condition;
            pvp_info.Text = txt_code.ReadOnly  == false? "" : "Informations Générales";
            pvp_intrant.Text = txt_code.ReadOnly  == false? "" : "Intrants";
            pvp_parametre.Text = txt_code.ReadOnly  == false? "" : "Parametres et valeurs normales";
       
               
            
            dgv_Liste.Enabled = !condition;
            gb_prelevement.Visible = !condition;
            gb_prelevement.BringToFront();
            gb_ParametreAnalyseShow.Visible = !condition;
            gb_ParametreAnalyseShow.BringToFront();
            gb_intrantAnalyseEdit.Visible = condition;
            gb_intrantAnalyseEdit.BringToFront();
            dck_prelevement.Visible = condition;
            dck_prelevement.BringToFront();
            gb_intrant.Visible = !condition;
            gb_intrant.BringToFront();
            dck_intrant.Visible = condition;
            dck_intrant.BringToFront();
            btn_Annuler.Visible = condition;
            btn_next.Visible = condition;
            
            
            dgv_ListeParametre.AllowEditRow = condition;
            btn_next.BringToFront();
            btn_back.Visible = condition;
            btn_back.Enabled = false;
            btn_Nouveau.Visible = !condition;
            btn_Modifier.Visible = !condition;
            btn_Supprimer.Visible = !condition;
            btn_Supprimer.BringToFront();
            btn_Actualiser.Enabled = !condition;
            btn_AjouterParametre.Enabled = condition;
            btn_SupprimerParametre.Enabled = condition;
            
        }

        private void RAZ()
        {
            try
            {
                txt_code.Text = "";
                txt_libelle.Text = "";
                meb_cout.Value = 0;
                se_heure.Value = 0;
                se_jours.Value = 0;
                se_minute.Value = 0;
                cb_secteurBiologique.Text = "";
                dgv_ListeParametre.Rows.Clear();
                dgv_ListePrelevementAnalyse.Rows.Clear();
                dgv_ListeIntrantAnalyseDragDrop.Rows.Clear();
                dgv_ListePrelevementAnalyseDragDrop.Rows.Clear();
                ChargerListeIntrant();
                ChargerListeprelevement();
                dgv_ListeIntrantAnalyse.Rows.Clear();
                dgv_ListeParametre.Rows.Clear();
                dgv_ListeParametreAide.Rows.Clear();
                dgv_ListeVN.Rows.Clear();
                dgv_aide.Rows.Clear();
                indexVN = 0;
            }
            catch (Exception)
            {


            }
        }

        private void constituerObjetAnalyse(Analyse  obj)
        {
            obj.CodeAnalyse = txt_code.Text.Trim();
            obj.CodeSecteur = Convert.ToString(cb_secteurBiologique.SelectedValue);
            obj.LibelleAnalyse = txt_libelle.Text.Trim();
            obj.Cout = Convert.ToDecimal(meb_cout.Value);
            obj.Jours = Convert.ToDecimal(se_jours.Value);
            obj.Heure = Convert.ToDecimal(se_heure.Value);
            obj.Minute = Convert.ToDecimal(se_minute.Value);
           
        }

        private void constituerObjetPrelevement(PrelevementAnalyse obj, int l)
        {
            obj.CodeAnalyse = txt_code.Text.Trim();
            obj.CodePrelevement = dgv_ListePrelevementAnalyseDragDrop.Rows[l].Cells["codePrelevement"].Value.ToString();
            TypeTube obj1 = lstTypeTube.Find(k => k.LibelleTypeTube.Trim() ==
                dgv_ListePrelevementAnalyseDragDrop.Rows[l].Cells["TypeTube"].Value.ToString().Trim());

            obj.CodeTypeTube = obj1 != null ? obj1.CodeTypeTube.Trim() : "";
        }

        private void constituerObjetIntrant(IntrantAnalyse obj, int l)
        {
            obj.CodeAnalyse = txt_code.Text.Trim();
            obj.CodeIntrant = dgv_ListeIntrantAnalyseDragDrop.Rows[l].Cells["codeIntrant"].Value.ToString();
            obj.QuantiteMin = Convert.ToDecimal(dgv_ListeIntrantAnalyseDragDrop.Rows[l].Cells["quantiteMin"].Value.ToString());
            obj.QuantiteMax = 10000000;
        }

        private void constituerObjetParametre(ParametreAnalyse obj, int l)
        {
            obj.CodeAnalyse = txt_code.Text.Trim();
            obj.LibelleParametre = dgv_ListeParametre.Rows[l].Cells["LibelleParametre"].Value.ToString();
            obj.Code = dgv_ListeParametre.Rows[l].Cells["code"].Value != null ? dgv_ListeParametre.Rows[l].Cells["code"].Value.ToString() : "";
           
        }

        private void constituerObjetVN(ValeurNormal obj, int l)
        {
            obj.CodeAnalyse = txt_code.Text.Trim();
            obj.CodeTranche = dgv_ListeVN.Rows[l].Cells["codeTranche"].Value.ToString();
            obj.LibelleParametre = dgv_ListeVN.Rows[l].Cells["Parametre"].Value.ToString();
            obj.LibelleVN = dgv_ListeVN.Rows[l].Cells["libelleVN"].Value.ToString();
            
        }
        private void detaillerObjet(Analyse  obj)
        {
           txt_code.Text = obj.CodeAnalyse;
           cb_secteurBiologique.Text = obj.CodeSecteur;
           txt_libelle.Text = obj.LibelleAnalyse;
           meb_cout.Value = obj.Cout;
           se_heure.Value = obj.Heure;
           se_jours.Value = obj.Jours;
           se_minute.Value = obj.Minute;
           ChargerListeIntrantAnalyse(obj);
           ChargerListeParametreAnalyse(obj);
           ChargerListeprelevementAnalyse(obj);
           ChargerListeAide(obj);
        }

        private void ChargerListeIntrant()
        {
            lstIntrants = Intrants.Liste(null,null, null, null, null, null, null, null, null, null, null, null, false, null, null);
            dragAndDropRadGrid2.Rows.Clear();
            foreach (Intrants mLigne in lstIntrants)
            {
                dragAndDropRadGrid2.Rows.Add(mLigne.CodeIntrant,
               mLigne.CodeCategorie,
               mLigne.LibelleIntrant,
               mLigne.Code);
            }
            //bds_Intrants.DataSource = lstIntrants;
        }

        private void ChargerListeSecteur()
        {
            lstSecteursBiologique = SecteursBiologique.Liste(null, null, null, null, null, null, null,false,null);
            bds_SecteursBiologique.DataSource = lstSecteursBiologique;
        }

        private void ChargerListeprelevement()
        {

            lstTypePrelevement = TypePrelevement.Liste(null, null,
                null, null, null, null, null, null, false, null);
            dragAndDropRadGrid1.Rows.Clear();
            foreach (TypePrelevement mLigne in lstTypePrelevement)
            {
                dragAndDropRadGrid1.Rows.Add(mLigne.CodePrelevement,
               mLigne.LibellePrelevement,
               mLigne.CodeUniteMesure);
            }
           
        }
        private void ChargerListeTypeTube()
        {
            lstTypeTube = TypeTube.Liste(null, null, null, null,
                null, null, null, false, null);
            bds_TypeTube.DataSource = lstTypeTube;
        }
        private void ChargerListeIntrantAnalyse(Analyse obj)
        {
            if (obj != null)
            {
                lstIntrantAnalyse = IntrantAnalyse.Liste(null,null, obj.CodeAnalyse, null, null, null, null, null, null, null, false, null);
                bds_IntrantAnalyse.DataSource = lstIntrantAnalyse;
                dgv_ListeIntrantAnalyseDragDrop.Rows.Clear();
                foreach (IntrantAnalyse item in lstIntrantAnalyse)
                {
                    Intrants objIntr = lstIntrants.Find(x => x.CodeIntrant.Trim() ==
                        item.CodeIntrant.Trim());
                    dgv_ListeIntrantAnalyseDragDrop.Rows.Add(objIntr != null ? objIntr.CodeCategorie.Trim() : ""
                        , item.CodeIntrant,
                        item.LibelleIntrant,
                        objIntr != null ? objIntr.Code : "",
                        item.QuantiteMin,
                        item.QuantiteMax);
                }
            }
        }

        private void ChargerListeParametreAnalyse(Analyse obj)
        {
            if (obj != null)
            {
                lstParametreAnalyse = ParametreAnalyse.Liste(obj.CodeAnalyse, null, null, null, null, null, null, null, false, null);
                bds_ParametreAnalyse.DataSource = lstParametreAnalyse;
                dgv_ListeParametre.Rows.Clear();
                foreach (ParametreAnalyse item in lstParametreAnalyse)
                {
                    dgv_ListeParametre.Rows.Add(item.CodeAnalyse, item.LibelleParametre, item.Code);
                }
            }
        }

        private void ChargerListeprelevementAnalyse(Analyse obj)
        {
            if (obj != null)
            {
                lstPrelevementAnalyse = PrelevementAnalyse.Liste(obj.CodeAnalyse,null, null,
                null, null, null, null, null, false, null);
                bds_PrelevementAnalyse.DataSource = lstPrelevementAnalyse;
                dgv_ListePrelevementAnalyseDragDrop.Rows.Clear();
                foreach (PrelevementAnalyse item in lstPrelevementAnalyse)
                {
                    TypePrelevement objTypePrel = lstTypePrelevement.Find(x => x.CodePrelevement.Trim() ==
                        item.CodePrelevement.Trim());
                    TypeTube objTypeTube = lstTypeTube.Find(x => x.CodeTypeTube.Trim() ==
                        item.CodeTypeTube.Trim());
                    dgv_ListePrelevementAnalyseDragDrop.Rows.Add(item.CodePrelevement, item.LibellePrelevement, 
                        objTypePrel != null ? objTypePrel.CodeUniteMesure : "", 
                        objTypeTube != null ? objTypeTube.LibelleTypeTube : "");
                }
            }
            
        }

        private void ChargerListeUniteMesure()
        {
            lstUniteMesure = UniteMesure.Liste(null, null, null, null,
                           null, null, null, false, null);
            bds_UniteMesure.DataSource = lstUniteMesure;
        }   

        private void ChargerListeVN(ParametreAnalyse obj)
        {
            lstValeurNormal = ValeurNormal.Liste(obj.CodeAnalyse, null, obj.LibelleParametre, null, null, null, null, null, null, null, null,
                 false, null);
            bds_ValeurNormal.DataSource = lstValeurNormal;
        }

        private void ChargerListeAide(Analyse obj)
        {
            lstValeurNormal = ValeurNormal.Liste(obj.CodeAnalyse, null, null, null, null, null, null, null, null, null, null,
                 false, null);

            dgv_aide.Rows.Clear();
            dgv_ListeVN.Rows.Clear();
            foreach (ValeurNormal item in lstValeurNormal)
            {
               

                dgv_aide.Rows.Add(item.NumLigne, item.CodeTranche,
                    item.LibelleVN,
                    item.LibelleParametre,
                    item.CodeTranche);

                /****************** Ajout par delphin (19/02/2020)*********************/
                dgv_ListeVN.Rows.Add(item.NumLigne, item.CodeTranche,
                    item.LibelleVN,
                    item.LibelleParametre,
                    item.CodeTranche);
                /***************************************/
                if (item.NumLigne > indexVN)
                {
                    indexVN = Convert.ToInt32(item.NumLigne);
                }
            }
        }

        private void ChargerListeTrancheAgePatient()
        {
            lstTrancheAgePatient = TrancheAgePatient.Liste(null, null, null, null, null,
                null, null, null, null, null, null, false, null);
            bds_TrancheAgePatient.DataSource = lstTrancheAgePatient;
        }

        
        private void ChargerListe(Analyse  obj)
        {
            lstAnalyse = Analyse.Liste(null, null, null, null,
                null, null, null, null, null, null, null, null, false, null);
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
        #endregion
        
        #region Formulaire

        public Frm_Analyse()
        {
            InitializeComponent();
            
        }

        private void Frm_Analyse_Load(object sender, EventArgs e)
        {
            dgv_Liste.BringToFront();
            ChargerListeprelevement();
            ChargerListeIntrant();
            activerDesactiverControle(false);
            ChargerListeUniteMesure();
            ChargerListeTrancheAgePatient();
            ChargerListeSecteur();
            ChargerListeTypeTube();
            ChargerListe(null);
            if (nouveau)
                btn_Nouveau_Click(null, null);
        }
        #endregion

        #region bouton de commande
        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            
            nouveau = true;
            ChargerListeprelevement();
            ChargerListeIntrant();
            pv_Details.SelectedPage = pvp_info;
            activerDesactiverControle(true);
            txt_libelle.Focus();
            RAZ();
            
        }
        
        private void btn_Modifier_Click(object sender, EventArgs e)
        {
             if (dgv_Liste.SelectedRows != null &&
               dgv_Liste.SelectedRows.Count > 0)
            {
                nouveau = false;
                ChargerListeprelevement();
                ChargerListeIntrant();
                activerDesactiverControle(true);
                txt_code.ReadOnly = true;
                txt_libelle.Focus();
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
                    //Analyse  obj = (Analyse )bds_Analyse .Current;
                    //string res = obj.Delete();
                    //message =LGO.Business.Tools.SplitMessage(res);
                    //if (int.Parse(message[0]) > 0)
                    //{
                    //    ChargerListe((Analyse )bds_Analyse .Current);
                    //    RadMessageBox.ThemeName = this.ThemeName;
                    //    RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                    //        MessageBoxButtons.OK, RadMessageIcon.Info);
                    //}
                    //else
                    //{
                    //    RadMessageBox.ThemeName = this.ThemeName;
                    //    MessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                    //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
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
            pv_Details.SelectedPage = pvp_info;
            activerDesactiverControle(false);
        ChargerListe((Analyse)bds_Analyse.Current);
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            Analyse  obj = new Analyse ();
            PrelevementAnalyse objPrelevementAnalyse = new PrelevementAnalyse();
            IntrantAnalyse objIntrantAnalyse = new IntrantAnalyse();
            ParametreAnalyse objParametreAnalyse = new ParametreAnalyse();
            ValeurNormal objValeurNormal = new ValeurNormal();

            

            #region controle de saisie

            for (int i = 0; i < dgv_ListeVN.RowCount; i++)
            {
                
                    if (dgv_ListeVN.Rows[i].Cells["nomAttribue"].Value.ToString().Trim() ==
                        "")
                    {
                        dgv_ListeVN.Rows.RemoveAt(i);
                        i--;
                    }

                    else if (dgv_ListeVN.Rows[i].Cells["libelleVN"].Value.ToString().Trim() ==
                        "")
                    {
                        dgv_ListeVN.Rows.RemoveAt(i);
                        i--;
                    }
               
            }

            dgv_ListeParametreAide_SelectionChanging(null, null);
            #endregion

            #region Enregistrement
            if (nouveau)
            {
                constituerObjetAnalyse(obj);
                sortie = obj.Insert();
                message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    for (int i = 0; i < dgv_ListePrelevementAnalyseDragDrop.RowCount; i++)
                    {
                        constituerObjetPrelevement(objPrelevementAnalyse, i);
                        sortie = objPrelevementAnalyse.Insert();  
                    }

                    for (int i = 0; i < dgv_ListeIntrantAnalyseDragDrop.RowCount; i++)
                    {
                        constituerObjetIntrant(objIntrantAnalyse, i);
                        sortie = objIntrantAnalyse.Insert();
                    }

                    for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
                    {
                        constituerObjetParametre(objParametreAnalyse, i);
                        sortie = objParametreAnalyse.Insert();
                    }
                    for (int i = 0; i < dgv_ListeVN.RowCount; i++)
                    {
                        constituerObjetVN(objValeurNormal, i);
                        sortie = objValeurNormal.Insert();
                    }
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());

                    ChargerListe(obj);
                    pv_Details.SelectedPage = pvp_info;
                    pvp_valeurNormales.Enabled = false;
                    nouveau = false;
                    activerDesactiverControle(false);
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
                obj = (Analyse)bds_Analyse.Current;
                PrelevementAnalyse.Delete_All(obj.CodeAnalyse.Trim());
                IntrantAnalyse.Delete_All(obj.CodeAnalyse.Trim());
                ParametreAnalyse.Delete_All(obj.CodeAnalyse.Trim());
                
                constituerObjetAnalyse(obj);
                sortie = obj.Update();
                message = LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    for (int i = 0; i < dgv_ListePrelevementAnalyseDragDrop.RowCount; i++)
                    {
                        constituerObjetPrelevement(objPrelevementAnalyse, i);
                        sortie = objPrelevementAnalyse.Insert();  
                    }

                    for (int i = 0; i < dgv_ListeIntrantAnalyseDragDrop.RowCount; i++)
                    {
                        constituerObjetIntrant(objIntrantAnalyse, i);
                        sortie = objIntrantAnalyse.Insert();
                    }

                    for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
                    {
                        constituerObjetParametre(objParametreAnalyse, i);
                        sortie = objParametreAnalyse.Insert();
                    }
                    for (int i = 0; i < dgv_ListeVN.RowCount; i++)
                    {
                        constituerObjetVN(objValeurNormal, i);
                        sortie = objValeurNormal.Insert();
                    }
                    nouveau = false;
                    activerDesactiverControle(false);
                    pv_Details.SelectedPage = pvp_info;
                    pvp_valeurNormales.Enabled = false;
                    ChargerListe((Analyse)bds_Analyse.Current);
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
        private void bds_Zone_CurrentChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region DataGridView
        //private void dgv_Liste_Resize(object sender, EventArgs e)
        //{
        //    if (dgv_Liste.Width > 650)
        //    {
        //        dgv_Liste.Columns["libelleZone"].Width = dgv_Liste.Width -
        //            dgv_Liste.Columns["codeZone"].Width - 7;
        //    }
        //    else
        //    {
        //        dgv_Liste.Columns["libelleZone"].Width = 505;
        //        dgv_Liste.Columns["codeZone"].Width = 138;
        //    }
        //}

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

        private void dgv_Liste_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            Program.formatDate(sender, e);
        }

        private void dgv_Liste_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            Program.activerGridViewTooltipText(sender, e);
        }

        #endregion

        private void txt_ValMinPlacement_Click(object sender, EventArgs e)
        {

        }

        private void txt_PeriodiciteCalculVl_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_AjouterParametre_Click(object sender, EventArgs e)
        {
            dgv_ListeParametre.Rows.Add("","");
        }

        private void btn_SupprimerParametre_Click(object sender, EventArgs e)
        {
            if (dgv_ListeParametre.SelectedRows != null &&
                dgv_ListeParametre.SelectedRows.Count > 0)
            {

                bool ligneTrouver = false; int indexTableRecherche = 0;
                do
                {
                    if (dgv_aide.RowCount > 0)
                    {
                        if (dgv_ListeParametre.CurrentRow.Cells["LibelleParametre"].Value.ToString().Trim() ==
                        dgv_aide.Rows[indexTableRecherche].Cells["Parametre"].Value.ToString().Trim())
                        {
                             RadMessageBox.ThemeName = this.ThemeName;
                             if (RadMessageBox.Show(this, "Ce parametre contient déjà des valeurs normales. Voulez-vous vraiment le supprimer?",
                                  CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                                 RadMessageIcon.Question) == DialogResult.Yes)
                             {
                                 // Si il trouve une ligne il supprime toutes les lignes
                                 for (int i = indexTableRecherche; i < dgv_aide.RowCount; i++)
                                 {
                                     if (dgv_ListeParametre.CurrentRow.Cells["LibelleParametre"].Value.ToString().Trim() ==
                                        dgv_aide.Rows[i].Cells["Parametre"].Value.ToString().Trim())
                                     {
                                         dgv_aide.Rows.RemoveAt(dgv_aide.Rows[i].Index);
                                         i--;
                                     }
                                 }
                                
                                 ligneTrouver = true;
                             }
                             else
                             {
                                 return;
                             }
                             
                        }

                    }

                    indexTableRecherche++;
                } while (ligneTrouver == false && indexTableRecherche < dgv_aide.RowCount);

               indexTableRecherche = 0;
                do
                {
                    if (dgv_ListeVN.RowCount > 0)
                    {
                        if (dgv_ListeParametre.CurrentRow.Cells["LibelleParametre"].Value.ToString().Trim() ==
                        dgv_ListeVN.Rows[indexTableRecherche].Cells["Parametre"].Value.ToString().Trim())
                        {
                            if (ligneTrouver)
                            {
                                // Si il trouve une ligne il supprime toutes les lignes
                                for (int i = indexTableRecherche; i < dgv_ListeVN.RowCount; i++)
                                {
                                    if (dgv_ListeParametre.CurrentRow.Cells["LibelleParametre"].Value.ToString().Trim() ==
                                       dgv_ListeVN.Rows[i].Cells["Parametre"].Value.ToString().Trim())
                                    {
                                        dgv_ListeVN.Rows.RemoveAt(dgv_ListeVN.Rows[i].Index);
                                        i--;
                                    }
                                }
                               
                            }
                            else
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                if (RadMessageBox.Show(this, "Ce parametre contient déjà des valeurs normales. Voulez-vous vraiment le supprimer?",
                                     CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                                    RadMessageIcon.Question) == DialogResult.Yes)
                                {
                                    // Si il trouve une ligne il supprime toutes les lignes
                                    for (int i = indexTableRecherche; i < dgv_ListeVN.RowCount; i++)
                                    {
                                        if (dgv_ListeParametre.CurrentRow.Cells["LibelleParametre"].Value.ToString().Trim() ==
                                           dgv_ListeVN.Rows[i].Cells["Parametre"].Value.ToString().Trim())
                                        {
                                            dgv_ListeVN.Rows.RemoveAt(dgv_ListeVN.Rows[i].Index);
                                            i--;
                                        }
                                    }
                                }
                                else
                                {
                                    return;
                                }
                                
                            }
                            
                            
                        }

                    }

                    indexTableRecherche++;
                } while (indexTableRecherche < dgv_aide.RowCount);

                
                dgv_ListeParametre.Rows.RemoveAt(dgv_ListeParametre.CurrentRow.Index);
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (pv_Details.SelectedPage == pvp_info)
            {
                if (txt_code.Text.Trim() == "")
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "La saisie du code de l'analyse est obligatoire.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    txt_code.Focus();
                    return;
                }
                if (txt_libelle.Text.Trim() == "")
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "La saisie du libellé de l'analyse est obligatoire.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    txt_libelle.Focus();
                    return;
                }

                if (meb_cout.Text.Trim() == "" || meb_cout.Text.Trim() == "0")
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "La saisie du coût de l'analyse est obligatoire.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    meb_cout.Focus();
                    return;
                }

                if (cb_secteurBiologique.Text.Trim() ==  "")
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "La sélection du secteur biologique de l'analyse est obligatoire.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    cb_secteurBiologique.Focus();
                    return;
                }
                if (Convert.ToDecimal(se_jours.Value) < 0)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Jours Invalide.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    se_jours.Focus();
                    return;
                }
                if (Convert.ToDecimal(se_heure.Value) < 0)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Heure Invalide.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    se_heure.Focus();
                    return;
                }
                if (Convert.ToDecimal(se_minute.Value) < 0)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Minute Invalide.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    se_minute.Focus();
                    return;
                }
                if (dgv_ListePrelevementAnalyseDragDrop.RowCount == 0)
                {
                     RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Veuillez renseigner les prélevement à éffectuer cet analyse.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    dgv_ListePrelevementAnalyseDragDrop.Focus();
                    return;
                }
                btn_back.Enabled = true;
                pvp_intrant.Enabled = true;
                pv_Details.SelectedPage = pvp_intrant;
                pvp_info.Enabled = false;
            }
            else if (pv_Details.SelectedPage == pvp_intrant)
            {
                if (txt_libelle.Text.Trim() == "")
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "La saisie du libellé de l'analyse est obligatoire.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    txt_libelle.Focus();
                    return;
                }

                if (meb_cout.Text.Trim() == "" || meb_cout.Text.Trim() == "0")
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "La saisie du coût de l'analyse est obligatoire.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    meb_cout.Focus();
                    return;
                }

                if (cb_secteurBiologique.Text.Trim() == "")
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "La sélection du secteur biologique de l'analyse est obligatoire.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    cb_secteurBiologique.Focus();
                    return;
                }

                if (dgv_ListePrelevementAnalyseDragDrop.RowCount == 0)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Veuillez renseigner le(s) prélevement(s) à éffectuer pour cet analyse.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    dgv_ListePrelevementAnalyseDragDrop.Focus();
                    return;
                }

                //if (dgv_ListeIntrantAnalyseDragDrop.RowCount == 0)
                //{
                //    RadMessageBox.ThemeName = this.ThemeName;
                //    RadMessageBox.Show(this, "Veuillez renseigner le(s) intrant(s) à utiliser pour cet analyse.",
                //        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                //    dgv_ListeIntrantAnalyseDragDrop.Focus();
                //    return;
                //}

                //for (int i = 0; i < dgv_ListeIntrantAnalyseDragDrop.RowCount; i++)
                //{
                //    if (dgv_ListeIntrantAnalyseDragDrop.Rows[i].Cells["QuantiteMin"].Value == null ||
                //        dgv_ListeIntrantAnalyseDragDrop.Rows[i].Cells["QuantiteMin"].Value.ToString() == string.Empty ||
                //        dgv_ListeIntrantAnalyseDragDrop.Rows[i].Cells["QuantiteMin"].Value.ToString() == "0")
                //    {
                //        RadMessageBox.ThemeName = this.ThemeName;
                //        RadMessageBox.Show(this, "Veuillez renseigner la quantite de l'intrant " +
                //        dgv_ListeIntrantAnalyseDragDrop.Rows[i].Cells["LibelleIntrant"].Value.ToString() + " à utiliser pour cet analyse.",
                //            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                //        dgv_ListeIntrantAnalyseDragDrop.Focus();
                //        return;
                //    }
                    
                //}

                pvp_parametre.Enabled = true;
                pv_Details.SelectedPage = pvp_parametre;
                pvp_intrant.Enabled = false;
            }
            else if (pv_Details.SelectedPage == pvp_parametre)
            {
                if (dgv_ListeParametre.RowCount == 0)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Veuillez renseigner le(s) parametre(s) de l'analyse.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    dgv_ListeIntrantAnalyseDragDrop.Focus();
                    return;
                }
                for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
                {
                    if (dgv_ListeParametre.Rows[i].Cells["LibelleParametre"].Value.ToString()
                        == "")
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, "Veuillez renseigner le(s) parametre(s).",
                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                        dgv_ListeIntrantAnalyseDragDrop.Focus();
                        return;
                    }
                }
                dgv_ListeParametreAide.Rows.Clear();
                for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
                {
                    int index = dgv_ListeParametreAide.Rows.Count;

                        GridViewRowInfo newRow = dgv_ListeParametreAide.Rows.NewRow();
                        newRow.Cells["LibelleParametre"].Value = dgv_ListeParametre.Rows[i].Cells["LibelleParametre"].Value != null ?
                            dgv_ListeParametre.Rows[i].Cells["LibelleParametre"].Value.ToString() : "";
                        newRow.Cells["Code"].Value = dgv_ListeParametre.Rows[i].Cells["Code"].Value != null ?
                            dgv_ListeParametre.Rows[i].Cells["Code"].Value.ToString() : "";
                       
                        dgv_ListeParametreAide.Rows.Insert(index, newRow);
                }
                pvp_valeurNormales.Enabled = true;
                pv_Details.SelectedPage = pvp_valeurNormales;
                pvp_parametre.Enabled = false;
                btn_next.Visible = false;
                btn_Enregistrer.Visible = true;
                btn_Enregistrer.BringToFront();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            
            if (pv_Details.SelectedPage == pvp_intrant)
            {
                btn_back.Enabled = false;
                pvp_info.Enabled = true;
                pv_Details.SelectedPage = pvp_info;
                pvp_intrant.Enabled = false;
            }
            else if (pv_Details.SelectedPage == pvp_parametre)
            {
                pvp_intrant.Enabled = true;
                pv_Details.SelectedPage = pvp_intrant;
                pvp_parametre.Enabled = false;
               
            }
            else if (pv_Details.SelectedPage == pvp_valeurNormales)
            {
                pvp_parametre.Enabled = true;
                btn_next.Visible = true;
                btn_next.BringToFront();
                btn_Enregistrer.Visible = false;
                pv_Details.SelectedPage = pvp_parametre;
                pvp_valeurNormales.Enabled = false;

            }
        }

        private void dgv_aide_Click(object sender, EventArgs e)
        {

        }

        private void btn_AjouterVN_Click(object sender, EventArgs e)
        {
            if (dgv_ListeParametreAide.SelectedRows != null &&
                dgv_ListeParametreAide.SelectedRows.Count > 0)
            {
                indexVN++;
                 dgv_ListeVN.Rows.Add(indexVN, "", "", dgv_ListeParametreAide.CurrentRow.Cells["LibelleParametre"].Value.ToString());
               
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez selectionner le parametre " +
                    "auquel vous voulez attribuer de valeur normale.", CurrentUser.LogicielHote, MessageBoxButtons.OK,
                    RadMessageIcon.Error);
            }
        }

        private void pv_Details_SelectedPageChanged(object sender, EventArgs e)
        {

        }

        private void dgv_ListeParametreAide_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeParametreAide.SelectedRows != null &&
                dgv_ListeParametreAide.SelectedRows.Count > 0)
            {
                //dgv_ListeVN.Rows.Clear();
                ////Charger les Valeurs normales du parametre sélectionner
                //for (int i = 0; i < dgv_aide.RowCount; i++)
                //{
                //    if (dgv_ListeParametreAide.CurrentRow.Cells["LibelleParametre"].Value.ToString().Trim()==
                //        dgv_aide.Rows[i].Cells["Parametre"].Value.ToString().Trim())
                //    { 
                //        int index = dgv_ListeVN.Rows.Count;

                //        GridViewRowInfo newRow = dgv_ListeVN.Rows.NewRow();
                //        newRow.Cells["Index"].Value =
                //            dgv_aide.Rows[i].Cells["Index"].Value.ToString();
                //        newRow.Cells["nomAttribue"].Value =
                //            dgv_aide.Rows[i].Cells["nomAttribue"].Value.ToString();
                //        newRow.Cells["libelleVN"].Value =
                //            dgv_aide.Rows[i].Cells["libelleVN"].Value.ToString().Trim();
                //        newRow.Cells["Parametre"].Value =
                //            dgv_aide.Rows[i].Cells["Parametre"].Value.ToString().Trim();
                //        newRow.Cells["codeTranche"].Value =
                //            dgv_aide.Rows[i].Cells["codeTranche"].Value.ToString().Trim();
                //        dgv_ListeVN.Rows.Insert(index, newRow);
                //    }
                //}

                for (int i = 0; i < dgv_ListeVN.RowCount; i++)
                {
                    if (dgv_ListeParametreAide.CurrentRow.Cells["LibelleParametre"].Value.ToString().Trim() ==
                        dgv_ListeVN.Rows[i].Cells["Parametre"].Value.ToString().Trim())
                    {

                        dgv_ListeVN.Rows[i].IsVisible = true;
                    }
                    else
                        dgv_ListeVN.Rows[i].IsVisible = false;
                }

            }
        }

        private void dgv_ListeParametreAide_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
            #region Commenté par delphin ce 19/02/2020
            //if (dgv_ListeParametreAide.SelectedRows != null &&
            //    dgv_ListeParametreAide.SelectedRows.Count > 0)
            //{
            //    for (int i = 0; i < dgv_ListeVN.RowCount; i++)
            //    {
            //        if (dgv_ListeVN.Rows[i].Cells["nomAttribue"].Value.ToString().Trim() ==
            //            "" )
            //        {
            //            dgv_ListeVN.Rows.RemoveAt(i);
            //            i--;
            //        }

            //        else if (dgv_ListeVN.Rows[i].Cells["libelleVN"].Value.ToString().Trim() ==
            //            "")
            //        {
            //            dgv_ListeVN.Rows.RemoveAt(i);
            //            i--;
            //        }
            //    }
            //    for (int i = 0; i < dgv_ListeVN.RowCount; i++)
            //    {
            //        //Recherche de la ligne dans le dgv_aide
            //        bool ligneTrouver = false; int indexTableRecherche = 0;
            //        do
            //        {
            //            if (dgv_aide.RowCount > 0)
            //            {
            //                if (Convert.ToDecimal(dgv_ListeVN.Rows[i].Cells["Index"].Value.ToString().Trim()) ==
            //                Convert.ToDecimal(dgv_aide.Rows[indexTableRecherche].Cells["Index"].Value.ToString().Trim()))
            //                {
            //                    // Si il trouve une ligne il met à jour les informations
            //                    dgv_aide.Rows[indexTableRecherche].Cells["nomAttribue"].Value = dgv_ListeVN.Rows[i].Cells["nomAttribue"].Value;
            //                    dgv_aide.Rows[indexTableRecherche].Cells["libelleVN"].Value = dgv_ListeVN.Rows[i].Cells["libelleVN"].Value;
            //                    ligneTrouver = true;
            //                }

            //            }

            //            indexTableRecherche++;
            //        } while (ligneTrouver == false && indexTableRecherche < dgv_aide.RowCount);

            //        // si aucune ligne n'est trouvée. Il fait une insertion dans la grille dgv_aide
            //        if (!ligneTrouver)
            //        {
            //            int index = dgv_aide.Rows.Count;

            //            GridViewRowInfo newRow = dgv_aide.Rows.NewRow();
            //            newRow.Cells["Index"].Value = 
            //                dgv_ListeVN.Rows[i].Cells["Index"].Value.ToString();
            //            newRow.Cells["nomAttribue"].Value =
            //                dgv_ListeVN.Rows[i].Cells["nomAttribue"].Value.ToString();
            //            newRow.Cells["libelleVN"].Value =
            //                dgv_ListeVN.Rows[i].Cells["libelleVN"].Value.ToString().Trim();
            //            newRow.Cells["Parametre"].Value =
            //                dgv_ListeVN.Rows[i].Cells["Parametre"].Value.ToString();
            //            newRow.Cells["codeTranche"].Value =
            //                dgv_ListeVN.Rows[i].Cells["codeTranche"].Value.ToString();
            //             dgv_aide.Rows.Insert(index, newRow);

            //        }
            //    }
            //} 
            #endregion
        }

        private void btn_SupprimerVN_Click(object sender, EventArgs e)
        {
            if (dgv_ListeVN.SelectedRows != null &&
                dgv_ListeVN.SelectedRows.Count > 0)
            {
                bool ligneTrouver = false; int indexTableRecherche = 0;
                do
                {
                    if (dgv_aide.RowCount > 0)
                    {
                        if (Convert.ToDecimal(dgv_ListeVN.CurrentRow.Cells["Index"].Value.ToString().Trim()) ==
                        Convert.ToDecimal(dgv_aide.Rows[indexTableRecherche].Cells["Index"].Value.ToString().Trim()))
                        {
                            // Si il trouve une ligne il supprime
                            dgv_aide.Rows.RemoveAt(dgv_aide.Rows[indexTableRecherche].Index);
                            indexTableRecherche--;
                            ligneTrouver = true;
                        }

                    }

                    indexTableRecherche++;
                } while (ligneTrouver == false && indexTableRecherche < dgv_aide.RowCount);

                dgv_ListeVN.Rows.RemoveAt(dgv_ListeVN.CurrentRow.Index);
            }
        }

        private void dgv_ListeParametre_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeParametre.SelectedRows != null &&
                dgv_ListeParametre.SelectedRows.Count > 0)
            {
                parametreCourant = dgv_ListeParametre.CurrentRow.Cells["LibelleParametre"].Value.ToString().Trim();
            }
            else
            {
                parametreCourant = "";
            }
            
        }

        private void dgv_ListeParametre_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (dgv_ListeParametre.SelectedRows != null &&
               dgv_ListeParametre.SelectedRows.Count > 0)
            {
                if (e.Column.Name.ToLower() == "libelleparametre")
                {
                    if (dgv_ListeParametre.Rows[e.RowIndex].Cells["LibelleParametre"].Value == null ||
                        dgv_ListeParametre.Rows[e.RowIndex].Cells["LibelleParametre"].Value.ToString().Trim() == string.Empty)
                    {

                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, "Parametre Invalide.", CurrentUser.LogicielHote, MessageBoxButtons.OK,
                            RadMessageIcon.Error);
                        dgv_ListeParametre.Rows[e.RowIndex].Cells["LibelleParametre"].Value = parametreCourant;
                        return;
                    }
                    for (int i = 0; i < dgv_aide.RowCount; i++)
                    {
                        if (dgv_aide.Rows[i].Cells["Parametre"].Value.ToString().Trim() ==
                            parametreCourant)
                        {
                            dgv_aide.Rows[i].Cells["Parametre"].Value =
                                dgv_ListeParametre.Rows[e.RowIndex].Cells["LibelleParametre"].Value.ToString().Trim();
                        }
                    }

                    for (int i = 0; i < dgv_ListeVN.RowCount; i++)
                    {
                        if (dgv_ListeVN.Rows[i].Cells["Parametre"].Value.ToString().Trim() ==
                            parametreCourant)
                        {
                            dgv_ListeVN.Rows[i].Cells["Parametre"].Value =
                                dgv_ListeParametre.Rows[e.RowIndex].Cells["LibelleParametre"].Value.ToString().Trim();
                        }
                    }

                    parametreCourant = dgv_ListeParametre.Rows[e.RowIndex].Cells["LibelleParametre"].Value.ToString().Trim();

                }
            }
            
        }

        private void radGroupBox7_Click(object sender, EventArgs e)
        {

        }

        private void dgv_ListeParametreShow_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeParametreShow.SelectedRows != null &&
               dgv_ListeParametreShow.SelectedRows.Count > 0)
            {
                ChargerListeVN((ParametreAnalyse)bds_ParametreAnalyse.Current);
            }
        }

        private void dragAndDropRadGrid1_Enter(object sender, EventArgs e)
        {
            
        }

        private void dragAndDropRadGrid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dragAndDropRadGrid1.SelectedRows != null &&
                 dragAndDropRadGrid1.SelectedRows.Count > 0)
            {
                if (e.KeyChar == 13)
                {
                    dgv_ListePrelevementAnalyseDragDrop.Rows.Add(dragAndDropRadGrid1.CurrentRow.Cells["CodePrelevement"].Value.ToString(),
                        dragAndDropRadGrid1.CurrentRow.Cells["LibellePrelevement"].Value.ToString(),
                        dragAndDropRadGrid1.CurrentRow.Cells["CodeUniteMesure"].Value.ToString(),
                        "");
                    dragAndDropRadGrid1.Rows.RemoveAt(dragAndDropRadGrid1.CurrentRow.Index);

                }
            }
        }

        private void dgv_ListePrelevementAnalyseDragDrop_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (dgv_ListePrelevementAnalyseDragDrop.SelectedRows != null &&
            //    dgv_ListePrelevementAnalyseDragDrop.SelectedRows.Count > 0)
            //{
            //    if (e.KeyChar == 13)
            //    {
            //        dragAndDropRadGrid1.Rows.Add(dgv_ListePrelevementAnalyseDragDrop.CurrentRow.Cells["CodePrelevement"].Value.ToString(),
            //            dgv_ListePrelevementAnalyseDragDrop.CurrentRow.Cells["LibellePrelevement"].Value.ToString(),
            //            dgv_ListePrelevementAnalyseDragDrop.CurrentRow.Cells["CodeUniteMesure"].Value.ToString(),
            //            "");
            //        dgv_ListePrelevementAnalyseDragDrop.Rows.RemoveAt(dgv_ListePrelevementAnalyseDragDrop.CurrentRow.Index);
                   
            //    }
            //}
           
        }

        private void dragAndDropRadGrid2_Click(object sender, EventArgs e)
        {

        }

        private void dragAndDropRadGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (dragAndDropRadGrid1.SelectedRows != null &&
                 dragAndDropRadGrid1.SelectedRows.Count > 0)
            {
                dgv_ListePrelevementAnalyseDragDrop.Rows.Add(dragAndDropRadGrid1.CurrentRow.Cells["CodePrelevement"].Value.ToString(),
                        dragAndDropRadGrid1.CurrentRow.Cells["LibellePrelevement"].Value.ToString(),
                        dragAndDropRadGrid1.CurrentRow.Cells["CodeUniteMesure"].Value.ToString(),
                        "");
                    dragAndDropRadGrid1.Rows.RemoveAt(dragAndDropRadGrid1.CurrentRow.Index);
  
            }
        }

        private void dgv_ListePrelevementAnalyseDragDrop_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void dgv_ListePrelevementAnalyseDragDrop_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            //if (e.Column.Name.ToLower() != "typetube")
            //{
            //    if (dgv_ListePrelevementAnalyseDragDrop.SelectedRows != null &&
            //      dgv_ListePrelevementAnalyseDragDrop.SelectedRows.Count > 0)
            //    {
            //        dragAndDropRadGrid1.Rows.Add(dgv_ListePrelevementAnalyseDragDrop.CurrentRow.Cells["CodePrelevement"].Value.ToString(),
            //                dgv_ListePrelevementAnalyseDragDrop.CurrentRow.Cells["LibellePrelevement"].Value.ToString(),
            //                dgv_ListePrelevementAnalyseDragDrop.CurrentRow.Cells["CodeUniteMesure"].Value.ToString(),
            //                "");
            //        dgv_ListePrelevementAnalyseDragDrop.Rows.RemoveAt(dgv_ListePrelevementAnalyseDragDrop.CurrentRow.Index);
            //    }
            //}
        }

        private void dragAndDropRadGrid2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dragAndDropRadGrid2.SelectedRows != null &&
                dragAndDropRadGrid2.SelectedRows.Count > 0)
            {
                if (e.KeyChar == 13)
                {
                    dgv_ListeIntrantAnalyseDragDrop.Rows.Add(dragAndDropRadGrid2.CurrentRow.Cells["CodeCategorie"].Value.ToString(),
                        dragAndDropRadGrid2.CurrentRow.Cells["CodeIntrant"].Value.ToString(),
                        dragAndDropRadGrid2.CurrentRow.Cells["LibelleIntrant"].Value.ToString(),
                         dragAndDropRadGrid2.CurrentRow.Cells["Code"].Value.ToString(),
                         0,
                       10000000);
                    dragAndDropRadGrid2.Rows.RemoveAt(dragAndDropRadGrid2.CurrentRow.Index);

                }
            }
        }

        private void dragAndDropRadGrid2_DoubleClick(object sender, EventArgs e)
        {
            if (dragAndDropRadGrid2.SelectedRows != null &&
               dragAndDropRadGrid2.SelectedRows.Count > 0)
            {
                
                    dgv_ListeIntrantAnalyseDragDrop.Rows.Add(dragAndDropRadGrid2.CurrentRow.Cells["CodeCategorie"].Value.ToString(),
                        dragAndDropRadGrid2.CurrentRow.Cells["CodeIntrant"].Value.ToString(),
                        dragAndDropRadGrid2.CurrentRow.Cells["LibelleIntrant"].Value.ToString(),
                         dragAndDropRadGrid2.CurrentRow.Cells["Code"].Value.ToString(),
                         0,
                       10000000);
                    dragAndDropRadGrid2.Rows.RemoveAt(dragAndDropRadGrid2.CurrentRow.Index);

                
            }
        }

        private void MasterTemplate_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (dgv_ListeVN.SelectedRows != null &&
               dgv_ListeVN.SelectedRows.Count > 0)
            {
                if (e != null && e.Column.Name.ToLower() == "nomattribue")
                {
                    dgv_ListeVN.Rows[e.Row.Index].Cells["codeTranche"].Value = ((TrancheAgePatient)bds_TrancheAgePatient.Current).CodeTranche;
                }
            }
        }

        private void MasterTemplate_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
           
        }
    }
}
