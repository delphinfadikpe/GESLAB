using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
//using LGC.Business.Parametre;
//using LGC.Business.Parametre;
using Telerik.WinControls.UI;
//using LGC.Business.Comptabilite;

using Telerik.WinControls.UI.Localization;

using LGC.UI.GestionUtilisateur;
using LGC.Business.GestionUtilisateur;

using LGC.Business;
using LGC.UI.Parametre;
using System.IO;
using LGC.UI.GestionDeStock;
using LGC.UI.GestionDesAnalyses;
using LGG.UI.GestionDeLaCaisse;
using LGC.Business.Parametre;
using System.Threading;
using LGC.UI.FormulaireEtat;
using LGG.UI.Parametre;
using LGC.Business.GestionDeStock;
using LGO.UI.Impressions;

namespace LGC.UI
{
    public partial class Frm_Menu : Telerik.WinControls.UI.RadForm
    {
        #region autres

        #region Gestion d'alerte
        //RadDesktopAlert radDesktopAlert1 = new RadDesktopAlert();

        List<Intrants> lstIntrantStockSecurite =
            new List<Intrants>();
        List<Intrants> lstIntrantStockCritique =
            new List<Intrants>();
       
        private delegate void ExecuterTimerRappel();
        private delegate void TacheATraiter(); //

        private TacheATraiter TacheATraiterAgent;
        Thread th, th1;
        //timer
        System.Windows.Forms.Timer timerAttente = new System.Windows.Forms.Timer();

        //duree
        long temps = 0, dureeMaxverouill = 10;
        //Déclaration de variable 
        public static int nbreIntrantStockSecurie, nbreIntrantStockCritique;
        bool estConnecte = false;
        #endregion
        //public void AfficherForm(RadForm frm, string nomForm)
        //{
        //    RadForm frmO = (RadForm)Application.OpenForms[nomForm];
        //    if (frmO != null)
        //    {
        //        frmO.BringToFront();
        //        frmO.Select();
        //    }
        //    else
        //    {
        //        frm.MdiParent = this;
        //        frm.Show();
        //    }
        //}
        private void MAJTacheATraiter()
        {
            try
            {

                {


                    nbreIntrantStockSecurie = lstIntrantStockSecurite.Count;
                    nbreIntrantStockCritique = lstIntrantStockCritique.Count;
                   
                    radDesktopAlert1.ButtonItems.Clear();
                    //Redirectionnement du RadDeskTopAlert
                    //radDesktopAlert1.FixedSize = new System.Drawing.Size(340, 100);
                    //Affichage du message et initialisation de quelques propriétés
                    //DA_Notification.ContentText = "<html><b><span style=\"font-size: 9pt\"> <color=black> Vous avez (<color=red>" + nbreTaches + "<color=black>) tâche(s) en retard.</span></b><b><span style=\"font-size: 9pt\"> <color=black>  Vous avez (<color=red>" + nbreTicketAttente + "<color=black>) ticket(s) en rencontre.</span></b></html>";
                    radDesktopAlert1.CaptionText = "<html><b><span style=\"font-size: 10pt\"><color=black> ATTENTION</span></b></html>";
                    radDesktopAlert1.PopupAnimation = true;
                    radDesktopAlert1.PopupAnimationDirection = RadDirection.Up;
                    radDesktopAlert1.PopupAnimationEasing = RadEasingType.InCubic;
                    //radDesktopAlert1.ContentImage = global::LGT.UI.Properties.Resources.cloche;
                    //DA_Notification.PopupAnimationFrames = 50;
                    radDesktopAlert1.AutoClose = true;
                    radDesktopAlert1.AutoCloseDelay = 15;

                    if (nbreIntrantStockSecurie != 0)
                    {
                        #region bouton N°2
                        //Déclaration d’un bouton 
                        RadButtonElement radButtonElement1 = new RadButtonElement();
                        //Ajout d’une image sur le bouton
                        radButtonElement1.Image = global::LGC.UI.Properties.Resources.print;
                        //Permet de spécifier que l’image est avant le text sur le bouton
                        radButtonElement1.TextImageRelation = TextImageRelation.ImageBeforeText;
                        //Permet d’écrire sur le bouton
                        radButtonElement1.Text = "<html><b><span style=\"font-size: 9pt\"> <color=black> Vous avez (<color=red>" + /*"02"*/nbreIntrantStockSecurie + "<color=black>) intrant(s) qui a(ont) atteint le seuil de sécurité.</span></b></html>";
                        //Permet de définir la couleur d’arrière du bouton
                        radButtonElement1.BackColor = Color.Red;
                        radButtonElement1.Click += new EventHandler(rmi_seuilSecurite_Click);
                        //Ajout du bouton sur le radDeskTopAlert
                        radDesktopAlert1.ButtonItems.Add(radButtonElement1);
                        #endregion
                    }

                    if (nbreIntrantStockCritique != 0)
                    {
                        #region bouton N°2
                        //Déclaration d’un bouton 
                        RadButtonElement radButtonElement2 = new RadButtonElement();
                        //Ajout d’une image sur le bouton
                        radButtonElement2.Image = global::LGC.UI.Properties.Resources.Add;
                        //Permet de spécifier que l’image est avant le text sur le bouton
                        radButtonElement2.TextImageRelation = TextImageRelation.ImageBeforeText;
                        //Permet d’écrire sur le bouton
                        radButtonElement2.Text = "<html><b><span style=\"font-size: 9pt\"> <color=black> Vous avez (<color=red>" + /*"02"*/nbreIntrantStockCritique + "<color=black>) intrant(s) qui a(ont) atteint le seuil critique.</span></b></html>";
                        //Permet de définir la couleur d’arrière du bouton
                        radButtonElement2.BackColor = Color.Red;
                        radButtonElement2.Click += new EventHandler(rmi_seuilCritique_Click);
                        //Ajout du bouton sur le radDeskTopAlert
                        radDesktopAlert1.ButtonItems.Add(radButtonElement2);
                        #endregion
                    }



                   
                    //radDesktopAlert1.ThemeName = global::LGO.UI.Properties.Settings.Default.theme;

                    if (nbreIntrantStockSecurie != 0 || nbreIntrantStockCritique != 0 )
                    {
                        radDesktopAlert1.Show();
                        timerRappel.Start();
                    }

                }
            }
            catch { }
        }
        private void ExecuterListe()
        {
            try
            {
                TacheATraiterAgent = new TacheATraiter(MAJTacheATraiter);
                this.Invoke(TacheATraiterAgent);
            }
            catch { }
        }
        private void Charger()
        {
            try
            {
                th1 = new Thread(ExecuterListe);
                th1.Start();
            }
            catch { }
        }

        private void ExecutionTache()
        {
            try
            {
                #region détermination des valeurs de nbreIntrantStockSecurie, nbreIntrantStockCritique


                lstIntrantStockCritique = lstIntrantStockSecurite = Intrants.Liste(null,false, null, null, null, null, null, null, null, null, null, null, false, null, null);
                if (lstIntrantStockSecurite.Count > 0)
                {
                    lstIntrantStockSecurite = lstIntrantStockSecurite.FindAll(x => x.StockDisponible <= x.StockSecurite &&
                        x.StockDisponible > x.SeuilCritique);
                    lstIntrantStockCritique = lstIntrantStockCritique.FindAll(x => x.StockDisponible <= x.SeuilCritique);
                }
  
            }
            catch { }

            // Affichage de l'alerte TacheATraiterAgent
            // TacheATraiterAgent = new TacheATraiter(MAJTacheATraiter);
            // th = new Thread(afficherDesktopAlerte);
            //afficherDesktopAlerte();

            th = new Thread(Charger);
            th.Start();
            //timerRappel.Start();
                #endregion
        }
        private void ExecuterTimerTick()
        {
            try
            {
                //if (CurrentUser.EstEnCloture == true)
                {

                }
                temps++;
                if (temps % 30 == 0)
                {
                    // timerLabel_Tick(null, null);
                    //tache en attente 
                    th = new Thread(ExecutionTache);
                    th.Start();
                }
            }
            catch { }
        }

        public void AfficherForm(Form f)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == f.GetType())
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    //frm.Select();
                    return;
                }
            }

            f.MdiParent = this;
            f.Show();
            ((RadForm)f).ThemeName = this.ThemeName;
        }
        #endregion

        #region formulaires
        public Frm_Menu()
        {
            InitializeComponent();

            RadGridLocalizationProvider.CurrentProvider =
                new FrenchRadGridLocalizationProvider();
            RadWizardLocalizationProvider.CurrentProvider =
                new RadWizardLocalization();
            //timerRappel.Interval = 3000;
            //timerRappel.Start();
            //timerRappel.Tick += new System.EventHandler(timerRappel_Tick);

            //timerLabel.Interval = 3000;
            //timerLabel.Start();
            //timerLabel.Tick += new System.EventHandler(timerLabel_Tick);
        }

        private void Frm_Menu_Load(object sender, EventArgs e)
        {
            LGC.Business.CurrentUser.ThemeName = this.ThemeName;
            //CurrentUser.ThemeName = this.ThemeName;
            RadMessageBox.ThemeName = this.ThemeName;
            //desctiver tous les menus qui ont de droit
            Outils.DesactiverMenu(this.radMenu11);
            Outils.DesactiverCommandBar(this.commandBarStripElement1);
            rmi_connexionDeconnexion_Click(null, null);
        }
        #endregion

        

        private void rmi_ConnexionOpcvm_Click(object sender, EventArgs e)
        {
            //Frm_ConnexionOpcvm frm = new Frm_ConnexionOpcvm();
            ////frm.Show();
            //AfficherForm(frm);//, "Frm_ConnexionOpcvm");
        }

        private void btn_ActionnairePh_Click(object sender, EventArgs e)
        {
            //Frm_PersonnePhysique frm = new Frm_PersonnePhysique();
            //frm.pv_titres.SelectedPage = frm.pvp_Actionnaire;
            //AfficherForm(frm);//, "Frm_PersonnePhysique");
        }

        private void btn_DirigeantPh_Click(object sender, EventArgs e)
        {
            //Frm_PersonnePhysique frm = new Frm_PersonnePhysique();
            //frm.pv_titres.SelectedPage = frm.pvp_Dirigeant;
            //AfficherForm(frm);//, "Frm_PersonnePhysique");
        }

        private void btn_Commissaire_Click(object sender, EventArgs e)
        {
            //Frm_PersonnePhysique frm = new Frm_PersonnePhysique();
            //frm.pv_titres.SelectedPage = frm.pvp_Commissiaire;
            //AfficherForm(frm);//, "Frm_PersonnePhysique");
        }

        private void btn_Conseil_Click(object sender, EventArgs e)
        {
            //Frm_PersonnePhysique frm = new Frm_PersonnePhysique();
            //frm.pv_titres.SelectedPage = frm.pvp_Conseil;
            //AfficherForm(frm);//, "Frm_PersonnePhysique");
        }

        private void btn_Gestionnaire_Click(object sender, EventArgs e)
        {
            //Frm_PersonnePhysique frm = new Frm_PersonnePhysique();
            //frm.pv_titres.SelectedPage = frm.pvp_gestionnaire;
            //AfficherForm(frm);//, "Frm_PersonnePhysique");
        }

        private void btn_ActionnairePm_Click(object sender, EventArgs e)
        {
            //Frm_Personne frm = new Frm_Personne();
            //frm.pv_titres.SelectedPage = frm.pvp_Actionnaire;
            //AfficherForm(frm);//, "Frm_Personne");
        }

        private void btn_Banque_Click(object sender, EventArgs e)
        {
            //Frm_Personne frm = new Frm_Personne();
            //frm.pv_titres.SelectedPage = frm.pvp_Banque;
            //AfficherForm(frm);//, "Frm_Personne");
        }

        private void btn_Distributeur_Click(object sender, EventArgs e)
        {
            //Frm_Personne frm = new Frm_Personne();
            //frm.pv_titres.SelectedPage = frm.pvp_Distributeur;
            //AfficherForm(frm);//, "Frm_Personne");
        }

        private void rmi_TypeOperation_Click(object sender, EventArgs e)
        {
            //Frm_TypeOperation frm = new Frm_TypeOperation();
            //AfficherForm(frm);//, "Frm_TypeOperation");
        }

        private void rmi_Formule_Click(object sender, EventArgs e)
        {
            //Frm_Formule frm = new Frm_Formule();
            //AfficherForm(frm);//, "Frm_Formule");
        }

        private void rmi_Nature_Click(object sender, EventArgs e)
        {
            //Frm_Nature frm = new Frm_Nature();
            //AfficherForm(frm);//, "Frm_Nature");
        }

        private void rmi_Journal_Click(object sender, EventArgs e)
        {
            //Frm_Journal frm = new Frm_Journal();
            //AfficherForm(frm);//, "Frm_Journal");
        }

        private void rmi_Plan_Click(object sender, EventArgs e)
        {
            //Frm_Plan frm = new Frm_Plan();
            //AfficherForm(frm);//, "Frm_Plan");
        }

        private void rmi_PosteComptable_Click(object sender, EventArgs e)
        {
            //Frm_PosteComptable frm = new Frm_PosteComptable();
            //AfficherForm(frm);//, "Frm_PosteComptable");
        }

        private void rmi_Modele1_Click(object sender, EventArgs e)
        {
            //Frm_Modele1 frm = new Frm_Modele1();
            //AfficherForm(frm);//, "Frm_Modele1");
        }

        private void rmi_ProfilCommission_Click(object sender, EventArgs e)
        {
            //Frm_ProfilCommission frm = new Frm_ProfilCommission();
            //AfficherForm(frm);//, "Frm_ProfilCommission");
        }

        private void rmi_ActionnaireCommission_Click(object sender, EventArgs e)
        {
            //Frm_ActionnaireCommission frm = new Frm_ActionnaireCommission();
            //AfficherForm(frm);//, "Frm_ActionnaireCommission");
        }

        private void rmi_Modele_Click(object sender, EventArgs e)
        {
            //Frm_Modele frm = new Frm_Modele();
            //AfficherForm(frm);//, "Frm_Modele");
        }

        private void btn_Signataire_Click(object sender, EventArgs e)
        {
            //Frm_PersonnePhysique frm = new Frm_PersonnePhysique();
            //frm.pv_titres.SelectedPage = frm.pvp_signataire;
            //AfficherForm(frm);//, "Frm_PersonnePhysique");
        }

        private void rmi_CritereFCPE_Click(object sender, EventArgs e)
        {
            //Frm_CritereFCPE frm = new Frm_CritereFCPE();
            //AfficherForm(frm);//, "Frm_CritereFCPE");
        }

        private void rmi_CriterePlacement_Click(object sender, EventArgs e)
        {
            //Frm_CriterePlacement frm = new Frm_CriterePlacement();
            //AfficherForm(frm);//, "Frm_CriterePlacement");
        }

        private void rmi_CriterePlafond_Click(object sender, EventArgs e)
        {
            //Frm_CriterePlafond frm = new Frm_CriterePlafond();
            //AfficherForm(frm);//, "Frm_CriterePlafond");
        }

        private void rmi_CritereEmetteur_Click(object sender, EventArgs e)
        {
            //Frm_CritereEmetteur frm = new Frm_CritereEmetteur();
            //AfficherForm(frm);//, "Frm_CritereEmetteur");
        }

       

        #region Titres
        #region Paramètres
        private void rmi_Compartiments_Click(object sender, EventArgs e)
        {
            //Frm_Compartiments frm = new Frm_Compartiments();
            //AfficherForm(frm);
        }

        private void rmi_natureEvenement_Click(object sender, EventArgs e)
        {
            //Frm_NatureEvenement frm = new Frm_NatureEvenement();
            //AfficherForm(frm);
        }

        private void rmi_SecteurActivite_Click(object sender, EventArgs e)
        {
            //Frm_SecteurActivite frm = new Frm_SecteurActivite();
            //AfficherForm(frm);
        }

        private void rmi_SousTypeAction_Click(object sender, EventArgs e)
        {
            //Frm_SousTypeAction frm = new Frm_SousTypeAction();
            //AfficherForm(frm);
        }

        private void rmi_TypeAction_Click(object sender, EventArgs e)
        {
            //Frm_TypeAction frm = new Frm_TypeAction();
            //AfficherForm(frm);
        }

        private void rmi_TypeEmetteur_Click(object sender, EventArgs e)
        {
            //Frm_TypeEmetteur frm = new Frm_TypeEmetteur();
            //AfficherForm(frm);
        }

        private void rmi_TypeEmission_Click(object sender, EventArgs e)
        {
            //Frm_TypeEmission frm = new Frm_TypeEmission();
            //AfficherForm(frm);
        }

        private void rmi_TypeEvenement_Click(object sender, EventArgs e)
        {
            //Frm_TypeEvenement frm = new Frm_TypeEvenement();
            //AfficherForm(frm);
        }

        private void rmi_TypeGarant_Click(object sender, EventArgs e)
        {
            //Frm_TypeGarant frm = new Frm_TypeGarant();
            //AfficherForm(frm);
        }

        private void rmi_TypeObligation_Click(object sender, EventArgs e)
        {
            //Frm_TypeObligation frm = new Frm_TypeObligation();
            //AfficherForm(frm);
        }

        private void rmi_Pays_Click(object sender, EventArgs e)
        {
            //Frm_Pays frm = new Frm_Pays();
            //AfficherForm(frm);
        }

        private void rmi_FormeJuridique_Click(object sender, EventArgs e)
        {
            //Frm_FormeJuridique frm = new Frm_FormeJuridique();
            //AfficherForm(frm);
        }
        #endregion 

        #region Menu intervenants
        private void rmi_Depositaire_Click(object sender, EventArgs e)
        {
            //Frm_Depositaire frm = new Frm_Depositaire();
            //AfficherForm(frm);
        }

        private void rmi_Emetteur_Click(object sender, EventArgs e)
        {
            //Frm_Emetteur frm = new Frm_Emetteur();
            //AfficherForm(frm);
        }

        private void rmi_Garant_Click(object sender, EventArgs e)
        {
            //Frm_Garant frm = new Frm_Garant();
            //AfficherForm(frm);
        }

        private void rmi_Organisme_Click(object sender, EventArgs e)
        {
            //Frm_Organisme frm = new Frm_Organisme();
            //AfficherForm(frm);
        }

        private void rmi_PlaceBoursière_Click(object sender, EventArgs e)
        {
            //Frm_Place frm = new Frm_Place();
            //AfficherForm(frm);
        }

        private void rmi_Registraire_Click(object sender, EventArgs e)
        {
            //Frm_Registraire frm = new Frm_Registraire();
            //AfficherForm(frm);
        }
        #endregion

        #region Menu titres
        private void rmi_GestionTitres_Click(object sender, EventArgs e)
        {
            //Frm_Titres frm = new Frm_Titres();
            //AfficherForm(frm);
        }

        private void rmi_majCoursTitres_Click(object sender, EventArgs e)
        {
            //Frm_HistoriqueCours frm = new Frm_HistoriqueCours("");            
            //AfficherForm(frm);
        }

        private void rmi_simulationAchatTitreCreance_Click(object sender, EventArgs e)
        {
            //Frm_SimulationAchatObligation frm = new Frm_SimulationAchatObligation();
            //AfficherForm(frm);
        }
        #endregion

        #region Menu adjudication
        private void rmi_Tcn_Click(object sender, EventArgs e)
        {
            //Frm_Adjudication frm = new Frm_Adjudication("tcn");
            //AfficherForm(frm);
        }

        private void rmi_Obligations_Click(object sender, EventArgs e)
        {
            //Frm_Adjudication frm = new Frm_Adjudication("obligation");
            //AfficherForm(frm);
        }

        private void rmi_rapportAdjudication_Click(object sender, EventArgs e)
        {
            //Frm_Adjudication frm = new Frm_Adjudication("rapport");
            //AfficherForm(frm);
        }

        private void rmi_etatsEtStatistiques_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Etats et statistiques
        private void rmi_TitreAEchInfAUneDate_Click(object sender, EventArgs e)
        {
            //Frm_Etat frm = new Frm_Etat();
            //AfficherForm(frm);
        }

        private void rmi_ListeTitreParClasse_Click(object sender, EventArgs e)
        {
            //Frm_Etat frm = new Frm_Etat();
            //AfficherForm(frm);
        }

        private void rmi_HistoCours_Click(object sender, EventArgs e)
        {
            //Frm_ChoixTitre frm = new Frm_ChoixTitre();
            //AfficherForm(frm);
        }

        private void rmi_EvenementSurUnePeriode_Click(object sender, EventArgs e)
        {
            //Frm_ChoixTitre frm = new Frm_ChoixTitre();
            //AfficherForm(frm);
        }

        private void rmi_RappelEcheance_Click(object sender, EventArgs e)
        {
            //Frm_RappelEcheanceTCNObligation frm = new Frm_RappelEcheanceTCNObligation();
            //AfficherForm(frm);
        }

        private void rmi_CourbeHistoCours_Click(object sender, EventArgs e)
        {
            //Frm_ChoixTitre frm = new Frm_ChoixTitre();
            //AfficherForm(frm);
        }

        private void rmi_MoyenneMobile_Click(object sender, EventArgs e)
        {
            //Frm_ChoixTitre frm = new Frm_ChoixTitre();
            //AfficherForm(frm);
        }
        #endregion
        #endregion

        #region Impressions
        private void rmi_pointTresorerie_Click(object sender, EventArgs e)
        {
            //CR_PointTresorerie rpt = new CR_PointTresorerie();
            //rpt.SetDataSource(EtatStatistiques.PointTresorerie(DateTime.Now.Date));
            //Frm_ReportViewer frm = new Frm_ReportViewer(
            //    "POINT DE LA TRESORERIE DES FONDS", rpt);
            //AfficherForm(frm);

            //TR_PointTresorerie rpt = new TR_PointTresorerie();
            //rpt.objectDataSource1.DataSource = EtatStatistiques.PointTresorerie(DateTime.Now.Date);
            //rpt.DataSource = rpt.objectDataSource1;
            //rpt.txt_NomApplication.Value = CurrentUser.LogicielHote;
            //rpt.titleTextBox.Value = "POINT DE LA TRESORERIE DES FONDS AU " +string.Format("{0:d}", DateTime.Now.Date);
            //Frm_ReportViewer frm = new Frm_ReportViewer("Control Profil Investissement", rpt);
            //frm.MdiParent = Application.OpenForms["Frm_MenuOpcvm"];
            //frm.Show();
        }
        #endregion

        
       
       
        private void rmi_GestionDesUtilisateurs_Click(object sender, EventArgs e)
        {
           
            Frm_UserManager frm = new
             Frm_UserManager(this.ThemeName, this.radMenu11, null, null);
            AfficherForm(frm);
        }

        private void rmi_connexionDeconnexion_Click(object sender, EventArgs e)
        {
            using (Frm_Connexion frm = new Frm_Connexion(this.ThemeName))
            {
                frm.ShowDialog();
                if (frm.connexionReussie)
                {
                    //estConnecte = true;
                    List<ConfigurationUM> lstChemin = new List<ConfigurationUM>();
                    lstChemin = ConfigurationUM.Liste(null, null, null, null, null, null, false, null);
                    if (lstChemin != null && lstChemin.Count != 0)
                    {
                        CurrentUser.ImagePath = lstChemin[0].StrPath;
                    }

                    List<Societe> lstSociete = new List<Societe>();
                    lstSociete = Societe.Liste(null, null,null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                        null,null,null,null,null,null,null,   null,null,null,false, null);
                    if (lstSociete != null && lstSociete.Count != 0)
                    {
                        CurrentUser.OSociete = lstSociete[0];
                    }

                    //vérification pour rappelle de la date d'expiration du logiciel
                    DateTime delai = CurrentUser.DateExpirationLogiciel;
                    if (delai.Date >= DateTime.Now.Date)
                    {
                        CurrentUser.UserLogin = CurrentUser.UserLogin;
                        Outils.DesactiverMenu(this.radMenu11);
                        Outils.DesactiverCommandBar(this.commandBarStripElement1);
                        Outils.activerMenu(this.radMenu11, this.commandBarStripElement1, "g");
                        le_NomUser.Text =
                                CurrentUser.OUtilisateur.NomUtilisateur.Trim() + " " +
                                CurrentUser.OUtilisateur.PrenomUtilisateur.Trim();
                        le_NomServeur.Text = CurrentUser.NomServeurProduction;
                        //affichage de la photo de l'utilisateur
                        string cheminFichier = CurrentUser.ImagePath + "\\" +
                        CurrentUser.OUtilisateur.NomUtilisateur.Trim().Substring(0, 4) +
                      CurrentUser.OUtilisateur.PrenomUtilisateur.Trim().Substring(0, 4) + "(" +
                        CurrentUser.OUtilisateur.NumeroUtilisateur.ToString() + ").jpg";
                        //permet d'afficher la photo
                        if (File.Exists(cheminFichier))
                        {
                            //pnl_photo.BackgroundImage = Image.FromFile(cheminFichier.Trim());
                            //pnl_photo.Visible = true;
                        }
                        else
                        {
                            //pnl_photo.BackgroundImage = null;
                            //pnl_photo.Visible = false;
                        }



                        TimeSpan intervalle = delai.Date - DateTime.Now.Date;
                        if (intervalle.Days <= 14)
                        {
                            //ProfilDroit objPD = CurrentUser.LstDroitReelUser.Find(l =>
                            //        l.ODroit.NomFormulaire.Trim().ToLower() == "frm_securite");
                            //if (objPD != null)
                            //{
                            //da_licence.ThemeName = this.ThemeName;
                            //da_licence.CaptionText = "RAPPEL EXPIRATION DU LOGICIEL";
                            //da_licence.ContentText = "Le logiciel va expirer dans " +
                            //    intervalle.Days.ToString() + "Jours. " +
                            //    "Cliquer sur le bouton corriger pour résoudre le problème.";
                            //da_licence.Show();
                            //}
                        }
                    }
                    else
                    {
                        CurrentUser.LstDroitReelUser =
                            ProfilDroit.DroitReelUtilisateur(
                            CurrentUser.OUtilisateur.NumeroUtilisateur);
                        ProfilDroit objPD = CurrentUser.LstDroitReelUser.Find(l =>
                                    l.ODroit.NomFormulaire.Trim().ToLower() == "frm_securite");
                        if (objPD == null)
                        {
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Seul un administrateur peut se connecter."
                                , CurrentUser.LogicielHote, MessageBoxButtons.OK,
                                RadMessageIcon.Error);
                            CurrentUser.OUtilisateur = null;
                        }
                        else
                        {
                            CurrentUser.UserLogin = CurrentUser.UserLogin;
                            Outils.DesactiverMenu(this.radMenu11);
                            Outils.DesactiverCommandBar(this.commandBarStripElement1);
                            Outils.activerMenu(this.radMenu11, this.commandBarStripElement1, "g");
                            le_NomUser.Text =
                                CurrentUser.OUtilisateur.NomUtilisateur.Trim() + " " +
                                CurrentUser.OUtilisateur.PrenomUtilisateur.Trim();
                        }
                    }
                }
                else
                {

                }
            }
        }

        private void rmi_monnaie_Click(object sender, EventArgs e)
        {
            //Frm_Monnaie frm = new Frm_Monnaie();
            //AfficherForm(frm);
        }

        private void rmi_compartiment_Click(object sender, EventArgs e)
        {
            //Frm_Compartiments frm = new Frm_Compartiments();
            //AfficherForm(frm);
        }

        private void rmi_verrouillerSession_Click(object sender, EventArgs e)
        {
            if (CurrentUser.OUtilisateur != null)
            {
                using (Frm_Connexion frm = new Frm_Connexion("OldCon", this.ThemeName))
                {
                    frm.ShowDialog();
                    if (!frm.connexionReussie)
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Aucun utilisateur n'est connecté."
                    , CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void rmi_changerMotDePasse_Click(object sender, EventArgs e)
        {
            if (CurrentUser.OUtilisateur != null)
            {
                using (Frm_ModifierMotDePasse frm = new Frm_ModifierMotDePasse(this.ThemeName))
                {
                    frm.ShowDialog();
                }
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Aucun utilisateur n'est connecté."
                    , CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void rmi_quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void rmi_configDataBase_Click(object sender, EventArgs e)
        {
            LGC.UI.DataBaseConfig.Frm_ConfigDataBase frm = new LGC.UI.DataBaseConfig.Frm_ConfigDataBase();
            frm.ShowDialog();
        }

        private void rmi_configProfil_Click(object sender, EventArgs e)
        {
            Frm_ConfigCheminProfil frm = new Frm_ConfigCheminProfil(ThemeName);
            AfficherForm(frm);
        }

        
        private void rmi_patient_Click(object sender, EventArgs e)
        {
            Frm_Personne frm = new Frm_Personne();
            frm.pv_titres.SelectedPage = frm.pvp_Patient;
            AfficherForm(frm);
        }

        private void rmi_assurance_Click(object sender, EventArgs e)
        {
            Frm_Personne frm = new Frm_Personne();
            frm.pv_titres.SelectedPage = frm.pvp_Assurance;
            AfficherForm(frm);
        }

        private void rmi_partenairePM_Click(object sender, EventArgs e)
        {
            Frm_Personne frm = new Frm_Personne();
            frm.pv_titres.SelectedPage = frm.pvp_PartenairePM;
            AfficherForm(frm);
        }

        private void rmi_partenairePP_Click(object sender, EventArgs e)
        {
            Frm_Personne frm = new Frm_Personne();
            frm.pv_titres.SelectedPage = frm.pvp_PartenairePP;
            AfficherForm(frm);
        }

        private void rmi_fournisseur_Click(object sender, EventArgs e)
        {
            Frm_Personne frm = new Frm_Personne();
            frm.pv_titres.SelectedPage = frm.pvp_Fournisseur;
            AfficherForm(frm);
        }

        private void rmi_formeJuridique_Click_1(object sender, EventArgs e)
        {
            Frm_FormeJuridique frm = new Frm_FormeJuridique();
            AfficherForm(frm);
        }

        private void rmi_secteurActivite_Click_1(object sender, EventArgs e)
        {
            Frm_SecteurActivite frm = new Frm_SecteurActivite();
            AfficherForm(frm);
        }

        private void rmi_pays_Click_1(object sender, EventArgs e)
        {
            Frm_Pays frm = new Frm_Pays();
            AfficherForm(frm);
        }

        private void rmi_secteursBiologique_Click(object sender, EventArgs e)
        {
            Frm_SecteursBiologique frm = new Frm_SecteursBiologique();
            AfficherForm(frm);
        }

        private void rmi_typePrelevement_Click(object sender, EventArgs e)
        {
            Frm_TypePrelevement frm = new Frm_TypePrelevement();
            AfficherForm(frm);
        }

        private void rmi_trancheAge_Click(object sender, EventArgs e)
        {
            Frm_TrancheAgePatient frm = new Frm_TrancheAgePatient();
            AfficherForm(frm);
        }

        private void rmi_categorieIntrant_Click(object sender, EventArgs e)
        {
            Frm_CategorieIntrant frm = new Frm_CategorieIntrant();
            AfficherForm(frm);
        }

        private void rmi_UniteMesure_Click(object sender, EventArgs e)
        {
            Frm_UniteMesure frm = new Frm_UniteMesure();
            AfficherForm(frm);
        }

        private void rmi_intrant_Click(object sender, EventArgs e)
        {
            Frm_Intrants frm = new Frm_Intrants();
            AfficherForm(frm);
        }

        private void rmi_codeBarre_Click(object sender, EventArgs e)
        {
            Frm_ParamCodeBarre frm = new Frm_ParamCodeBarre(ThemeName);
            AfficherForm(frm);
        }

        private void rmi_laboratoire_Click(object sender, EventArgs e)
        {
            Frm_Societe frm = new Frm_Societe();
            AfficherForm(frm);
        }

        private void rmi_MAJAnalyse_Click(object sender, EventArgs e)
        {
            Frm_Analyse frm = new Frm_Analyse();
            AfficherForm(frm);
        }

        private void rmi_CmdFrs_Click(object sender, EventArgs e)
        {
            Frm_CommandeFrs frm = new Frm_CommandeFrs();
            AfficherForm(frm);
        }

        private void rmi_LivraisonFournisseur_Click(object sender, EventArgs e)
        {
            Frm_Livraison frm = new Frm_Livraison();
            AfficherForm(frm);
        }

        private void rmi_Entre_Click(object sender, EventArgs e)
        {
            Frm_EntreSortieStock frm = new Frm_EntreSortieStock();
            frm.pv_titres.SelectedPage = frm.pvp_Entre;
            AfficherForm(frm);
        }

        private void rmi_Sortie_Click(object sender, EventArgs e)
        {
            Frm_EntreSortieStock frm = new Frm_EntreSortieStock();
            frm.pv_titres.SelectedPage = frm.pvp_Sortie;
            AfficherForm(frm);
        }

        private void rmi_SaisieDemandes_Click(object sender, EventArgs e)
        {
            Frm_DemandeAnalyse frm = new Frm_DemandeAnalyse();           
            AfficherForm(frm);
        }

        private void rmi_RegClient_Click(object sender, EventArgs e)
        {
            Frm_ReglementClient frm = new Frm_ReglementClient(false);
            AfficherForm(frm);
        }

        private void rmi_FactureAssurance_Click(object sender, EventArgs e)
        {
            Frm_FactureAssurance frm = new Frm_FactureAssurance();
            AfficherForm(frm);
        }

        private void rmi_FacturePartenaire_Click(object sender, EventArgs e)
        {
            Frm_FacturePartenaire frm = new Frm_FacturePartenaire();
            AfficherForm(frm);
        }

        private void rmi_RegAssurance_Click(object sender, EventArgs e)
        {
            Frm_ReglementAssurance frm = new Frm_ReglementAssurance();
            AfficherForm(frm);
        }

        private void rmi_RegPartenaires_Click(object sender, EventArgs e)
        {
            Frm_ReglementPartenaire frm = new Frm_ReglementPartenaire();
            AfficherForm(frm);
        }

        private void rmi_ResultatAnalyse_Click(object sender, EventArgs e)
        {
            Frm_ResultatDemande frm = new Frm_ResultatDemande();
            AfficherForm(frm);
        }

        private void rmi_VerificationTechnique_Click(object sender, EventArgs e)
        {
            Frm_VerificationResultat frm = new Frm_VerificationResultat();
            AfficherForm(frm);
        }

        private void rmi_VerificationBiologique_Click(object sender, EventArgs e)
        {
            Frm_VerificationResultat frm = new Frm_VerificationResultat();
            AfficherForm(frm);
        }

        private void rmi_Ristourne_Click(object sender, EventArgs e)
        {
            Frm_PaiementRistournes frm = new Frm_PaiementRistournes();
            AfficherForm(frm);
        }

        private void rmi_Prelevement_Click(object sender, EventArgs e)
        {
            Frm_PrelevementAnalyseDemande frm = new Frm_PrelevementAnalyseDemande();
            AfficherForm(frm);
        }

        private void rmi_Destockage_Click(object sender, EventArgs e)
        {
            //Frm_DestockageAnalyse frm = new Frm_DestockageAnalyse();
            //AfficherForm(frm);
        }

        private void rmi_miseAJourTypeTube_Click(object sender, EventArgs e)
        {
            Frm_TypeTube frm = new Frm_TypeTube();
            AfficherForm(frm);
        }

        private void rmi_ExcesQtePrevue_Click(object sender, EventArgs e)
        {
            Frm_EntreSortieStock frm = new Frm_EntreSortieStock();
            frm.pv_titres.SelectedPage = frm.pvp_Exces;
            AfficherForm(frm);
        }

        private void timerRappel_Tick(object sender, EventArgs e)
        {
            try
            {
                th = new Thread(ExecuterTimerTick);
                th.Start();
            }
            catch { }
        }

        private void rmi_ResultatAnalyseDemande_Click(object sender, EventArgs e)
        {
            Frm_ResultatDemandeImp frm = new Frm_ResultatDemandeImp();
            AfficherForm(frm);
            
        }

        private void rmi_EntreeDeCaisse_Click(object sender, EventArgs e)
        {
            Frm_AutreEntreSortie frm = new Frm_AutreEntreSortie("ENTREE");
            AfficherForm(frm);
        }

        private void rmi_SortieDeCaisse_Click(object sender, EventArgs e)
        {
            Frm_AutreEntreSortie frm = new Frm_AutreEntreSortie("SORTIE");
            AfficherForm(frm);
        }

        private void rmi_stockIntrant_Click(object sender, EventArgs e)
        {
            Frm_StockIntrant frm = new Frm_StockIntrant();
            AfficherForm(frm);
        }

        private void rmi_autreParametrageAnalyse_Click(object sender, EventArgs e)
        {
            Frm_ParametrageInterpretationParametre frm = new Frm_ParametrageInterpretationParametre();
            AfficherForm(frm);
        }

        private void rmi_StatCaisse_Click(object sender, EventArgs e)
        {
            Frm_StatistiquesCaisse frm = new Frm_StatistiquesCaisse();
            AfficherForm(frm);
        }

        private void rmi_AnnulationDemande_Click(object sender, EventArgs e)
        {
            Frm_AnnulationDemandes frm = new Frm_AnnulationDemandes();
            AfficherForm(frm);
        }

        private void rmi_inventaire_Click(object sender, EventArgs e)
        {
           
            Frm_Inventaire frm = new Frm_Inventaire();
            AfficherForm(frm);
        }

        private void rmi_typeInventaire_Click(object sender, EventArgs e)
        {
            Frm_TypeInventaire frm = new Frm_TypeInventaire();
            AfficherForm(frm);
        }

        private void timerLabel_Tick(object sender, EventArgs e)
        {
            try
            {
                List<Inventaire> oInventaire = Inventaire.Liste(null, null, null, null, "EN COURS", null, null, null, null, null,
                false, null);

                if (oInventaire != null && oInventaire.Count >  0)
                {
                    lbl_Inventaire.Visible = true;
                    this.radCommandBar1.Enabled = false;
                    foreach (RadMenuItem unMenu in this.radMenu11.Items)
                    {
                        if (unMenu.Text.Trim() != "GESTION DE STOCK" )
                        {
                            unMenu.Enabled = false;
                        }
                        else
                        {
                            foreach (RadMenuItem unSousMenu in this.rmi_GestionStock.Items)
                            {
                                if (unSousMenu.Text.Trim() != "Inventaire")
                                {
                                    unSousMenu.Enabled = false;
                                }
                            }
                        }
                    }
                    CurrentUser.EstEnCloture = true;
                    #region Bloquer l'accès a la vérification des jeux d'ecritures dans le menu comptabilité
                    //Outils.MenuBycodeDroit(this.radMenu1, "g", "163;164", true);
                    #endregion

                    //if (lbl_Cloture.Visible == false)
                    //    lbl_Cloture.Visible = true;
                    //else
                    //    lbl_Cloture.Visible = false;

                }
                else
                {
                    this.radCommandBar1.Enabled = true;
                    foreach (RadMenuItem unMenu in this.radMenu11.Items)
                    {
                        if (unMenu.Text.Trim() == "GESTION DE STOCK")
                        {
                            foreach (RadMenuItem unSousMenu in unMenu.Items)
                            {
                                if (unSousMenu.Text.Trim() != "Inventaire")
                                {
                                    unSousMenu.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            unMenu.Enabled = true;
                        }
                    }
                    if (lbl_Inventaire.Visible == true)
                        lbl_Inventaire.Visible = false;
                    CurrentUser.EstEnCloture = false;
                    #region Bloquer l'accès a la vérification des jeux d'ecritures dans le menu comptabilité
                    //Outils.MenuBycodeDroit(this.radMenu1, "g", "163;164", false);
                    #endregion
                }   
                       
                    
            }
            catch { }
        }

        private void rmi_seuilSecurite_Click(object sender, EventArgs e)
        {
            Frm_AlerteIntrant frm = new Frm_AlerteIntrant("SECURITE");
            AfficherForm(frm);
            
        }

        private void rmi_seuilCritique_Click(object sender, EventArgs e)
        {
            Frm_AlerteIntrant frm = new Frm_AlerteIntrant("CRITIQUE");
            AfficherForm(frm);
        }

        private void rmi_FactureFournisseur_Click(object sender, EventArgs e)
        {
            Frm_FactureFournisseur frm = new Frm_FactureFournisseur();
            AfficherForm(frm);
        }

        private void rmi_RegFournisseurs_Click(object sender, EventArgs e)
        {
            Frm_ReglementFournisseur frm = new Frm_ReglementFournisseur();
            AfficherForm(frm);
        }

        private void rmi_TypeCoffret_Click(object sender, EventArgs e)
        {
            Frm_TypeCoffret frm = new Frm_TypeCoffret();
            AfficherForm(frm);
        }

        private void rmi_ModelResultat_Click(object sender, EventArgs e)
        {
            Frm_ModeleResultat frm = new Frm_ModeleResultat();
            AfficherForm(frm);
        }

        private void rmi_Antibiotiques_Click(object sender, EventArgs e)
        {
            Frm_Antibiotiques frm = new Frm_Antibiotiques();
            AfficherForm(frm);
        }

        private void rmi_ModelAnalyseDem_Click(object sender, EventArgs e)
        {
            Frm_ModeleDemandeAnalyse frm = new Frm_ModeleDemandeAnalyse();
            AfficherForm(frm);
        }

        private void rmi_PointPeriodique_Click(object sender, EventArgs e)
        {
            Frm_PointPeriodique frm = new Frm_PointPeriodique();
            AfficherForm(frm);
        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Fichiers bak(*.bak)|*.bak";
             
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Securite.BackupDatabase(dialog.FileName);
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Sauvegarde effectuée avec succès",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                }


            }
            catch (Exception ex)
            {
                RadMessageBox.Show(this, ex.Message,
                   CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        private void rmi_RestoreDB_Click(object sender, EventArgs e)
        {
            Frm_RestoreDB frm = new Frm_RestoreDB(ThemeName);
            AfficherForm(frm);
        }

        private void rmi_ConfigRestorDB_Click(object sender, EventArgs e)
        {
            Frm_ConfigSaveRestoreDB frm = new Frm_ConfigSaveRestoreDB(ThemeName);
            AfficherForm(frm);
        }

        private void rmi_StatPatientPartenaires_Click(object sender, EventArgs e)
        {
            Frm_ListePatientsByPartenaire frm = new Frm_ListePatientsByPartenaire(ThemeName);
            AfficherForm(frm);
        }

        private void rmi_AnalyseParSecteur_Click(object sender, EventArgs e)
        {
            Frm_ListeAnalyseParSecteur frm = new Frm_ListeAnalyseParSecteur(ThemeName);
            AfficherForm(frm);
        }

        private void rmi_PointEncais_Click(object sender, EventArgs e)
        {
            Frm_PointEncaissement frm = new Frm_PointEncaissement(ThemeName);
            AfficherForm(frm);
        }

        private void rmi_PointFactNormalisees_Click(object sender, EventArgs e)
        {
            Frm_PointFactureNormalisee frm = new Frm_PointFactureNormalisee(ThemeName);
            AfficherForm(frm);
        }

        private void rmi_PointAnalyseAssur_Click(object sender, EventArgs e)
        {
            Frm_PointAnalyseQteMt frm = new Frm_PointAnalyseQteMt(ThemeName);
            AfficherForm(frm);
        }

        private void rmi_EtatRecapAvecCentres_DoubleClick(object sender, EventArgs e)
        {

        }

        private void rmi_EtatRecapAvecCentres_Click(object sender, EventArgs e)
        {
            Frm_EtatRecapPrestationsCentre frm = new Frm_EtatRecapPrestationsCentre(ThemeName, "PRESTATION");
            AfficherForm(frm);
        }

        private void radMenuItem3_Click_1(object sender, EventArgs e)
        {
            Frm_EtatRecapPrestationsCentre frm = new Frm_EtatRecapPrestationsCentre(ThemeName,"CREANCE");
            AfficherForm(frm);
        }

        private void rmi_PointRistournes_Click(object sender, EventArgs e)
        {
            Frm_EtatRecapPrestationsCentre frm = new Frm_EtatRecapPrestationsCentre(ThemeName, "RISTOURNE");
            AfficherForm(frm);
        }

        private void rmi_RecalculDemande_Click(object sender, EventArgs e)
        {
            Frm_RecalculDemande frm = new Frm_RecalculDemande(ThemeName);
            AfficherForm(frm);
        }

        private void rmi_AutrePartenaire_Click(object sender, EventArgs e)
        {
            Frm_FactureAutrePartenaire frm = new Frm_FactureAutrePartenaire(ThemeName);
            AfficherForm(frm);
        }

        private void rmi_PointDemandeAnnulees_Click(object sender, EventArgs e)
        {
            Frm_PointFactureAnnulees_Clt frm = new Frm_PointFactureAnnulees_Clt(ThemeName);
            AfficherForm(frm);
        }

        private void rmi_PartenairePrevisu_Click(object sender, EventArgs e)
        {
            Frm_FacturePartenaireVisualiser frm = new Frm_FacturePartenaireVisualiser(ThemeName);
            AfficherForm(frm);
        }

        private void rmi_PointFactPartAnnulees_Click(object sender, EventArgs e)
        {
            Frm_PointFactureAnnulees_Part frm = new Frm_PointFactureAnnulees_Part(ThemeName);
            AfficherForm(frm);
        }
    
	}
}

    