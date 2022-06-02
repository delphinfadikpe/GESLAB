using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGC.DataAccess.GestionDeLaCaisse;
using LGC.DataAccess.GestionDeLaCaisse.GestionDeLaCaisseDataSetTableAdapters;

namespace LGC.Business.GestionDeLaCaisse
{
    /// <summary>
    /// 
    /// </summary>
    public class PaiementRistourne
    {
        #region Constructeurs
        public PaiementRistourne()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idPaiement;
        private Decimal idOparation;
        private DateTime datePaiement;
        private Decimal tauxRistourne;
        private Decimal montantRistourne;
        private Decimal montantGlobal;
        private string idFacture;
        private string partenaire;
        private DateTime dateDebut;
        private DateTime dateFin;

      
       
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

        public DateTime DateFin
        {
            get { return dateFin; }
            set { dateFin = value; }
        }
        public DateTime DateDebut
        {
            get { return dateDebut; }
            set { dateDebut = value; }
        }
        

        public string Partenaire
        {
            get { return partenaire; }
            set { partenaire = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Decimal IdPaiement
        {
            get { return idPaiement; }
            set { idPaiement = value; }
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
        public DateTime DatePaiement
        {
            get { return datePaiement; }
            set { datePaiement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal TauxRistourne
        {
            get { return tauxRistourne; }
            set { tauxRistourne = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantRistourne
        {
            get { return montantRistourne; }
            set { montantRistourne = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantGlobal
        {
            get { return montantGlobal; }
            set { montantGlobal = value; }
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
        /// Le Numéro de Ligne de PaiementRistourne
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de PaiementRistourne
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de PaiementRistourne
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de PaiementRistourne
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de PaiementRistourne
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de PaiementRistourne
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de PaiementRistourne
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
        private static T_PaiementRistourneTableAdapter adapPaiementRistourne = new T_PaiementRistourneTableAdapter();
        private static GestionDeLaCaisseDataSet.T_PaiementRistourneDataTable dtPaiementRistourne = new GestionDeLaCaisseDataSet.T_PaiementRistourneDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de PaiementRistourne
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPaiementRistourne.PS_PaiementRistourne_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de PaiementRistourne
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPaiementRistourne.PS_PaiementRistourne_IP(
                idPaiement,
                idOparation,
                datePaiement,
                tauxRistourne,
                montantRistourne,
                montantGlobal,
                idFacture,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de PaiementRistourne
        /// </summary>
        /// <param name="idPaiement"></param>
        /// <param name="idOparation"></param>
        /// <param name="datePaiement"></param>
        /// <param name="tauxRistourne"></param>
        /// <param name="montantRistourne"></param>
        /// <param name="montantGlobal"></param>
        /// <param name="idFacture"></param>
        /// <param name="numLigne">Le Numéro de Ligne de PaiementRistourne</param>
        /// <param name="dateCreationServeur">La date de création de PaiementRistourne</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de PaiementRistourne</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de PaiementRistourne</param>
        /// <param name="userLogin">Le User Login de PaiementRistourne</param>
        /// <param name="supprimer">Supprimer de PaiementRistourne</param>
        /// <param name="rowvers">Version de ligne de PaiementRistourne</param>
        /// <returns>Liste PaiementRistourne</returns>
        public static List<PaiementRistourne> Liste(
             Decimal? mIdPaiement,
             Decimal? mIdOparation,
             DateTime? mDatePaiement,
             Decimal? mTauxRistourne,
             Decimal? mMontantRistourne,
             Decimal? mMontantGlobal,
             string mIdFacture,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtPaiementRistourne = adapPaiementRistourne.PS_PaiementRistourne_SP(
                mIdPaiement,
                mIdOparation,
                mDatePaiement,
                mTauxRistourne,
                mMontantRistourne,
                mMontantGlobal,
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
        /// Retourne la liste des PaiementRistourne
        /// </summary>
        /// <returns>Liste PaiementRistourne</returns>
        private static List<PaiementRistourne> pListe()
        {
            List<PaiementRistourne> mListe = new List<PaiementRistourne>();
            foreach (GestionDeLaCaisseDataSet.T_PaiementRistourneRow mLigne in dtPaiementRistourne)
            {
                PaiementRistourne oPaiementRistourne = new PaiementRistourne();
                oPaiementRistourne.IdPaiement = mLigne.idPaiement;
                oPaiementRistourne.IdOparation = mLigne.idOparation;
                oPaiementRistourne.DatePaiement = mLigne.datePaiement;
                oPaiementRistourne.TauxRistourne = mLigne.tauxRistourne;
                oPaiementRistourne.MontantRistourne = mLigne.montantRistourne;
                oPaiementRistourne.MontantGlobal = mLigne.montantGlobal;
                oPaiementRistourne.IdFacture = mLigne.idFacture.Trim();
                oPaiementRistourne.NumLigne = mLigne.numLigne;
                oPaiementRistourne.DateCreationServeur = mLigne.dateCreationServeur;
                oPaiementRistourne.DateDernModifClient = mLigne.dateDernModifClient;
                oPaiementRistourne.DateDernModifServeur = mLigne.dateDernModifServeur;
                oPaiementRistourne.UserLogin = mLigne.userLogin.Trim();
                oPaiementRistourne.Supprimer = mLigne.supprimer;
                oPaiementRistourne.Rowvers = mLigne.rowvers;
                oPaiementRistourne.Partenaire = mLigne.partenaire;
                oPaiementRistourne.DateDebut = mLigne.dateDebut;
                oPaiementRistourne.DateFin = mLigne.dateFin;
                mListe.Add(oPaiementRistourne);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de PaiementRistourne
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPaiementRistourne.PS_PaiementRistourne_UP(
                idPaiement,
                idOparation,
                datePaiement,
                tauxRistourne,
                montantRistourne,
                montantGlobal,
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
