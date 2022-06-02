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
    public class IntrantLivrer
    {
        #region Constructeurs
        public IntrantLivrer()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal numCommande;
        private string codeIntrant;
        private Decimal numLivraison;
        private Decimal qteLivree;
        private Decimal prixRevient;
        private Decimal montantBrut;
        private string intrant;
        private string libelleTypeCoffret;
        private string codeTypeCoffret;
        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private DateTime dateCreationServeur;
        private DateTime dateDernModifClient;
        private DateTime dateDernModifServeur;
        private Byte[] rowvers;
        private bool supprimer;
        private string userLogin;
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

        public string CodeTypeCoffret
        {
            get { return codeTypeCoffret; }
            set { codeTypeCoffret = value; }
        }

        public string LibelleTypeCoffret
        {
            get { return libelleTypeCoffret; }
            set { libelleTypeCoffret = value; }
        }

        public string Intrant
        {
            get { return intrant; }
            set { intrant = value; }
        }
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
        public string CodeIntrant
        {
            get { return codeIntrant.Trim(); }
            set { codeIntrant = value; }
        }

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
        public Decimal QteLivree
        {
            get { return qteLivree; }
            set { qteLivree = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal PrixRevient
        {
            get { return prixRevient; }
            set { prixRevient = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantBrut
        {
            get { return montantBrut; }
            set { montantBrut = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de IntrantLivrer
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de IntrantLivrer
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de IntrantLivrer
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de IntrantLivrer
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Version de ligne de IntrantLivrer
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// Supprimer de IntrantLivrer
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de IntrantLivrer
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        #endregion Passe partout
        #endregion Elémentaires

        #region Objets

        #endregion Objets

        #region Collections

        #endregion Collections
        #endregion Propriétés

        #region Variables
        private static TJ_IntrantLivrerTableAdapter adapIntrantLivrer = new TJ_IntrantLivrerTableAdapter();
        private static GestionDeStockDataSet.TJ_IntrantLivrerDataTable dtIntrantLivrer = new GestionDeStockDataSet.TJ_IntrantLivrerDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de IntrantLivrer
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantLivrer.PS_IntrantLivrer_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de IntrantLivrer
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantLivrer.PS_IntrantLivrer_IP(
                numCommande,
                codeIntrant,
                numLivraison,codeTypeCoffret,
                qteLivree,
                prixRevient,
                montantBrut,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de IntrantLivrer
        /// </summary>
        /// <param name="numCommande"></param>
        /// <param name="codeIntrant"></param>
        /// <param name="numLivraison"></param>
        /// <param name="qteLivree"></param>
        /// <param name="prixRevient"></param>
        /// <param name="montantBrut"></param>
        /// <param name="numLigne">Le Numéro de Ligne de IntrantLivrer</param>
        /// <param name="dateCreationServeur">La date de création de IntrantLivrer</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de IntrantLivrer</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de IntrantLivrer</param>
        /// <param name="rowvers">Version de ligne de IntrantLivrer</param>
        /// <param name="supprimer">Supprimer de IntrantLivrer</param>
        /// <param name="userLogin">Le User Login de IntrantLivrer</param>
        /// <returns>Liste IntrantLivrer</returns>
        public static List<IntrantLivrer> Liste(
             Decimal? mNumCommande,
             string mCodeIntrant,
             Decimal? mNumLivraison,
            string mCodeTypeCoffret,
             Decimal? mQteLivree,
             Decimal? mPrixRevient,
             Decimal? mMontantBrut,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             Byte[] mRowvers,
             bool? mSupprimer,
             string mUserLogin)
        {
            dtIntrantLivrer = adapIntrantLivrer.PS_IntrantLivrer_SP(
                mNumCommande,
                mCodeIntrant,
                mNumLivraison,mCodeTypeCoffret,
                mQteLivree,
                mPrixRevient,
                mMontantBrut,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mRowvers,
                mSupprimer,
                mUserLogin);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des IntrantLivrer
        /// </summary>
        /// <returns>Liste IntrantLivrer</returns>
        private static List<IntrantLivrer> pListe()
        {
            List<IntrantLivrer> mListe = new List<IntrantLivrer>();
            foreach (GestionDeStockDataSet.TJ_IntrantLivrerRow mLigne in dtIntrantLivrer)
            {
                IntrantLivrer oIntrantLivrer = new IntrantLivrer();
                oIntrantLivrer.NumCommande = mLigne.numCommande;
                oIntrantLivrer.CodeIntrant = mLigne.codeIntrant.Trim();
                oIntrantLivrer.NumLivraison = mLigne.numLivraison;
                oIntrantLivrer.QteLivree = mLigne.qteLivree;
                oIntrantLivrer.PrixRevient = mLigne.prixRevient;
                oIntrantLivrer.MontantBrut = mLigne.montantBrut;
                oIntrantLivrer.NumLigne = mLigne.numLigne;
                oIntrantLivrer.DateCreationServeur = mLigne.dateCreationServeur;
                oIntrantLivrer.DateDernModifClient = mLigne.dateDernModifClient;
                oIntrantLivrer.DateDernModifServeur = mLigne.dateDernModifServeur;
                oIntrantLivrer.Rowvers = mLigne.rowvers;
                oIntrantLivrer.Supprimer = mLigne.supprimer;
                oIntrantLivrer.UserLogin = mLigne.userLogin.Trim();
                oIntrantLivrer.Intrant = mLigne.Intrant.Trim();
                oIntrantLivrer.CodeTypeCoffret = mLigne.codeTypeCoffret.Trim();
                oIntrantLivrer.LibelleTypeCoffret = mLigne.coffret.Trim();
                mListe.Add(oIntrantLivrer);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de IntrantLivrer
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantLivrer.PS_IntrantLivrer_UP(
                numCommande,
                codeIntrant,codeTypeCoffret,
                numLivraison,
                qteLivree,
                prixRevient,
                montantBrut,
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

