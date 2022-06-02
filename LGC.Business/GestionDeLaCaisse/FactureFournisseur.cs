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
    public class FactureFournisseur
    {
        #region Constructeurs
        public FactureFournisseur()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string cheminFichierFacture;
        private DateTime dateFacture;
        private Decimal idPersonne;
        private Decimal montantFacture;
        private Decimal montantRestantAPayer;
        private string fournisseur;
        private string estSolde;
       
        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private DateTime dateCreationServeur;
        private DateTime dateDernModifClient;
        private DateTime dateDernModifServeur;
        private string userLogin;
        private bool supprimer;
        private Byte[] rowvers;
        private Decimal montantBrut;
        private Decimal remise;
        private Decimal tva;
        private Decimal aib;
        private string reference;
        private string idFacture;
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

        public string EstSolde
        {
            get { return estSolde; }
            set { estSolde = value; }
        }


        public string Fournisseur
        {
            get { return fournisseur; }
            set { fournisseur = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CheminFichierFacture
        {
            get { return cheminFichierFacture.Trim(); }
            set { cheminFichierFacture = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateFacture
        {
            get { return dateFacture; }
            set { dateFacture = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal IdPersonne
        {
            get { return idPersonne; }
            set { idPersonne = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantFacture
        {
            get { return montantFacture; }
            set { montantFacture = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantRestantAPayer
        {
            get { return montantRestantAPayer; }
            set { montantRestantAPayer = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de FactureFournisseur
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de FactureFournisseur
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de FactureFournisseur
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de FactureFournisseur
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de FactureFournisseur
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de FactureFournisseur
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de FactureFournisseur
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantBrut
        {
            get { return montantBrut; }
            set { montantBrut = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Remise
        {
            get { return remise; }
            set { remise = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Tva
        {
            get { return tva; }
            set { tva = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Aib
        {
            get { return aib; }
            set { aib = value; }
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
        public string IdFacture
        {
            get { return idFacture.Trim(); }
            set { idFacture = value; }
        }

        #endregion Passe partout
        #endregion Elémentaires

        #region Objets

        #endregion Objets

        #region Collections

        #endregion Collections
        #endregion Propriétés

        #region Variables
        private static TJ_FactureFournisseurTableAdapter adapFactureFournisseur = new TJ_FactureFournisseurTableAdapter();
        private static GestionDeLaCaisseDataSet.TJ_FactureFournisseurDataTable dtFactureFournisseur = new GestionDeLaCaisseDataSet.TJ_FactureFournisseurDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de FactureFournisseur
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFactureFournisseur.PS_FactureFournisseur_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de FactureFournisseur
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFactureFournisseur.PS_FactureFournisseur_IP(
                cheminFichierFacture,
                dateFacture,
                idPersonne,
                montantFacture,
                montantRestantAPayer,
                montantBrut,
                remise,
                tva,
                aib,
                reference,
                idFacture,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de FactureFournisseur
        /// </summary>
        /// <param name="cheminFichierFacture"></param>
        /// <param name="dateFacture"></param>
        /// <param name="idPersonne"></param>
        /// <param name="montantFacture"></param>
        /// <param name="montantRestantAPayer"></param>
        /// <param name="numLigne">Le Numéro de Ligne de FactureFournisseur</param>
        /// <param name="dateCreationServeur">La date de création de FactureFournisseur</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de FactureFournisseur</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de FactureFournisseur</param>
        /// <param name="userLogin">Le User Login de FactureFournisseur</param>
        /// <param name="supprimer">Supprimer de FactureFournisseur</param>
        /// <param name="rowvers">Version de ligne de FactureFournisseur</param>
        /// <param name="montantBrut"></param>
        /// <param name="remise"></param>
        /// <param name="tva"></param>
        /// <param name="aib"></param>
        /// <param name="reference"></param>
        /// <param name="idFacture"></param>
        /// <returns>Liste FactureFournisseur</returns>
        public static List<FactureFournisseur> Liste(
             string mCheminFichierFacture,
             DateTime? mDateFacture,
             Decimal? mIdPersonne,
             Decimal? mMontantFacture,
             Decimal? mMontantRestantAPayer,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers,
             Decimal? mMontantBrut,
             Decimal? mRemise,
             Decimal? mTva,
             Decimal? mAib,
             string mReference,
             string mIdFacture)
        {
            dtFactureFournisseur = adapFactureFournisseur.PS_FactureFournisseur_SP(
                mCheminFichierFacture,
                mDateFacture,
                mIdPersonne,
                mMontantFacture,
                mMontantRestantAPayer,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mUserLogin,
                mSupprimer,
                mRowvers,
                mMontantBrut,
                mRemise,
                mTva,
                mAib,
                mReference,
                mIdFacture);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des FactureFournisseur
        /// </summary>
        /// <returns>Liste FactureFournisseur</returns>
        private static List<FactureFournisseur> pListe()
        {
            List<FactureFournisseur> mListe = new List<FactureFournisseur>();
            foreach (GestionDeLaCaisseDataSet.TJ_FactureFournisseurRow mLigne in dtFactureFournisseur)
            {
                FactureFournisseur oFactureFournisseur = new FactureFournisseur();
                oFactureFournisseur.CheminFichierFacture = mLigne.cheminFichierFacture.Trim();
                oFactureFournisseur.DateFacture = mLigne.dateFacture;
                oFactureFournisseur.IdPersonne = mLigne.idPersonne;
                oFactureFournisseur.MontantFacture = mLigne.montantFacture;
                oFactureFournisseur.MontantRestantAPayer = mLigne.montantRestantAPayer;
                oFactureFournisseur.NumLigne = mLigne.numLigne;
                oFactureFournisseur.DateCreationServeur = mLigne.dateCreationServeur;
                oFactureFournisseur.DateDernModifClient = mLigne.dateDernModifClient;
                oFactureFournisseur.DateDernModifServeur = mLigne.dateDernModifServeur;
                oFactureFournisseur.UserLogin = mLigne.userLogin.Trim();
                oFactureFournisseur.Supprimer = mLigne.supprimer;
                oFactureFournisseur.Rowvers = mLigne.rowvers;
                oFactureFournisseur.MontantBrut = mLigne.montantBrut;
                oFactureFournisseur.Remise = mLigne.remise;
                oFactureFournisseur.Tva = mLigne.tva;
                oFactureFournisseur.Aib = mLigne.aib;
                oFactureFournisseur.Reference = mLigne.reference.Trim();
                oFactureFournisseur.IdFacture = mLigne.idFacture.Trim();
                oFactureFournisseur.Fournisseur = mLigne.fournisseur.Trim();
                oFactureFournisseur.EstSolde = mLigne.montantRestantAPayer == 0 ? "SOLDEES" : "NON SOLDEES";
                mListe.Add(oFactureFournisseur);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de FactureFournisseur
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFactureFournisseur.PS_FactureFournisseur_UP(
                cheminFichierFacture,
                dateFacture,
                idPersonne,
                montantFacture,
                montantRestantAPayer,
                montantBrut,
                remise,
                tva,
                aib,
                reference,
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
