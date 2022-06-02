//Fichier :		 InventaireProduit.cs
//Auteur :		 Derrick TOIHOUN
//Créer le :		 Jeudi 27 Août 2015
//Description :		 Le fichier de classe

using LGC.DataAccess.GestionDeStock;
using LGC.DataAccess.GestionDeStock.GestionDeStockDataSetTableAdapters;
//using LGG.DataAccess.AutresOperations;
//using LGG.DataAccess.AutresOperations.AutresOperationsDataSetTableAdapters;
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
    public class InventaireIntrant
    {
        #region Constructeurs
        public InventaireIntrant()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal numeroInventaire;
        private string codeIntrant;
        private Decimal stockLogique;
        private Decimal stockPhysique;
        private Decimal ecart;
        private string motif;
        private string libelleIntrant;

        private string libelleCategorie;

       
        private bool estRegulariserSurPhysique;
        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private DateTime dateCreationServeur;
        private DateTime dateDernModifClient;
        private Byte[] rowvers;
        private DateTime dateDernModifServeur;
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
        public string LibelleCategorie
        {
            get { return libelleCategorie; }
            set { libelleCategorie = value; }
        }

        public string LibelleIntrant
        {
            get { return libelleIntrant; }
            set { libelleIntrant = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Decimal NumeroInventaire
        {
            get { return numeroInventaire; }
            set { numeroInventaire = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodeIntrant
        {
            get { return codeIntrant; }
            set { codeIntrant = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal StockLogique
        {
            get { return stockLogique; }
            set { stockLogique = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal StockPhysique
        {
            get { return stockPhysique; }
            set { stockPhysique = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Ecart
        {
            get { return ecart; }
            set { ecart = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Motif
        {
            get { return motif; }
            set { motif = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstRegulariserSurPhysique
        {
            get { return estRegulariserSurPhysique; }
            set { estRegulariserSurPhysique = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de InventaireIntrant
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de InventaireIntrant
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de InventaireIntrant
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// Version de ligne de InventaireIntrant
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de InventaireIntrant
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Supprimer de InventaireIntrant
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de InventaireIntrant
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
        private static TJ_InventaireIntrantTableAdapter adapInventaireIntrant = new TJ_InventaireIntrantTableAdapter();
        private static GestionDeStockDataSet.TJ_InventaireIntrantDataTable dtInventaireIntrant = new GestionDeStockDataSet.TJ_InventaireIntrantDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de InventaireIntrant
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapInventaireIntrant.PS_InventaireIntrant_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de InventaireIntrant
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapInventaireIntrant.PS_InventaireIntrant_IP(
                numeroInventaire,
                codeIntrant,
                stockLogique,
                stockPhysique,
                ecart,
                motif,
                estRegulariserSurPhysique,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de InventaireIntrant
        /// </summary>
        /// <param name="numeroInventaire"></param>
        /// <param name="codeIntrant"></param>
        /// <param name="stockLogique"></param>
        /// <param name="stockPhysique"></param>
        /// <param name="ecart"></param>
        /// <param name="motif"></param>
        /// <param name="estRegulariserSurPhysique"></param>
        /// <param name="numLigne">Le Numéro de Ligne de InventaireIntrant</param>
        /// <param name="dateCreationServeur">La date de création de InventaireIntrant</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de InventaireIntrant</param>
        /// <param name="rowvers">Version de ligne de InventaireIntrant</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de InventaireIntrant</param>
        /// <param name="supprimer">Supprimer de InventaireIntrant</param>
        /// <param name="userLogin">Le User Login de InventaireIntrant</param>
        /// <returns>Liste InventaireIntrant</returns>
        public static List<InventaireIntrant> Liste(
             Decimal? mNumeroInventaire,
             string mCodeIntrant,
             Decimal? mStockLogique,
             Decimal? mStockPhysique,
             Decimal? mEcart,
             string mMotif,
             bool? mEstRegulariserSurPhysique,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             Byte[] mRowvers,
             DateTime? mDateDernModifServeur,
             bool? mSupprimer,
             string mUserLogin)
        {
            dtInventaireIntrant = adapInventaireIntrant.PS_InventaireIntrant_SP(
                mNumeroInventaire,
                mCodeIntrant,
                mStockLogique,
                mStockPhysique,
                mEcart,
                mMotif,
                mEstRegulariserSurPhysique,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mRowvers,
                mDateDernModifServeur,
                mSupprimer,
                mUserLogin);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des InventaireIntrant
        /// </summary>
        /// <returns>Liste InventaireIntrant</returns>
        private static List<InventaireIntrant> pListe()
        {
            List<InventaireIntrant> mListe = new List<InventaireIntrant>();
            foreach (GestionDeStockDataSet.TJ_InventaireIntrantRow mLigne in dtInventaireIntrant)
            {
                InventaireIntrant oInventaireIntrant = new InventaireIntrant();
                oInventaireIntrant.NumeroInventaire = mLigne.numeroInventaire;
                oInventaireIntrant.LibelleCategorie = mLigne.libelleCategorie.Trim();
                oInventaireIntrant.LibelleIntrant = mLigne.libelleIntrant.Trim();
                oInventaireIntrant.CodeIntrant = mLigne.codeIntrant.Trim();
                oInventaireIntrant.StockLogique = mLigne.stockLogique;
                oInventaireIntrant.StockPhysique = mLigne.stockPhysique;
                oInventaireIntrant.Ecart = mLigne.ecart;
                oInventaireIntrant.Motif = mLigne.motif.Trim();
                oInventaireIntrant.EstRegulariserSurPhysique = mLigne.estRegulariserSurPhysique;
                oInventaireIntrant.NumLigne = mLigne.numLigne;
                oInventaireIntrant.DateCreationServeur = mLigne.dateCreationServeur;
                oInventaireIntrant.DateDernModifClient = mLigne.dateDernModifClient;
                oInventaireIntrant.Rowvers = mLigne.rowvers;
                oInventaireIntrant.DateDernModifServeur = mLigne.dateDernModifServeur;
                oInventaireIntrant.Supprimer = mLigne.supprimer;
                oInventaireIntrant.UserLogin = mLigne.userLogin.Trim();

                mListe.Add(oInventaireIntrant);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de InventaireIntrant
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapInventaireIntrant.PS_InventaireIntrant_UP(
                numeroInventaire,
                codeIntrant,
                stockLogique,
                stockPhysique,
                ecart,
                motif,
                estRegulariserSurPhysique,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }


        public static void deleteAll(string mNumeroInventaire)
        {
            adapInventaireIntrant.PS_InventaireIntrant_DPA(mNumeroInventaire);
        }

        #endregion Interfaces

        #region Gestion des collections

        #endregion Gestion des collections

        #region Métier

        #endregion Métier
        #endregion Méthodes
    }
}

