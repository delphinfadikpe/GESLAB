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
    public class TypeTube
    {
        #region Constructeurs
        public TypeTube()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeTypeTube;
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
        /// <summary>
        /// 
        /// </summary>
        public string CodeTypeTube
        {
            get { return codeTypeTube.Trim(); }
            set { codeTypeTube = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibelleTypeTube
        {
            get { return libelleTypeTube.Trim(); }
            set { libelleTypeTube = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de TypeTube
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de TypeTube
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de TypeTube
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de TypeTube
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de TypeTube
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de TypeTube
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de TypeTube
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
        private static T_TypeTubeTableAdapter adapTypeTube = new T_TypeTubeTableAdapter();
        private static ParametreDataSet1.T_TypeTubeDataTable dtTypeTube = new ParametreDataSet1.T_TypeTubeDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de TypeTube
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeTube.PS_TypeTube_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de TypeTube
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeTube.PS_TypeTube_IP(
                codeTypeTube,
                libelleTypeTube,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de TypeTube
        /// </summary>
        /// <param name="codeTypeTube"></param>
        /// <param name="libelleTypeTube"></param>
        /// <param name="numLigne">Le Numéro de Ligne de TypeTube</param>
        /// <param name="dateCreationServeur">La date de création de TypeTube</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de TypeTube</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de TypeTube</param>
        /// <param name="userLogin">Le User Login de TypeTube</param>
        /// <param name="supprimer">Supprimer de TypeTube</param>
        /// <param name="rowvers">Version de ligne de TypeTube</param>
        /// <returns>Liste TypeTube</returns>
        public static List<TypeTube> Liste(
             string mCodeTypeTube,
             string mLibelleTypeTube,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtTypeTube = adapTypeTube.PS_TypeTube_SP(
                mCodeTypeTube,
                mLibelleTypeTube,
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
        /// Retourne la liste des TypeTube
        /// </summary>
        /// <returns>Liste TypeTube</returns>
        private static List<TypeTube> pListe()
        {
            List<TypeTube> mListe = new List<TypeTube>();
            foreach (ParametreDataSet1.T_TypeTubeRow mLigne in dtTypeTube)
            {
                TypeTube oTypeTube = new TypeTube();
                oTypeTube.CodeTypeTube = mLigne.codeTypeTube.Trim();
                oTypeTube.LibelleTypeTube = mLigne.libelleTypeTube.Trim();
                oTypeTube.NumLigne = mLigne.numLigne;
                oTypeTube.DateCreationServeur = mLigne.dateCreationServeur;
                oTypeTube.DateDernModifClient = mLigne.dateDernModifClient;
                oTypeTube.DateDernModifServeur = mLigne.dateDernModifServeur;
                oTypeTube.UserLogin = mLigne.userLogin.Trim();
                oTypeTube.Supprimer = mLigne.supprimer;
                oTypeTube.Rowvers = mLigne.rowvers;

                mListe.Add(oTypeTube);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de TypeTube
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeTube.PS_TypeTube_UP(
                codeTypeTube,
                libelleTypeTube,
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

