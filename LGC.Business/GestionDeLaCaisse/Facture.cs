using LGC.DataAccess.GestionDeLaCaisse;
using LGC.DataAccess.GestionDeLaCaisse.GestionDeLaCaisseDataSetTableAdapters;
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
    public class Facture
    {
        #region Constructeurs
        public Facture()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string idFacture;
        private DateTime dateFacture;
        private Decimal montantFacture;
        private Decimal montantRestantAPayer;
        private string typeFacture;
        private decimal idPersonne;
        private string patient;
        private bool estAnnulee;
        private bool estSurComptePartenaire;
        private decimal tauxCouverture;
        private decimal montantCouverture;
        private decimal montantBase;
        private string soldeParClient;
        private decimal montantBrut;
        private decimal remise;
        private string statut;
        private decimal montantClient;
        private bool valideParAssurance;

        
       
       
        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private DateTime dateCreationServeur;
        private DateTime dateDernModifClient;
        private DateTime dateDernModifServeur;
        private string userLogin;
        private bool supprimer;
        private Byte[] rowvers;
        private Decimal numDemande;
        private string idFactureAssurance;
        private string idFacturePartenaire;
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

        public decimal MontantClient
        {
            get { return montantClient; }
            set { montantClient = value; }
        }

        public string Statut
        {
            get { return statut; }
            set { statut = value; }
        }
       

        public decimal Remise
        {
            get { return remise; }
            set { remise = value; }
        }
        public decimal MontantBrut
        {
            get { return montantBrut; }
            set { montantBrut = value; }
        }
        

        public decimal MontantBase
        {
            get { return montantBase; }
            set { montantBase = value; }
        }
        

        public decimal MontantCouverture
        {
            get { return montantCouverture; }
            set { montantCouverture = value; }
        }

        public decimal TauxCouverture
        {
            get { return tauxCouverture; }
            set { tauxCouverture = value; }
        }
        public bool EstSurComptePartenaire
        {
            get { return estSurComptePartenaire; }
            set { estSurComptePartenaire = value; }
        }

        public bool EstAnnulee
        {
            get { return estAnnulee; }
            set { estAnnulee = value; }
        }

        public string Patient
        {
            get { return patient; }
            set { patient = value; }
        }
        public decimal IdPersonne
        {
            get { return idPersonne; }
            set { idPersonne = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string IdFacture
        {
            get { return idFacture; }
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

        public string SoldeParClient
        {
            get { return soldeParClient; }
            set { soldeParClient = value; }
        }

        public bool ValideParAssurance
        {
            get { return valideParAssurance; }
            set { valideParAssurance = value; }
        }
        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Facture
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Facture
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Facture
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Facture
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Facture
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Facture
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Facture
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
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
        public string IdFactureAssurance
        {
            get { return idFactureAssurance; }
            set { idFactureAssurance = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string IdFacturePartenaire
        {
            get { return idFacturePartenaire; }
            set { idFacturePartenaire = value; }
        }

        #endregion Passe partout
        #endregion Elémentaires

        #region Objets

        #endregion Objets

        #region Collections

        #endregion Collections
        #endregion Propriétés

        #region Variables
        private static T_FactureTableAdapter adapFacture = new T_FactureTableAdapter();
        private static GestionDeLaCaisseDataSet.T_FactureDataTable dtFacture = new GestionDeLaCaisseDataSet.T_FactureDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Facture
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFacture.PS_Facture_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Facture
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFacture.PS_Facture_IP(
                idFacture,
                dateFacture,
                montantFacture,
                montantRestantAPayer,
                typeFacture,
                numDemande,
                idFactureAssurance,
                idFacturePartenaire,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Facture
        /// </summary>
        /// <param name="idFacture"></param>
        /// <param name="dateFacture"></param>
        /// <param name="montantFacture"></param>
        /// <param name="montantRestantAPayer"></param>
        /// <param name="typeFacture"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Facture</param>
        /// <param name="dateCreationServeur">La date de création de Facture</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Facture</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Facture</param>
        /// <param name="userLogin">Le User Login de Facture</param>
        /// <param name="supprimer">Supprimer de Facture</param>
        /// <param name="rowvers">Version de ligne de Facture</param>
        /// <param name="numDemande"></param>
        /// <returns>Liste Facture</returns>
        public static List<Facture> Liste(
             string mIdFacture,
             DateTime? mDateFacture,
             Decimal? mMontantFacture,
             Decimal? mMontantRestantAPayer,
             string mTypeFacture,
             Decimal? idPersonnePartenaire  
	        ,Decimal? idPersonneAssurance  
	        ,string idFactureAssurance  
	        ,string idFacturePartenaire  
             ,Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers,
             Decimal? mNumDemande,
            DateTime? mDateDebut,
            DateTime? mDateFin)
        {
            adapFacture.ComTimeout = 0;
            dtFacture = adapFacture.PS_Facture_SP(
                mIdFacture,
                mDateFacture,
                mMontantFacture,
                mMontantRestantAPayer,
                mTypeFacture,
                idPersonnePartenaire,
                idPersonneAssurance,
                idFactureAssurance,
                idFacturePartenaire,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mUserLogin,
                mSupprimer,
                mRowvers,
                mNumDemande,
                mDateDebut,
                mDateFin);
            return pListe();
        }


        /// <summary>
        /// Retourne la liste de Facture
        /// </summary>
        /// <param name="idFacture"></param>
        /// <param name="dateFacture"></param>
        /// <param name="montantFacture"></param>
        /// <param name="montantRestantAPayer"></param>
        /// <param name="typeFacture"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Facture</param>
        /// <param name="dateCreationServeur">La date de création de Facture</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Facture</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Facture</param>
        /// <param name="userLogin">Le User Login de Facture</param>
        /// <param name="supprimer">Supprimer de Facture</param>
        /// <param name="rowvers">Version de ligne de Facture</param>
        /// <param name="numDemande"></param>
        /// <returns>Liste Facture</returns>
        public static List<Facture> Liste1(           
             Decimal? idPersonnePartenaire
           )
        {
            dtFacture = adapFacture.PS_Facture_SP1(idPersonnePartenaire);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des Facture
        /// </summary>
        /// <returns>Liste Facture</returns>
        private static List<Facture> pListe()
        {
            List<Facture> mListe = new List<Facture>();
            foreach (GestionDeLaCaisseDataSet.T_FactureRow mLigne in dtFacture)
            {
                Facture oFacture = new Facture();
                oFacture.IdFacture = mLigne.idFacture;
                oFacture.DateFacture = mLigne.dateFacture;
                oFacture.MontantFacture = mLigne.montantFacture;
                oFacture.MontantRestantAPayer = mLigne.montantRestantAPayer;
                oFacture.TypeFacture = mLigne.typeFacture.Trim();
                oFacture.NumLigne = mLigne.numLigne;
                oFacture.DateCreationServeur = mLigne.dateCreationServeur;
                oFacture.DateDernModifClient = mLigne.dateDernModifClient;
                oFacture.DateDernModifServeur = mLigne.dateDernModifServeur;
                oFacture.UserLogin = mLigne.userLogin.Trim();
                oFacture.Supprimer = mLigne.supprimer;
                oFacture.Rowvers = mLigne.rowvers;
                oFacture.NumDemande = mLigne.numDemande;
                oFacture.IdFactureAssurance = mLigne.idFactureAssurance;
                oFacture.IdFacturePartenaire = mLigne.idFacturePartenaire;
                oFacture.IdPersonne = mLigne.idPersonne;
                oFacture.Patient = mLigne.patient;
                oFacture.EstAnnulee = mLigne.estAnnulee;
                oFacture.EstSurComptePartenaire = mLigne.estSurComptePartenaire;
                oFacture.TauxCouverture = mLigne.tauxCouverture;
                oFacture.MontantCouverture = mLigne.montantCouverture;
                oFacture.MontantBase = mLigne.montantBase;
                oFacture.SoldeParClient = mLigne.montantRestantAPayer==0?"SOLDEES":"NON SOLDEES";
                oFacture.Statut = mLigne.estSurComptePartenaire == true ? "A PAYER AU LABORATOIRE" : "A LA CHARGE DU PATIENT";
                oFacture.MontantBrut = mLigne.montantBrut;
                oFacture.Remise = mLigne.Remise;
                oFacture.MontantClient = mLigne.montantBase - mLigne.montantCouverture;
                oFacture.ValideParAssurance = mLigne.valideParAssurance;
                mListe.Add(oFacture);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Facture
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFacture.PS_Facture_UP(
                idFacture.Trim(),
                dateFacture,
                montantFacture,
                montantRestantAPayer,
                typeFacture,
                numDemande,
                idFactureAssurance,
                idFacturePartenaire,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        public static Facture FindFirst(string mIdFacture, Decimal mNumDemande)
        {
            dtFacture = adapFacture.PS_Facture_SP(
                mIdFacture,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                false,
                null,
                mNumDemande,
                null,null);
            if (dtFacture.Rows.Count > 0)
                return pListe()[0];
            else
                return null;
        }

        public static Facture FindFirst1(string mIdFacture, Decimal mNumDemande)
        {
            dtFacture = adapFacture.PS_Facture_SP(
                mIdFacture,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                false,
                null,
                mNumDemande, null, null);
            if (dtFacture.Rows.Count > 0)
                return pListe()[0];
            else
                return null;
        }


        #endregion Interfaces

        #region Gestion des collections

        #endregion Gestion des collections

        #region Métier

        #endregion Métier
        #endregion Méthodes
    }

}
