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
    public class FacturePartenaire
    {
        #region Constructeurs
        public FacturePartenaire()
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
        private string partenaire;
        private string numPolice;
        private string estSolde;
        private decimal idPaiement;
        private bool aReçuRistourne;
        private decimal montantDemande;

        private string objet;
        private string nb;
        private string reference;
        private Decimal idPersonnePrincipal;
        private string sigFV;
        private string nimFV;
        private string sigFA;
        private string nimFA;

              
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

        public string Objet
        {
            get { return objet; }
            set { objet = value; }
        }


        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }


        public string Nb
        {
            get { return nb; }
            set { nb = value; }
        }

        public bool AReçuRistourne
        {
            get { return aReçuRistourne; }
            set { aReçuRistourne = value; }
        }

        public decimal IdPaiement
        {
            get { return idPaiement; }
            set { idPaiement = value; }
        }

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

        public string Partenaire
        {
            get { return partenaire; }
            set { partenaire = value; }
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

        public decimal MontantDemande
        {
            get { return montantDemande; }
            set { montantDemande = value; }
        }

        public Decimal IdPersonnePrincipal
        {
            get { return idPersonnePrincipal; }
            set { idPersonnePrincipal = value; }
        }


        public string NimFA
        {
            get { return nimFA; }
            set { nimFA = value; }
        }
        public string SigFA
        {
            get { return sigFA; }
            set { sigFA = value; }
        }

        public string NimFV
        {
            get { return nimFV; }
            set { nimFV = value; }
        }

        public string SigFV
        {
            get { return sigFV; }
            set { sigFV = value; }
        }
        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de FacturePartenaire
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de FacturePartenaire
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de FacturePartenaire
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de FacturePartenaire
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de FacturePartenaire
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de FacturePartenaire
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de FacturePartenaire
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
        private static T_FacturePartenaireTableAdapter  adapFacturePartenaire = new T_FacturePartenaireTableAdapter();
        private static GestionDeLaCaisseDataSet.T_FacturePartenaireDataTable dtFacturePartenaire = new GestionDeLaCaisseDataSet.T_FacturePartenaireDataTable();

        private static PS_AutreFacturePartenaire_SPTableAdapter adapAutreFacturePartenaire = new PS_AutreFacturePartenaire_SPTableAdapter();
        private static GestionDeLaCaisseDataSet.PS_AutreFacturePartenaire_SPDataTable dtAutreFacturePartenaire = new GestionDeLaCaisseDataSet.PS_AutreFacturePartenaire_SPDataTable();

        private static PS_FacturePartenaire_SPTableAdapter adapFacturePartenaireSP = new PS_FacturePartenaire_SPTableAdapter();
        private static GestionDeLaCaisseDataSet.PS_FacturePartenaire_SPDataTable dtFacturePartenaireSP= new GestionDeLaCaisseDataSet.PS_FacturePartenaire_SPDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de FacturePartenaire
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFacturePartenaire.PS_FacturePartenaire_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de FacturePartenaire
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFacturePartenaire.PS_FacturePartenaire_IP(
                idFacture,
                dateFacture,
                dateDebut,
                dateFin,
                idPersonne,
                montantFacture,
                montantRestantAPayer,
                typeFacture,numPolice,aReçuRistourne,objet,reference,nb,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de FacturePartenaire
        /// </summary>
        /// <param name="idFacture"></param>
        /// <param name="dateFacture"></param>
        /// <param name="dateDebut"></param>
        /// <param name="dateFin"></param>
        /// <param name="idPersonne"></param>
        /// <param name="montantFacture"></param>
        /// <param name="montantRestantAPayer"></param>
        /// <param name="typeFacture"></param>
        /// <param name="numLigne">Le Numéro de Ligne de FacturePartenaire</param>
        /// <param name="dateCreationServeur">La date de création de FacturePartenaire</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de FacturePartenaire</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de FacturePartenaire</param>
        /// <param name="userLogin">Le User Login de FacturePartenaire</param>
        /// <param name="supprimer">Supprimer de FacturePartenaire</param>
        /// <param name="rowvers">Version de ligne de FacturePartenaire</param>
        /// <returns>Liste FacturePartenaire</returns>
        public static List<FacturePartenaire> Liste(
             string mIdFacture,
             DateTime? mDateFacture,
             DateTime? mDateDebut,
             DateTime? mDateFin,
             Decimal? mIdPersonne,
             Decimal? mMontantFacture,
             Decimal? mMontantRestantAPayer,
             string mTypeFacture,
            bool? mAReçuRistourne,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            adapFacturePartenaireSP.ComTimeout = 0;
            dtFacturePartenaireSP = adapFacturePartenaireSP.GetData(
                mIdFacture,
                mDateFacture,
                mDateDebut,
                mDateFin,
                mIdPersonne,
                mMontantFacture,
                mMontantRestantAPayer,
                mTypeFacture,
                 mAReçuRistourne,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mUserLogin,
                mSupprimer,
                mRowvers);
            List<FacturePartenaire> mListe = new List<FacturePartenaire>();
            foreach (GestionDeLaCaisseDataSet.PS_FacturePartenaire_SPRow mLigne in dtFacturePartenaireSP)
            {
                FacturePartenaire oFacturePartenaire = new FacturePartenaire();
                oFacturePartenaire.IdFacture = mLigne.idFacture.Trim();
                oFacturePartenaire.DateFacture = mLigne.dateFacture;
                oFacturePartenaire.DateDebut = mLigne.dateDebut;
                oFacturePartenaire.DateFin = mLigne.dateFin;
                oFacturePartenaire.IdPersonne = mLigne.idPersonne;
                oFacturePartenaire.MontantFacture = mLigne.montantFacture;
                oFacturePartenaire.MontantRestantAPayer = mLigne.montantRestantAPayer;
                oFacturePartenaire.TypeFacture = mLigne.typeFacture.Trim();
                oFacturePartenaire.NumLigne = mLigne.numLigne;
                oFacturePartenaire.DateCreationServeur = mLigne.dateCreationServeur;
                oFacturePartenaire.DateDernModifClient = mLigne.dateDernModifClient;
                oFacturePartenaire.DateDernModifServeur = mLigne.dateDernModifServeur;
                oFacturePartenaire.UserLogin = mLigne.userLogin.Trim();
                oFacturePartenaire.Supprimer = mLigne.supprimer;
                oFacturePartenaire.Rowvers = mLigne.rowvers;
                oFacturePartenaire.Partenaire = mLigne.partenaire;
                oFacturePartenaire.NumPolice = mLigne.numPolice;
                oFacturePartenaire.EstSolde = mLigne.montantRestantAPayer == 0 ? "SOLDEES" : "NON SOLDEES";
                oFacturePartenaire.IdPaiement = mLigne.idPaiement;
                oFacturePartenaire.AReçuRistourne = mLigne.aReçuRistourne;
                oFacturePartenaire.MontantDemande = mLigne.montantDemande;
                oFacturePartenaire.Objet = mLigne.objet;
                oFacturePartenaire.Reference = mLigne.reference;
                oFacturePartenaire.Nb = mLigne.nb;
                oFacturePartenaire.IdPersonnePrincipal = mLigne.idPersonnePrincipal;

                try
                {
                    oFacturePartenaire.SigFV = mLigne.sigFV;
                }
                catch { }
                try
                {
                    oFacturePartenaire.NimFV = mLigne.nimFV;
                }
                catch { }
                try
                {
                    oFacturePartenaire.SigFA = mLigne.sigFA;
                }
                catch { }
                try
                {
                    oFacturePartenaire.NimFA = mLigne.nimFA;
                }
                catch { }
                mListe.Add(oFacturePartenaire);
            }
            return mListe;
        }


        public static List<FacturePartenaire> Liste1(
             string mIdFacture,
             DateTime? mDateFacture,
             DateTime? mDateDebut,
             DateTime? mDateFin,
             Decimal? mIdPersonne,
             Decimal? mMontantFacture,
             Decimal? mMontantRestantAPayer,
             string mTypeFacture,
            bool? mAReçuRistourne,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {

            dtAutreFacturePartenaire = adapAutreFacturePartenaire.GetData(
                mIdFacture,
                mDateFacture,
                mDateDebut,
                mDateFin,
                mIdPersonne,
                mMontantFacture,
                mMontantRestantAPayer,
                mTypeFacture,
                 mAReçuRistourne,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mUserLogin,
                mSupprimer,
                mRowvers);
            List<FacturePartenaire> mListe = new List<FacturePartenaire>();
            foreach (GestionDeLaCaisseDataSet.PS_AutreFacturePartenaire_SPRow mLigne in dtAutreFacturePartenaire)
            {
                FacturePartenaire oFacturePartenaire = new FacturePartenaire();
                oFacturePartenaire.IdFacture = mLigne.idFacture.Trim();
                oFacturePartenaire.DateFacture = mLigne.dateFacture;
                oFacturePartenaire.DateDebut = mLigne.dateDebut;
                oFacturePartenaire.DateFin = mLigne.dateFin;
                oFacturePartenaire.IdPersonne = mLigne.idPersonne;
                oFacturePartenaire.MontantFacture = mLigne.montantFacture;
                oFacturePartenaire.MontantRestantAPayer = mLigne.montantRestantAPayer;
                oFacturePartenaire.TypeFacture = mLigne.typeFacture.Trim();
                oFacturePartenaire.NumLigne = mLigne.numLigne;
                oFacturePartenaire.DateCreationServeur = mLigne.dateCreationServeur;
                oFacturePartenaire.DateDernModifClient = mLigne.dateDernModifClient;
                oFacturePartenaire.DateDernModifServeur = mLigne.dateDernModifServeur;
                oFacturePartenaire.UserLogin = mLigne.userLogin.Trim();
                oFacturePartenaire.Supprimer = mLigne.supprimer;
                oFacturePartenaire.Rowvers = mLigne.rowvers;
                oFacturePartenaire.Partenaire = mLigne.partenaire;
                oFacturePartenaire.NumPolice = mLigne.numPolice;
                oFacturePartenaire.EstSolde = mLigne.montantRestantAPayer == 0 ? "SOLDEES" : "NON SOLDEES";
                oFacturePartenaire.IdPaiement = mLigne.idPaiement;
                oFacturePartenaire.AReçuRistourne = mLigne.aReçuRistourne;
                oFacturePartenaire.MontantDemande = mLigne.montantDemande;
                oFacturePartenaire.Objet = mLigne.objet;
                oFacturePartenaire.Reference = mLigne.reference;
                oFacturePartenaire.Nb = mLigne.nb;
                oFacturePartenaire.IdPersonnePrincipal = mLigne.idPersonnePrincipal;
                mListe.Add(oFacturePartenaire);
            }
            return mListe;
        }


        /// <summary>
        /// Retourne la liste des FacturePartenaire
        /// </summary>
        /// <returns>Liste FacturePartenaire</returns>
        private static List<FacturePartenaire> pListe()
        {
            List<FacturePartenaire> mListe = new List<FacturePartenaire>();
            foreach (GestionDeLaCaisseDataSet.T_FacturePartenaireRow mLigne in dtFacturePartenaire)
            {
                FacturePartenaire oFacturePartenaire = new FacturePartenaire();
                oFacturePartenaire.IdFacture = mLigne.idFacture.Trim();
                oFacturePartenaire.DateFacture = mLigne.dateFacture;
                oFacturePartenaire.DateDebut = mLigne.dateDebut;
                oFacturePartenaire.DateFin = mLigne.dateFin;
                oFacturePartenaire.IdPersonne = mLigne.idPersonne;
                oFacturePartenaire.MontantFacture = mLigne.montantFacture;
                oFacturePartenaire.MontantRestantAPayer = mLigne.montantRestantAPayer;
                oFacturePartenaire.TypeFacture = mLigne.typeFacture.Trim();
                oFacturePartenaire.NumLigne = mLigne.numLigne;
                oFacturePartenaire.DateCreationServeur = mLigne.dateCreationServeur;
                oFacturePartenaire.DateDernModifClient = mLigne.dateDernModifClient;
                oFacturePartenaire.DateDernModifServeur = mLigne.dateDernModifServeur;
                oFacturePartenaire.UserLogin = mLigne.userLogin.Trim();
                oFacturePartenaire.Supprimer = mLigne.supprimer;
                oFacturePartenaire.Rowvers = mLigne.rowvers;
                oFacturePartenaire.Partenaire = mLigne.partenaire;
                oFacturePartenaire.NumPolice = mLigne.numPolice;
                oFacturePartenaire.EstSolde = mLigne.montantRestantAPayer == 0 ? "SOLDEES" : "NON SOLDEES";
                oFacturePartenaire.IdPaiement = mLigne.idPaiement;
                oFacturePartenaire.AReçuRistourne = mLigne.aReçuRistourne;
                oFacturePartenaire.MontantDemande = mLigne.montantDemande;
                oFacturePartenaire.Objet = mLigne.objet;
                oFacturePartenaire.Reference = mLigne.reference;
                oFacturePartenaire.Nb = mLigne.nb;
                oFacturePartenaire.IdPersonnePrincipal = mLigne.idPersonnePrincipal;
                mListe.Add(oFacturePartenaire);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de FacturePartenaire
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFacturePartenaire.PS_FacturePartenaire_UP(
                idFacture,
                dateFacture,
                dateDebut,
                dateFin,
                idPersonne,
                montantFacture,
                montantRestantAPayer,
                typeFacture,numPolice,aReçuRistourne,objet,reference,nb,
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
