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
    public class SecteursBiologique
    {
        #region Constructeurs
        public SecteursBiologique()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string codeSecteur;
        private string libelleSecteur;
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
        public string CodeSecteur
        {
            get { return codeSecteur.Trim(); }
            set { codeSecteur = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LibelleSecteur
        {
            get { return libelleSecteur.Trim(); }
            set { libelleSecteur = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de SecteursBiologique
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de SecteursBiologique
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de SecteursBiologique
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de SecteursBiologique
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de SecteursBiologique
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de SecteursBiologique
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de SecteursBiologique
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
        private static T_SecteursBiologiqueTableAdapter adapSecteursBiologique = new T_SecteursBiologiqueTableAdapter();
        private static ParametreDataSet1.T_SecteursBiologiqueDataTable dtSecteursBiologique = new ParametreDataSet1.T_SecteursBiologiqueDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de SecteursBiologique
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapSecteursBiologique.PS_SecteursBiologique_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de SecteursBiologique
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapSecteursBiologique.PS_SecteursBiologique_IP(
                codeSecteur,
                libelleSecteur,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de SecteursBiologique
        /// </summary>
        /// <param name="codeSecteur"></param>
        /// <param name="libelleSecteur"></param>
        /// <param name="numLigne">Le Numéro de Ligne de SecteursBiologique</param>
        /// <param name="dateCreationServeur">La date de création de SecteursBiologique</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de SecteursBiologique</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de SecteursBiologique</param>
        /// <param name="userLogin">Le User Login de SecteursBiologique</param>
        /// <param name="supprimer">Supprimer de SecteursBiologique</param>
        /// <param name="rowvers">Version de ligne de SecteursBiologique</param>
        /// <returns>Liste SecteursBiologique</returns>
        public static List<SecteursBiologique> Liste(
             string mCodeSecteur,
             string mLibelleSecteur,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtSecteursBiologique = adapSecteursBiologique.PS_SecteursBiologique_SP(
                mCodeSecteur,
                mLibelleSecteur,
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
        /// Retourne la liste des SecteursBiologique
        /// </summary>
        /// <returns>Liste SecteursBiologique</returns>
        private static List<SecteursBiologique> pListe()
        {
            List<SecteursBiologique> mListe = new List<SecteursBiologique>();
            foreach (ParametreDataSet1.T_SecteursBiologiqueRow mLigne in dtSecteursBiologique)
            {
                SecteursBiologique oSecteursBiologique = new SecteursBiologique();
                oSecteursBiologique.CodeSecteur = mLigne.codeSecteur.Trim();
                oSecteursBiologique.LibelleSecteur = mLigne.libelleSecteur.Trim();
                oSecteursBiologique.NumLigne = mLigne.numLigne;
                oSecteursBiologique.DateCreationServeur = mLigne.dateCreationServeur;
                oSecteursBiologique.DateDernModifClient = mLigne.dateDernModifClient;
                oSecteursBiologique.DateDernModifServeur = mLigne.dateDernModifServeur;
                oSecteursBiologique.UserLogin = mLigne.userLogin.Trim();
                oSecteursBiologique.Supprimer = mLigne.supprimer;
                oSecteursBiologique.Rowvers = mLigne.rowvers;

                mListe.Add(oSecteursBiologique);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de SecteursBiologique
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapSecteursBiologique.PS_SecteursBiologique_UP(
                codeSecteur,
                libelleSecteur,
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

