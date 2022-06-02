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
    public class TypeAnalyse
    {
        #region Constructeurs
        public TypeAnalyse()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeAnalyse;
        private string libelleParametre;
        private string valeur;
        private string libelleAnalyse;

        
        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private string type;
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
        public string LibelleParametre
        {
            get { return libelleParametre.Trim(); }
            set { libelleParametre = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Valeur
        {
            get { return valeur.Trim(); }
            set { valeur = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de TypeAnalyse
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            get { return type.Trim(); }
            set { type = value; }
        }

        /// <summary>
        /// La date de création de TypeAnalyse
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de TypeAnalyse
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de TypeAnalyse
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de TypeAnalyse
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de TypeAnalyse
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de TypeAnalyse
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
        private static TJ_TypeAnalyseTableAdapter adapTypeAnalyse = new TJ_TypeAnalyseTableAdapter();
        private static ParametreDataSet2.TJ_TypeAnalyseDataTable dtTypeAnalyse = new ParametreDataSet2.TJ_TypeAnalyseDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de TypeAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeAnalyse.PS_TypeAnalyse_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        public static void DeleteAll(string mCodeAnalyse,string mType)
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeAnalyse.PS_TypeAnalyse_DP_ALL(mCodeAnalyse,
                mType);
            
        }

        /// <summary>
        /// Permet l'enregistrement de TypeAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeAnalyse.PS_TypeAnalyse_IP(
                codeAnalyse,
                libelleParametre,
                valeur,
                type,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de TypeAnalyse
        /// </summary>
        /// <param name="codeAnalyse"></param>
        /// <param name="libelleParametre"></param>
        /// <param name="valeur"></param>
        /// <param name="numLigne">Le Numéro de Ligne de TypeAnalyse</param>
        /// <param name="type"></param>
        /// <param name="dateCreationServeur">La date de création de TypeAnalyse</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de TypeAnalyse</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de TypeAnalyse</param>
        /// <param name="userLogin">Le User Login de TypeAnalyse</param>
        /// <param name="supprimer">Supprimer de TypeAnalyse</param>
        /// <param name="rowvers">Version de ligne de TypeAnalyse</param>
        /// <returns>Liste TypeAnalyse</returns>
        public static List<TypeAnalyse> Liste(
             string mCodeAnalyse,
             string mLibelleParametre,
             string mValeur,
             Decimal? mNumLigne,
             string mType,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtTypeAnalyse = adapTypeAnalyse.PS_TypeAnalyse_SP(
                mCodeAnalyse,
                mLibelleParametre,
                mValeur,
                mNumLigne,
                mType,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mUserLogin,
                mSupprimer,
                mRowvers);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des TypeAnalyse
        /// </summary>
        /// <returns>Liste TypeAnalyse</returns>
        private static List<TypeAnalyse> pListe()
        {
            List<TypeAnalyse> mListe = new List<TypeAnalyse>();
            foreach (ParametreDataSet2.TJ_TypeAnalyseRow mLigne in dtTypeAnalyse)
            {
                TypeAnalyse oTypeAnalyse = new TypeAnalyse();
                oTypeAnalyse.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oTypeAnalyse.LibelleParametre = mLigne.libelleParametre.Trim();
                oTypeAnalyse.Valeur = mLigne.valeur.Trim();
                oTypeAnalyse.NumLigne = mLigne.numLigne;
                oTypeAnalyse.Type = mLigne.type.Trim();
                oTypeAnalyse.DateCreationServeur = mLigne.dateCreationServeur;
                oTypeAnalyse.DateDernModifClient = mLigne.dateDernModifClient;
                oTypeAnalyse.DateDernModifServeur = mLigne.dateDernModifServeur;
                oTypeAnalyse.UserLogin = mLigne.userLogin.Trim();
                oTypeAnalyse.Supprimer = mLigne.supprimer;
                oTypeAnalyse.Rowvers = mLigne.rowvers;
                oTypeAnalyse.LibelleAnalyse = mLigne.libelleAnalyse;
                mListe.Add(oTypeAnalyse);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de TypeAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeAnalyse.PS_TypeAnalyse_UP(
                codeAnalyse,
                libelleParametre,
                valeur,
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
