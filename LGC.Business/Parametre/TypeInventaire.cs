//Fichier :		 TypeInventaire.cs
//Auteur :		 Derrick TOIHOUN
//Créer le :		 Jeudi 27 janvier 2015
//Description :		 Le fichier de classe

using System;
using System.Text;
using System.Collections.Generic;
using LGC.DataAccess.Parametre.ParametreDataSet1TableAdapters;
using LGC.DataAccess.Parametre;
//using LGG.DataAccess.Parametre.ParametreDataSetTableAdapters;
//using LGG.DataAccess.Parametre;

namespace LGC.Business.Parametre
{
    /// <summary>
    /// 
    /// </summary>
    public class TypeInventaire
    {
        #region Constructeurs
        public TypeInventaire()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeTypeInventaire;
        private string libelleTypeInventaire;
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
        public string CodeTypeInventaire
        {
            get { return codeTypeInventaire.Trim(); }
            set { codeTypeInventaire = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibelleTypeInventaire
        {
            get { return libelleTypeInventaire.Trim(); }
            set { libelleTypeInventaire = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de TypeInventaire
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de TypeInventaire
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de TypeInventaire
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de TypeInventaire
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de TypeInventaire
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de TypeInventaire
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de TypeInventaire
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
        private static T_TypeInventaireTableAdapter adapTypeInventaire = new T_TypeInventaireTableAdapter();
        private static ParametreDataSet1.T_TypeInventaireDataTable dtTypeInventaire = new ParametreDataSet1.T_TypeInventaireDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de TypeInventaire
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeInventaire.PS_TypeInventaire_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de TypeInventaire
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeInventaire.PS_TypeInventaire_IP(
                codeTypeInventaire,
                libelleTypeInventaire,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de TypeInventaire
        /// </summary>
        /// <param name="codeTypeInventaire"></param>
        /// <param name="libelleTypeInventaire"></param>
        /// <param name="numLigne">Le Numéro de Ligne de TypeInventaire</param>
        /// <param name="dateCreationServeur">La date de création de TypeInventaire</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de TypeInventaire</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de TypeInventaire</param>
        /// <param name="userLogin">Le User Login de TypeInventaire</param>
        /// <param name="supprimer">Supprimer de TypeInventaire</param>
        /// <param name="rowvers">Version de ligne de TypeInventaire</param>
        /// <returns>Liste TypeInventaire</returns>
        public static List<TypeInventaire> Liste(
             string mCodeTypeInventaire,
             string mLibelleTypeInventaire,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtTypeInventaire = adapTypeInventaire.PS_TypeInventaire_SP(
                mCodeTypeInventaire,
                mLibelleTypeInventaire,
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
        /// Retourne la liste des TypeInventaire
        /// </summary>
        /// <returns>Liste TypeInventaire</returns>
        private static List<TypeInventaire> pListe()
        {
            List<TypeInventaire> mListe = new List<TypeInventaire>();
            foreach (ParametreDataSet1.T_TypeInventaireRow mLigne in dtTypeInventaire)
            {
                TypeInventaire oTypeInventaire = new TypeInventaire();
                oTypeInventaire.CodeTypeInventaire = mLigne.codeTypeInventaire.Trim();
                oTypeInventaire.LibelleTypeInventaire = mLigne.libelleTypeInventaire.Trim();
                oTypeInventaire.NumLigne = mLigne.numLigne;
                oTypeInventaire.DateCreationServeur = mLigne.dateCreationServeur;
                oTypeInventaire.DateDernModifClient = mLigne.dateDernModifClient;
                oTypeInventaire.DateDernModifServeur = mLigne.dateDernModifServeur;
                oTypeInventaire.UserLogin = mLigne.userLogin.Trim();
                oTypeInventaire.Supprimer = mLigne.supprimer;
                oTypeInventaire.Rowvers = mLigne.rowvers;

                mListe.Add(oTypeInventaire);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de TypeInventaire
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeInventaire.PS_TypeInventaire_UP(
                codeTypeInventaire,
                libelleTypeInventaire,
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

