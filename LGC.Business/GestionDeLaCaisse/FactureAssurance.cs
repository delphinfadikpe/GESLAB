using LGC.DataAccess.GestionDeLaCaisse.GestionDeLaCaisseDataSetTableAdapters;
using LGC.DataAccess.GestionDeLaCaisse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGC.Business.GestionDeLaCaisse
{

    /// <summary>
    /// 
    /// </summary>
    public class FactureAssurance
    {
        #region Constructeurs
        public FactureAssurance()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string idFacture;
        private DateTime dateFacture;
        private DateTime dateDebut;
        private DateTime dateFin;
        private Decimal idPersonne;
        private Decimal montantFacture;
        private Decimal montantRestantAPayer;
        private string typeFacture;
        private string assurance;
        private string numPolice;
        private string estSolde;

      
       
      
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

        public string EstSolde
        {
            get { return estSolde; }
            set { estSolde = value; }
        }

        public string NumPolice
        {
            get { return numPolice; }
            set { numPolice = value; }
        }

        public string Assurance
        {
            get { return assurance; }
            set { assurance = value; }
        }

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
        public DateTime DateFacture
        {
            get { return dateFacture; }
            set { dateFacture = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateDebut
        {
            get { return dateDebut; }
            set { dateDebut = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateFin
        {
            get { return dateFin; }
            set { dateFin = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal IdPersonne
        {
            get { return idPersonne; }
            set { idPersonne = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantFacture
        {
            get { return montantFacture; }
            set { montantFacture = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal MontantRestantAPayer
        {
            get { return montantRestantAPayer; }
            set { montantRestantAPayer = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TypeFacture
        {
            get { return typeFacture.Trim(); }
            set { typeFacture = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de FactureAssurance
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de FactureAssurance
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de FactureAssurance
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de FactureAssurance
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de FactureAssurance
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de FactureAssurance
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de FactureAssurance
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
        private static T_FactureAssuranceTableAdapter adapFactureAssurance = new T_FactureAssuranceTableAdapter();
        private static GestionDeLaCaisseDataSet.T_FactureAssuranceDataTable dtFactureAssurance = new GestionDeLaCaisseDataSet.T_FactureAssuranceDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de FactureAssurance
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFactureAssurance.PS_FactureAssurance_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de FactureAssurance
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFactureAssurance.PS_FactureAssurance_IP(
                idFacture,
                dateFacture,
                dateDebut,
                dateFin,
                idPersonne,
                montantFacture,
                montantRestantAPayer,
                typeFacture,numPolice,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de FactureAssurance
        /// </summary>
        /// <param name="idFacture"></param>
        /// <param name="dateFacture"></param>
        /// <param name="dateDebut"></param>
        /// <param name="dateFin"></param>
        /// <param name="idPersonne"></param>
        /// <param name="montantFacture"></param>
        /// <param name="montantRestantAPayer"></param>
        /// <param name="typeFacture"></param>
        /// <param name="numLigne">Le Numéro de Ligne de FactureAssurance</param>
        /// <param name="dateCreationServeur">La date de création de FactureAssurance</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de FactureAssurance</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de FactureAssurance</param>
        /// <param name="userLogin">Le User Login de FactureAssurance</param>
        /// <param name="supprimer">Supprimer de FactureAssurance</param>
        /// <param name="rowvers">Version de ligne de FactureAssurance</param>
        /// <returns>Liste FactureAssurance</returns>
        public static List<FactureAssurance> Liste(
             string mIdFacture,
             DateTime? mDateFacture,
             DateTime? mDateDebut,
             DateTime? mDateFin,
             Decimal? mIdPersonne,
             Decimal? mMontantFacture,
             Decimal? mMontantRestantAPayer,
             string mTypeFacture,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtFactureAssurance = adapFactureAssurance.PS_FactureAssurance_SP(
                mIdFacture,
                mDateFacture,
                mDateDebut,
                mDateFin,
                mIdPersonne,
                mMontantFacture,
                mMontantRestantAPayer,
                mTypeFacture,
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
        /// Retourne la liste des FactureAssurance
        /// </summary>
        /// <returns>Liste FactureAssurance</returns>
        private static List<FactureAssurance> pListe()
        {
            List<FactureAssurance> mListe = new List<FactureAssurance>();
            foreach (GestionDeLaCaisseDataSet.T_FactureAssuranceRow mLigne in dtFactureAssurance)
            {
                FactureAssurance oFactureAssurance = new FactureAssurance();
                oFactureAssurance.IdFacture = mLigne.idFacture.Trim();
                oFactureAssurance.DateFacture = mLigne.dateFacture;
                oFactureAssurance.DateDebut = mLigne.dateDebut;
                oFactureAssurance.DateFin = mLigne.dateFin;
                oFactureAssurance.IdPersonne = mLigne.idPersonne;
                oFactureAssurance.MontantFacture = mLigne.montantFacture;
                oFactureAssurance.MontantRestantAPayer = mLigne.montantRestantAPayer;
                oFactureAssurance.TypeFacture = mLigne.typeFacture.Trim();
                oFactureAssurance.NumLigne = mLigne.numLigne;
                oFactureAssurance.DateCreationServeur = mLigne.dateCreationServeur;
                oFactureAssurance.DateDernModifClient = mLigne.dateDernModifClient;
                oFactureAssurance.DateDernModifServeur = mLigne.dateDernModifServeur;
                oFactureAssurance.UserLogin = mLigne.userLogin.Trim();
                oFactureAssurance.Supprimer = mLigne.supprimer;
                oFactureAssurance.Rowvers = mLigne.rowvers;
                oFactureAssurance.Assurance = mLigne.assurance;
                oFactureAssurance.NumPolice = mLigne.numPolice;
                oFactureAssurance.EstSolde = mLigne.montantRestantAPayer == 0 ? "SOLDEES" : "NON SOLDEES";
                mListe.Add(oFactureAssurance);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de FactureAssurance
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFactureAssurance.PS_FactureAssurance_UP(
                idFacture,
                dateFacture,
                dateDebut,
                dateFin,
                idPersonne,
                montantFacture,
                montantRestantAPayer,
                typeFacture,numPolice,
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
