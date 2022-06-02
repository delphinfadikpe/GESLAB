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
    public class ParametrageInterpretationParametre
    {
        #region Constructeurs
        public ParametrageInterpretationParametre()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeAnalyse;
        private string libelleParametre;
        private Decimal borneInferieure;
        private Decimal borneSuperieure;
        private string valeur;
        private string interpretation;
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
        public Decimal BorneInferieure
        {
            get { return borneInferieure; }
            set { borneInferieure = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal BorneSuperieure
        {
            get { return borneSuperieure; }
            set { borneSuperieure = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Interpretation
        {
            get { return interpretation.Trim(); }
            set { interpretation = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de ParametrageInterpretationParametre
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de ParametrageInterpretationParametre
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de ParametrageInterpretationParametre
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de ParametrageInterpretationParametre
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de ParametrageInterpretationParametre
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de ParametrageInterpretationParametre
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de ParametrageInterpretationParametre
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
        private static T_ParametrageInterpretationParametreTableAdapter adapParametrageInterpretationParametre = new T_ParametrageInterpretationParametreTableAdapter();
        private static ParametreDataSet1.T_ParametrageInterpretationParametreDataTable dtParametrageInterpretationParametre = new ParametreDataSet1.T_ParametrageInterpretationParametreDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de ParametrageInterpretationParametre
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapParametrageInterpretationParametre.PS_ParametrageInterpretationParametre_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de ParametrageInterpretationParametre
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapParametrageInterpretationParametre.PS_ParametrageInterpretationParametre_IP(
                codeAnalyse,
                LibelleParametre,
                borneInferieure,
                borneSuperieure,
                valeur,
                interpretation,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de ParametrageInterpretationParametre
        /// </summary>
        /// <param name="codeAnalyse"></param>
        /// <param name="LibelleParametre"></param>
        /// <param name="borneInferieure"></param>
        /// <param name="borneSuperieure"></param>
        /// <param name="valeur"></param>
        /// <param name="interpretation"></param>
        /// <param name="numLigne">Le Numéro de Ligne de ParametrageInterpretationParametre</param>
        /// <param name="dateCreationServeur">La date de création de ParametrageInterpretationParametre</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de ParametrageInterpretationParametre</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ParametrageInterpretationParametre</param>
        /// <param name="userLogin">Le User Login de ParametrageInterpretationParametre</param>
        /// <param name="supprimer">Supprimer de ParametrageInterpretationParametre</param>
        /// <param name="rowvers">Version de ligne de ParametrageInterpretationParametre</param>
        /// <returns>Liste ParametrageInterpretationParametre</returns>
        public static List<ParametrageInterpretationParametre> Liste(
             string mCodeAnalyse,
             string mLibelleParametre,
             Decimal? mBorneInferieure,
             Decimal? mBorneSuperieure,
             string mValeur,
             string mInterpretation,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtParametrageInterpretationParametre = adapParametrageInterpretationParametre.PS_ParametrageInterpretationParametre_SP(
                mCodeAnalyse,
                mLibelleParametre,
                mBorneInferieure,
                mBorneSuperieure,
                mValeur,
                mInterpretation,
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
        /// Retourne la liste des ParametrageInterpretationParametre
        /// </summary>
        /// <returns>Liste ParametrageInterpretationParametre</returns>
        private static List<ParametrageInterpretationParametre> pListe()
        {
            List<ParametrageInterpretationParametre> mListe = new List<ParametrageInterpretationParametre>();
            foreach (ParametreDataSet1.T_ParametrageInterpretationParametreRow mLigne in dtParametrageInterpretationParametre)
            {
                ParametrageInterpretationParametre oParametrageInterpretationParametre = new ParametrageInterpretationParametre();
                oParametrageInterpretationParametre.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oParametrageInterpretationParametre.LibelleParametre = mLigne.LibelleParametre.Trim();
                oParametrageInterpretationParametre.BorneInferieure = mLigne.borneInferieure;
                oParametrageInterpretationParametre.BorneSuperieure = mLigne.borneSuperieure;
                oParametrageInterpretationParametre.Valeur = mLigne.valeur;
                oParametrageInterpretationParametre.Interpretation = mLigne.interpretation.Trim();
                oParametrageInterpretationParametre.NumLigne = mLigne.numLigne;
                oParametrageInterpretationParametre.DateCreationServeur = mLigne.dateCreationServeur;
                oParametrageInterpretationParametre.DateDernModifClient = mLigne.dateDernModifClient;
                oParametrageInterpretationParametre.DateDernModifServeur = mLigne.dateDernModifServeur;
                oParametrageInterpretationParametre.UserLogin = mLigne.userLogin.Trim();
                oParametrageInterpretationParametre.Supprimer = mLigne.supprimer;
                oParametrageInterpretationParametre.Rowvers = mLigne.rowvers;

                mListe.Add(oParametrageInterpretationParametre);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de ParametrageInterpretationParametre
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapParametrageInterpretationParametre.PS_ParametrageInterpretationParametre_UP(
                codeAnalyse,
                LibelleParametre,
                borneInferieure,
                borneSuperieure,
                valeur,
                interpretation,
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

