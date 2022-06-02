
using LGC.Business.GestionDesAnalyses;
using LGC.Business.GestionDeStock;
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
    public partial class Frm_ListeDemande : Telerik.WinControls.UI.RadForm
    {
        #region Declaration
        public List<Analyse> lstAnalyse = new List<Analyse>();
        public List<PrelevementAnalyse> lstPrelevementAnalyse =
            new List<PrelevementAnalyse>();
        List<DemandeAnalyse> lstDemandeAnalyse = new List<DemandeAnalyse>();
        DataTable dt, dt1;
        public DemandeAnalyse obj = null;
        decimal totalQteSaisie;
        #endregion

        #region Autres


       

        #endregion

        #region Formulaire

        public Frm_ListeDemande()
        {
            InitializeComponent();
            dt1 = new DataTable();
            dt1.Columns.Add("codeAnalyse");
            dt1.Columns.Add("libelleAnalyse");
            dt1.Columns.Add("codeIntrant");
            dt1.Columns.Add("libelleIntrant");
            dt1.Columns.Add("QuantiteMax");
            dt1.Columns.Add("quantiteMin");
            dt1.Columns.Add("CodeUniteMesure");
            dt1.Columns.Add("stockDisponible");
            dt1.Columns.Add("QteDesctocke");
            dt1.Columns.Add("NumLigne");
            dt1.Columns.Add("NumDemande");
            dt1.Columns.Add("IdDestockage");
            dt1.Columns.Add("QteDispoReelle");
            dt1.Columns.Add("chk");

        }

        private void Frm_ListeProduitConditionnementPointDeVente_Load(object sender, EventArgs e)
        {
            lstDemandeAnalyse = DemandeAnalyse.Liste(null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);
            lstDemandeAnalyse = lstDemandeAnalyse.FindAll(l =>  l.NiveauExecution == "EDITION DE RESULTAT" || l.NiveauExecution == "PRELEVEMENT" ||
                 l.NiveauExecution == "DESTOCKAGE INTRANT");
            bds_Demande.DataSource = lstDemandeAnalyse;
        } 
        #endregion

        #region Bouton
      

        private void btn_inserer_Click(object sender, EventArgs e)
        {
            Frm_DestockageAnalyse frm = (Frm_DestockageAnalyse)Application.OpenForms["Frm_DestockageAnalyse"];
            for (int j = 0; j < gv_ListeDemande.RowCount; j++)
            {
                if (gv_ListeDemande.Rows[j].Cells["chk"].Value != null)
                {
                    if (Convert.ToBoolean(gv_ListeDemande.Rows[j].Cells["chk"].Value.ToString().Trim()) == true)
                    {
                        bds_Demande.Position = j;
                        obj = (DemandeAnalyse)bds_Demande.Current;
                        #region Analyses
                        if (obj != null)
                        {
                            
                            bool trouve = false;
                            for (int i = 0; i < frm.dgv_ListeDestockageDemande.RowCount; i++)//parcour de la liste des produits déjà sélectionnés
                            {
                                dt1.Rows.Add(frm.dgv_ListeDestockageDemande.Rows[i].Cells["codeAnalyse"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["libelleAnalyse"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["codeIntrant"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["libelleIntrant"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["QuantiteMax"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["quantiteMin"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["CodeUniteMesure"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["stockDisponible"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["QteDesctocke"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["NumLigne"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["NumDemande"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["IdDestockage"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["QteDispoReelle"].Value.ToString().Trim()
                                       , frm.dgv_ListeDestockageDemande.Rows[i].Cells["chk"].Value.ToString().Trim());
                                //si le produit en cours sélectionné est déjà sélectionné au paravant il faut arreter la recherche
                                if (obj.NumDemande ==
                                    Convert.ToDecimal(frm.dgv_ListeDestockageDemande.Rows[i].Cells["NumDemande"].Value.ToString().Trim()))
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
                            
                                dt = IntrantAnalyseDestocke.IntrantAnalyse(obj.NumDemande);
                               
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    totalQteSaisie = 0;
                                    for (int k = 0; k < dt1.Rows.Count; k++)
                                    {
                                        if (dt1.Rows[k]["CodeIntrant"].ToString().Trim() ==
                                            dt.Rows[i]["CodeIntrant"].ToString().Trim())
	                                    {
		                                    totalQteSaisie += Convert.ToDecimal(dt1.Rows[k]["QteDesctocke"].ToString().Trim());
                                        }
                        
                                    }
                                    //dt1.Rows.Add(dt.Rows[i]);
                                    dt1.Rows.Add(dt.Rows[i]["codeAnalyse"].ToString().Trim()
                                        , dt.Rows[i]["libelleAnalyse"].ToString().Trim()
                                        , dt.Rows[i]["codeIntrant"].ToString().Trim()
                                        , dt.Rows[i]["libelleIntrant"].ToString().Trim(),
                                        dt.Rows[i]["QuantiteMax"].ToString().Trim()
                                        , dt.Rows[i]["quantiteMin"].ToString().Trim()
                                        , dt.Rows[i]["CodeUniteMesure"].ToString().Trim()
                                        , dt.Rows[i]["stockDisponible"].ToString().Trim(),
                                        Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim()) 
                                        > Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) ?
                                        Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) : 
                                        Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim())
                                        ,0
                                        ,obj.NumDemande
                                        ,0
                                        ,Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim())
                                        - totalQteSaisie - (Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim())
                                        > Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) ?
                                        Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) :
                                        Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim()))
                                        , Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim())
                                        - totalQteSaisie < 0 ? false : true);
                                    //frm.dgv_ListeDestockageDemande.Rows.Add(dt.Rows[i]["codeIntrant"].ToString().Trim(),
                                    //                       dt.Rows[i]["libelleIntrant"].ToString().Trim(),
                                    //                       dt.Rows[i]["LibelleAnalyse"].ToString().Trim(),
                                    //                       0,
                                    //                       dt.Rows[i]["codeAnalyse"].ToString().Trim()
                                    //                      , Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) < 
                                    //                      Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim()) ?
                                    //                      Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) :
                                    //                      Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim())
                                    //                      ,0
                                    //                      , dt.Rows[i]["stockDisponible"].ToString().Trim()
                                    //                      , dt.Rows[i]["quantiteMin"].ToString().Trim()
                                    //                      , dt.Rows[i]["QuantiteMax"].ToString().Trim()
                                    //                      ,obj.NumDemande
                                    //                      , dt.Rows[i]["CodeUniteMesure"].ToString().Trim());

                                    
                                }
                                
                            }
                        }
                        else
                        {
                        }

                        #endregion
                        
                    }
                }
               
            }
            frm.dgv_ListeDestockageDemande.DataSource = dt1;  
            this.Close();
        }
            
        #endregion

        #region Grille de données
        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            
        } 
        #endregion
    }
}