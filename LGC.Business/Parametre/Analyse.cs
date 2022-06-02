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
    public class Analyse
    {
        #region Constructeurs
        public Analyse()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeAnalyse;
        private string codeSecteur;
        private string libelleAnalyse;
        private Decimal cout;
        private Decimal jours;

        public Decimal Jours
        {
            get { return jours; }
            set { jours = value; }
        }
        private Decimal heure;

        public Decimal Heure
        {
            get { return heure; }
            set { heure = value; }
        }
        private Decimal minute;

        public Decimal Minute
        {
            get { return minute; }
            set { minute = value; }
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
        public string CodeSecteur
        {
            get { return codeSecteur.Trim(); }
            set { codeSecteur = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibelleAnalyse
        {
            get { return libelleAnalyse.Trim(); }
            set { libelleAnalyse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Cout
        {
            get { return cout; }
            set { cout = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Analyse
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Analyse
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Analyse
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Analyse
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Analyse
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Analyse
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Analyse
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
        private static T_AnalyseTableAdapter adapAnalyse = new T_AnalyseTableAdapter();
        private static ParametreDataSet1.T_AnalyseDataTable dtAnalyse = new ParametreDataSet1.T_AnalyseDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Analyse
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalyse.PS_Analyse_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Analyse
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalyse.PS_Analyse_IP(
                codeAnalyse,
                codeSecteur,
                libelleAnalyse,
                cout,
                jours,
                heure,
                minute,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Analyse
        /// </summary>
        /// <param name="codeAnalyse"></param>
        /// <param name="codeSecteur"></param>
        /// <param name="libelleAnalyse"></param>
        /// <param name="cout"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Analyse</param>
        /// <param name="dateCreationServeur">La date de création de Analyse</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Analyse</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Analyse</param>
        /// <param name="userLogin">Le User Login de Analyse</param>
        /// <param name="supprimer">Supprimer de Analyse</param>
        /// <param name="rowvers">Version de ligne de Analyse</param>
        /// <returns>Liste Analyse</returns>
        public static List<Analyse> Liste(
             string mCodeAnalyse,
             string mCodeSecteur,
             string mLibelleAnalyse,
             Decimal? mCout,
             Decimal? mJours,
             Decimal? mHeure,
             Decimal? mMinute,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtAnalyse = adapAnalyse.PS_Analyse_SP(
                mCodeAnalyse,
                mCodeSecteur,
                mLibelleAnalyse,
                mCout,
                mJours,
                mHeure,
                mMinute,
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
        /// Retourne la liste des Analyse
        /// </summary>
        /// <returns>Liste Analyse</returns>
        private static List<Analyse> pListe()
        {
            List<Analyse> mListe = new List<Analyse>();
            foreach (ParametreDataSet1.T_AnalyseRow mLigne in dtAnalyse)
            {
                Analyse oAnalyse = new Analyse();
                oAnalyse.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oAnalyse.CodeSecteur = mLigne.codeSecteur.Trim();
                oAnalyse.LibelleAnalyse = mLigne.libelleAnalyse.Trim();
                oAnalyse.Cout = mLigne.cout;
                oAnalyse.Jours = mLigne.jours;
                oAnalyse.Heure = mLigne.heure;
                oAnalyse.Minute = mLigne.minute;
                oAnalyse.NumLigne = mLigne.numLigne;
                oAnalyse.DateCreationServeur = mLigne.dateCreationServeur;
                oAnalyse.DateDernModifClient = mLigne.dateDernModifClient;
                oAnalyse.DateDernModifServeur = mLigne.dateDernModifServeur;
                oAnalyse.UserLogin = mLigne.userLogin.Trim();
                oAnalyse.Supprimer = mLigne.supprimer;
                oAnalyse.Rowvers = mLigne.rowvers;

                mListe.Add(oAnalyse);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Analyse
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalyse.PS_Analyse_UP(
                codeAnalyse,
                codeSecteur,
                libelleAnalyse,
                cout,
                jours,
                heure,
                minute,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        public static Analyse FindFirst(string mCodeAnalyse)
        {
            dtAnalyse = adapAnalyse.PS_Analyse_SP(
                mCodeAnalyse,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                false,
                null);

            if (dtAnalyse.Rows.Count > 0)
                return pListe()[0];
            else
                return null;
        }


        #endregion Interfaces

        #region Gestion des collections

        #endregion Gestion des collections

        #region Métier

        #endregion Métier
        #endregion Méthodes
    }
}

