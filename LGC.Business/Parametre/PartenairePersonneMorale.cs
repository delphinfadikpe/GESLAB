
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
    public class PartenairePersonneMorale : Partenaires
    {
        #region Constructeurs
        public PartenairePersonneMorale()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idPersonne;
        private string libelleSecteurActivite;
        private string codeFormeJuridique;
        private string numeroAgrementPersonneMorale;
        private Decimal capitalSocial;
        private string siglePersonneMorale;
        private string raisonSociale;
        private string logo;
        private bool aRistourneFinPeriode;
        private Decimal idPersonnePrincipal;
        private string intitule;
        private string conditionPartenaire;
        private decimal montantImpaye;
        
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
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
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
        public string LibelleSecteurActivite
        {
            get { return libelleSecteurActivite.Trim(); }
            set { libelleSecteurActivite = value; }
        }

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
        public string NumeroAgrementPersonneMorale
        {
            get { return numeroAgrementPersonneMorale.Trim(); }
            set { numeroAgrementPersonneMorale = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal CapitalSocial
        {
            get { return capitalSocial; }
            set { capitalSocial = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SiglePersonneMorale
        {
            get { return siglePersonneMorale.Trim(); }
            set { siglePersonneMorale = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string RaisonSociale
        {
            get { return raisonSociale.Trim(); }
            set { raisonSociale = value; }
        }

        public bool ARistourneFinPeriode
        {
            get { return aRistourneFinPeriode; }
            set { aRistourneFinPeriode = value; }
        }

        public decimal IdPersonnePrincipal
        {
            get { return idPersonnePrincipal; }
            set { idPersonnePrincipal = value; }
        }
        public string Intitule
        {
            get { return intitule; }
            set { intitule = value; }
        }

        public string ConditionPartenaire
        {
            get { return conditionPartenaire; }
            set { conditionPartenaire = value; }
        }


        public decimal MontantImpaye
        {
            get { return montantImpaye; }
            set { montantImpaye = value; }
        }
        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de PartenairePersonneMorale
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de PartenairePersonneMorale
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de PartenairePersonneMorale
        /// </summary>
        public  DateTime DateDernModifClient 
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de PartenairePersonneMorale
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de PartenairePersonneMorale
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de PartenairePersonneMorale
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de PartenairePersonneMorale
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
        private static T_PartenairePersonneMoraleTableAdapter adapPartenairePersonneMorale = new T_PartenairePersonneMoraleTableAdapter();
        private static ParametreDataSet1.T_PartenairePersonneMoraleDataTable dtPartenairePersonneMorale = new ParametreDataSet1.T_PartenairePersonneMoraleDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de PartenairePersonneMorale
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPartenairePersonneMorale.PS_PartenairePersonneMorale_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de PartenairePersonneMorale
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPartenairePersonneMorale.PS_PartenairePersonneMorale_IP(
                idPersonne,
                libelleSecteurActivite,
                codeFormeJuridique,
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
                NumeroAgrementPersonneMorale,
                capitalSocial,
                SiglePersonneMorale,
                RaisonSociale, logo, aRistourneFinPeriode, idPersonnePrincipal, conditionPartenaire, montantImpaye,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de PartenairePersonneMorale
        /// </summary>
        /// <param name="idPersonne"></param>
        /// <param name="CodePays"></param>
        /// <param name="CodeLangue">Langue de l'utilisateur de PartenairePersonneMorale</param>
        /// <param name="estActif"></param>
        /// <param name="LibelleTypePersonne"></param>
        /// <param name="EstActifPersonne"></param>
        /// <param name="telephoneMobile1"></param>
        /// <param name="telephoneMobile2"></param>
        /// <param name="email"></param>
        /// <param name="adresseComplete"></param>
        /// <param name="tauxRistourne"></param>
        /// <param name="typePartenaire"></param>
        /// <param name="NumeroAgrementPersonneMorale"></param>
        /// <param name="capitalSocial"></param>
        /// <param name="SiglePersonneMorale"></param>
        /// <param name="RaisonSociale"></param>
        /// <param name="numLigne">Le Numéro de Ligne de PartenairePersonneMorale</param>
        /// <param name="dateCreationServeur">La date de création de PartenairePersonneMorale</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de PartenairePersonneMorale</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de PartenairePersonneMorale</param>
        /// <param name="userLogin">Le User Login de PartenairePersonneMorale</param>
        /// <param name="supprimer">Supprimer de PartenairePersonneMorale</param>
        /// <param name="rowvers">Version de ligne de PartenairePersonneMorale</param>
        /// <returns>Liste PartenairePersonneMorale</returns>
        public static List<PartenairePersonneMorale> Liste(
             Decimal? mIdPersonne,
            string mLibelleSecteurActivite,
             string mCodeFormeJuridique,
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
             string mNumeroAgrementPersonneMorale,
             Decimal? mCapitalSocial,
             string mSiglePersonneMorale,
             string mRaisonSociale,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtPartenairePersonneMorale = adapPartenairePersonneMorale.PS_PartenairePersonneMorale_SP(
                mIdPersonne,
                mLibelleSecteurActivite,
                mCodeFormeJuridique,
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
                mNumeroAgrementPersonneMorale,
                mCapitalSocial,
                mSiglePersonneMorale,
                mRaisonSociale,
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
        /// Retourne la liste des PartenairePersonneMorale
        /// </summary>
        /// <returns>Liste PartenairePersonneMorale</returns>
        private static List<PartenairePersonneMorale> pListe()
        {
            List<PartenairePersonneMorale> mListe = new List<PartenairePersonneMorale>();
            foreach (ParametreDataSet1.T_PartenairePersonneMoraleRow mLigne in dtPartenairePersonneMorale)
            {
                PartenairePersonneMorale oPartenairePersonneMorale = new PartenairePersonneMorale();
                oPartenairePersonneMorale.IdPersonne = mLigne.idPersonne;
                oPartenairePersonneMorale.CodePays = mLigne.CodePays.Trim();
                oPartenairePersonneMorale.CodeLangue = mLigne.CodeLangue.Trim();
                oPartenairePersonneMorale.EstActif = mLigne.estActif;
                oPartenairePersonneMorale.LibelleTypePersonne = mLigne.LibelleTypePersonne.Trim();
                oPartenairePersonneMorale.EstActifPersonne = mLigne.EstActifPersonne;
                oPartenairePersonneMorale.TelephoneMobile1 = mLigne.telephoneMobile1.Trim();
                oPartenairePersonneMorale.TelephoneMobile2 = mLigne.telephoneMobile2.Trim();
                oPartenairePersonneMorale.Email = mLigne.email.Trim();
                oPartenairePersonneMorale.AdresseComplete = mLigne.adresseComplete.Trim();
                oPartenairePersonneMorale.TauxRistourne = mLigne.tauxRistourne;
                oPartenairePersonneMorale.EstTauxVariable = mLigne.estTauxVariable;
                oPartenairePersonneMorale.TypePartenaire = mLigne.typePartenaire.Trim();
                oPartenairePersonneMorale.LibelleSecteurActivite = mLigne.libelleSecteurActivite.Trim();
                oPartenairePersonneMorale.CodeFormeJuridique = mLigne.codeFormeJuridique.Trim();
                oPartenairePersonneMorale.NumeroAgrementPersonneMorale = mLigne.NumeroAgrementPersonneMorale.Trim();
                oPartenairePersonneMorale.CapitalSocial = mLigne.CapitalSocial;
                oPartenairePersonneMorale.SiglePersonneMorale = mLigne.SiglePersonneMorale.Trim();
                oPartenairePersonneMorale.RaisonSociale = mLigne.RaisonSociale.Trim();
                oPartenairePersonneMorale.NumLigne = mLigne.numLigne;
                oPartenairePersonneMorale.DateCreationServeur = mLigne.dateCreationServeur;
                oPartenairePersonneMorale.DateDernModifClient = mLigne.dateDernModifClient;
                oPartenairePersonneMorale.DateDernModifServeur = mLigne.dateDernModifServeur;
                oPartenairePersonneMorale.UserLogin = mLigne.userLogin.Trim();
                oPartenairePersonneMorale.Supprimer = mLigne.supprimer;
                oPartenairePersonneMorale.Rowvers = mLigne.rowvers;
                oPartenairePersonneMorale.Logo = mLigne.logo;
                oPartenairePersonneMorale.ARistourneFinPeriode = mLigne.aRistourneFinPeriode;
                oPartenairePersonneMorale.IdPersonnePrincipal = mLigne.idPersonnePrincipal;
                oPartenairePersonneMorale.Intitule = mLigne.intitule;
                oPartenairePersonneMorale.ConditionPartenaire = mLigne.conditionPartenaire;
                oPartenairePersonneMorale.MontantImpaye = mLigne.montantImpaye;
                mListe.Add(oPartenairePersonneMorale);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de PartenairePersonneMorale
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPartenairePersonneMorale.PS_PartenairePersonneMorale_UP(
                idPersonne,
                libelleSecteurActivite,
                codeFormeJuridique,
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
                NumeroAgrementPersonneMorale,
                capitalSocial,
                SiglePersonneMorale,
                RaisonSociale, logo, aRistourneFinPeriode, idPersonnePrincipal, conditionPartenaire, montantImpaye,
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

