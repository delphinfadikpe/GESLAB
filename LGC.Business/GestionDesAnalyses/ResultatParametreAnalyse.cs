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
    public class ResultatParametreAnalyse
    {
        #region Constructeurs
        public ResultatParametreAnalyse()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idResultatDemande;
        private string codeAnalyse;
        private string libelleParametre;
        private string estValide;
        private string valeurResultat;
        private string motifRejet;
        private string interpretation;
        private string unite;
        private string libelleAnalyse;
        private string etat;
        private decimal numDemande;
        private DateTime dateDemande;

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


        public DateTime DateDemande
        {
            get { return dateDemande; }
            set { dateDemande = value; }
        }


        public decimal NumDemande
        {
            get { return numDemande; }
            set { numDemande = value; }
        }
        public string Etat
        {
            get { return etat; }
            set { etat = value; }
        }

        public string LibelleAnalyse
        {
            get { return libelleAnalyse; }
            set { libelleAnalyse = value; }
        }

        public string Unite
        {
            get { return unite; }
            set { unite = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Decimal IdResultatDemande
        {
            get { return idResultatDemande; }
            set { idResultatDemande = value; }
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
        public string LibelleParametre
        {
            get { return libelleParametre.Trim(); }
            set { libelleParametre = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string EstValide
        {
            get { return estValide.Trim(); }
            set { estValide = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ValeurResultat
        {
            get { return valeurResultat; }
            set { valeurResultat = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MotifRejet
        {
            get { return motifRejet.Trim(); }
            set { motifRejet = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Interpretation
        {
            get { return interpretation.Trim(); }
            set { interpretation = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de ResultatParametreAnalyse
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de ResultatParametreAnalyse
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de ResultatParametreAnalyse
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de ResultatParametreAnalyse
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de ResultatParametreAnalyse
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de ResultatParametreAnalyse
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de ResultatParametreAnalyse
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
        private static TJ_ResultatParametreAnalyseTableAdapter adapResultatParametreAnalyse = new TJ_ResultatParametreAnalyseTableAdapter();
        private static GestionDesAnalysesDataSet.TJ_ResultatParametreAnalyseDataTable dtResultatParametreAnalyse = new GestionDesAnalysesDataSet.TJ_ResultatParametreAnalyseDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de ResultatParametreAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapResultatParametreAnalyse.PS_ResultatParametreAnalyse_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de ResultatParametreAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapResultatParametreAnalyse.PS_ResultatParametreAnalyse_IP(
                idResultatDemande,
                etat,
                codeAnalyse,
                LibelleParametre,
                estValide,
                unite,
                valeurResultat,
                motifRejet,
                interpretation,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de ResultatParametreAnalyse
        /// </summary>
        /// <param name="idResultatDemande"></param>
        /// <param name="codeAnalyse"></param>
        /// <param name="LibelleParametre"></param>
        /// <param name="estValide"></param>
        /// <param name="valeurResultat"></param>
        /// <param name="motifRejet"></param>
        /// <param name="interpretation"></param>
        /// <param name="numLigne">Le Numéro de Ligne de ResultatParametreAnalyse</param>
        /// <param name="dateCreationServeur">La date de création de ResultatParametreAnalyse</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de ResultatParametreAnalyse</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ResultatParametreAnalyse</param>
        /// <param name="userLogin">Le User Login de ResultatParametreAnalyse</param>
        /// <param name="supprimer">Supprimer de ResultatParametreAnalyse</param>
        /// <param name="rowvers">Version de ligne de ResultatParametreAnalyse</param>
        /// <returns>Liste ResultatParametreAnalyse</returns>
        public static List<ResultatParametreAnalyse> Liste(
             Decimal? mIdResultatDemande,
            string mEtat,
             string mCodeAnalyse,
             string mLibelleParametre,
             string mEstValide,
             string mUnite,
             string mValeurResultat,
             string mMotifRejet,
             string mInterpretation,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtResultatParametreAnalyse = adapResultatParametreAnalyse.PS_ResultatParametreAnalyse_SP(
                mIdResultatDemande,
                mEtat,
                mCodeAnalyse,
                mLibelleParametre,
                mEstValide,
                mUnite,
                mValeurResultat,
                mMotifRejet,
                mInterpretation,
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
        /// Retourne la liste des ResultatParametreAnalyse
        /// </summary>
        /// <returns>Liste ResultatParametreAnalyse</returns>
        private static List<ResultatParametreAnalyse> pListe()
        {
            List<ResultatParametreAnalyse> mListe = new List<ResultatParametreAnalyse>();
            foreach (GestionDesAnalysesDataSet.TJ_ResultatParametreAnalyseRow mLigne in dtResultatParametreAnalyse)
            {
                ResultatParametreAnalyse oResultatParametreAnalyse = new ResultatParametreAnalyse();
                oResultatParametreAnalyse.IdResultatDemande = mLigne.idResultatDemande;
                oResultatParametreAnalyse.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oResultatParametreAnalyse.LibelleParametre = mLigne.LibelleParametre.Trim();
                oResultatParametreAnalyse.EstValide = mLigne.estValide.Trim();
                oResultatParametreAnalyse.ValeurResultat = mLigne.valeurResultat;
                oResultatParametreAnalyse.MotifRejet = mLigne.motifRejet.Trim();
                oResultatParametreAnalyse.Interpretation = mLigne.interpretation.Trim();
                oResultatParametreAnalyse.NumLigne = mLigne.numLigne;
                oResultatParametreAnalyse.DateCreationServeur = mLigne.dateCreationServeur;
                oResultatParametreAnalyse.DateDernModifClient = mLigne.dateDernModifClient;
                oResultatParametreAnalyse.DateDernModifServeur = mLigne.dateDernModifServeur;
                oResultatParametreAnalyse.UserLogin = mLigne.userLogin.Trim();
                oResultatParametreAnalyse.Supprimer = mLigne.supprimer;
                oResultatParametreAnalyse.Rowvers = mLigne.rowvers;
                oResultatParametreAnalyse.libelleAnalyse = mLigne.libelleAnalyse.Trim();
                oResultatParametreAnalyse.Unite = mLigne.unite.Trim();
                oResultatParametreAnalyse.etat = mLigne.etat.Trim();
                oResultatParametreAnalyse.NumDemande = mLigne.numDemande;
                oResultatParametreAnalyse.DateDemande = mLigne.dateDemande;
                mListe.Add(oResultatParametreAnalyse);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de ResultatParametreAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapResultatParametreAnalyse.PS_ResultatParametreAnalyse_UP(
                idResultatDemande,
                etat,
                codeAnalyse,
                LibelleParametre,
                estValide,
                unite,
                valeurResultat,
                motifRejet,
                interpretation,
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

