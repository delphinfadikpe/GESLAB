//Fichier :		 ProfilDroit.cs
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
	public class ProfilDroit
	{
		#region Constructeurs
		public ProfilDroit()
		{ }

		#endregion Constructeurs

		#region Champs
		#region Elémentaires
		#region Propres
        private string codeProfil;
        private string codeDroit;
        private string libelleProfil;

        public string LibelleProfil
        {
            get { return libelleProfil; }
            set { libelleProfil = value; }
        }
        private string libelleDroit;

        public string LibelleDroit
        {
            get { return libelleDroit; }
            set { libelleDroit = value; }
        }
		private bool creation;
		private bool modification;
		private bool suppression;
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
        private Droit oDroit = new Droit();

        public Droit ODroit
        {
            get { return oDroit; }
            set { oDroit = value; }
        }
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
		public string CodeProfil
		{
			get { return codeProfil.Trim(); }
			set { codeProfil = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public string CodeDroit
		{
			get { return codeDroit.Trim(); }
			set { codeDroit = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Creation
		{
			get { return creation; }
			set { creation = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Modification
		{
			get { return modification; }
			set { modification = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Suppression
		{
			get { return suppression; }
			set { suppression = value; }
		}

		#endregion Propres
		#region Passe partout
		/// <summary>
		/// La date de création de ProfilDroit
		/// </summary>
		public DateTime DateCreationServeur
		{
			get { return dateCreationServeur; }
			set { dateCreationServeur = value; }
		}

		/// <summary>
		/// La Date Dernière Modification Client de ProfilDroit
		/// </summary>
		public DateTime DateDernModifClient
		{
			get { return dateDernModifClient; }
			set { dateDernModifClient = value; }
		}

		/// <summary>
		/// La Date Dernière Modification Serveur de ProfilDroit
		/// </summary>
		public DateTime DateDernModifServeur
		{
			get { return dateDernModifServeur; }
			set { dateDernModifServeur = value; }
		}

		/// <summary>
		/// Le Numéro de Ligne de ProfilDroit
		/// </summary>
		public Decimal NumLigne
		{
			get { return numLigne; }
			set { numLigne = value; }
		}

		/// <summary>
		/// Version de ligne de ProfilDroit
		/// </summary>
		public Byte[] Rowvers
		{
			get { return rowvers; }
			set { rowvers = value; }
		}

		/// <summary>
		/// Supprimer de ProfilDroit
		/// </summary>
		public bool Supprimer
		{
			get { return supprimer; }
			set { supprimer = value; }
		}

		/// <summary>
		/// Le User Login de ProfilDroit
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
		private static TJ_ProfilDroitTableAdapter adapProfilDroit = new TJ_ProfilDroitTableAdapter();
        private static UserManagerDataSet.TJ_ProfilDroitDataTable dtProfilDroit = new UserManagerDataSet.TJ_ProfilDroitDataTable();
		string mSortie = string.Empty;
		#endregion Variables

		#region Méthodes
		#region Interfaces

		/// <summary>
		/// Permet la suppression de ProfilDroit
		/// </summary>
		/// <returns> </returns>
		public string Delete()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapProfilDroit.PS_ProfilDroit_DP(
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  (Decimal)NumLigne,
				  rowvers,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

		/// <summary>
		/// Permet l'enregistrement de ProfilDroit
		/// </summary>
		/// <returns> </returns>
		public string Insert()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapProfilDroit.PS_ProfilDroit_IP(
				  codeProfil,
				  codeDroit,
				  creation,
				  modification,
				  suppression,
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

		/// <summary>
		/// Retourne la liste de ProfilDroit
		/// </summary>
		/// <param name="codeProfil"></param>
		/// <param name="codeDroit"></param>
		/// <param name="creation"></param>
		/// <param name="modification"></param>
		/// <param name="suppression"></param>
		/// <param name="dateCreationServeur">La date de création de ProfilDroit</param>
		/// <param name="dateDernModifClient">La Date Dernière Modification Client de ProfilDroit</param>
		/// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ProfilDroit</param>
		/// <param name="numLigne">Le Numéro de Ligne de ProfilDroit</param>
		/// <param name="rowvers">Version de ligne de ProfilDroit</param>
		/// <param name="supprimer">Supprimer de ProfilDroit</param>
		/// <param name="userLogin">Le User Login de ProfilDroit</param>
		/// <returns>Liste ProfilDroit</returns>
        public static List<ProfilDroit> Liste(
             string mCodeProfil,
             string mCodeDroit,
             bool? mCreation,
             bool? mModification,
             bool? mSuppression,
             DateTime? mDateCreationServeur,
             DateTime? mDateDernModifClient,
             DateTime? mDateDernModifServeur,
             Decimal? mNumLigne,
             Byte[] mRowvers,
             bool? mSupprimer,
             string mUserLogin)
        {
            dtProfilDroit = adapProfilDroit.PS_ProfilDroit_SP(
                mCodeProfil,
                mCodeDroit,
                mCreation,
                mModification,
                mSuppression,
                mDateCreationServeur,
                mDateDernModifClient,
                mDateDernModifServeur,
                mNumLigne,
                mRowvers,
                mSupprimer,
                mUserLogin);
            return pListe();
        }

        public static List<ProfilDroit> DroitReelUtilisateur(Decimal? mNumeroUtilisateur)
        {
            dtProfilDroit = adapProfilDroit.PS_DroitReelUtilisateur(mNumeroUtilisateur);
            return pListe();
        }

        public static List<ProfilDroit> UtilisateurByDroit(string mCodeDroit)
        {
            dtProfilDroit = adapProfilDroit.PS_UtilisateurByDroit(mCodeDroit);
            return pListe();
        }

        public static List<ProfilDroit> ProfilByDroit(string mCodeDroit)
        {
            dtProfilDroit = adapProfilDroit.PS_ProfilByDroit(mCodeDroit);
            return pListe();
        }

		/// <summary>
		/// Retourne la liste des ProfilDroit
		/// </summary>
		/// <returns>Liste ProfilDroit</returns>
		private static List<ProfilDroit> pListe()
		{
            //recuperer la liste de tous les droits
            List<Droit> lstDroit = Droit.Liste(null, null, null, null, null, null,
                null, null, null, null, null, false, null);

			 List<ProfilDroit> mListe = new List<ProfilDroit>();
             foreach (UserManagerDataSet.TJ_ProfilDroitRow mLigne in dtProfilDroit)
			{
                ProfilDroit oProfilDroit = new ProfilDroit();
                oProfilDroit.CodeProfil = mLigne.codeProfil.Trim();
                oProfilDroit.CodeDroit = mLigne.codeDroit.Trim();
                oProfilDroit.libelleProfil = mLigne.libelleProfil.Trim();
                oProfilDroit.libelleDroit = mLigne.libelleDroit.Trim();
				 oProfilDroit.Creation = mLigne.creation;
				 oProfilDroit.Modification = mLigne.modification;
				 oProfilDroit.Suppression = mLigne.suppression;
				 oProfilDroit.DateCreationServeur = mLigne.dateCreationServeur;
				 oProfilDroit.DateDernModifClient = mLigne.dateDernModifClient;
				 oProfilDroit.DateDernModifServeur = mLigne.dateDernModifServeur;
				 oProfilDroit.NumLigne = mLigne.numLigne;
				 oProfilDroit.Rowvers = mLigne.rowvers;
				 oProfilDroit.Supprimer = mLigne.supprimer;
				 oProfilDroit.UserLogin = mLigne.userLogin.Trim();
                 oProfilDroit.oDroit = lstDroit.Find(l=>l.CodeDroit.Trim() ==
                     oProfilDroit.codeDroit.Trim());
				 mListe.Add(oProfilDroit);
			 }
			return mListe;
		 }

		/// <summary>
		/// Permet la mise à jour de ProfilDroit
		/// </summary>
		/// <returns> </returns>
		public string Update()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapProfilDroit.PS_ProfilDroit_UP(
				  codeProfil,
				  codeDroit,
				  creation,
				  modification,
				  suppression,
				  (Decimal)NumLigne,
				  rowvers,
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

        public static void DeleteAll(string mCodeProfil)
        {
            adapProfilDroit.PS_ProfilDroit_DP_ALL(mCodeProfil);
        }
		#endregion Interfaces

		#region Gestion des collections

		#endregion Gestion des collections

		#region Métier

		#endregion Métier
		#endregion Méthodes
	}
}

