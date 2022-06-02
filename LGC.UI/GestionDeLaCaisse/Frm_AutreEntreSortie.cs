
using LGC.Business;
using LGC.Business.GestionDeLaCaisse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using LGC.Business.Impressions;
using LGC.UI.Impressions;
using LGC.UI;

namespace LGG.UI.GestionDeLaCaisse
{
    public partial class Frm_AutreEntreSortie : RadForm
    {
        #region Declaration

       
        public List<AutreEntreSortie> lstFacture = new List<AutreEntreSortie>();
        public bool nouveau = false;
        //ProfilDroit objPD = null;
        int ligne = 0;
        string sortie;
        string[] message;
        string typeOperation = "";
        #endregion

        #region Autres

        public void Bloquerdebloquer(bool etat)
        {
            //dtp_date.ReadOnly = etat;
          
            gv_Facture.Enabled = etat;

            btn_Nouveau.Visible = etat;
            btn_Modifier.Visible = etat;
            btn_Annuler.Visible = !etat;
            btn_Enregistrer.Visible = !etat;
            meb_reference.ReadOnly = etat;
            rddl_ModeReglement.ReadOnly = etat;
            btn_Actualiser.Enabled = etat;
            meb_justif.ReadOnly = etat;
            meb_montantAregler.ReadOnly = etat;
        }
        private void Viderchamp()
        {
            meb_reference.Value = "";
            dtp_date.Value = DateTime.Now;
            meb_justif.Value = "";
            meb_montantAregler.Value = 0;
           
        }
        private void creerObjet(AutreEntreSortie obj)
        {
            //obj.IdOperationEntreSortie = 0;            
            obj.DateOperation = dtp_date.Value;
            obj.Montant = Convert.ToDecimal(meb_montantAregler.Value);           
            obj.ModeReglement = rddl_ModeReglement.Text;
            obj.Reference = meb_reference.Text;
            obj.TypeOperation = typeOperation;
            obj.Justification = meb_justif.Text;
        }
        private void DetaillerFacture(AutreEntreSortie obj)
        {

            dtp_date.Value = obj.DateOperation;
            meb_montantAregler.Value = obj.Montant;
            rddl_ModeReglement.Text = obj.ModeReglement;
            meb_reference.Text = obj.Reference;
            meb_justif.Text = obj.Justification;
        }
        private void ChargerDonnesFacture(AutreEntreSortie obj)
        {
            Viderchamp();
            lstFacture = AutreEntreSortie.Liste(null, null, typeOperation.Trim(), null, null, null, null, null, null, null, false, null, null, null);
            //affichage des factures dont le montant reste à payer
            bds_facture.DataSource =lstFacture;
            if (obj != null)
            {
                int i = 0;
                foreach (AutreEntreSortie ligne in bds_facture.List as List<AutreEntreSortie>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_facture.Position = i;
                        break;
                    }
                    else
                        i++;
                }
            }
        }
      
     

        #endregion

        #region Formulaire
        public Frm_AutreEntreSortie()
        {
            InitializeComponent();
        }

        public Frm_AutreEntreSortie(string mTypeOperation)
        {
            InitializeComponent();
            typeOperation = mTypeOperation;
            this.Text ="["+ typeOperation + " DE CAISSE]";
            if(mTypeOperation=="ENTREE")
            {
                lbl_Solde.Visible = false;
                meb_Solde.Visible = false;
            }
            else
            {
                lbl_Solde.Visible = true;
                meb_Solde.Visible = true;
            }
        }
        
        private void Frm_Reglement_Load(object sender, EventArgs e)
        {
            meb_Solde.Value = Rapport.SoldeCaisse(DateTime.Now);
            bds_ModeReglement.DataSource = ModeReglement.Liste(null, null, null, null, null, null, null, false, null);
            Bloquerdebloquer(true);
            ChargerDonnesFacture(null);
            if (nouveau)
                btn_Nouveau_Click(null, null);
        }
        #endregion

        #region Boutons

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            if (gv_Facture.SelectedRows != null &&
                gv_Facture.SelectedRows.Count > 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne " +
                    "sélectionnée", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                    RadMessageIcon.Question) == DialogResult.Yes)
                {
                    AutreEntreSortie obj = (AutreEntreSortie)bds_facture.Current;
                    string res = obj.Delete();
                    message = Tools.SplitMessage(res);
                    if (int.Parse(message[0]) > 0)
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                        ChargerDonnesFacture(null);
                    }
                    else
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        MessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            AutreEntreSortie obj = new AutreEntreSortie();

            #region ControlDeSaisie

            if (dtp_date.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie de la date du règlement est obligatoire", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                dtp_date.Focus();
                return;
            }

            

            if (meb_montantAregler.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du montant   est obligatoire", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_montantAregler.Focus();
                return;
            }


            if (meb_justif.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du justif est obligatoire", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_justif.Focus();
                return;
            }

            if (rddl_ModeReglement.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La sélection du mode de règlement est obligatoire", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                rddl_ModeReglement.Focus();
                return;
            }

            if (rddl_ModeReglement.Text.Trim() == "ESPECE" && meb_reference.Text!="")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Un paiement en espèce ne necessite pas de référence", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_reference.Text = "";
                return;
            }
            if (rddl_ModeReglement.Text.Trim() == "CHEQUE" && meb_reference.Text == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Un paiement en chèque necessite de référence", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_reference.Focus();
                return;
            }

            if (Convert.ToDecimal(meb_montantAregler.Value) == 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "le montant ne peut etre égale à zéro ", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_montantAregler.Focus();
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
                    ChargerDonnesFacture((AutreEntreSortie)bds_facture.Current);                   
                    meb_Solde.Value = Rapport.SoldeCaisse(DateTime.Now);
                    
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(),
                                    "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Info);
            }


            #endregion

            #region Modification
            else
            {
                obj = (AutreEntreSortie)bds_facture.Current;
                creerObjet(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1] != "")
                {
                    Bloquerdebloquer(true);
                    ChargerDonnesFacture((AutreEntreSortie)bds_facture.Current);
                    meb_Solde.Value = Rapport.SoldeCaisse(DateTime.Now);
                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "GESLAB",
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);

            }


            #endregion
  
        }
        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (gv_Facture.SelectedRows != null && gv_Facture.SelectedRows.Count != 0)
            {
                Bloquerdebloquer(false);
                dtp_date.Focus();
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veillez sélèctioner une ligne avant d'entamer la modification.",
                                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = (true);
            Viderchamp();
            Bloquerdebloquer(false);           

            dtp_date.Value = DateTime.Now;
        }
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            Bloquerdebloquer(true);
            Viderchamp();
            ChargerDonnesFacture((AutreEntreSortie)bds_facture.Current);
        }
        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            AutreEntreSortie obj = (AutreEntreSortie)bds_facture.Current;
            ChargerDonnesFacture(obj);
        }
        private void btn_Facture_Click(object sender, EventArgs e)
        {
            //if (gv_Facture.SelectedRows != null &&
            //    gv_Facture.SelectedRows.Count != 0)
            //{
            //    decimal montTot = 0;
            //    DataTable dt = null;
            //    string montEnLettre = "";
            //    dt = Rapport.Facture(
            //        Convert.ToDecimal(gv_Facture.SelectedRows[0].Cells["NumCommande"].Value.ToString()));
            //    if (dt != null && dt.Rows.Count != 0)
            //        montTot = Convert.ToDecimal(dt.Rows[0]["montantFacture"]);
            //    montEnLettre = Tools.convertirNombreEnLettre((float)montTot);
            //    TR_Facture rpt = new TR_Facture();
            //    rpt.objectDataSource1.DataSource = dt;
            //    rpt.DataSource = rpt.objectDataSource1;
            //    try
            //    {
            //        rpt.pb_imageEntete.Value = Image.FromFile(Application.StartupPath + "\\" + "EnteteSte.png");
            //    }
            //    catch { }
            //    rpt.txt_montEnLettre.Value = montEnLettre + " francs CFA";
            //    Frm_ReportViewer frm = new Frm_ReportViewer("FACTURE", rpt);
            //    frm.MdiParent = Application.OpenForms["Frm_Menu"];
            //    frm.Show();

            //}
        }
     
        #endregion

        #region DataGridView

        private void gv_Facture_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_Facture.SelectedRows != null && gv_Facture.SelectedRows.Count != 0)
            {
                DetaillerFacture((AutreEntreSortie)bds_facture.Current);
            }
            else
            {
                Viderchamp();
            }
        }

       
        
        #endregion

        #region Zone de masque
       
        #endregion

        private void rddl_ModeReglement_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        
    }
}