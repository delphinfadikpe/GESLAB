using LGC.DataAccess.Parametre;
using LGC.DataAccess.Parametre.ParametreDataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGC.Business.Parametre
{
    /// <summary>
    /// 
    /// </summary>
    public class Intrants
    {
        #region Constructeurs
        public Intrants()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeIntrant;
        private string codeCategorie;
        private string code;
        private string libelleIntrant;
        private Decimal stockSecurite;
        private Decimal seuilCritique;
        private bool? estArreteAlerte;

        public bool? EstArreteAlerte
        {
            get { return estArreteAlerte; }
            set { estArreteAlerte = value; }
        }
        private bool? alerteArrete;

        public bool? AlerteArrete
        {
            get { return alerteArrete; }
            set { alerteArrete = value; }
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
        private Decimal stockDisponible;
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
        public string CodeIntrant
        {
            get { return codeIntrant.Trim(); }
            set { codeIntrant = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodeCategorie
        {
            get { return codeCategorie.Trim(); }
            set { codeCategorie = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            get { return code.Trim(); }
            set { code = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibelleIntrant
        {
            get { return libelleIntrant.Trim(); }
            set { libelleIntrant = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal StockSecurite
        {
            get { return stockSecurite; }
            set { stockSecurite = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal SeuilCritique
        {
            get { return seuilCritique; }
            set { seuilCritique = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Intrants
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Intrants
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Intrants
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Intrants
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Intrants
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Intrants
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Intrants
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal StockDisponible
        {
            get { return stockDisponible; }
            set { stockDisponible = value; }
        }

        #endregion Passe partout
        #endregion Elémentaires

        #region Objets

        #endregion Objets

        #region Collections

        #endregion Collections
        #endregion Propriétés

        #region Variables
        private static T_IntrantsTableAdapter adapIntrants = new T_IntrantsTableAdapter();
        private static ParametreDataSet1.T_IntrantsDataTable dtIntrants = new ParametreDataSet1.T_IntrantsDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Intrants
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrants.PS_Intrants_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Intrants
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrants.PS_Intrants_IP(
                codeIntrant,
                codeCategorie,
                code,
                libelleIntrant,
                stockSecurite,
                seuilCritique,
                stockDisponible,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Intrants
        /// </summary>
        /// <param name="codeIntrant"></param>
        /// <param name="codeCategorie"></param>
        /// <param name="code"></param>
        /// <param name="libelleIntrant"></param>
        /// <param name="stockSecurite"></param>
        /// <param name="seuilCritique"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Intrants</param>
        /// <param name="dateCreationServeur">La date de création de Intrants</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Intrants</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Intrants</param>
        /// <param name="userLogin">Le User Login de Intrants</param>
        /// <param name="supprimer">Supprimer de Intrants</param>
        /// <param name="rowvers">Version de ligne de Intrants</param>
        /// <param name="stockDisponible"></param>
        /// <returns>Liste Intrants</returns>
        public static List<Intrants> Liste(
             string mCodeIntrant,
            bool? mAlerteArrete,
             string mCodeCategorie,
             string mCode,
             string mLibelleIntrant,
             Decimal? mStockSecurite,
             Decimal? mSeuilCritique,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers,
             Decimal? mStockDisponible)
        {
            dtIntrants = adapIntrants.PS_Intrants_SP(
                mCodeIntrant,
                mAlerteArrete,
                mCodeCategorie,
                mCode,
                mLibelleIntrant,
                mStockSecurite,
                mSeuilCritique,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mUserLogin,
                mSupprimer,
                mRowvers,
                mStockDisponible);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des Intrants
        /// </summary>
        /// <returns>Liste Intrants</returns>
        private static List<Intrants> pListe()
        {
            List<Intrants> mListe = new List<Intrants>();
            foreach (ParametreDataSet1.T_IntrantsRow mLigne in dtIntrants)
            {
                Intrants oIntrants = new Intrants();
                oIntrants.CodeIntrant = mLigne.codeIntrant.Trim();
                oIntrants.CodeCategorie = mLigne.codeCategorie.Trim();
                oIntrants.Code = mLigne.code.Trim();
                oIntrants.LibelleIntrant = mLigne.libelleIntrant.Trim();
                oIntrants.StockSecurite = mLigne.stockSecurite;
                oIntrants.SeuilCritique = mLigne.seuilCritique;
                oIntrants.NumLigne = mLigne.numLigne;
                oIntrants.DateCreationServeur = mLigne.dateCreationServeur;
                oIntrants.DateDernModifClient = mLigne.dateDernModifClient;
                oIntrants.DateDernModifServeur = mLigne.dateDernModifServeur;
                oIntrants.UserLogin = mLigne.userLogin.Trim();
                oIntrants.Supprimer = mLigne.supprimer;
                oIntrants.Rowvers = mLigne.rowvers;
                oIntrants.StockDisponible = mLigne.stockDisponible;
                oIntrants.AlerteArrete = mLigne.alerteArrete;

                mListe.Add(oIntrants);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Intrants
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrants.PS_Intrants_UP(
                codeIntrant,
                estArreteAlerte,
                codeCategorie,
                code,
                libelleIntrant,
                stockSecurite,
                seuilCritique,
                stockDisponible,
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

