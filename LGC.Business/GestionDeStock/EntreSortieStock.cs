using LGC.DataAccess.GestionDeStock;
using LGC.DataAccess.GestionDeStock.GestionDeStockDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGC.Business.GestionDeStock
{
    /// <summary>
    /// 
    /// </summary>
    public class EntreSortieStock
    {
        #region Constructeurs
        public EntreSortieStock()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal numEntreSortie;
        private DateTime dateEntreSortie;
        private string typeOperation;
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
        /// <summary>
        /// 
        /// </summary>
        public Decimal NumEntreSortie
        {
            get { return numEntreSortie; }
            set { numEntreSortie = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateEntreSortie
        {
            get { return dateEntreSortie; }
            set { dateEntreSortie = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TypeOperation
        {
            get { return typeOperation.Trim(); }
            set { typeOperation = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de EntreSortieStock
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de EntreSortieStock
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de EntreSortieStock
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de EntreSortieStock
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de EntreSortieStock
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de EntreSortieStock
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de EntreSortieStock
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
        private static T_EntreSortieStockTableAdapter adapEntreSortieStock = new T_EntreSortieStockTableAdapter();
        private static GestionDeStockDataSet.T_EntreSortieStockDataTable dtEntreSortieStock = new GestionDeStockDataSet.T_EntreSortieStockDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de EntreSortieStock
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapEntreSortieStock.PS_EntreSortieStock_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de EntreSortieStock
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapEntreSortieStock.PS_EntreSortieStock_IP(
                numEntreSortie,
                dateEntreSortie,
                typeOperation,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de EntreSortieStock
        /// </summary>
        /// <param name="numEntreSortie"></param>
        /// <param name="dateEntreSortie"></param>
        /// <param name="typeOperation"></param>
        /// <param name="numLigne">Le Numéro de Ligne de EntreSortieStock</param>
        /// <param name="dateCreationServeur">La date de création de EntreSortieStock</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de EntreSortieStock</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de EntreSortieStock</param>
        /// <param name="userLogin">Le User Login de EntreSortieStock</param>
        /// <param name="supprimer">Supprimer de EntreSortieStock</param>
        /// <param name="rowvers">Version de ligne de EntreSortieStock</param>
        /// <returns>Liste EntreSortieStock</returns>
        public static List<EntreSortieStock> Liste(
             Decimal? mNumEntreSortie,
             DateTime? mDateEntreSortie,
             string mTypeOperation,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtEntreSortieStock = adapEntreSortieStock.PS_EntreSortieStock_SP(
                mNumEntreSortie,
                mDateEntreSortie,
                mTypeOperation,
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
        /// Retourne la liste des EntreSortieStock
        /// </summary>
        /// <returns>Liste EntreSortieStock</returns>
        private static List<EntreSortieStock> pListe()
        {
            List<EntreSortieStock> mListe = new List<EntreSortieStock>();
            foreach (GestionDeStockDataSet.T_EntreSortieStockRow mLigne in dtEntreSortieStock)
            {
                EntreSortieStock oEntreSortieStock = new EntreSortieStock();
                oEntreSortieStock.NumEntreSortie = mLigne.numEntreSortie;
                oEntreSortieStock.DateEntreSortie = mLigne.dateEntreSortie;
                oEntreSortieStock.TypeOperation = mLigne.typeOperation.Trim();
                oEntreSortieStock.NumLigne = mLigne.numLigne;
                oEntreSortieStock.DateCreationServeur = mLigne.dateCreationServeur;
                oEntreSortieStock.DateDernModifClient = mLigne.dateDernModifClient;
                oEntreSortieStock.DateDernModifServeur = mLigne.dateDernModifServeur;
                oEntreSortieStock.UserLogin = mLigne.userLogin.Trim();
                oEntreSortieStock.Supprimer = mLigne.supprimer;
                oEntreSortieStock.Rowvers = mLigne.rowvers;

                mListe.Add(oEntreSortieStock);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de EntreSortieStock
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapEntreSortieStock.PS_EntreSortieStock_UP(
                numEntreSortie,
                dateEntreSortie,
                typeOperation,
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

