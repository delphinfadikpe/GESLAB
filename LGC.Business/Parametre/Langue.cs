using LGC.Business;
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
    public class Langue
    {
        #region Constructeurs
        public Langue()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeLangue;
        private string libelleLangue;
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
        /// Langue de l'utilisateur de Langue
        /// </summary>
        public string CodeLangue
        {
            get { return codeLangue.Trim(); }
            set { codeLangue = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibelleLangue
        {
            get { return libelleLangue.Trim(); }
            set { libelleLangue = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Langue
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Langue
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Langue
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Langue
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Langue
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Langue
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Langue
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
        private static T_LangueTableAdapter adapLangue = new T_LangueTableAdapter();
        private static ParametreDataSet1.T_LangueDataTable dtLangue = new ParametreDataSet1.T_LangueDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Langue
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapLangue.PS_Langue_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Langue
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapLangue.PS_Langue_IP(
                CodeLangue,
                libelleLangue,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Langue
        /// </summary>
        /// <param name="CodeLangue">Langue de l'utilisateur de Langue</param>
        /// <param name="libelleLangue"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Langue</param>
        /// <param name="dateCreationServeur">La date de création de Langue</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Langue</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Langue</param>
        /// <param name="userLogin">Le User Login de Langue</param>
        /// <param name="supprimer">Supprimer de Langue</param>
        /// <param name="rowvers">Version de ligne de Langue</param>
        /// <returns>Liste Langue</returns>
        public static List<Langue> Liste(
             string mCodeLangue,
             string mLibelleLangue,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtLangue = adapLangue.PS_Langue_SP(
                mCodeLangue,
                mLibelleLangue,
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
        /// Retourne la liste des Langue
        /// </summary>
        /// <returns>Liste Langue</returns>
        private static List<Langue> pListe()
        {
            List<Langue> mListe = new List<Langue>();
            foreach (ParametreDataSet1.T_LangueRow mLigne in dtLangue)
            {
                Langue oLangue = new Langue();
                oLangue.CodeLangue = mLigne.CodeLangue.Trim();
                oLangue.LibelleLangue = mLigne.libelleLangue.Trim();
                oLangue.NumLigne = mLigne.numLigne;
                oLangue.DateCreationServeur = mLigne.dateCreationServeur;
                oLangue.DateDernModifClient = mLigne.dateDernModifClient;
                oLangue.DateDernModifServeur = mLigne.dateDernModifServeur;
                oLangue.UserLogin = mLigne.userLogin.Trim();
                oLangue.Supprimer = mLigne.supprimer;
                oLangue.Rowvers = mLigne.rowvers;

                mListe.Add(oLangue);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Langue
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapLangue.PS_Langue_UP(
                CodeLangue,
                libelleLangue,
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

