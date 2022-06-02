
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
    public partial class Frm_ListeIntrant : Telerik.WinControls.UI.RadForm
    {
        #region Declaration
        public List<Analyse> lstAnalyse = new List<Analyse>();
        public List<PrelevementAnalyse> lstPrelevementAnalyse =
            new List<PrelevementAnalyse>();

        public Intrants obj = null;
        #endregion

        #region Autres


       

        #endregion

        #region Formulaire

        public Frm_ListeIntrant()
        {
            InitializeComponent();
        }

        private void Frm_ListeProduitConditionnementPointDeVente_Load(object sender, EventArgs e)
        {
            bds_Categorie.DataSource = CategorieIntrant.Liste(null,
                null, null, null, null, null, null, false, null);
        } 
        #endregion

        #region Bouton
        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            bds_Categorie.DataSource = Analyse.Liste(null, null, null, null, null, null, null, null, null, null, null, null, false, null);
        }

        private void btn_inserer_Click(object sender, EventArgs e)
        {
            if (gv_Listep.SelectedRows != null && gv_Listep.SelectedRows.Count > 0)
            {
                 obj = ((Intrants)bds_Intrant.Current);

                #region Commande
                if (obj != null)
                {
                    Frm_Inventaire frm = (Frm_Inventaire)Application.OpenForms["Frm_Inventaire"];
                    bool trouve = false;
                    for (int i = 0; i < frm.gv_ListeProduit.Rows.Count; i++)//parcour de la liste des produits déjà sélectionnés
                    {
                        //si le produit en cours sélectionné est déjà sélectionné au paravant il faut arreter la recherche
                        if (obj.CodeIntrant.Trim() ==
                            frm.gv_ListeProduit.Rows[i].Cells["CodeIntrant"].Value.ToString().Trim())
                        {
                            trouve = true;//marquer le produit est déjà sélectionné au paravant
                            break;//permet de quitter  la boucle sans aller à la derniere ittération
                        }
                    }
                    if (!trouve)//si le produit ne faisait pas partir de la sélection de produit sur le formulaire commande
                    {

                        /*si ce produit n'est pas un carreau, bloquer les zones carton et piece*/

                        
                        frm.gv_ListeProduit.Rows.Add(obj.CodeIntrant.Trim(),
                                                     obj.CodeCategorie.Trim(),
                                                     obj.LibelleIntrant.Trim(),
                                                     obj.StockDisponible,
                                                     0,
                                                     obj.StockDisponible,
                                                     false,
                                                     "");
                    }
                }

                #endregion

            } 
        }
        #endregion

        #region Grille de données
        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)//si  au moins une ligne est sélectionnée
            {
                bds_Intrant.DataSource = Intrants.Liste
                    (null, null,((CategorieIntrant)bds_Categorie.Current).CodeCategorie.Trim(),null,null,null,null,null,null,null,null,null,false,null,null);
            }
            else
            {
                //vider la grille d'affichage des produits puisque aucune catégorie n'est sélectionnée
                bds_Intrant.DataSource = new List<Intrants>();
            }
        } 
        #endregion
    }
}