using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGC.DataAccess.GestionDeLaCaisse;
using LGC.DataAccess.GestionDeLaCaisse.GestionDeLaCaisseDataSetTableAdapters;


namespace LGC.Business.GestionDesAnalyses
{
    /// <summary>
    /// 
    /// </summary>
    public class AnalyseCommission
    {
        #region Constructeurs
        public AnalyseCommission()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string idFacture;
        private Decimal numDemande;
        private string codeAnalyse;
        private Decimal prixAnalyse;
        private Decimal prixCommission;
        private Decimal taux;
        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private DateTime dateCreationServeur;
        private DateTime dateDernModifClient;
        private DateTime dateDernModifServeur;
        private bool supprimer;
        private string userLogin;
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
        public string IdFacture
        {
            get { return idFacture.Trim(); }
            set { idFacture = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal NumDemande
        {
            get { return numDemande; }
            set { numDemande = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodeAnalyse
        {
            get { return codeAnalyse.Trim(); }
            set { codeAnalyse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal PrixAnalyse
        {
            get { return prixAnalyse; }
            set { prixAnalyse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal PrixCommission
        {
            get { return prixCommission; }
            set { prixCommission = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Taux
        {
            get { return taux; }
            set { taux = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de AnalyseCommission
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de AnalyseCommission
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de AnalyseCommission
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de AnalyseCommission
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Supprimer de AnalyseCommission
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de AnalyseCommission
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Version de ligne de AnalyseCommission
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
        private static TJ_AnalyseCommissionTableAdapter adapAnalyseCommission = new TJ_AnalyseCommissionTableAdapter();
        private static GestionDeLaCaisseDataSet.TJ_AnalyseCommissionDataTable dtAnalyseCommission = new GestionDeLaCaisseDataSet.TJ_AnalyseCommissionDataTable();

        private static PS_CalculCommissionSurProduitsTableAdapter adapCalculCommissionSurProduits = new PS_CalculCommissionSurProduitsTableAdapter();
        private static GestionDeLaCaisseDataSet.PS_CalculCommissionSurProduitsDataTable dtCalculCommissionSurProduits = new GestionDeLaCaisseDataSet.PS_CalculCommissionSurProduitsDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de AnalyseCommission
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalyseCommission.PS_AnalyseCommission_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de AnalyseCommission
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalyseCommission.PS_AnalyseCommission_IP(
                idFacture,
                numDemande,
                codeAnalyse,
                prixAnalyse,
                prixCommission,
                taux,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de AnalyseCommission
        /// </summary>
        /// <param name="idFacture"></param>
        /// <param name="numDemande"></param>
        /// <param name="codeAnalyse"></param>
        /// <param name="prixAnalyse"></param>
        /// <param name="prixCommission"></param>
        /// <param name="taux"></param>
        /// <param name="numLigne">Le Numéro de Ligne de AnalyseCommission</param>
        /// <param name="dateCreationServeur">La date de création de AnalyseCommission</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de AnalyseCommission</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de AnalyseCommission</param>
        /// <param name="supprimer">Supprimer de AnalyseCommission</param>
        /// <param name="userLogin">Le User Login de AnalyseCommission</param>
        /// <param name="rowvers">Version de ligne de AnalyseCommission</param>
        /// <returns>Liste AnalyseCommission</returns>
        public static List<AnalyseCommission> Liste(
             string mIdFacture,
             Decimal? mNumDemande,
             string mCodeAnalyse,
             Decimal? mPrixAnalyse,
             Decimal? mPrixCommission,
             Decimal? mTaux,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             bool? mSupprimer,
             string mUserLogin,
             Byte[] mRowvers)
        {
            dtAnalyseCommission = adapAnalyseCommission.PS_AnalyseCommission_SP(
                mIdFacture,
                mNumDemande,
                mCodeAnalyse,
                mPrixAnalyse,
                mPrixCommission,
                mTaux,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mSupprimer,
                mUserLogin,
                mRowvers);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des AnalyseCommission
        /// </summary>
        /// <returns>Liste AnalyseCommission</returns>
        private static List<AnalyseCommission> pListe()
        {
            List<AnalyseCommission> mListe = new List<AnalyseCommission>();
            foreach (GestionDeLaCaisseDataSet.TJ_AnalyseCommissionRow mLigne in dtAnalyseCommission)
            {
                AnalyseCommission oAnalyseCommission = new AnalyseCommission();
                oAnalyseCommission.IdFacture = mLigne.idFacture.Trim();
                oAnalyseCommission.NumDemande = mLigne.numDemande;
                oAnalyseCommission.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oAnalyseCommission.PrixAnalyse = mLigne.prixAnalyse;
                oAnalyseCommission.PrixCommission = mLigne.prixCommission;
                oAnalyseCommission.Taux = mLigne.taux;
                oAnalyseCommission.NumLigne = mLigne.numLigne;
                oAnalyseCommission.DateCreationServeur = mLigne.dateCreationServeur;
                oAnalyseCommission.DateDernModifClient = mLigne.dateDernModifClient;
                oAnalyseCommission.DateDernModifServeur = mLigne.dateDernModifServeur;
                oAnalyseCommission.Supprimer = mLigne.supprimer;
                oAnalyseCommission.UserLogin = mLigne.userLogin.Trim();
                oAnalyseCommission.Rowvers = mLigne.rowvers;

                mListe.Add(oAnalyseCommission);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de AnalyseCommission
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalyseCommission.PS_AnalyseCommission_UP(
                idFacture,
                numDemande,
                codeAnalyse,
                prixAnalyse,
                prixCommission,
                taux,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }



        public static System.Data.DataTable CalculCommissionSurProduits(DateTime mDateDebut, DateTime mDateFin, decimal mIdPersonne, decimal mIdPersonnePrincipal)
        {

            dtCalculCommissionSurProduits = adapCalculCommissionSurProduits.GetData(mDateDebut, mDateFin, mIdPersonne, mIdPersonnePrincipal);
            return dtCalculCommissionSurProduits;
        }
        #endregion Interfaces

        #region Gestion des collections

        #endregion Gestion des collections

        #region Métier

        #endregion Métier
        #endregion Méthodes
    }

}
