using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LGG.DataAccess.GestionUtilisateur.UserManagerDataSetTableAdapters;
using LGG.DataAccess.GestionUtilisateur;
using System.Data;


namespace LGG.Business.GestionUtilisateur
{
    public class Etats
    {

        #region champs
        private string nomUtilisateur;

        private string prenomUtilisateur;

     
        private string libelleDroit;

       
        private bool creation;

       
        private bool modification;

       
        private bool suppression;

        private string intitule;

        private decimal numeroUtilisateur;

      
        #endregion


        #region Propriétés
        public string Intitule
        {
            get { return intitule; }
            set { intitule = value; }
        }
        public string NomUtilisateur
        {
            get { return nomUtilisateur; }
            set { nomUtilisateur = value; }
        }
        public string PrenomUtilisateur
        {
            get { return prenomUtilisateur; }
            set { prenomUtilisateur = value; }
        }
        public string LibelleDroit
        {
            get { return libelleDroit; }
            set { libelleDroit = value; }
        }
        public bool Creation
        {
            get { return creation; }
            set { creation = value; }
        }
        public bool Modification
        {
            get { return modification; }
            set { modification = value; }
        }
        public bool Suppression
        {
            get { return suppression; }
            set { suppression = value; }
        }
        public decimal NumeroUtilisateur
        {
            get { return numeroUtilisateur; }
            set { numeroUtilisateur = value; }
        }
        #endregion

        #region Variables

        private static FT_ListeDesUtilisateursAvecLeursDroitsTableAdapter adapListeUtilParDroits = new FT_ListeDesUtilisateursAvecLeursDroitsTableAdapter();
        private static UserManagerDataSet.FT_ListeDesUtilisateursAvecLeursDroitsDataTable dtListe = new UserManagerDataSet.FT_ListeDesUtilisateursAvecLeursDroitsDataTable();

       
        #endregion Variables



        public static DataTable afficheListeUtilisateurParDroits(decimal? mNumeroUtilisateur)
        {
            return adapListeUtilParDroits.GetData(mNumeroUtilisateur);

        }


        public static List<Etats> Liste(decimal? mNumeroUtilisateur)
        {
            dtListe = adapListeUtilParDroits.GetData(mNumeroUtilisateur);
            List<Etats> mListe = new List<Etats>();
            foreach (UserManagerDataSet.FT_ListeDesUtilisateursAvecLeursDroitsRow mLigne in dtListe)
            {
                Etats oEtats = new Etats();
              
                oEtats.NomUtilisateur = mLigne.nomUtilisateur.Trim();
                oEtats.PrenomUtilisateur = mLigne.prenomUtilisateur.Trim();            
                oEtats.LibelleDroit = mLigne.libelleDroit.Trim();               
                oEtats.Intitule = mLigne.nomUtilisateur.Trim() + " " + mLigne.prenomUtilisateur.Trim();
                oEtats.Creation = mLigne.creation;
                oEtats.Modification = mLigne.modification;
                oEtats.Suppression = mLigne.suppression;
                oEtats.NumeroUtilisateur = mLigne.numeroUtilisateur; 
                mListe.Add(oEtats);
            }
            return mListe;
        }



    }
}
