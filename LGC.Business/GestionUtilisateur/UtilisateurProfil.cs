//Fichier :		 UtilisateurProfil.cs
//Auteur :		 Jean-Paul MENSAH
//Créer le :		 mardi 2 juin 2015
//Description :		 Le fichier de classe

using System;
using System.Text;
using System.Collections.Generic;
using LGC.DataAccess.GestionUtilisateur.UserManagerDataSetTableAdapters;
using LGC.DataAccess.GestionUtilisateur;

namespace LGC.Business.GestionUtilisateur
{
	/// <summary>
	/// 
	/// </summary>
	public class UtilisateurProfil
	{
		#region Constructeurs
		public UtilisateurProfil()
		{ }

		#endregion Constructeurs

		#region Champs
		#region Elémentaires
		#region Propres
		private Decimal numeroUtilisateur;
        private string nomUtilisateur;
        private string prenomUtilisateur;
        private string sexe;
        private string telephone;
        private string mail;
        private string codeProfil;
        private string libelleProfil;
        private string intitule;

       

       
		#endregion Propres

		#region Passe partout
		private DateTime dateCreationServeur;
		private DateTime dateDernModifClient;
		private DateTime dateDernModifServeur;
		private Decimal numLigne;
		private Byte[] rowvers;
		private bool supprimer;
		private string userLogin;
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

        public string Intitule
        {
            get { return intitule; }
            set { intitule = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public Decimal NumeroUtilisateur
		{
			get { return numeroUtilisateur; }
			set { numeroUtilisateur = value; }
		}


        public string NomUtilisateur
        {
            get { return nomUtilisateur.Trim(); }
            set { nomUtilisateur = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PrenomUtilisateur
        {
            get { return prenomUtilisateur.Trim(); }
            set { prenomUtilisateur = value; }
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
        public string Telephone
        {
            get { return telephone.Trim(); }
            set { telephone = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Mail
        {
            get { return mail.Trim(); }
            set { mail = value; }
        }




		/// <summary>
		/// 
		/// </summary>
		public string CodeProfil
		{
			get { return codeProfil.Trim(); }
			set { codeProfil = value; }
		}


        public string LibelleProfil
        {
            get { return libelleProfil; }
            set { libelleProfil = value; }
        }

		#endregion Propres

		#region Passe partout
		/// <summary>
		/// La date de création de UtilisateurProfil
		/// </summary>
		public DateTime DateCreationServeur
		{
			get { return dateCreationServeur; }
			set { dateCreationServeur = value; }
		}

		/// <summary>
		/// La Date Dernière Modification Client de UtilisateurProfil
		/// </summary>
		public DateTime DateDernModifClient
		{
			get { return dateDernModifClient; }
			set { dateDernModifClient = value; }
		}

		/// <summary>
		/// La Date Dernière Modification Serveur de UtilisateurProfil
		/// </summary>
		public DateTime DateDernModifServeur
		{
			get { return dateDernModifServeur; }
			set { dateDernModifServeur = value; }
		}

		/// <summary>
		/// Le Numéro de Ligne de UtilisateurProfil
		/// </summary>
		public Decimal NumLigne
		{
			get { return numLigne; }
			set { numLigne = value; }
		}

		/// <summary>
		/// Version de ligne de UtilisateurProfil
		/// </summary>
		public Byte[] Rowvers
		{
			get { return rowvers; }
			set { rowvers = value; }
		}

		/// <summary>
		/// Supprimer de UtilisateurProfil
		/// </summary>
		public bool Supprimer
		{
			get { return supprimer; }
			set { supprimer = value; }
		}

		/// <summary>
		/// Le User Login de UtilisateurProfil
		/// </summary>
		public string UserLogin
		{
			get { return userLogin.Trim(); }
			set { userLogin = value; }
		}

		#endregion Passe partout
		#endregion Elémentaires

		#region Objets

		#endregion Objets

		#region Collections

		#endregion Collections
		#endregion Propriétés

		#region Variables
		private static TJ_UtilisateurProfilTableAdapter adapUtilisateurProfil = 
            new TJ_UtilisateurProfilTableAdapter();
		private static UserManagerDataSet.TJ_UtilisateurProfilDataTable dtUtilisateurProfil = 
            new UserManagerDataSet.TJ_UtilisateurProfilDataTable();
		string mSortie = string.Empty;
		#endregion Variables

		#region Méthodes
		#region Interfaces

		/// <summary>
		/// Permet la suppression de UtilisateurProfil
		/// </summary>
		/// <returns> </returns>
		public string Delete()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapUtilisateurProfil.PS_UtilisateurProfil_DP(
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  (Decimal)NumLigne,
				  rowvers,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

		/// <summary>
		/// Permet l'enregistrement de UtilisateurProfil
		/// </summary>
		/// <returns> </returns>
		public string Insert()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapUtilisateurProfil.PS_UtilisateurProfil_IP(
				  numeroUtilisateur,
				  codeProfil,
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

		/// <summary>
		/// Retourne la liste de UtilisateurProfil
		/// </summary>
		/// <param name="numeroUtilisateur"></param>
		/// <param name="codeProfil"></param>
		/// <param name="dateCreationServeur">La date de création de UtilisateurProfil</param>
		/// <param name="dateDernModifClient">La Date Dernière Modification Client de UtilisateurProfil</param>
		/// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de UtilisateurProfil</param>
		/// <param name="numLigne">Le Numéro de Ligne de UtilisateurProfil</param>
		/// <param name="rowvers">Version de ligne de UtilisateurProfil</param>
		/// <param name="supprimer">Supprimer de UtilisateurProfil</param>
		/// <param name="userLogin">Le User Login de UtilisateurProfil</param>
		/// <returns>Liste UtilisateurProfil</returns>
		public static List<UtilisateurProfil> Liste(
			 Decimal? mNumeroUtilisateur,
			 string mCodeProfil,
			 DateTime? mDateCreationServeur,
			 DateTime? mDateDernModifClient,
			 DateTime? mDateDernModifServeur,
			 Decimal? mNumLigne,
			 Byte[] mRowvers,
			 bool? mSupprimer,
			 string mUserLogin )
		{
			  dtUtilisateurProfil = adapUtilisateurProfil.PS_UtilisateurProfil_SP(
				  mNumeroUtilisateur,
				  mCodeProfil,
				  mDateCreationServeur,
				  mDateDernModifClient,
				  mDateDernModifServeur,
				  mNumLigne,
				  mRowvers,
				  mSupprimer,
				  mUserLogin );
			 return pListe();
		}

		/// <summary>
		/// Retourne la liste des UtilisateurProfil
		/// </summary>
		/// <returns>Liste UtilisateurProfil</returns>
		private static List<UtilisateurProfil> pListe()
		{
			 List<UtilisateurProfil> mListe = new List<UtilisateurProfil>();
			 foreach (UserManagerDataSet.TJ_UtilisateurProfilRow mLigne in dtUtilisateurProfil)
			{
				 UtilisateurProfil oUtilisateurProfil = new UtilisateurProfil();
				 oUtilisateurProfil.NumeroUtilisateur = mLigne.numeroUtilisateur;
                 oUtilisateurProfil.NomUtilisateur = mLigne.nomUtilisateur.Trim();
                 oUtilisateurProfil.PrenomUtilisateur = mLigne.prenomUtilisateur.Trim();
                 oUtilisateurProfil.Sexe = mLigne.sexe.Trim();
                 oUtilisateurProfil.Telephone = mLigne.telephone.Trim();
                 oUtilisateurProfil.Mail = mLigne.mail.Trim();
                 oUtilisateurProfil.CodeProfil = mLigne.codeProfil.Trim();
                 oUtilisateurProfil.libelleProfil = mLigne.libelleProfil.Trim();
				 oUtilisateurProfil.DateCreationServeur = mLigne.dateCreationServeur;
				 oUtilisateurProfil.DateDernModifClient = mLigne.dateDernModifClient;
				 oUtilisateurProfil.DateDernModifServeur = mLigne.dateDernModifServeur;
				 oUtilisateurProfil.NumLigne = mLigne.numLigne;
				 oUtilisateurProfil.Rowvers = mLigne.rowvers;
				 oUtilisateurProfil.Supprimer = mLigne.supprimer;
				 oUtilisateurProfil.UserLogin = mLigne.userLogin.Trim();
                 oUtilisateurProfil.Intitule = mLigne.nomUtilisateur.Trim() + " " + mLigne.prenomUtilisateur.Trim();
				 mListe.Add(oUtilisateurProfil);
			 }
			return mListe;
		 }

		/// <summary>
		/// Permet la mise à jour de UtilisateurProfil
		/// </summary>
		/// <returns> </returns>
		public string Update()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapUtilisateurProfil.PS_UtilisateurProfil_UP(
				  numeroUtilisateur,
				  codeProfil,
				  (Decimal)NumLigne,
				  rowvers,
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

        public static void DeleteAll(decimal mIdUtil)
        {
            adapUtilisateurProfil.PS_UtilisateurProfil_DP_ALL(mIdUtil);
        }
		#endregion Interfaces

		#region Gestion des collections

		#endregion Gestion des collections

		#region Métier

		#endregion Métier
		#endregion Méthodes
	}
}

