//Fichier :		 Securite.cs
//Auteur :		 Jean-Paul MENSAH
//Créer le :		 lundi 15 juin 2015
//Description :		 Le fichier de classe

using System;
using System.Text;
using System.Collections.Generic;
using LGG.DataAccess.GestionUtilisateur.UserManagerDataSetTableAdapters;
using LGG.DataAccess.GestionUtilisateur;

namespace LGG.Business.GestionUtilisateur
{
	/// <summary>
	/// 
	/// </summary>
	public class Securite
	{
		#region Constructeurs
		public Securite()
		{ }

		#endregion Constructeurs

		#region Champs
		#region Elémentaires
		#region Propres
		private string str;
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
		public string Str
		{
			get { return str.Trim(); }
			set { str = value; }
		}

		#endregion Propres
		#region Passe partout
		/// <summary>
		/// La date de création de Securite
		/// </summary>
		public DateTime DateCreationServeur
		{
			get { return dateCreationServeur; }
			set { dateCreationServeur = value; }
		}

		/// <summary>
		/// La Date Dernière Modification Client de Securite
		/// </summary>
		public DateTime DateDernModifClient
		{
			get { return dateDernModifClient; }
			set { dateDernModifClient = value; }
		}

		/// <summary>
		/// La Date Dernière Modification Serveur de Securite
		/// </summary>
		public DateTime DateDernModifServeur
		{
			get { return dateDernModifServeur; }
			set { dateDernModifServeur = value; }
		}

		/// <summary>
		/// Le Numéro de Ligne de Securite
		/// </summary>
		public Decimal NumLigne
		{
			get { return numLigne; }
			set { numLigne = value; }
		}

		/// <summary>
		/// Version de ligne de Securite
		/// </summary>
		public Byte[] Rowvers
		{
			get { return rowvers; }
			set { rowvers = value; }
		}

		/// <summary>
		/// Supprimer de Securite
		/// </summary>
		public bool Supprimer
		{
			get { return supprimer; }
			set { supprimer = value; }
		}

		/// <summary>
		/// Le User Login de Securite
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
		private static T_SecuriteTableAdapter adapSecurite = 
            new T_SecuriteTableAdapter();
		private static UserManagerDataSet.T_SecuriteDataTable dtSecurite = 
            new UserManagerDataSet.T_SecuriteDataTable();
		string mSortie = string.Empty;
		#endregion Variables

		#region Méthodes
		#region Interfaces

		/// <summary>
		/// Permet la suppression de Securite
		/// </summary>
		/// <returns> </returns>
		public string Delete()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapSecurite.PS_Securite_DP(
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  (Decimal)NumLigne,
				  rowvers,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

		/// <summary>
		/// Permet l'enregistrement de Securite
		/// </summary>
		/// <returns> </returns>
		public string Insert()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapSecurite.PS_Securite_IP(
				  str,
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

		/// <summary>
		/// Retourne la liste de Securite
		/// </summary>
		/// <param name="str"></param>
		/// <param name="dateCreationServeur">La date de création de Securite</param>
		/// <param name="dateDernModifClient">La Date Dernière Modification Client de Securite</param>
		/// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de Securite</param>
		/// <param name="numLigne">Le Numéro de Ligne de Securite</param>
		/// <param name="rowvers">Version de ligne de Securite</param>
		/// <param name="supprimer">Supprimer de Securite</param>
		/// <param name="userLogin">Le User Login de Securite</param>
		/// <returns>Liste Securite</returns>
		public static List<Securite> Liste(
			 string mStr,
			 DateTime? mDateCreationServeur,
			 DateTime? mDateDernModifClient,
			 DateTime? mDateDernModifServeur,
			 Decimal? mNumLigne,
			 Byte[] mRowvers,
			 bool? mSupprimer,
			 string mUserLogin )
		{
			  dtSecurite = adapSecurite.PS_Securite_SP(
				  mStr,
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
		/// Retourne la liste des Securite
		/// </summary>
		/// <returns>Liste Securite</returns>
		private static List<Securite> pListe()
		{
			 List<Securite> mListe = new List<Securite>();
			 foreach (UserManagerDataSet.T_SecuriteRow mLigne in dtSecurite)
			{
				 Securite oSecurite = new Securite();
				 oSecurite.Str = mLigne.str.Trim();
				 oSecurite.DateCreationServeur = mLigne.dateCreationServeur;
				 oSecurite.DateDernModifClient = mLigne.dateDernModifClient;
				 oSecurite.DateDernModifServeur = mLigne.dateDernModifServeur;
				 oSecurite.NumLigne = mLigne.numLigne;
				 oSecurite.Rowvers = mLigne.rowvers;
				 oSecurite.Supprimer = mLigne.supprimer;
				 oSecurite.UserLogin = mLigne.userLogin.Trim();

				 mListe.Add(oSecurite);
			 }
			return mListe;
		 }

		/// <summary>
		/// Permet la mise à jour de Securite
		/// </summary>
		/// <returns> </returns>
		public string Update()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapSecurite.PS_Securite_UP(
				  str,
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

