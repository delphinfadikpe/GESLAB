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
    public class PartenairePersonnePhysique : Partenaires
    {
        #region Constructeurs
        public PartenairePersonnePhysique()
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
        private string numPiece;
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

        /// <summary>
        /// 
        /// </summary>
        public string NumPiece
        {
            get { return numPiece.Trim(); }
            set { numPiece = value; }
        }

        public bool ARistourneFinPeriode
        {
            get { return aRistourneFinPeriode; }
            set { aRistourneFinPeriode = value; }
        }
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
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
        /// Le Numéro de Ligne de PartenairePersonnePhysique
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de PartenairePersonnePhysique
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de PartenairePersonnePhysique
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de PartenairePersonnePhysique
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de PartenairePersonnePhysique
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de PartenairePersonnePhysique
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de PartenairePersonnePhysique
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
        private static T_PartenairePersonnePhysiqueTableAdapter adapPartenairePersonnePhysique = new T_PartenairePersonnePhysiqueTableAdapter();
        private static ParametreDataSet1.T_PartenairePersonnePhysiqueDataTable dtPartenairePersonnePhysique = new ParametreDataSet1.T_PartenairePersonnePhysiqueDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de PartenairePersonnePhysique
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPartenairePersonnePhysique.PS_PartenairePersonnePhysique_DP(
                CodeLangue,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.UserLogin,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de PartenairePersonnePhysique
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPartenairePersonnePhysique.PS_PartenairePersonnePhysique_IP(
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
                Civilte,
                Sexe,
                NomPersonnePhysique,
                PrenomPersonnePhysique,
                DateNaissance,
                LieuNaissance,
                PhotoPersonnePhysique,
                numPiece, logo, aRistourneFinPeriode, idPersonnePrincipal, conditionPartenaire, montantImpaye,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de PartenairePersonnePhysique
        /// </summary>
        /// <param name="idPersonne"></param>
        /// <param name="CodePays"></param>
        /// <param name="CodeLangue">Langue de l'utilisateur de PartenairePersonnePhysique</param>
        /// <param name="estActif"></param>
        /// <param name="LibelleTypePersonne"></param>
        /// <param name="EstActifPersonne"></param>
        /// <param name="telephoneMobile1"></param>
        /// <param name="telephoneMobile2"></param>
        /// <param name="email"></param>
        /// <param name="adresseComplete"></param>
        /// <param name="tauxRistourne"></param>
        /// <param name="typePartenaire"></param>
        /// <param name="Civilte"></param>
        /// <param name="Sexe"></param>
        /// <param name="NomPersonnePhysique"></param>
        /// <param name="PrenomPersonnePhysique"></param>
        /// <param name="DateNaissance"></param>
        /// <param name="LieuNaissance"></param>
        /// <param name="PhotoPersonnePhysique"></param>
        /// <param name="numPiece"></param>
        /// <param name="numLigne">Le Numéro de Ligne de PartenairePersonnePhysique</param>
        /// <param name="dateCreationServeur">La date de création de PartenairePersonnePhysique</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de PartenairePersonnePhysique</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de PartenairePersonnePhysique</param>
        /// <param name="userLogin">Le User Login de PartenairePersonnePhysique</param>
        /// <param name="supprimer">Supprimer de PartenairePersonnePhysique</param>
        /// <param name="rowvers">Version de ligne de PartenairePersonnePhysique</param>
        /// <returns>Liste PartenairePersonnePhysique</returns>
        public static List<PartenairePersonnePhysique> Liste(
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
             string mCivilte,
             string mSexe,
             string mNomPersonnePhysique,
             string mPrenomPersonnePhysique,
             DateTime? mDateNaissance,
             string mLieuNaissance,
             string mPhotoPersonnePhysique,
             string mNumPiece,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtPartenairePersonnePhysique = adapPartenairePersonnePhysique.PS_PartenairePersonnePhysique_SP(
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
                mCivilte,
                mSexe,
                mNomPersonnePhysique,
                mPrenomPersonnePhysique,
                mDateNaissance,
                mLieuNaissance,
                mPhotoPersonnePhysique,
                mNumPiece,
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
        /// Retourne la liste des PartenairePersonnePhysique
        /// </summary>
        /// <returns>Liste PartenairePersonnePhysique</returns>
        private static List<PartenairePersonnePhysique> pListe()
        {
            List<PartenairePersonnePhysique> mListe = new List<PartenairePersonnePhysique>();
            foreach (ParametreDataSet1.T_PartenairePersonnePhysiqueRow mLigne in dtPartenairePersonnePhysique)
            {
                PartenairePersonnePhysique oPartenairePersonnePhysique = new PartenairePersonnePhysique();
                oPartenairePersonnePhysique.IdPersonne = mLigne.idPersonne;
                oPartenairePersonnePhysique.CodePays = mLigne.CodePays.Trim();
                oPartenairePersonnePhysique.CodeLangue = mLigne.CodeLangue.Trim();
                oPartenairePersonnePhysique.EstActif = mLigne.estActif;
                oPartenairePersonnePhysique.LibelleTypePersonne = mLigne.LibelleTypePersonne.Trim();
                oPartenairePersonnePhysique.EstActifPersonne = mLigne.EstActifPersonne;
                oPartenairePersonnePhysique.TelephoneMobile1 = mLigne.telephoneMobile1.Trim();
                oPartenairePersonnePhysique.TelephoneMobile2 = mLigne.telephoneMobile2.Trim();
                oPartenairePersonnePhysique.Email = mLigne.email.Trim();
                oPartenairePersonnePhysique.AdresseComplete = mLigne.adresseComplete.Trim();
                oPartenairePersonnePhysique.TauxRistourne = mLigne.tauxRistourne;
                oPartenairePersonnePhysique.TypePartenaire = mLigne.typePartenaire.Trim();
                oPartenairePersonnePhysique.Civilte = mLigne.Civilte.Trim();
                oPartenairePersonnePhysique.Sexe = mLigne.Sexe.Trim();
                oPartenairePersonnePhysique.NomPersonnePhysique = mLigne.NomPersonnePhysique.Trim();
                oPartenairePersonnePhysique.PrenomPersonnePhysique = mLigne.PrenomPersonnePhysique.Trim();
                oPartenairePersonnePhysique.DateNaissance = mLigne.DateNaissance;
                oPartenairePersonnePhysique.LieuNaissance = mLigne.LieuNaissance.Trim();
                oPartenairePersonnePhysique.EstTauxVariable = mLigne.estTauxVariable;
                oPartenairePersonnePhysique.PhotoPersonnePhysique = mLigne.PhotoPersonnePhysique.Trim();
                oPartenairePersonnePhysique.NumPiece = mLigne.numPiece.Trim();
                oPartenairePersonnePhysique.NumLigne = mLigne.numLigne;
                oPartenairePersonnePhysique.DateCreationServeur = mLigne.dateCreationServeur;
                oPartenairePersonnePhysique.DateDernModifClient = mLigne.dateDernModifClient;
                oPartenairePersonnePhysique.DateDernModifServeur = mLigne.dateDernModifServeur;
                oPartenairePersonnePhysique.UserLogin = mLigne.userLogin.Trim();
                oPartenairePersonnePhysique.Supprimer = mLigne.supprimer;
                oPartenairePersonnePhysique.Rowvers = mLigne.rowvers;
                oPartenairePersonnePhysique.Logo = mLigne.logo;
                oPartenairePersonnePhysique.ARistourneFinPeriode = mLigne.aRistourneFinPeriode;
                oPartenairePersonnePhysique.IdPersonnePrincipal = mLigne.idPersonnePrincipal;
                oPartenairePersonnePhysique.Intitule = mLigne.intitule;
                oPartenairePersonnePhysique.ConditionPartenaire = mLigne.conditionPartenaire;
                oPartenairePersonnePhysique.MontantImpaye = mLigne.montantImpaye;
                mListe.Add(oPartenairePersonnePhysique);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de PartenairePersonnePhysique
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPartenairePersonnePhysique.PS_PartenairePersonnePhysique_UP(
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
                Civilte,
                Sexe,
                NomPersonnePhysique,
                PrenomPersonnePhysique,
                DateNaissance,
                LieuNaissance,
                PhotoPersonnePhysique,
                numPiece, logo, aRistourneFinPeriode, idPersonnePrincipal, conditionPartenaire, montantImpaye,
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

