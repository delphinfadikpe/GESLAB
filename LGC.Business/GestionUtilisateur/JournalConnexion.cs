//Fichier :		 JournalConnexion.cs
//Auteur :		 Jean-Paul MENSAH
//Créer le :		 lundi 18 mai 2015
//Description :		 Le fichier de classe

using System;
using System.Collections.Generic;
using LGC.DataAccess.GestionUtilisateur.UserManagerDataSetTableAdapters;
using LGC.DataAccess.GestionUtilisateur;
using System.Data;


namespace LGC.Business.GestionUtilisateur
{
    /// <summary>
    /// 
    /// </summary>
    public class JournalConnexion
    {
        #region Constructeurs
        public JournalConnexion()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal numeroConnexion;
        private Decimal numeroUtilisateur;
        private string nomUtilisateur;
		private string prenomUtilisateur;
		private string sexe;
        private string adresseIP;
        private string adresseMac;
        private DateTime dateDebCon;
        private DateTime dateFinCon;
        private string utilisateurWindows;

        public string UtilisateurWindows
        {
            get { return utilisateurWindows; }
            set { utilisateurWindows = value; }
        }
        private string nomMachine;

        public string NomMachine
        {
            get { return nomMachine; }
            set { nomMachine = value; }
        }

        private string intitule;

        public string Intitule
        {
            get { return intitule; }
            set { intitule = value; }
        }
        #endregion Propres

        #region Passe partout
        private DateTime dateCreationServeur;
        private DateTime dateDernModifClient;
        private DateTime dateDernModifServeur;
        private Decimal numLigne;
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
        public Decimal NumeroConnexion
        {
            get { return numeroConnexion; }
            set { numeroConnexion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal NumeroUtilisateur
        {
            get { return numeroUtilisateur; }
            set { numeroUtilisateur = value; }
        }


        public string NomUtilisateur
        {
            get { return nomUtilisateur.Trim(); }
            set { nomUtilisateur = value; }
        }


        public string PrenomUtilisateur
        {
            get { return prenomUtilisateur.Trim(); }
            set { prenomUtilisateur = value; }
        }


        public string Sexe
        {
            get { return sexe.Trim(); }
            set { sexe = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AdresseIP
        {
            get { return adresseIP.Trim(); }
            set { adresseIP = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string AdresseMac
        {
            get { return adresseMac.Trim(); }
            set { adresseMac = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateDebCon
        {
            get { return dateDebCon; }
            set { dateDebCon = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateFinCon
        {
            get { return dateFinCon; }
            set { dateFinCon = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// La date de création de JournalConnexion
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de JournalConnexion
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de JournalConnexion
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le Numéro de Ligne de JournalConnexion
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// Version de ligne de JournalConnexion
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// Supprimer de JournalConnexion
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de JournalConnexion
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
        private static T_JournalConnexionTableAdapter adapJournalConnexion = new T_JournalConnexionTableAdapter();
        private static UserManagerDataSet.T_JournalConnexionDataTable dtJournalConnexion = new UserManagerDataSet.T_JournalConnexionDataTable();

        private static FT_JournalConnexionTableAdapter adapFnctJournalConnexion = new FT_JournalConnexionTableAdapter();
        private static UserManagerDataSet.FT_JournalConnexionDataTable dtFnctJournalConnexion = new UserManagerDataSet.FT_JournalConnexionDataTable();

        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        //permet l'affichage du journal des connexions
        public static DataTable afficheJournalConnexion(
           
                    DateTime? mDateJour,
                    DateTime? mDateDeb,
                    DateTime? mDateFin)
        {
            return adapFnctJournalConnexion.GetData(mDateJour, mDateDeb, mDateFin);

        }

        /// <summary>
        /// Permet la suppression de JournalConnexion
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapJournalConnexion.PS_JournalConnexion_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de JournalConnexion
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapJournalConnexion.PS_JournalConnexion_IP(
                numeroConnexion,
                numeroUtilisateur,
                adresseIP,
                adresseMac,
                dateDebCon,
                dateFinCon,
                utilisateurWindows,
                nomMachine,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de JournalConnexion
        /// </summary>
        /// <param name="numeroConnexion"></param>
        /// <param name="numeroUtilisateur"></param>
        /// <param name="adresseIP"></param>
        /// <param name="adresseMac"></param>
        /// <param name="dateDebCon"></param>
        /// <param name="dateFinCon"></param>
        /// <param name="dateCreationServeur">La date de création de JournalConnexion</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de JournalConnexion</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de JournalConnexion</param>
        /// <param name="numLigne">Le Numéro de Ligne de JournalConnexion</param>
        /// <param name="rowvers">Version de ligne de JournalConnexion</param>
        /// <param name="supprimer">Supprimer de JournalConnexion</param>
        /// <param name="userLogin">Le User Login de JournalConnexion</param>
        /// <returns>Liste JournalConnexion</returns>
        public static List<JournalConnexion> Liste(
             Decimal? mNumeroConnexion,
             Decimal? mNumeroUtilisateur,
             string mAdresseIP,
             string mAdresseMac,
             DateTime? mDateFinCon,
             DateTime? mDateDeb,
             DateTime? mDateFin,
            string mUtilisateurWindows,
            string mNomMachine,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             Decimal? mNumLigne,
             Byte[] mRowvers,
             bool? mSupprimer,
             string mUserLogin)
        {
            dtJournalConnexion = adapJournalConnexion.PS_JournalConnexion_SP(
                mNumeroConnexion,
                mNumeroUtilisateur,
                mAdresseIP,
                mAdresseMac,
                mDateFinCon,
                mUtilisateurWindows,
                mNomMachine,
                mDateDeb,
                mDateFin,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mNumLigne,
                mRowvers,
                mSupprimer,
                mUserLogin);
            return pListe();
        }

        public static List<JournalConnexion> ListeUtilisateur(DateTime? mDateDeb,
             DateTime? mDateFin)
        {
            dtJournalConnexion = adapJournalConnexion.PS_JournalConnexionUtilisateur_SP(
                mDateDeb,
                mDateFin);
            return pListe();
        }

        public static List<JournalConnexion> ListeDate(DateTime? mDateDeb,
             DateTime? mDateFin)
        {
            dtJournalConnexion = adapJournalConnexion.PS_JournalConnexionDate_SP(
                mDateDeb,
                mDateFin);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des JournalConnexion
        /// </summary>
        /// <returns>Liste JournalConnexion</returns>
        private static List<JournalConnexion> pListe()
        {
            List<JournalConnexion> mListe = new List<JournalConnexion>();
            foreach (UserManagerDataSet.T_JournalConnexionRow mLigne in dtJournalConnexion)
            {
                JournalConnexion oJournalConnexion = new JournalConnexion();
                oJournalConnexion.NomMachine = mLigne.nomMachine.Trim();
                oJournalConnexion.NumeroConnexion = mLigne.numeroConnexion;
                oJournalConnexion.NumeroUtilisateur = mLigne.numeroUtilisateur;
                oJournalConnexion.NomUtilisateur = mLigne.nomUtilisateur.Trim();
                oJournalConnexion.PrenomUtilisateur= mLigne.prenomUtilisateur.Trim();
                oJournalConnexion.Sexe = mLigne.sexe.Trim();
                oJournalConnexion.AdresseIP = mLigne.adresseIP.Trim();
                oJournalConnexion.AdresseMac = mLigne.adresseMac.Trim();
                oJournalConnexion.DateDebCon = mLigne.dateDebCon;
                oJournalConnexion.DateFinCon = mLigne.dateFinCon;
                oJournalConnexion.DateCreationServeur = mLigne.dateCreationServeur;
                oJournalConnexion.DateDernModifClient = mLigne.dateDernModifClient;
                oJournalConnexion.DateDernModifServeur = mLigne.dateDernModifServeur;
                oJournalConnexion.NumLigne = mLigne.numLigne;
                oJournalConnexion.Rowvers = mLigne.rowvers;
                oJournalConnexion.Supprimer = mLigne.supprimer;
                oJournalConnexion.UserLogin = mLigne.userLogin.Trim();
                oJournalConnexion.utilisateurWindows = mLigne.utilisateurWindows.Trim();
                oJournalConnexion.Intitule = mLigne.nomUtilisateur.Trim() + " " + mLigne.prenomUtilisateur.Trim();
                mListe.Add(oJournalConnexion);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de JournalConnexion
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapJournalConnexion.PS_JournalConnexion_UP(
                numeroConnexion,
                numeroUtilisateur,
                adresseIP,
                adresseMac,
                dateDebCon,
                dateFinCon,
                utilisateurWindows,
                nomMachine,
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

