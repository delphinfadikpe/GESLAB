using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGC.DataAccess.Parametre;
using LGC.DataAccess.Parametre.ParametreDataSet1TableAdapters;
using LGC.DataAccess.Parametre.ParametreDataSet2TableAdapters;

namespace LGC.Business.Parametre
{
    /// <summary>
    /// 
    /// </summary>
    public class AnalysePartenaire
    {
        #region Constructeurs
        public AnalysePartenaire()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idPersonne;
        private string codeAnalyse;
        private Decimal prixNormal;
        private Decimal taux;

        
        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private DateTime dateCreationServeur;
        private DateTime dateDernModifClient;
        private DateTime dateDernModifServeur;
        private bool supprimer;
        private string userLogin;
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
        public Decimal IdPersonne
        {
            get { return idPersonne; }
            set { idPersonne = value; }
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
        public Decimal PrixNormal
        {
            get { return prixNormal; }
            set { prixNormal = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de AnalysePartenaire
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de AnalysePartenaire
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de AnalysePartenaire
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de AnalysePartenaire
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Supprimer de AnalysePartenaire
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de AnalysePartenaire
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Version de ligne de AnalysePartenaire
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
        private static TJ_AnalysePartenaireTableAdapter adapAnalysePartenaire = new TJ_AnalysePartenaireTableAdapter();
        private static ParametreDataSet2.TJ_AnalysePartenaireDataTable dtAnalysePartenaire = new ParametreDataSet2.TJ_AnalysePartenaireDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de AnalysePartenaire
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalysePartenaire.PS_AnalysePartenaire_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de AnalysePartenaire
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalysePartenaire.PS_AnalysePartenaire_IP(
                idPersonne,
                codeAnalyse,
                prixNormal,taux,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de AnalysePartenaire
        /// </summary>
        /// <param name="idPersonne"></param>
        /// <param name="codeAnalyse"></param>
        /// <param name="prixNormal"></param>
        /// <param name="numLigne">Le Numéro de Ligne de AnalysePartenaire</param>
        /// <param name="dateCreationServeur">La date de création de AnalysePartenaire</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de AnalysePartenaire</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de AnalysePartenaire</param>
        /// <param name="supprimer">Supprimer de AnalysePartenaire</param>
        /// <param name="userLogin">Le User Login de AnalysePartenaire</param>
        /// <param name="rowvers">Version de ligne de AnalysePartenaire</param>
        /// <returns>Liste AnalysePartenaire</returns>
        public static List<AnalysePartenaire> Liste(
             Decimal? mIdPersonne,
             string mCodeAnalyse,
             Decimal? mPrixNormal,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             bool? mSupprimer,
             string mUserLogin,
             Byte[] mRowvers)
        {
            dtAnalysePartenaire = adapAnalysePartenaire.PS_AnalysePartenaire_SP(
                mIdPersonne,
                mCodeAnalyse,
                mPrixNormal,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mSupprimer,
                mUserLogin,
                mRowvers);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des AnalysePartenaire
        /// </summary>
        /// <returns>Liste AnalysePartenaire</returns>
        private static List<AnalysePartenaire> pListe()
        {
            List<AnalysePartenaire> mListe = new List<AnalysePartenaire>();
            foreach (ParametreDataSet2.TJ_AnalysePartenaireRow mLigne in dtAnalysePartenaire)
            {
                AnalysePartenaire oAnalysePartenaire = new AnalysePartenaire();
                oAnalysePartenaire.IdPersonne = mLigne.idPersonne;
                oAnalysePartenaire.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oAnalysePartenaire.PrixNormal = mLigne.prixNormal;
                oAnalysePartenaire.NumLigne = mLigne.numLigne;
                oAnalysePartenaire.DateCreationServeur = mLigne.dateCreationServeur;
                oAnalysePartenaire.DateDernModifClient = mLigne.dateDernModifClient;
                oAnalysePartenaire.DateDernModifServeur = mLigne.dateDernModifServeur;
                oAnalysePartenaire.Supprimer = mLigne.supprimer;
                oAnalysePartenaire.UserLogin = mLigne.userLogin.Trim();
                oAnalysePartenaire.Rowvers = mLigne.rowvers;
                oAnalysePartenaire.Taux = mLigne.taux;
                mListe.Add(oAnalysePartenaire);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de AnalysePartenaire
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalysePartenaire.PS_AnalysePartenaire_UP(
                idPersonne,
                codeAnalyse,
                prixNormal,taux,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        public Decimal Taux
        {
            get { return taux; }
            set { taux = value; }
        }
        #endregion Interfaces

        #region Gestion des collections

        #endregion Gestion des collections

        #region Métier

        #endregion Métier
        #endregion Méthodes
    }

}
