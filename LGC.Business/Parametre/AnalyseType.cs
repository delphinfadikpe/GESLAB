using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGC.DataAccess.Parametre;
using LGC.DataAccess.Parametre.ParametreDataSet2TableAdapters;


namespace LGC.Business.Parametre
{
    /// <summary>
    /// 
    /// </summary>
    public class AnalyseType
    {
        #region Constructeurs
        public AnalyseType()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeAnalyse;
        private string type;
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

        public string LibelleAnalyse
        {
            get { return libelleAnalyse; }
            set { libelleAnalyse = value; }
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
        public string Type
        {
            get { return type.Trim(); }
            set { type = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de AnalyseType
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de AnalyseType
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de AnalyseType
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de AnalyseType
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de AnalyseType
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de AnalyseType
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de AnalyseType
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
        private static T_AnalyseTypeTableAdapter adapAnalyseType = new T_AnalyseTypeTableAdapter();
        private static ParametreDataSet2.T_AnalyseTypeDataTable dtAnalyseType = new ParametreDataSet2.T_AnalyseTypeDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de AnalyseType
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalyseType.PS_AnalyseType_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de AnalyseType
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalyseType.PS_AnalyseType_IP(
                codeAnalyse,
                type,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de AnalyseType
        /// </summary>
        /// <param name="codeAnalyse"></param>
        /// <param name="type"></param>
        /// <param name="numLigne">Le Numéro de Ligne de AnalyseType</param>
        /// <param name="dateCreationServeur">La date de création de AnalyseType</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de AnalyseType</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de AnalyseType</param>
        /// <param name="userLogin">Le User Login de AnalyseType</param>
        /// <param name="supprimer">Supprimer de AnalyseType</param>
        /// <param name="rowvers">Version de ligne de AnalyseType</param>
        /// <returns>Liste AnalyseType</returns>
        public static List<AnalyseType> Liste(
             string mCodeAnalyse,
             string mType,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtAnalyseType = adapAnalyseType.PS_AnalyseType_SP(
                mCodeAnalyse,
                mType,
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
        /// Retourne la liste des AnalyseType
        /// </summary>
        /// <returns>Liste AnalyseType</returns>
        private static List<AnalyseType> pListe()
        {
            List<AnalyseType> mListe = new List<AnalyseType>();
            foreach (ParametreDataSet2.T_AnalyseTypeRow mLigne in dtAnalyseType)
            {
                AnalyseType oAnalyseType = new AnalyseType();
                oAnalyseType.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oAnalyseType.Type = mLigne.type.Trim();
                oAnalyseType.NumLigne = mLigne.numLigne;
                oAnalyseType.DateCreationServeur = mLigne.dateCreationServeur;
                oAnalyseType.DateDernModifClient = mLigne.dateDernModifClient;
                oAnalyseType.DateDernModifServeur = mLigne.dateDernModifServeur;
                oAnalyseType.UserLogin = mLigne.userLogin.Trim();
                oAnalyseType.Supprimer = mLigne.supprimer;
                oAnalyseType.Rowvers = mLigne.rowvers;
                oAnalyseType.LibelleAnalyse = mLigne.libelleAnalyse;
                mListe.Add(oAnalyseType);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de AnalyseType
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalyseType.PS_AnalyseType_UP(
                codeAnalyse,
                type,
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
