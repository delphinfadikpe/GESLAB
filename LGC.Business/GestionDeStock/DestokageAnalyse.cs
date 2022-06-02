
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
    public class DestokageAnalyse
    {
        #region Constructeurs
        public DestokageAnalyse()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idDestockage;
        private DateTime dateDestockage;
        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private DateTime dateCreationServeur;
        private DateTime dateDernModifClient;
        private DateTime dateDernModifServeur;
        private Byte[] rowvers;
        private bool supprimer;
        private string userLogin;
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
        public Decimal IdDestockage
        {
            get { return idDestockage; }
            set { idDestockage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateDestockage
        {
            get { return dateDestockage; }
            set { dateDestockage = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de DestokageAnalyse
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de DestokageAnalyse
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de DestokageAnalyse
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de DestokageAnalyse
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Version de ligne de DestokageAnalyse
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// Supprimer de DestokageAnalyse
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de DestokageAnalyse
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        #endregion Passe partout
        #endregion Elémentaires

        #region Objets

        #endregion Objets

        #region Collections

        #endregion Collections
        #endregion Propriétés

        #region Variables
        private static T_DestokageAnalyseTableAdapter adapDestokageAnalyse = new T_DestokageAnalyseTableAdapter();
        private static GestionDeStockDataSet.T_DestokageAnalyseDataTable dtDestokageAnalyse = new GestionDeStockDataSet.T_DestokageAnalyseDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de DestokageAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapDestokageAnalyse.PS_DestokageAnalyse_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de DestokageAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapDestokageAnalyse.PS_DestokageAnalyse_IP(
                idDestockage,
                dateDestockage,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de DestokageAnalyse
        /// </summary>
        /// <param name="idDestockage"></param>
        /// <param name="dateDestockage"></param>
        /// <param name="numLigne">Le Numéro de Ligne de DestokageAnalyse</param>
        /// <param name="dateCreationServeur">La date de création de DestokageAnalyse</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de DestokageAnalyse</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de DestokageAnalyse</param>
        /// <param name="rowvers">Version de ligne de DestokageAnalyse</param>
        /// <param name="supprimer">Supprimer de DestokageAnalyse</param>
        /// <param name="userLogin">Le User Login de DestokageAnalyse</param>
        /// <returns>Liste DestokageAnalyse</returns>
        public static List<DestokageAnalyse> Liste(
             Decimal? mIdDestockage,
             DateTime? mDateDestockage,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             Byte[] mRowvers,
             bool? mSupprimer,
             string mUserLogin)
        {
            dtDestokageAnalyse = adapDestokageAnalyse.PS_DestokageAnalyse_SP(
                mIdDestockage,
                mDateDestockage,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mRowvers,
                mSupprimer,
                mUserLogin);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des DestokageAnalyse
        /// </summary>
        /// <returns>Liste DestokageAnalyse</returns>
        private static List<DestokageAnalyse> pListe()
        {
            List<DestokageAnalyse> mListe = new List<DestokageAnalyse>();
            foreach (GestionDeStockDataSet.T_DestokageAnalyseRow mLigne in dtDestokageAnalyse)
            {
                DestokageAnalyse oDestokageAnalyse = new DestokageAnalyse();
                oDestokageAnalyse.IdDestockage = mLigne.idDestockage;
                oDestokageAnalyse.DateDestockage = mLigne.dateDestockage;
                oDestokageAnalyse.NumLigne = mLigne.numLigne;
                oDestokageAnalyse.DateCreationServeur = mLigne.dateCreationServeur;
                oDestokageAnalyse.DateDernModifClient = mLigne.dateDernModifClient;
                oDestokageAnalyse.DateDernModifServeur = mLigne.dateDernModifServeur;
                oDestokageAnalyse.Rowvers = mLigne.rowvers;
                oDestokageAnalyse.Supprimer = mLigne.supprimer;
                oDestokageAnalyse.UserLogin = mLigne.userLogin.Trim();
               
                mListe.Add(oDestokageAnalyse);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de DestokageAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapDestokageAnalyse.PS_DestokageAnalyse_UP(
                idDestockage,
                dateDestockage,
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
