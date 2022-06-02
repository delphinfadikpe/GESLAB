using LGC.DataAccess.GestionDeLaCaisse.GestionDeLaCaisseDataSetTableAdapters;
using LGC.DataAccess.GestionDeLaCaisse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGC.Business.GestionDeLaCaisse
{
    /// <summary>
    /// 
    /// </summary>
    public class ReglementFacture
    {
        #region Constructeurs
        public ReglementFacture()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
            private Decimal idReglement;
            private string idFacture;
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
        public Decimal IdReglement
        {
            get { return idReglement; }
            set { idReglement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string IdFacture
        {
            get { return idFacture.Trim(); }
            set { idFacture = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de ReglementFacture
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de ReglementFacture
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de ReglementFacture
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de ReglementFacture
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de ReglementFacture
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de ReglementFacture
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de ReglementFacture
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
        private static TJ_ReglementFactureTableAdapter adapReglementFacture = new TJ_ReglementFactureTableAdapter();
        private static GestionDeLaCaisseDataSet.TJ_ReglementFactureDataTable dtReglementFacture = new GestionDeLaCaisseDataSet.TJ_ReglementFactureDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de ReglementFacture
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementFacture.PS_ReglementFacture_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de ReglementFacture
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementFacture.PS_ReglementFacture_IP(
                idReglement,
                idFacture,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de ReglementFacture
        /// </summary>
        /// <param name="idReglement"></param>
        /// <param name="idFacture"></param>
        /// <param name="numLigne">Le Numéro de Ligne de ReglementFacture</param>
        /// <param name="dateCreationServeur">La date de création de ReglementFacture</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de ReglementFacture</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ReglementFacture</param>
        /// <param name="userLogin">Le User Login de ReglementFacture</param>
        /// <param name="supprimer">Supprimer de ReglementFacture</param>
        /// <param name="rowvers">Version de ligne de ReglementFacture</param>
        /// <returns>Liste ReglementFacture</returns>
        public static List<ReglementFacture> Liste(
             Decimal? mIdReglement,
             string mIdFacture,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtReglementFacture = adapReglementFacture.PS_ReglementFacture_SP(
                mIdReglement,
                mIdFacture,
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
        /// Retourne la liste des ReglementFacture
        /// </summary>
        /// <returns>Liste ReglementFacture</returns>
        private static List<ReglementFacture> pListe()
        {
            List<ReglementFacture> mListe = new List<ReglementFacture>();
            foreach (GestionDeLaCaisseDataSet.TJ_ReglementFactureRow mLigne in dtReglementFacture)
            {
                ReglementFacture oReglementFacture = new ReglementFacture();
                oReglementFacture.IdReglement = mLigne.idReglement;
                oReglementFacture.IdFacture = mLigne.idFacture.Trim();
                oReglementFacture.NumLigne = mLigne.numLigne;
                oReglementFacture.DateCreationServeur = mLigne.dateCreationServeur;
                oReglementFacture.DateDernModifClient = mLigne.dateDernModifClient;
                oReglementFacture.DateDernModifServeur = mLigne.dateDernModifServeur;
                oReglementFacture.UserLogin = mLigne.userLogin.Trim();
                oReglementFacture.Supprimer = mLigne.supprimer;
                oReglementFacture.Rowvers = mLigne.rowvers;

                mListe.Add(oReglementFacture);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de ReglementFacture
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementFacture.PS_ReglementFacture_UP(
                idReglement,
                idFacture,
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
