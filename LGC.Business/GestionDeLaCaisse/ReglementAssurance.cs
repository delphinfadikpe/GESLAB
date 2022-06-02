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
    public class ReglementAssurance
    {
        #region Constructeurs
        public ReglementAssurance()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idReglement;
        private Decimal idOparation;
        private string modeReglement;
        private string reference;
        private Decimal typeReglement;
        private DateTime dateOperation;
        private Decimal montantAregler;
        private Decimal montant;
        private Decimal montantRestantDue;
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
        public Decimal IdOparation
        {
            get { return idOparation; }
            set { idOparation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ModeReglement
        {
            get { return modeReglement.Trim(); }
            set { modeReglement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Reference
        {
            get { return reference.Trim(); }
            set { reference = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal TypeReglement
        {
            get { return typeReglement; }
            set { typeReglement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateOperation
        {
            get { return dateOperation; }
            set { dateOperation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantAregler
        {
            get { return montantAregler; }
            set { montantAregler = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantRestantDue
        {
            get { return montantRestantDue; }
            set { montantRestantDue = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de ReglementAssurance
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de ReglementAssurance
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de ReglementAssurance
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de ReglementAssurance
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de ReglementAssurance
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de ReglementAssurance
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de ReglementAssurance
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
        private static T_ReglementAssuranceTableAdapter adapReglementAssurance = new T_ReglementAssuranceTableAdapter();
        private static GestionDeLaCaisseDataSet.T_ReglementAssuranceDataTable dtReglementAssurance = new GestionDeLaCaisseDataSet.T_ReglementAssuranceDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de ReglementAssurance
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementAssurance.PS_ReglementAssurance_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de ReglementAssurance
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementAssurance.PS_ReglementAssurance_IP(
                idReglement,
                idOparation,
                modeReglement,
                reference,
                typeReglement,
                dateOperation,
                montantAregler,
                montant,
                montantRestantDue,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de ReglementAssurance
        /// </summary>
        /// <param name="idReglement"></param>
        /// <param name="idOparation"></param>
        /// <param name="modeReglement"></param>
        /// <param name="reference"></param>
        /// <param name="typeReglement"></param>
        /// <param name="dateOperation"></param>
        /// <param name="montantAregler"></param>
        /// <param name="montant"></param>
        /// <param name="montantRestantDue"></param>
        /// <param name="numLigne">Le Numéro de Ligne de ReglementAssurance</param>
        /// <param name="dateCreationServeur">La date de création de ReglementAssurance</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de ReglementAssurance</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ReglementAssurance</param>
        /// <param name="userLogin">Le User Login de ReglementAssurance</param>
        /// <param name="supprimer">Supprimer de ReglementAssurance</param>
        /// <param name="rowvers">Version de ligne de ReglementAssurance</param>
        /// <returns>Liste ReglementAssurance</returns>
        public static List<ReglementAssurance> Liste(
            string mIdFacture,
             Decimal? mIdReglement,
             Decimal? mIdOparation,
             string mModeReglement,
             string mReference,
             Decimal? mTypeReglement,
             DateTime? mDateOperation,
             Decimal? mMontantAregler,
             Decimal? mMontant,
             Decimal? mMontantRestantDue,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtReglementAssurance = adapReglementAssurance.PS_ReglementAssurance_SP(mIdFacture,
                mIdReglement,
                mIdOparation,
                mModeReglement,
                mReference,
                mTypeReglement,
                mDateOperation,
                mMontantAregler,
                mMontant,
                mMontantRestantDue,
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
        /// Retourne la liste des ReglementAssurance
        /// </summary>
        /// <returns>Liste ReglementAssurance</returns>
        private static List<ReglementAssurance> pListe()
        {
            List<ReglementAssurance> mListe = new List<ReglementAssurance>();
            foreach (GestionDeLaCaisseDataSet.T_ReglementAssuranceRow mLigne in dtReglementAssurance)
            {
                ReglementAssurance oReglementAssurance = new ReglementAssurance();
                oReglementAssurance.IdReglement = mLigne.idReglement;
                oReglementAssurance.IdOparation = mLigne.idOparation;
                oReglementAssurance.ModeReglement = mLigne.modeReglement.Trim();
                oReglementAssurance.Reference = mLigne.reference.Trim();
                oReglementAssurance.TypeReglement = mLigne.typeReglement;
                oReglementAssurance.DateOperation = mLigne.dateOperation;
                oReglementAssurance.MontantAregler = mLigne.montantAregler;
                oReglementAssurance.Montant = mLigne.montant;
                oReglementAssurance.MontantRestantDue = mLigne.montantRestantDue;
                oReglementAssurance.NumLigne = mLigne.numLigne;
                oReglementAssurance.DateCreationServeur = mLigne.dateCreationServeur;
                oReglementAssurance.DateDernModifClient = mLigne.dateDernModifClient;
                oReglementAssurance.DateDernModifServeur = mLigne.dateDernModifServeur;
                oReglementAssurance.UserLogin = mLigne.userLogin.Trim();
                oReglementAssurance.Supprimer = mLigne.supprimer;
                oReglementAssurance.Rowvers = mLigne.rowvers;

                mListe.Add(oReglementAssurance);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de ReglementAssurance
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementAssurance.PS_ReglementAssurance_UP(
                idReglement,
                idOparation,
                modeReglement,
                reference,
                typeReglement,
                dateOperation,
                montantAregler,
                montant,
                montantRestantDue,
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
