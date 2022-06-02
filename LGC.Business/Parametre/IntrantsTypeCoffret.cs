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
    public class IntrantsTypeCoffret
    {
        #region Constructeurs
        public IntrantsTypeCoffret()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private decimal codeTypeCoffret;
        private string codeIntrant;
        private Decimal nbAnalyse_qte;
        private string libelleIntrant;
        private string libelleTypeCoffret;
        private string mesure1Test;

        
       
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

        public string Mesure1Test
        {
            get { return mesure1Test; }
            set { mesure1Test = value; }
        }

        public string LibelleTypeCoffret
        {
            get { return libelleTypeCoffret; }
            set { libelleTypeCoffret = value; }
        }
       

        public string LibelleIntrant
        {
            get { return libelleIntrant; }
            set { libelleIntrant = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal CodeTypeCoffret
        {
            get { return codeTypeCoffret; }
            set { codeTypeCoffret = value; }
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
        public Decimal NbAnalyse_qte
        {
            get { return nbAnalyse_qte; }
            set { nbAnalyse_qte = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de IntrantsTypeCoffret
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de IntrantsTypeCoffret
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de IntrantsTypeCoffret
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de IntrantsTypeCoffret
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de IntrantsTypeCoffret
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de IntrantsTypeCoffret
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de IntrantsTypeCoffret
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
        private static TJ_IntrantsTypeCoffretTableAdapter adapIntrantsTypeCoffret = new TJ_IntrantsTypeCoffretTableAdapter();
        private static ParametreDataSet1.TJ_IntrantsTypeCoffretDataTable dtIntrantsTypeCoffret = new ParametreDataSet1.TJ_IntrantsTypeCoffretDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de IntrantsTypeCoffret
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantsTypeCoffret.PS_IntrantsTypeCoffret_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de IntrantsTypeCoffret
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantsTypeCoffret.PS_IntrantsTypeCoffret_IP(
                codeTypeCoffret,
                codeIntrant,mesure1Test,
                nbAnalyse_qte,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de IntrantsTypeCoffret
        /// </summary>
        /// <param name="codeTypeCoffret"></param>
        /// <param name="codeIntrant"></param>
        /// <param name="nbAnalyse_qte"></param>
        /// <param name="numLigne">Le Numéro de Ligne de IntrantsTypeCoffret</param>
        /// <param name="dateCreationServeur">La date de création de IntrantsTypeCoffret</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de IntrantsTypeCoffret</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de IntrantsTypeCoffret</param>
        /// <param name="userLogin">Le User Login de IntrantsTypeCoffret</param>
        /// <param name="supprimer">Supprimer de IntrantsTypeCoffret</param>
        /// <param name="rowvers">Version de ligne de IntrantsTypeCoffret</param>
        /// <returns>Liste IntrantsTypeCoffret</returns>
        public static List<IntrantsTypeCoffret> Liste(
             decimal? mCodeTypeCoffret,
             string mCodeIntrant,
             Decimal? mNbAnalyse_qte,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtIntrantsTypeCoffret = adapIntrantsTypeCoffret.PS_IntrantsTypeCoffret_SP(
                mCodeTypeCoffret,
                mCodeIntrant,
                mNbAnalyse_qte,
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
        /// Retourne la liste des IntrantsTypeCoffret
        /// </summary>
        /// <returns>Liste IntrantsTypeCoffret</returns>
        private static List<IntrantsTypeCoffret> pListe()
        {
            List<IntrantsTypeCoffret> mListe = new List<IntrantsTypeCoffret>();
            foreach (ParametreDataSet1.TJ_IntrantsTypeCoffretRow mLigne in dtIntrantsTypeCoffret)
            {
                IntrantsTypeCoffret oIntrantsTypeCoffret = new IntrantsTypeCoffret();
                oIntrantsTypeCoffret.CodeTypeCoffret = mLigne.codeTypeCoffret;
                oIntrantsTypeCoffret.CodeIntrant = mLigne.codeIntrant.Trim();
                oIntrantsTypeCoffret.NbAnalyse_qte = mLigne.nbAnalyse_qte;
                oIntrantsTypeCoffret.NumLigne = mLigne.numLigne;
                oIntrantsTypeCoffret.DateCreationServeur = mLigne.dateCreationServeur;
                oIntrantsTypeCoffret.DateDernModifClient = mLigne.dateDernModifClient;
                oIntrantsTypeCoffret.DateDernModifServeur = mLigne.dateDernModifServeur;
                oIntrantsTypeCoffret.UserLogin = mLigne.userLogin.Trim();
                oIntrantsTypeCoffret.Supprimer = mLigne.supprimer;
                oIntrantsTypeCoffret.Rowvers = mLigne.rowvers;
                oIntrantsTypeCoffret.LibelleIntrant = mLigne.libelleIntrant;
                oIntrantsTypeCoffret.LibelleTypeCoffret = mLigne.libelleTypeCoffret;
                oIntrantsTypeCoffret.Mesure1Test = mLigne.mesure1Test;
                mListe.Add(oIntrantsTypeCoffret);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de IntrantsTypeCoffret
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapIntrantsTypeCoffret.PS_IntrantsTypeCoffret_UP(
                codeTypeCoffret,
                codeIntrant,mesure1Test,
                nbAnalyse_qte,
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
