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
    public class SecteurActivite
    {
        #region Constructeurs
        public SecteurActivite()
        { }

        #endregion Constructeurs

        #region Champs
        #region Elémentaires
        #region Propres
        private string libelleSecteurActivite;
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
        public string LibelleSecteurActivite
        {
            get { return libelleSecteurActivite.Trim(); }
            set { libelleSecteurActivite = value; }
        }

        #endregion Propres
        #region Passe partout
        /// <summary>
        /// Le Numéro de Ligne de SecteurActivite
        /// </summary>
        public Decimal NumLigne
        {
            get { return numLigne; }
            set { numLigne = value; }
        }

        /// <summary>
        /// La date de création de SecteurActivite
        /// </summary>
        public DateTime DateCreationServeur
        {
            get { return dateCreationServeur; }
            set { dateCreationServeur = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Client de SecteurActivite
        /// </summary>
        public DateTime DateDernModifClient
        {
            get { return dateDernModifClient; }
            set { dateDernModifClient = value; }
        }

        /// <summary>
        /// La Date Dernière Modification Serveur de SecteurActivite
        /// </summary>
        public DateTime DateDernModifServeur
        {
            get { return dateDernModifServeur; }
            set { dateDernModifServeur = value; }
        }

        /// <summary>
        /// Le User Login de SecteurActivite
        /// </summary>
        public string UserLogin
        {
            get { return userLogin.Trim(); }
            set { userLogin = value; }
        }

        /// <summary>
        /// Supprimer de SecteurActivite
        /// </summary>
        public bool Supprimer
        {
            get { return supprimer; }
            set { supprimer = value; }
        }

        /// <summary>
        /// Version de ligne de SecteurActivite
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
        private static T_SecteurActiviteTableAdapter adapSecteurActivite = new T_SecteurActiviteTableAdapter();
        private static ParametreDataSet1.T_SecteurActiviteDataTable dtSecteurActivite = new ParametreDataSet1.T_SecteurActiviteDataTable();
        string mSortie = string.Empty;
        #endregion Variables

        #region Méthodes
        #region Interfaces

        /// <summary>
        /// Permet la suppression de SecteurActivite
        /// </summary>
        /// <returns> </returns>
        public string Delete()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapSecteurActivite.PS_SecteurActivite_DP(
                CurrentUser.UserLogin,
                DateTime.Now,
                (Decimal)NumLigne,
                rowvers,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Permet l'enregistrement de SecteurActivite
        /// </summary>
        /// <returns> </returns>
        public string Insert()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapSecteurActivite.PS_SecteurActivite_IP(
                libelleSecteurActivite,
                CurrentUser.UserLogin,
                DateTime.Now,
                CurrentUser.CurrentLangue,
               ref mSortie);
            return mSortie;
        }

        /// <summary>
        /// Retourne la liste de SecteurActivite
        /// </summary>
        /// <param name="libelleSecteurActivite"></param>
        /// <param name="numLigne">Le Numéro de Ligne de SecteurActivite</param>
        /// <param name="dateCreationServeur">La date de création de SecteurActivite</param>
        /// <param name="dateDernModifClient">La Date Dernière Modification Client de SecteurActivite</param>
        /// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de SecteurActivite</param>
        /// <param name="userLogin">Le User Login de SecteurActivite</param>
        /// <param name="supprimer">Supprimer de SecteurActivite</param>
        /// <param name="rowvers">Version de ligne de SecteurActivite</param>
        /// <returns>Liste SecteurActivite</returns>
        public static List<SecteurActivite> Liste(
             string mLibelleSecteurActivite,
             Decimal? mNumLigne,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             string mUserLogin,
             bool? mSupprimer,
             Byte[] mRowvers)
        {
            dtSecteurActivite = adapSecteurActivite.PS_SecteurActivite_SP(
                mLibelleSecteurActivite,
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
        /// Retourne la liste des SecteurActivite
        /// </summary>
        /// <returns>Liste SecteurActivite</returns>
        private static List<SecteurActivite> pListe()
        {
            List<SecteurActivite> mListe = new List<SecteurActivite>();
            foreach (ParametreDataSet1.T_SecteurActiviteRow mLigne in dtSecteurActivite)
            {
                SecteurActivite oSecteurActivite = new SecteurActivite();
                oSecteurActivite.LibelleSecteurActivite = mLigne.libelleSecteurActivite.Trim();
                oSecteurActivite.NumLigne = mLigne.numLigne;
                oSecteurActivite.DateCreationServeur = mLigne.dateCreationServeur;
                oSecteurActivite.DateDernModifClient = mLigne.dateDernModifClient;
                oSecteurActivite.DateDernModifServeur = mLigne.dateDernModifServeur;
                oSecteurActivite.UserLogin = mLigne.userLogin.Trim();
                oSecteurActivite.Supprimer = mLigne.supprimer;
                oSecteurActivite.Rowvers = mLigne.rowvers;

                mListe.Add(oSecteurActivite);
            }
            return mListe;
        }

        /// <summary>
        /// Permet la mise à jour de SecteurActivite
        /// </summary>
        /// <returns> </returns>
        public string Update()
        {
            string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
            adapSecteurActivite.PS_SecteurActivite_UP(
                libelleSecteurActivite,
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

