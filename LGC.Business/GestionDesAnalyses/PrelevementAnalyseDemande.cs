using LGC.DataAccess.GestionDesAnalyses;
using LGC.DataAccess.GestionDesAnalyses.GestionDesAnalysesDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGC.Business.GestionDesAnalyses
{
    /// <summary>
    /// 
    /// </summary>
    public class PrelevementAnalyseDemande
    {
        #region Constructeurs
        public PrelevementAnalyseDemande()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal numDemande;
        private string codeAnalyse;
        private string codePrelevement;
        private Decimal idCodeBarPrelevement;
        private DateTime datePrelevement;
        private DateTime heurePrelevement;
        private Decimal numPrelevement;
        private string libelleAnalyse;
        private string libellePrelevement;
        private string chaineCode;
        private string idCodeBarre;
        private string encoder;
        private bool? showTexte;
        private string codeUniteMesure;
        private string tube;
        private string codeTypeTube;
        private string libelleTypeTube;

        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private DateTime dateCreationServeur;
        private DateTime dateDernModifClient;
        private DateTime dateDernModifServeur;
        private Byte[] rowvers;
        private bool supprimer;
        private string userLogin;
        private Decimal qtePrelevee;
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

        public string LibelleTypeTube
        {
            get { return libelleTypeTube; }
            set { libelleTypeTube = value; }
        }
        public string CodeTypeTube
        {
            get { return codeTypeTube; }
            set { codeTypeTube = value; }
        }
        public string Tube
        {
            get { return tube; }
            set { tube = value; }
        }
        public string CodeUniteMesure
        {
            get { return codeUniteMesure; }
            set { codeUniteMesure = value; }
        } 


        public bool? ShowTexte
        {
            get { return showTexte; }
            set { showTexte = value; }
        }
        public string Encoder
        {
            get { return encoder; }
            set { encoder = value; }
        }
        public string IdCodeBarre
        {
            get { return idCodeBarre; }
            set { idCodeBarre = value; }
        }


        public string ChaineCode
        {
            get { return chaineCode; }
            set { chaineCode = value; }
        }
       
        public string LibelleAnalyse
        {
            get { return libelleAnalyse; }
            set { libelleAnalyse = value; }
        }

        public string LibellePrelevement
        {
            get { return libellePrelevement; }
            set { libellePrelevement = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Decimal NumDemande
        {
            get { return numDemande; }
            set { numDemande = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodeAnalyse
        {
            get { return codeAnalyse.Trim(); }
            set { codeAnalyse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodePrelevement
        {
            get { return codePrelevement.Trim(); }
            set { codePrelevement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal IdCodeBarPrelevement
        {
            get { return idCodeBarPrelevement; }
            set { idCodeBarPrelevement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DatePrelevement
        {
            get { return datePrelevement; }
            set { datePrelevement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime HeurePrelevement
        {
            get { return heurePrelevement; }
            set { heurePrelevement = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal NumPrelevement
        {
            get { return numPrelevement; }
            set { numPrelevement = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de PrelevementAnalyseDemande
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de PrelevementAnalyseDemande
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de PrelevementAnalyseDemande
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de PrelevementAnalyseDemande
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Version de ligne de PrelevementAnalyseDemande
        /// </summary>
        public Byte[] Rowvers
        {
            get { return rowvers; }
            set { rowvers = value; }
        }

        /// <summary>
        /// Supprimer de PrelevementAnalyseDemande
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Le User Login de PrelevementAnalyseDemande
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal QtePrelevee
        {
            get { return qtePrelevee; }
            set { qtePrelevee = value; }
        }

        #endregion Passe partout
        #endregion Elémentaires

        #region Objets

        #endregion Objets

        #region Collections

        #endregion Collections
        #endregion Propriétés

        #region Variables
        private static TJ_PrelevementAnalyseDemandeTableAdapter adapPrelevementAnalyseDemande = new TJ_PrelevementAnalyseDemandeTableAdapter();
        private static GestionDesAnalysesDataSet.TJ_PrelevementAnalyseDemandeDataTable dtPrelevementAnalyseDemande = new GestionDesAnalysesDataSet.TJ_PrelevementAnalyseDemandeDataTable();

        private static FT_PrelevementAnalyseDemandeTableAdapter adapFTPrelevementAnalyseDemande = new FT_PrelevementAnalyseDemandeTableAdapter();
        private static GestionDesAnalysesDataSet.FT_PrelevementAnalyseDemandeDataTable dtFTPrelevementAnalyseDemande = new GestionDesAnalysesDataSet.FT_PrelevementAnalyseDemandeDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces
        public static DataTable PrelevementAnalyse(decimal mNumDemande)
        {
            dtFTPrelevementAnalyseDemande = adapFTPrelevementAnalyseDemande.GetData(mNumDemande);
            return dtFTPrelevementAnalyseDemande;
        }
        /// <summary>
        /// Permet la suppression de PrelevementAnalyseDemande
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPrelevementAnalyseDemande.PS_PrelevementAnalyseDemande_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de PrelevementAnalyseDemande
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPrelevementAnalyseDemande.PS_PrelevementAnalyseDemande_IP(
                numDemande,
                codeAnalyse,
                codePrelevement,
                idCodeBarPrelevement,
                datePrelevement,
                tube,
                heurePrelevement,
                numPrelevement,
                qtePrelevee,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de PrelevementAnalyseDemande
        /// </summary>
        /// <param name="numDemande"></param>
        /// <param name="codeAnalyse"></param>
        /// <param name="codePrelevement"></param>
        /// <param name="idCodeBarPrelevement"></param>
        /// <param name="datePrelevement"></param>
        /// <param name="heurePrelevement"></param>
        /// <param name="numPrelevement"></param>
        /// <param name="numLigne">Le Numéro de Ligne de PrelevementAnalyseDemande</param>
        /// <param name="dateCreationServeur">La date de création de PrelevementAnalyseDemande</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de PrelevementAnalyseDemande</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de PrelevementAnalyseDemande</param>
        /// <param name="rowvers">Version de ligne de PrelevementAnalyseDemande</param>
        /// <param name="supprimer">Supprimer de PrelevementAnalyseDemande</param>
        /// <param name="userLogin">Le User Login de PrelevementAnalyseDemande</param>
        /// <param name="qtePrelevee"></param>
        /// <returns>Liste PrelevementAnalyseDemande</returns>
        public static List<PrelevementAnalyseDemande> Liste(
             Decimal? mNumDemande,
             string mCodeAnalyse,
             string mCodePrelevement,
             Decimal? mIdCodeBarPrelevement,
             DateTime? mDatePrelevement,
             DateTime? mHeurePrelevement,
             Decimal? mNumPrelevement,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             Byte[] mRowvers,
             bool? mSupprimer,
             string mUserLogin,
             Decimal? mQtePrelevee)
        {
            dtPrelevementAnalyseDemande = adapPrelevementAnalyseDemande.PS_PrelevementAnalyseDemande_SP(
                mNumDemande,
                mCodeAnalyse,
                mCodePrelevement,
                mIdCodeBarPrelevement,
                mDatePrelevement,
                mHeurePrelevement,
                mNumPrelevement,
                mNumLigne,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mRowvers,
                mSupprimer,
                mUserLogin,
                mQtePrelevee);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des PrelevementAnalyseDemande
        /// </summary>
        /// <returns>Liste PrelevementAnalyseDemande</returns>
        private static List<PrelevementAnalyseDemande> pListe()
        {
            List<PrelevementAnalyseDemande> mListe = new List<PrelevementAnalyseDemande>();
            foreach (GestionDesAnalysesDataSet.TJ_PrelevementAnalyseDemandeRow mLigne in dtPrelevementAnalyseDemande)
            {
                PrelevementAnalyseDemande oPrelevementAnalyseDemande = new PrelevementAnalyseDemande();
                oPrelevementAnalyseDemande.NumDemande = mLigne.numDemande;
                oPrelevementAnalyseDemande.CodeAnalyse = mLigne.codeAnalyse.Trim();
                oPrelevementAnalyseDemande.CodePrelevement = mLigne.codePrelevement.Trim();
                oPrelevementAnalyseDemande.IdCodeBarPrelevement = mLigne.idCodeBarPrelevement;
                oPrelevementAnalyseDemande.DatePrelevement = mLigne.datePrelevement;
                oPrelevementAnalyseDemande.HeurePrelevement = mLigne.heurePrelevement;
                oPrelevementAnalyseDemande.NumPrelevement = mLigne.numPrelevement;
                oPrelevementAnalyseDemande.NumLigne = mLigne.numLigne;
                oPrelevementAnalyseDemande.DateCreationServeur = mLigne.dateCreationServeur;
                oPrelevementAnalyseDemande.DateDernModifClient = mLigne.dateDernModifClient;
                oPrelevementAnalyseDemande.DateDernModifServeur = mLigne.dateDernModifServeur;
                oPrelevementAnalyseDemande.Rowvers = mLigne.rowvers;
                oPrelevementAnalyseDemande.Supprimer = mLigne.supprimer;
                oPrelevementAnalyseDemande.UserLogin = mLigne.userLogin.Trim();
                oPrelevementAnalyseDemande.QtePrelevee = mLigne.qtePrelevee;
                oPrelevementAnalyseDemande.LibelleAnalyse = mLigne.libelleAnalyse.Trim();
                oPrelevementAnalyseDemande.LibellePrelevement = mLigne.libellePrelevement;
                oPrelevementAnalyseDemande.Encoder = mLigne.Encoder;
                oPrelevementAnalyseDemande.IdCodeBarre = mLigne.idCodeBarre.Trim();
                oPrelevementAnalyseDemande.ShowTexte = mLigne.showTexte;
                oPrelevementAnalyseDemande.CodeUniteMesure = mLigne.codeUniteMesure.Trim();
                oPrelevementAnalyseDemande.Tube = mLigne.tube.Trim();
                oPrelevementAnalyseDemande.CodeTypeTube = mLigne.codeTypeTube.Trim();
                oPrelevementAnalyseDemande.LibelleTypeTube = mLigne.libelleTypeTube.Trim();

                mListe.Add(oPrelevementAnalyseDemande);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de PrelevementAnalyseDemande
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapPrelevementAnalyseDemande.PS_PrelevementAnalyseDemande_UP(
                numDemande,
                codeAnalyse,
                codePrelevement,
                idCodeBarPrelevement,
                datePrelevement,
                tube,
                heurePrelevement,
                numPrelevement,
                qtePrelevee,
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
