using LGC.Business;
using LGC.Business.GestionDeLaCaisse;
using LGC.Business.GestionDesAnalyses;
using LGC.Business.Impressions;
using LGC.Business.Parametre;
using LGC.UI;
using LGC.UI.Impressions;
using LGG.UI.Parametre;
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
    public partial class Frm_ModeleResultat : Telerik.WinControls.UI.RadForm
    {

        #region declarations
        public Analyse oAnalyse = new Analyse();
        public bool nouveau = false;       
        string sortie;
        string[] message;        
        List<ParametreAnalyse> olstParametreAnalyse = new List<ParametreAnalyse>();
        List<TypeAnalyse> olstTypeAnalyse = new List<TypeAnalyse>();
        List<AnalyseType> olstAnalyseType = new List<AnalyseType>(); 
        #endregion


        #region Autres
        private void Viderchamp()
        {

            
            txt_Analyse.Text = "";           
            meb_numero.Text = "";
            gv_ListeParametreValeur.Rows.Clear();
          
            
        }

        private void Detailler(AnalyseType obj)
        {
            oAnalyse.CodeAnalyse = obj.CodeAnalyse;
            gv_ListeParametreValeur.Rows.Clear();
            meb_numero.Text = obj.Type;
            txt_Analyse.Text = obj.LibelleAnalyse;            
            olstTypeAnalyse = TypeAnalyse.Liste(obj.CodeAnalyse, null, null, null, obj.Type, null, null, null, null, false, null);
            for(int i=0;i<olstTypeAnalyse.Count;i++)
            {
                gv_ListeParametreValeur.Rows.Add(olstTypeAnalyse[i].CodeAnalyse, olstTypeAnalyse[i].LibelleParametre, olstTypeAnalyse[i].Valeur);
            }
            
        }

        private void ChargerDonnes(AnalyseType obj)
        {
            Viderchamp();
                  
            bds_ModelResultat.DataSource = AnalyseType.Liste(null,null,null,null,null,null,null,false,null);
           
            if (obj != null)
            {
                int i = 0;
                foreach (AnalyseType ligne in bds_ModelResultat.List as List<AnalyseType>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_ModelResultat.Position = i;
                        break;
                    }
                    else
                        i++;
                }
            }
        }
        
        private void Bloquerdebloquer(bool etat)
        {
            gv_Liste.Enabled = etat;
            btn_Nouveau.Visible = etat;
            btn_Modifier.Visible = etat;
            btn_Annuler.Visible = !etat;
            btn_Enregistrer.Visible = !etat;
            btn_Supprimer.Enabled = etat;
            btn_Actualiser.Enabled = etat;
            //dtp_date.ReadOnly = etat;
            gv_ListeParametreValeur.ReadOnly = etat;
           btn_choixAnalyse.Enabled = !etat;
           meb_numero.ReadOnly = true;
           

        }

        private void constituerObjet(AnalyseType obj)
        {          
            
            obj.CodeAnalyse=oAnalyse.CodeAnalyse;           
            obj.Type=meb_numero.Text;           
            
        }



       
        #endregion

        #region Formulaires
        public Frm_ModeleResultat()
        {
            InitializeComponent();
        }
        private void Frm_FactureAssurance_Load(object sender, EventArgs e)
        {
            ChargerDonnes(null);
           
             Bloquerdebloquer(true);
            if (nouveau)
                btn_Nouveau_Click(null, null);
        }
	#endregion

        #region Boutons de commandes


         private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = (true);
            Viderchamp();
            Bloquerdebloquer(false);
            meb_numero.ReadOnly = false;
            gv_ListeParametreValeur.Columns["libelleParametre"].ReadOnly = true;
           
        }

        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {              
               

                    //RadMessageBox.ThemeName = this.ThemeName;
                    //RadMessageBox.Show(this, "Cette commande a été déjà livrée partiellement. Impossible de la modifier.",
                    //                        "CurrentUser.LogicielHote", MessageBoxButtons.OK, RadMessageIcon.Error);
                    //return;
               
                Bloquerdebloquer(false);
               
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veillez sélèctioner une ligne avant d'entamer la modification.",
                                        "CurrentUser.LogicielHote", MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }

           private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            Bloquerdebloquer(true);
            Viderchamp();
            
            ChargerDonnes((AnalyseType)bds_ModelResultat.Current);
        }


         private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            #region Déclaration
             AnalyseType obj = new AnalyseType();
            #endregion

            #region ControlDeSaisie          

            

            if (txt_Analyse.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez obligatoirement spécifier l'analyse", CurrentUser.LogicielHote,
                MessageBoxButtons.OK, RadMessageIcon.Error);
               
                return;
            }

                     
            
            #endregion            

            
            #region Enregistrement

            if (nouveau)
            {
                constituerObjet(obj);
                sortie = obj.Insert();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {

                    #region enregistrement du modele en cours
                    for (int i = 0; i < gv_ListeParametreValeur.RowCount;i++ )
                    {
                        TypeAnalyse oTypeAnalyse = new TypeAnalyse();
                        oTypeAnalyse.CodeAnalyse=Convert.ToString(gv_ListeParametreValeur.Rows[i].Cells["codeAnalyse"].Value);
                        oTypeAnalyse.LibelleParametre = Convert.ToString(gv_ListeParametreValeur.Rows[i].Cells["libelleParametre"].Value);
                        oTypeAnalyse.Valeur = Convert.ToString(gv_ListeParametreValeur.Rows[i].Cells["valeur"].Value);
                        oTypeAnalyse.Type = meb_numero.Text;      

                        oTypeAnalyse.Insert();
                    }
                    #endregion

                        Bloquerdebloquer(true);
                    nouveau = false;                    
                    ChargerDonnes(obj);
                   
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "CurrentUser.LogicielHote",
                    MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }
            #endregion

            #region Modification
            else
            {
                obj = (AnalyseType)bds_ModelResultat.Current;
                constituerObjet(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1] != "")
                {

                    #region suppression de l'ancien modele
                    TypeAnalyse.DeleteAll(obj.CodeAnalyse.Trim(), obj.Type.Trim());
                    #endregion

                    #region enregistrement du modele en cours
                    for (int i = 0; i < gv_ListeParametreValeur.RowCount; i++)
                    {
                        TypeAnalyse oTypeAnalyse = new TypeAnalyse();
                        oTypeAnalyse.CodeAnalyse = Convert.ToString(gv_ListeParametreValeur.Rows[i].Cells["codeAnalyse"].Value);
                        oTypeAnalyse.LibelleParametre = Convert.ToString(gv_ListeParametreValeur.Rows[i].Cells["libelleParametre"].Value);
                        oTypeAnalyse.Valeur = Convert.ToString(gv_ListeParametreValeur.Rows[i].Cells["valeur"].Value);
                        oTypeAnalyse.Type = meb_numero.Text; 
                        oTypeAnalyse.Insert();
                    }
                    #endregion
                    Bloquerdebloquer(true);                   
                    ChargerDonnes(obj);
                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "CurrentUser.LogicielHote",
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }
            #endregion


            

        }
            

         private void btn_Actualiser_Click(object sender, EventArgs e)
         {
             AnalyseType obj = (AnalyseType)bds_ModelResultat.Current;
             ChargerDonnes(obj);
         }

         private void btn_choixAssurance_Click(object sender, EventArgs e)
         {
             try
             {
                 Frm_ListeAnalyse frm = new Frm_ListeAnalyse();
                 frm.FrmSource = "modeleResultat";
                 frm.ShowDialog();
                 txt_Analyse.Text = oAnalyse.LibelleAnalyse;
                 olstParametreAnalyse = ParametreAnalyse.Liste(oAnalyse.CodeAnalyse,null,null,null,null,null,null,null,false,null);
                 for (int i = 0; i < olstParametreAnalyse.Count; i++)
                 {
                     gv_ListeParametreValeur.Rows.Add(olstParametreAnalyse[i].CodeAnalyse, olstParametreAnalyse[i].LibelleParametre, "");
                 }
             }
             catch { }
         }



         private void btn_Supprimer_Click(object sender, EventArgs e)
         {
             //try
             //{
             //    for (int i = 0; i < gv_FactureClients.RowCount; i++)
             //    {
             //        DemandeAnalyse oDemandeAnalyse = olstDemandeAnalyse.Find(x => x.NumDemande == Convert.ToDecimal(gv_FactureClients.Rows[i].Cells["NumDemande"].Value));
             //        if (oDemandeAnalyse != null)
             //        {
             //            oDemandeAnalyse.ValideParAssurance = Convert.ToBoolean(gv_FactureClients.Rows[i].Cells["ValideParAssurance"].Value);
             //            sortie = oDemandeAnalyse.Update();
             //            message = Tools.SplitMessage(sortie);
             //        }

             //    }
             //    if (message[message.Length - 1].Trim() != "")
             //    {
             //        RadMessageBox.ThemeName = this.ThemeName;
             //        RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), CurrentUser.LogicielHote,
             //        MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
             //    }
             //}
             //catch { }

             //btn_ActualiserPeriode_Click(null, null);
         }
	#endregion

        #region DatagridView
		 private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
             if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                Detailler((AnalyseType)bds_ModelResultat.Current);
            }
            else
            {
                Viderchamp();
            }
        } 
	#endregion

        

       
        


        



    }
}
