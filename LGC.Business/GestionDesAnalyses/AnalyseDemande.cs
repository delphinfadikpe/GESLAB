using LGC.DataAccess.GestionDesAnalyses;
using LGC.DataAccess.GestionDesAnalyses.GestionDesAnalysesDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGC.Business.GestionDesAnalyses
{
    /// <summary>
    /// 
    /// </summary>
    public class AnalyseDemande
    {
        #region Constructeurs
        public AnalyseDemande()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeAnalyse;
        private Decimal numDemande;
        private Decimal qte;

        
        private Decimal remiseAnalyse;
        private Decimal prixNormal;
        private Decimal prixApresRemise;
        private string libelleAnalyse;
        private string interpretation;
        private DateTime dateDemande;

        private decimal montantLigne;

       
       
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

        public Decimal Qte
        {
            get { return qte; }
            set { qte = value; }
        }
        public DateTime DateDemande
        {
            get { return dateDemande; }
            set { dateDemande = value; }
        }
        public string Interpretation
        {
            get { return interpretation; }
            set { interpretation = value; }
        }

        public string LibelleAnalyse
        {
            get { return libelleAnalyse; }
            set { libelleAnalyse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodeAnalyse
        {
            get { return codeAnalyse; }
            set { codeAnalyse = value; }
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
        public Decimal RemiseAnalyse
        {
            get { return remiseAnalyse; }
            set { remiseAnalyse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal PrixNormal
        {
            get { return prixNormal; }
            set { prixNormal = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal PrixApresRemise
        {
            get { return prixApresRemise; }
            set { prixApresRemise = value; }
        }

        public decimal MontantLigne
        {
            get { return montantLigne; }
            set { montantLigne = value; }
        }
        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de AnalyseDemande
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de AnalyseDemande
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de AnalyseDemande
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de AnalyseDemande
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Supprimer de AnalyseDemande
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de AnalyseDemande
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Version de ligne de AnalyseDemande
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
        private static TJ_AnalyseDemandeTableAdapter adapAnalyseDemande = new TJ_AnalyseDemandeTableAdapter();
        private static GestionDesAnalysesDataSet.TJ_AnalyseDemandeDataTable dtAnalyseDemande = new GestionDesAnalysesDataSet.TJ_AnalyseDemandeDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de AnalyseDemande
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalyseDemande.PS_AnalyseDemande_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de AnalyseDemande
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalyseDemande.PS_AnalyseDemande_IP(
                codeAnalyse,
                numDemande,
                remiseAnalyse,
                prixNormal,
                prixApresRemise,
                interpretation,qte,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de AnalyseDemande
        /// </summary>
        /// <param name="codeAnalyse"></param>
        /// <param name="numDemande"></param>
        /// <param name="remiseAnalyse"></param>
        /// <param name="prixNormal"></param>
        /// <param name="prixApresRemise"></param>
        /// <param name="numLigne">Le Numéro de Ligne de AnalyseDemande</param>
        /// <param name="dateCreationServeur">La date de création de AnalyseDemande</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de AnalyseDemande</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de AnalyseDemande</param>
        /// <param name="supprimer">Supprimer de AnalyseDemande</param>
        /// <param name="userLogin">Le User Login de AnalyseDemande</param>
        /// <param name="rowvers">Version de ligne de AnalyseDemande</param>
        /// <returns>Liste AnalyseDemande</returns>
        public static List<AnalyseDemande> Liste(
             string mCodeAnalyse,
             Decimal? mNumDemande,
             Decimal? mRemiseAnalyse,
             Decimal? mPrixNormal,
             Decimal? mPrixApresRemise,
            string mInterpretation,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             bool? mSupprimer,
             string mUserLogin,
             Byte[] mRowvers)
        {
            dtAnalyseDemande = adapAnalyseDemande.PS_AnalyseDemande_SP(
                mCodeAnalyse,
                mNumDemande,
                mRemiseAnalyse,
                mPrixNormal,
                mPrixApresRemise,
                mInterpretation,
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
        /// Retourne la liste des AnalyseDemande
        /// </summary>
        /// <returns>Liste AnalyseDemande</returns>
        private static List<AnalyseDemande> pListe()
        {
            List<AnalyseDemande> mListe = new List<AnalyseDemande>();
            foreach (GestionDesAnalysesDataSet.TJ_AnalyseDemandeRow mLigne in dtAnalyseDemande)
            {
                AnalyseDemande oAnalyseDemande = new AnalyseDemande();
                oAnalyseDemande.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oAnalyseDemande.NumDemande = mLigne.numDemande;
                oAnalyseDemande.RemiseAnalyse = mLigne.remiseAnalyse;
                oAnalyseDemande.PrixNormal = mLigne.prixNormal;
                oAnalyseDemande.PrixApresRemise = mLigne.prixApresRemise;
                oAnalyseDemande.NumLigne = mLigne.numLigne;
                oAnalyseDemande.DateCreationServeur = mLigne.dateCreationServeur;
                oAnalyseDemande.DateDernModifClient = mLigne.dateDernModifClient;
                oAnalyseDemande.DateDernModifServeur = mLigne.dateDernModifServeur;
                oAnalyseDemande.Supprimer = mLigne.supprimer;
                oAnalyseDemande.UserLogin = mLigne.userLogin.Trim();
                oAnalyseDemande.Rowvers = mLigne.rowvers;
                oAnalyseDemande.Interpretation = mLigne.interpretation.Trim();
                oAnalyseDemande.LibelleAnalyse = mLigne.libelleAnalyse;
                oAnalyseDemande.DateDemande = mLigne.dateDemande;
                oAnalyseDemande.Qte = mLigne.qte;
                oAnalyseDemande.MontantLigne = mLigne.qte * mLigne.prixApresRemise;
                mListe.Add(oAnalyseDemande);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de AnalyseDemande
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAnalyseDemande.PS_AnalyseDemande_UP(
                codeAnalyse,
                numDemande,
                remiseAnalyse,
                prixNormal,
                prixApresRemise,
                interpretation,qte,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        public static void DeleteAll(decimal mNumDemande)
        {
            adapAnalyseDemande.PS_AnalyseDemande_DP_ALL(mNumDemande);
        }
        #endregion Interfaces

        #region Gestion des collections

        #endregion Gestion des collections

        #region Métier

        #endregion Métier
        #endregion Méthodes
    }

}
