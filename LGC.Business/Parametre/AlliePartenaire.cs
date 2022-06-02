using LGC.DataAccess.Parametre;
using LGC.DataAccess.Parametre.ParametreDataSet2TableAdapters;
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
    public class AlliePartenaire
    {
        #region Constructeurs
        public AlliePartenaire()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idPartenaire;
        private string libellePersonne;
        private Decimal tauxRistourne;
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
        public Decimal IdPartenaire
        {
            get { return idPartenaire; }
            set { idPartenaire = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibellePersonne
        {
            get { return libellePersonne.Trim(); }
            set { libellePersonne = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal TauxRistourne
        {
            get { return tauxRistourne; }
            set { tauxRistourne = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de AlliePartenaire
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de AlliePartenaire
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de AlliePartenaire
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de AlliePartenaire
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de AlliePartenaire
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de AlliePartenaire
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de AlliePartenaire
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
        private static TJ_AlliePartenaireTableAdapter adapAlliePartenaire = new TJ_AlliePartenaireTableAdapter();
        private static ParametreDataSet2.TJ_AlliePartenaireDataTable dtAlliePartenaire = new ParametreDataSet2.TJ_AlliePartenaireDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de AlliePartenaire
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAlliePartenaire.PS_AlliePartenaire_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de AlliePartenaire
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAlliePartenaire.PS_AlliePartenaire_IP(
                idPartenaire,
                libellePersonne,
                tauxRistourne,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de AlliePartenaire
        /// </summary>
        /// <param name="idPartenaire"></param>
        /// <param name="libellePersonne"></param>
        /// <param name="tauxRistourne"></param>
        /// <param name="numLigne">Le Numéro de Ligne de AlliePartenaire</param>
        /// <param name="dateCreationServeur">La date de création de AlliePartenaire</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de AlliePartenaire</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de AlliePartenaire</param>
        /// <param name="userLogin">Le User Login de AlliePartenaire</param>
        /// <param name="supprimer">Supprimer de AlliePartenaire</param>
        /// <param name="rowvers">Version de ligne de AlliePartenaire</param>
        /// <returns>Liste AlliePartenaire</returns>
        public static List<AlliePartenaire> Liste(
             Decimal? mIdPartenaire,
             string mLibellePersonne,
             Decimal? mTauxRistourne,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtAlliePartenaire = adapAlliePartenaire.PS_AlliePartenaire_SP(
                mIdPartenaire,
                mLibellePersonne,
                mTauxRistourne,
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
        /// Retourne la liste des AlliePartenaire
        /// </summary>
        /// <returns>Liste AlliePartenaire</returns>
        private static List<AlliePartenaire> pListe()
        {
            List<AlliePartenaire> mListe = new List<AlliePartenaire>();
            foreach (ParametreDataSet2.TJ_AlliePartenaireRow mLigne in dtAlliePartenaire)
            {
                AlliePartenaire oAlliePartenaire = new AlliePartenaire();
                oAlliePartenaire.IdPartenaire = mLigne.idPartenaire;
                oAlliePartenaire.LibellePersonne = mLigne.libellePersonne.Trim();
                oAlliePartenaire.TauxRistourne = mLigne.tauxRistourne;
                oAlliePartenaire.NumLigne = mLigne.numLigne;
                oAlliePartenaire.DateCreationServeur = mLigne.dateCreationServeur;
                oAlliePartenaire.DateDernModifClient = mLigne.dateDernModifClient;
                oAlliePartenaire.DateDernModifServeur = mLigne.dateDernModifServeur;
                oAlliePartenaire.UserLogin = mLigne.userLogin.Trim();
                oAlliePartenaire.Supprimer = mLigne.supprimer;
                oAlliePartenaire.Rowvers = mLigne.rowvers;

                mListe.Add(oAlliePartenaire);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de AlliePartenaire
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAlliePartenaire.PS_AlliePartenaire_UP(
                idPartenaire,
                libellePersonne,
                tauxRistourne,
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
