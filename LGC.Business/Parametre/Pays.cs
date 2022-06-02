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
    public class Pays
    {
        #region Constructeurs
        public Pays()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codePays;
        private string nomPays;
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
        public string CodePays
        {
            get { return codePays.Trim(); }
            set { codePays = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NomPays
        {
            get { return nomPays.Trim(); }
            set { nomPays = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Pays
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Pays
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Pays
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Pays
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Pays
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Pays
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Pays
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
        private static T_PaysTableAdapter adapPays = new T_PaysTableAdapter();
        private static ParametreDataSet1.T_PaysDataTable dtPays = new ParametreDataSet1.T_PaysDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Pays
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPays.PS_Pays_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Pays
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPays.PS_Pays_IP(
                CodePays,
                nomPays,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Pays
        /// </summary>
        /// <param name="CodePays"></param>
        /// <param name="nomPays"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Pays</param>
        /// <param name="dateCreationServeur">La date de création de Pays</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Pays</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Pays</param>
        /// <param name="userLogin">Le User Login de Pays</param>
        /// <param name="supprimer">Supprimer de Pays</param>
        /// <param name="rowvers">Version de ligne de Pays</param>
        /// <returns>Liste Pays</returns>
        public static List<Pays> Liste(
             string mCodePays,
             string mNomPays,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtPays = adapPays.PS_Pays_SP(
                mCodePays,
                mNomPays,
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
        /// Retourne la liste des Pays
        /// </summary>
        /// <returns>Liste Pays</returns>
        private static List<Pays> pListe()
        {
            List<Pays> mListe = new List<Pays>();
            foreach (ParametreDataSet1.T_PaysRow mLigne in dtPays)
            {
                Pays oPays = new Pays();
                oPays.CodePays = mLigne.CodePays.Trim();
                oPays.NomPays = mLigne.nomPays.Trim();
                oPays.NumLigne = mLigne.numLigne;
                oPays.DateCreationServeur = mLigne.dateCreationServeur;
                oPays.DateDernModifClient = mLigne.dateDernModifClient;
                oPays.DateDernModifServeur = mLigne.dateDernModifServeur;
                oPays.UserLogin = mLigne.userLogin.Trim();
                oPays.Supprimer = mLigne.supprimer;
                oPays.Rowvers = mLigne.rowvers;
                mListe.Add(oPays);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Pays
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPays.PS_Pays_UP(
                CodePays,
                nomPays,
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

