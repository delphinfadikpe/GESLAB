using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGC.DataAccess.GestionDeStock.GestionDeStockDataSetTableAdapters;
using LGC.DataAccess.GestionDeStock;

namespace LGC.Business.GestionDeStock
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandeIntrant
    {
        #region Constructeurs
        public CommandeIntrant()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal numCommande;
        private Decimal idPersonne;
        private DateTime dateCommande;
        private DateTime dateLivraisonPrevu;
        private DateTime dateDerniereLivraison;
        private string statut;
        private Decimal montantGlobale;
        private bool estAnnule;
        private DateTime dateAnnulation;
        private string motifAnnulation;
        private string fournisseur;

       
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
        public Decimal NumCommande
        {
            get { return numCommande; }
            set { numCommande = value; }
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
        public DateTime DateCommande
        {
            get { return dateCommande; }
            set { dateCommande = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateLivraisonPrevu
        {
            get { return dateLivraisonPrevu; }
            set { dateLivraisonPrevu = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateDerniereLivraison
        {
            get { return dateDerniereLivraison; }
            set { dateDerniereLivraison = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Statut
        {
            get { return statut.Trim(); }
            set { statut = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantGlobale
        {
            get { return montantGlobale; }
            set { montantGlobale = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstAnnule
        {
            get { return estAnnule; }
            set { estAnnule = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateAnnulation
        {
            get { return dateAnnulation; }
            set { dateAnnulation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MotifAnnulation
        {
            get { return motifAnnulation.Trim(); }
            set { motifAnnulation = value; }
        }

        public string Fournisseur
        {
            get { return fournisseur; }
            set { fournisseur = value; }
        }
        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de CommandeIntrant
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de CommandeIntrant
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de CommandeIntrant
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de CommandeIntrant
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de CommandeIntrant
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de CommandeIntrant
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de CommandeIntrant
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
        private static T_CommandeIntrantTableAdapter adapCommandeIntrant = new T_CommandeIntrantTableAdapter();
        private static GestionDeStockDataSet.T_CommandeIntrantDataTable dtCommandeIntrant = new GestionDeStockDataSet.T_CommandeIntrantDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de CommandeIntrant
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapCommandeIntrant.PS_CommandeIntrant_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de CommandeIntrant
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapCommandeIntrant.PS_CommandeIntrant_IP(
                numCommande,
                idPersonne,
                dateCommande,
                dateLivraisonPrevu,
                dateDerniereLivraison,
                Statut,
                montantGlobale,
                estAnnule,
                dateAnnulation,
                motifAnnulation,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de CommandeIntrant
        /// </summary>
        /// <param name="numCommande"></param>
        /// <param name="idPersonne"></param>
        /// <param name="dateCommande"></param>
        /// <param name="dateLivraisonPrevu"></param>
        /// <param name="dateDerniereLivraison"></param>
        /// <param name="Statut"></param>
        /// <param name="montantGlobale"></param>
        /// <param name="estAnnule"></param>
        /// <param name="dateAnnulation"></param>
        /// <param name="motifAnnulation"></param>
        /// <param name="numLigne">Le Numéro de Ligne de CommandeIntrant</param>
        /// <param name="dateCreationServeur">La date de création de CommandeIntrant</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de CommandeIntrant</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de CommandeIntrant</param>
        /// <param name="userLogin">Le User Login de CommandeIntrant</param>
        /// <param name="supprimer">Supprimer de CommandeIntrant</param>
        /// <param name="rowvers">Version de ligne de CommandeIntrant</param>
        /// <returns>Liste CommandeIntrant</returns>
        public static List<CommandeIntrant> Liste(
             Decimal? mNumCommande,
             Decimal? mIdPersonne,
             DateTime? mDateCommande,
             DateTime? mDateLivraisonPrevu,
             DateTime? mDateDerniereLivraison,
             string mStatut,
             Decimal? mMontantGlobale,
             bool? mEstAnnule,
             DateTime? mDateAnnulation,
             string mMotifAnnulation,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtCommandeIntrant = adapCommandeIntrant.PS_CommandeIntrant_SP(
                mNumCommande,
                mIdPersonne,
                mDateCommande,
                mDateLivraisonPrevu,
                mDateDerniereLivraison,
                mStatut,
                mMontantGlobale,
                mEstAnnule,
                mDateAnnulation,
                mMotifAnnulation,
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
        /// Retourne la liste des CommandeIntrant
        /// </summary>
        /// <returns>Liste CommandeIntrant</returns>
        private static List<CommandeIntrant> pListe()
        {
            List<CommandeIntrant> mListe = new List<CommandeIntrant>();
            foreach (GestionDeStockDataSet.T_CommandeIntrantRow mLigne in dtCommandeIntrant)
            {
                CommandeIntrant oCommandeIntrant = new CommandeIntrant();
                oCommandeIntrant.NumCommande = mLigne.numCommande;
                oCommandeIntrant.IdPersonne = mLigne.idPersonne;
                oCommandeIntrant.DateCommande = mLigne.dateCommande;
                oCommandeIntrant.DateLivraisonPrevu = mLigne.dateLivraisonPrevu;
                oCommandeIntrant.DateDerniereLivraison = mLigne.dateDerniereLivraison;
                oCommandeIntrant.Statut = mLigne.Statut.Trim();
                oCommandeIntrant.MontantGlobale = mLigne.montantGlobale;
                oCommandeIntrant.EstAnnule = mLigne.estAnnule;
                oCommandeIntrant.DateAnnulation = mLigne.dateAnnulation;
                oCommandeIntrant.MotifAnnulation = mLigne.motifAnnulation.Trim();
                oCommandeIntrant.NumLigne = mLigne.numLigne;
                oCommandeIntrant.DateCreationServeur = mLigne.dateCreationServeur;
                oCommandeIntrant.DateDernModifClient = mLigne.dateDernModifClient;
                oCommandeIntrant.DateDernModifServeur = mLigne.dateDernModifServeur;
                oCommandeIntrant.UserLogin = mLigne.userLogin.Trim();
                oCommandeIntrant.Supprimer = mLigne.supprimer;
                oCommandeIntrant.Rowvers = mLigne.rowvers;
                oCommandeIntrant.Fournisseur = mLigne.fournisseur;
                mListe.Add(oCommandeIntrant);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de CommandeIntrant
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapCommandeIntrant.PS_CommandeIntrant_UP(
                numCommande,
                idPersonne,
                dateCommande,
                dateLivraisonPrevu,
                dateDerniereLivraison,
                Statut,
                montantGlobale,
                estAnnule,
                dateAnnulation,
                motifAnnulation,
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
