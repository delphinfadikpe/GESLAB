//Fichier :		 JournalConnexionOperation.cs
//Auteur :		 Jean-Paul MENSAH
//Créer le :		 mercredi 17 juin 2015
//Description :		 Le fichier de classe

using System;
using System.Text;
using System.Collections.Generic;
using LGC.DataAccess.GestionUtilisateur.UserManagerDataSetTableAdapters;
using LGC.DataAccess.GestionUtilisateur;

namespace LGC.Business.GestionUtilisateur.Parametre
{
	/// <summary>
	/// 
	/// </summary>
	public class JournalConnexionOperation
	{
		#region Constructeurs
		public JournalConnexionOperation()
		{ }

		#endregion Constructeurs

		#region Champs
		#region Elémentaires
		#region Propres
		private Decimal numeroConnexion;
		private string libelleOperation;
		private DateTime dateOperation;
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
		public Decimal NumeroConnexion
		{
			get { return numeroConnexion; }
			set { numeroConnexion = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public string LibelleOperation
		{
			get { return libelleOperation.Trim(); }
			set { libelleOperation = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime DateOperation
		{
			get { return dateOperation; }
			set { dateOperation = value; }
		}

		#endregion Propres
		#region Passe partout
		/// <summary>
		/// La date de création de JournalConnexionOperation
		/// </summary>
		public DateTime DateCreationServeur
		{
			get { return dateCreationServeur; }
			set { dateCreationServeur = value; }
		}

		/// <summary>
		/// La Date Dernière Modification Client de JournalConnexionOperation
		/// </summary>
		public DateTime DateDernModifClient
		{
			get { return dateDernModifClient; }
			set { dateDernModifClient = value; }
		}

		/// <summary>
		/// La Date Dernière Modification Serveur de JournalConnexionOperation
		/// </summary>
		public DateTime DateDernModifServeur
		{
			get { return dateDernModifServeur; }
			set { dateDernModifServeur = value; }
		}

		/// <summary>
		/// Le Numéro de Ligne de JournalConnexionOperation
		/// </summary>
		public Decimal NumLigne
		{
			get { return numLigne; }
			set { numLigne = value; }
		}

		/// <summary>
		/// Version de ligne de JournalConnexionOperation
		/// </summary>
		public Byte[] Rowvers
		{
			get { return rowvers; }
			set { rowvers = value; }
		}

		/// <summary>
		/// Supprimer de JournalConnexionOperation
		/// </summary>
		public bool Supprimer
		{
			get { return supprimer; }
			set { supprimer = value; }
		}

		/// <summary>
		/// Le User Login de JournalConnexionOperation
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
		private static TJ_JournalConnexionOperationTableAdapter 
            adapJournalConnexionOperation = new TJ_JournalConnexionOperationTableAdapter();
		private static UserManagerDataSet.TJ_JournalConnexionOperationDataTable 
            dtJournalConnexionOperation = new UserManagerDataSet.TJ_JournalConnexionOperationDataTable();
		string mSortie = string.Empty;
		#endregion Variables

		#region Méthodes
		#region Interfaces

		/// <summary>
		/// Permet la suppression de JournalConnexionOperation
		/// </summary>
		/// <returns> </returns>
		public string Delete()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapJournalConnexionOperation.PS_JournalConnexionOperation_DP(
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  (Decimal)NumLigne,
				  rowvers,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

		/// <summary>
		/// Permet l'enregistrement de JournalConnexionOperation
		/// </summary>
		/// <returns> </returns>
		public string Insert()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapJournalConnexionOperation.PS_JournalConnexionOperation_IP(
				  numeroConnexion,
				  libelleOperation,
				  dateOperation,
				  CurrentUser.UserLogin,
				  DateTime.Now,
				  CurrentUser.CurrentLangue,
				 ref mSortie );
			 return mSortie;
		}

		/// <summary>
		/// Retourne la liste de JournalConnexionOperation
		/// </summary>
		/// <param name="numeroConnexion"></param>
		/// <param name="libelleOperation"></param>
		/// <param name="dateOperation"></param>
		/// <param name="dateCreationServeur">La date de création de JournalConnexionOperation</param>
		/// <param name="dateDernModifClient">La Date Dernière Modification Client de JournalConnexionOperation</param>
		/// <param name="dateDernModifServeur">La Date Dernière Modification Serveur de JournalConnexionOperation</param>
		/// <param name="numLigne">Le Numéro de Ligne de JournalConnexionOperation</param>
		/// <param name="rowvers">Version de ligne de JournalConnexionOperation</param>
		/// <param name="supprimer">Supprimer de JournalConnexionOperation</param>
		/// <param name="userLogin">Le User Login de JournalConnexionOperation</param>
		/// <returns>Liste JournalConnexionOperation</returns>
		public static List<JournalConnexionOperation> Liste(
			 Decimal? mNumeroConnexion,
			 string mLibelleOperation,
			 DateTime? mDateOperation,
			 DateTime? mDateCreationServeur,
			 DateTime? mDateDernModifClient,
			 DateTime? mDateDernModifServeur,
			 Decimal? mNumLigne,
			 Byte[] mRowvers,
			 bool? mSupprimer,
			 string mUserLogin )
		{
			  dtJournalConnexionOperation = adapJournalConnexionOperation.PS_JournalConnexionOperation_SP(
				  mNumeroConnexion,
				  mLibelleOperation,
				  mDateOperation,
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
		/// Retourne la liste des JournalConnexionOperation
		/// </summary>
		/// <returns>Liste JournalConnexionOperation</returns>
		private static List<JournalConnexionOperation> pListe()
		{
			 List<JournalConnexionOperation> mListe = new List<JournalConnexionOperation>();
			 foreach (UserManagerDataSet.TJ_JournalConnexionOperationRow mLigne in 
                 dtJournalConnexionOperation)
			{
				 JournalConnexionOperation oJournalConnexionOperation = new JournalConnexionOperation();
				 oJournalConnexionOperation.NumeroConnexion = mLigne.numeroConnexion;
				 oJournalConnexionOperation.LibelleOperation = mLigne.libelleOperation.Trim();
				 oJournalConnexionOperation.DateOperation = mLigne.dateOperation;
				 oJournalConnexionOperation.DateCreationServeur = mLigne.dateCreationServeur;
				 oJournalConnexionOperation.DateDernModifClient = mLigne.dateDernModifClient;
				 oJournalConnexionOperation.DateDernModifServeur = mLigne.dateDernModifServeur;
				 oJournalConnexionOperation.NumLigne = mLigne.numLigne;
				 oJournalConnexionOperation.Rowvers = mLigne.rowvers;
				 oJournalConnexionOperation.Supprimer = mLigne.supprimer;
				 oJournalConnexionOperation.UserLogin = mLigne.userLogin.Trim();

				 mListe.Add(oJournalConnexionOperation);
			 }
			return mListe;
		 }

		/// <summary>
		/// Permet la mise à jour de JournalConnexionOperation
		/// </summary>
		/// <returns> </returns>
		public string Update()
		{
			 string mSortie = string.Empty; //Variable de récupération de la chaine de retour la méthode
			  adapJournalConnexionOperation.PS_JournalConnexionOperation_UP(
				  numeroConnexion,
				  libelleOperation,
				  dateOperation,
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

