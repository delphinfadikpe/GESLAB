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
    public class FormeJuridique
    {
        #region Constructeurs
        public FormeJuridique()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeFormeJuridique;
        private string libelleFormeJuridique;
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
        public string CodeFormeJuridique
        {
            get { return codeFormeJuridique.Trim(); }
            set { codeFormeJuridique = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibelleFormeJuridique
        {
            get { return libelleFormeJuridique.Trim(); }
            set { libelleFormeJuridique = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de FormeJuridique
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de FormeJuridique
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de FormeJuridique
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de FormeJuridique
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de FormeJuridique
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de FormeJuridique
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de FormeJuridique
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
        private static T_FormeJuridiqueTableAdapter adapFormeJuridique = new T_FormeJuridiqueTableAdapter();
        private static ParametreDataSet1.T_FormeJuridiqueDataTable dtFormeJuridique = new ParametreDataSet1.T_FormeJuridiqueDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de FormeJuridique
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFormeJuridique.PS_FormeJuridique_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de FormeJuridique
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFormeJuridique.PS_FormeJuridique_IP(
                codeFormeJuridique,
                libelleFormeJuridique,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de FormeJuridique
        /// </summary>
        /// <param name="codeFormeJuridique"></param>
        /// <param name="libelleFormeJuridique"></param>
        /// <param name="numLigne">Le Numéro de Ligne de FormeJuridique</param>
        /// <param name="dateCreationServeur">La date de création de FormeJuridique</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de FormeJuridique</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de FormeJuridique</param>
        /// <param name="userLogin">Le User Login de FormeJuridique</param>
        /// <param name="supprimer">Supprimer de FormeJuridique</param>
        /// <param name="rowvers">Version de ligne de FormeJuridique</param>
        /// <returns>Liste FormeJuridique</returns>
        public static List<FormeJuridique> Liste(
             string mCodeFormeJuridique,
             string mLibelleFormeJuridique,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtFormeJuridique = adapFormeJuridique.PS_FormeJuridique_SP(
                mCodeFormeJuridique,
                mLibelleFormeJuridique,
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
        /// Retourne la liste des FormeJuridique
        /// </summary>
        /// <returns>Liste FormeJuridique</returns>
        private static List<FormeJuridique> pListe()
        {
            List<FormeJuridique> mListe = new List<FormeJuridique>();
            foreach (ParametreDataSet1.T_FormeJuridiqueRow mLigne in dtFormeJuridique)
            {
                FormeJuridique oFormeJuridique = new FormeJuridique();
                oFormeJuridique.CodeFormeJuridique = mLigne.codeFormeJuridique.Trim();
                oFormeJuridique.LibelleFormeJuridique = mLigne.libelleFormeJuridique.Trim();
                oFormeJuridique.NumLigne = mLigne.numLigne;
                oFormeJuridique.DateCreationServeur = mLigne.dateCreationServeur;
                oFormeJuridique.DateDernModifClient = mLigne.dateDernModifClient;
                oFormeJuridique.DateDernModifServeur = mLigne.dateDernModifServeur;
                oFormeJuridique.UserLogin = mLigne.userLogin.Trim();
                oFormeJuridique.Supprimer = mLigne.supprimer;
                oFormeJuridique.Rowvers = mLigne.rowvers;

                mListe.Add(oFormeJuridique);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de FormeJuridique
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFormeJuridique.PS_FormeJuridique_UP(
                codeFormeJuridique,
                libelleFormeJuridique,
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


