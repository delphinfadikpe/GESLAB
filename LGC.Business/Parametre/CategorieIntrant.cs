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
    public class CategorieIntrant
    {
        #region Constructeurs
        public CategorieIntrant()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeCategorie;
        private string libelleCategorie;
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
        public string CodeCategorie
        {
            get { return codeCategorie.Trim(); }
            set { codeCategorie = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibelleCategorie
        {
            get { return libelleCategorie.Trim(); }
            set { libelleCategorie = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de CategorieIntrant
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de CategorieIntrant
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de CategorieIntrant
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de CategorieIntrant
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de CategorieIntrant
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de CategorieIntrant
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de CategorieIntrant
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
        private static T_CategorieIntrantTableAdapter adapCategorieIntrant = new T_CategorieIntrantTableAdapter();
        private static ParametreDataSet1.T_CategorieIntrantDataTable dtCategorieIntrant = new ParametreDataSet1.T_CategorieIntrantDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de CategorieIntrant
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapCategorieIntrant.PS_CategorieIntrant_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de CategorieIntrant
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapCategorieIntrant.PS_CategorieIntrant_IP(
                codeCategorie,
                libelleCategorie,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de CategorieIntrant
        /// </summary>
        /// <param name="codeCategorie"></param>
        /// <param name="libelleCategorie"></param>
        /// <param name="numLigne">Le Numéro de Ligne de CategorieIntrant</param>
        /// <param name="dateCreationServeur">La date de création de CategorieIntrant</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de CategorieIntrant</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de CategorieIntrant</param>
        /// <param name="userLogin">Le User Login de CategorieIntrant</param>
        /// <param name="supprimer">Supprimer de CategorieIntrant</param>
        /// <param name="rowvers">Version de ligne de CategorieIntrant</param>
        /// <returns>Liste CategorieIntrant</returns>
        public static List<CategorieIntrant> Liste(
             string mCodeCategorie,
             string mLibelleCategorie,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtCategorieIntrant = adapCategorieIntrant.PS_CategorieIntrant_SP(
                mCodeCategorie,
                mLibelleCategorie,
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
        /// Retourne la liste des CategorieIntrant
        /// </summary>
        /// <returns>Liste CategorieIntrant</returns>
        private static List<CategorieIntrant> pListe()
        {
            List<CategorieIntrant> mListe = new List<CategorieIntrant>();
            foreach (ParametreDataSet1.T_CategorieIntrantRow mLigne in dtCategorieIntrant)
            {
                CategorieIntrant oCategorieIntrant = new CategorieIntrant();
                oCategorieIntrant.CodeCategorie = mLigne.codeCategorie.Trim();
                oCategorieIntrant.LibelleCategorie = mLigne.libelleCategorie.Trim();
                oCategorieIntrant.NumLigne = mLigne.numLigne;
                oCategorieIntrant.DateCreationServeur = mLigne.dateCreationServeur;
                oCategorieIntrant.DateDernModifClient = mLigne.dateDernModifClient;
                oCategorieIntrant.DateDernModifServeur = mLigne.dateDernModifServeur;
                oCategorieIntrant.UserLogin = mLigne.userLogin.Trim();
                oCategorieIntrant.Supprimer = mLigne.supprimer;
                oCategorieIntrant.Rowvers = mLigne.rowvers;

                mListe.Add(oCategorieIntrant);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de CategorieIntrant
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapCategorieIntrant.PS_CategorieIntrant_UP(
                codeCategorie,
                libelleCategorie,
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

