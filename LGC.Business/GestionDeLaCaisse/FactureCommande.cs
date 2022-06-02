using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGC.DataAccess.GestionDeLaCaisse.GestionDeLaCaisseDataSetTableAdapters;
using LGC.DataAccess.GestionDeLaCaisse;

namespace LGC.Business.GestionDeLaCaisse
{
    /// <summary>
    /// 
    /// </summary>
    public class FactureCommande
    {
        #region Constructeurs
        public FactureCommande()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string idFacture;
        private string numCde;
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
        public string IdFacture
        {
            get { return idFacture.Trim(); }
            set { idFacture = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NumCde
        {
            get { return numCde.Trim(); }
            set { numCde = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de FactureCommande
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de FactureCommande
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de FactureCommande
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de FactureCommande
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de FactureCommande
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de FactureCommande
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de FactureCommande
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
        private static TJ_FactureCommandeTableAdapter adapFactureCommande = new TJ_FactureCommandeTableAdapter();
        private static GestionDeLaCaisseDataSet.TJ_FactureCommandeDataTable dtFactureCommande = new GestionDeLaCaisseDataSet.TJ_FactureCommandeDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de FactureCommande
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFactureCommande.PS_FactureCommande_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de FactureCommande
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFactureCommande.PS_FactureCommande_IP(
                idFacture,
                numCde,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de FactureCommande
        /// </summary>
        /// <param name="idFacture"></param>
        /// <param name="numCde"></param>
        /// <param name="numLigne">Le Numéro de Ligne de FactureCommande</param>
        /// <param name="dateCreationServeur">La date de création de FactureCommande</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de FactureCommande</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de FactureCommande</param>
        /// <param name="userLogin">Le User Login de FactureCommande</param>
        /// <param name="supprimer">Supprimer de FactureCommande</param>
        /// <param name="rowvers">Version de ligne de FactureCommande</param>
        /// <returns>Liste FactureCommande</returns>
        public static List<FactureCommande> Liste(
             string mIdFacture,
             string mNumCde,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtFactureCommande = adapFactureCommande.PS_FactureCommande_SP(
                mIdFacture,
                mNumCde,
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
        /// Retourne la liste des FactureCommande
        /// </summary>
        /// <returns>Liste FactureCommande</returns>
        private static List<FactureCommande> pListe()
        {
            List<FactureCommande> mListe = new List<FactureCommande>();
            foreach (GestionDeLaCaisseDataSet.TJ_FactureCommandeRow mLigne in dtFactureCommande)
            {
                FactureCommande oFactureCommande = new FactureCommande();
                oFactureCommande.IdFacture = mLigne.idFacture.Trim();
                oFactureCommande.NumCde = mLigne.numCde.Trim();
                oFactureCommande.NumLigne = mLigne.numLigne;
                oFactureCommande.DateCreationServeur = mLigne.dateCreationServeur;
                oFactureCommande.DateDernModifClient = mLigne.dateDernModifClient;
                oFactureCommande.DateDernModifServeur = mLigne.dateDernModifServeur;
                oFactureCommande.UserLogin = mLigne.userLogin.Trim();
                oFactureCommande.Supprimer = mLigne.supprimer;
                oFactureCommande.Rowvers = mLigne.rowvers;

                mListe.Add(oFactureCommande);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de FactureCommande
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFactureCommande.PS_FactureCommande_UP(
                idFacture,
                numCde,
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
