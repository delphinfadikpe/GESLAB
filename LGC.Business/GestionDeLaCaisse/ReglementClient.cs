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
    public class ReglementClient
    {
        #region Constructeurs
        public ReglementClient()
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
        private decimal numDemande;
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

        public string ValeurMCF
        {
            get { return valeurMCF; }
            set { valeurMCF = value; }
        }

        public Decimal NumDemande
        {
            get { return numDemande; }
            set { numDemande = value; }
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
        /// Le Numéro de Ligne de ReglementClient
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de ReglementClient
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de ReglementClient
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de ReglementClient
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de ReglementClient
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de ReglementClient
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de ReglementClient
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
        private static T_ReglementClientTableAdapter adapReglementClient = new T_ReglementClientTableAdapter();
        private static GestionDeLaCaisseDataSet.T_ReglementClientDataTable dtReglementClient = new GestionDeLaCaisseDataSet.T_ReglementClientDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de ReglementClient
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementClient.PS_ReglementClient_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de ReglementClient
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementClient.PS_ReglementClient_IP(
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
        /// Retourne la liste de ReglementClient
        /// </summary>
        /// <param name="idFacture"></param>
        /// <param name="idReglement"></param>
        /// <param name="numDemande"></param>
        /// <param name="idOparation"></param>
        /// <param name="modeReglement"></param>
        /// <param name="reference"></param>
        /// <param name="typeReglement"></param>
        /// <param name="dateOperation"></param>
        /// <param name="montantAregler"></param>
        /// <param name="montant"></param>
        /// <param name="montantRestantDue"></param>
        /// <param name="numLigne">Le Numéro de Ligne de ReglementClient</param>
        /// <param name="dateCreationServeur">La date de création de ReglementClient</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de ReglementClient</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ReglementClient</param>
        /// <param name="userLogin">Le User Login de ReglementClient</param>
        /// <param name="supprimer">Supprimer de ReglementClient</param>
        /// <param name="rowvers">Version de ligne de ReglementClient</param>
        /// <returns>Liste ReglementClient</returns>
        public static List<ReglementClient> Liste(
             string mIdFacture,
             Decimal? mIdReglement,
             Decimal? mNumDemande,
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
            dtReglementClient = adapReglementClient.PS_ReglementClient_SP(
                mIdFacture,
                mIdReglement,
                mNumDemande,
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
        /// Retourne la liste des ReglementClient
        /// </summary>
        /// <returns>Liste ReglementClient</returns>
        private static List<ReglementClient> pListe()
        {
            List<ReglementClient> mListe = new List<ReglementClient>();
            foreach (GestionDeLaCaisseDataSet.T_ReglementClientRow mLigne in dtReglementClient)
            {
                ReglementClient oReglementClient = new ReglementClient();
                oReglementClient.IdReglement = mLigne.idReglement;
                oReglementClient.IdOparation = mLigne.idOparation;
                oReglementClient.ModeReglement = mLigne.modeReglement.Trim();
                oReglementClient.Reference = mLigne.reference.Trim();
                oReglementClient.TypeReglement = mLigne.typeReglement;
                oReglementClient.DateOperation = mLigne.dateOperation;
                oReglementClient.MontantAregler = mLigne.montantAregler;
                oReglementClient.Montant = mLigne.montant;
                oReglementClient.MontantRestantDue = mLigne.montantRestantDue;
                oReglementClient.NumLigne = mLigne.numLigne;
                oReglementClient.DateCreationServeur = mLigne.dateCreationServeur;
                oReglementClient.DateDernModifClient = mLigne.dateDernModifClient;
                oReglementClient.DateDernModifServeur = mLigne.dateDernModifServeur;
                oReglementClient.UserLogin = mLigne.userLogin.Trim();
                oReglementClient.Supprimer = mLigne.supprimer;
                oReglementClient.Rowvers = mLigne.rowvers;
                oReglementClient.ValeurMCF = mLigne.valeurMCF;
                mListe.Add(oReglementClient);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de ReglementClient
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementClient.PS_ReglementClient_UP(
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
