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
    public class Personne
    {
        #region Constructeurs
        public Personne()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idPersonne;
        public string codePays;
        public string codeLangue;
        public bool estActif;
        public string libelleTypePersonne;
        public bool estActifPersonne;
        public string telephoneMobile1;
        public string telephoneMobile2;
        public string email;
        public string adresseComplete;
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
        public string CodePays
        {
            get { return codePays.Trim(); }
            set { codePays = value; }
        }

        /// <summary>
        /// Langue de l'utilisateur de Personne
        /// </summary>
        public string CodeLangue
        {
            get { return codeLangue.Trim(); }
            set { codeLangue = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstActif
        {
            get { return estActif; }
            set { estActif = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibelleTypePersonne
        {
            get { return libelleTypePersonne.Trim(); }
            set { libelleTypePersonne = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstActifPersonne
        {
            get { return estActifPersonne; }
            set { estActifPersonne = value; }
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
        public string Email
        {
            get { return email.Trim(); }
            set { email = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string AdresseComplete
        {
            get { return adresseComplete.Trim(); }
            set { adresseComplete = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Personne
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Personne
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Personne
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Personne
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Personne
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Personne
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Personne
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
        private static T_PersonneTableAdapter adapPersonne = new T_PersonneTableAdapter();
        private static ParametreDataSet1.T_PersonneDataTable dtPersonne = new ParametreDataSet1.T_PersonneDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Personne
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPersonne.PS_Personne_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Personne
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPersonne.PS_Personne_IP(
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
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Personne
        /// </summary>
        /// <param name="idPersonne"></param>
        /// <param name="CodePays"></param>
        /// <param name="CodeLangue">Langue de l'utilisateur de Personne</param>
        /// <param name="estActif"></param>
        /// <param name="LibelleTypePersonne"></param>
        /// <param name="EstActifPersonne"></param>
        /// <param name="telephoneMobile1"></param>
        /// <param name="telephoneMobile2"></param>
        /// <param name="email"></param>
        /// <param name="adresseComplete"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Personne</param>
        /// <param name="dateCreationServeur">La date de création de Personne</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Personne</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Personne</param>
        /// <param name="userLogin">Le User Login de Personne</param>
        /// <param name="supprimer">Supprimer de Personne</param>
        /// <param name="rowvers">Version de ligne de Personne</param>
        /// <returns>Liste Personne</returns>
        public static List<Personne> Liste(
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
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtPersonne = adapPersonne.PS_Personne_SP(
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
        /// Retourne la liste des Personne
        /// </summary>
        /// <returns>Liste Personne</returns>
        private static List<Personne> pListe()
        {
            List<Personne> mListe = new List<Personne>();
            foreach (ParametreDataSet1.T_PersonneRow mLigne in dtPersonne)
            {
                Personne oPersonne = new Personne();
                oPersonne.IdPersonne = mLigne.idPersonne;
                oPersonne.CodePays = mLigne.CodePays.Trim();
                oPersonne.CodeLangue = mLigne.CodeLangue.Trim();
                oPersonne.EstActif = mLigne.estActif;
                oPersonne.LibelleTypePersonne = mLigne.LibelleTypePersonne.Trim();
                oPersonne.EstActifPersonne = mLigne.EstActifPersonne;
                oPersonne.TelephoneMobile1 = mLigne.telephoneMobile1.Trim();
                oPersonne.TelephoneMobile2 = mLigne.telephoneMobile2.Trim();
                oPersonne.Email = mLigne.email.Trim();
                oPersonne.AdresseComplete = mLigne.adresseComplete.Trim();
                oPersonne.NumLigne = mLigne.numLigne;
                oPersonne.DateCreationServeur = mLigne.dateCreationServeur;
                oPersonne.DateDernModifClient = mLigne.dateDernModifClient;
                oPersonne.DateDernModifServeur = mLigne.dateDernModifServeur;
                oPersonne.UserLogin = mLigne.userLogin.Trim();
                oPersonne.Supprimer = mLigne.supprimer;
                oPersonne.Rowvers = mLigne.rowvers;

                mListe.Add(oPersonne);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Personne
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPersonne.PS_Personne_UP(
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

