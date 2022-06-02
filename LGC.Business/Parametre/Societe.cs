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
    public class Societe
    {
        #region Constructeurs
        public Societe()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires 
        #region Propres
        private Decimal idSociete;
        private string numAgrement;
        private decimal? tva;
        private decimal? aib;

        private DateTime dateAgrement;
        private DateTime dateCreation;
        private Decimal capital;
        private string sigle;
        private string ville;
        private string adresseComplete;
        private string raisonSocial;
        private string telephoneFixe1;
        private string telephoneFixe2;
        private string telephoneMobile1;
        private string telephoneMobile2;
        private string codeSkype;
        private string siteweb;
        private string fax;
        private string email;
        private string boitePostale;
        private string logo;
        private string directeur;

        private string ifu;
        private string devise;
        private string compteBancaire;


      
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

        public decimal? Aib
        {
            get { return aib; }
            set { aib = value; }
        }
        public decimal? Tva
        {
            get { return tva; }
            set { tva = value; }
        }
        public string Ifu
        {
            get { return ifu; }
            set { ifu = value; }
        }


        public string Devise
        {
            get { return devise; }
            set { devise = value; }
        }


        public string CompteBancaire
        {
            get { return compteBancaire; }
            set { compteBancaire = value; }
        }
      

        public string Directeur
        {
            get { return directeur; }
            set { directeur = value; }

        }
        /// <summary>
        /// 
        /// </summary>
        public Decimal IdSociete
        {
            get { return idSociete; }
            set { idSociete = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NumAgrement
        {
            get { return numAgrement.Trim(); }
            set { numAgrement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateAgrement
        {
            get { return dateAgrement; }
            set { dateAgrement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateCreation
        {
            get { return dateCreation; }
            set { dateCreation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Capital
        {
            get { return capital; }
            set { capital = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Sigle
        {
            get { return sigle.Trim(); }
            set { sigle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Ville
        {
            get { return ville.Trim(); }
            set { ville = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string AdresseComplete
        {
            get { return adresseComplete.Trim(); }
            set { adresseComplete = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string RaisonSocial
        {
            get { return raisonSocial.Trim(); }
            set { raisonSocial = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TelephoneFixe1
        {
            get { return telephoneFixe1.Trim(); }
            set { telephoneFixe1 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TelephoneFixe2
        {
            get { return telephoneFixe2.Trim(); }
            set { telephoneFixe2 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TelephoneMobile1
        {
            get { return telephoneMobile1.Trim(); }
            set { telephoneMobile1 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TelephoneMobile2
        {
            get { return telephoneMobile2.Trim(); }
            set { telephoneMobile2 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodeSkype
        {
            get { return codeSkype.Trim(); }
            set { codeSkype = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Siteweb
        {
            get { return siteweb.Trim(); }
            set { siteweb = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            get { return fax.Trim(); }
            set { fax = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get { return email.Trim(); }
            set { email = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string BoitePostale
        {
            get { return boitePostale.Trim(); }
            set { boitePostale = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Logo
        {
            get { return logo.Trim(); }
            set { logo = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Societe
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Societe
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Societe
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Societe
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Societe
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Societe
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Societe
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
        private static T_SocieteTableAdapter adapSociete = new T_SocieteTableAdapter();
        private static ParametreDataSet1.T_SocieteDataTable dtSociete = new ParametreDataSet1.T_SocieteDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Societe
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapSociete.PS_Societe_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Societe
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapSociete.PS_Societe_IP(
                idSociete,
                tva,
                aib,
                numAgrement,
                dateAgrement,
                dateCreation,
                capital,
                sigle,
                ville,
                adresseComplete,
                raisonSocial,
                telephoneFixe1,
                telephoneFixe2,
                telephoneMobile1,
                telephoneMobile2,
                codeSkype,
                siteweb,
                fax,
                email,
                boitePostale,
                Logo,directeur,ifu,devise,compteBancaire,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Societe
        /// </summary>
        /// <param name="idSociete"></param>
        /// <param name="numAgrement"></param>
        /// <param name="dateAgrement"></param>
        /// <param name="dateCreation"></param>
        /// <param name="capital"></param>
        /// <param name="sigle"></param>
        /// <param name="ville"></param>
        /// <param name="adresseComplete"></param>
        /// <param name="raisonSocial"></param>
        /// <param name="telephoneFixe1"></param>
        /// <param name="telephoneFixe2"></param>
        /// <param name="telephoneMobile1"></param>
        /// <param name="telephoneMobile2"></param>
        /// <param name="codeSkype"></param>
        /// <param name="siteweb"></param>
        /// <param name="fax"></param>
        /// <param name="email"></param>
        /// <param name="boitePostale"></param>
        /// <param name="Logo"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Societe</param>
        /// <param name="dateCreationServeur">La date de création de Societe</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Societe</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Societe</param>
        /// <param name="userLogin">Le User Login de Societe</param>
        /// <param name="supprimer">Supprimer de Societe</param>
        /// <param name="rowvers">Version de ligne de Societe</param>
        /// <returns>Liste Societe</returns>
        public static List<Societe> Liste(
             Decimal? mIdSociete,
             string mNumAgrement,
            decimal? mTva,
            decimal? mAib,
             DateTime? mDateAgrement,
             DateTime? mDateCreation,
             Decimal? mCapital,
             string mSigle,
             string mVille,
             string mAdresseComplete,
             string mRaisonSocial,
             string mTelephoneFixe1,
             string mTelephoneFixe2,
             string mTelephoneMobile1,
             string mTelephoneMobile2,
             string mCodeSkype,
             string mSiteweb,
             string mFax,
             string mEmail,
             string mBoitePostale,
             string mLogo,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtSociete = adapSociete.PS_Societe_SP(
                mIdSociete,
                mNumAgrement,
                mTva,
                mAib,
                mDateAgrement,
                mDateCreation,
                mCapital,
                mSigle,
                mVille,
                mAdresseComplete,
                mRaisonSocial,
                mTelephoneFixe1,
                mTelephoneFixe2,
                mTelephoneMobile1,
                mTelephoneMobile2,
                mCodeSkype,
                mSiteweb,
                mFax,
                mEmail,
                mBoitePostale,
                mLogo,
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
        /// Retourne la liste des Societe
        /// </summary>
        /// <returns>Liste Societe</returns>
        private static List<Societe> pListe()
        {
            List<Societe> mListe = new List<Societe>();
            foreach (ParametreDataSet1.T_SocieteRow mLigne in dtSociete)
            {
                Societe oSociete = new Societe();
                oSociete.IdSociete = mLigne.idSociete;
                oSociete.NumAgrement = mLigne.numAgrement.Trim();
                oSociete.DateAgrement = mLigne.dateAgrement;
                oSociete.DateCreation = mLigne.dateCreation;
                oSociete.Capital = mLigne.capital;
                oSociete.Sigle = mLigne.sigle.Trim();
                oSociete.Ville = mLigne.ville.Trim();
                oSociete.AdresseComplete = mLigne.adresseComplete.Trim();
                oSociete.RaisonSocial = mLigne.raisonSocial.Trim();
                oSociete.TelephoneFixe1 = mLigne.telephoneFixe1.Trim();
                oSociete.TelephoneFixe2 = mLigne.telephoneFixe2.Trim();
                oSociete.TelephoneMobile1 = mLigne.telephoneMobile1.Trim();
                oSociete.TelephoneMobile2 = mLigne.telephoneMobile2.Trim();
                oSociete.CodeSkype = mLigne.codeSkype.Trim();
                oSociete.Siteweb = mLigne.siteweb.Trim();
                oSociete.Fax = mLigne.fax.Trim();
                oSociete.Email = mLigne.email.Trim();
                oSociete.BoitePostale = mLigne.boitePostale.Trim();
                oSociete.Logo = mLigne.Logo.Trim();
                oSociete.Tva = mLigne.tva;
                oSociete.Aib = mLigne.aib;
                oSociete.NumLigne = mLigne.numLigne;
                oSociete.DateCreationServeur = mLigne.dateCreationServeur;
                oSociete.DateDernModifClient = mLigne.dateDernModifClient;
                oSociete.DateDernModifServeur = mLigne.dateDernModifServeur;
                oSociete.UserLogin = mLigne.userLogin.Trim();
                oSociete.Supprimer = mLigne.supprimer;
                oSociete.Rowvers = mLigne.rowvers;
                oSociete.Directeur = mLigne.directeur;
                oSociete.Ifu = mLigne.ifu;
                oSociete.Devise = mLigne.devise;
                oSociete.CompteBancaire = mLigne.compteBancaire;
                mListe.Add(oSociete);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Societe
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapSociete.PS_Societe_UP(
                idSociete,
                numAgrement,
                tva,
                aib,
                dateAgrement,
                dateCreation,
                capital,
                sigle,
                ville,
                adresseComplete,
                raisonSocial,
                telephoneFixe1,
                telephoneFixe2,
                telephoneMobile1,
                telephoneMobile2,
                codeSkype,
                siteweb,
                fax,
                email,
                boitePostale,
                Logo,directeur,ifu,devise,compteBancaire,
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

