using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGC.DataAccess.GestionDeLaCaisse.GestionDeLaCaisseDataSetTableAdapters;
using LGC.DataAccess.GestionDeLaCaisse;



namespace LGC.Business.GestionDeLaCaisse
{
    /// <summary>
    /// 
    /// </summary>
    public class ReglementFournisseur
    {
        #region Constructeurs
        public ReglementFournisseur()
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
        /// Le Numéro de Ligne de ReglementFournisseur
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de ReglementFournisseur
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de ReglementFournisseur
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de ReglementFournisseur
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de ReglementFournisseur
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de ReglementFournisseur
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de ReglementFournisseur
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
        private static T_ReglementFournisseurTableAdapter adapReglementFournisseur = new T_ReglementFournisseurTableAdapter();
        private static GestionDeLaCaisseDataSet.T_ReglementFournisseurDataTable dtReglementFournisseur = new GestionDeLaCaisseDataSet.T_ReglementFournisseurDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de ReglementFournisseur
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementFournisseur.PS_ReglementFournisseur_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de ReglementFournisseur
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementFournisseur.PS_ReglementFournisseur_IP(
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
        /// Retourne la liste de ReglementFournisseur
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
        /// <param name="numLigne">Le Numéro de Ligne de ReglementFournisseur</param>
        /// <param name="dateCreationServeur">La date de création de ReglementFournisseur</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de ReglementFournisseur</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ReglementFournisseur</param>
        /// <param name="userLogin">Le User Login de ReglementFournisseur</param>
        /// <param name="supprimer">Supprimer de ReglementFournisseur</param>
        /// <param name="rowvers">Version de ligne de ReglementFournisseur</param>
        /// <returns>Liste ReglementFournisseur</returns>
        public static List<ReglementFournisseur> Liste(
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
            dtReglementFournisseur = adapReglementFournisseur.PS_ReglementFournisseur_SP(
                mIdFacture,
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
        /// Retourne la liste des ReglementFournisseur
        /// </summary>
        /// <returns>Liste ReglementFournisseur</returns>
        private static List<ReglementFournisseur> pListe()
        {
            List<ReglementFournisseur> mListe = new List<ReglementFournisseur>();
            foreach (GestionDeLaCaisseDataSet.T_ReglementFournisseurRow mLigne in dtReglementFournisseur)
            {
                ReglementFournisseur oReglementFournisseur = new ReglementFournisseur();
                oReglementFournisseur.IdReglement = mLigne.idReglement;
                oReglementFournisseur.IdOparation = mLigne.idOparation;
                oReglementFournisseur.ModeReglement = mLigne.modeReglement.Trim();
                oReglementFournisseur.Reference = mLigne.reference.Trim();
                oReglementFournisseur.TypeReglement = mLigne.typeReglement;
                oReglementFournisseur.DateOperation = mLigne.dateOperation;
                oReglementFournisseur.MontantAregler = mLigne.montantAregler;
                oReglementFournisseur.Montant = mLigne.montant;
                oReglementFournisseur.MontantRestantDue = mLigne.montantRestantDue;
                oReglementFournisseur.NumLigne = mLigne.numLigne;
                oReglementFournisseur.DateCreationServeur = mLigne.dateCreationServeur;
                oReglementFournisseur.DateDernModifClient = mLigne.dateDernModifClient;
                oReglementFournisseur.DateDernModifServeur = mLigne.dateDernModifServeur;
                oReglementFournisseur.UserLogin = mLigne.userLogin.Trim();
                oReglementFournisseur.Supprimer = mLigne.supprimer;
                oReglementFournisseur.Rowvers = mLigne.rowvers;

                mListe.Add(oReglementFournisseur);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de ReglementFournisseur
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementFournisseur.PS_ReglementFournisseur_UP(
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
