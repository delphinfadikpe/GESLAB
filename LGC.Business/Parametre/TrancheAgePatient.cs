using LGC.DataAccess.Parametre;
using LGC.DataAccess.Parametre.ParametreDataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGC.Business.Parametre
{
    /// <summary>
    /// 
    /// </summary>
    public class TrancheAgePatient
    {
        #region Constructeurs
        public TrancheAgePatient()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeTranche;
        private Decimal minTranche;
        private Decimal maxTranche;
        private string periodiciteMin;
        private string periodiciteMax;
        private string nomAttribue;
        private string autre;

       
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
        public string Autre
        {
            get { return autre; }
            set { autre = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CodeTranche
        {
            get { return codeTranche.Trim(); }
            set { codeTranche = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MinTranche
        {
            get { return minTranche; }
            set { minTranche = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MaxTranche
        {
            get { return maxTranche; }
            set { maxTranche = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PeriodiciteMin
        {
            get { return periodiciteMin.Trim(); }
            set { periodiciteMin = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PeriodiciteMax
        {
            get { return periodiciteMax.Trim(); }
            set { periodiciteMax = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NomAttribue
        {
            get { return nomAttribue.Trim(); }
            set { nomAttribue = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de TrancheAgePatient
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de TrancheAgePatient
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de TrancheAgePatient
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de TrancheAgePatient
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de TrancheAgePatient
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de TrancheAgePatient
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de TrancheAgePatient
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
        private static T_TrancheAgePatientTableAdapter adapTrancheAgePatient = new T_TrancheAgePatientTableAdapter();
        private static ParametreDataSet1.T_TrancheAgePatientDataTable dtTrancheAgePatient = new ParametreDataSet1.T_TrancheAgePatientDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de TrancheAgePatient
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTrancheAgePatient.PS_TrancheAgePatient_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de TrancheAgePatient
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTrancheAgePatient.PS_TrancheAgePatient_IP(
                codeTranche,
                minTranche,
                maxTranche,
                periodiciteMin,
                periodiciteMax,
                nomAttribue,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de TrancheAgePatient
        /// </summary>
        /// <param name="codeTranche"></param>
        /// <param name="minTranche"></param>
        /// <param name="maxTranche"></param>
        /// <param name="periodiciteMin"></param>
        /// <param name="periodiciteMax"></param>
        /// <param name="nomAttribue"></param>
        /// <param name="numLigne">Le Numéro de Ligne de TrancheAgePatient</param>
        /// <param name="dateCreationServeur">La date de création de TrancheAgePatient</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de TrancheAgePatient</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de TrancheAgePatient</param>
        /// <param name="userLogin">Le User Login de TrancheAgePatient</param>
        /// <param name="supprimer">Supprimer de TrancheAgePatient</param>
        /// <param name="rowvers">Version de ligne de TrancheAgePatient</param>
        /// <returns>Liste TrancheAgePatient</returns>
        public static List<TrancheAgePatient> Liste(
             string mCodeTranche,
             Decimal? mMinTranche,
             Decimal? mMaxTranche,
             string mPeriodiciteMin,
             string mPeriodiciteMax,
             string mNomAttribue,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtTrancheAgePatient = adapTrancheAgePatient.PS_TrancheAgePatient_SP(
                mCodeTranche,
                mMinTranche,
                mMaxTranche,
                mPeriodiciteMin,
                mPeriodiciteMax,
                mNomAttribue,
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
        /// Retourne la liste des TrancheAgePatient
        /// </summary>
        /// <returns>Liste TrancheAgePatient</returns>
        private static List<TrancheAgePatient> pListe()
        {
            List<TrancheAgePatient> mListe = new List<TrancheAgePatient>();
            foreach (ParametreDataSet1.T_TrancheAgePatientRow mLigne in dtTrancheAgePatient)
            {
                TrancheAgePatient oTrancheAgePatient = new TrancheAgePatient();
                oTrancheAgePatient.CodeTranche = mLigne.codeTranche.Trim();
                oTrancheAgePatient.MinTranche = mLigne.minTranche;
                oTrancheAgePatient.MaxTranche = mLigne.maxTranche;
                oTrancheAgePatient.PeriodiciteMin = mLigne.periodiciteMin.Trim();
                oTrancheAgePatient.PeriodiciteMax = mLigne.periodiciteMax.Trim();
                oTrancheAgePatient.NomAttribue = mLigne.nomAttribue.Trim();
                oTrancheAgePatient.NumLigne = mLigne.numLigne;
                oTrancheAgePatient.DateCreationServeur = mLigne.dateCreationServeur;
                oTrancheAgePatient.DateDernModifClient = mLigne.dateDernModifClient;
                oTrancheAgePatient.DateDernModifServeur = mLigne.dateDernModifServeur;
                oTrancheAgePatient.UserLogin = mLigne.userLogin.Trim();
                oTrancheAgePatient.Supprimer = mLigne.supprimer;
                oTrancheAgePatient.Rowvers = mLigne.rowvers;
                oTrancheAgePatient.Autre = mLigne.autre.Trim();

                mListe.Add(oTrancheAgePatient);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de TrancheAgePatient
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTrancheAgePatient.PS_TrancheAgePatient_UP(
                codeTranche,
                minTranche,
                maxTranche,
                periodiciteMin,
                periodiciteMax,
                nomAttribue,
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

