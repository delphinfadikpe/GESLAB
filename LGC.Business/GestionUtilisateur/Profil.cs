//Fichier :		 Profil.cs
//Auteur :		 Jean-Paul MENSAH
//Créer le :		 mardi 2 juin 2015
//Description :		 Le fichier de classe

using System;
using System.Text;
using System.Collections.Generic;
using LGC.DataAccess.GestionUtilisateur.UserManagerDataSetTableAdapters;
using LGC.DataAccess.GestionUtilisateur;
////using User_Manager.DataAccess.Parametre;
////using User_Manager.DataAccess.Parametre.ParametreDataSet1TableAdapters;

namespace LGC.Business.GestionUtilisateur
{
	/// <summary>
	/// 
	/// </summary>
	public class Profil
	{
		#region Constructeurs
		public Profil()
		{ }

		#endregion Constructeurs

		#region Champs
		#region Elémentaires
		#region Propres
		private string codeProfil;
		private string libelleProfil;
		private bool estActif;
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
		public string LibelleProfil
		{
			get { return libelleProfil.Trim(); }
			set { libelleProfil = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public bool EstActif
		{
			get { return estActif; }
			set { estActif = value; }
		}

		#endregion Propres
		#region Passe partout
		/// <summary>
		/// La date de création de Profil
		/// </summary>
		public DateTime DateCreationServeur
		{
			get { return dateCreationServeur; }
			set { dateCreationServeur = value; }
		}

		/// <summary>
		/// La Date Dernière Modification Client de Profil
		/// </summary>
		public DateTime DateDernModifClient
		{
			get { return dateDernModifClient; }
			set { dateDernModifClient = value; }
		}

		/// <summary>
		/// La Date Dernière Modification Serveur de Profil
		/// </summary>
		public DateTime DateDernModifServeur
		{
			get { return dateDernModifServeur; }
			set { dateDernModifServeur = value; }
		}

		/// <summary>
		/// Le Numéro de Ligne de Profil
		/// </summary>
		public Decimal NumLigne
		{
			get { return numLigne; }
			set { numLigne = value; }
		}

		/// <summary>
		/// Version de ligne de Profil
		/// </summary>
		public Byte[] Rowvers
		{
			get { return rowvers; }
			set { rowvers = value; }
		}

		/// <summary>
		/// Supprimer de Profil
		/// </summary>
		public bool Supprimer
		{
			get { return supprimer; }
			set { supprimer = value; }
		}

		/// <summary>
		/// Le User Login de Profil
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
		private static T_ProfilTableAdapter adapProfil = new T_ProfilTableAdapter();
		private static UserManagerDataSet.T_ProfilDataTable dtProfil = new UserManagerDataSet.T_ProfilDataTable();
		string mSortie = string.Empty;
		#endregion Variables

		#region Méthodes
		#region Interfaces

		/// <summary>
		/// Permet la suppression de Profil
		/// </summary>
		/// <returns> </returns>
		public string Delete()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapProfil.PS_Profil_DP(
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  (Decimal)NumLigne,
				  rowvers,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

		/// <summary>
		/// Permet l'enregistrement de Profil
		/// </summary>
		/// <returns> </returns>
		public string Insert()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapProfil.PS_Profil_IP(
				  codeProfil,
				  libelleProfil,
				  estActif,
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

		/// <summary>
		/// Retourne la liste de Profil
		/// </summary>
		/// <param name="codeProfil"></param>
		/// <param name="libelleProfil"></param>
		/// <param name="estActif"></param>
		/// <param name="dateCreationServeur">La date de création de Profil</param>
		/// <param name="dateDernModifClient">La Date Dernière Modification Client de Profil</param>
		/// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Profil</param>
		/// <param name="numLigne">Le Numéro de Ligne de Profil</param>
		/// <param name="rowvers">Version de ligne de Profil</param>
		/// <param name="supprimer">Supprimer de Profil</param>
		/// <param name="userLogin">Le User Login de Profil</param>
		/// <returns>Liste Profil</returns>
		public static List<Profil> Liste(
			 string mCodeProfil,
			 string mLibelleProfil,
			 bool? mEstActif,
			 DateTime? mDateCreationServeur,
			 DateTime? mDateDernModifClient,
			 DateTime? mDateDernModifServeur,
			 Decimal? mNumLigne,
			 Byte[] mRowvers,
			 bool? mSupprimer,
			 string mUserLogin )
		{
			  dtProfil = adapProfil.PS_Profil_SP(
				  mCodeProfil,
				  mLibelleProfil,
				  mEstActif,
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
		/// Retourne la liste des Profil
		/// </summary>
		/// <returns>Liste Profil</returns>
		private static List<Profil> pListe()
		{
			 List<Profil> mListe = new List<Profil>();
			 foreach (UserManagerDataSet.T_ProfilRow mLigne in dtProfil)
			{
				 Profil oProfil = new Profil();
				 oProfil.CodeProfil = mLigne.codeProfil.Trim();
				 oProfil.LibelleProfil = mLigne.libelleProfil.Trim();
				 oProfil.EstActif = mLigne.estActif;
				 oProfil.DateCreationServeur = mLigne.dateCreationServeur;
				 oProfil.DateDernModifClient = mLigne.dateDernModifClient;
				 oProfil.DateDernModifServeur = mLigne.dateDernModifServeur;
				 oProfil.NumLigne = mLigne.numLigne;
				 oProfil.Rowvers = mLigne.rowvers;
				 oProfil.Supprimer = mLigne.supprimer;
				 oProfil.UserLogin = mLigne.userLogin.Trim();

				 mListe.Add(oProfil);
			 }
			return mListe;
		 }

		/// <summary>
		/// Permet la mise à jour de Profil
		/// </summary>
		/// <returns> </returns>
		public string Update()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapProfil.PS_Profil_UP(
				  codeProfil,
				  libelleProfil,
				  estActif,
				  (Decimal)NumLigne,
				  rowvers,
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
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

