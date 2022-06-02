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
    public class PrelevementAnalyse
    {
        #region Constructeurs
        public PrelevementAnalyse()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeAnalyse;
        private string codeTypeTube;
        private string codePrelevement;
        private string libellePrelevement;
        private string libelleAnalyse;
        private string libelleTypeTube;

       
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
        public string LibelleTypeTube
        {
            get { return libelleTypeTube; }
            set { libelleTypeTube = value; }
        }

        
        public string CodeTypeTube
        {
            get { return codeTypeTube; }
            set { codeTypeTube = value; }
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
            get { return codeAnalyse.Trim(); }
            set { codeAnalyse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodePrelevement
        {
            get { return codePrelevement.Trim(); }
            set { codePrelevement = value; }
        }


        public string LibellePrelevement
        {
            get { return libellePrelevement; }
            set { libellePrelevement = value; }
        }
        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de PrelevementAnalyse
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de PrelevementAnalyse
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de PrelevementAnalyse
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de PrelevementAnalyse
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de PrelevementAnalyse
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de PrelevementAnalyse
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de PrelevementAnalyse
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
        private static TJ_PrelevementAnalyseTableAdapter adapPrelevementAnalyse = new TJ_PrelevementAnalyseTableAdapter();
        private static ParametreDataSet1.TJ_PrelevementAnalyseDataTable dtPrelevementAnalyse = new ParametreDataSet1.TJ_PrelevementAnalyseDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de PrelevementAnalyse
        /// </summary>
        /// <returns> </returns>
        /// 
        public static void Delete_All(string mCodeAnalyse)
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPrelevementAnalyse.PS_PrelevementAnalyse_DP_ALL(mCodeAnalyse);
           
        }
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPrelevementAnalyse.PS_PrelevementAnalyse_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de PrelevementAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPrelevementAnalyse.PS_PrelevementAnalyse_IP(
                codeAnalyse,
                codePrelevement,
                codeTypeTube,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de PrelevementAnalyse
        /// </summary>
        /// <param name="codeAnalyse"></param>
        /// <param name="codePrelevement"></param>
        /// <param name="numLigne">Le Numéro de Ligne de PrelevementAnalyse</param>
        /// <param name="dateCreationServeur">La date de création de PrelevementAnalyse</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de PrelevementAnalyse</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de PrelevementAnalyse</param>
        /// <param name="userLogin">Le User Login de PrelevementAnalyse</param>
        /// <param name="supprimer">Supprimer de PrelevementAnalyse</param>
        /// <param name="rowvers">Version de ligne de PrelevementAnalyse</param>
        /// <returns>Liste PrelevementAnalyse</returns>
        public static List<PrelevementAnalyse> Liste(
             string mCodeAnalyse,
             string mLibellePrelevement,
             string mCodePrelevement,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtPrelevementAnalyse = adapPrelevementAnalyse.PS_PrelevementAnalyse_SP(
                mCodeAnalyse,
                mLibellePrelevement,
                mCodePrelevement,
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
        /// Retourne la liste des PrelevementAnalyse
        /// </summary>
        /// <returns>Liste PrelevementAnalyse</returns>
        private static List<PrelevementAnalyse> pListe()
        {
            List<PrelevementAnalyse> mListe = new List<PrelevementAnalyse>();
            foreach (ParametreDataSet1.TJ_PrelevementAnalyseRow mLigne in dtPrelevementAnalyse)
            {
                PrelevementAnalyse oPrelevementAnalyse = new PrelevementAnalyse();
                oPrelevementAnalyse.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oPrelevementAnalyse.LibellePrelevement = mLigne.libellePrelevement.Trim();
                oPrelevementAnalyse.CodePrelevement = mLigne.codePrelevement.Trim();
                oPrelevementAnalyse.NumLigne = mLigne.numLigne;
                oPrelevementAnalyse.DateCreationServeur = mLigne.dateCreationServeur;
                oPrelevementAnalyse.DateDernModifClient = mLigne.dateDernModifClient;
                oPrelevementAnalyse.DateDernModifServeur = mLigne.dateDernModifServeur;
                oPrelevementAnalyse.UserLogin = mLigne.userLogin.Trim();
                oPrelevementAnalyse.Supprimer = mLigne.supprimer;
                oPrelevementAnalyse.Rowvers = mLigne.rowvers;
                oPrelevementAnalyse.LibelleAnalyse = mLigne.libelleAnalyse.Trim();
                oPrelevementAnalyse.CodeTypeTube = mLigne.codeTypeTube.Trim();
                oPrelevementAnalyse.LibelleTypeTube = mLigne.libelleTypeTube.Trim();

                mListe.Add(oPrelevementAnalyse);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de PrelevementAnalyse
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPrelevementAnalyse.PS_PrelevementAnalyse_UP(
                codeAnalyse,
                codePrelevement,
                codeTypeTube,
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

