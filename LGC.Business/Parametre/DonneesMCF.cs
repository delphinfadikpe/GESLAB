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
    public class DonneesMCF
    {
        #region Constructeurs
        public DonneesMCF()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string idFacture;
        private Decimal fc;
        private Decimal tc;
        private string ft;
        private string sig;
        private string compteur;
        private string dateEtHeure;
        private string codeQR;
        private string nim;
        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private DateTime dateCreationServeur;
        private DateTime dateDernModifServeur;
        private DateTime dateDernModifClient;
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
        public string IdFacture
        {
            get { return idFacture; }
            set { idFacture = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Fc
        {
            get { return fc; }
            set { fc = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Tc
        {
            get { return tc; }
            set { tc = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Ft
        {
            get { return ft; }
            set { ft = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Sig
        {
            get { return sig; }
            set { sig = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Compteur
        {
            get { return compteur; }
            set { compteur = value; }
        }

        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private string ifu;

        public string IFU
        {
            get { return ifu; }
            set { ifu = value; }
        }

        private string rccm;

        public string RCCM
        {
            get { return rccm; }
            set { rccm = value; }
        }

        private string adresse;

        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        private string telephone;

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        private string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        private string ville;

        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string DateEtHeure
        {
            get { return dateEtHeure; }
            set { dateEtHeure = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodeQR
        {
            get { return codeQR; }
            set { codeQR = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Nim
        {
            get { return nim; }
            set { nim = value; }
        }

        private Byte[] codeQRImage;

        public Byte[] CodeQRImage
        {
            get { return codeQRImage; }
            set { codeQRImage = value; }
        }

        private string reference;

        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }
        
        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de DonneesMCF
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de DonneesMCF
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de DonneesMCF
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de DonneesMCF
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// Le User Login de DonneesMCF
        /// </summary>
        public string UserLogin
        {
            get { return userLogin; }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de DonneesMCF
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de DonneesMCF
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
        private static T_DonneesMCFTableAdapter adapDonneesMCF = new T_DonneesMCFTableAdapter();
        private static ParametreDataSet1.T_DonneesMCFDataTable dtDonneesMCF = new ParametreDataSet1.T_DonneesMCFDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet l'enregistrement de DonneesMCF
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapDonneesMCF.PS_DonneesMCF_IP(
                idFacture.Trim(),
                fc,
                tc,
                ft,
                sig,
                compteur,
                dateEtHeure,
                codeQR,
                nim,
                codeQRImage,
                nom,
                ifu,
                mail,
                telephone,
                rccm,
                adresse,
                ville,
                reference,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de DonneesMCF
        /// </summary>
        /// <param name="idFacture"></param>
        /// <param name="fc"></param>
        /// <param name="tc"></param>
        /// <param name="ft"></param>
        /// <param name="sig"></param>
        /// <param name="compteur"></param>
        /// <param name="dateEtHeure"></param>
        /// <param name="codeQR"></param>
        /// <param name="nim"></param>
        /// <param name="codeQRImage"></param>
        /// <param name="ville"></param>
        /// <param name="numLigne">Le Numéro de Ligne de DonneesMCF</param>
        /// <param name="dateCreationServeur">La date de création de DonneesMCF</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de DonneesMCF</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de DonneesMCF</param>
        /// <param name="userLogin">Le User Login de DonneesMCF</param>
        /// <param name="supprimer">Supprimer de DonneesMCF</param>
        /// <param name="rowvers">Version de ligne de DonneesMCF</param>
        /// <returns>Liste DonneesMCF</returns>
        public static List<DonneesMCF> Liste(
             string mIdFacture,
             Decimal? mFc,
             Decimal? mTc,
             string mFt,
             string mSig,
             string mCompteur,
             string mDateEtHeure,
             string mCodeQR,
             string mNim,
             Byte[] mCodeQRImage,
             string mNom,
             string mIfu,
             string mAdresse,
             string mMail,
             string mTelephone,
             string mRccm,
             string mVille,
             string mReference,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifServeur,
             DateTime? mDateDernModifClient,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtDonneesMCF = adapDonneesMCF.PS_DonneesMCF_SP(
                mIdFacture.Trim(),
                mFc,
                mTc,
                mFt,
                mSig,
                mCompteur,
                mDateEtHeure,
                mCodeQR,
                mNim,
                mCodeQRImage,
                mNom,
                mIfu,
                mMail,
                mTelephone,
                mRccm,
                mAdresse,
                mVille,
                mReference,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifServeur,
                mDateDernModifClient,
                mUserLogin,
                mSupprimer,
                mRowvers);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des DonneesMCF
        /// </summary>
        /// <returns>Liste DonneesMCF</returns>
        private static List<DonneesMCF> pListe()
        {
            List<DonneesMCF> mListe = new List<DonneesMCF>();
            foreach (ParametreDataSet1.T_DonneesMCFRow mLigne in dtDonneesMCF)
            {
                DonneesMCF oDonneesMCF = new DonneesMCF();
                oDonneesMCF.IdFacture = mLigne.numFacture;
                oDonneesMCF.Fc = mLigne.fc;
                oDonneesMCF.Tc = mLigne.tc;
                oDonneesMCF.Ft = mLigne.ft;
                oDonneesMCF.Sig = mLigne.sig;
                oDonneesMCF.Compteur = mLigne.compteur;
                oDonneesMCF.DateEtHeure = mLigne.dateEtHeure;
                oDonneesMCF.CodeQR = mLigne.codeQR;
                oDonneesMCF.Nim = mLigne.nim;
                oDonneesMCF.CodeQRImage = mLigne.codeQRImage;
                oDonneesMCF.Nom = mLigne.nom;
                oDonneesMCF.IFU = mLigne.ifu;
                oDonneesMCF.Mail = mLigne.mail;
                oDonneesMCF.Adresse = mLigne.adresse;
                oDonneesMCF.Telephone = mLigne.telephone;
                oDonneesMCF.RCCM = mLigne.rccm;
                oDonneesMCF.Ville = mLigne.ville;
                oDonneesMCF.Reference = mLigne.reference;
                oDonneesMCF.NumLigne = mLigne.numLigne;
                oDonneesMCF.DateCreationServeur = mLigne.dateCreationServeur;
                oDonneesMCF.DateDernModifServeur = mLigne.dateDernModifServeur;
                oDonneesMCF.DateDernModifClient = mLigne.dateDernModifClient;
                oDonneesMCF.UserLogin = mLigne.userLogin;
                oDonneesMCF.Supprimer = mLigne.supprimer;
                oDonneesMCF.Rowvers = mLigne.rowvers;

                mListe.Add(oDonneesMCF);
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
