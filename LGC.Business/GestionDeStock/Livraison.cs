using LGC.DataAccess.GestionDeStock;
using LGC.DataAccess.GestionDeStock.GestionDeStockDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGC.Business.GestionDeStock
{
    /// <summary>
    /// 
    /// </summary>
    public class Livraison
    {
        #region Constructeurs
        public Livraison()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal numLivraison;
        private DateTime dateLivraison;
        private Decimal tVA;
        private Decimal motantBrut;
        private Decimal aIB;
        private Decimal remise;
        private Decimal montantNet;
        private DateTime dateAnnulation;
        private string motifAnnulation;
        private bool estAnnule;
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
        public Decimal NumLivraison
        {
            get { return numLivraison; }
            set { numLivraison = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateLivraison
        {
            get { return dateLivraison; }
            set { dateLivraison = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal TVA
        {
            get { return tVA; }
            set { tVA = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MotantBrut
        {
            get { return motantBrut; }
            set { motantBrut = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal AIB
        {
            get { return aIB; }
            set { aIB = value; }
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
        public Decimal MontantNet
        {
            get { return montantNet; }
            set { montantNet = value; }
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

        /// <summary>
        /// 
        /// </summary>
        public bool EstAnnule
        {
            get { return estAnnule; }
            set { estAnnule = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Livraison
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Livraison
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Livraison
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Livraison
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Livraison
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Livraison
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Livraison
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
        private static T_LivraisonTableAdapter adapLivraison = new T_LivraisonTableAdapter();
        private static GestionDeStockDataSet.T_LivraisonDataTable dtLivraison = new GestionDeStockDataSet.T_LivraisonDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Livraison
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapLivraison.PS_Livraison_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Livraison
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapLivraison.PS_Livraison_IP(
                numLivraison,
                dateLivraison,
                TVA,
                motantBrut,
                AIB,
                remise,
                montantNet,
                dateAnnulation,
                motifAnnulation,
                estAnnule,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Livraison
        /// </summary>
        /// <param name="numLivraison"></param>
        /// <param name="dateLivraison"></param>
        /// <param name="TVA"></param>
        /// <param name="motantBrut"></param>
        /// <param name="AIB"></param>
        /// <param name="remise"></param>
        /// <param name="montantNet"></param>
        /// <param name="dateAnnulation"></param>
        /// <param name="motifAnnulation"></param>
        /// <param name="estAnnule"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Livraison</param>
        /// <param name="dateCreationServeur">La date de création de Livraison</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Livraison</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Livraison</param>
        /// <param name="userLogin">Le User Login de Livraison</param>
        /// <param name="supprimer">Supprimer de Livraison</param>
        /// <param name="rowvers">Version de ligne de Livraison</param>
        /// <returns>Liste Livraison</returns>
        public static List<Livraison> Liste(
             Decimal? mNumLivraison,
             DateTime? mDateLivraison,
             Decimal? mTVA,
             Decimal? mMotantBrut,
             Decimal? mAIB,
             Decimal? mRemise,
             Decimal? mMontantNet,
             DateTime? mDateAnnulation,
             string mMotifAnnulation,
             bool? mEstAnnule,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtLivraison = adapLivraison.PS_Livraison_SP(
                mNumLivraison,
                mDateLivraison,
                mTVA,
                mMotantBrut,
                mAIB,
                mRemise,
                mMontantNet,
                mDateAnnulation,
                mMotifAnnulation,
                mEstAnnule,
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
        /// Retourne la liste des Livraison
        /// </summary>
        /// <returns>Liste Livraison</returns>
        private static List<Livraison> pListe()
        {
            List<Livraison> mListe = new List<Livraison>();
            foreach (GestionDeStockDataSet.T_LivraisonRow mLigne in dtLivraison)
            {
                Livraison oLivraison = new Livraison();
                oLivraison.NumLivraison = mLigne.numLivraison;
                oLivraison.DateLivraison = mLigne.dateLivraison;
                oLivraison.TVA = mLigne.TVA;
                oLivraison.MotantBrut = mLigne.motantBrut;
                oLivraison.AIB = mLigne.AIB;
                oLivraison.Remise = mLigne.remise;
                oLivraison.MontantNet = mLigne.montantNet;
                oLivraison.DateAnnulation = mLigne.dateAnnulation;
                oLivraison.MotifAnnulation = mLigne.motifAnnulation.Trim();
                oLivraison.EstAnnule = mLigne.estAnnule;
                oLivraison.NumLigne = mLigne.numLigne;
                oLivraison.DateCreationServeur = mLigne.dateCreationServeur;
                oLivraison.DateDernModifClient = mLigne.dateDernModifClient;
                oLivraison.DateDernModifServeur = mLigne.dateDernModifServeur;
                oLivraison.UserLogin = mLigne.userLogin.Trim();
                oLivraison.Supprimer = mLigne.supprimer;
                oLivraison.Rowvers = mLigne.rowvers;

                mListe.Add(oLivraison);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Livraison
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapLivraison.PS_Livraison_UP(
                numLivraison,
                dateLivraison,
                TVA,
                motantBrut,
                AIB,
                remise,
                montantNet,
                dateAnnulation,
                motifAnnulation,
                estAnnule,
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

