//Fichier :		 ConfigurationUM.cs
//Auteur :		 GABIN ANASGAB
//Créer le :		 lundi 22 juin 2015
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
	public class ConfigurationUM
	{
		#region Constructeurs
		public ConfigurationUM()
		{ }

		#endregion Constructeurs

		#region Champs
		#region Elémentaires
		#region Propres
		private string strPath;
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
		public string StrPath
		{
			get { return strPath.Trim(); }
			set { strPath = value; }
		}

		#endregion Propres
		#region Passe partout
		/// <summary>
		/// La date de création de ConfigurationUM
		/// </summary>
		public DateTime DateCreationServeur
		{
			get { return dateCreationServeur; }
			set { dateCreationServeur = value; }
		}

		/// <summary>
		/// La Date Dernière Modification Client de ConfigurationUM
		/// </summary>
		public DateTime DateDernModifClient
		{
			get { return dateDernModifClient; }
			set { dateDernModifClient = value; }
		}

		/// <summary>
		/// La Date Dernière Modification Serveur de ConfigurationUM
		/// </summary>
		public DateTime DateDernModifServeur
		{
			get { return dateDernModifServeur; }
			set { dateDernModifServeur = value; }
		}

		/// <summary>
		/// Le Numéro de Ligne de ConfigurationUM
		/// </summary>
		public Decimal NumLigne
		{
			get { return numLigne; }
			set { numLigne = value; }
		}

		/// <summary>
		/// Version de ligne de ConfigurationUM
		/// </summary>
		public Byte[] Rowvers
		{
			get { return rowvers; }
			set { rowvers = value; }
		}

		/// <summary>
		/// Supprimer de ConfigurationUM
		/// </summary>
		public bool Supprimer
		{
			get { return supprimer; }
			set { supprimer = value; }
		}

		/// <summary>
		/// Le User Login de ConfigurationUM
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
		private static T_ConfigurationUMTableAdapter adapConfigurationUM = new T_ConfigurationUMTableAdapter();
		private static UserManagerDataSet.T_ConfigurationUMDataTable dtConfigurationUM = new UserManagerDataSet.T_ConfigurationUMDataTable();
		string mSortie = string.Empty;
		#endregion Variables

		#region Méthodes
		#region Interfaces

		/// <summary>
		/// Permet la suppression de ConfigurationUM
		/// </summary>
		/// <returns> </returns>
		public string Delete()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapConfigurationUM.PS_ConfigurationUM_DP(
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  (Decimal)NumLigne,
				  rowvers,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

		/// <summary>
		/// Permet l'enregistrement de ConfigurationUM
		/// </summary>
		/// <returns> </returns>
		public string Insert()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapConfigurationUM.PS_ConfigurationUM_IP(
				  strPath,
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

		/// <summary>
		/// Retourne la liste de ConfigurationUM
		/// </summary>
		/// <param name="strPath"></param>
		/// <param name="dateCreationServeur">La date de création de ConfigurationUM</param>
		/// <param name="dateDernModifClient">La Date Dernière Modification Client de ConfigurationUM</param>
		/// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de ConfigurationUM</param>
		/// <param name="numLigne">Le Numéro de Ligne de ConfigurationUM</param>
		/// <param name="rowvers">Version de ligne de ConfigurationUM</param>
		/// <param name="supprimer">Supprimer de ConfigurationUM</param>
		/// <param name="userLogin">Le User Login de ConfigurationUM</param>
		/// <returns>Liste ConfigurationUM</returns>
		public static List<ConfigurationUM> Liste(
			 string mStrPath,
			 DateTime? mDateCreationServeur,
			 DateTime? mDateDernModifClient,
			 DateTime? mDateDernModifServeur,
			 Decimal? mNumLigne,
			 Byte[] mRowvers,
			 bool? mSupprimer,
			 string mUserLogin )
		{
            dtConfigurationUM = adapConfigurationUM.PS_ConfigurationUM_SP(
				  mStrPath,
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
		/// Retourne la liste des ConfigurationUM
		/// </summary>
		/// <returns>Liste ConfigurationUM</returns>
		private static List<ConfigurationUM> pListe()
		{
			 List<ConfigurationUM> mListe = new List<ConfigurationUM>();
			 foreach (UserManagerDataSet.T_ConfigurationUMRow mLigne in dtConfigurationUM)
			{
				 ConfigurationUM oConfigurationUM = new ConfigurationUM();
				 oConfigurationUM.StrPath = mLigne.strPath.Trim();
				 oConfigurationUM.DateCreationServeur = mLigne.dateCreationServeur;
				 oConfigurationUM.DateDernModifClient = mLigne.dateDernModifClient;
				 oConfigurationUM.DateDernModifServeur = mLigne.dateDernModifServeur;
				 oConfigurationUM.NumLigne = mLigne.numLigne;
				 oConfigurationUM.Rowvers = mLigne.rowvers;
				 oConfigurationUM.Supprimer = mLigne.supprimer;
				 oConfigurationUM.UserLogin = mLigne.userLogin.Trim();

				 mListe.Add(oConfigurationUM);
			 }
			return mListe;
		 }

		/// <summary>
		/// Permet la mise à jour de ConfigurationUM
		/// </summary>
		/// <returns> </returns>
		public string Update()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapConfigurationUM.PS_ConfigurationUM_UP(
				  strPath,
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

