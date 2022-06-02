using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LGC.Business.GestionDesAnalyses;
using LGC.Business.Parametre;
using LGG.UI.Parametre;
using LGC.Business;
using LGC.Business.GestionDeLaCaisse;
using LGC.Business.Impressions;
using LGC.UI.Impressions;
using System.IO;
using System.IO.Ports;
using LGC.Business.GestionUtilisateur;
using LGG.Business;
using QRCoder;
using LGG.UI.GestionDeLaCaisse;
using Microsoft.Win32;

namespace LGC.UI.GestionDesAnalyses
{
    public partial class Frm_DemandeAnalyse : Telerik.WinControls.UI.RadForm
    {


        #region Declarations
        List<DemandeAnalyse> olstDemandeAnalyse = new List<DemandeAnalyse>();
        public List<DemandeAnalyse> lstDemandeAnalyse = new List<DemandeAnalyse>();
        public List<Patient> lstPatient = new List<Patient>();
        public List<Assurance> lstAssurance = new List<Assurance>();
        public List<Partenaires> lstPartenaires = new List<Partenaires>();
        public bool nouveau = false;
        public bool nouveauLivraison = false;
        string sortie;
        string[] message;
        int ligne = 0;
        Patient oPatient = new Patient();
       public Partenaires oPartenaires = new Partenaires();
        Assurance oAssurance = new Assurance();
        public List<AnalyseDemande> lstAnalyseDemande = new List<AnalyseDemande>();
        Facture oFacture = new Facture();
        SerialPort serialPort = new SerialPort();
        public string nomVendeur = CurrentUser.OUtilisateur.NomUtilisateur + " " + CurrentUser.OUtilisateur.PrenomUtilisateur;

        string[] retour33h;
        string codeQR = "";
        Image image = null;
        string operateur = "";
        string ifuAcheteur = "", nomAcheteur = "";
        int AIB = 0;
        int idOperateur = 0;
        #endregion

        #region Autres

       

        private void Viderchamp()
        {
            try
            {
                //bds_Demandes.DataSource = new List<DemandeAnalyse>();
                chk_Assurance.Checked = false;
                chk_DemandePriseEnCharge.IsChecked = false;
                chk_Retenue.IsChecked = false;
                chk_Partenaire.Checked = false;
                meb_Taux.Text = "0,00";
                meb_TauxRemise.Text = "0,00";
                meb_TauxRetenue.Text = "0,00";
                //bds_AnalyseDemande.DataSource = new List<AnalyseDemande>();
                meb_MontantClient.Text = "0";
                meb_MontantClient1.Text = "0";
                meb_Retenue.Text = "0";
                meb_Retenue1.Text = "0";
                meb_MontantTotal.Text = "0";
                meb_MontantTotal1.Text = "0";
                meb_MontRemise.Text = "0";
                meb_MontRemise1.Text = "0";
                meb_MontCouvert.Text = "0";
                meb_MontCouvert1.Text = "0";
                txt_Assurance.Text = "";
                txt_Partenaire.Text = "";
                txt_Patient.Text = "";
                meb_numero.Text = "EN CREATION";
                gb_Assurance.Enabled = true;
                gb_Partenaire.Enabled = true;
                txt_numPolice.Text = "";
                oPartenaires = null;
                oAssurance = null;
                txt_beneficiaire.Text = "";
            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, ex.Message,
                CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void Detailler(DemandeAnalyse obj)
        {
            try
            {
                meb_numero.Text = Convert.ToString(obj.NumDemande);
                meb_DateDemande.Value = obj.DateDemande;
                meb_DateResultatPrevue.Value = obj.DateSortiResultatPrevu;
                lstPatient = Patient.Liste(obj.IdPersonne, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);
                oPatient = lstPatient[0];
                txt_Patient.Text = obj.Patient;
                lstAssurance = Assurance.Liste(obj.IdPersonneAssurance, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);
                oAssurance = lstAssurance.Count != 0 ? lstAssurance[0] : null;
                txt_Assurance.Text = obj.Assurance;
                lstPartenaires = Partenaires.Liste(obj.IdPersonnePartenaire, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);
                oPartenaires = lstPartenaires.Count != 0 ? lstPartenaires[0] : null;
                txt_Partenaire.Text = obj.Partenaire;
                chk_Assurance.Checked = obj.EstAssure;
                chk_DemandePriseEnCharge.IsChecked = obj.EstSurComptePartenaire;
                chk_Partenaire.Checked = obj.EstRecommande;
                meb_Taux.Value = obj.TauxCouverture;
                meb_MontantTotal.Value = meb_MontantTotal1.Value = obj.MontantBrut;
                meb_MontCouvert.Value = meb_MontCouvert1.Value = (obj.MontantBrut) * obj.TauxCouverture / 100;
                meb_MontRemise.Value = meb_MontRemise1.Value = obj.Remise;
                meb_MontantClient.Value = meb_MontantClient1.Value = obj.MontantDemande;
                bds_AnalyseDemande.DataSource = lstAnalyseDemande = AnalyseDemande.Liste(null, obj.NumDemande, null, null, null, null, null, null, null, null, false, null, null);
                if (obj.Remise != 0)
                {
                    chk_Remise.Checked = true;
                    bool trouver = false;
                    foreach (AnalyseDemande ligne in lstAnalyseDemande)
                    {
                        if (ligne.RemiseAnalyse != 0)
                        {
                            trouver = true;
                            break;
                        }
                    }
                    if (trouver == false)
                    {
                        rddl_Remise.Text = "SUR LE MONTANT GLOBAL";
                    }
                    else
                    {
                        rddl_Remise.Text = "SUR LES ANALYSES";
                    }
                }
                else
                {
                    chk_Remise.Checked = false;
                    rddl_Remise.Text = "";
                }
                gb_Assurance.Enabled = obj.EstAssure == true ? true : false;
                gb_Partenaire.Enabled = obj.EstRecommande == true ? true : false;
                try
                {
                    meb_TauxRemise.Text = string.Format("{0:n2}", (Convert.ToDecimal(obj.Remise) / Convert.ToDecimal(obj.MontantBrut)) * 100);
                }
                catch
                {
                    meb_TauxRemise.Text = "0";
                }
                txt_numPolice.Text = obj.NumPolice;

                chk_Retenue.IsChecked = obj.EstRetenuAlaSource;
                meb_TauxRetenue.Value = obj.TauxRetenue;
                meb_Retenue.Value = meb_Retenue1.Value = obj.MontantRetenue;
                txt_beneficiaire.Text = obj.Beneficiaire;
                try
                {
                    oFacture = Facture.Liste(null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null, obj.NumDemande, null, null)[0];
                }catch
                {
                    oFacture = null;
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, ex.Message,
                CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void ChargerDonnes(DemandeAnalyse obj)
        {
            Viderchamp();
            bds_Demandes.DataSource = DemandeAnalyse.Liste(meb_DateDebut.Value.Date, meb_DateFin.Value.Date);

            if (obj != null)
            {
                int i = 0;
                foreach (DemandeAnalyse ligne in bds_Demandes.List as List<DemandeAnalyse>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        //oFacture.NumLigne = obj.NumLigneFact;
                        bds_Demandes.Position = i;
                        break;
                    }
                    else
                        i++;
                }
            }
        }

        private void Bloquerdebloquer(bool etat)
        {

            meb_DateDemande.ReadOnly = CurrentUser.OUtilisateur.AutoriseDateAnterieur == true ? false : true;
            gv_Liste.Enabled = etat;
            btn_Nouveau.Visible = etat;
            btn_Modifier.Visible = etat;
            btn_Annuler.Visible = !etat;
            btn_Enregistrer.Enabled = !etat;
            btn_Reglement.Enabled = etat;
            btn_Actualiser.Enabled = etat;
            //meb_DateDemande.ReadOnly = true;
            meb_DateResultatPrevue.ReadOnly = etat;
            btn_ChoixAssurance.Enabled = !etat;
            btn_ChoixPartenaire.Enabled = !etat;
            btn_choixPatient.Enabled = !etat;
            chk_Assurance.ReadOnly = etat;
            chk_Partenaire.ReadOnly = etat;
            chk_DemandePriseEnCharge.ReadOnly = etat;
            chk_Retenue.ReadOnly = etat;
            chk_Remise.ReadOnly = etat;
            meb_TauxRemise.ReadOnly = etat;
            txt_numPolice.ReadOnly = etat;
            txt_beneficiaire.ReadOnly = etat;

            btn_AjouterAnalyse.Enabled = !etat;
            btn_EnleverAnalyse.Enabled =! etat;
        }

        private void calculerRemise()
        {
            meb_MontRemise.Value = 0;
            for (int i = 0; i < gv_Analyses.RowCount; i++)
            {
                meb_MontRemise.Value = meb_MontRemise1.Value = Convert.ToDecimal(meb_MontRemise.Value) + Convert.ToDecimal(gv_Analyses.Rows[i].Cells["RemiseAnalyse"].Value);
            }
        }
        public void calculerBrut()
        {
            meb_MontantTotal.Value = 0;
            meb_MontantTotal1.Value = 0;
            meb_DateResultatPrevue.Value = DateTime.Now;
            for (int i = 0; i < gv_Analyses.RowCount; i++)
            {
                meb_MontantTotal.Value = meb_MontantTotal1.Value = meb_MontantTotal1.Value = Convert.ToDecimal(meb_MontantTotal.Value) + (Convert.ToDecimal(gv_Analyses.Rows[i].Cells["PrixNormal"].Value) * Convert.ToDecimal(gv_Analyses.Rows[i].Cells["Qte"].Value));
                meb_DateResultatPrevue.Value = Convert.ToDateTime(meb_DateResultatPrevue.Value).AddDays(Convert.ToInt32(gv_Analyses.Rows[i].Cells["jours"].Value)).AddHours(Convert.ToInt32(gv_Analyses.Rows[i].Cells["heure"].Value)).AddMinutes(Convert.ToInt32(gv_Analyses.Rows[i].Cells["minute"].Value));
            }
        }

        public void calculerMontantNet()
        {
            try
            {
                //meb_TauxRemise_ValueChanged(null, null);
                meb_MontCouvert.Value = meb_MontCouvert1.Value = (Convert.ToDecimal(meb_MontantTotal.Value) - Convert.ToDecimal(meb_MontRemise.Value)) * Convert.ToDecimal(meb_Taux.Value) / 100;
                meb_Retenue.Value = meb_Retenue1.Value = (Convert.ToDecimal(meb_MontantTotal.Value) - Convert.ToDecimal(meb_MontRemise.Value)) * Convert.ToDecimal(meb_TauxRetenue.Value) / 100;
                meb_MontantClient.Value = meb_MontantClient1.Value = Convert.ToDecimal(meb_MontantTotal.Value) - Convert.ToDecimal(meb_Retenue.Value) - Convert.ToDecimal(meb_MontRemise.Value) - Convert.ToDecimal(meb_MontCouvert.Value);

            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, ex.Message,
                CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void constituerObjetDemande(DemandeAnalyse obj)
        {
            //obj.NumDemande = Convert.ToDecimal(0);
            obj.DateDemande = meb_DateDemande.Value;
            obj.DateSortiResultatPrevu = meb_DateResultatPrevue.Value;
            obj.IdPersonne = oPatient.IdPersonne;
            obj.IdPersonneAssurance = oAssurance != null ? oAssurance.IdPersonne : 0;
            obj.IdPersonnePartenaire = oPartenaires != null ? oPartenaires.IdPersonne : 0;
            obj.EstSurComptePartenaire = chk_DemandePriseEnCharge.IsChecked;
            obj.EstRecommande = chk_Partenaire.Checked;
            obj.EstAssure = chk_Assurance.Checked;
            obj.TauxCouverture = Convert.ToDecimal(meb_Taux.Value);
            obj.MontantBrut = Convert.ToDecimal(meb_MontantTotal.Value);
            obj.Remise = Convert.ToDecimal(meb_MontRemise.Value);
            obj.MontantDemande = Convert.ToDecimal(meb_MontantClient.Value);
            obj.DateAnnulation = Convert.ToDateTime("01/01/1900");
            obj.MotifAnnulation = "";
            obj.StatutReglement = "";
            obj.NiveauExecution = "";
            obj.Reste = Convert.ToDecimal(meb_MontantClient.Value);
            obj.NumPolice = txt_numPolice.Text;
            obj.EstRetenuAlaSource = chk_Retenue.IsChecked;
            obj.TauxRetenue = Convert.ToDecimal(meb_TauxRetenue.Value);
            obj.MontantRetenue = Convert.ToDecimal(meb_Retenue.Value);
            obj.Beneficiaire = txt_beneficiaire.Text;
        }


        #endregion

        #region Formulaires
        public Frm_DemandeAnalyse()
        {
            InitializeComponent();
        }
        private void Frm_DemandeAnalyse_Load(object sender, EventArgs e)
        {
            meb_DateDebut.Value = DateTime.Now;
            meb_DateFin.Value = DateTime.Now;
            btn_Actualiser_Click(null, null);
            Bloquerdebloquer(true);
            if (nouveau)
                btn_Nouveau_Click(null, null);
        }
        #endregion               

        #region Boutons de commandes
        private void btn_Nouveau_Click(object sender, EventArgs e)
        {

            meb_DateDemande.Value = DateTime.Now;
            meb_DateDebut.Value = DateTime.Now;
            meb_DateFin.Value = DateTime.Now;
            nouveau = (true);
            Viderchamp();
            Bloquerdebloquer(false);
            chk_Partenaire.Checked = true;
            chk_Assurance.Checked = true;
            chk_Remise.Checked = true;
            radPageView1.SelectedPage = radPageViewPage1;


        }
        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            {


                {
                    try
                    {
                        oFacture = Facture.Liste(null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null, Convert.ToDecimal(gv_Liste.SelectedRows[0].Cells["NumDemande"].Value), null, null)[0];
                        if (oFacture.IdFactureAssurance != "")
                        {
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Impossible de modifier la demande N°" + Convert.ToString(gv_Liste.SelectedRows[0].Cells["NumDemande"].Value) + " \n car elle est prise en compte sur la note d'honoraire à envoyer à l'assurance",
                                                    "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                            return;
                        }
                        if (oFacture.IdFacturePartenaire != "")
                        {
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Impossible de modifier la demande N°" + Convert.ToString(gv_Liste.SelectedRows[0].Cells["NumDemande"].Value) + " \n car elle est prise en compte sur la note d'honoraire à envoyer au partenaire",
                                                    "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                            return;
                        }
                        //if (oFacture.MontantRestantAPayer == 0 && oFacture.IdFacturePartenaire == "")
                        //{
                        //    RadMessageBox.ThemeName = this.ThemeName;
                        //    RadMessageBox.Show(this, "Impossible de modifier la demande N°" + Convert.ToString(gv_Liste.SelectedRows[0].Cells["NumDemande"].Value) + " \n car elle a déjà fait l'objet d'un règlement",
                        //                            "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                        //    return;
                        //}

                        if (oFacture.MontantRestantAPayer == 0 && oFacture.IdFacturePartenaire == "")
                        {
                            if (Convert.ToDecimal(gv_Liste.SelectedRows[0].Cells["TauxCouverture"].Value) == 0)
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, "Impossible d'annuler la demande N°" + Convert.ToString(gv_Liste.SelectedRows[0].Cells["NumDemande"].Value) + " \n car elle a déjà fait l'objet d'un règlement",
                                                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                                return;
                            }

                            if (Convert.ToDecimal(gv_Liste.SelectedRows[0].Cells["TauxCouverture"].Value) != 100)
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, "Impossible d'annuler la demande N°" + Convert.ToString(gv_Liste.SelectedRows[0].Cells["NumDemande"].Value) + " \n car elle a déjà fait l'objet d'un règlement",
                                                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                                return;
                            }
                        }

                       
                    }
                    catch { oFacture = null; }

                    switch (Convert.ToString(gv_Liste.SelectedRows[0].Cells["niveauExecution"].Value))
                    {
                        case "PRELEVEMENT":
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Impossible de modifier la demande N°" + Convert.ToString(gv_Liste.SelectedRows[0].Cells["NumDemande"].Value) + " \n car elle a déjà fait l'objet d'un prélèvement",
                                                    "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                            return;
                            break;
                        case "VALIDATION DE RESULTAT":
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Impossible de modifier la demande N°" + Convert.ToString(gv_Liste.SelectedRows[0].Cells["NumDemande"].Value) + " \n car les résultats sont en cours de validation",
                                                    "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                            return;
                            break;
                        case "RESULTAT VALIDE":
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Impossible de modifier la demande N°" + Convert.ToString(gv_Liste.SelectedRows[0].Cells["NumDemande"].Value) + " \n car les résultats sont déja disponibles",
                                                    "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                            return;
                            break;
                        case "EDITION DE RESULTAT":
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Impossible de modifier la demande N°" + Convert.ToString(gv_Liste.SelectedRows[0].Cells["NumDemande"].Value) + " \n car les résultats sont déja disponibles",
                                                    "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                            return;
                            break;
                    }

                    DemandeAnalyse objDem = ((DemandeAnalyse)bds_Demandes.Current);
                    List<DonneesMCF> olstDonneesMCF = new List<DonneesMCF>();
                    olstDonneesMCF = DonneesMCF.Liste(Facture.FindFirst(null, (objDem.NumDemande)).IdFacture, null, null, null, null, null, null, null, null, null,
                        null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);

                    if(olstDonneesMCF.Count>0)
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, "Impossible de modifier la demande N°" + Convert.ToString(gv_Liste.SelectedRows[0].Cells["NumDemande"].Value) + " \n car elle est déja normalisée",
                                                "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                        return;
                    }

                    if (objDem.EstAnnulee==true)
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, "Impossible de modifier la demande N°" + Convert.ToString(gv_Liste.SelectedRows[0].Cells["NumDemande"].Value) + " \n car elle est déja annulée",
                                                "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                        return;
                    }

                }
                Bloquerdebloquer(false);

            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "veillez sélèctioner une ligne avant d'entamer la modification.",
                                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }
        private void btn_choixPatient_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_ListePatient frm = new Frm_ListePatient();
                frm.ShowDialog();
                oPatient = frm.oPatient;
                txt_Patient.Text = oPatient.NomPersonnePhysique + " " + oPatient.PrenomPersonnePhysique;
            }
            catch { }
        }

        private void btn_ChoixPartenaire_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_ListePartenaire frm = new Frm_ListePartenaire(false);
                frm.ShowDialog();
                oPartenaires = frm.oPartenaires;
                txt_Partenaire.Text = oPartenaires.NomSigle + " " + oPartenaires.PrenomRaisonSociale;
            }
            catch { }
        }

        private void btn_ChoixAssurance_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_ListeAssurances frm = new Frm_ListeAssurances();
                frm.ShowDialog();
                oAssurance = frm.oAssurance;
                txt_Assurance.Text = oAssurance.SiglePersonneMorale + " " + oAssurance.RaisonSociale;
            }
            catch { }
        }

        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            Bloquerdebloquer(true);
            Viderchamp();
            //bds_Demandes.DataSource = DemandeAnalyse.Liste(meb_DateDebut.Value.Date, meb_DateFin.Value.Date);
            ChargerDonnes((DemandeAnalyse)bds_Demandes.Current);
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            #region Déclaration

            DemandeAnalyse obj = new DemandeAnalyse();
            #endregion

            #region ControlDeSaisie



            if (txt_Patient.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez obligatoirement spécifier le patient", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);

                return;
            }

            if (meb_DateDemande.Value.Date > meb_DateResultatPrevue.Value.Date)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La date de la sortie des résultats ne peut pas être antérieur à la date de la demande.", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

            if (chk_Remise.Checked == true && rddl_Remise.Text == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Vous devez spécifier le type de remise", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);

                return;
            }

            if (gv_Analyses.RowCount==0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez renseigner les analyses", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                radPageView1.SelectedPage = radPageViewPage2;
                return;
            }

            if (chk_Retenue.IsChecked == true && oPartenaires.ConditionPartenaire.Trim() != "RETENUE A LA SOURCE")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La condition définie pour ce partenaire ne permet pas une retenue à la source", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);                
                return;
            }

            if (chk_DemandePriseEnCharge.IsChecked == true && oPartenaires.ConditionPartenaire.Trim() != "PAIEMENT EN FIN DE PERIODE")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La condition définie pour ce partenaire ne permet pas un paiement en fin de période", "GESLAB",
                MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

            #region grille des commandes
            //for (int i = 0; i < gv_ProduitCommande.RowCount; i++)
            //{
            //    if (Convert.ToDecimal(gv_ProduitCommande.Rows[i].Cells["PrixDeVente"].Value) <
            //        Convert.ToDecimal(gv_ProduitCommande.Rows[i].Cells["PrixVenteLimite"].Value) && Convert.ToString(gv_ProduitCommande.Rows[i].Cells["Motif"].Value) == "")
            //    {
            //        RadMessageBox.ThemeName = this.ThemeName;
            //        RadMessageBox.Show(this, "Veuillez spécifier un motif au niveau du produit " +
            //            gv_ProduitCommande.Rows[i].Cells["LibelleProduitAvecConditionnement"].Value.ToString() + " pour justifier un tel prix de vente",
            //            "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
            //        return;
            //    }
            //}
            #endregion
            #endregion


            #region Enregistrement

            if (nouveau)
            {
                constituerObjetDemande(obj);
                sortie = obj.Insert();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    //enregistrement des produits de la commande
                    for (int i = 0; i < gv_Analyses.RowCount; i++)
                    {
                        AnalyseDemande objPC = new AnalyseDemande();
                        objPC.NumDemande = obj.NumLigne;
                        objPC.CodeAnalyse = gv_Analyses.Rows[i].Cells["CodeAnalyse"].Value.ToString();
                        objPC.RemiseAnalyse = Convert.ToDecimal(gv_Analyses.Rows[i].Cells["RemiseAnalyse"].Value);
                        objPC.PrixNormal = Convert.ToDecimal(gv_Analyses.Rows[i].Cells["PrixNormal"].Value);
                        objPC.PrixApresRemise = Convert.ToDecimal(gv_Analyses.Rows[i].Cells["PrixApresRemise"].Value);
                        objPC.Qte = Convert.ToDecimal(gv_Analyses.Rows[i].Cells["Qte"].Value);
                        objPC.Interpretation = "";

                        string res = objPC.Insert();

                    }

                    #region Enregistrement de Facture
                    oFacture = new Facture();
                    oFacture.DateFacture = meb_DateDemande.Value;
                    oFacture.IdFacture = "";
                    oFacture.IdFactureAssurance = "";
                    oFacture.IdFacturePartenaire = "";
                    oFacture.MontantFacture = obj.MontantDemande;
                    oFacture.MontantRestantAPayer = obj.MontantDemande;
                    oFacture.NumDemande = obj.NumLigne;
                    oFacture.TypeFacture = "";
                    oFacture.Insert();
                    #endregion

                    
                    Bloquerdebloquer(true);
                    nouveau = false;
                    ChargerDonnes(obj);
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "GESLAB",
                    MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }
            #endregion

            #region Modification
            else
            {
                obj = (DemandeAnalyse)bds_Demandes.Current;
                constituerObjetDemande(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1] != "")
                {
                    //suppression des anciens produits de la commande
                    AnalyseDemande.DeleteAll(obj.NumLigne);
                    //enregistrement des produits de la commande
                    for (int i = 0; i < gv_Analyses.RowCount; i++)
                    {
                        AnalyseDemande objPC = new AnalyseDemande();
                        objPC.NumDemande = obj.NumLigne;
                        objPC.CodeAnalyse = gv_Analyses.Rows[i].Cells["CodeAnalyse"].Value.ToString();
                        objPC.RemiseAnalyse = Convert.ToDecimal(gv_Analyses.Rows[i].Cells["RemiseAnalyse"].Value);
                        objPC.PrixNormal = Convert.ToDecimal(gv_Analyses.Rows[i].Cells["PrixNormal"].Value);
                        objPC.PrixApresRemise = Convert.ToDecimal(gv_Analyses.Rows[i].Cells["PrixApresRemise"].Value);
                        objPC.Qte = Convert.ToDecimal(gv_Analyses.Rows[i].Cells["Qte"].Value);
                        objPC.Interpretation = "";
                        string res = objPC.Insert();
                    }
                    Bloquerdebloquer(true);

                    #region Modification de Facture

                    if (oFacture != null)
                    {
                        oFacture.DateFacture = meb_DateDemande.Value;
                        oFacture.IdFacture = oFacture.IdFacture;
                        oFacture.IdFactureAssurance = oFacture.IdFactureAssurance;
                        oFacture.IdFacturePartenaire = oFacture.IdFacturePartenaire;
                        oFacture.MontantFacture = obj.MontantDemande;
                        oFacture.MontantRestantAPayer = obj.MontantDemande;
                        oFacture.NumDemande = obj.NumLigne;
                        oFacture.TypeFacture = "";
                        oFacture.Update();
                    }
                    #endregion

                    ChargerDonnes(obj);
                }

                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), "GESLAB",
                MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }
            #endregion




        }

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            Frm_ReglementClient frm = new Frm_ReglementClient(true);
            frm.oFacture = oFacture;
            frm.ShowDialog();
        }

        private void btn_Facture1_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null &&
                gv_Liste.SelectedRows.Count != 0)
            {
                List<DonneesMCF> olstDonneesMCF = new List<DonneesMCF>();
                olstDonneesMCF = DonneesMCF.Liste(Facture.FindFirst(null, ((DemandeAnalyse)bds_Demandes.Current).NumDemande).IdFacture, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                  null, null, null, null, null, false, null);

                decimal montTot = 0;
                DataTable dt = null;
                string montEnLettre = "";
                dt = Rapport.FactureClient(((DemandeAnalyse)bds_Demandes.Current).NumDemande);
                if (dt != null && dt.Rows.Count != 0)
                    montTot = Convert.ToDecimal(dt.Rows[0]["montantDemande"]);
                montEnLettre = "Arretée la présente facture à la somme de " + Tools.convertirNombreEnLettre((float)montTot);
                TR_Facture3 rpt = new TR_Facture3();
                rpt.objectDataSource1.DataSource = dt;
                rpt.DataSource = rpt.objectDataSource1;
                try
                {
                    rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                }
                catch { }

                rpt.txt_Caisse.Value = CurrentUser.OUtilisateur.NumeroUtilisateur + "       " + nomVendeur;
                if (olstDonneesMCF.Count != 0)
                {
                    rpt.pnl_MCF.Visible = true;
                    rpt.txt_Compteur.Visible = true;
                    rpt.txt_dateEtHeure.Visible = true;
                    rpt.txt_sig.Visible = true;
                    rpt.pb_QRCode.Visible = true;
                    rpt.lbl_Compteurs.Visible = true;
                    rpt.lbl_NIM.Visible = true;
                    rpt.lbl_Heure.Visible = true;
                    rpt.lbl_Operateur.Visible = true;
                    rpt.txt_Operateur.Visible = true;

                    Utilisateur user = Utilisateur.Liste(null, null, null, null, null, null, null, null, null, ((DemandeAnalyse)bds_Demandes.Current).UserLogin.Trim(), null, null, null, null, null, null, null, false, null)[0];

                    idOperateur = Convert.ToInt32(user.NumeroUtilisateur);
                    operateur = (user.NomUtilisateur + " " + user.PrenomUtilisateur).Length > 32 ? (user.NomUtilisateur + " " + user.PrenomUtilisateur).Substring(0, 32) : (user.NomUtilisateur + " " + user.PrenomUtilisateur);

                    rpt.txt_Operateur.Value = idOperateur.ToString() + "    -   " + operateur;
                    rpt.txt_nim.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Nim : "Aucune donnée";
                    rpt.txt_Compteur.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Compteur : "Aucune donnée";
                    rpt.txt_dateEtHeure.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].DateEtHeure : "Aucune donnée";
                    rpt.txt_sig.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Sig : "Aucune donnée";
                }
                else
                {
                    rpt.pnl_MCF.Visible = false;
                    rpt.txt_Compteur.Visible = false;
                    rpt.txt_dateEtHeure.Visible = false;
                    rpt.txt_sig.Visible = false;
                    rpt.pb_QRCode.Visible = false;
                    rpt.lbl_Compteurs.Visible = false;
                    rpt.lbl_NIM.Visible = false;
                    rpt.lbl_Heure.Visible = false;
                    rpt.txt_nim.Value = "";
                    rpt.txt_Compteur.Value ="";
                    rpt.txt_dateEtHeure.Value = "";
                    rpt.txt_sig.Value = "";
                    rpt.lbl_Operateur.Visible = false;
                    rpt.txt_Operateur.Visible = false;
                }

                if (Convert.ToString(dt.Rows[0]["assurance"]) == "")
                {
                    rpt.lbl_MontantCouvert.Visible = rpt.txt_MontantCouvert.Visible = false;
                    rpt.txt_Avt_Ristourne.Visible = rpt.txt_Avt_Ristourne1.Visible = false;
                    rpt.lbl_Assurance.Visible = rpt.txt_Assurance.Visible = false;

                }
                else
                {
                    rpt.lbl_MontantCouvert.Visible = rpt.txt_MontantCouvert.Visible = true;
                    rpt.txt_Avt_Ristourne.Visible = rpt.txt_Avt_Ristourne1.Visible = true;
                    rpt.lbl_Assurance.Visible = rpt.txt_Assurance.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["partenaire"]) == "" || chk_AfficherCentre.Checked == false)
                {
                    rpt.lbl_Partenaire.Visible = false;
                    rpt.txt_Partenaire.Visible = false;

                }
                else
                {
                    rpt.lbl_Partenaire.Visible = true;
                    rpt.txt_Partenaire.Visible = true;

                }
                
                rpt.txt_V_Ap_Ristourne.Visible = false;
                rpt.txt_V_Ristourne.Visible = false;
                rpt.txt_Ristourne.Visible = false;
                rpt.txt_Ap_Ristourne.Visible = false;
                rpt.txt_Avt_Ristourne.Value = "Montant A verser";
                rpt.txt_montEnLettre.Value = montEnLettre + " (" + string.Format("{0:n0}", montTot) + ") francs CFA";
                rpt.txt_NomApplication.Value = "GESLAB";
                rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                    CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                rpt.pb_QRCode.Value = null;
                if (olstDonneesMCF != null && olstDonneesMCF.Count > 0 && olstDonneesMCF[0].CodeQRImage != null)
                {
                    using (Stream imgStr = new MemoryStream(olstDonneesMCF[0].CodeQRImage))
                    {
                        rpt.pb_QRCode.Value = System.Drawing.Image.FromStream(imgStr);
                    }
                }
                rpt.lbl_Profil.Value = CurrentUser.OProfil == null ? "CAISSE" : CurrentUser.OProfil.LibelleProfil;
                Frm_ReportViewer frm = new Frm_ReportViewer("FACTURE CLIENT", rpt);
                frm.MdiParent = Application.OpenForms["Frm_Menu"];
                frm.Show();
            }
        }

        private void btn_Facture_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null &&
                gv_Liste.SelectedRows.Count != 0)
            {
                DemandeAnalyse objDem = ((DemandeAnalyse)bds_Demandes.Current);
                List<DonneesMCF> olstDonneesMCF = new List<DonneesMCF>();
                olstDonneesMCF = DonneesMCF.Liste(Facture.FindFirst(null, (objDem.NumDemande)).IdFacture, null, null, null, null, null, null, null, null, null,
                    null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);


                PictureBox pb = new PictureBox();

                if (olstDonneesMCF.Count == 0)
                {

                    #region Envoi des informations à la DGI et édition de la facture Normalisée
                    //string port = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\HARDWARE\\DEVICEMAP\\SERIALCOMM", "\\Device\\Serial0", " ");
                    //string port1 = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\HARDWARE\\DEVICEMAP\\SERIALCOMM", "\\Device\\USBSER000", " ");

                    // Récupérer la liste des ports.
                    string[] ports = SerialPort.GetPortNames();
                   
                    byte seq = (byte)0;
                    bool C1Valide = false;

                    try
                    {

                        try
                        {
                            /* ETAT DE MCF*/

                            // Parcours de la liste.
                            #region MyRegion
                            //
                            ////foreach (string port in ports)
                            //{
                            //    try
                            //    {
                            //        SerialPort serialPort1 = new SerialPort(port, 115200);

                            //        if (serialPort1 != null)
                            //        {
                            //            //serialPort.Close();
                            //            try
                            //            {
                            //                serialPort1.Open();

                            //                if (!serialPort1.IsOpen)
                            //                    continue;
                            //                else
                            //                {
                            //                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                            //                    Commandes.SEQ_INT++;

                            //                    try
                            //                    {
                            //                        C1Valide = Commandes.C1h(serialPort1, seq);
                            //                    }
                            //                    catch (Exception ex)
                            //                    {
                            //                        C1Valide = false;
                            //                    }

                            //                    if (!C1Valide)
                            //                    {
                            //                        serialPort1.Close();
                            //                        continue;
                            //                    }
                            //                }

                            //                if (C1Valide)
                            //                {
                            //                    serialPort = serialPort1;
                            //                    break;
                            //                }
                            //            }
                            //            catch (Exception ex)
                            //            {
                            //                serialPort1.Close();
                            //                continue;
                            //            }
                            //        }
                            //    }
                            //    catch (Exception ex)
                            //    {

                            //        continue;
                            //    }
                            //} 
                            #endregion

                            //if (serialPort != null && !serialPort.IsOpen)
                            //    serialPort.Open();

                            string port = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\HARDWARE\\DEVICEMAP\\SERIALCOMM", "\\Device\\USBSER000", " ");
                            serialPort = new SerialPort(port, 115200, Parity.None, 8, StopBits.One);
                            serialPort.Open();


                            do
                            {

                                seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                Commandes.SEQ_INT++;

                                C1Valide = Commandes.C1h(serialPort, seq);

                                if (!C1Valide)
                                {

                                    RadMessageBox.ThemeName = this.ThemeName;
                                    RadMessageBox.Show(this, "[======ECHEC DE CONNEXION AU PC !======]",
                                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);

                                    serialPort.Close();
                                    return;

                                }
                                else
                                {
                                    //CurrentInfo.serialPort = serialPort;
                                    //RadMessageBox.ThemeName = this.ThemeName;
                                    //RadMessageBox.Show(this, "[======CONNEXION EFFECTUEE AVEC SUCCES !======]",
                                    //    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);

                                    #region récupérer les infos sur le contribuables
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    CurrentUser.nom = Commandes._2Bh(serialPort, seq, "I0");
                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    CurrentUser.adresse = Commandes._2Bh(serialPort, seq, "I1");

                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    CurrentUser.ville = Commandes._2Bh(serialPort, seq, "I2");

                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    CurrentUser.telephone = Commandes._2Bh(serialPort, seq, "I3");

                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    CurrentUser.mail = Commandes._2Bh(serialPort, seq, "I4");
                                    #endregion

                                }


                            } while (!C1Valide);
                        }
                        catch
                        {
                            if (serialPort != null)
                            serialPort.Close();
                        }

                        /* FIN ETAT DE MCF*/

                        if (C1Valide)
                        {
                            #region Détermination de l'id et du nom de l'opérateur
                            {
                                Utilisateur user = Utilisateur.Liste(null, null, null, null, null, null, null, null, null, objDem.UserLogin.Trim(), null, null, null, null, null, null, null, false, null)[0];

                                idOperateur = Convert.ToInt32(user.NumeroUtilisateur);
                                operateur = (user.NomUtilisateur + " " + user.PrenomUtilisateur).Length > 32 ? (user.NomUtilisateur + " " + user.PrenomUtilisateur).Substring(0, 32) : (user.NomUtilisateur + " " + user.PrenomUtilisateur);
                                if (objDem.IdPersonne > 0)
                                {
                                    Patient pat = lstPatient.Find(p => p.IdPersonne == objDem.IdPersonne);

                                    if (pat != null && pat.IdPersonne > 0)
                                        ifuAcheteur = "";

                                }
                                nomAcheteur = txt_Patient.Text;
                            }
                            #endregion


                            #region C0h (OUVRIR FACTURE)
                            Commandes.SEQ_INT++;
                            seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                            string message = Commandes.testC0h(serialPort, seq, idOperateur, operateur, ifuAcheteur,
                                nomAcheteur, Convert.ToString(AIB), "FV", "");

                            if (message != null && message.Length == 0)
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, "Facture non ouverte",
                                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                #region 38h (FERMER FACTURE)
                                Commandes.SEQ_INT++;
                                seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                message = Commandes.test38h(serialPort, seq);
                                #endregion

                                serialPort.Close();
                                return;
                            }

                            if (message != null && message.Contains("E:"))
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message.Split(':')[1],
                                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                #region 38h (FERMER FACTURE)
                                Commandes.SEQ_INT++;
                                seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                message = Commandes.test38h(serialPort, seq);
                                #endregion

                                serialPort.Close();
                                return;
                            }
                            #endregion

                            decimal tauxAssurance = ((100 - ((DemandeAnalyse)bds_Demandes.Current).TauxCouverture) / 100);
                            for (int i = 0; i < gv_Analyses.RowCount; i++)
                            {
                                decimal prixTTC = decimal.Round(Convert.ToDecimal(gv_Analyses.Rows[i].Cells["PrixApresRemise"].Value) * tauxAssurance, 0, MidpointRounding.AwayFromZero);

                                Analyse objP = Analyse.FindFirst(Convert.ToString(gv_Analyses.Rows[i].Cells["CodeAnalyse"].Value));
                                string libelleAnalyse = Convert.ToString(gv_Analyses.Rows[i].Cells["LibelleAnalyse"].Value);

                                AnalyseDemande objAD = AnalyseDemande.Liste(Convert.ToString(gv_Analyses.Rows[i].Cells["CodeAnalyse"].Value), objDem.NumDemande, null, null, null, null, null, null, null, null, false, null, null)[0];

                                string quantite = Convert.ToString(Math.Abs(decimal.Round(Convert.ToDecimal(gv_Analyses.Rows[i].Cells["Qte"].Value), 3))).Replace(",", ".");

                                #region 31h (INSCRIRE DES ARTICLES)

                                libelleAnalyse = libelleAnalyse.Length > 60
                                    ? Fonction.RemplacerCaracSpec(libelleAnalyse.Substring(0, 60)) :
                                            Fonction.RemplacerCaracSpec(libelleAnalyse);
                                List<byte> article = new List<byte>();
                                article = new List<Byte>(Encoding.Default.GetBytes(libelleAnalyse));
                                article.Add(0x09);
                                string lettre = "A";
                                article.Add(((byte)Convert.ToInt32(lettre[0])));
                                article.AddRange((Encoding.UTF8.GetBytes(Convert.ToString(prixTTC))));
                                string star = "*";
                                article.Add((byte)Convert.ToInt32(star[0]));
                                article.AddRange((Encoding.UTF8.GetBytes(quantite)));

                                #region gestion des remises
                                if (Convert.ToDecimal(gv_Analyses.Rows[i].Cells["RemiseAnalyse"].Value) != 0)
                                {
                                    string remise = "remise de " + Convert.ToDecimal(gv_Analyses.Rows[i].Cells["RemiseAnalyse"].Value);
                                    decimal prixOrig = Convert.ToDecimal(gv_Analyses.Rows[i].Cells["PrixNormal"].Value);
                                    article.Add(0x09);
                                    article.AddRange((Encoding.UTF8.GetBytes(Convert.ToString(prixOrig))));
                                    string virgule = ",";
                                    article.Add((byte)Convert.ToInt32(virgule[0]));
                                    article.AddRange((Encoding.Default.GetBytes(remise)));
                                }
                                #endregion

                                Commandes.SEQ_INT++;
                                seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                message = Commandes.C31h(serialPort, seq, article);
                                if (message.Split(',').Length == 4)
                                {
                                    #region 33h (LIRE SOUS TOTAL)
                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    message = Commandes.test33h(serialPort, seq);
                                    if (Convert.ToString(message[message.Length - 1]).Trim() == ",")
                                    {
                                        message = message.Substring(0, message.Length - 1);
                                    }
                                    if (message.Split(',').Length == 15)
                                    {

                                    }
                                    else
                                    {
                                        RadMessageBox.ThemeName = this.ThemeName;
                                        RadMessageBox.Show(this, "Impossible de déterminer le sous total pour l'article " + Convert.ToString(gv_Analyses.Rows[i].Cells["LibelleAnalyse"].Value).Trim(),
                                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                        #region 38h (FERMER FACTURE)
                                        Commandes.SEQ_INT++;
                                        seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                        message = Commandes.test38h(serialPort, seq);
                                        #endregion

                                        serialPort.Close();
                                        return;
                                    }
                                    #endregion
                                }
                                else
                                {
                                    RadMessageBox.ThemeName = this.ThemeName;
                                    RadMessageBox.Show(this, "Impossible d'inscrire l'article " + Convert.ToString(gv_Analyses.Rows[i].Cells["LibelleAnalyse"].Value).Trim(),
                                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                    #region 38h (FERMER FACTURE)
                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    message = Commandes.test38h(serialPort, seq);
                                    #endregion

                                    serialPort.Close();
                                    return;
                                }
                                #endregion
                            }

                            if (Convert.ToString(message[message.Length - 1]).Trim() == ",")
                            {
                                message = message.Substring(0, message.Length - 1);
                            }

                            if (message.Split(',').Length == 15)
                            {
                                if (Convert.ToDecimal(message.Split(',')[0]) != (Convert.ToDecimal(meb_MontantTotal.Value)*tauxAssurance))
                                {
                                    RadMessageBox.ThemeName = this.ThemeName;
                                    RadMessageBox.Show(this, "Montant Facture [" + Convert.ToDecimal(meb_MontantClient.Value) + "] != Montant Mcf [" + Convert.ToDecimal(message.Split(',')[0]) + "]",
                                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                    #region 38h (FERMER FACTURE)
                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    message = Commandes.test38h(serialPort, seq);
                                    #endregion

                                    serialPort.Close();
                                    return;
                                }

                                #region 35h (CONFIRMER FACTURE)
                                List<ReglementClient> lstReglement = ReglementClient.Liste(null, null, objDem.NumDemande, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null);
                                Commandes.SEQ_INT++;
                                seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);

                                if (lstReglement.Count == 0)
                                {
                                    message = Commandes.test35h(serialPort, seq, "E" + Convert.ToString((Convert.ToDecimal(meb_MontantTotal.Value))));
                                    while (message.Trim().Contains("E"))
                                    {
                                        Commandes.SEQ_INT++;
                                        seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                        message = Commandes.test35h(serialPort, seq, "E" + Convert.ToString((Convert.ToDecimal(meb_MontantTotal.Value))));
                                    }
                                }
                                else
                                {
                                    foreach (ReglementClient unReglement in lstReglement)
                                    {
                                        Commandes.SEQ_INT++;
                                        seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                        message = Commandes.test35h(serialPort, seq, unReglement.ValeurMCF + Convert.ToString((decimal.Round(unReglement.Montant))));
                                        while (message.Trim().Contains("E"))
                                        {
                                            Commandes.SEQ_INT++;
                                            seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                            message = Commandes.test35h(serialPort, seq, unReglement.ValeurMCF + Convert.ToString((decimal.Round(unReglement.Montant))));
                                        }
                                    }
                                }
                                #endregion

                                if (message.Trim().Contains("R"))
                                {
                                    #region Traitement de la reponse de 35h

                                    #region 38h (FERMER FACTURE)
                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    message = Commandes.test38h(serialPort, seq);
                                    #endregion

                                    if (message.Split(',').Length == 6)
                                    {
                                        RadMessageBox.ThemeName = this.ThemeName;
                                        MessageBox.Show(this, "La signature n'a pas été retournée car la facture est considérée comme annulée",
                                            CurrentUser.LogicielHote, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        #region 38h (FERMER FACTURE)
                                        Commandes.SEQ_INT++;
                                        seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                        message = Commandes.test38h(serialPort, seq);
                                        #endregion

                                        serialPort.Close();
                                        return;
                                    }
                                    if (message.Split(',').Length == 7)
                                    {
                                        codeQR = "F;" + message.Split(',')[4] + ";" + message.Split(',')[6] + ";" + message.Split(',')[5] + ";" + message.Split(',')[3];

                                        #region génération de QRCode

                                        string DATA = codeQR;
                                        QRCodeGenerator qrGenerator = new QRCodeGenerator();
                                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(DATA, QRCodeGenerator.ECCLevel.M);
                                        QRCode qrCode = new QRCode(qrCodeData);
                                        //Bitmap qrCodeImage = qrCode.GetGraphic(20);

                                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                                        imgBarCode.Height = 150;
                                        imgBarCode.Width = 150;

                                        using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                                        {
                                            using (MemoryStream ms = new MemoryStream())
                                            {
                                                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                                byte[] byteImage = ms.ToArray();
                                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);

                                                Panel pnl_codeQR = new Panel();
                                                pnl_codeQR.BackgroundImage = qrCodeImage;

                                                #region Sauvegarde dans la table T_DonneesMCF
                                                try
                                                {
                                                    DonneesMCF obj = new DonneesMCF();
                                                    obj.IdFacture = Facture.FindFirst(null, (objDem.NumDemande)).IdFacture;
                                                    obj.Fc = Convert.ToDecimal(message.Split(',')[0]);
                                                    obj.Tc = Convert.ToDecimal(message.Split(',')[1]);
                                                    obj.Ft = message.Split(',')[2];
                                                    obj.Sig = Fonction.Signature(Convert.ToString(message.Split(',')[6]));
                                                    obj.Compteur = Convert.ToString(message.Split(',')[0]) + "/" + Convert.ToString(message.Split(',')[1])
                                                        + "" + Convert.ToString(message.Split(',')[2]);
                                                    obj.DateEtHeure = Fonction.dateSignature(message.Split(',')[3]);
                                                    obj.CodeQR = codeQR;
                                                    obj.Nim = message.Split(',')[4];
                                                    obj.CodeQRImage = byteImage;
                                                    obj.Adresse = CurrentUser.adresse;
                                                    obj.Mail = CurrentUser.mail;
                                                    obj.IFU = Commandes.IFU;
                                                    obj.Nom = CurrentUser.nom;
                                                    obj.Telephone = CurrentUser.telephone;
                                                    obj.RCCM = "";
                                                    obj.Ville = CurrentUser.ville;
                                                    obj.Reference = "";
                                                    obj.Insert();


                                                }
                                                catch (Exception ex)
                                                {
                                                    RadMessageBox.ThemeName = this.ThemeName;
                                                    RadMessageBox.Show(this, ex.Message,
                                                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                                }
                                                finally
                                                {

                                                }
                                                #endregion
                                            }
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    RadMessageBox.ThemeName = this.ThemeName;
                                    MessageBox.Show(this, "Cette facture ne peut etre confirmée",
                                        CurrentUser.LogicielHote, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    #region 38h (FERMER FACTURE)
                                    Commandes.SEQ_INT++;
                                    seq = Fonction.convertirSeqInt(Commandes.SEQ_INT);
                                    message = Commandes.test38h(serialPort, seq);
                                    #endregion

                                    serialPort.Close();
                                    return;
                                }
                            }
                        }

                        serialPort.Close();

                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, "NORMALISATION TERMINEE AVEC SUCCES",
                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    catch (Exception ex)
                    {
                        if (serialPort != null)
                            serialPort.Close();

                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, ex.Message,
                            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);

                        return;
                    }
                    #endregion
                }
                else
                {
                    btn_Facture1_Click(null, null);
                }

             
            }
        }

        private void btn_AjouterAnalyse_Click(object sender, EventArgs e)
        {
            Frm_ListeAnalyse frm = new Frm_ListeAnalyse();
            frm.FrmSource = "demande";
            frm.ShowDialog();
        }

        private void btn_EnleverAnalyse_Click(object sender, EventArgs e)
        {
            if (gv_Analyses.SelectedRows != null &&
               gv_Analyses.SelectedRows.Count != 0)//vérifie si une ligne est sélectionnée
            {
                gv_Analyses.Rows.RemoveAt(gv_Analyses.SelectedRows[0].Index);//supprime la ligne sélectionnée 
                rddl_Remise_SelectedIndexChanged(null, null);
                calculerBrut();
                calculerMontantNet();
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            try
            {
                Viderchamp();
                olstDemandeAnalyse = DemandeAnalyse.Liste(meb_DateDebut.Value, meb_DateFin.Value);
                bds_Demandes.DataSource = olstDemandeAnalyse.FindAll(x => x.EstAnnulee == false);
                //gv_Liste.PerformLayout();
            }
            catch (Exception ex)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, ex.Message,
                CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        #endregion

        #region RadCheckBox
        private void chk_Partenaire_Click(object sender, EventArgs e)
        {
            if (btn_Nouveau.Visible == false)
            {
                gb_Partenaire.Enabled = !chk_Partenaire.Checked == true ? true : false;
                txt_Partenaire.Text = "";
                txt_beneficiaire.Text = "";
                chk_DemandePriseEnCharge.IsChecked = false;
                oPartenaires = null;
            }

        }

        private void chk_Assurance_Click(object sender, EventArgs e)
        {
            if (btn_Nouveau.Visible == false)
            {
                gb_Assurance.Enabled = !chk_Assurance.Checked == true ? true : false;
                txt_Assurance.Text = "";
                meb_Taux.Value = 0;
                calculerMontantNet();
                oAssurance = null;
            }

        }

        private void chk_Remise_Click(object sender, EventArgs e)
        {
            rddl_Remise.Enabled = !chk_Remise.Checked;
            rddl_Remise.Text = "";


            if (!chk_Remise.Checked == true)
            {
                gv_Analyses.Columns["RemiseAnalyse"].ReadOnly = false;
                meb_TauxRemise.Enabled = true;

            }
            else
            {
                gv_Analyses.Columns["RemiseAnalyse"].ReadOnly = true;
                rddl_Remise.Text = "";
                meb_TauxRemise.Enabled = false;
            }

            rddl_Remise_SelectedIndexChanged(null, null);
            calculerMontantNet();
        } 
        #endregion

        #region RadDropDownList
        private void rddl_Remise_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            if (rddl_Remise.Text.Trim() == "SUR LES PRODUITS")
            {
                gv_Analyses.Columns["RemiseAnalyse"].ReadOnly = false;
                meb_MontRemise.ReadOnly = true;
                calculerRemise();

            }
            else

                if (rddl_Remise.Text.Trim() != "SUR LES PRODUITS" || rddl_Remise.Text.Trim() == "")
                {
                    gv_Analyses.Columns["RemiseAnalyse"].ReadOnly = true;
                    meb_MontRemise.ReadOnly = false;
                    meb_MontRemise.Value = 0;
                    meb_MontRemise1.Value = 0;
                    for (int i = 0; i < gv_Analyses.RowCount; i++)
                    {
                        gv_Analyses.Rows[i].Cells["RemiseAnalyse"].Value = 0;
                        gv_Analyses.Rows[i].Cells["PrixApresRemise"].Value = gv_Analyses.Rows[i].Cells["PrixNormal"].Value;
                    }

                   
                }


        } 
        #endregion
       

        #region RadMaskEditBox
        private void meb_Taux_ValueChanged(object sender, EventArgs e)
        {
            calculerMontantNet();
        }


        private void meb_MontCouvert_ValueChanged(object sender, EventArgs e)
        {

        }

        private void meb_MontRemise_ValueChanged(object sender, EventArgs e)
        {
            //if (meb_MontRemise.ReadOnly == false)
            {
                calculerMontantNet();
            }
            meb_MontRemise1.Value = meb_MontRemise.Value;
        }


        private void meb_TauxRemise_ValueChanged(object sender, EventArgs e)
        {
            if (meb_TauxRemise.ReadOnly == false)
            {
                meb_MontRemise.Value = meb_MontRemise1.Value = (Convert.ToDecimal(meb_MontantTotal.Value) - Convert.ToDecimal(meb_MontCouvert.Value)) * Convert.ToDecimal(meb_TauxRemise.Value) / 100;
                calculerMontantNet();
            }
        }

        #endregion
               

        #region DatagridView
        private void gv_Analyses_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0 &&
                    (e.Column.Name == "RemiseAnalyse" || e.Column.Name == "PrixNormal" || e.Column.Name == "Qte")))
            {
                if (Convert.ToDecimal(gv_Analyses.Rows[e.RowIndex].Cells["PrixNormal"].Value) < Convert.ToDecimal(gv_Analyses.Rows[e.RowIndex].Cells["RemiseAnalyse"].Value))
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "la remise ne peut excéder le prix normal.",
                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                    gv_Analyses.Rows[e.RowIndex].Cells["RemiseAnalyse"].Value = 0;
                    return;
                }



                if (rddl_Remise.Text == "" && e.Column.Name == "RemiseAnalyse")
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Veuillez spécifier le type de remise",
                        "GESLAB", MessageBoxButtons.OK, RadMessageIcon.Error);
                    gv_Analyses.Rows[e.RowIndex].Cells["RemiseAnalyse"].Value = 0;
                    return;
                }
                gv_Analyses.Rows[e.RowIndex].Cells["PrixApresRemise"].Value = ( Convert.ToDecimal(gv_Analyses.Rows[e.RowIndex].Cells["PrixNormal"].Value) - Convert.ToDecimal(gv_Analyses.Rows[e.RowIndex].Cells["RemiseAnalyse"].Value));
                gv_Analyses.Rows[e.RowIndex].Cells["MontantLigne"].Value = (Convert.ToDecimal(gv_Analyses.Rows[e.RowIndex].Cells["PrixApresRemise"].Value)*Convert.ToDecimal(gv_Analyses.Rows[e.RowIndex].Cells["Qte"].Value));
                rddl_Remise_SelectedIndexChanged(null, null);
                calculerBrut();
                calculerMontantNet();
            }

        }
       
        #endregion

        private void rmi_A4_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null &&
                 gv_Liste.SelectedRows.Count != 0)
            {
                List<DonneesMCF> olstDonneesMCF = new List<DonneesMCF>();
                olstDonneesMCF = DonneesMCF.Liste(Facture.FindFirst(null, ((DemandeAnalyse)bds_Demandes.Current).NumDemande).IdFacture, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                  null, null, null, null, null, false, null);

                decimal montTot = 0;
                DataTable dt = null;
                string montEnLettre = "";
                dt = Rapport.FactureClient(((DemandeAnalyse)bds_Demandes.Current).NumDemande);
                if (dt != null && dt.Rows.Count != 0)
                    montTot = Convert.ToDecimal(dt.Rows[0]["montantDemande"]);
                montEnLettre = "Arretée la présente facture à la somme de " + Tools.convertirNombreEnLettre((float)montTot);
                TR_Facture2 rpt = new TR_Facture2();
                rpt.objectDataSource1.DataSource = dt;
                rpt.DataSource = rpt.objectDataSource1;
                try
                {
                    rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                }
                catch { }

                rpt.txt_Caisse.Value = CurrentUser.OUtilisateur.NumeroUtilisateur + "       " + nomVendeur;
                if (olstDonneesMCF.Count != 0)
                {
                    rpt.pnl_MCF.Visible = true;
                    rpt.txt_Compteur.Visible = true;
                    rpt.txt_dateEtHeure.Visible = true;
                    rpt.txt_sig.Visible = true;
                    rpt.pb_QRCode.Visible = true;
                    rpt.lbl_Compteurs.Visible = true;
                    rpt.lbl_NIM.Visible = true;
                    rpt.lbl_Heure.Visible = true;
                    rpt.lbl_Operateur.Visible = true;
                    rpt.txt_Operateur.Visible = true;

                    Utilisateur user = Utilisateur.Liste(null, null, null, null, null, null, null, null, null, ((DemandeAnalyse)bds_Demandes.Current).UserLogin.Trim(), null, null, null, null, null, null, null, false, null)[0];

                    idOperateur = Convert.ToInt32(user.NumeroUtilisateur);
                    operateur = (user.NomUtilisateur + " " + user.PrenomUtilisateur).Length > 32 ? (user.NomUtilisateur + " " + user.PrenomUtilisateur).Substring(0, 32) : (user.NomUtilisateur + " " + user.PrenomUtilisateur);

                    rpt.txt_Operateur.Value = idOperateur.ToString() + "    -   " + operateur;
                    rpt.txt_nim.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Nim : "Aucune donnée";
                    rpt.txt_Compteur.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Compteur : "Aucune donnée";
                    rpt.txt_dateEtHeure.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].DateEtHeure : "Aucune donnée";
                    rpt.txt_sig.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Sig : "Aucune donnée";
                }
                else
                {
                    rpt.pnl_MCF.Visible = false;
                    rpt.txt_Compteur.Visible = false;
                    rpt.txt_dateEtHeure.Visible = false;
                    rpt.txt_sig.Visible = false;
                    rpt.pb_QRCode.Visible = false;
                    rpt.lbl_Compteurs.Visible = false;
                    rpt.lbl_NIM.Visible = false;
                    rpt.lbl_Heure.Visible = false;
                    rpt.txt_nim.Value = "";
                    rpt.txt_Compteur.Value = "";
                    rpt.txt_dateEtHeure.Value = "";
                    rpt.txt_sig.Value = "";
                    rpt.lbl_Operateur.Visible = false;
                    rpt.txt_Operateur.Visible = false;
                }

                if (Convert.ToString(dt.Rows[0]["assurance"]) == "")
                {
                    rpt.lbl_MontantCouvert.Visible = rpt.txt_MontantCouvert.Visible = false;
                    rpt.txt_Avt_Ristourne.Visible = rpt.txt_Avt_Ristourne1.Visible = false;
                    rpt.lbl_Assurance.Visible = rpt.txt_Assurance.Visible = false;

                }
                else
                {
                    rpt.lbl_MontantCouvert.Visible = rpt.txt_MontantCouvert.Visible = true;
                    rpt.txt_Avt_Ristourne.Visible = rpt.txt_Avt_Ristourne1.Visible = true;
                    rpt.lbl_Assurance.Visible = rpt.txt_Assurance.Visible = true;
                }

                if (Convert.ToString(dt.Rows[0]["partenaire"]) == "" || chk_AfficherCentre.Checked == false)
                {
                    rpt.lbl_Partenaire.Visible =  false;
                    rpt.txt_Partenaire.Visible = false;                  

                }
                else
                {
                    rpt.lbl_Partenaire.Visible = true;
                    rpt.txt_Partenaire.Visible = true;
                   
                }
                rpt.txt_V_Ap_Ristourne.Visible = false;
                rpt.txt_V_Ristourne.Visible = false;
                rpt.txt_Ristourne.Visible = false;
                rpt.txt_Ap_Ristourne.Visible = false;
                rpt.txt_Avt_Ristourne.Value = "Montant A verser";
                rpt.txt_Caisse.Value = CurrentUser.OUtilisateur.NumeroUtilisateur + "       " + nomVendeur;
                rpt.txt_montEnLettre.Value = montEnLettre + " (" + string.Format("{0:n0}", montTot) + ") francs CFA";
                rpt.txt_NomApplication.Value = "GESLAB";
                rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                    CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                rpt.pb_QRCode.Value = null;
                if (olstDonneesMCF != null && olstDonneesMCF.Count > 0 && olstDonneesMCF[0].CodeQRImage != null)
                {
                    using (Stream imgStr = new MemoryStream(olstDonneesMCF[0].CodeQRImage))
                    {
                        rpt.pb_QRCode.Value = System.Drawing.Image.FromStream(imgStr);
                    }
                }
                rpt.lbl_Profil.Value = CurrentUser.OProfil == null ? "CAISSE" : CurrentUser.OProfil.LibelleProfil;
                Frm_ReportViewer frm = new Frm_ReportViewer("FACTURE CLIENT", rpt);
                frm.MdiParent = Application.OpenForms["Frm_Menu"];
                frm.Show();
            }
        }

       
        private void rmiA4AvecRistourne_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null &&
                gv_Liste.SelectedRows.Count != 0)
            {
                List<DonneesMCF> olstDonneesMCF = new List<DonneesMCF>();
                olstDonneesMCF = DonneesMCF.Liste(Facture.FindFirst(null, ((DemandeAnalyse)bds_Demandes.Current).NumDemande).IdFacture, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                  null, null, null, null, null, false, null);

                decimal montTot = 0;
                DataTable dt = null;
                string montEnLettre = "";
                dt = Rapport.FactureClient(((DemandeAnalyse)bds_Demandes.Current).NumDemande);
                if (dt != null && dt.Rows.Count != 0)
                    montTot = Convert.ToDecimal(dt.Rows[0]["montantDemande"]);
                montEnLettre = "Arretée la présente facture à la somme de " + Tools.convertirNombreEnLettre((float)montTot);
                TR_Facture2 rpt = new TR_Facture2();
                rpt.objectDataSource1.DataSource = dt;
                rpt.DataSource = rpt.objectDataSource1;
                try
                {
                    rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                }
                catch { }

                rpt.txt_Caisse.Value = CurrentUser.OUtilisateur.NumeroUtilisateur + "       " + nomVendeur;
                if (olstDonneesMCF.Count != 0)
                {
                    rpt.pnl_MCF.Visible = true;
                    rpt.txt_Compteur.Visible = true;
                    rpt.txt_dateEtHeure.Visible = true;
                    rpt.txt_sig.Visible = true;
                    rpt.pb_QRCode.Visible = true;
                    rpt.lbl_Compteurs.Visible = true;
                    rpt.lbl_NIM.Visible = true;
                    rpt.lbl_Heure.Visible = true;
                    rpt.lbl_Operateur.Visible = true;
                    rpt.txt_Operateur.Visible = true;

                    Utilisateur user = Utilisateur.Liste(null, null, null, null, null, null, null, null, null, ((DemandeAnalyse)bds_Demandes.Current).UserLogin.Trim(), null, null, null, null, null, null, null, false, null)[0];

                    idOperateur = Convert.ToInt32(user.NumeroUtilisateur);
                    operateur = (user.NomUtilisateur + " " + user.PrenomUtilisateur).Length > 32 ? (user.NomUtilisateur + " " + user.PrenomUtilisateur).Substring(0, 32) : (user.NomUtilisateur + " " + user.PrenomUtilisateur);

                    rpt.txt_Operateur.Value = idOperateur.ToString() + "    -   " + operateur;
                    rpt.txt_nim.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Nim : "Aucune donnée";
                    rpt.txt_Compteur.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Compteur : "Aucune donnée";
                    rpt.txt_dateEtHeure.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].DateEtHeure : "Aucune donnée";
                    rpt.txt_sig.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Sig : "Aucune donnée";
                }
                else
                {
                    rpt.pnl_MCF.Visible = false;
                    rpt.txt_Compteur.Visible = false;
                    rpt.txt_dateEtHeure.Visible = false;
                    rpt.txt_sig.Visible = false;
                    rpt.pb_QRCode.Visible = false;
                    rpt.lbl_Compteurs.Visible = false;
                    rpt.lbl_NIM.Visible = false;
                    rpt.lbl_Heure.Visible = false;
                    rpt.txt_nim.Value = "";
                    rpt.txt_Compteur.Value = "";
                    rpt.txt_dateEtHeure.Value = "";
                    rpt.txt_sig.Value = "";
                    rpt.lbl_Operateur.Visible = false;
                    rpt.txt_Operateur.Visible = false;
                }
                if (Convert.ToString(dt.Rows[0]["assurance"]) == "")
                {
                    rpt.lbl_MontantCouvert.Visible = rpt.txt_MontantCouvert.Visible = false;

                }
                else
                {
                    rpt.lbl_MontantCouvert.Visible = rpt.txt_MontantCouvert.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["partenaire"]) == "" || chk_AfficherCentre.Checked == false)
                {
                    rpt.lbl_Partenaire.Visible = false;
                    rpt.txt_Partenaire.Visible = false;

                }
                else
                {
                    rpt.lbl_Partenaire.Visible = true;
                    rpt.txt_Partenaire.Visible = true;

                }
                rpt.txt_V_Ap_Ristourne.Visible = true;
                rpt.txt_V_Ristourne.Visible = true;
                rpt.txt_Ristourne.Visible = true;
                rpt.txt_Ap_Ristourne.Visible = true;
                rpt.txt_Avt_Ristourne.Value = "Montant Av. Ristourne";
                rpt.txt_Caisse.Value = CurrentUser.OUtilisateur.NumeroUtilisateur + "       " + nomVendeur;
                rpt.txt_montEnLettre.Value = montEnLettre + " (" + string.Format("{0:n0}", montTot) + ") francs CFA";
                rpt.txt_NomApplication.Value = "GESLAB";
                rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                    CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                rpt.pb_QRCode.Value = null;
                if (olstDonneesMCF != null && olstDonneesMCF.Count > 0 && olstDonneesMCF[0].CodeQRImage != null)
                {
                    using (Stream imgStr = new MemoryStream(olstDonneesMCF[0].CodeQRImage))
                    {
                        rpt.pb_QRCode.Value = System.Drawing.Image.FromStream(imgStr);
                    }
                }
                rpt.lbl_Profil.Value = CurrentUser.OProfil == null ? "CAISSE" : CurrentUser.OProfil.LibelleProfil;
                Frm_ReportViewer frm = new Frm_ReportViewer("FACTURE CLIENT", rpt);
                frm.MdiParent = Application.OpenForms["Frm_Menu"];
                frm.Show();
            }
        }

        private void rmiA5AvecRistourne_Click(object sender, EventArgs e)
        {
            if (gv_Liste.SelectedRows != null &&
                gv_Liste.SelectedRows.Count != 0)
            {
                List<DonneesMCF> olstDonneesMCF = new List<DonneesMCF>();
                olstDonneesMCF = DonneesMCF.Liste(Facture.FindFirst(null, ((DemandeAnalyse)bds_Demandes.Current).NumDemande).IdFacture, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                  null, null, null, null, null, false, null);

                decimal montTot = 0;
                DataTable dt = null;
                string montEnLettre = "";
                dt = Rapport.FactureClient(((DemandeAnalyse)bds_Demandes.Current).NumDemande);
                if (dt != null && dt.Rows.Count != 0)
                    montTot = Convert.ToDecimal(dt.Rows[0]["montantDemande"]);
                montEnLettre = "Arretée la présente facture à la somme de " + Tools.convertirNombreEnLettre((float)montTot);
                TR_Facture3 rpt = new TR_Facture3();
                rpt.objectDataSource1.DataSource = dt;
                rpt.DataSource = rpt.objectDataSource1;
                try
                {
                    rpt.pb_imageEntete.Value = Image.FromFile(CurrentUser.ImagePath + "\\" + "logo_(1).jpg");

                }
                catch { }

                rpt.txt_Caisse.Value =CurrentUser.OUtilisateur.NumeroUtilisateur + "       " + nomVendeur;
                if (olstDonneesMCF.Count != 0)
                {
                    rpt.pnl_MCF.Visible = true;
                    rpt.txt_Compteur.Visible = true;
                    rpt.txt_dateEtHeure.Visible = true;
                    rpt.txt_sig.Visible = true;
                    rpt.pb_QRCode.Visible = true;
                    rpt.lbl_Compteurs.Visible = true;
                    rpt.lbl_NIM.Visible = true;
                    rpt.lbl_Heure.Visible = true;
                    rpt.lbl_Operateur.Visible = true;
                    rpt.txt_Operateur.Visible = true;

                    Utilisateur user = Utilisateur.Liste(null, null, null, null, null, null, null, null, null, ((DemandeAnalyse)bds_Demandes.Current).UserLogin.Trim(), null, null, null, null, null, null, null, false, null)[0];

                    idOperateur = Convert.ToInt32(user.NumeroUtilisateur);
                    operateur = (user.NomUtilisateur + " " + user.PrenomUtilisateur).Length > 32 ? (user.NomUtilisateur + " " + user.PrenomUtilisateur).Substring(0, 32) : (user.NomUtilisateur + " " + user.PrenomUtilisateur);

                    rpt.txt_Operateur.Value = idOperateur.ToString() + "    -   " + operateur;
                    rpt.txt_nim.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Nim : "Aucune donnée";
                    rpt.txt_Compteur.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Compteur : "Aucune donnée";
                    rpt.txt_dateEtHeure.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].DateEtHeure : "Aucune donnée";
                    rpt.txt_sig.Value = (olstDonneesMCF != null && olstDonneesMCF.Count > 0) ? olstDonneesMCF[0].Sig : "Aucune donnée";
                }
                else
                {
                    rpt.pnl_MCF.Visible = false;
                    rpt.txt_Compteur.Visible = false;
                    rpt.txt_dateEtHeure.Visible = false;
                    rpt.txt_sig.Visible = false;
                    rpt.pb_QRCode.Visible = false;
                    rpt.lbl_Compteurs.Visible = false;
                    rpt.lbl_NIM.Visible = false;
                    rpt.lbl_Heure.Visible = false;
                    rpt.txt_nim.Value = "";
                    rpt.txt_Compteur.Value = "";
                    rpt.txt_dateEtHeure.Value = "";
                    rpt.txt_sig.Value = "";
                    rpt.lbl_Operateur.Visible = false;
                    rpt.txt_Operateur.Visible = false;
                }
                if (Convert.ToString(dt.Rows[0]["assurance"]) == "")
                {
                    rpt.lbl_MontantCouvert.Visible = rpt.txt_MontantCouvert.Visible = false;

                }
                else
                {
                    rpt.lbl_MontantCouvert.Visible = rpt.txt_MontantCouvert.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["partenaire"]) == "" || chk_AfficherCentre.Checked == false)
                {
                    rpt.lbl_Partenaire.Visible = false;
                    rpt.txt_Partenaire.Visible = false;

                }
                else
                {
                    rpt.lbl_Partenaire.Visible = true;
                    rpt.txt_Partenaire.Visible = true;

                }
                rpt.txt_V_Ap_Ristourne.Visible=true;
                rpt.txt_V_Ristourne.Visible=true;
                rpt.txt_Ristourne.Visible=true;
                rpt.txt_Ap_Ristourne.Visible = true;
                rpt.txt_Avt_Ristourne.Value = "Montant Av. Ristourne";
                rpt.txt_montEnLettre.Value = montEnLettre + " (" + string.Format("{0:n0}", montTot) + ") francs CFA";
                rpt.txt_NomApplication.Value = "GESLAB";
                rpt.txt_Devise.Value = "DEVISE " + CurrentUser.OSociete.Devise;
                rpt.txt_Ligne1.Value = "Tel:" + CurrentUser.OSociete.TelephoneMobile1 + "/" + CurrentUser.OSociete.TelephoneMobile2 + "/" + CurrentUser.OSociete.TelephoneFixe1 + "/" +
                    CurrentUser.OSociete.TelephoneFixe2 + " " + CurrentUser.OSociete.BoitePostale + " " + CurrentUser.OSociete.AdresseComplete + "- Mail:" + CurrentUser.OSociete.Email;
                rpt.txt_Ligne2.Value = " N°RCCM " + CurrentUser.OSociete.NumAgrement + "- IFU" + CurrentUser.OSociete.Ifu + "- COMPTE BANCAIRE:" + CurrentUser.OSociete.CompteBancaire;
                rpt.pb_QRCode.Value = null;
                if (olstDonneesMCF != null && olstDonneesMCF.Count > 0 && olstDonneesMCF[0].CodeQRImage != null)
                {
                    using (Stream imgStr = new MemoryStream(olstDonneesMCF[0].CodeQRImage))
                    {
                        rpt.pb_QRCode.Value = System.Drawing.Image.FromStream(imgStr);
                    }
                }
                rpt.lbl_Profil.Value = CurrentUser.OProfil == null ? "CAISSE" : CurrentUser.OProfil.LibelleProfil;
                Frm_ReportViewer frm = new Frm_ReportViewer("FACTURE CLIENT", rpt);
                frm.MdiParent = Application.OpenForms["Frm_Menu"];
                frm.Show();
            }
        }

        private void chk_Retenue_Click_1(object sender, EventArgs e)
        {
            meb_TauxRetenue.Value = oPartenaires != null ? oPartenaires.tauxRistourne : 0;
            calculerMontantNet();
        }

        private void chk_DemandePriseEnCharge_Click_1(object sender, EventArgs e)
        {
            meb_TauxRetenue.Value = 0;
            calculerMontantNet();
        }

        private void gv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (gv_Liste.SelectedRows != null && gv_Liste.SelectedRows.Count != 0)
            //    {
            Detailler((DemandeAnalyse)bds_Demandes.Current);
            //    }
            //    else
            //    {
            //        Viderchamp();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    RadMessageBox.ThemeName = this.ThemeName;
            //    RadMessageBox.Show(this, ex.Message,
            //    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            //}
        }

        private void meb_DateDebut_ValueChanged(object sender, EventArgs e)
        {
            bds_Demandes.DataSource = new List<DemandeAnalyse>();
            bds_AnalyseDemande.DataSource = new List<AnalyseDemande>();
        }
    }
}

    