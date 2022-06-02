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
    public class Assurance : Personne
    {
        #region Constructeurs
        public Assurance()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idPersonne;
        private string libelleSecteurActivite;
        private string codeFormeJuridique;
        private string numeroAgrementPersonneMorale;
        private string siglePersonneMorale;
        private string raisonSociale;
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
            get { return numeroAgrementPersonneMorale; }
            set { numeroAgrementPersonneMorale = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SiglePersonneMorale
        {
            get { return siglePersonneMorale; }
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

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Assurance
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Assurance
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Assurance
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Assurance
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Assurance
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Assurance
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Assurance
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
        private static T_AssuranceTableAdapter adapAssurance = new T_AssuranceTableAdapter();
        private static ParametreDataSet1.T_AssuranceDataTable dtAssurance = new ParametreDataSet1.T_AssuranceDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Assurance
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAssurance.PS_Assurance_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Assurance
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAssurance.PS_Assurance_IP(
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
                NumeroAgrementPersonneMorale,
                SiglePersonneMorale,
                RaisonSociale,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Assurance
        /// </summary>
        /// <param name="idPersonne"></param>
        /// <param name="CodePays"></param>
        /// <param name="CodeLangue">Langue de l'utilisateur de Assurance</param>
        /// <param name="estActif"></param>
        /// <param name="LibelleTypePersonne"></param>
        /// <param name="EstActifPersonne"></param>
        /// <param name="telephoneMobile1"></param>
        /// <param name="telephoneMobile2"></param>
        /// <param name="email"></param>
        /// <param name="adresseComplete"></param>
        /// <param name="NumeroAgrementPersonneMorale"></param>
        /// <param name="SiglePersonneMorale"></param>
        /// <param name="RaisonSociale"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Assurance</param>
        /// <param name="dateCreationServeur">La date de création de Assurance</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Assurance</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Assurance</param>
        /// <param name="userLogin">Le User Login de Assurance</param>
        /// <param name="supprimer">Supprimer de Assurance</param>
        /// <param name="rowvers">Version de ligne de Assurance</param>
        /// <returns>Liste Assurance</returns>
        public static List<Assurance> Liste(
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
             string mNumeroAgrementPersonneMorale,
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
            dtAssurance = adapAssurance.PS_Assurance_SP(
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
                mNumeroAgrementPersonneMorale,
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
        /// Retourne la liste des Assurance
        /// </summary>
        /// <returns>Liste Assurance</returns>
        private static List<Assurance> pListe()
        {
            List<Assurance> mListe = new List<Assurance>();
            foreach (ParametreDataSet1.T_AssuranceRow mLigne in dtAssurance)
            {
                Assurance oAssurance = new Assurance();
                oAssurance.IdPersonne = mLigne.idPersonne;
                oAssurance.CodePays = mLigne.CodePays.Trim();
                oAssurance.CodeLangue = mLigne.CodeLangue.Trim();
                oAssurance.EstActif = mLigne.estActif;
                oAssurance.LibelleTypePersonne = mLigne.LibelleTypePersonne.Trim();
                oAssurance.EstActifPersonne = mLigne.EstActifPersonne;
                oAssurance.TelephoneMobile1 = mLigne.telephoneMobile1.Trim();
                oAssurance.TelephoneMobile2 = mLigne.telephoneMobile2.Trim();
                oAssurance.Email = mLigne.email.Trim();
                oAssurance.AdresseComplete = mLigne.adresseComplete.Trim();
                oAssurance.LibelleSecteurActivite = mLigne.libelleSecteurActivite.Trim();
                oAssurance.CodeFormeJuridique = mLigne.codeFormeJuridique.Trim();
                oAssurance.NumeroAgrementPersonneMorale = mLigne.NumeroAgrementPersonneMorale.Trim();
                oAssurance.SiglePersonneMorale = mLigne.SiglePersonneMorale.Trim();
                oAssurance.RaisonSociale = mLigne.RaisonSociale.Trim();
                oAssurance.NumLigne = mLigne.numLigne;
                oAssurance.DateCreationServeur = mLigne.dateCreationServeur;
                oAssurance.DateDernModifClient = mLigne.dateDernModifClient;
                oAssurance.DateDernModifServeur = mLigne.dateDernModifServeur;
                oAssurance.UserLogin = mLigne.userLogin.Trim();
                oAssurance.Supprimer = mLigne.supprimer;
                oAssurance.Rowvers = mLigne.rowvers;

                mListe.Add(oAssurance);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Assurance
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAssurance.PS_Assurance_UP(
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
                NumeroAgrementPersonneMorale,
                SiglePersonneMorale,
                RaisonSociale,
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

