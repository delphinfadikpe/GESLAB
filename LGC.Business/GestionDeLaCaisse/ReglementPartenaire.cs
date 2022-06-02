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
    public class ReglementPartenaire
    {
        #region Constructeurs
        public ReglementPartenaire()
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
        /// Le Numéro de Ligne de ReglementPartenaire
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de ReglementPartenaire
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de ReglementPartenaire
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de ReglementPartenaire
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de ReglementPartenaire
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de ReglementPartenaire
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de ReglementPartenaire
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
        private static T_ReglementPartenaireTableAdapter adapReglementPartenaire = new T_ReglementPartenaireTableAdapter();
        private static GestionDeLaCaisseDataSet.T_ReglementPartenaireDataTable dtReglementPartenaire = new GestionDeLaCaisseDataSet.T_ReglementPartenaireDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de ReglementPartenaire
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementPartenaire.PS_ReglementPartenaire_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de ReglementPartenaire
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementPartenaire.PS_ReglementPartenaire_IP(
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
        /// Retourne la liste de ReglementPartenaire
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
        /// <param name="numLigne">Le Numéro de Ligne de ReglementPartenaire</param>
        /// <param name="dateCreationServeur">La date de création de ReglementPartenaire</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de ReglementPartenaire</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ReglementPartenaire</param>
        /// <param name="userLogin">Le User Login de ReglementPartenaire</param>
        /// <param name="supprimer">Supprimer de ReglementPartenaire</param>
        /// <param name="rowvers">Version de ligne de ReglementPartenaire</param>
        /// <returns>Liste ReglementPartenaire</returns>
        public static List<ReglementPartenaire> Liste(
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
            dtReglementPartenaire = adapReglementPartenaire.PS_ReglementPartenaire_SP(mIdFacture,
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
        /// Retourne la liste des ReglementPartenaire
        /// </summary>
        /// <returns>Liste ReglementPartenaire</returns>
        private static List<ReglementPartenaire> pListe()
        {
            List<ReglementPartenaire> mListe = new List<ReglementPartenaire>();
            foreach (GestionDeLaCaisseDataSet.T_ReglementPartenaireRow mLigne in dtReglementPartenaire)
            {
                ReglementPartenaire oReglementPartenaire = new ReglementPartenaire();
                oReglementPartenaire.IdReglement = mLigne.idReglement;
                oReglementPartenaire.IdOparation = mLigne.idOparation;
                oReglementPartenaire.ModeReglement = mLigne.modeReglement.Trim();
                oReglementPartenaire.Reference = mLigne.reference.Trim();
                oReglementPartenaire.TypeReglement = mLigne.typeReglement;
                oReglementPartenaire.DateOperation = mLigne.dateOperation;
                oReglementPartenaire.MontantAregler = mLigne.montantAregler;
                oReglementPartenaire.Montant = mLigne.montant;
                oReglementPartenaire.MontantRestantDue = mLigne.montantRestantDue;
                oReglementPartenaire.NumLigne = mLigne.numLigne;
                oReglementPartenaire.DateCreationServeur = mLigne.dateCreationServeur;
                oReglementPartenaire.DateDernModifClient = mLigne.dateDernModifClient;
                oReglementPartenaire.DateDernModifServeur = mLigne.dateDernModifServeur;
                oReglementPartenaire.UserLogin = mLigne.userLogin.Trim();
                oReglementPartenaire.Supprimer = mLigne.supprimer;
                oReglementPartenaire.Rowvers = mLigne.rowvers;

                mListe.Add(oReglementPartenaire);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de ReglementPartenaire
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapReglementPartenaire.PS_ReglementPartenaire_UP(
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
