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
    public partial class Frm_ModeleDemandeAnalyse : Telerik.WinControls.UI.RadForm
    {

        #region declarations
        public Analyse oAnalyse = new Analyse();
        public bool nouveau = false;       
        string sortie;
        string[] message;        
        List<ParametreAnalyse> olstParametreAnalyse = new List<ParametreAnalyse>();
        List<TypeAnalyse> olstTypeAnalyse = new List<TypeAnalyse>();
        List<AnalyseType> olstAnalyseType = new List<AnalyseType>();
        List<DemandeAnalyse> lstDemandeAnalyse = new List<DemandeAnalyse>();
        #endregion


        #region Autres
        private void Viderchamp()
        {
            mcb_Demandes.Text = "";
            rddl_Analyse.Text = "";
            rddl_Modele.Text = "";
            gv_ListeModele.Rows.Clear();
          
            
        }

        private void Detailler(ModeleAnalyseDemande obj)
        {
            if (obj != null)
            {
                int i = 0;
                foreach (DemandeAnalyse ligne in bds_Demandes.List as List<DemandeAnalyse>)
                {
                    if (ligne.NumDemande == obj.NumDemande)
                    {
                        bds_Demandes.Position = i;
                        mcb_Demandes.Text = obj.NumDemande.ToString().Trim();
                        break;
                    }
                    else
                        i++;
                }

                int j = 0;
                foreach (AnalyseDemande ligne in bds_AnalyseDemande.List as List<AnalyseDemande>)
                {
                    if (ligne.NumDemande == obj.NumDemande && ligne.CodeAnalyse==obj.CodeAnalyse)
                    {
                        bds_AnalyseDemande.Position = j;
                        rddl_Analyse.Text = ligne.LibelleAnalyse;
                        break;
                    }
                    else
                        j++;
                }

                int k = 0;
                foreach (AnalyseType ligne in bds_AnalyseType.List as List<AnalyseType>)
                {
                    if (ligne.Type == obj.Type)
                    {
                        bds_AnalyseType.Position = k;
                        rddl_Modele.Text = ligne.Type.Trim();
                        rddl_Modele_SelectedIndexChanged(null, null);
                        break;
                    }
                    else
                        k++;
                }
            }
        }

        private void ChargerDonnes(ModeleAnalyseDemande obj)
        {
            Viderchamp();

            bds_ModelResultat.DataSource = ModeleAnalyseDemande.Liste(null, null, null, null, null, null, null,null, false, null);
           
            if (obj != null)
            {
                int i = 0;
                foreach (ModeleAnalyseDemande ligne in bds_ModelResultat.List as List<ModeleAnalyseDemande>)
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

        private void ChargerListeDemandes()
        {
            lstDemandeAnalyse = DemandeAnalyse.Liste(null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);
            lstDemandeAnalyse = lstDemandeAnalyse.FindAll(l => l.NiveauExecution.Trim() == "DESTOCKAGE INTRANT" ||
                l.NiveauExecution.Trim() == "PRELEVEMENT");
            bds_Demandes.DataSource = lstDemandeAnalyse;
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
            rddl_Analyse.ReadOnly = etat;
            rddl_Modele.ReadOnly = etat;
            mcb_Demandes.Enabled = !etat;
           

        }

        private void constituerObjet(ModeleAnalyseDemande obj)
        {

            obj.NumDemande = Convert.ToDecimal(mcb_Demandes.Text);
            obj.CodeAnalyse = rddl_Analyse.Text.Trim();
            obj.Type = rddl_Modele.Text.Trim();
        }



       
        #endregion

        #region Formulaires
        public Frm_ModeleDemandeAnalyse()
        {
            InitializeComponent();
        }
        private void Frm_FactureAssurance_Load(object sender, EventArgs e)
        {
            ChargerListeDemandes();
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

            ChargerDonnes((ModeleAnalyseDemande)bds_ModelResultat.Current);
        }


         private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            #region Déclaration
            ModeleAnalyseDemande obj = new ModeleAnalyseDemande();
            #endregion

            #region ControlDeSaisie          
             if (mcb_Demandes.Text.Trim() == "")
             {
                 RadMessageBox.ThemeName = this.ThemeName;
                 RadMessageBox.Show(this, "La sélection de la demande est obligatoire.",
                     CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                 mcb_Demandes.Focus();
                 return;
             }


             if (rddl_Analyse.Text.Trim() == "")
             {
                 RadMessageBox.ThemeName = this.ThemeName;
                 RadMessageBox.Show(this, "La sélection de l'analyse est obligatoire.",
                     CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                 rddl_Analyse.Focus();
                 return;
             }

             if (rddl_Modele.Text.Trim() == "")
             {
                 RadMessageBox.ThemeName = this.ThemeName;
                 RadMessageBox.Show(this, "La sélection du modèle est obligatoire.",
                     CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                 rddl_Modele.Focus();
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
                obj = (ModeleAnalyseDemande)bds_ModelResultat.Current;
                constituerObjet(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1] != "")
                {                   

                   
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
             ModeleAnalyseDemande obj = (ModeleAnalyseDemande)bds_ModelResultat.Current;
             ChargerDonnes(obj);
         }

      



         private void btn_Supprimer_Click(object sender, EventArgs e)
         {
             if (gv_Liste.SelectedRows != null &&
                 gv_Liste.SelectedRows.Count > 0)
             {
                 RadMessageBox.ThemeName = this.ThemeName;
                 if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne " +
                     "sélectionnée", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                     RadMessageIcon.Question) == DialogResult.Yes)
                 {
                     ModeleAnalyseDemande obj = (ModeleAnalyseDemande)bds_ModelResultat.Current;
                     string res = obj.Delete();
                     message = LGC.Business.Tools.SplitMessage(res);
                     if (int.Parse(message[0]) > 0)
                     {
                        
                         RadMessageBox.ThemeName = this.ThemeName;
                         RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                             MessageBoxButtons.OK, RadMessageIcon.Info);
                     }
                     else
                     {
                         RadMessageBox.ThemeName = this.ThemeName;
                         MessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }

                 btn_Actualiser_Click(null, null);
             }
             else
             {
                 RadMessageBox.ThemeName = this.ThemeName;
                 RadMessageBox.Show(this, "Veuillez sélectionner la ligne à supprimer.",
                     CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
             }
         }
	#endregion

        #region DatagridView
		 private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
             if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {
                Detailler((ModeleAnalyseDemande)bds_ModelResultat.Current);
            }
            else
            {
                Viderchamp();
            }
        } 
	#endregion

         private void mcb_Demandes_SelectedIndexChanged(object sender, EventArgs e)
         {
             if(((DemandeAnalyse)bds_Demandes.Current)!=null)

             {
                 bds_AnalyseDemande.DataSource = AnalyseDemande.Liste(null, ((DemandeAnalyse)bds_Demandes.Current).NumDemande, null, null, null, null, null, null, null, null, false, null, null);
             }

         }

         private void rddl_Analyse_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
         {
             if (((AnalyseDemande)bds_AnalyseDemande.Current) != null)
             {
                 bds_AnalyseType.DataSource = AnalyseType.Liste(((AnalyseDemande)bds_AnalyseDemande.Current).CodeAnalyse,null,null,null,null,null,null,false,null);
             }
             rddl_Modele_SelectedIndexChanged(null, null);
         }

         private void rddl_Modele_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
         {
             if (((AnalyseType)bds_AnalyseType.Current) != null)
             {
                 bds_TypeAnalyse.DataSource = TypeAnalyse.Liste(((AnalyseType)bds_AnalyseType.Current).CodeAnalyse, null, null, null, ((AnalyseType)bds_AnalyseType.Current).Type.Trim(), null, null, null, null, false, null);
             }
         }

       
        


        



    }
}
