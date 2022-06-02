using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGC.DataAccess.Impressions;
using LGC.DataAccess.Impressions.ImpressionsDataSetTableAdapters;
using LGC.DataAccess.GestionDeLaCaisse.GestionDeLaCaisseDataSetTableAdapters;
using LGC.DataAccess.GestionDeLaCaisse;

namespace LGC.Business.Impressions
{
   public  class Rapport
    {
        #region variables 
        private static FT_RecuTableAdapter adapFT_Recu= new FT_RecuTableAdapter();
        private static ImpressionsDataSet.FT_RecuDataTable dtFT_Recu = new ImpressionsDataSet.FT_RecuDataTable();
        private static FT_FactureAssuranceTableAdapter adapFT_FactureAssurance = new FT_FactureAssuranceTableAdapter();
        private static ImpressionsDataSet.FT_FactureAssuranceDataTable dtFT_FactureAssurance = new ImpressionsDataSet.FT_FactureAssuranceDataTable();


        private static FT_FacturePartenaireTableAdapter adapFT_FacturePartenaire = new FT_FacturePartenaireTableAdapter();
        private static ImpressionsDataSet.FT_FacturePartenaireDataTable dtFT_FacturePartenaire = new ImpressionsDataSet.FT_FacturePartenaireDataTable();

        private static FT_FacturePartenaire_PreVisualiserTableAdapter adapFT_FacturePartenaire_PreVisualiser = new FT_FacturePartenaire_PreVisualiserTableAdapter();
        private static ImpressionsDataSet.FT_FacturePartenaire_PreVisualiserDataTable dtFT_FacturePartenaire_PreVisualiser = new ImpressionsDataSet.FT_FacturePartenaire_PreVisualiserDataTable();

        private static FT_FactureAutrePartenaireTableAdapter adapFT_FactureAutrePartenaire = new FT_FactureAutrePartenaireTableAdapter();
        private static ImpressionsDataSet.FT_FactureAutrePartenaireDataTable dtFT_FactureAutrePartenaire = new ImpressionsDataSet.FT_FactureAutrePartenaireDataTable();
        string mSortie = string.Empty;

        private static PS_FactureClientTableAdapter adapPS_FactureClient = new PS_FactureClientTableAdapter();
        private static ImpressionsDataSet.PS_FactureClientDataTable dtPS_FactureClient = new ImpressionsDataSet.PS_FactureClientDataTable();
        private static QueriesTableAdapter adapFormule = new QueriesTableAdapter();

        private static FT_StatistiquesCaisseTableAdapter adapFT_StatistiquesCaisse = new FT_StatistiquesCaisseTableAdapter();
        private static ImpressionsDataSet.FT_StatistiquesCaisseDataTable dtFT_StatistiquesCaisse= new ImpressionsDataSet.FT_StatistiquesCaisseDataTable();

        private static FT_PointPeriodiqueTableAdapter adapFT_PointPeriodique = new FT_PointPeriodiqueTableAdapter();
        private static ImpressionsDataSet.FT_PointPeriodiqueDataTable dtFT_PointPeriodique = new ImpressionsDataSet.FT_PointPeriodiqueDataTable();

        private static PS_FacturePartenaireSimplifieTableAdapter adapPS_FacturePartenaireSimplifie = new PS_FacturePartenaireSimplifieTableAdapter();
        private static ImpressionsDataSet.PS_FacturePartenaireSimplifieDataTable dtPS_FacturePartenaireSimplifie = new ImpressionsDataSet.PS_FacturePartenaireSimplifieDataTable();

        private static PS_ListePatientsByPartenaireTableAdapter adapPS_ListePatientsByPartenaire = new PS_ListePatientsByPartenaireTableAdapter();
        private static ImpressionsDataSet.PS_ListePatientsByPartenaireDataTable dtPS_ListePatientsByPartenaire = new ImpressionsDataSet.PS_ListePatientsByPartenaireDataTable();


        private static PS_ListeAnalyseParSecteurTableAdapter adapListeAnalyseParSecteur = new PS_ListeAnalyseParSecteurTableAdapter();
        private static ImpressionsDataSet.PS_ListeAnalyseParSecteurDataTable dtListeAnalyseParSecteur = new ImpressionsDataSet.PS_ListeAnalyseParSecteurDataTable();

        private static PS_PointEncaissementTableAdapter adapPS_PointEncaissement = new PS_PointEncaissementTableAdapter();
        private static ImpressionsDataSet.PS_PointEncaissementDataTable dtPS_PointEncaissement = new ImpressionsDataSet.PS_PointEncaissementDataTable();

        private static PS_PointFactureNormaliseeTableAdapter adapPS_PointFactureNormalisee = new PS_PointFactureNormaliseeTableAdapter();
        private static ImpressionsDataSet.PS_PointFactureNormaliseeDataTable dtPS_PointFactureNormalisee = new ImpressionsDataSet.PS_PointFactureNormaliseeDataTable();


        private static PS_PointAnalyseQteMtTableAdapter adapPS_PointAnalyseQteMt = new PS_PointAnalyseQteMtTableAdapter();
        private static ImpressionsDataSet.PS_PointAnalyseQteMtDataTable dtPS_PointAnalyseQteMt = new ImpressionsDataSet.PS_PointAnalyseQteMtDataTable();

        private static FT_EtatRecapPrestationsCentreTableAdapter adapFT_EtatRecapPrestationsCentre = new FT_EtatRecapPrestationsCentreTableAdapter();
        private static ImpressionsDataSet.FT_EtatRecapPrestationsCentreDataTable dtFT_EtatRecapPrestationsCentre  = new ImpressionsDataSet.FT_EtatRecapPrestationsCentreDataTable();
        #endregion



        #region Methodes
        public static System.Data.DataTable Recu(string mIdFacture,decimal mIdReglement)
        {
            return adapFT_Recu.GetData(mIdFacture, mIdReglement);
        }
        public static System.Data.DataTable FactureAssurance(string mIdFactureAssurance)
        {
            return adapFT_FactureAssurance.GetData(mIdFactureAssurance);
        }

        public static System.Data.DataTable FacturePArtenaire(string mIdFacturePartenaire)
        {
            return adapFT_FacturePartenaire.GetData(mIdFacturePartenaire);
        }


        public static System.Data.DataTable FacturePArtenaire_Previsualiser(decimal mIdPersonne, DateTime mDateDebut, DateTime mDateFin)
        {
            adapFT_FacturePartenaire_PreVisualiser.ComTimeout=0;
            return adapFT_FacturePartenaire_PreVisualiser.GetData(mIdPersonne, mDateDebut, mDateFin);
        }
        public static System.Data.DataTable FactureAutrePArtenaire(string mIdFacturePartenaire)
        {
            return adapFT_FactureAutrePartenaire.GetData(mIdFacturePartenaire);
        }

        public static System.Data.DataTable FactureClient(decimal mNumDemande)
        {
            adapPS_FactureClient.ComTimeout = 0;
            return adapPS_FactureClient.GetData(mNumDemande);
        }

        public static decimal SoldeCaisse(DateTime mDate)
        {
            
            return Convert.ToDecimal(adapFormule.FS_SoldeCaisse( mDate));
        }

        public static System.Data.DataTable StatistiquesCaisse(string mTypeOperation,string mPAtient,string mPartenaire,string mAssurance,string mFournisseur,string mAutre,DateTime mDateDebut,DateTime mDateFin)
        {
            return adapFT_StatistiquesCaisse.GetData(mTypeOperation,mPAtient,mPartenaire,mAssurance,mFournisseur,mAutre,mDateDebut,mDateFin);
        }


        public static System.Data.DataTable PointPeriodique(DateTime mDateDebut, DateTime mDateFin,string mTypePoint)
        {
            return adapFT_PointPeriodique.GetData(mDateDebut, mDateFin, mTypePoint);
        }

        public static System.Data.DataTable FacturePartenaireSimplifie( string midFacturePartenaire)
        {
            return adapPS_FacturePartenaireSimplifie.GetData(midFacturePartenaire);
        }

        public static System.Data.DataTable ListePatientsByPartenaire(decimal? midPartenaire, DateTime mDateDebut, DateTime mDateFin)
        {
            return adapPS_ListePatientsByPartenaire.GetData(midPartenaire, mDateDebut, mDateFin);
        }

        public static System.Data.DataTable ListeAnalyseParSecteur(DateTime mDateDebut, DateTime mDateFin)
        {
            return adapListeAnalyseParSecteur.GetData( mDateDebut, mDateFin);
        }

        public static System.Data.DataTable PointEncaissement(DateTime mDateDebut, DateTime mDateFin)
        {
            return adapPS_PointEncaissement.GetData( mDateDebut, mDateFin);
        }

        public static System.Data.DataTable PointFactureNormalisee(DateTime mDateDebut, DateTime mDateFin,bool? mestNormalise)
        {
            return adapPS_PointFactureNormalisee.GetData(mDateDebut, mDateFin, mestNormalise);
        }


        public static System.Data.DataTable PointAnalyseQteMt(decimal? midAssurance, DateTime mDateDebut, DateTime mDateFin)
        {
            return adapPS_PointAnalyseQteMt.GetData(mDateDebut, mDateFin, midAssurance);
        }

        public static System.Data.DataTable EtatRecapPrestationsCentre(DateTime mDateDebut, DateTime mDateFin, string mConditionPartenaire, string mTypePersonne)
        {
            return adapFT_EtatRecapPrestationsCentre.GetData(mDateDebut, mDateFin, mConditionPartenaire, mTypePersonne);
        }


       
        #endregion
    }
}
