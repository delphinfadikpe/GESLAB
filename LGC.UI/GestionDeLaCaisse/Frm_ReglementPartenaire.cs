
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

namespace LGG.UI.GestionDeLaCaisse
{
    public partial class Frm_ReglementPartenaire :RadForm
    {
        #region Declaration

        public List<ReglementPartenaire> lstReglement = new List<ReglementPartenaire>();
        public List<FacturePartenaire> lstFacture = new List<FacturePartenaire>();
        public bool nouveau = false;
        //ProfilDroit objPD = null;
        int ligne = 0;
        string sortie;
        string[] message;

        #endregion

        #region Autres

        public void Bloquerdebloquer(bool etat)
        {
            dtp_date.ReadOnly = CurrentUser.OUtilisateur.AutoriseDateAnterieur == true ? false : true;
            //dtp_date.ReadOnly = etat;
            meb_montantRegler.ReadOnly = etat;

            gv_Reglement.Enabled = etat;
            gv_Facture.Enabled = etat;

            btn_Nouveau.Visible = etat;
            btn_Modifier.Visible = etat;
            btn_Annuler.Visible = !etat;
            btn_Enregistrer.Visible = !etat;
            meb_reference.ReadOnly = etat;
            rddl_ModeReglement.ReadOnly = etat;
            btn_Actualiser.Enabled = etat;

        }
        private void Viderchamp()
        {
            meb_reference.Value = "";
            dtp_date.Value = DateTime.Now;
            meb_montantRegler.Value = 0;
            meb_montantAregler.Value = 0;
            meb_montantRestanDue.Value = 0;

            //vider la grille d'affichage des reglements
            lstReglement = new List<ReglementPartenaire>();
            bds_reglement.DataSource = lstReglement;
        }
        private void creerObjet(ReglementPartenaire obj)
        {
            obj.IdReglement =0;            
            obj.DateOperation = dtp_date.Value;
            obj.Montant = Convert.ToDecimal(meb_montantRegler.Value);
            obj.MontantAregler = Convert.ToDecimal(meb_montantAregler.Value);
            obj.MontantRestantDue = Convert.ToDecimal(meb_montantRestanDue.Value);
            obj.ModeReglement = rddl_ModeReglement.Text;
            obj.Reference = meb_reference.Text;
        }
        private void DetaillerFacture(FacturePartenaire obj)
        {
            Viderchamp();
            //afficher la liste des reglements
            lstReglement = ReglementPartenaire.Liste(obj.IdFacture, null, null, null, null, null, null,
                null, null, null, null, null, null, null,null, false, null);
            bds_reglement.DataSource = lstReglement;
        }
        private void ChargerDonnesFacture(FacturePartenaire obj)
        {
            Viderchamp();
            lstFacture = FacturePartenaire.Liste(null,null,null,null,null,null,null,null,null,null,null,null,null,null,false,null);
            //affichage des factures dont le montant reste à payer
            bds_facture.DataSource = lstFacture;// lstFacture.FindAll(l => l.MontantRestantAPayer != 0);
            if (obj != null)
            {
                int i = 0;
                foreach (FacturePartenaire ligne in bds_facture.List as List<FacturePartenaire>)
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
        private void DetaillerReglement(ReglementPartenaire obj)
        {
            //meb_numero.Value = obj.IdReglement;
            dtp_date.Value = obj.DateOperation;
            meb_montantRegler.Value = obj.Montant;
            meb_montantAregler.Value = obj.MontantAregler;
            meb_montantRestanDue.Value = obj.MontantRestantDue;
            rddl_ModeReglement.Text = obj.ModeReglement;
            meb_reference.Text = obj.Reference;
        }
        private void ChargerDonnesReglement(ReglementPartenaire obj, string mNumFacture)
        {
            lstReglement = ReglementPartenaire.Liste(mNumFacture.Trim(), null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, false, null);
            bds_reglement.DataSource = lstReglement;
            if (obj != null)
            {
                int i = 0;
                foreach (ReglementPartenaire ligne in bds_reglement.List as List<ReglementPartenaire>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_reglement.Position = i;
                        break;
                    }
                    else
                        i++;
                }
            }
        }

        #endregion

        #region Formulaire
        public Frm_ReglementPartenaire()
        {
            InitializeComponent();
        }
        private void Frm_Reglement_Load(object sender, EventArgs e)
        {

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
            if (gv_Reglement.SelectedRows != null && gv_Reglement.SelectedRows.Count != 0)
            {
                if (gv_Reglement.SelectedRows[0].Index != gv_Reglement.RowCount - 1)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Vous ne pouvez modifier que le dernier règlement",
                                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }

                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this,
                    "Voullez-vous vraiment supprimer la ligne sélectionnée?", CurrentUser.LogicielHote,
                    MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    ReglementPartenaire obj = (ReglementPartenaire)bds_reglement.Current;
                    sortie = obj.Delete();
                    message = Tools.SplitMessage(sortie);
                    if (int.Parse(message[0]) > 0)
                    {

                        #region Mise à jour de la facture
                        FacturePartenaire oFacture = ((FacturePartenaire)bds_facture.Current);
                        oFacture.MontantRestantAPayer = oFacture.MontantRestantAPayer + obj.Montant;
                        oFacture.Update();
                        #endregion

                        Viderchamp();
                        ChargerDonnesFacture((FacturePartenaire)bds_facture.Current);
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
        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            ReglementPartenaire obj = new ReglementPartenaire();

            #region ControlDeSaisie

            if (dtp_date.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie de la date du règlement est obligatoire", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                dtp_date.Focus();
                return;
            }

            if (Convert.ToDecimal(meb_montantRegler.Value) == 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du montant du règlement est obligatoire", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_montantRegler.Focus();
                return;
            }

            if (meb_montantAregler.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du montant à régler est obligatoire", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_montantAregler.Focus();
                return;
            }

            if (meb_montantRestanDue.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du montant restant due est obligatoire", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_montantRestanDue.Focus();
                return;
            }

            if (rddl_ModeReglement.Text.Trim() == "ESPECE" && meb_reference.Text != "")
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
            #endregion

            #region Enregistrement

            if (nouveau)
            {
                creerObjet(obj);
                sortie = obj.Insert();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.IdReglement = int.Parse(message[message.Length - 1].Trim());


                    #region Mise à jour de la facture
                    FacturePartenaire oFacture = ((FacturePartenaire)bds_facture.Current);
                    oFacture.MontantRestantAPayer = obj.MontantRestantDue;
                    oFacture.Update();
                    #endregion

                    #region Enregistrement dans la table TJ_ReglementFacture
                    ReglementFacture oReglementFacture = new ReglementFacture();
                    oReglementFacture.IdFacture = ((FacturePartenaire)bds_facture.Current).IdFacture;
                    oReglementFacture.IdReglement = obj.IdReglement;
                    oReglementFacture.Insert();
                    #endregion

                    Bloquerdebloquer(true);
                    nouveau = false;
                    ChargerDonnesFacture((FacturePartenaire)bds_facture.Current);
                    lstReglement = ReglementPartenaire.Liste(null, obj.NumLigne, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);
                    ReglementPartenaire objReg = lstReglement.Find(l => l.NumLigne == obj.NumLigne);
                    //Reglement objReg = Reglement.Liste(null, null, null, null, null, null, null, null, null, null, null, obj.NumLigne, null, null, null);
                    decimal montTot = 0;
                    DataTable dt = null;
                    string montEnLettre = "";
                    //dt = Rapport.Recu(objReg.NumReglement);
                    //if (dt != null && dt.Rows.Count != 0)
                    //    montTot = Convert.ToDecimal(dt.Rows[0]["montantReglement"]);
                    //montEnLettre = Tools.convertirNombreEnLettre((float)montTot);
                    //TR_Recu rpt = new TR_Recu();
                    //rpt.objectDataSource1.DataSource = dt;
                    //rpt.DataSource = rpt.objectDataSource1;
                    //try
                    //{
                    //    rpt.pb_imageEntete.Value = Image.FromFile(Application.StartupPath + "\\" + "EnteteSte.png");
                    //    rpt.pb_imageEntete2.Value = Image.FromFile(Application.StartupPath + "\\" + "EnteteSte.png");
                    //}
                    //catch { }
                    //rpt.txt_MontantEnLettre.Value = montEnLettre + " francs CFA";
                    //rpt.txt_MontantEnLettre2.Value = montEnLettre + " francs CFA";
                    //Frm_ReportViewer frm = new Frm_ReportViewer("RECU", rpt);
                    //frm.MdiParent = Application.OpenForms["Frm_MenuPrincipal"];
                    //frm.Show();
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(),
                                    "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Info);
            }


            #endregion

            #region Modification
            else
            {
                obj = (ReglementPartenaire)bds_reglement.Current;
                creerObjet(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1] != "")
                {
                    #region Mise à jour de la facture
                    FacturePartenaire oFacture = ((FacturePartenaire)bds_facture.Current);
                    oFacture.MontantRestantAPayer = obj.MontantRestantDue;
                    oFacture.Update();
                    #endregion


                    Bloquerdebloquer(true);
                    ChargerDonnesFacture((FacturePartenaire)bds_facture.Current);
                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "GESLAB",
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);

            }


            #endregion
  
        }
        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (gv_Reglement.SelectedRows != null && gv_Reglement.SelectedRows.Count != 0)
            {
                if (gv_Reglement.SelectedRows[0].Index != gv_Reglement.RowCount - 1)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Vous ne pouvez modifier que le dernier règlement",
                                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;

                }
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

            FacturePartenaire obj = (FacturePartenaire)bds_facture.Current;
            if (obj != null)
            {
                if (obj.MontantRestantAPayer != 0)
                {
                    nouveau = (true);
                    Viderchamp();
                    Bloquerdebloquer(false);
                    meb_montantAregler.Value = obj.MontantRestantAPayer;
                    meb_montantRestanDue.Value = obj.MontantRestantAPayer;
                    dtp_date.Value = DateTime.Now;
                }
                else
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "FACTURE DEJA SOLDEE",
                    "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez sélectionner la facture à régler.",
                "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
            }

           
        }
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            Bloquerdebloquer(true);
            Viderchamp();
            ChargerDonnesFacture((FacturePartenaire)bds_facture.Current);
        }
        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            FacturePartenaire obj = (FacturePartenaire)bds_facture.Current;
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
        private void btn_recu_Click(object sender, EventArgs e)
        {
            //if (gv_Reglement.SelectedRows != null &&
            //    gv_Reglement.SelectedRows.Count != 0)
            //{
            //    decimal montTot = 0;
            //    DataTable dt = null;
            //    string montEnLettre = "";
            //    dt = Rapport.Recu(meb_numero.Value.ToString());
            //    if (dt != null && dt.Rows.Count != 0)
            //        montTot = Convert.ToDecimal(dt.Rows[0]["montantReglement"]);
            //    montEnLettre = Tools.convertirNombreEnLettre((float)montTot);
            //    TR_Recu rpt = new TR_Recu();
            //    rpt.objectDataSource1.DataSource = dt;
            //    rpt.DataSource = rpt.objectDataSource1;
            //    try
            //    {
            //        rpt.pb_imageEntete.Value = Image.FromFile(Application.StartupPath + "\\" + "EnteteSte.png");
            //        rpt.pb_imageEntete2.Value = Image.FromFile(Application.StartupPath + "\\" + "EnteteSte.png");
            //    }
            //    catch { }
            //    rpt.txt_MontantEnLettre.Value = montEnLettre + " francs CFA";
            //    rpt.txt_MontantEnLettre2.Value = montEnLettre + " francs CFA";
            //    Frm_ReportViewer frm = new Frm_ReportViewer("RECU", rpt);
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
                DetaillerFacture((FacturePartenaire)bds_facture.Current);
            }
            else
            {
                Viderchamp();
            }
        }

        private void gv_Reglement_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_Reglement.SelectedRows != null && gv_Reglement.SelectedRows.Count != 0)
            {
                DetaillerReglement((ReglementPartenaire)bds_reglement.Current);
            }
            else
            {
                Viderchamp();
            }
        }
        
        #endregion

        #region Zone de masque
        private void meb_montantRegler_ValueChanged(object sender, EventArgs e)
        {
            if (!meb_montantRegler.ReadOnly)
            {
                if (Convert.ToDecimal(meb_montantAregler.Value) <
                    Convert.ToDecimal(meb_montantRegler.Value))
                {
                    meb_montantRegler.Value = meb_montantAregler.Value;
                }
                else
                {
                    meb_montantRestanDue.Value =
                        Convert.ToDecimal(meb_montantAregler.Value) -
                        Convert.ToDecimal(meb_montantRegler.Value);
                }
            }
        } 
        #endregion

        private void rddl_ModeReglement_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        #region Zone de liste déroulante
        #endregion
    }
}