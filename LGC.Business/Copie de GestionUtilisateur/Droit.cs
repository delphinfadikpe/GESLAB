//Fichier :		 Droit.cs
//Auteur :		 Jean-Paul MENSAH
//Créer le :		 lundi 18 mai 2015
//Description :		 Le fichier de classe

using System;
using System.Text;
using System.Collections.Generic;
using LGG.DataAccess.GestionUtilisateur.UserManagerDataSetTableAdapters;
using LGG.DataAccess.GestionUtilisateur;

namespace LGG.Business.GestionUtilisateur
{
    /// <summary>
    /// 
    /// </summary>
    public class Droit
    {
        #region Constructeurs
        public Droit()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeDroit;
        private string libelleDroit;

        public string LibelleDroit
        {
            get { return libelleDroit; }
            set { libelleDroit = value; }
        }
        private string nomFormulaire;
        private string cheminMenu;
        private bool estSensible;
        private string degreSensibilite;
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
        public string CodeDroit
        {
            get { return codeDroit.Trim(); }
            set { codeDroit = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NomFormulaire
        {
            get { return nomFormulaire.Trim(); }
            set { nomFormulaire = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CheminMenu
        {
            get { return cheminMenu.Trim(); }
            set { cheminMenu = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstSensible
        {
            get { return estSensible; }
            set { estSensible = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DegreSensibilite
        {
            get { return degreSensibilite.Trim(); }
            set { degreSensibilite = value; }
        }

        #endregion Propres

        #region Passe partout
        /// <summary>
        /// La date de création de Droit
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Droit
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Droit
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le Numéro de Ligne de Droit
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// Version de ligne de Droit
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// Supprimer de Droit
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de Droit
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
        private static T_DroitTableAdapter adapDroit = new T_DroitTableAdapter();
        private static UserManagerDataSet.T_DroitDataTable dtDroit = new UserManagerDataSet.T_DroitDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Droit
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapDroit.PS_Droit_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Droit
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapDroit.PS_Droit_IP(
                codeDroit,
                libelleDroit,
                nomFormulaire,
                cheminMenu,
                estSensible,
                degreSensibilite,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Droit
        /// </summary>
        /// <param name="codeDroit"></param>
        /// <param name="nomFormulaire"></param>
        /// <param name="cheminMenu"></param>
        /// <param name="estSensible"></param>
        /// <param name="degreSensibilite"></param>
        /// <param name="dateCreationServeur">La date de création de Droit</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Droit</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Droit</param>
        /// <param name="numLigne">Le Numéro de Ligne de Droit</param>
        /// <param name="rowvers">Version de ligne de Droit</param>
        /// <param name="supprimer">Supprimer de Droit</param>
        /// <param name="userLogin">Le User Login de Droit</param>
        /// <returns>Liste Droit</returns>
        public static List<Droit> Liste(
             string mCodeDroit,
             string mLibelleDroit,
             string mNomFormulaire,
             string mCheminMenu,
             bool? mEstSensible,
             string mDegreSensibilite,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             Decimal? mNumLigne,
             Byte[] mRowvers,
             bool? mSupprimer,
             string mUserLogin)
        {
            dtDroit = adapDroit.PS_Droit_SP(
                mCodeDroit,
                mLibelleDroit,
                mNomFormulaire,
                mCheminMenu,
                mEstSensible,
                mDegreSensibilite,
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
        /// Retourne la liste des Droit
        /// </summary>
        /// <returns>Liste Droit</returns>
        private static List<Droit> pListe()
        {
            List<Droit> mListe = new List<Droit>();
            foreach (UserManagerDataSet.T_DroitRow mLigne in dtDroit)
            {
                Droit oDroit = new Droit();
                oDroit.CodeDroit = mLigne.codeDroit.Trim();
                oDroit.LibelleDroit = mLigne.libelleDroit.Trim();
                oDroit.NomFormulaire = mLigne.nomFormulaire.Trim();
                oDroit.CheminMenu = mLigne.cheminMenu.Trim();
                oDroit.EstSensible = mLigne.estSensible;
                oDroit.DegreSensibilite = mLigne.degreSensibilite.Trim();
                oDroit.DateCreationServeur = mLigne.dateCreationServeur;
                oDroit.DateDernModifClient = mLigne.dateDernModifClient;
                oDroit.DateDernModifServeur = mLigne.dateDernModifServeur;
                oDroit.NumLigne = mLigne.numLigne;
                oDroit.Rowvers = mLigne.rowvers;
                oDroit.Supprimer = mLigne.supprimer;
                oDroit.UserLogin = mLigne.userLogin.Trim();

                mListe.Add(oDroit);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Droit
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapDroit.PS_Droit_UP(
                codeDroit,
                libelleDroit,
                nomFormulaire,
                cheminMenu,
                estSensible,
                degreSensibilite,
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

