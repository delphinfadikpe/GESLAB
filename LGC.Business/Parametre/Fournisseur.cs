using LGC.Business;
using LGC.Business.Parametre;
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
    public class Fournisseur : Personne
    {
        #region Constructeurs
        public Fournisseur()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idPersonne;
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
        public string NumeroAgrementPersonneMorale
        {
            get { return numeroAgrementPersonneMorale.Trim(); }
            set { numeroAgrementPersonneMorale = value; }
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

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Fournisseur
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Fournisseur
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Fournisseur
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Fournisseur
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Fournisseur
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Fournisseur
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Fournisseur
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
        private static T_FournisseurTableAdapter adapFournisseur = new T_FournisseurTableAdapter();
        private static ParametreDataSet1.T_FournisseurDataTable dtFournisseur = new ParametreDataSet1.T_FournisseurDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Fournisseur
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFournisseur.PS_Fournisseur_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Fournisseur
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFournisseur.PS_Fournisseur_IP(
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
        /// Retourne la liste de Fournisseur
        /// </summary>
        /// <param name="idPersonne"></param>
        /// <param name="CodePays"></param>
        /// <param name="CodeLangue">Langue de l'utilisateur de Fournisseur</param>
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
        /// <param name="numLigne">Le Numéro de Ligne de Fournisseur</param>
        /// <param name="dateCreationServeur">La date de création de Fournisseur</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Fournisseur</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Fournisseur</param>
        /// <param name="userLogin">Le User Login de Fournisseur</param>
        /// <param name="supprimer">Supprimer de Fournisseur</param>
        /// <param name="rowvers">Version de ligne de Fournisseur</param>
        /// <returns>Liste Fournisseur</returns>
        public static List<Fournisseur> Liste(
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
            dtFournisseur = adapFournisseur.PS_Fournisseur_SP(
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
        /// Retourne la liste des Fournisseur
        /// </summary>
        /// <returns>Liste Fournisseur</returns>
        private static List<Fournisseur> pListe()
        {
            List<Fournisseur> mListe = new List<Fournisseur>();
            foreach (ParametreDataSet1.T_FournisseurRow mLigne in dtFournisseur)
            {
                Fournisseur oFournisseur = new Fournisseur();
                oFournisseur.IdPersonne = mLigne.idPersonne;
                oFournisseur.CodePays = mLigne.CodePays.Trim();
                oFournisseur.CodeLangue = mLigne.CodeLangue.Trim();
                oFournisseur.EstActif = mLigne.estActif;
                oFournisseur.LibelleTypePersonne = mLigne.LibelleTypePersonne.Trim();
                oFournisseur.EstActifPersonne = mLigne.EstActifPersonne;
                oFournisseur.TelephoneMobile1 = mLigne.telephoneMobile1.Trim();
                oFournisseur.TelephoneMobile2 = mLigne.telephoneMobile2.Trim();
                oFournisseur.Email = mLigne.email.Trim();
                oFournisseur.AdresseComplete = mLigne.adresseComplete.Trim();
                oFournisseur.NumeroAgrementPersonneMorale = mLigne.NumeroAgrementPersonneMorale.Trim();
                oFournisseur.SiglePersonneMorale = mLigne.SiglePersonneMorale.Trim();
                oFournisseur.RaisonSociale = mLigne.RaisonSociale.Trim();
                oFournisseur.NumLigne = mLigne.numLigne;
                oFournisseur.DateCreationServeur = mLigne.dateCreationServeur;
                oFournisseur.DateDernModifClient = mLigne.dateDernModifClient;
                oFournisseur.DateDernModifServeur = mLigne.dateDernModifServeur;
                oFournisseur.UserLogin = mLigne.userLogin.Trim();
                oFournisseur.Supprimer = mLigne.supprimer;
                oFournisseur.Rowvers = mLigne.rowvers;

                mListe.Add(oFournisseur);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Fournisseur
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapFournisseur.PS_Fournisseur_UP(
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

