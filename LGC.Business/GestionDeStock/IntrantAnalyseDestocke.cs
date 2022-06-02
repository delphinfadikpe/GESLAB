using LGC.DataAccess.GestionDeStock;
using LGC.DataAccess.GestionDeStock.GestionDeStockDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGC.Business.GestionDeStock
{
    /// <summary>
    /// 
    /// </summary>
    public class IntrantAnalyseDestocke
    {
        #region Constructeurs
        public IntrantAnalyseDestocke()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeIntrant;
        private Decimal idDestockage;
        private string codeAnalyse;
        private Decimal numDemande;
        private Decimal qteDesctocke;
        private string libelleIntrant;
        private string libelleAnalyse;

      
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

        public string LibelleIntrant
        {
            get { return libelleIntrant; }
            set { libelleIntrant = value; }
        }


        public string LibelleAnalyse
        {
            get { return libelleAnalyse; }
            set { libelleAnalyse = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CodeIntrant
        {
            get { return codeIntrant.Trim(); }
            set { codeIntrant = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal IdDestockage
        {
            get { return idDestockage; }
            set { idDestockage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodeAnalyse
        {
            get { return codeAnalyse.Trim(); }
            set { codeAnalyse = value; }
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
        public Decimal QteDesctocke
        {
            get { return qteDesctocke; }
            set { qteDesctocke = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de IntrantAnalyseDestocke
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de IntrantAnalyseDestocke
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de IntrantAnalyseDestocke
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de IntrantAnalyseDestocke
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de IntrantAnalyseDestocke
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de IntrantAnalyseDestocke
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de IntrantAnalyseDestocke
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
        private static TJ_IntrantAnalyseDestockeTableAdapter adapIntrantAnalyseDestocke = new TJ_IntrantAnalyseDestockeTableAdapter();
        private static GestionDeStockDataSet.TJ_IntrantAnalyseDestockeDataTable dtIntrantAnalyseDestocke = new GestionDeStockDataSet.TJ_IntrantAnalyseDestockeDataTable();
        string mSortie = string.Empty;

        private static FT_IntrantAnalyseDemandeTableAdapter adapFTIntrantAnalyseDemande = new FT_IntrantAnalyseDemandeTableAdapter();
        private static GestionDeStockDataSet.FT_IntrantAnalyseDemandeDataTable dtFTIntrantAnalyseDemande = new GestionDeStockDataSet.FT_IntrantAnalyseDemandeDataTable();
        #endregion Variables

        #region Méthodes
        #region Interfaces
        public static DataTable IntrantAnalyse(decimal mNumDemande)
        {
            dtFTIntrantAnalyseDemande = adapFTIntrantAnalyseDemande.GetData(mNumDemande);
            return dtFTIntrantAnalyseDemande;
        }
        /// <summary>
        /// Permet la suppression de IntrantAnalyseDestocke
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantAnalyseDestocke.PS_IntrantAnalyseDestocke_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de IntrantAnalyseDestocke
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantAnalyseDestocke.PS_IntrantAnalyseDestocke_IP(
                codeIntrant,
                idDestockage,
                codeAnalyse,
                numDemande,
                qteDesctocke,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de IntrantAnalyseDestocke
        /// </summary>
        /// <param name="codeIntrant"></param>
        /// <param name="idDestockage"></param>
        /// <param name="codeAnalyse"></param>
        /// <param name="numDemande"></param>
        /// <param name="qteDesctocke"></param>
        /// <param name="numLigne">Le Numéro de Ligne de IntrantAnalyseDestocke</param>
        /// <param name="dateCreationServeur">La date de création de IntrantAnalyseDestocke</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de IntrantAnalyseDestocke</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de IntrantAnalyseDestocke</param>
        /// <param name="userLogin">Le User Login de IntrantAnalyseDestocke</param>
        /// <param name="supprimer">Supprimer de IntrantAnalyseDestocke</param>
        /// <param name="rowvers">Version de ligne de IntrantAnalyseDestocke</param>
        /// <returns>Liste IntrantAnalyseDestocke</returns>
        public static List<IntrantAnalyseDestocke> Liste(
             string mCodeIntrant,
             Decimal? mIdDestockage,
             string mCodeAnalyse,
             Decimal? mNumDemande,
             Decimal? mQteDesctocke,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtIntrantAnalyseDestocke = adapIntrantAnalyseDestocke.PS_IntrantAnalyseDestocke_SP(
                mCodeIntrant,
                mIdDestockage,
                mCodeAnalyse,
                mNumDemande,
                mQteDesctocke,
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
        /// Retourne la liste des IntrantAnalyseDestocke
        /// </summary>
        /// <returns>Liste IntrantAnalyseDestocke</returns>
        private static List<IntrantAnalyseDestocke> pListe()
        {
            List<IntrantAnalyseDestocke> mListe = new List<IntrantAnalyseDestocke>();
            foreach (GestionDeStockDataSet.TJ_IntrantAnalyseDestockeRow mLigne in dtIntrantAnalyseDestocke)
            {
                IntrantAnalyseDestocke oIntrantAnalyseDestocke = new IntrantAnalyseDestocke();
                oIntrantAnalyseDestocke.CodeIntrant = mLigne.codeIntrant.Trim();
                oIntrantAnalyseDestocke.IdDestockage = mLigne.idDestockage;
                oIntrantAnalyseDestocke.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oIntrantAnalyseDestocke.NumDemande = mLigne.numDemande;
                oIntrantAnalyseDestocke.QteDesctocke = mLigne.qteDesctocke;
                oIntrantAnalyseDestocke.NumLigne = mLigne.numLigne;
                oIntrantAnalyseDestocke.DateCreationServeur = mLigne.dateCreationServeur;
                oIntrantAnalyseDestocke.DateDernModifClient = mLigne.dateDernModifClient;
                oIntrantAnalyseDestocke.DateDernModifServeur = mLigne.dateDernModifServeur;
                oIntrantAnalyseDestocke.UserLogin = mLigne.userLogin.Trim();
                oIntrantAnalyseDestocke.Supprimer = mLigne.supprimer;
                oIntrantAnalyseDestocke.Rowvers = mLigne.rowvers;
                oIntrantAnalyseDestocke.LibelleAnalyse = mLigne.libelleAnalyse;
                oIntrantAnalyseDestocke.LibelleIntrant = mLigne.libelleIntrant;
                mListe.Add(oIntrantAnalyseDestocke);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de IntrantAnalyseDestocke
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantAnalyseDestocke.PS_IntrantAnalyseDestocke_UP(
                codeIntrant,
                idDestockage,
                codeAnalyse,
                numDemande,
                qteDesctocke,
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
