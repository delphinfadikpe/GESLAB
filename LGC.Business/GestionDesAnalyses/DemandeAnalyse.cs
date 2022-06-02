using LGC.DataAccess.GestionDesAnalyses.GestionDesAnalysesDataSetTableAdapters;
using LGC.DataAccess.GestionDesAnalyses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace LGC.Business.GestionDesAnalyses
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    public class DemandeAnalyse
    {
        #region Constructeurs
        public DemandeAnalyse()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal numDemande;
        private Decimal idPersonne;
        private Decimal idPersonnePartenaire;
        private Decimal idPersonneAssurance;
        private DateTime dateDemande;
        private DateTime dateSortiResultatPrevu;
        private bool estRecommande;
        private bool estAssure;
        private Decimal tauxCouverture;
        private Decimal remise;
        private bool estAnnulee;
        private DateTime dateAnnulation;
        private string motifAnnulation;
        private string niveauExecution;
        private bool estSurComptePartenaire;
        private Decimal montantDemande;
        private string statutReglement;
        private Decimal reste;
        private Decimal montantBrut;
        private string patient;
        private string partenaire;
        private string assurance;
        private string numPolice;
        private bool valideParAssurance;
        private bool estRetenuAlaSource;
        private decimal tauxRetenue;
        private decimal montantRetenue;
        private string beneficiaire;
        private decimal numLigneFact;
        private string reference;
        private string sigFV;
        private string nimFV;
        private string sigFA;
        private string nimFA;

       
        
      

      
       
       
        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private DateTime dateCreationServeur;
        private DateTime dateDernModifClient;
        private DateTime dateDernModifServeur;
        private string userLogin;
        private bool supprimer;
        private Byte[] rowvers;
        #endregion Passe partout
        #endregion Elémentaires

        #region Objets

        #endregion Objets

        #region Collections

        #endregion Collections
        #endregion Champs

        #region Propriétés
        #region Elémentaires
        #region Propres

        public decimal NumLigneFact
        {
            get { return numLigneFact; }
            set { numLigneFact = value; }
        }
       

        public string Beneficiaire
        {
            get { return beneficiaire; }
            set { beneficiaire = value; }
        }

        public bool EstRetenuAlaSource
        {
            get { return estRetenuAlaSource; }
            set { estRetenuAlaSource = value; }
        }


        public decimal TauxRetenue
        {
            get { return tauxRetenue; }
            set { tauxRetenue = value; }
        }


        public decimal MontantRetenue
        {
            get { return montantRetenue; }
            set { montantRetenue = value; }
        }
       

        public string NumPolice
        {
            get { return numPolice; }
            set { numPolice = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal NumDemande
        {
            get { return numDemande; }
            set { numDemande = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal IdPersonne
        {
            get { return idPersonne; }
            set { idPersonne = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal IdPersonnePartenaire
        {
            get { return idPersonnePartenaire; }
            set { idPersonnePartenaire = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal IdPersonneAssurance
        {
            get { return idPersonneAssurance; }
            set { idPersonneAssurance = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateDemande
        {
            get { return dateDemande; }
            set { dateDemande = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateSortiResultatPrevu
        {
            get { return dateSortiResultatPrevu; }
            set { dateSortiResultatPrevu = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstRecommande
        {
            get { return estRecommande; }
            set { estRecommande = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstAssure
        {
            get { return estAssure; }
            set { estAssure = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal TauxCouverture
        {
            get { return tauxCouverture; }
            set { tauxCouverture = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Remise
        {
            get { return remise; }
            set { remise = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstAnnulee
        {
            get { return estAnnulee; }
            set { estAnnulee = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateAnnulation
        {
            get { return dateAnnulation; }
            set { dateAnnulation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MotifAnnulation
        {
            get { return motifAnnulation.Trim(); }
            set { motifAnnulation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NiveauExecution
        {
            get { return niveauExecution.Trim(); }
            set { niveauExecution = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstSurComptePartenaire
        {
            get { return estSurComptePartenaire; }
            set { estSurComptePartenaire = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantDemande
        {
            get { return montantDemande; }
            set { montantDemande = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string StatutReglement
        {
            get { return statutReglement.Trim(); }
            set { statutReglement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Reste
        {
            get { return reste; }
            set { reste = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantBrut
        {
            get { return montantBrut; }
            set { montantBrut = value; }
        }

        public string Patient
        {
            get { return patient; }
            set { patient = value; }
        }


        public string Partenaire
        {
            get { return partenaire; }
            set { partenaire = value; }
        }


        public string Assurance
        {
            get { return assurance; }
            set { assurance = value; }
        }

        public bool ValideParAssurance
        {
            get { return valideParAssurance; }
            set { valideParAssurance = value; }
        }

        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        public string NimFA
        {
            get { return nimFA; }
            set { nimFA = value; }
        }
        public string SigFA
        {
            get { return sigFA; }
            set { sigFA = value; }
        }

        public string NimFV
        {
            get { return nimFV; }
            set { nimFV = value; }
        }

        public string SigFV
        {
            get { return sigFV; }
            set { sigFV = value; }
        }
        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de DemandeAnalyse
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de DemandeAnalyse
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de DemandeAnalyse
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de DemandeAnalyse
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de DemandeAnalyse
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de DemandeAnalyse
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de DemandeAnalyse
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        #endregion Passe partout
        #endregion Elémentaires

        #region Objets

        #endregion Objets

        #region Collections

        #endregion Collections
        #endregion Propriétés

        #region Variables
        private static T_DemandeAnalyseTableAdapter adapDemandeAnalyse = new T_DemandeAnalyseTableAdapter();
        private static GestionDesAnalysesDataSet.T_DemandeAnalyseDataTable dtDemandeAnalyse = new GestionDesAnalysesDataSet.T_DemandeAnalyseDataTable();
        private static PS_DemandeAnalyse_SP1TableAdapter adapDemandeAnalyse_SP1 = new PS_DemandeAnalyse_SP1TableAdapter();
        private static GestionDesAnalysesDataSet.PS_DemandeAnalyse_SP1DataTable dtDemandeAnalyse_SP1 = new GestionDesAnalysesDataSet.PS_DemandeAnalyse_SP1DataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de DemandeAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapDemandeAnalyse.PS_DemandeAnalyse_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de DemandeAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapDemandeAnalyse.PS_DemandeAnalyse_IP(
                numDemande,
                idPersonne,
                idPersonnePartenaire,
                idPersonneAssurance,
                dateDemande,
                dateSortiResultatPrevu,
                estRecommande,
                estAssure,
                tauxCouverture,
                Remise,
                estAnnulee,
                dateAnnulation,
                motifAnnulation,
                niveauExecution,
                estSurComptePartenaire,
                montantDemande,
                statutReglement,
                reste,
                montantBrut,NumPolice   ,estRetenuAlaSource,tauxRetenue,montantRetenue,beneficiaire,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de DemandeAnalyse
        /// </summary>
        /// <param name="numDemande"></param>
        /// <param name="idPersonne"></param>
        /// <param name="idPersonnePartenaire"></param>
        /// <param name="idPersonneAssurance"></param>
        /// <param name="dateDemande"></param>
        /// <param name="dateSortiResultatPrevu"></param>
        /// <param name="estRecommande"></param>
        /// <param name="estAssure"></param>
        /// <param name="tauxCouverture"></param>
        /// <param name="Remise"></param>
        /// <param name="estAnnulee"></param>
        /// <param name="dateAnnulation"></param>
        /// <param name="motifAnnulation"></param>
        /// <param name="niveauExecution"></param>
        /// <param name="estSurComptePartenaire"></param>
        /// <param name="montantDemande"></param>
        /// <param name="statutReglement"></param>
        /// <param name="reste"></param>
        /// <param name="montantBrut"></param>
        /// <param name="numLigne">Le Numéro de Ligne de DemandeAnalyse</param>
        /// <param name="dateCreationServeur">La date de création de DemandeAnalyse</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de DemandeAnalyse</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de DemandeAnalyse</param>
        /// <param name="userLogin">Le User Login de DemandeAnalyse</param>
        /// <param name="supprimer">Supprimer de DemandeAnalyse</param>
        /// <param name="rowvers">Version de ligne de DemandeAnalyse</param>
        /// <returns>Liste DemandeAnalyse</returns>
        public static List<DemandeAnalyse> Liste(
             Decimal? mNumDemande,
             Decimal? mIdPersonne,
             Decimal? mIdPersonnePartenaire,
             Decimal? mIdPersonneAssurance,
             DateTime? mDateDemande,
             DateTime? mDateSortiResultatPrevu,
             bool? mEstRecommande,
             bool? mEstAssure,
             Decimal? mTauxCouverture,
             Decimal? mRemise,
             bool? mEstAnnulee,
             DateTime? mDateAnnulation,
             string mMotifAnnulation,
             string mNiveauExecution,
             bool? mEstSurComptePartenaire,
             Decimal? mMontantDemande,
             string mStatutReglement,
             Decimal? mReste,
             Decimal? mMontantBrut,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtDemandeAnalyse = adapDemandeAnalyse.PS_DemandeAnalyse_SP(
                mNumDemande,
                mIdPersonne,
                mIdPersonnePartenaire,
                mIdPersonneAssurance,
                mDateDemande,
                mDateSortiResultatPrevu,
                mEstRecommande,
                mEstAssure,
                mTauxCouverture,
                mRemise,
                mEstAnnulee,
                mDateAnnulation,
                mMotifAnnulation,
                mNiveauExecution,
                mEstSurComptePartenaire,
                mMontantDemande,
                mStatutReglement,
                mReste,
                mMontantBrut,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mUserLogin,
                mSupprimer,
                mRowvers);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des DemandeAnalyse
        /// </summary>
        /// <returns>Liste DemandeAnalyse</returns>
        private static List<DemandeAnalyse> pListe()
        {
            List<DemandeAnalyse> mListe = new List<DemandeAnalyse>();
            foreach (GestionDesAnalysesDataSet.T_DemandeAnalyseRow mLigne in dtDemandeAnalyse)
            {
                DemandeAnalyse oDemandeAnalyse = new DemandeAnalyse();
                oDemandeAnalyse.NumDemande = mLigne.numDemande;
                oDemandeAnalyse.IdPersonne = mLigne.idPersonne;
                oDemandeAnalyse.IdPersonnePartenaire = mLigne.idPersonnePartenaire;
                oDemandeAnalyse.IdPersonneAssurance = mLigne.idPersonneAssurance;
                oDemandeAnalyse.DateDemande = mLigne.dateDemande;
                oDemandeAnalyse.DateSortiResultatPrevu = mLigne.dateSortiResultatPrevu;
                oDemandeAnalyse.EstRecommande = mLigne.estRecommande;
                oDemandeAnalyse.EstAssure = mLigne.estAssure;
                oDemandeAnalyse.TauxCouverture = mLigne.tauxCouverture;
                oDemandeAnalyse.Remise = mLigne.Remise;
                oDemandeAnalyse.EstAnnulee = mLigne.estAnnulee;
                oDemandeAnalyse.DateAnnulation = mLigne.dateAnnulation;
                oDemandeAnalyse.MotifAnnulation = mLigne.motifAnnulation.Trim();
                oDemandeAnalyse.NiveauExecution = mLigne.niveauExecution.Trim();
                oDemandeAnalyse.EstSurComptePartenaire = mLigne.estSurComptePartenaire;
                oDemandeAnalyse.MontantDemande = mLigne.montantDemande;
                oDemandeAnalyse.StatutReglement = mLigne.statutReglement.Trim();
                oDemandeAnalyse.Reste = mLigne.reste;
                oDemandeAnalyse.MontantBrut = mLigne.montantBrut;
                oDemandeAnalyse.NumLigne = mLigne.numLigne;
                oDemandeAnalyse.DateCreationServeur = mLigne.dateCreationServeur;
                oDemandeAnalyse.DateDernModifClient = mLigne.dateDernModifClient;
                oDemandeAnalyse.DateDernModifServeur = mLigne.dateDernModifServeur;
                oDemandeAnalyse.UserLogin = mLigne.userLogin.Trim();
                oDemandeAnalyse.Supprimer = mLigne.supprimer;
                oDemandeAnalyse.Rowvers = mLigne.rowvers;
                oDemandeAnalyse.Patient = mLigne.patient;
                oDemandeAnalyse.Partenaire = mLigne.partenaire;
                oDemandeAnalyse.Assurance = mLigne.assurance;
                oDemandeAnalyse.NumPolice = mLigne.numPolice;
                oDemandeAnalyse.ValideParAssurance = mLigne.valideParAssurance;
                oDemandeAnalyse.EstRetenuAlaSource = mLigne.estRetenuAlaSource;
                oDemandeAnalyse.TauxRetenue = mLigne.tauxRetenue;   
                oDemandeAnalyse.MontantRetenue = mLigne.montantRetenue;
                oDemandeAnalyse.Beneficiaire = mLigne.beneficiaire;
                try
                {
                    oDemandeAnalyse.NumLigneFact = mLigne.numLigneFact;
                }
                catch { }
               
                mListe.Add(oDemandeAnalyse);
            }
            return mListe;
        }

        public static List<DemandeAnalyse> Liste(DateTime? mDateDebut,DateTime? mdateFin)
        {
            adapDemandeAnalyse_SP1.ComTimeout = 0;
            dtDemandeAnalyse_SP1 = adapDemandeAnalyse_SP1.GetData(mDateDebut, mdateFin);
            List<DemandeAnalyse> mListe = new List<DemandeAnalyse>();
            foreach (GestionDesAnalysesDataSet.PS_DemandeAnalyse_SP1Row mLigne in dtDemandeAnalyse_SP1)
            {
                DemandeAnalyse oDemandeAnalyse = new DemandeAnalyse();
                oDemandeAnalyse.NumDemande = mLigne.numDemande;
                oDemandeAnalyse.IdPersonne = mLigne.idPersonne;
                oDemandeAnalyse.IdPersonnePartenaire = mLigne.idPersonnePartenaire;
                oDemandeAnalyse.IdPersonneAssurance = mLigne.idPersonneAssurance;
                oDemandeAnalyse.DateDemande = mLigne.dateDemande;
                oDemandeAnalyse.DateSortiResultatPrevu = mLigne.dateSortiResultatPrevu;
                oDemandeAnalyse.EstRecommande = mLigne.estRecommande;
                oDemandeAnalyse.EstAssure = mLigne.estAssure;
                oDemandeAnalyse.TauxCouverture = mLigne.tauxCouverture;
                oDemandeAnalyse.Remise = mLigne.Remise;
                oDemandeAnalyse.EstAnnulee = mLigne.estAnnulee;
                oDemandeAnalyse.DateAnnulation = mLigne.dateAnnulation;
                oDemandeAnalyse.MotifAnnulation = mLigne.motifAnnulation.Trim();
                oDemandeAnalyse.NiveauExecution = mLigne.niveauExecution.Trim();
                oDemandeAnalyse.EstSurComptePartenaire = mLigne.estSurComptePartenaire;
                oDemandeAnalyse.MontantDemande = mLigne.montantDemande;
                oDemandeAnalyse.StatutReglement = mLigne.statutReglement.Trim();
                oDemandeAnalyse.Reste = mLigne.reste;
                oDemandeAnalyse.MontantBrut = mLigne.montantBrut;
                oDemandeAnalyse.NumLigne = mLigne.numLigne;
                oDemandeAnalyse.DateCreationServeur = mLigne.dateCreationServeur;
                oDemandeAnalyse.DateDernModifClient = mLigne.dateDernModifClient;
                oDemandeAnalyse.DateDernModifServeur = mLigne.dateDernModifServeur;
                oDemandeAnalyse.UserLogin = mLigne.userLogin.Trim();
                oDemandeAnalyse.Supprimer = mLigne.supprimer;
                oDemandeAnalyse.Rowvers = mLigne.rowvers;
                oDemandeAnalyse.Patient = mLigne.patient;
                oDemandeAnalyse.Partenaire = mLigne.partenaire;
                oDemandeAnalyse.Assurance = mLigne.assurance;
                oDemandeAnalyse.NumPolice = mLigne.numPolice;
                oDemandeAnalyse.ValideParAssurance = mLigne.valideParAssurance;
                oDemandeAnalyse.EstRetenuAlaSource = mLigne.estRetenuAlaSource;
                oDemandeAnalyse.TauxRetenue = mLigne.tauxRetenue;
                oDemandeAnalyse.MontantRetenue = mLigne.montantRetenue;
                oDemandeAnalyse.Beneficiaire = mLigne.beneficiaire;
                try
                {
                    oDemandeAnalyse.NumLigneFact = mLigne.numLigneFact;
                }
                catch { }
                try
                {
                    oDemandeAnalyse.Reference = mLigne.reference;
                }
                catch { }

                try
                {
                    oDemandeAnalyse.SigFV = mLigne.sigFV;
                }
                catch { }
                try
                {
                    oDemandeAnalyse.NimFV = mLigne.nimFV;
                }
                catch { }
                try
                {
                    oDemandeAnalyse.SigFA = mLigne.sigFA;
                }
                catch { }
                try
                {
                    oDemandeAnalyse.NimFA = mLigne.nimFA;
                }
                catch { }
                mListe.Add(oDemandeAnalyse);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de DemandeAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapDemandeAnalyse.PS_DemandeAnalyse_UP(
                numDemande,
                idPersonne,
                idPersonnePartenaire,
                idPersonneAssurance,
                dateDemande,
                dateSortiResultatPrevu,
                estRecommande,
                estAssure,
                tauxCouverture,
                Remise,
                estAnnulee,
                dateAnnulation,
                motifAnnulation,
                niveauExecution,
                estSurComptePartenaire,
                montantDemande,
                statutReglement,
                reste,
                montantBrut,NumPolice,valideParAssurance,estRetenuAlaSource,tauxRetenue,montantRetenue,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }


        public static void RecalculDemande(string mNumDemande)
        {
            adapDemandeAnalyse.PS_RecalculDemande(mNumDemande, CurrentUser.UserLogin);
        }

        #endregion Interfaces

        #region Gestion des collections

        #endregion Gestion des collections

        #region Métier

        #endregion Métier
        #endregion Méthodes
    }

}
