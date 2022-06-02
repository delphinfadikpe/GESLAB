using System;
using System.Text;
using System.Collections.Generic;
//using LGG.DataAccess.AutresOperations;
//using LGG.DataAccess.AutresOperations.AutresOperationsDataSetTableAdapters;
using LGC.DataAccess.GestionDeStock.GestionDeStockDataSetTableAdapters;
using LGC.DataAccess.GestionDeStock;
//using LGG.Business.GestionUtilisateur;

namespace LGC.Business.GestionDeStock
{
    /// <summary>
    /// 
    /// </summary>
    public class PersonneConcernneeInventaire
    {
        #region Constructeurs
        public PersonneConcernneeInventaire()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string numeroUtilisateur;
        private string numeroInventaire;
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
        public string NumeroUtilisateur
        {
            get { return numeroUtilisateur.Trim(); }
            set { numeroUtilisateur = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NumeroInventaire
        {
            get { return numeroInventaire.Trim(); }
            set { numeroInventaire = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de PersonneConcernneeInventaire
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de PersonneConcernneeInventaire
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de PersonneConcernneeInventaire
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de PersonneConcernneeInventaire
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Version de ligne de PersonneConcernneeInventaire
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// Supprimer de PersonneConcernneeInventaire
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de PersonneConcernneeInventaire
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
        private static TJ_PersonneConcernneeInventaireTableAdapter adapPersonneConcernneeInventaire = new TJ_PersonneConcernneeInventaireTableAdapter();
        private static GestionDeStockDataSet.TJ_PersonneConcernneeInventaireDataTable dtPersonneConcernneeInventaire = new GestionDeStockDataSet.TJ_PersonneConcernneeInventaireDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de PersonneConcernneeInventaire
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPersonneConcernneeInventaire.PS_PersonneConcernneeInventaire_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de PersonneConcernneeInventaire
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPersonneConcernneeInventaire.PS_PersonneConcernneeInventaire_IP(
                numeroUtilisateur,
                numeroInventaire,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de PersonneConcernneeInventaire
        /// </summary>
        /// <param name="numeroUtilisateur"></param>
        /// <param name="numeroInventaire"></param>
        /// <param name="numLigne">Le Numéro de Ligne de PersonneConcernneeInventaire</param>
        /// <param name="dateCreationServeur">La date de création de PersonneConcernneeInventaire</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de PersonneConcernneeInventaire</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de PersonneConcernneeInventaire</param>
        /// <param name="rowvers">Version de ligne de PersonneConcernneeInventaire</param>
        /// <param name="supprimer">Supprimer de PersonneConcernneeInventaire</param>
        /// <param name="userLogin">Le User Login de PersonneConcernneeInventaire</param>
        /// <returns>Liste PersonneConcernneeInventaire</returns>
        public static List<PersonneConcernneeInventaire> Liste(
             string mNumeroUtilisateur,
             string mNumeroInventaire,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             Byte[] mRowvers,
             bool? mSupprimer,
             string mUserLogin)
        {
            dtPersonneConcernneeInventaire = adapPersonneConcernneeInventaire.PS_PersonneConcernneeInventaire_SP(
                mNumeroUtilisateur,
                mNumeroInventaire,
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
        /// Retourne la liste des PersonneConcernneeInventaire
        /// </summary>
        /// <returns>Liste PersonneConcernneeInventaire</returns>
        private static List<PersonneConcernneeInventaire> pListe()
        {
            List<PersonneConcernneeInventaire> mListe = new List<PersonneConcernneeInventaire>();
            foreach (GestionDeStockDataSet.TJ_PersonneConcernneeInventaireRow mLigne in dtPersonneConcernneeInventaire)
            {
                PersonneConcernneeInventaire oPersonneConcernneeInventaire = new PersonneConcernneeInventaire();
                oPersonneConcernneeInventaire.NumeroUtilisateur = mLigne.numeroUtilisateur.Trim();
                oPersonneConcernneeInventaire.NumeroInventaire = mLigne.numeroInventaire.Trim();
                oPersonneConcernneeInventaire.NumLigne = mLigne.numLigne;
                oPersonneConcernneeInventaire.DateCreationServeur = mLigne.dateCreationServeur;
                oPersonneConcernneeInventaire.DateDernModifClient = mLigne.dateDernModifClient;
                oPersonneConcernneeInventaire.DateDernModifServeur = mLigne.dateDernModifServeur;
                oPersonneConcernneeInventaire.Rowvers = mLigne.rowvers;
                oPersonneConcernneeInventaire.Supprimer = mLigne.supprimer;
                oPersonneConcernneeInventaire.UserLogin = mLigne.userLogin.Trim();

                mListe.Add(oPersonneConcernneeInventaire);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de PersonneConcernneeInventaire
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPersonneConcernneeInventaire.PS_PersonneConcernneeInventaire_UP(
                numeroUtilisateur,
                numeroInventaire,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        public static void deleteAll(string mNumeroInventaire)
        {
            adapPersonneConcernneeInventaire.PS_PersonneConcernneeInventaire_DPA(mNumeroInventaire);
        }

        #endregion Interfaces

        #region Gestion des collections

        #endregion Gestion des collections

        #region Métier

        #endregion Métier
        #endregion Méthodes
    }
}

