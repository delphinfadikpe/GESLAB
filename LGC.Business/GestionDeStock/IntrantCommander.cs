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
    public class IntrantCommander
    {
        #region Constructeurs
        public IntrantCommander()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal numCommande;
        private string codeIntrant;
        private Decimal qteCommande;
        private string libelleIntrant;
        private Decimal qteLivree;
        private Decimal qteRestante;
        private Decimal prixUnitaire;
        private Decimal montantBut;
        private string intrant;
        private string libelleTypeCoffret;
        private Decimal codeTypeCoffret;

        
       
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

        public Decimal CodeTypeCoffret
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
        public Decimal QteCommande
        {
            get { return qteCommande; }
            set { qteCommande = value; }
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
        public Decimal QteRestante
        {
            get { return qteRestante; }
            set { qteRestante = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal PrixUnitaire
        {
            get { return prixUnitaire; }
            set { prixUnitaire = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantBut
        {
            get { return montantBut; }
            set { montantBut = value; }
        }

        public string LibelleIntrant
        {
            get { return libelleIntrant; }
            set { libelleIntrant = value; }
        }
        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de IntrantCommander
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de IntrantCommander
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de IntrantCommander
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de IntrantCommander
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Version de ligne de IntrantCommander
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// Supprimer de IntrantCommander
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de IntrantCommander
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
        private static TJ_IntrantCommanderTableAdapter adapIntrantCommander = new TJ_IntrantCommanderTableAdapter();
        private static GestionDeStockDataSet.TJ_IntrantCommanderDataTable dtIntrantCommander = new GestionDeStockDataSet.TJ_IntrantCommanderDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de IntrantCommander
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantCommander.PS_IntrantCommander_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de IntrantCommander
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantCommander.PS_IntrantCommander_IP(
                numCommande,
                codeIntrant,
                codeTypeCoffret,
                qteCommande,
                qteLivree,
                qteRestante,
                prixUnitaire,
                montantBut,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de IntrantCommander
        /// </summary>
        /// <param name="numCommande"></param>
        /// <param name="codeIntrant"></param>
        /// <param name="qteCommande"></param>
        /// <param name="qteLivree"></param>
        /// <param name="qteRestante"></param>
        /// <param name="prixUnitaire"></param>
        /// <param name="montantBut"></param>
        /// <param name="numLigne">Le Numéro de Ligne de IntrantCommander</param>
        /// <param name="dateCreationServeur">La date de création de IntrantCommander</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de IntrantCommander</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de IntrantCommander</param>
        /// <param name="rowvers">Version de ligne de IntrantCommander</param>
        /// <param name="supprimer">Supprimer de IntrantCommander</param>
        /// <param name="userLogin">Le User Login de IntrantCommander</param>
        /// <returns>Liste IntrantCommander</returns>
        public static List<IntrantCommander> Liste(
             Decimal? mNumCommande,
             string mCodeIntrant,
            Decimal? mCodeTypeCoffret,
             Decimal? mQteCommande,
             Decimal? mQteLivree,
             Decimal? mQteRestante,
             Decimal? mPrixUnitaire,
             Decimal? mMontantBut,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             Byte[] mRowvers,
             bool? mSupprimer,
             string mUserLogin)
        {
            dtIntrantCommander = adapIntrantCommander.PS_IntrantCommander_SP(
                mNumCommande,
                mCodeIntrant,
                mCodeTypeCoffret,
                mQteCommande,
                mQteLivree,
                mQteRestante,
                mPrixUnitaire,
                mMontantBut,
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
        /// Retourne la liste des IntrantCommander
        /// </summary>
        /// <returns>Liste IntrantCommander</returns>
        private static List<IntrantCommander> pListe()
        {
            List<IntrantCommander> mListe = new List<IntrantCommander>();
            foreach (GestionDeStockDataSet.TJ_IntrantCommanderRow mLigne in dtIntrantCommander)
            {
                IntrantCommander oIntrantCommander = new IntrantCommander();
                oIntrantCommander.NumCommande = mLigne.numCommande;
                oIntrantCommander.CodeIntrant = mLigne.codeIntrant.Trim();
                oIntrantCommander.QteCommande = mLigne.qteCommande;
                oIntrantCommander.QteLivree = mLigne.qteLivree;
                oIntrantCommander.QteRestante = mLigne.qteRestante;
                oIntrantCommander.PrixUnitaire = mLigne.prixUnitaire;
                oIntrantCommander.MontantBut = mLigne.montantBut;
                oIntrantCommander.NumLigne = mLigne.numLigne;
                oIntrantCommander.DateCreationServeur = mLigne.dateCreationServeur;
                oIntrantCommander.DateDernModifClient = mLigne.dateDernModifClient;
                oIntrantCommander.DateDernModifServeur = mLigne.dateDernModifServeur;
                oIntrantCommander.Rowvers = mLigne.rowvers;
                oIntrantCommander.Supprimer = mLigne.supprimer;
                oIntrantCommander.UserLogin = mLigne.userLogin.Trim();
                oIntrantCommander.Intrant = mLigne.Intrant.Trim();
                oIntrantCommander.CodeTypeCoffret = mLigne.codeTypeCoffret;
                oIntrantCommander.LibelleTypeCoffret = mLigne.coffret.Trim();

                mListe.Add(oIntrantCommander);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de IntrantCommander
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantCommander.PS_IntrantCommander_UP(
                numCommande,
                codeIntrant,
                codeTypeCoffret,
                qteCommande,
                qteLivree,
                qteRestante,
                prixUnitaire,
                montantBut,
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
