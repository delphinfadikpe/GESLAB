using LGC.DataAccess.GestionDesAnalyses;
using LGC.DataAccess.GestionDesAnalyses.GestionDesAnalysesDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGC.Business.GestionDesAnalyses
{
    /// <summary>
    /// 
    /// </summary>
    public class ResultatDemande
    {
        #region Constructeurs
        public ResultatDemande()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idResultatDemande;
        private Decimal numDemande;
        private bool estVerifie1;
        private DateTime dateVerification1;
        private bool estVerifie2;
        private DateTime dateVerification2;
        private DateTime dateOperation;
        private bool estTransmi;
        private string conclusion;
        private string statut;
        private string patient;
        private DateTime dateDemande;
        private string logo;

        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }


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

        public string Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        public DateTime DateDemande
        {
            get { return dateDemande; }
            set { dateDemande = value; }
        }

        public string Statut
        {
            get { return statut; }
            set { statut = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Decimal IdResultatDemande
        {
            get { return idResultatDemande; }
            set { idResultatDemande = value; }
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
        public bool EstVerifie1
        {
            get { return estVerifie1; }
            set { estVerifie1 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateVerification1
        {
            get { return dateVerification1; }
            set { dateVerification1 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstVerifie2
        {
            get { return estVerifie2; }
            set { estVerifie2 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateVerification2
        {
            get { return dateVerification2; }
            set { dateVerification2 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateOperation
        {
            get { return dateOperation; }
            set { dateOperation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstTransmi
        {
            get { return estTransmi; }
            set { estTransmi = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Conclusion
        {
            get { return conclusion.Trim(); }
            set { conclusion = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de ResultatDemande
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de ResultatDemande
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de ResultatDemande
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de ResultatDemande
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de ResultatDemande
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de ResultatDemande
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de ResultatDemande
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
        private static T_ResultatDemandeTableAdapter adapResultatDemande = new T_ResultatDemandeTableAdapter();
        private static FT_ParametreAnalyseDemandeTableAdapter adapParametreAnalyseDemande = new FT_ParametreAnalyseDemandeTableAdapter();
        private static GestionDesAnalysesDataSet.T_ResultatDemandeDataTable dtResultatDemande = new GestionDesAnalysesDataSet.T_ResultatDemandeDataTable();
        private static GestionDesAnalysesDataSet.FT_ParametreAnalyseDemandeDataTable dtParametreAnalyseDemande = new GestionDesAnalysesDataSet.FT_ParametreAnalyseDemandeDataTable();
        string mSortie = string.Empty;
        private static FT_ResultatDemandeAnalyseTableAdapter adapFTResultatDemandeAnalyse = new FT_ResultatDemandeAnalyseTableAdapter();
        private static GestionDesAnalysesDataSet.FT_ResultatDemandeAnalyseDataTable dtFTResultatDemandeAnalyse = new GestionDesAnalysesDataSet.FT_ResultatDemandeAnalyseDataTable();
        #endregion Variables

        #region Méthodes
        #region Interfaces
        public static DataTable ResultatDemandeFonction(decimal mNumDemande)
        {
            dtFTResultatDemandeAnalyse = adapFTResultatDemandeAnalyse.GetData(mNumDemande);
            return dtFTResultatDemandeAnalyse;
        }
        public static DataTable ParametreAnalyseDemande(decimal mNumDemande)
        {
            dtParametreAnalyseDemande = adapParametreAnalyseDemande.GetData(mNumDemande);
            return dtParametreAnalyseDemande;
        }
        /// <summary>
        /// Permet la suppression de ResultatDemande
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapResultatDemande.PS_ResultatDemande_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de ResultatDemande
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapResultatDemande.PS_ResultatDemande_IP(
                idResultatDemande,
                numDemande,
                estVerifie1,
                dateVerification1,
                estVerifie2,
                dateVerification2,
                dateOperation,
                estTransmi,
                statut,
                conclusion,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de ResultatDemande
        /// </summary>
        /// <param name="idResultatDemande"></param>
        /// <param name="numDemande"></param>
        /// <param name="estVerifie1"></param>
        /// <param name="dateVerification1"></param>
        /// <param name="estVerifie2"></param>
        /// <param name="dateVerification2"></param>
        /// <param name="dateOperation"></param>
        /// <param name="estTransmi"></param>
        /// <param name="conclusion"></param>
        /// <param name="numLigne">Le Numéro de Ligne de ResultatDemande</param>
        /// <param name="dateCreationServeur">La date de création de ResultatDemande</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de ResultatDemande</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ResultatDemande</param>
        /// <param name="userLogin">Le User Login de ResultatDemande</param>
        /// <param name="supprimer">Supprimer de ResultatDemande</param>
        /// <param name="rowvers">Version de ligne de ResultatDemande</param>
        /// <returns>Liste ResultatDemande</returns>
        public static List<ResultatDemande> Liste(
             Decimal? mIdResultatDemande,
             Decimal? mNumDemande,
             bool? mEstVerifie1,
             DateTime? mDateVerification1,
             bool? mEstVerifie2,
             DateTime? mDateVerification2,
             DateTime? mDateOperation,
             bool? mEstTransmi,
            string mStatut,
             string mConclusion,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtResultatDemande = adapResultatDemande.PS_ResultatDemande_SP(
                mIdResultatDemande,
                mNumDemande,
                mEstVerifie1,
                mDateVerification1,
                mEstVerifie2,
                mDateVerification2,
                mDateOperation,
                mEstTransmi,
                mStatut,
                mConclusion,
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
        /// Retourne la liste des ResultatDemande
        /// </summary>
        /// <returns>Liste ResultatDemande</returns>
        private static List<ResultatDemande> pListe()
        {
            List<ResultatDemande> mListe = new List<ResultatDemande>();
            foreach (GestionDesAnalysesDataSet.T_ResultatDemandeRow mLigne in dtResultatDemande)
            {
                ResultatDemande oResultatDemande = new ResultatDemande();
                oResultatDemande.IdResultatDemande = mLigne.idResultatDemande;
                oResultatDemande.NumDemande = mLigne.numDemande;
                try
                {
                    oResultatDemande.Logo = mLigne.Logo.Trim();
                }catch
                {}
                oResultatDemande.EstVerifie1 = mLigne.estVerifie1;
                oResultatDemande.DateVerification1 = mLigne.dateVerification1;
                oResultatDemande.EstVerifie2 = mLigne.estVerifie2;
                oResultatDemande.Statut = mLigne.statut;
                oResultatDemande.DateVerification2 = mLigne.dateVerification2;
                oResultatDemande.DateOperation = mLigne.dateOperation;
                oResultatDemande.EstTransmi = mLigne.estTransmi;
                oResultatDemande.Conclusion = mLigne.conclusion.Trim();
                oResultatDemande.NumLigne = mLigne.numLigne;
                oResultatDemande.DateCreationServeur = mLigne.dateCreationServeur;
                oResultatDemande.DateDernModifClient = mLigne.dateDernModifClient;
                oResultatDemande.DateDernModifServeur = mLigne.dateDernModifServeur;
                oResultatDemande.UserLogin = mLigne.userLogin.Trim();
                oResultatDemande.Supprimer = mLigne.supprimer;
                oResultatDemande.Rowvers = mLigne.rowvers;
                oResultatDemande.Patient = mLigne.patient.Trim();
                oResultatDemande.DateDemande = mLigne.dateDemande;
                mListe.Add(oResultatDemande);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de ResultatDemande
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapResultatDemande.PS_ResultatDemande_UP(
                idResultatDemande,
                numDemande,
                estVerifie1,
                dateVerification1,
                estVerifie2,
                dateVerification2,
                dateOperation,
                estTransmi,
                statut,
                conclusion,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }


        #endregion Interfaces

        #region Gestion des collections

        #endregion Gestion des collections

        #region Métier

        #endregion Métier
        #endregion Méthodes
    }
}

