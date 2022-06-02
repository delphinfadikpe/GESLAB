
using LGC.Business;
using LGC.Business.GestionDesAnalyses;
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
    public partial class Frm_AddParametreAnalyseResultat : Telerik.WinControls.UI.RadForm
    {
        #region Declaration
        DataTable dt;
        List<Analyse> lstAnalyse = new List<Analyse>();
        public ResultatParametreAnalyse obj = null;
        #endregion

        #region Autres


       

        #endregion

        #region Formulaire

        public Frm_AddParametreAnalyseResultat(DataTable dtParametre)
        {
            InitializeComponent();
            dt = dtParametre;
        }

        private void Frm_ListeProduitConditionnementPointDeVente_Load(object sender, EventArgs e)
        {
            bds_UniteMesure.DataSource = UniteMesure.Liste(null, null, null, null,
                null, null, null, false, null);
            bds_ResultatParametreAnalyse.DataSource = dt;
            lstAnalyse = Analyse.Liste(null, null, null, null,
                null, null, null, null, null, null, null, null, false, null);
            
        } 
        #endregion

        #region Bouton
       

        private void btn_inserer_Click(object sender, EventArgs e)
        {
            if (mcb_Parametre.Text.Trim() == "")
            {
                 RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner le parametre",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                mcb_Parametre.Focus();
                return;
            }
            if (cb_Unite.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner le l'unité",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                cb_Unite.Focus();
                return;
            }
            //obj = (ResultatParametreAnalyse)bds_ResultatParametreAnalyse.Current;            
               
                
                    #region Analyses
                    if (mcb_Parametre.Text.Trim() != "")
                    {
                        Frm_ResultatDemande frm = (Frm_ResultatDemande)Application.OpenForms["Frm_ResultatDemande"];
                        bool trouve = false;
                        for (int i = 0; i < frm.dgv_ListeParametre.RowCount; i++)//parcour de la liste des produits déjà sélectionnés
                        {
                            //si le produit en cours sélectionné est déjà sélectionné au paravant il faut arreter la recherche
                            if (mcb_Parametre.Text.Trim() ==
                                frm.dgv_ListeParametre.Rows[i].Cells["LibelleParametre"].Value.ToString().Trim() && 
                               cb_Unite.Text.Trim() ==
                                frm.dgv_ListeParametre.Rows[i].Cells["Unite"].Value.ToString().Trim())
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, "Ces informations sont déjà insérés",
                                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                trouve = true;//marquer le produit est déjà sélectionné au paravant
                                break;//permet de quitter  la boucle sans aller à la derniere ittération
                            }
                        }
                        if (!trouve)//si le produit ne faisait pas partir de la sélection de produit sur le formulaire commande
                        {
                            if (txt_ValeurResultat.Text.Trim() == "")
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, "Veuillez saisir la valeur résultat",
                                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                txt_ValeurResultat.Focus();
                                return;
                            }

                            /*si ce produit n'est pas un carreau, bloquer les zones carton et piece*/

                            //Produit objs = new Produit();
                            //objs = Produit.FindFirst(obj.CodeProduit.Trim());
                            try
                            {
                                frm.dgv_ListeParametre.Rows.Add(0,
                               mcb_Parametre.SelectedValue
                               , ""
                               , mcb_Parametre.Text.Trim()
                               , txt_ValeurResultat.Text.Trim()
                               , cb_Unite.Text.Trim(),
                               "",
                               "",
                              lstAnalyse.Find(l => l.CodeAnalyse.Trim() ==
                              mcb_Parametre.SelectedValue.ToString().Trim()).LibelleAnalyse,
                              0,
                              "COMPLETE");


                                
                            }
                            catch (Exception)
                            {
                                mcb_Parametre.Text = "";
                                txt_ValeurResultat.Text = "";
                                cb_Unite.Text = "";
                               
                            }
                           



                        }
                    }
                     else
                {
                }

                    #endregion
               
        }
        #endregion

        #region Grille de données
        
        #endregion
    }
}