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
    public class Partenaires : Personne
    {
        #region Constructeurs
        public Partenaires()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idPersonne;
        public Decimal tauxRistourne;
        public bool? estTauxVariable;

        public bool? EstTauxVariable
        {
            get { return estTauxVariable; }
            set { estTauxVariable = value; }
        }

       
        public string typePartenaire;
        private string nomSigle;
        private string prenomRaisonSociale;

        public string PrenomRaisonSociale
        {
            get { return prenomRaisonSociale; }
            set { prenomRaisonSociale = value; }
        }

        public string NomSigle
        {
            get { return nomSigle; }
            set { nomSigle = value; }
        }

        private string intitule;

        public string Intitule
        {
            get { return intitule; }
            set { intitule = value; }
        }

        private bool aRistourneFinPeriode;

        public bool ARistourneFinPeriode
        {
            get { return aRistourneFinPeriode; }
            set { aRistourneFinPeriode = value; }
        }

        private decimal idPersonnePrincipal;

        public decimal IdPersonnePrincipal
        {
            get { return idPersonnePrincipal; }
            set { idPersonnePrincipal = value; }
        }


        private string conditionPartenaire;

        public string ConditionPartenaire
        {
            get { return conditionPartenaire; }
            set { conditionPartenaire = value; }
        }
        private decimal montantImpaye;

        public decimal MontantImpaye
        {
            get { return montantImpaye; }
            set { montantImpaye = value; }
        }

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
        public Decimal IdPersonne
        {
            get { return idPersonne; }
            set { idPersonne = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal TauxRistourne
        {
            get { return tauxRistourne; }
            set { tauxRistourne = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TypePartenaire
        {
            get { return typePartenaire.Trim(); }
            set { typePartenaire = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Partenaires
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Partenaires
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Partenaires
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Partenaires
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Partenaires
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Partenaires
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Partenaires
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
        private static T_PartenairesTableAdapter adapPartenaires = new T_PartenairesTableAdapter();
        private static ParametreDataSet1.T_PartenairesDataTable dtPartenaires = new ParametreDataSet1.T_PartenairesDataTable();
        private static PS_Partenaire_SP_ALLTableAdapter adapPartenaires_SP_ALL = new PS_Partenaire_SP_ALLTableAdapter();
        private static ParametreDataSet1.PS_Partenaire_SP_ALLDataTable dtPartenaires_SP_ALL = new ParametreDataSet1.PS_Partenaire_SP_ALLDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Partenaires
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPartenaires.PS_Partenaires_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Partenaires
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPartenaires.PS_Partenaires_IP(
                idPersonne,
                CodePays,
                CodeLangue,
                estActif,
                LibelleTypePersonne,
                EstActifPersonne,
                telephoneMobile1,
                telephoneMobile2,
                email,
                adresseComplete,
                tauxRistourne,
                estTauxVariable,
                typePartenaire,
                adresseComplete,aRistourneFinPeriode,idPersonnePrincipal,conditionPartenaire,montantImpaye,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Partenaires
        /// </summary>
        /// <param name="idPersonne"></param>
        /// <param name="CodePays"></param>
        /// <param name="CodeLangue">Langue de l'utilisateur de Partenaires</param>
        /// <param name="estActif"></param>
        /// <param name="LibelleTypePersonne"></param>
        /// <param name="EstActifPersonne"></param>
        /// <param name="telephoneMobile1"></param>
        /// <param name="telephoneMobile2"></param>
        /// <param name="email"></param>
        /// <param name="adresseComplete"></param>
        /// <param name="tauxRistourne"></param>
        /// <param name="typePartenaire"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Partenaires</param>
        /// <param name="dateCreationServeur">La date de création de Partenaires</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Partenaires</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Partenaires</param>
        /// <param name="userLogin">Le User Login de Partenaires</param>
        /// <param name="supprimer">Supprimer de Partenaires</param>
        /// <param name="rowvers">Version de ligne de Partenaires</param>
        /// <returns>Liste Partenaires</returns>
        public static List<Partenaires> Liste(
             Decimal? mIdPersonne,
             string mCodePays,
             string mCodeLangue,
             bool? mEstActif,
             string mLibelleTypePersonne,
             bool? mEstActifPersonne,
             string mTelephoneMobile1,
             string mTelephoneMobile2,
             string mEmail,
             string mAdresseComplete,
             Decimal? mTauxRistourne,
             bool? mEstTauxVariable,
             string mTypePartenaire,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtPartenaires = adapPartenaires.PS_Partenaires_SP(
                mIdPersonne,
                mCodePays,
                mCodeLangue,
                mEstActif,
                mLibelleTypePersonne,
                mEstActifPersonne,
                mTelephoneMobile1,
                mTelephoneMobile2,
                mEmail,
                mAdresseComplete,
                mTauxRistourne,
                mEstTauxVariable,
                mTypePartenaire,
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
        /// Retourne la liste des Partenaires
        /// </summary>
        /// <returns>Liste Partenaires</returns>
        private static List<Partenaires> pListe()
        {
            List<Partenaires> mListe = new List<Partenaires>();
            foreach (ParametreDataSet1.T_PartenairesRow mLigne in dtPartenaires)
            {
                Partenaires oPartenaires = new Partenaires();
                oPartenaires.IdPersonne = mLigne.idPersonne;
                oPartenaires.CodePays = mLigne.CodePays.Trim();
                oPartenaires.CodeLangue = mLigne.CodeLangue.Trim();
                oPartenaires.EstActif = mLigne.estActif;
                oPartenaires.LibelleTypePersonne = mLigne.LibelleTypePersonne.Trim();
                oPartenaires.EstActifPersonne = mLigne.EstActifPersonne;
                oPartenaires.TelephoneMobile1 = mLigne.telephoneMobile1.Trim();
                oPartenaires.TelephoneMobile2 = mLigne.telephoneMobile2.Trim();
                oPartenaires.Email = mLigne.email.Trim();
                oPartenaires.AdresseComplete = mLigne.adresseComplete.Trim();
                oPartenaires.TauxRistourne = mLigne.tauxRistourne;
                oPartenaires.EstTauxVariable = mLigne.estTauxVariable;
                oPartenaires.TypePartenaire = mLigne.typePartenaire.Trim();
                oPartenaires.NumLigne = mLigne.numLigne;
                oPartenaires.DateCreationServeur = mLigne.dateCreationServeur;
                oPartenaires.DateDernModifClient = mLigne.dateDernModifClient;
                oPartenaires.DateDernModifServeur = mLigne.dateDernModifServeur;
                oPartenaires.UserLogin = mLigne.userLogin.Trim();
                oPartenaires.Supprimer = mLigne.supprimer;
                oPartenaires.Rowvers = mLigne.rowvers;
                oPartenaires.ARistourneFinPeriode = mLigne.aRistourneFinPeriode;
                oPartenaires.IdPersonnePrincipal = mLigne.idPersonnePrincipal;
                oPartenaires.ConditionPartenaire = mLigne.conditionPartenaire;
                oPartenaires.MontantImpaye = mLigne.montantImpaye;
                mListe.Add(oPartenaires);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Partenaires
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPartenaires.PS_Partenaires_UP(
                idPersonne,
                CodePays,
                CodeLangue,
                estActif,
                LibelleTypePersonne,
                EstActifPersonne,
                telephoneMobile1,
                telephoneMobile2,
                email,
                adresseComplete,
                tauxRistourne,
                estTauxVariable,
                typePartenaire,
                adresseComplete, aRistourneFinPeriode, idPersonnePrincipal, conditionPartenaire, montantImpaye,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        public static List<Partenaires> ListePartenairesAll()
        {
            dtPartenaires_SP_ALL= adapPartenaires_SP_ALL.GetData();
            List<Partenaires> mListe = new List<Partenaires>();
            foreach (ParametreDataSet1.PS_Partenaire_SP_ALLRow mLigne in dtPartenaires_SP_ALL)
            {
                Partenaires oPartenaires = new Partenaires();
                oPartenaires.IdPersonne = mLigne.idPersonne;
                oPartenaires.NomSigle = mLigne.nomSigle.Trim();
                oPartenaires.PrenomRaisonSociale = mLigne.prenomRaisonSociale.Trim();
                oPartenaires.TauxRistourne = mLigne.tauxRistourne;
                oPartenaires.Intitule = mLigne.nomSigle.Trim() +" " + mLigne.prenomRaisonSociale.Trim();
                oPartenaires.IdPersonnePrincipal = mLigne.idPersonnePrincipal;
                oPartenaires.ConditionPartenaire = mLigne.conditionPartenaire;
                mListe.Add(oPartenaires);
            }
            return mListe;
        }

        #endregion Interfaces

        #region Gestion des collections

        #endregion Gestion des collections

        #region Métier

        #endregion Métier
        #endregion Méthodes
    }
}


