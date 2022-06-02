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
    public class TypeCoffret
    {
        #region Constructeurs
        public TypeCoffret()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private decimal codeTypeCoffret;
        private string libelleTypeCoffret;
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
        public decimal CodeTypeCoffret
        {
            get { return codeTypeCoffret; }
            set { codeTypeCoffret = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibelleTypeCoffret
        {
            get { return libelleTypeCoffret.Trim(); }
            set { libelleTypeCoffret = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de TypeCoffret
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de TypeCoffret
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de TypeCoffret
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de TypeCoffret
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de TypeCoffret
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de TypeCoffret
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de TypeCoffret
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
        private static T_TypeCoffretTableAdapter adapTypeCoffret = new T_TypeCoffretTableAdapter();
        private static ParametreDataSet1.T_TypeCoffretDataTable dtTypeCoffret = new ParametreDataSet1.T_TypeCoffretDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de TypeCoffret
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeCoffret.PS_TypeCoffret_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de TypeCoffret
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeCoffret.PS_TypeCoffret_IP(
                CodeTypeCoffret,
                libelleTypeCoffret,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de TypeCoffret
        /// </summary>
        /// <param name="CodeTypeCoffret"></param>
        /// <param name="libelleTypeCoffret"></param>
        /// <param name="numLigne">Le Numéro de Ligne de TypeCoffret</param>
        /// <param name="dateCreationServeur">La date de création de TypeCoffret</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de TypeCoffret</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de TypeCoffret</param>
        /// <param name="userLogin">Le User Login de TypeCoffret</param>
        /// <param name="supprimer">Supprimer de TypeCoffret</param>
        /// <param name="rowvers">Version de ligne de TypeCoffret</param>
        /// <returns>Liste TypeCoffret</returns>
        public static List<TypeCoffret> Liste(
             int? mCodeTypeCoffret,
             string mLibelleTypeCoffret,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtTypeCoffret = adapTypeCoffret.PS_TypeCoffret_SP(
                mCodeTypeCoffret,
                mLibelleTypeCoffret,
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
        /// Retourne la liste des TypeCoffret
        /// </summary>
        /// <returns>Liste TypeCoffret</returns>
        private static List<TypeCoffret> pListe()
        {
            List<TypeCoffret> mListe = new List<TypeCoffret>();
            foreach (ParametreDataSet1.T_TypeCoffretRow mLigne in dtTypeCoffret)
            {
                TypeCoffret oTypeCoffret = new TypeCoffret();
                oTypeCoffret.CodeTypeCoffret = mLigne.CodeTypeCoffret;
                oTypeCoffret.LibelleTypeCoffret = mLigne.libelleTypeCoffret.Trim();
                oTypeCoffret.NumLigne = mLigne.numLigne;
                oTypeCoffret.DateCreationServeur = mLigne.dateCreationServeur;
                oTypeCoffret.DateDernModifClient = mLigne.dateDernModifClient;
                oTypeCoffret.DateDernModifServeur = mLigne.dateDernModifServeur;
                oTypeCoffret.UserLogin = mLigne.userLogin.Trim();
                oTypeCoffret.Supprimer = mLigne.supprimer;
                oTypeCoffret.Rowvers = mLigne.rowvers;

                mListe.Add(oTypeCoffret);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de TypeCoffret
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypeCoffret.PS_TypeCoffret_UP(
                CodeTypeCoffret,
                libelleTypeCoffret,
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
