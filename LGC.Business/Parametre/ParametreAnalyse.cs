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
    public class ParametreAnalyse
    {
        #region Constructeurs
        public ParametreAnalyse()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeAnalyse;
        private string libelleParametre;
        private string code;
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
        public string Code
        {
            get { return code.Trim(); }
            set { code = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de ParametreAnalyse
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de ParametreAnalyse
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de ParametreAnalyse
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de ParametreAnalyse
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de ParametreAnalyse
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de ParametreAnalyse
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de ParametreAnalyse
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
        private static T_ParametreAnalyseTableAdapter adapParametreAnalyse = new T_ParametreAnalyseTableAdapter();
        private static ParametreDataSet1.T_ParametreAnalyseDataTable dtParametreAnalyse = new ParametreDataSet1.T_ParametreAnalyseDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de ParametreAnalyse
        /// </summary>
        /// <returns> </returns>
        /// 
        public static void Delete_All(string mCodeAnalyse)
        {
            adapParametreAnalyse.PS_ParametreAnalyse_DP_ALL(
                mCodeAnalyse);
   
        }

        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapParametreAnalyse.PS_ParametreAnalyse_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de ParametreAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapParametreAnalyse.PS_ParametreAnalyse_IP(
                codeAnalyse,
                LibelleParametre,
                code,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de ParametreAnalyse
        /// </summary>
        /// <param name="codeAnalyse"></param>
        /// <param name="LibelleParametre"></param>
        /// <param name="code"></param>
        /// <param name="numLigne">Le Numéro de Ligne de ParametreAnalyse</param>
        /// <param name="dateCreationServeur">La date de création de ParametreAnalyse</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de ParametreAnalyse</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ParametreAnalyse</param>
        /// <param name="userLogin">Le User Login de ParametreAnalyse</param>
        /// <param name="supprimer">Supprimer de ParametreAnalyse</param>
        /// <param name="rowvers">Version de ligne de ParametreAnalyse</param>
        /// <returns>Liste ParametreAnalyse</returns>
        public static List<ParametreAnalyse> Liste(
             string mCodeAnalyse,
             string mLibelleParametre,
             string mCode,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtParametreAnalyse = adapParametreAnalyse.PS_ParametreAnalyse_SP(
                mCodeAnalyse,
                mLibelleParametre,
                mCode,
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
        /// Retourne la liste des ParametreAnalyse
        /// </summary>
        /// <returns>Liste ParametreAnalyse</returns>
        private static List<ParametreAnalyse> pListe()
        {
            List<ParametreAnalyse> mListe = new List<ParametreAnalyse>();
            foreach (ParametreDataSet1.T_ParametreAnalyseRow mLigne in dtParametreAnalyse)
            {
                ParametreAnalyse oParametreAnalyse = new ParametreAnalyse();
                oParametreAnalyse.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oParametreAnalyse.LibelleParametre = mLigne.LibelleParametre.Trim();
                oParametreAnalyse.Code = mLigne.code.Trim();
                oParametreAnalyse.NumLigne = mLigne.numLigne;
                oParametreAnalyse.DateCreationServeur = mLigne.dateCreationServeur;
                oParametreAnalyse.DateDernModifClient = mLigne.dateDernModifClient;
                oParametreAnalyse.DateDernModifServeur = mLigne.dateDernModifServeur;
                oParametreAnalyse.UserLogin = mLigne.userLogin.Trim();
                oParametreAnalyse.Supprimer = mLigne.supprimer;
                oParametreAnalyse.Rowvers = mLigne.rowvers;

                mListe.Add(oParametreAnalyse);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de ParametreAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapParametreAnalyse.PS_ParametreAnalyse_UP(
                codeAnalyse,
                LibelleParametre,
                code,
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

