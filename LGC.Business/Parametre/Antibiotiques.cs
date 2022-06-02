using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGC.DataAccess.Parametre;
using LGC.DataAccess.Parametre.ParametreDataSet2TableAdapters;

namespace LGC.Business.Parametre
{
    /// <summary>
    /// 
    /// </summary>
    public class Antibiotiques
    {
        #region Constructeurs
        public Antibiotiques()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string code;
        private string libelle;
        #endregion Propres

        #region Passe partout
        private Decimal numLigne;
        private string type;
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
        public string Code
        {
            get { return code.Trim(); }
            set { code = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Libelle
        {
            get { return libelle.Trim(); }
            set { libelle = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de Antibiotiques
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            get { return type.Trim(); }
            set { type = value; }
        }

        /// <summary>
        /// La date de création de Antibiotiques
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de Antibiotiques
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de Antibiotiques
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de Antibiotiques
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de Antibiotiques
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de Antibiotiques
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
        private static T_AntibiotiquesTableAdapter adapAntibiotiques = new T_AntibiotiquesTableAdapter();
        private static ParametreDataSet2.T_AntibiotiquesDataTable dtAntibiotiques = new ParametreDataSet2.T_AntibiotiquesDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de Antibiotiques
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAntibiotiques.PS_Antibiotiques_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de Antibiotiques
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAntibiotiques.PS_Antibiotiques_IP(
                code,
                libelle,
                type,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de Antibiotiques
        /// </summary>
        /// <param name="code"></param>
        /// <param name="libelle"></param>
        /// <param name="numLigne">Le Numéro de Ligne de Antibiotiques</param>
        /// <param name="type"></param>
        /// <param name="dateCreationServeur">La date de création de Antibiotiques</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de Antibiotiques</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Antibiotiques</param>
        /// <param name="userLogin">Le User Login de Antibiotiques</param>
        /// <param name="supprimer">Supprimer de Antibiotiques</param>
        /// <param name="rowvers">Version de ligne de Antibiotiques</param>
        /// <returns>Liste Antibiotiques</returns>
        public static List<Antibiotiques> Liste(
             string mCode,
             string mLibelle,
             Decimal? mNumLigne,
             string mType,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtAntibiotiques = adapAntibiotiques.PS_Antibiotiques_SP(
                mCode,
                mLibelle,
                mNumLigne,
                mType,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mUserLogin,
                mSupprimer,
                mRowvers);
            return pListe();
        }

        /// <summary>
        /// Retourne la liste des Antibiotiques
        /// </summary>
        /// <returns>Liste Antibiotiques</returns>
        private static List<Antibiotiques> pListe()
        {
            List<Antibiotiques> mListe = new List<Antibiotiques>();
            foreach (ParametreDataSet2.T_AntibiotiquesRow mLigne in dtAntibiotiques)
            {
                Antibiotiques oAntibiotiques = new Antibiotiques();
                oAntibiotiques.Code = mLigne.code.Trim();
                oAntibiotiques.Libelle = mLigne.libelle.Trim();
                oAntibiotiques.NumLigne = mLigne.numLigne;
                oAntibiotiques.Type = mLigne.type.Trim();
                oAntibiotiques.DateCreationServeur = mLigne.dateCreationServeur;
                oAntibiotiques.DateDernModifClient = mLigne.dateDernModifClient;
                oAntibiotiques.DateDernModifServeur = mLigne.dateDernModifServeur;
                oAntibiotiques.UserLogin = mLigne.userLogin.Trim();
                oAntibiotiques.Supprimer = mLigne.supprimer;
                oAntibiotiques.Rowvers = mLigne.rowvers;

                mListe.Add(oAntibiotiques);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de Antibiotiques
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapAntibiotiques.PS_Antibiotiques_UP(
                code,
                libelle,
                type,
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
