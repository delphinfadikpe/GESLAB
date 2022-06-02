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
    public class CodeBarre
    {
        #region Constructeurs
        public CodeBarre()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idCodeBarre;
        private string encoder;
        private bool showTexte;
        private bool estCourant;
        private DateTime datedebutUtilisation;
        private DateTime datedebutFinUtilisation;
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
        public Decimal IdCodeBarre
        {
            get { return idCodeBarre; }
            set { idCodeBarre = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Encoder
        {
            get { return encoder.Trim(); }
            set { encoder = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowTexte
        {
            get { return showTexte; }
            set { showTexte = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstCourant
        {
            get { return estCourant; }
            set { estCourant = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DatedebutUtilisation
        {
            get { return datedebutUtilisation; }
            set { datedebutUtilisation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DatedebutFinUtilisation
        {
            get { return datedebutFinUtilisation; }
            set { datedebutFinUtilisation = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de CodeBarre
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de CodeBarre
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de CodeBarre
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de CodeBarre
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de CodeBarre
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de CodeBarre
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de CodeBarre
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
        private static T_CodeBarreTableAdapter adapCodeBarre = new T_CodeBarreTableAdapter();
        private static ParametreDataSet1.T_CodeBarreDataTable dtCodeBarre = new ParametreDataSet1.T_CodeBarreDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de CodeBarre
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapCodeBarre.PS_CodeBarre_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de CodeBarre
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapCodeBarre.PS_CodeBarre_IP(
                idCodeBarre,
                Encoder,
                showTexte,
                estCourant,
                datedebutUtilisation,
                datedebutFinUtilisation,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de CodeBarre
        /// </summary>
        /// <param name="idCodeBarre"></param>
        /// <param name="Encoder"></param>
        /// <param name="showTexte"></param>
        /// <param name="estCourant"></param>
        /// <param name="datedebutUtilisation"></param>
        /// <param name="datedebutFinUtilisation"></param>
        /// <param name="numLigne">Le Numéro de Ligne de CodeBarre</param>
        /// <param name="dateCreationServeur">La date de création de CodeBarre</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de CodeBarre</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de CodeBarre</param>
        /// <param name="userLogin">Le User Login de CodeBarre</param>
        /// <param name="supprimer">Supprimer de CodeBarre</param>
        /// <param name="rowvers">Version de ligne de CodeBarre</param>
        /// <returns>Liste CodeBarre</returns>
        public static List<CodeBarre> Liste(
             Decimal? mIdCodeBarre,
             string mEncoder,
             bool? mShowTexte,
             bool? mEstCourant,
             DateTime? mDatedebutUtilisation,
             DateTime? mDatedebutFinUtilisation,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtCodeBarre = adapCodeBarre.PS_CodeBarre_SP(
                mIdCodeBarre,
                mEncoder,
                mShowTexte,
                mEstCourant,
                mDatedebutUtilisation,
                mDatedebutFinUtilisation,
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
        /// Retourne la liste des CodeBarre
        /// </summary>
        /// <returns>Liste CodeBarre</returns>
        private static List<CodeBarre> pListe()
        {
            List<CodeBarre> mListe = new List<CodeBarre>();
            foreach (ParametreDataSet1.T_CodeBarreRow mLigne in dtCodeBarre)
            {
                CodeBarre oCodeBarre = new CodeBarre();
                oCodeBarre.IdCodeBarre = mLigne.idCodeBarre;
                oCodeBarre.Encoder = mLigne.Encoder.Trim();
                oCodeBarre.ShowTexte = mLigne.showTexte;
                oCodeBarre.EstCourant = mLigne.estCourant;
                oCodeBarre.DatedebutUtilisation = mLigne.datedebutUtilisation;
                oCodeBarre.DatedebutFinUtilisation = mLigne.datedebutFinUtilisation;
                oCodeBarre.NumLigne = mLigne.numLigne;
                oCodeBarre.DateCreationServeur = mLigne.dateCreationServeur;
                oCodeBarre.DateDernModifClient = mLigne.dateDernModifClient;
                oCodeBarre.DateDernModifServeur = mLigne.dateDernModifServeur;
                oCodeBarre.UserLogin = mLigne.userLogin.Trim();
                oCodeBarre.Supprimer = mLigne.supprimer;
                oCodeBarre.Rowvers = mLigne.rowvers;

                mListe.Add(oCodeBarre);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de CodeBarre
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapCodeBarre.PS_CodeBarre_UP(
                idCodeBarre,
                Encoder,
                showTexte,
                estCourant,
                datedebutUtilisation,
                datedebutFinUtilisation,
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

