
using LGC.Business.Parametre;
using LGC.UI.GestionDesAnalyses;
using LGC.UI.Parametre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;



namespace LGG.UI.Parametre
{
    public partial class Frm_ListeAnalyse : Telerik.WinControls.UI.RadForm
    {
        #region Declaration
        public List<Analyse> lstAnalyse = new List<Analyse>();
        public List<PrelevementAnalyse> lstPrelevementAnalyse =
            new List<PrelevementAnalyse>();
        public string FrmSource = "";//permet d'avoir le  formulaire d'où on a lancé le formulaire courrant
        public Analyse obj = null;
        #endregion

        #region Autres


       

        #endregion

        #region Formulaire

        public Frm_ListeAnalyse()
        {
            InitializeComponent();
        }

        private void Frm_ListeProduitConditionnementPointDeVente_Load(object sender, EventArgs e)
        {
            bds_Analyses.DataSource = Analyse.Liste(null, null, null, null, null, null, null, null, null, null, null, null, false, null);
        } 
        #endregion

        #region Bouton
        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            bds_Analyses.DataSource = Analyse.Liste(null, null, null, null, null, null, null, null, null, null, null, null, false, null);
        }

        private void btn_inserer_Click(object sender, EventArgs e)
        {
            obj = (Analyse)bds_Analyses.Current;

            if (FrmSource == "demande")
            {
                #region Analyses
                if (obj != null)
                {
                    Frm_DemandeAnalyse frm = (Frm_DemandeAnalyse)Application.OpenForms["Frm_DemandeAnalyse"];
                    bool trouve = false;
                    AnalysePartenaire objP = new AnalysePartenaire();
                    try
                    {
                         objP = AnalysePartenaire.Liste(frm.oPartenaires.IdPersonne, obj.CodeAnalyse.Trim(), null, null, null, null, null, false, null, null)[0];
                    }
                    catch { objP = null; }

                    
                    for (int i = 0; i < frm.gv_Analyses.RowCount; i++)//parcour de la liste des produits déjà sélectionnés
                    {
                        //si le produit en cours sélectionné est déjà sélectionné au paravant il faut arreter la recherche
                        if (obj.CodeAnalyse.Trim() ==
                            frm.gv_Analyses.Rows[i].Cells["CodeAnalyse"].Value.ToString().Trim())
                        {
                            trouve = true;//marquer le produit est déjà sélectionné au paravant
                            break;//permet de quitter  la boucle sans aller à la derniere ittération
                        }
                    }
                    if (!trouve)//si le produit ne faisait pas partir de la sélection de produit sur le formulaire commande
                    {

                        /*si ce produit n'est pas un carreau, bloquer les zones carton et piece*/

                        //Produit objs = new Produit();
                        //objs = Produit.FindFirst(obj.CodeProduit.Trim());
                        frm.gv_Analyses.Rows.Add(obj.LibelleAnalyse.Trim(),
                            1,
                                                      objP != null ? objP.PrixNormal : obj.Cout,
                                                     obj.CodeAnalyse.Trim(),                                                    
                                                     0,
                                                     0,
                                                     objP!=null?objP.PrixNormal: obj.Cout,
                                                    obj.Jours,
                                                    obj.Heure,
                                                    obj.Minute);

                        
                        frm.gv_Analyses.Rows[frm.gv_Analyses.RowCount - 1].Cells["MontantLigne"].Value = (Convert.ToDecimal(frm.gv_Analyses.Rows[frm.gv_Analyses.RowCount - 1].Cells["PrixApresRemise"].Value) * Convert.ToDecimal(frm.gv_Analyses.Rows[frm.gv_Analyses.RowCount - 1].Cells["Qte"].Value));
                        frm.calculerBrut();
                        frm.calculerMontantNet();
                    }
                }
                else
                {
                }

                #endregion
            }
            else
            {
                #region modeleResultat
                Frm_ModeleResultat frm = (Frm_ModeleResultat)Application.OpenForms["Frm_ModeleResultat"];
                frm.oAnalyse = obj;
                Close();
                #endregion
            }
               
        }
        #endregion

        #region Grille de données
        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)//si  au moins une ligne est sélectionnée
            {
                bds_Prelevement.DataSource = PrelevementAnalyse.Liste(((Analyse)bds_Analyses.Current).CodeAnalyse.Trim(), null, null, null, null, null, null, null, false, null);
            }
            else
            {
                //vider la grille d'affichage des produits puisque aucune catégorie n'est sélectionnée
                bds_Prelevement.DataSource = new List<PrelevementAnalyse>();
            }
        } 
        #endregion

        private void btn_Ajouter_Click(object sender, EventArgs e)
        {
            Frm_AnalyseSimplifie frm = new Frm_AnalyseSimplifie();
            frm.ShowDialog();
            bds_Analyses.DataSource = Analyse.Liste(null, null, null, null, null, null, null, null, null, null, null, null, false, null);
            int i = 0;
            foreach (Analyse ligne in bds_Analyses.List as List<Analyse>)
            {
                if (ligne.NumLigne == frm.oAnalyse.NumLigne)
                {
                    bds_Analyses.Position = i;
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