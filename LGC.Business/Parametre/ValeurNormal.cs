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
    public class ValeurNormal
    {
        #region Constructeurs
        public ValeurNormal()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeAnalyse;
        private string libelleParametre;
        private string codeTranche;
        private Decimal codeVN;
        private string libelleVN;
        private string nomAttribue;

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
        public string CodeTranche
        {
            get { return codeTranche.Trim(); }
            set { codeTranche = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal CodeVN
        {
            get { return codeVN; }
            set { codeVN = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibelleVN
        {
            get { return libelleVN.Trim(); }
            set { libelleVN = value; }
        }


        public string NomAttribue
        {
            get { return nomAttribue; }
            set { nomAttribue = value; }
        }
        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de ValeurNormal
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de ValeurNormal
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de ValeurNormal
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de ValeurNormal
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de ValeurNormal
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de ValeurNormal
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de ValeurNormal
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
        private static T_ValeurNormalTableAdapter adapValeurNormal = new T_ValeurNormalTableAdapter();
        private static ParametreDataSet1.T_ValeurNormalDataTable dtValeurNormal = new ParametreDataSet1.T_ValeurNormalDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de ValeurNormal
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapValeurNormal.PS_ValeurNormal_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de ValeurNormal
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapValeurNormal.PS_ValeurNormal_IP(
                codeAnalyse,
                LibelleParametre,
                codeTranche,
                codeVN,
                libelleVN,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de ValeurNormal
        /// </summary>
        /// <param name="codeAnalyse"></param>
        /// <param name="LibelleParametre"></param>
        /// <param name="codeTranche"></param>
        /// <param name="codeVN"></param>
        /// <param name="libelleVN"></param>
        /// <param name="numLigne">Le Numéro de Ligne de ValeurNormal</param>
        /// <param name="dateCreationServeur">La date de création de ValeurNormal</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de ValeurNormal</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ValeurNormal</param>
        /// <param name="userLogin">Le User Login de ValeurNormal</param>
        /// <param name="supprimer">Supprimer de ValeurNormal</param>
        /// <param name="rowvers">Version de ligne de ValeurNormal</param>
        /// <returns>Liste ValeurNormal</returns>
        public static List<ValeurNormal> Liste(
             string mCodeAnalyse,
             string mNomAttribue,
             string mLibelleParametre,
             string mCodeTranche,
             Decimal? mCodeVN,
             string mLibelleVN,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtValeurNormal = adapValeurNormal.PS_ValeurNormal_SP(
                mCodeAnalyse,
                mNomAttribue,
                mLibelleParametre,
                mCodeTranche,
                mCodeVN,
                mLibelleVN,
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
        /// Retourne la liste des ValeurNormal
        /// </summary>
        /// <returns>Liste ValeurNormal</returns>
        private static List<ValeurNormal> pListe()
        {
            List<ValeurNormal> mListe = new List<ValeurNormal>();
            foreach (ParametreDataSet1.T_ValeurNormalRow mLigne in dtValeurNormal)
            {
                ValeurNormal oValeurNormal = new ValeurNormal();
                oValeurNormal.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oValeurNormal.NomAttribue = mLigne.nomAttribue.Trim();
                oValeurNormal.LibelleParametre = mLigne.LibelleParametre.Trim();
                oValeurNormal.CodeTranche = mLigne.codeTranche.Trim();
                oValeurNormal.CodeVN = mLigne.codeVN;
                oValeurNormal.LibelleVN = mLigne.libelleVN.Trim();
                oValeurNormal.NumLigne = mLigne.numLigne;
                oValeurNormal.DateCreationServeur = mLigne.dateCreationServeur;
                oValeurNormal.DateDernModifClient = mLigne.dateDernModifClient;
                oValeurNormal.DateDernModifServeur = mLigne.dateDernModifServeur;
                oValeurNormal.UserLogin = mLigne.userLogin.Trim();
                oValeurNormal.Supprimer = mLigne.supprimer;
                oValeurNormal.Rowvers = mLigne.rowvers;

                mListe.Add(oValeurNormal);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de ValeurNormal
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapValeurNormal.PS_ValeurNormal_UP(
                codeAnalyse,
                LibelleParametre,
                codeTranche,
                codeVN,
                libelleVN,
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

