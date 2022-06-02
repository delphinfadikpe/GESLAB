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
    public class Patient : Personne
    {
        #region Constructeurs
        public Patient()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal idPersonne;
        private string civilte;
        private string sexe;
        private string nomPersonnePhysique;
        private string prenomPersonnePhysique;
        private DateTime dateNaissance;
        private string lieuNaissance;
        private string photoPersonnePhysique;
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
        public string Civilte
        {
            get { return civilte.Trim(); }
            set { civilte = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Sexe
        {
            get { return sexe.Trim(); }
            set { sexe = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NomPersonnePhysique
        {
            get { return nomPersonnePhysique.Trim(); }
            set { nomPersonnePhysique = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PrenomPersonnePhysique
        {
            get { return prenomPersonnePhysique.Trim(); }
            set { prenomPersonnePhysique = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateNaissance
        {
            get { return dateNaissance; }
            set { dateNaissance = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LieuNaissance
        {
            get { return lieuNaissance.Trim(); }
            set { lieuNaissance = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PhotoPersonnePhysique
        {
            get { return photoPersonnePhysique.Trim(); }
            set { photoPersonnePhysique = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Patient
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Patient
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Patient
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Patient
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Patient
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Patient
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Patient
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
        private static T_PatientTableAdapter adapPatient = new T_PatientTableAdapter();
        private static ParametreDataSet1.T_PatientDataTable dtPatient = new ParametreDataSet1.T_PatientDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Patient
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPatient.PS_Patient_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Patient
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPatient.PS_Patient_IP(
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
                Civilte,
                Sexe,
                NomPersonnePhysique,
                PrenomPersonnePhysique,
                DateNaissance,
                LieuNaissance,
                PhotoPersonnePhysique,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Patient
        /// </summary>
        /// <param name="idPersonne"></param>
        /// <param name="CodePays"></param>
        /// <param name="CodeLangue">Langue de l'utilisateur de Patient</param>
        /// <param name="estActif"></param>
        /// <param name="LibelleTypePersonne"></param>
        /// <param name="EstActifPersonne"></param>
        /// <param name="telephoneMobile1"></param>
        /// <param name="telephoneMobile2"></param>
        /// <param name="email"></param>
        /// <param name="adresseComplete"></param>
        /// <param name="Civilte"></param>
        /// <param name="Sexe"></param>
        /// <param name="NomPersonnePhysique"></param>
        /// <param name="PrenomPersonnePhysique"></param>
        /// <param name="DateNaissance"></param>
        /// <param name="LieuNaissance"></param>
        /// <param name="PhotoPersonnePhysique"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Patient</param>
        /// <param name="dateCreationServeur">La date de création de Patient</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Patient</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Patient</param>
        /// <param name="userLogin">Le User Login de Patient</param>
        /// <param name="supprimer">Supprimer de Patient</param>
        /// <param name="rowvers">Version de ligne de Patient</param>
        /// <returns>Liste Patient</returns>
        public static List<Patient> Liste(
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
             string mCivilte,
             string mSexe,
             string mNomPersonnePhysique,
             string mPrenomPersonnePhysique,
             DateTime? mDateNaissance,
             string mLieuNaissance,
             string mPhotoPersonnePhysique,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtPatient = adapPatient.PS_Patient_SP(
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
                mCivilte,
                mSexe,
                mNomPersonnePhysique,
                mPrenomPersonnePhysique,
                mDateNaissance,
                mLieuNaissance,
                mPhotoPersonnePhysique,
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
        /// Retourne la liste des Patient
        /// </summary>
        /// <returns>Liste Patient</returns>
        private static List<Patient> pListe()
        {
            List<Patient> mListe = new List<Patient>();
            foreach (ParametreDataSet1.T_PatientRow mLigne in dtPatient)
            {
                Patient oPatient = new Patient();
                oPatient.IdPersonne = mLigne.idPersonne;
                oPatient.CodePays = mLigne.CodePays.Trim();
                oPatient.CodeLangue = mLigne.CodeLangue.Trim();
                oPatient.EstActif = mLigne.estActif;
                oPatient.LibelleTypePersonne = mLigne.LibelleTypePersonne.Trim();
                oPatient.EstActifPersonne = mLigne.EstActifPersonne;
                oPatient.TelephoneMobile1 = mLigne.telephoneMobile1.Trim();
                oPatient.TelephoneMobile2 = mLigne.telephoneMobile2.Trim();
                oPatient.Email = mLigne.email.Trim();
                oPatient.AdresseComplete = mLigne.adresseComplete.Trim();
                oPatient.Civilte = mLigne.Civilte.Trim();
                oPatient.Sexe = mLigne.Sexe.Trim();
                oPatient.NomPersonnePhysique = mLigne.NomPersonnePhysique.Trim();
                oPatient.PrenomPersonnePhysique = mLigne.PrenomPersonnePhysique.Trim();
                oPatient.DateNaissance = mLigne.DateNaissance;
                oPatient.LieuNaissance = mLigne.LieuNaissance.Trim();
                oPatient.PhotoPersonnePhysique = mLigne.PhotoPersonnePhysique.Trim();
                oPatient.NumLigne = mLigne.numLigne;
                oPatient.DateCreationServeur = mLigne.dateCreationServeur;
                oPatient.DateDernModifClient = mLigne.dateDernModifClient;
                oPatient.DateDernModifServeur = mLigne.dateDernModifServeur;
                oPatient.UserLogin = mLigne.userLogin.Trim();
                oPatient.Supprimer = mLigne.supprimer;
                oPatient.Rowvers = mLigne.rowvers;

                mListe.Add(oPatient);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Patient
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPatient.PS_Patient_UP(
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
                Civilte,
                Sexe,
                NomPersonnePhysique,
                PrenomPersonnePhysique,
                DateNaissance,
                LieuNaissance,
                PhotoPersonnePhysique,
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

