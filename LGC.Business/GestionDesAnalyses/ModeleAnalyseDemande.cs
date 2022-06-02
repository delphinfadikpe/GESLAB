using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGC.DataAccess.Parametre;
using LGC.DataAccess.Parametre.ParametreDataSet2TableAdapters;

namespace LGC.Business.GestionDesAnalyses
{
    /// <summary>
    /// 
    /// </summary>
    public class ModeleAnalyseDemande
    {
        #region Constructeurs
        public ModeleAnalyseDemande()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeAnalyse;
        private Decimal numDemande;
        private string type;
        private string libelleAnalyse;

        
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
        public Decimal NumDemande
        {
            get { return numDemande; }
            set { numDemande = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            get { return type.Trim(); }
            set { type = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de ModeleAnalyseDemande
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de ModeleAnalyseDemande
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de ModeleAnalyseDemande
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de ModeleAnalyseDemande
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de ModeleAnalyseDemande
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de ModeleAnalyseDemande
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de ModeleAnalyseDemande
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
        private static TJ_ModeleAnalyseDemandeTableAdapter adapModeleAnalyseDemande = new TJ_ModeleAnalyseDemandeTableAdapter();
        private static ParametreDataSet2.TJ_ModeleAnalyseDemandeDataTable dtModeleAnalyseDemande = new ParametreDataSet2.TJ_ModeleAnalyseDemandeDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de ModeleAnalyseDemande
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapModeleAnalyseDemande.PS_ModeleAnalyseDemande_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de ModeleAnalyseDemande
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapModeleAnalyseDemande.PS_ModeleAnalyseDemande_IP(
                codeAnalyse,
                numDemande,
                type,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de ModeleAnalyseDemande
        /// </summary>
        /// <param name="codeAnalyse"></param>
        /// <param name="numDemande"></param>
        /// <param name="type"></param>
        /// <param name="numLigne">Le Numéro de Ligne de ModeleAnalyseDemande</param>
        /// <param name="dateCreationServeur">La date de création de ModeleAnalyseDemande</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de ModeleAnalyseDemande</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ModeleAnalyseDemande</param>
        /// <param name="userLogin">Le User Login de ModeleAnalyseDemande</param>
        /// <param name="supprimer">Supprimer de ModeleAnalyseDemande</param>
        /// <param name="rowvers">Version de ligne de ModeleAnalyseDemande</param>
        /// <returns>Liste ModeleAnalyseDemande</returns>
        public static List<ModeleAnalyseDemande> Liste(
             string mCodeAnalyse,
             Decimal? mNumDemande,
             string mType,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtModeleAnalyseDemande = adapModeleAnalyseDemande.PS_ModeleAnalyseDemande_SP(
                mCodeAnalyse,
                mNumDemande,
                mType,
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
        /// Retourne la liste des ModeleAnalyseDemande
        /// </summary>
        /// <returns>Liste ModeleAnalyseDemande</returns>
        private static List<ModeleAnalyseDemande> pListe()
        {
            List<ModeleAnalyseDemande> mListe = new List<ModeleAnalyseDemande>();
            foreach (ParametreDataSet2.TJ_ModeleAnalyseDemandeRow mLigne in dtModeleAnalyseDemande)
            {
                ModeleAnalyseDemande oModeleAnalyseDemande = new ModeleAnalyseDemande();
                oModeleAnalyseDemande.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oModeleAnalyseDemande.NumDemande = mLigne.numDemande;
                oModeleAnalyseDemande.Type = mLigne.type.Trim();
                oModeleAnalyseDemande.NumLigne = mLigne.numLigne;
                oModeleAnalyseDemande.DateCreationServeur = mLigne.dateCreationServeur;
                oModeleAnalyseDemande.DateDernModifClient = mLigne.dateDernModifClient;
                oModeleAnalyseDemande.DateDernModifServeur = mLigne.dateDernModifServeur;
                oModeleAnalyseDemande.UserLogin = mLigne.userLogin.Trim();
                oModeleAnalyseDemande.Supprimer = mLigne.supprimer;
                oModeleAnalyseDemande.Rowvers = mLigne.rowvers;
                oModeleAnalyseDemande.LibelleAnalyse = mLigne.libelleAnalyse;
                mListe.Add(oModeleAnalyseDemande);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de ModeleAnalyseDemande
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapModeleAnalyseDemande.PS_ModeleAnalyseDemande_UP(
                codeAnalyse,
                numDemande,
                type,
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
