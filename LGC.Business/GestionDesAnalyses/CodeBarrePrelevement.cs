using LGC.DataAccess.GestionDesAnalyses;
using LGC.DataAccess.GestionDesAnalyses.GestionDesAnalysesDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGC.Business.GestionDesAnalyses
{
    /// 
    /// </summary>
    public class CodeBarrePrelevement
    {
        #region Constructeurs
        public CodeBarrePrelevement()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idCodeBarPrelevement;
        private Decimal idCodeBarre;
        private Decimal numDemande;
        private string codeAnalyse;
        private string codePrelevement;
        private string chaineCode;
        private DateTime dateGeneration;
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
        public Decimal IdCodeBarPrelevement
        {
            get { return idCodeBarPrelevement; }
            set { idCodeBarPrelevement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal IdCodeBarre
        {
            get { return idCodeBarre; }
            set { idCodeBarre = value; }
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
        public string CodeAnalyse
        {
            get { return codeAnalyse.Trim(); }
            set { codeAnalyse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodePrelevement
        {
            get { return codePrelevement.Trim(); }
            set { codePrelevement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ChaineCode
        {
            get { return chaineCode.Trim(); }
            set { chaineCode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateGeneration
        {
            get { return dateGeneration; }
            set { dateGeneration = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de CodeBarrePrelevement
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de CodeBarrePrelevement
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de CodeBarrePrelevement
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de CodeBarrePrelevement
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Version de ligne de CodeBarrePrelevement
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// Supprimer de CodeBarrePrelevement
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de CodeBarrePrelevement
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
        private static T_CodeBarrePrelevementTableAdapter adapCodeBarrePrelevement = new T_CodeBarrePrelevementTableAdapter();
        private static GestionDesAnalysesDataSet.T_CodeBarrePrelevementDataTable dtCodeBarrePrelevement = new GestionDesAnalysesDataSet.T_CodeBarrePrelevementDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de CodeBarrePrelevement
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapCodeBarrePrelevement.PS_CodeBarrePrelevement_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de CodeBarrePrelevement
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapCodeBarrePrelevement.PS_CodeBarrePrelevement_IP(
                idCodeBarPrelevement,
                idCodeBarre,
                numDemande,
                codeAnalyse,
                codePrelevement,
                chaineCode,
                dateGeneration,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de CodeBarrePrelevement
        /// </summary>
        /// <param name="idCodeBarPrelevement"></param>
        /// <param name="idCodeBarre"></param>
        /// <param name="numDemande"></param>
        /// <param name="codeAnalyse"></param>
        /// <param name="codePrelevement"></param>
        /// <param name="chaineCode"></param>
        /// <param name="dateGeneration"></param>
        /// <param name="numLigne">Le Numéro de Ligne de CodeBarrePrelevement</param>
        /// <param name="dateCreationServeur">La date de création de CodeBarrePrelevement</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de CodeBarrePrelevement</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de CodeBarrePrelevement</param>
        /// <param name="rowvers">Version de ligne de CodeBarrePrelevement</param>
        /// <param name="supprimer">Supprimer de CodeBarrePrelevement</param>
        /// <param name="userLogin">Le User Login de CodeBarrePrelevement</param>
        /// <returns>Liste CodeBarrePrelevement</returns>
        public static List<CodeBarrePrelevement> Liste(
             Decimal? mIdCodeBarPrelevement,
             Decimal? mIdCodeBarre,
             Decimal? mNumDemande,
             string mCodeAnalyse,
             string mCodePrelevement,
             string mChaineCode,
             DateTime? mDateGeneration,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             Byte[] mRowvers,
             bool? mSupprimer,
             string mUserLogin)
        {
            dtCodeBarrePrelevement = adapCodeBarrePrelevement.PS_CodeBarrePrelevement_SP(
                mIdCodeBarPrelevement,
                mIdCodeBarre,
                mNumDemande,
                mCodeAnalyse,
                mCodePrelevement,
                mChaineCode,
                mDateGeneration,
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
        /// Retourne la liste des CodeBarrePrelevement
        /// </summary>
        /// <returns>Liste CodeBarrePrelevement</returns>
        private static List<CodeBarrePrelevement> pListe()
        {
            List<CodeBarrePrelevement> mListe = new List<CodeBarrePrelevement>();
            foreach (GestionDesAnalysesDataSet.T_CodeBarrePrelevementRow mLigne in dtCodeBarrePrelevement)
            {
                CodeBarrePrelevement oCodeBarrePrelevement = new CodeBarrePrelevement();
                oCodeBarrePrelevement.IdCodeBarPrelevement = mLigne.idCodeBarPrelevement;
                oCodeBarrePrelevement.IdCodeBarre = mLigne.idCodeBarre;
                oCodeBarrePrelevement.NumDemande = mLigne.numDemande;
                oCodeBarrePrelevement.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oCodeBarrePrelevement.CodePrelevement = mLigne.codePrelevement.Trim();
                oCodeBarrePrelevement.ChaineCode = mLigne.chaineCode.Trim();
                oCodeBarrePrelevement.DateGeneration = mLigne.dateGeneration;
                oCodeBarrePrelevement.NumLigne = mLigne.numLigne;
                oCodeBarrePrelevement.DateCreationServeur = mLigne.dateCreationServeur;
                oCodeBarrePrelevement.DateDernModifClient = mLigne.dateDernModifClient;
                oCodeBarrePrelevement.DateDernModifServeur = mLigne.dateDernModifServeur;
                oCodeBarrePrelevement.Rowvers = mLigne.rowvers;
                oCodeBarrePrelevement.Supprimer = mLigne.supprimer;
                oCodeBarrePrelevement.UserLogin = mLigne.userLogin.Trim();

                mListe.Add(oCodeBarrePrelevement);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de CodeBarrePrelevement
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapCodeBarrePrelevement.PS_CodeBarrePrelevement_UP(
                idCodeBarPrelevement,
                idCodeBarre,
                numDemande,
                codeAnalyse,
                codePrelevement,
                chaineCode,
                dateGeneration,
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

