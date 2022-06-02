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
    public class InrantSortieStock
    {
        #region Constructeurs
        public InrantSortieStock()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeIntrant;
        private Decimal numEntreSortie;
        private Decimal qteEntreSortie;
        private string motifEntreSortie;
        private string intrant;

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

        public string Intrant
        {
            get { return intrant; }
            set { intrant = value; }
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
        public Decimal NumEntreSortie
        {
            get { return numEntreSortie; }
            set { numEntreSortie = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal QteEntreSortie
        {
            get { return qteEntreSortie; }
            set { qteEntreSortie = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MotifEntreSortie
        {
            get { return motifEntreSortie.Trim(); }
            set { motifEntreSortie = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de InrantSortieStock
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de InrantSortieStock
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de InrantSortieStock
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de InrantSortieStock
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de InrantSortieStock
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de InrantSortieStock
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de InrantSortieStock
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
        private static TJ_InrantSortieStockTableAdapter adapInrantSortieStock = new TJ_InrantSortieStockTableAdapter();
        private static GestionDeStockDataSet.TJ_InrantSortieStockDataTable dtInrantSortieStock = new GestionDeStockDataSet.TJ_InrantSortieStockDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de InrantSortieStock
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapInrantSortieStock.PS_InrantSortieStock_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de InrantSortieStock
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapInrantSortieStock.PS_InrantSortieStock_IP(
                codeIntrant,
                numEntreSortie,
                qteEntreSortie,
                motifEntreSortie,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de InrantSortieStock
        /// </summary>
        /// <param name="codeIntrant"></param>
        /// <param name="numEntreSortie"></param>
        /// <param name="qteEntreSortie"></param>
        /// <param name="motifEntreSortie"></param>
        /// <param name="numLigne">Le Numéro de Ligne de InrantSortieStock</param>
        /// <param name="dateCreationServeur">La date de création de InrantSortieStock</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de InrantSortieStock</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de InrantSortieStock</param>
        /// <param name="userLogin">Le User Login de InrantSortieStock</param>
        /// <param name="supprimer">Supprimer de InrantSortieStock</param>
        /// <param name="rowvers">Version de ligne de InrantSortieStock</param>
        /// <returns>Liste InrantSortieStock</returns>
        public static List<InrantSortieStock> Liste(
             string mCodeIntrant,
             Decimal? mNumEntreSortie,
             Decimal? mQteEntreSortie,
             string mMotifEntreSortie,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtInrantSortieStock = adapInrantSortieStock.PS_InrantSortieStock_SP(
                mCodeIntrant,
                mNumEntreSortie,
                mQteEntreSortie,
                mMotifEntreSortie,
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
        /// Retourne la liste des InrantSortieStock
        /// </summary>
        /// <returns>Liste InrantSortieStock</returns>
        private static List<InrantSortieStock> pListe()
        {
            List<InrantSortieStock> mListe = new List<InrantSortieStock>();
            foreach (GestionDeStockDataSet.TJ_InrantSortieStockRow mLigne in dtInrantSortieStock)
            {
                InrantSortieStock oInrantSortieStock = new InrantSortieStock();
                oInrantSortieStock.CodeIntrant = mLigne.codeIntrant.Trim();
                oInrantSortieStock.NumEntreSortie = mLigne.numEntreSortie;
                oInrantSortieStock.QteEntreSortie = mLigne.qteEntreSortie;
                oInrantSortieStock.MotifEntreSortie = mLigne.motifEntreSortie.Trim();
                oInrantSortieStock.NumLigne = mLigne.numLigne;
                oInrantSortieStock.DateCreationServeur = mLigne.dateCreationServeur;
                oInrantSortieStock.DateDernModifClient = mLigne.dateDernModifClient;
                oInrantSortieStock.DateDernModifServeur = mLigne.dateDernModifServeur;
                oInrantSortieStock.UserLogin = mLigne.userLogin.Trim();
                oInrantSortieStock.Supprimer = mLigne.supprimer;
                oInrantSortieStock.Rowvers = mLigne.rowvers;
                oInrantSortieStock.Intrant = mLigne.Intrant.Trim();

                mListe.Add(oInrantSortieStock);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de InrantSortieStock
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapInrantSortieStock.PS_InrantSortieStock_UP(
                codeIntrant,
                numEntreSortie,
                qteEntreSortie,
                motifEntreSortie,
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
