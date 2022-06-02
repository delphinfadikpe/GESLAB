//Fichier :		 Utilisateur.cs
//Auteur :		 Jean-Paul MENSAH
//Créer le :		 lundi 18 mai 2015
//Description :		 Le fichier de classe

using System;
using System.Text;
using System.Collections.Generic;
using LGC.DataAccess.GestionUtilisateur.UserManagerDataSetTableAdapters;
using LGC.DataAccess.GestionUtilisateur;

namespace LGC.Business.GestionUtilisateur
{
    /// <summary>
    /// 
    /// </summary>
    public class Utilisateur
    {
        #region Constructeurs
        public Utilisateur()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal numeroUtilisateur;
        private string nomUtilisateur;
        private string prenomUtilisateur;
        private string sexe;
        private string telephone;
        private string mail;
        private bool estActiveDirectory;
        private bool estActif;
        private string cheminPhoto;
        private string login;
        private string password;
        private bool autoriseDateAnterieur;

        
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
        public Decimal NumeroUtilisateur
        {
            get { return numeroUtilisateur; }
            set { numeroUtilisateur = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NomUtilisateur
        {
            get { return nomUtilisateur.Trim(); }
            set { nomUtilisateur = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PrenomUtilisateur
        {
            get { return prenomUtilisateur.Trim(); }
            set { prenomUtilisateur = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Sexe
        {
            get { return sexe.Trim(); }
            set { sexe = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Telephone
        {
            get { return telephone.Trim(); }
            set { telephone = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Mail
        {
            get { return mail.Trim(); }
            set { mail = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstActiveDirectory
        {
            get { return estActiveDirectory; }
            set { estActiveDirectory = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstActif
        {
            get { return estActif; }
            set { estActif = value; }
        }

        public string CheminPhoto
        {
            get { return cheminPhoto.Trim(); }
            set { cheminPhoto = value; }
        }
         

        /// <summary>
        /// 
        /// </summary>
        public string Login
        {
            get { return login.Trim(); }
            set { login = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get { return password.Trim(); }
            set { password = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AutoriseDateAnterieur
        {
            get { return autoriseDateAnterieur; }
            set { autoriseDateAnterieur = value; }
        }
        #endregion Propres

        #region Passe partout
        /// <summary>
        /// La date de création de Utilisateur
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Utilisateur
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Utilisateur
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le Numéro de Ligne de Utilisateur
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// Version de ligne de Utilisateur
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// Supprimer de Utilisateur
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de Utilisateur
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
        private static T_UtilisateurTableAdapter adapUtilisateur = new T_UtilisateurTableAdapter();
        private static UserManagerDataSet.T_UtilisateurDataTable dtUtilisateur = new UserManagerDataSet.T_UtilisateurDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Utilisateur
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapUtilisateur.PS_Utilisateur_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Utilisateur
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapUtilisateur.PS_Utilisateur_IP(
                numeroUtilisateur,
                nomUtilisateur,
                prenomUtilisateur,
                sexe,
                telephone,
                mail,
                estActiveDirectory,
                estActif,
                cheminPhoto,
                login,
                password,autoriseDateAnterieur,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Utilisateur
        /// </summary>
        /// <param name="numeroUtilisateur"></param>
        /// <param name="nomUtilisateur"></param>
        /// <param name="prenomUtilisateur"></param>
        /// <param name="sexe"></param>
        /// <param name="telephone"></param>
        /// <param name="mail"></param>
        /// <param name="estActiveDirectory"></param>
        /// <param name="estActif"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="dateCreationServeur">La date de création de Utilisateur</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Utilisateur</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Utilisateur</param>
        /// <param name="numLigne">Le Numéro de Ligne de Utilisateur</param>
        /// <param name="rowvers">Version de ligne de Utilisateur</param>
        /// <param name="supprimer">Supprimer de Utilisateur</param>
        /// <param name="userLogin">Le User Login de Utilisateur</param>
        /// <returns>Liste Utilisateur</returns>
        public static List<Utilisateur> Liste(
             Decimal? mNumeroUtilisateur,
             string mNomUtilisateur,
             string mPrenomUtilisateur,
             string mSexe,
             string mTelephone,
             string mMail,
             bool? mEstActiveDirectory,
             bool? mEstActif,
             string mCheminPhoto,
             string mLogin,
             string mPassword,
            bool? mAutoriseDateAnterieur,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             Decimal? mNumLigne,
             Byte[] mRowvers,
             bool? mSupprimer,
             string mUserLogin)
        {
            dtUtilisateur = adapUtilisateur.PS_Utilisateur_SP(
                mNumeroUtilisateur,
                mNomUtilisateur,
                mPrenomUtilisateur,
                mSexe,
                mTelephone,
                mMail,
                mEstActiveDirectory,
                mEstActif,
                mCheminPhoto,
                mLogin,
                mPassword,mAutoriseDateAnterieur,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mNumLigne,
                mRowvers,
                mSupprimer,
                mUserLogin);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des Utilisateur
        /// </summary>
        /// <returns>Liste Utilisateur</returns>
        private static List<Utilisateur> pListe()
        {
            List<Utilisateur> mListe = new List<Utilisateur>();
            foreach (UserManagerDataSet.T_UtilisateurRow mLigne in dtUtilisateur)
            {
                Utilisateur oUtilisateur = new Utilisateur();
                oUtilisateur.NumeroUtilisateur = mLigne.numeroUtilisateur;
                oUtilisateur.NomUtilisateur = mLigne.nomUtilisateur.Trim();
                oUtilisateur.PrenomUtilisateur = mLigne.prenomUtilisateur.Trim();
                oUtilisateur.Sexe = mLigne.sexe.Trim();
                oUtilisateur.Telephone = mLigne.telephone.Trim();
                oUtilisateur.Mail = mLigne.mail.Trim();
                oUtilisateur.EstActiveDirectory = mLigne.estActiveDirectory;
                oUtilisateur.EstActif = mLigne.estActif;
                oUtilisateur.CheminPhoto = mLigne.cheminPhoto.Trim();
                oUtilisateur.Login = mLigne.login.Trim();
                oUtilisateur.Password = mLigne.password.Trim();
                oUtilisateur.DateCreationServeur = mLigne.dateCreationServeur;
                oUtilisateur.DateDernModifClient = mLigne.dateDernModifClient;
                oUtilisateur.DateDernModifServeur = mLigne.dateDernModifServeur;
                oUtilisateur.NumLigne = mLigne.numLigne;
                oUtilisateur.Rowvers = mLigne.rowvers;
                oUtilisateur.Supprimer = mLigne.supprimer;
                oUtilisateur.AutoriseDateAnterieur = mLigne.autoriseDateAnterieur;
                oUtilisateur.UserLogin = mLigne.userLogin.Trim();

                mListe.Add(oUtilisateur);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Utilisateur
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapUtilisateur.PS_Utilisateur_UP(
                numeroUtilisateur,
                nomUtilisateur,
                prenomUtilisateur,
                sexe,
                telephone,
                mail,
                estActiveDirectory,
                estActif,
                cheminPhoto,
                login,
                password,autoriseDateAnterieur,
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

