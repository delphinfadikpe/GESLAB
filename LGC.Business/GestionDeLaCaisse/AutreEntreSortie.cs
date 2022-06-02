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
    public class AutreEntreSortie
    {
        #region Constructeurs
        public AutreEntreSortie()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idOperationEntreSortie;
        private DateTime dateOperation;
        private string typeOperation;
        private string justification;
        private Decimal montant;
        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private DateTime dateCreationServeur;
        private DateTime dateDernModifClient;
        private DateTime dateDernModifServeur;
        private string userLogin;
        private bool supprimer;
        private Byte[] rowvers;
        private string modeReglement;
        private string reference;
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
        public Decimal IdOperationEntreSortie
        {
            get { return idOperationEntreSortie; }
            set { idOperationEntreSortie = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateOperation
        {
            get { return dateOperation; }
            set { dateOperation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TypeOperation
        {
            get { return typeOperation.Trim(); }
            set { typeOperation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Justification
        {
            get { return justification.Trim(); }
            set { justification = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de AutreEntreSortie
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de AutreEntreSortie
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de AutreEntreSortie
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de AutreEntreSortie
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de AutreEntreSortie
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de AutreEntreSortie
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de AutreEntreSortie
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ModeReglement
        {
            get { return modeReglement.Trim(); }
            set { modeReglement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Reference
        {
            get { return reference.Trim(); }
            set { reference = value; }
        }

        #endregion Passe partout
        #endregion Elémentaires

        #region Objets

        #endregion Objets

        #region Collections

        #endregion Collections
        #endregion Propriétés

        #region Variables
        private static T_AutreEntreSortieTableAdapter adapAutreEntreSortie = new T_AutreEntreSortieTableAdapter();
        private static GestionDeLaCaisseDataSet.T_AutreEntreSortieDataTable dtAutreEntreSortie = new GestionDeLaCaisseDataSet.T_AutreEntreSortieDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de AutreEntreSortie
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAutreEntreSortie.PS_AutreEntreSortie_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de AutreEntreSortie
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAutreEntreSortie.PS_AutreEntreSortie_IP(
                idOperationEntreSortie,
                dateOperation,
                typeOperation,
                justification,
                montant,
                modeReglement,
                reference,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de AutreEntreSortie
        /// </summary>
        /// <param name="idOperationEntreSortie"></param>
        /// <param name="dateOperation"></param>
        /// <param name="typeOperation"></param>
        /// <param name="justification"></param>
        /// <param name="montant"></param>
        /// <param name="numLigne">Le Numéro de Ligne de AutreEntreSortie</param>
        /// <param name="dateCreationServeur">La date de création de AutreEntreSortie</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de AutreEntreSortie</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de AutreEntreSortie</param>
        /// <param name="userLogin">Le User Login de AutreEntreSortie</param>
        /// <param name="supprimer">Supprimer de AutreEntreSortie</param>
        /// <param name="rowvers">Version de ligne de AutreEntreSortie</param>
        /// <param name="modeReglement"></param>
        /// <param name="reference"></param>
        /// <returns>Liste AutreEntreSortie</returns>
        public static List<AutreEntreSortie> Liste(
             Decimal? mIdOperationEntreSortie,
             DateTime? mDateOperation,
             string mTypeOperation,
             string mJustification,
             Decimal? mMontant,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers,
             string mModeReglement,
             string mReference)
        {
            dtAutreEntreSortie = adapAutreEntreSortie.PS_AutreEntreSortie_SP(
                mIdOperationEntreSortie,
                mDateOperation,
                mTypeOperation,
                mJustification,
                mMontant,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mUserLogin,
                mSupprimer,
                mRowvers,
                mModeReglement,
                mReference);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des AutreEntreSortie
        /// </summary>
        /// <returns>Liste AutreEntreSortie</returns>
        private static List<AutreEntreSortie> pListe()
        {
            List<AutreEntreSortie> mListe = new List<AutreEntreSortie>();
            foreach (GestionDeLaCaisseDataSet.T_AutreEntreSortieRow mLigne in dtAutreEntreSortie)
            {
                AutreEntreSortie oAutreEntreSortie = new AutreEntreSortie();
                oAutreEntreSortie.IdOperationEntreSortie = mLigne.idOperationEntreSortie;
                oAutreEntreSortie.DateOperation = mLigne.dateOperation;
                oAutreEntreSortie.TypeOperation = mLigne.typeOperation.Trim();
                oAutreEntreSortie.Justification = mLigne.justification.Trim();
                oAutreEntreSortie.Montant = mLigne.montant;
                oAutreEntreSortie.NumLigne = mLigne.numLigne;
                oAutreEntreSortie.DateCreationServeur = mLigne.dateCreationServeur;
                oAutreEntreSortie.DateDernModifClient = mLigne.dateDernModifClient;
                oAutreEntreSortie.DateDernModifServeur = mLigne.dateDernModifServeur;
                oAutreEntreSortie.UserLogin = mLigne.userLogin.Trim();
                oAutreEntreSortie.Supprimer = mLigne.supprimer;
                oAutreEntreSortie.Rowvers = mLigne.rowvers;
                oAutreEntreSortie.ModeReglement = mLigne.modeReglement.Trim();
                oAutreEntreSortie.Reference = mLigne.reference.Trim();

                mListe.Add(oAutreEntreSortie);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de AutreEntreSortie
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAutreEntreSortie.PS_AutreEntreSortie_UP(
                idOperationEntreSortie,
                dateOperation,
                typeOperation,
                justification,
                montant,
                modeReglement,
                reference,
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
