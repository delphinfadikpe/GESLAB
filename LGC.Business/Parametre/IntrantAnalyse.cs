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
    public class IntrantAnalyse
    {
        #region Constructeurs
        public IntrantAnalyse()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeIntrant;
        private string codeAnalyse;
        private Decimal quantiteMin;
        private Decimal quantiteMax;
        private string libelleIntrant;

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
        public string CodeIntrant
        {
            get { return codeIntrant.Trim(); }
            set { codeIntrant = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodeAnalyse
        {
            get { return codeAnalyse.Trim(); }
            set { codeAnalyse = value; }
        }


        public string LibelleIntrant
        {
            get { return libelleIntrant; }
            set { libelleIntrant = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Decimal QuantiteMin
        {
            get { return quantiteMin; }
            set { quantiteMin = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal QuantiteMax
        {
            get { return quantiteMax; }
            set { quantiteMax = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de IntrantAnalyse
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de IntrantAnalyse
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de IntrantAnalyse
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de IntrantAnalyse
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de IntrantAnalyse
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de IntrantAnalyse
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de IntrantAnalyse
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
        private static TJ_IntrantAnalyseTableAdapter adapIntrantAnalyse = new TJ_IntrantAnalyseTableAdapter();
        private static ParametreDataSet1.TJ_IntrantAnalyseDataTable dtIntrantAnalyse = new ParametreDataSet1.TJ_IntrantAnalyseDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de IntrantAnalyse
        /// </summary>
        /// <returns> </returns>
        /// 
        public static void Delete_All(string mCodeAnalyse)
        {
         
            adapIntrantAnalyse.PS_IntrantAnalyse_DP_ALL(
                mCodeAnalyse);
           
        }
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantAnalyse.PS_IntrantAnalyse_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de IntrantAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantAnalyse.PS_IntrantAnalyse_IP(
                codeIntrant,
                codeAnalyse,
                quantiteMin,
                QuantiteMax,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de IntrantAnalyse
        /// </summary>
        /// <param name="codeIntrant"></param>
        /// <param name="codeAnalyse"></param>
        /// <param name="quantiteMin"></param>
        /// <param name="QuantiteMax"></param>
        /// <param name="numLigne">Le Numéro de Ligne de IntrantAnalyse</param>
        /// <param name="dateCreationServeur">La date de création de IntrantAnalyse</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de IntrantAnalyse</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de IntrantAnalyse</param>
        /// <param name="userLogin">Le User Login de IntrantAnalyse</param>
        /// <param name="supprimer">Supprimer de IntrantAnalyse</param>
        /// <param name="rowvers">Version de ligne de IntrantAnalyse</param>
        /// <returns>Liste IntrantAnalyse</returns>
        public static List<IntrantAnalyse> Liste(
             string mCodeIntrant,
            string mLibelleIntrant,
             string mCodeAnalyse,
             Decimal? mQuantiteMin,
             Decimal? mQuantiteMax,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtIntrantAnalyse = adapIntrantAnalyse.PS_IntrantAnalyse_SP(
                mCodeIntrant,
                mLibelleIntrant,
                mCodeAnalyse,
                mQuantiteMin,
                mQuantiteMax,
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
        /// Retourne la liste des IntrantAnalyse
        /// </summary>
        /// <returns>Liste IntrantAnalyse</returns>
        private static List<IntrantAnalyse> pListe()
        {
            List<IntrantAnalyse> mListe = new List<IntrantAnalyse>();
            foreach (ParametreDataSet1.TJ_IntrantAnalyseRow mLigne in dtIntrantAnalyse)
            {
                IntrantAnalyse oIntrantAnalyse = new IntrantAnalyse();
                oIntrantAnalyse.CodeIntrant = mLigne.codeIntrant.Trim();
                oIntrantAnalyse.LibelleIntrant = mLigne.libelleIntrant.Trim();
                oIntrantAnalyse.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oIntrantAnalyse.QuantiteMin = mLigne.quantiteMin;
                oIntrantAnalyse.QuantiteMax = mLigne.QuantiteMax;
                oIntrantAnalyse.NumLigne = mLigne.numLigne;
                oIntrantAnalyse.DateCreationServeur = mLigne.dateCreationServeur;
                oIntrantAnalyse.DateDernModifClient = mLigne.dateDernModifClient;
                oIntrantAnalyse.DateDernModifServeur = mLigne.dateDernModifServeur;
                oIntrantAnalyse.UserLogin = mLigne.userLogin.Trim();
                oIntrantAnalyse.Supprimer = mLigne.supprimer;
                oIntrantAnalyse.Rowvers = mLigne.rowvers;

                mListe.Add(oIntrantAnalyse);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de IntrantAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantAnalyse.PS_IntrantAnalyse_UP(
                codeIntrant,
                codeAnalyse,
                quantiteMin,
                QuantiteMax,
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

