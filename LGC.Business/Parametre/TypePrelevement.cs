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
    public class TypePrelevement
    {
        #region Constructeurs
        public TypePrelevement()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codePrelevement;
        private string libellePrelevement;
        private string codeUniteMesure;
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
        public string CodePrelevement
        {
            get { return codePrelevement.Trim(); }
            set { codePrelevement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibellePrelevement
        {
            get { return libellePrelevement.Trim(); }
            set { libellePrelevement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodeUniteMesure
        {
            get { return codeUniteMesure.Trim(); }
            set { codeUniteMesure = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de TypePrelevement
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de TypePrelevement
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de TypePrelevement
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de TypePrelevement
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de TypePrelevement
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de TypePrelevement
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de TypePrelevement
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
        private static T_TypePrelevementTableAdapter adapTypePrelevement = new T_TypePrelevementTableAdapter();
        private static ParametreDataSet1.T_TypePrelevementDataTable dtTypePrelevement = new ParametreDataSet1.T_TypePrelevementDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de TypePrelevement
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypePrelevement.PS_TypePrelevement_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de TypePrelevement
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypePrelevement.PS_TypePrelevement_IP(
                codePrelevement,
                libellePrelevement,
                codeUniteMesure,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de TypePrelevement
        /// </summary>
        /// <param name="codePrelevement"></param>
        /// <param name="libellePrelevement"></param>
        /// <param name="codeUniteMesure"></param>
        /// <param name="numLigne">Le Numéro de Ligne de TypePrelevement</param>
        /// <param name="dateCreationServeur">La date de création de TypePrelevement</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de TypePrelevement</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de TypePrelevement</param>
        /// <param name="userLogin">Le User Login de TypePrelevement</param>
        /// <param name="supprimer">Supprimer de TypePrelevement</param>
        /// <param name="rowvers">Version de ligne de TypePrelevement</param>
        /// <returns>Liste TypePrelevement</returns>
        public static List<TypePrelevement> Liste(
             string mCodePrelevement,
             string mLibellePrelevement,
             string mCodeUniteMesure,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtTypePrelevement = adapTypePrelevement.PS_TypePrelevement_SP(
                mCodePrelevement,
                mLibellePrelevement,
                mCodeUniteMesure,
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
        /// Retourne la liste des TypePrelevement
        /// </summary>
        /// <returns>Liste TypePrelevement</returns>
        private static List<TypePrelevement> pListe()
        {
            List<TypePrelevement> mListe = new List<TypePrelevement>();
            foreach (ParametreDataSet1.T_TypePrelevementRow mLigne in dtTypePrelevement)
            {
                TypePrelevement oTypePrelevement = new TypePrelevement();
                oTypePrelevement.CodePrelevement = mLigne.codePrelevement.Trim();
                oTypePrelevement.LibellePrelevement = mLigne.libellePrelevement.Trim();
                oTypePrelevement.CodeUniteMesure = mLigne.codeUniteMesure.Trim();
                oTypePrelevement.NumLigne = mLigne.numLigne;
                oTypePrelevement.DateCreationServeur = mLigne.dateCreationServeur;
                oTypePrelevement.DateDernModifClient = mLigne.dateDernModifClient;
                oTypePrelevement.DateDernModifServeur = mLigne.dateDernModifServeur;
                oTypePrelevement.UserLogin = mLigne.userLogin.Trim();
                oTypePrelevement.Supprimer = mLigne.supprimer;
                oTypePrelevement.Rowvers = mLigne.rowvers;

                mListe.Add(oTypePrelevement);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de TypePrelevement
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapTypePrelevement.PS_TypePrelevement_UP(
                codePrelevement,
                libellePrelevement,
                codeUniteMesure,
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

