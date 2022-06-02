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
    public class UniteMesure
    {
        #region Constructeurs
        public UniteMesure()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string code;
        private string libelle;
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
        public string Code
        {
            get { return code.Trim(); }
            set { code = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Libelle
        {
            get { return libelle.Trim(); }
            set { libelle = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de UniteMesure
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de UniteMesure
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de UniteMesure
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de UniteMesure
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de UniteMesure
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de UniteMesure
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de UniteMesure
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
        private static T_UniteMesureTableAdapter adapUniteMesure = new T_UniteMesureTableAdapter();
        private static ParametreDataSet1.T_UniteMesureDataTable dtUniteMesure = new ParametreDataSet1.T_UniteMesureDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de UniteMesure
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapUniteMesure.PS_UniteMesure_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de UniteMesure
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapUniteMesure.PS_UniteMesure_IP(
                code,
                libelle,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de UniteMesure
        /// </summary>
        /// <param name="code"></param>
        /// <param name="libelle"></param>
        /// <param name="numLigne">Le Numéro de Ligne de UniteMesure</param>
        /// <param name="dateCreationServeur">La date de création de UniteMesure</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de UniteMesure</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de UniteMesure</param>
        /// <param name="userLogin">Le User Login de UniteMesure</param>
        /// <param name="supprimer">Supprimer de UniteMesure</param>
        /// <param name="rowvers">Version de ligne de UniteMesure</param>
        /// <returns>Liste UniteMesure</returns>
        public static List<UniteMesure> Liste(
             string mCode,
             string mLibelle,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtUniteMesure = adapUniteMesure.PS_UniteMesure_SP(
                mCode,
                mLibelle,
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
        /// Retourne la liste des UniteMesure
        /// </summary>
        /// <returns>Liste UniteMesure</returns>
        private static List<UniteMesure> pListe()
        {
            List<UniteMesure> mListe = new List<UniteMesure>();
            foreach (ParametreDataSet1.T_UniteMesureRow mLigne in dtUniteMesure)
            {
                UniteMesure oUniteMesure = new UniteMesure();
                oUniteMesure.Code = mLigne.code.Trim();
                oUniteMesure.Libelle = mLigne.libelle.Trim();
                oUniteMesure.NumLigne = mLigne.numLigne;
                oUniteMesure.DateCreationServeur = mLigne.dateCreationServeur;
                oUniteMesure.DateDernModifClient = mLigne.dateDernModifClient;
                oUniteMesure.DateDernModifServeur = mLigne.dateDernModifServeur;
                oUniteMesure.UserLogin = mLigne.userLogin.Trim();
                oUniteMesure.Supprimer = mLigne.supprimer;
                oUniteMesure.Rowvers = mLigne.rowvers;

                mListe.Add(oUniteMesure);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de UniteMesure
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapUniteMesure.PS_UniteMesure_UP(
                code,
                libelle,
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

