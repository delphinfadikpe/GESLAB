
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
using LGG.UI.Parametre;
using LGC.Business.Parametre;
using Telerik.WinControls.Export;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace LGG.UI.GestionDeLaCaisse
{
    public partial class Frm_ReglementClient :RadForm
    {
        #region Declaration

        public List<ReglementClient> lstReglement = new List<ReglementClient>();
        public List<Facture> lstFacture = new List<Facture>();
        public bool nouveau = false;
        //ProfilDroit objPD = null;
        int ligne = 0;
        string sortie;
        string[] message;
       public Facture oFacture = null;
        bool ailleurs=false;
        Partenaires oPartenaire = new Partenaires();
        private GridViewSpreadExport spreadExporter;
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
            lstReglement = new List<ReglementClient>();
            bds_reglement.DataSource = lstReglement;
        }
        private void creerObjet(ReglementClient obj)
        {
            //obj.IdReglement =0;            
            obj.DateOperation = dtp_date.Value;
            obj.Montant = Convert.ToDecimal(meb_montantRegler.Value);
            obj.MontantAregler = Convert.ToDecimal(meb_montantAregler.Value);
            obj.MontantRestantDue = Convert.ToDecimal(meb_montantRestanDue.Value);
            obj.ModeReglement = rddl_ModeReglement.Text;
            obj.Reference = meb_reference.Text;
        }
        private void DetaillerFacture(Facture obj)
        {
            Viderchamp();
            //afficher la liste des reglements
            lstReglement = ReglementClient.Liste(obj.IdFacture, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null,null, false, null);
            bds_reglement.DataSource = lstReglement;
        }
        private void ChargerDonnesFacture(Facture obj)
        {
            Viderchamp();
            if (ailleurs == true && obj!=null)           
            {
                if (lstFacture.Count>0)
                lstFacture.RemoveAt(0);
                lstFacture.Add(obj);
            }
            else
            {
                if(txt_Partenaire.Text==string.Empty)
                {
                    lstFacture = Facture.Liste(null, null, null, null, null,null , null, null, null, null, null, null, null, null, false, null, null,meb_DateDebut.Value.Date,meb_DateFin.Value.Date);
                }
                else
                {
                    lstFacture = Facture.Liste(null, null, null, null, null, oPartenaire.IdPersonne, null, null, null, null, null, null, null, null, false, null, null,meb_DateDebut.Value.Date,meb_DateFin.Value.Date);
                }

                
            }
                
                //affichage des factures dont le montant reste à payer
            bds_facture.DataSource =lstFacture.FindAll(l =>  l.EstSurComptePartenaire == false );
            if (obj != null)
            {
                int i = 0;
                foreach (Facture ligne in bds_facture.List as List<Facture>)
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
        private void DetaillerReglement(ReglementClient obj)
        {
            //meb_numero.Value = obj.IdReglement;
            dtp_date.Value = obj.DateOperation;
            meb_montantRegler.Value = obj.Montant;
            meb_montantAregler.Value = obj.MontantAregler;
            meb_montantRestanDue.Value = obj.MontantRestantDue;
            rddl_ModeReglement.Text = obj.ModeReglement;
            meb_reference.Text = obj.Reference;
        }
        private void ChargerDonnesReglement(ReglementClient obj, string mNumFacture)
        {
            lstReglement = ReglementClient.Liste(mNumFacture.Trim(), null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null,false, null);
            bds_reglement.DataSource = lstReglement;
            if (obj != null)
            {
                int i = 0;
                foreach (ReglementClient ligne in bds_reglement.List as List<ReglementClient>)
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

        private void renderer_WorkbookCreated(object sender, WorkbookCreatedEventArgs e)
        {
            Worksheet worksheet = e.Workbook.ActiveWorksheet;
            worksheet.Columns[worksheet.UsedCellRange].AutoFitWidth();
        }
        #endregion

        #region Formulaire
        public Frm_ReglementClient()
        {
            InitializeComponent();
        }

        public Frm_ReglementClient(bool estAilleurs)
        {
            InitializeComponent();
            ailleurs = estAilleurs;
        }
        
        private void Frm_Reglement_Load(object sender, EventArgs e)
        {
            meb_DateFin.Value = DateTime.Now;
            meb_DateDebut.Value = DateTime.Now;

            bds_ModeReglement.DataSource = ModeReglement.Liste(null, null, null, null, null, null, null, false, null);
            Bloquerdebloquer(true);
            ChargerDonnesFacture(oFacture);
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
                    ReglementClient obj = (ReglementClient)bds_reglement.Current;
                    sortie = obj.Delete();
                    message = Tools.SplitMessage(sortie);
                    if (int.Parse(message[0]) > 0)
                    {

                        #region Mise à jour de la facture
                        Facture oFacture = ((Facture)bds_facture.Current);
                        oFacture.MontantRestantAPayer =oFacture.MontantRestantAPayer+ obj.Montant;
                        oFacture.Update();
                        #endregion

                        Viderchamp();
                        ChargerDonnesFacture((Facture)bds_facture.Current);
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
            ReglementClient obj = new ReglementClient();

            #region ControlDeSaisie

            if (dtp_date.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie de la date du règlement est obligatoire", CurrentUser.LogicielHote,
                MessageBoxButtons.OK, RadMessageIcon.Error);
                dtp_date.Focus();
                return;
            }

            if (Convert.ToDecimal(meb_montantRegler.Value)== 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du montant du règlement est obligatoire", CurrentUser.LogicielHote,
                MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_montantRegler.Focus();
                return;
            }

            if (meb_montantAregler.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du montant à régler est obligatoire", CurrentUser.LogicielHote,
                MessageBoxButtons.OK, RadMessageIcon.Error);
                meb_montantAregler.Focus();
                return;
            }

            if (meb_montantRestanDue.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du montant restant due est obligatoire", CurrentUser.LogicielHote,
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
                    Facture oFacture = ((Facture)bds_facture.Current);
                    oFacture.MontantRestantAPayer = obj.MontantRestantDue;
                    oFacture.Update();                    
                    #endregion

                    #region Enregistrement dans la table TJ_ReglementFacture
                    ReglementFacture oReglementFacture = new ReglementFacture();
                    oReglementFacture.IdFacture = ((Facture)bds_facture.Current).IdFacture;
                    oReglementFacture.IdReglement = obj.IdReglement;
                    oReglementFacture.Insert();
                    #endregion

                    //ailleurs = false;
                    Bloquerdebloquer(true);
                    nouveau = false;
                    ChargerDonnesFacture((Facture)bds_facture.Current);
                    lstReglement = ReglementClient.Liste(null, obj.NumLigne, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);
                    ReglementClient objReg = lstReglement.Find(l => l.NumLigne == obj.NumLigne);
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
                                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
            }


            #endregion

            #region Modification
            else
            {
                obj = (ReglementClient)bds_reglement.Current;
                creerObjet(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1] != "")
                {
                    #region Mise à jour de la facture
                    Facture oFacture = ((Facture)bds_facture.Current);
                    oFacture.MontantRestantAPayer = obj.MontantRestantDue;
                    oFacture.Update();
                    #endregion

                    Bloquerdebloquer(true);
                    ChargerDonnesFacture((Facture)bds_facture.Current);
                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), CurrentUser.LogicielHote,
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);

            }


            #endregion
  
        }
        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (gv_Reglement.SelectedRows != null && gv_Reglement.SelectedRows.Count != 0)
            {

                if (gv_Reglement.SelectedRows[0].Index !=gv_Reglement.RowCount-1)
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
                                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            Facture obj = (Facture)bds_facture.Current;
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
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez sélectionner la facture à régler.",
                CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            Bloquerdebloquer(true);
            Viderchamp();
            ChargerDonnesFacture((Facture)bds_facture.Current);
        }
        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            //Facture obj = (Facture)bds_facture.Current;
            //ailleurs = false;
            ChargerDonnesFacture(null);
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
            if (gv_Reglement.SelectedRows != null &&
                gv_Reglement.SelectedRows.Count != 0)
            {
                decimal montTot = 0;
                DataTable dt = null;
                string montEnLettre = "";
                dt = Rapport.Recu(((Facture)bds_facture.Current).IdFacture, ((ReglementClient)bds_reglement.Current).IdReglement);
                if (dt != null && dt.Rows.Count != 0)
                    montTot = Convert.ToDecimal(dt.Rows[0]["montantReglement"]);
                montEnLettre = Tools.convertirNombreEnLettre((float)montTot);
                TR_Recu rpt = new TR_Recu();
                rpt.objectDataSource1.DataSource = dt;
                rpt.DataSource = rpt.objectDataSource1;
                try
                {
                    rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");
                    rpt.pb_imageEntete2.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");
                }
                catch { }
                rpt.txt_MontantEnLettre.Value = montEnLettre + " francs CFA";
                rpt.txt_MontantEnLettre2.Value = montEnLettre + " francs CFA";
                Frm_ReportViewer frm = new Frm_ReportViewer("RECU", rpt);
                if (oFacture == null)
                {
                    frm.MdiParent = Application.OpenForms["Frm_Menu"];
                    frm.Show();
                }
                else
                frm.ShowDialog();
            }
        }
        #endregion

        #region DataGridView

        private void gv_Facture_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_Facture.SelectedRows != null && gv_Facture.SelectedRows.Count != 0)
            {
                DetaillerFacture((Facture)bds_facture.Current);
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
                DetaillerReglement((ReglementClient)bds_reglement.Current);
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

        private void btn_choixPartenaire_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_ListePartenaire frm = new Frm_ListePartenaire(false);
                frm.ShowDialog();
                oPartenaire = frm.oPartenaires;
                txt_Partenaire.Text = oPartenaire.NomSigle + " " + oPartenaire.PrenomRaisonSociale;
            }
            catch { }
        }

        private void btn_Exporter_Click(object sender, EventArgs e)
        {
            if (gv_Facture != null && gv_Facture.Rows.Count != 0)
            {

                try
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "Excel files|*.xls";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        this.spreadExporter = new GridViewSpreadExport(this.gv_Facture);
                        spreadExporter.ExportVisualSettings = true;
                        spreadExporter.HiddenColumnOption = Telerik.WinControls.UI.Export.HiddenOption.DoNotExport;
                        spreadExporter.HiddenRowOption = Telerik.WinControls.UI.Export.HiddenOption.DoNotExport;
                        SpreadExportRenderer renderer = new SpreadExportRenderer();
                        renderer.WorkbookCreated += renderer_WorkbookCreated;

                        this.spreadExporter.RunExport(dialog.FileName, renderer);

                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, "Exportation terminée.",
                           CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                    }

                }
                catch (Exception ex)
                {
                    RadMessageBox.Show(this, ex.Message,
                       CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                }

            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La grille est vide.", CurrentUser.LogicielHote,
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        #region Zone de liste déroulante
        #endregion
    }
}