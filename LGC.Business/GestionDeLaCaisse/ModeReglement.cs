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
    public class ModeReglement
    {
        #region Constructeurs
        public ModeReglement()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idMode;
        private string libelleMode;
        private string valeurMCF;

       
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
        public string ValeurMCF
        {
            get { return valeurMCF; }
            set { valeurMCF = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Decimal IdMode
        {
            get { return idMode; }
            set { idMode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibelleMode
        {
            get { return libelleMode.Trim(); }
            set { libelleMode = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de ModeReglement
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de ModeReglement
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de ModeReglement
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de ModeReglement
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de ModeReglement
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de ModeReglement
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de ModeReglement
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
        private static T_ModeReglementTableAdapter adapModeReglement = new T_ModeReglementTableAdapter();
        private static GestionDeLaCaisseDataSet.T_ModeReglementDataTable dtModeReglement = new GestionDeLaCaisseDataSet.T_ModeReglementDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de ModeReglement
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapModeReglement.PS_ModeReglement_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de ModeReglement
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapModeReglement.PS_ModeReglement_IP(
                idMode,
                libelleMode,valeurMCF,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de ModeReglement
        /// </summary>
        /// <param name="idMode"></param>
        /// <param name="libelleMode"></param>
        /// <param name="numLigne">Le Numéro de Ligne de ModeReglement</param>
        /// <param name="dateCreationServeur">La date de création de ModeReglement</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de ModeReglement</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ModeReglement</param>
        /// <param name="userLogin">Le User Login de ModeReglement</param>
        /// <param name="supprimer">Supprimer de ModeReglement</param>
        /// <param name="rowvers">Version de ligne de ModeReglement</param>
        /// <returns>Liste ModeReglement</returns>
        public static List<ModeReglement> Liste(
             Decimal? mIdMode,
             string mLibelleMode,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtModeReglement = adapModeReglement.PS_ModeReglement_SP(
                mIdMode,
                mLibelleMode,null,
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
        /// Retourne la liste des ModeReglement
        /// </summary>
        /// <returns>Liste ModeReglement</returns>
        private static List<ModeReglement> pListe()
        {
            List<ModeReglement> mListe = new List<ModeReglement>();
            foreach (GestionDeLaCaisseDataSet.T_ModeReglementRow mLigne in dtModeReglement)
            {
                ModeReglement oModeReglement = new ModeReglement();
                oModeReglement.IdMode = mLigne.idMode;
                oModeReglement.LibelleMode = mLigne.libelleMode.Trim();
                oModeReglement.NumLigne = mLigne.numLigne;
                oModeReglement.DateCreationServeur = mLigne.dateCreationServeur;
                oModeReglement.DateDernModifClient = mLigne.dateDernModifClient;
                oModeReglement.DateDernModifServeur = mLigne.dateDernModifServeur;
                oModeReglement.UserLogin = mLigne.userLogin.Trim();
                oModeReglement.Supprimer = mLigne.supprimer;
                oModeReglement.Rowvers = mLigne.rowvers;

                mListe.Add(oModeReglement);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de ModeReglement
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapModeReglement.PS_ModeReglement_UP(
                idMode,
                libelleMode,valeurMCF,
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
