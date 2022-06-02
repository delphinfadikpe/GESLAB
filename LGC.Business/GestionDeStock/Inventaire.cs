//Fichier :		 Inventaire.cs
//Auteur :		 Derrick TOIHOUN
//Créer le :		 Mercredi 26 Août 2015
//Description :		 Le fichier de classe

using LGC.Business.GestionUtilisateur;
using LGC.DataAccess.GestionDeStock;
using LGC.DataAccess.GestionDeStock.GestionDeStockDataSetTableAdapters;
//using LGG.Business.GestionUtilisateur;
//using LGG.DataAccess.AutresOperations;
//using LGG.DataAccess.AutresOperations.AutresOperationsDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGC.Business.GestionDeStock
{
    /// <summary>
    /// 
    /// </summary>
    public class Inventaire
    {
        #region Constructeurs
        public Inventaire()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private Decimal numeroInventaire;
        private string codeTypeInventaire;
        private DateTime dateFin;
        private DateTime dateDebut;
        private string etat;
        private string libelleTypeInventaire;

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


        public string LibelleTypeInventaire
        {
            get { return libelleTypeInventaire; }
            set { libelleTypeInventaire = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Decimal NumeroInventaire
        {
            get { return numeroInventaire; }
            set { numeroInventaire = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodeTypeInventaire
        {
            get { return codeTypeInventaire.Trim(); }
            set { codeTypeInventaire = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateFin
        {
            get { return dateFin; }
            set { dateFin = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateDebut
        {
            get { return dateDebut; }
            set { dateDebut = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Etat
        {
            get { return etat.Trim(); }
            set { etat = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Inventaire
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de Inventaire
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Inventaire
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Inventaire
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Inventaire
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Inventaire
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Inventaire
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
        private static FT_FichePreInventaireTableAdapter adapFT_FichePreInventaire =
         new FT_FichePreInventaireTableAdapter();
        private static GestionDeStockDataSet.FT_FichePreInventaireDataTable dtFT_FichePreInventaire =
            new GestionDeStockDataSet.FT_FichePreInventaireDataTable();
        private static FT_FicheInventaireTableAdapter adapFT_FicheInventaire =
          new FT_FicheInventaireTableAdapter();
        private static GestionDeStockDataSet.FT_FicheInventaireDataTable dtFT_FicheInventaire =
            new GestionDeStockDataSet.FT_FicheInventaireDataTable();
        private static T_InventaireTableAdapter adapInventaire = new T_InventaireTableAdapter();
        private static GestionDeStockDataSet.T_InventaireDataTable dtInventaire = new GestionDeStockDataSet.T_InventaireDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces
        //Impression de la fiche d'Inventaire
        public static DataTable FicheInventaire(Int32 mNumeroInventaire)
        {
            return adapFT_FicheInventaire.GetData(mNumeroInventaire);
        }
        //Impression de la fiche de préInventaire
        public static DataTable FichePreInventaire(Int32 mNumeroInventaire)
        {
            return adapFT_FichePreInventaire.GetData(mNumeroInventaire);
        }
        /// <summary>
        /// Permet la suppression de Inventaire
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapInventaire.PS_Inventaire_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Inventaire
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapInventaire.PS_Inventaire_IP(
                numeroInventaire,
                codeTypeInventaire,
                dateFin,
                dateDebut,
                etat,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Inventaire
        /// </summary>
        /// <param name="numeroInventaire"></param>
        /// <param name="codeTypeInventaire"></param>
        /// <param name="dateFin"></param>
        /// <param name="dateDebut"></param>
        /// <param name="etat"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Inventaire</param>
        /// <param name="dateCreationServeur">La date de création de Inventaire</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Inventaire</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Inventaire</param>
        /// <param name="userLogin">Le User Login de Inventaire</param>
        /// <param name="supprimer">Supprimer de Inventaire</param>
        /// <param name="rowvers">Version de ligne de Inventaire</param>
        /// <returns>Liste Inventaire</returns>
        public static List<Inventaire> Liste(
             Decimal? mNumeroInventaire,
             string mCodeTypeInventaire,
             DateTime? mDateFin,
             DateTime? mDateDebut,
             string mEtat,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtInventaire = adapInventaire.PS_Inventaire_SP(
                mNumeroInventaire,
                mCodeTypeInventaire,
                mDateFin,
                mDateDebut,
                mEtat,
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
        /// Retourne la liste des Inventaire
        /// </summary>
        /// <returns>Liste Inventaire</returns>
        private static List<Inventaire> pListe()
        {
            List<Inventaire> mListe = new List<Inventaire>();
            foreach (GestionDeStockDataSet.T_InventaireRow mLigne in dtInventaire)
            {
                Inventaire oInventaire = new Inventaire();
                oInventaire.NumeroInventaire = mLigne.numeroInventaire;
                oInventaire.LibelleTypeInventaire = mLigne.libelleTypeInventaire.Trim();
                oInventaire.CodeTypeInventaire = mLigne.codeTypeInventaire.Trim();
                oInventaire.DateFin = mLigne.dateFin;
                oInventaire.DateDebut = mLigne.dateDebut;
                oInventaire.Etat = mLigne.etat.Trim();
                oInventaire.NumLigne = mLigne.numLigne;
                oInventaire.DateCreationServeur = mLigne.dateCreationServeur;
                oInventaire.DateDernModifClient = mLigne.dateDernModifClient;
                oInventaire.DateDernModifServeur = mLigne.dateDernModifServeur;
                oInventaire.UserLogin = mLigne.userLogin.Trim();
                oInventaire.Supprimer = mLigne.supprimer;
                oInventaire.Rowvers = mLigne.rowvers;

                mListe.Add(oInventaire);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Inventaire
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapInventaire.PS_Inventaire_UP(
                numeroInventaire,
                codeTypeInventaire,
                dateFin,
                dateDebut,
                etat,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        public List<Utilisateur> getPersonneConcernneeInventaire()
        {
            List<Utilisateur> lstUtilisateur = new List<Utilisateur>();
            List<PersonneConcernneeInventaire> lstPersonneConcernneeInventaire = new List<PersonneConcernneeInventaire>();

            if (!String.IsNullOrEmpty(Convert.ToString(this.numeroInventaire)))
            {
                lstPersonneConcernneeInventaire = PersonneConcernneeInventaire.Liste(null, Convert.ToString(this.numeroInventaire),
                null, null, null, null, null, false, null);

                if (lstPersonneConcernneeInventaire != null)
                {
                    foreach (PersonneConcernneeInventaire pci in lstPersonneConcernneeInventaire)
                    {
                        List<Utilisateur> mListe = Utilisateur.Liste(Convert.ToDecimal(pci.NumeroUtilisateur), null, null, null,
                                                null, null, null, null, null, null, null, null, null, null, null, null,null, false, null);

                        if (mListe != null && mListe.Count > 0)
                            lstUtilisateur.Add(mListe[0]);
                    }
                }
            }

            return lstUtilisateur;
        }

        #endregion Interfaces

        #region Gestion des collections

        #endregion Gestion des collections

        #region Métier

        #endregion Métier
        #endregion Méthodes
    }
}

