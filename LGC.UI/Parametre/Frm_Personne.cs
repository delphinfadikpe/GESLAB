using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LGC.Business.Parametre;
using LGC.Business;
using System.IO;
using LGG.UI.Parametre;

namespace LGC.UI.Parametre
{
    public partial class Frm_Personne : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public string libelleTypePersonne,etat;
        string cheminFichier;
        decimal idPersonne;
        int l;
        public bool nouveau = false;
        string sortie;
        string[] message;
        List<PartenairePersonneMorale> lstPartenairePersonneMorale = new List<PartenairePersonneMorale>();
        List<Patient> lstPatient = new List<Patient>();
        List<Assurance> lstAssurance = new List<Assurance>();
        List<Fournisseur> lstFournisseur = new List<Fournisseur>();
        List<Pays> lstPays = new List<Pays>();
        List<Langue> lstLangue = new List<Langue>();
        List<PartenairePersonnePhysique> lstPartenairePersonnePhysique = new List<PartenairePersonnePhysique>();
        List<FormeJuridique> lstFormeJuridique = new List<FormeJuridique>();
        List<SecteurActivite> lstSecteurActivite = new List<SecteurActivite>();
        //List<Categorie> lstCategorie = new List<Categorie>();
        public bool estailleurs = false;
        Patient objPatient = new Patient();
        int numeroLigne = 0, numeroLigneAllie = 0;
        List<AnalysePartenaire> lstAnalysePartenaire = new List<AnalysePartenaire>();
        List<AlliePartenaire> lstAlliePartenaire = new List<AlliePartenaire>();
        List<Partenaires> lstPartenaires = new List<Partenaires>();
        public Partenaires oPartenaires = new Partenaires();
        #endregion

        #region Autres

        

        private void activerDesactiverControle(bool condition)
        {
           
            pv_titres.Enabled = !condition;
            dgv_ListePM.Enabled = !condition;
            dgv_ListePP.Enabled = !condition;
            cb_Civilite.ReadOnly = !condition;
           
            txt_Nom.ReadOnly = !condition;    
            
            dtp_DateNaissance.Enabled = condition;
            ddl_paysPP.ReadOnly = !condition;
           
            txt_lieuNaissance.ReadOnly = !condition;
            cb_SecteurActivite.ReadOnly = !condition;
            cb_Pays.ReadOnly = !condition;
            chk_EstActifPersonne.Enabled = condition;
            txt_adressePP.ReadOnly = !condition;

            meb_tauxRistounePM.ReadOnly = !condition;
            meb_tauxRistounePP.ReadOnly = !condition;
           
            txt_Mobile1.ReadOnly = !condition;
            txt_Mobile2.ReadOnly = !condition;
            meb_mobile1PP.ReadOnly = !condition;
            meb_mobile2PP.ReadOnly = !condition;
            txt_Email.ReadOnly = !condition;
            cb_FormeJuridique.ReadOnly = !condition;
            cb_SecteurActivite.ReadOnly = !condition;
            txt_mailPP.ReadOnly = !condition;
           
            txt_Adresse.ReadOnly = !condition;
            txt_lieuNaissance.ReadOnly = !condition;
            txt_numPiece.ReadOnly = !condition; 
            
            
            pv_titres.Enabled = !condition;
            dgv_ListePM.Enabled = !condition;
            dgv_ListePP.Enabled = !condition;        
            txt_NumAgrement.ReadOnly=!condition;              
            txt_Raison_Sociale.ReadOnly=!condition;
            txt_Capital.ReadOnly = !condition;
            
            cb_Pays.ReadOnly = !condition;
            cb_FormeJuridique.ReadOnly = !condition;
            cb_SecteurActivite.ReadOnly = !condition;
            chk_estVarPP.ReadOnly = !condition;
            chk_varPM.ReadOnly = !condition;
            txt_Num.ReadOnly = !condition;          
            chk_EstActifPersonne.ReadOnly=!condition;                      
            btn_Annuler.Visible = condition;
            btn_Enregistrer.Visible = condition;
            btn_Nouveau.Visible = !condition;
            btn_Modifier.Visible = !condition;
            btn_Supprimer.Enabled = !condition;
            btn_AddPhoto.Enabled = condition;
            btn_supPhoto.Enabled = condition;
            btn_ImporterEntetePM.Enabled = condition;
            btn_ImporterEntetePP.Enabled = condition;
            btn_SupprimerEntetePM.Enabled = condition;
            btn_SupprimerEntetePP.Enabled = condition;
           
            txt_Mobile1.ReadOnly = !condition;
            txt_Mobile2.ReadOnly = !condition;
            txt_Email.ReadOnly = !condition;
            
            txt_Adresse.ReadOnly = !condition;



            gv_ListeAnalysePartenaire.Enabled = !condition;

            btn_NouveauCB.Enabled = !condition;
            btn_ModifierCB.Enabled = !condition;
            btn_SupprimerCB.Enabled = !condition;

            btn_ChoixPartenairePM.Enabled = condition;
            btn_ChoixPartenairePP.Enabled = condition;
            txt_PartenaireSourcePM.ReadOnly = !condition;
            txt_PartenaireSourcePP.ReadOnly = !condition;
            cb_ConditionPartenairePH.ReadOnly = !condition;
            cb_ConditionPartenairePM.ReadOnly = !condition;
        }

        private void RAZ()
        {
            cb_Civilite.Text = "";
            txt_Nom.Text = "";
            txt_Prenom.Text = "";
            ddl_paysPP.Text = "";
            txt_lieuNaissance.Text = "";
            chk_EstActifPersonne.Checked = true;
            chk_estVarPP.Checked = false;
            chk_varPM.Checked = false;
            cb_SecteurActivite.Text = "";
            chk_EstActifPersonne.Checked = false;
            dtp_DateNaissance.Value = DateTime.Now;
            txt_mailPP.Text = "";
            txt_adressePP.Text = "";
            meb_mobile1PP.Value = 0;
            meb_mobile2PP.Value = 0;
            txt_Email.Text = "";
            txt_Adresse.Text = "";
            txt_numPiece.Text = "";
            meb_tauxRistounePP.Value = 0;
            //txt_DateCreationPM.Value = DateTime.Now; 
            txt_NumAgrement.Text = "";
            txt_Num.Text = txt_numPP.Text = nouveau == true ? "EN CREATION" : ""; 
            txt_Sigle.Text = "";
            txt_Raison_Sociale.Text = "";         
            cb_FormeJuridique.Text="";            
            cb_SecteurActivite.Text="";   
            chk_EstActifPersonne.Checked=false;
            cb_Pays.Text = "";
            txt_Mobile1.Text = "";
            txt_Mobile2.Text = "";
            txt_Email.Text = "";
            txt_Adresse.Text = "";
            meb_tauxRistounePM.Value = 0;
            meb_tauxRistounePP.Value = 0;
            pnl_photo.Text = "";
            pnl_photo.BackgroundImage = null;
            pnl_EntetePM.Text = "";
            pnl_EntetePM.BackgroundImage = null;
            pnl_EntetePP.Text = "";
            pnl_EntetePP.BackgroundImage = null;
            cheminFichier = "";
            txt_Nom.Focus();
        }
        private void ControleAffichage(FormulaireType FormulaireType)
        {
            switch (FormulaireType)
            {
                case FormulaireType.Fournisseur:
                    {
                        gb_Liste.Text = "LISTE DES FOURNISSEURS";
                        dgv_ListePM.Visible = true;
                        dgv_ListePP.Visible = false;
                        dgv_ListePM.BringToFront();

                        ChargerListeFournisseur(null);

                        pv_PM.Show();
                        pv_PP.Hide();

                        pv_PP.Enabled = false;
                        pv_PM.Enabled = true;

                        pv_PM.Text = "DETAILS FOURNISSEUR";
                        pv_PP.Text = "";
                        gb_autreInfoPM.Visible = false;
                        chk_RistournePP.Visible = false;

                        break;
                    }
                case FormulaireType.Assurance:
                    gb_Liste.Text = "LISTE DES ASSURANCES";
                        dgv_ListePM.Visible = true;
                        dgv_ListePP.Visible = false;
                        dgv_ListePM.BringToFront();

                        ChargerListeAssurance(null);

                        pv_PM.Show();
                        pv_PP.Hide();
                        pv_PP.Enabled = false;
                        pv_PM.Enabled = true;

                        pv_PM.Text = "DETAILS ASSURANCE";
                        pv_PP.Text = "";
                        gb_autreInfoPM.Visible = false;
                        chk_RistournePP.Visible = false;
                    break;
                case FormulaireType.Patient:
                    gb_Liste.Text = "LISTE DES PATIENTS";
                        dgv_ListePP.Visible = true;
                        dgv_ListePM.Visible = false;
                        dgv_ListePP.BringToFront();

                        ChargerListePatient(null);

                        pv_PP.Show();
                        pv_PM.Hide();
                        pv_PP.Enabled = true;
                        pv_PM.Enabled = false;

                        pv_PP.Text = "DETAILS PATIENTS";
                        pv_PM.Text = "";
                        gb_autreInfoPP.Visible = false;
                        chk_RistournePP.Visible = false;
                    break;
                case FormulaireType.PartenairePP:
                     gb_Liste.Text = "LISTE DES PARTENAIRES PERSONNE PHYSIQUE";
                        dgv_ListePP.Visible = true;
                        dgv_ListePM.Visible = false;
                        dgv_ListePP.BringToFront();
                       
                        ChargerListePartenairePP(null);

                        pv_PP.Show();
                       
                        pv_PM.Hide();
                        pv_PP.Enabled = true;
                        pv_PM.Enabled = false;

                        pv_PP.Text = "DETAILS PARTENAIRE";
                        pv_PM.Text = "";
                        gb_autreInfoPP.Visible = true;

                      chk_RistournePP.Visible = true;
                        chk_RistournePP.Checked = false;
                        
                    break;
                case FormulaireType.PartenairePM:
                    gb_Liste.Text = "LISTE DES PARTENAIRES PERSONNE MORALE";
                        dgv_ListePM.Visible = true;
                        dgv_ListePP.Visible = false;
                        dgv_ListePM.BringToFront();
                       
                        ChargerListePartenairePM(null);

                        pv_PM.Show();
                        pv_PP.Hide();

                        pv_PP.Enabled = false;
                        pv_PM.Enabled = true;

                        pv_PM.Text = "DETAILS PARTENAIRE";
                        gb_autreInfoPM.Visible = true;
                        pv_PP.Text = "";
                         chk_RistournePM.Visible = true;
                         chk_RistournePM.Checked = false;
                    break;
                default:
                    this.Close();
                    break;
            }
        }


        private void constituerObjet(FormulaireType FormulaireType, Fournisseur objFournisseur, Assurance objAssurance
            , PartenairePersonneMorale objPartPM, PartenairePersonnePhysique objPartPP,Patient objPatient)
        {
            switch (FormulaireType)
            {
                case FormulaireType.Fournisseur:
                    {
                        constituerObjetFournisseur(objFournisseur);
                         break;
                    }
                case FormulaireType.Assurance:
                    constituerObjetAssurance(objAssurance);
                    break;
                case FormulaireType.Patient:
                    constituerObjetPatient(objPatient);
                    break;
                case FormulaireType.PartenairePP:
                    constituerObjetPartenairePersonnePhysique(objPartPP);
                    break;
                case FormulaireType.PartenairePM:
                    constituerObjetPartenairePersonneMorale(objPartPM);
                    break;
                default:
                    btn_Annuler_Click(null,null);
                    break;
            }
        }
        private void constituerObjetFournisseur(Fournisseur obj)
        {
            obj.NumeroAgrementPersonneMorale = txt_NumAgrement.Text;
            obj.SiglePersonneMorale = txt_Sigle.Text;
            obj.RaisonSociale = txt_Raison_Sociale.Text;
            obj.EstActifPersonne = chk_EstActifPersonne.Checked;
            obj.CodePays = lstPays.Find(l => l.NomPays.Trim() ==
                cb_Pays.Text.Trim()).CodePays.Trim();
            obj.EstActif = chk_EstActifPersonne.Checked;
            obj.LibelleTypePersonne = "FOURNISSEUR";
            obj.TelephoneMobile1 = txt_Mobile1.Text;
            obj.TelephoneMobile2 = txt_Mobile2.Text;
            obj.Email = txt_Email.Text;
            obj.AdresseComplete = txt_Adresse.Text;
            obj.CodeLangue = CurrentUser.CurrentLangue;
            
        }

        private void constituerObjetAssurance(Assurance obj)
        {
            obj.NumeroAgrementPersonneMorale = txt_NumAgrement.Text;
            obj.SiglePersonneMorale = txt_Sigle.Text;
            obj.RaisonSociale = txt_Raison_Sociale.Text;
            obj.CodeFormeJuridique = lstFormeJuridique.Find(l => l.LibelleFormeJuridique.Trim() ==
                cb_FormeJuridique.Text.Trim()).CodeFormeJuridique.Trim();
            obj.EstActifPersonne = chk_EstActifPersonne.Checked;
            obj.CodePays = lstPays.Find(l => l.NomPays.Trim() ==
                cb_Pays.Text.Trim()).CodePays.Trim();
            obj.EstActif = chk_EstActifPersonne.Checked;
            obj.LibelleTypePersonne = "ASSURANCE";
            obj.TelephoneMobile1 = txt_Mobile1.Text;
            obj.TelephoneMobile2 = txt_Mobile2.Text;
            obj.Email = txt_Email.Text;
            obj.AdresseComplete = txt_Adresse.Text;
            obj.CodeLangue = CurrentUser.CurrentLangue;
            obj.LibelleSecteurActivite = cb_SecteurActivite.Text.Trim();
          

        }

        private void constituerObjetPatient(Patient obj)
        {
            //obj.IdPersonne = 1;//rds_IdPersonne.Value.ToString();
            obj.Civilte = cb_Civilite.Text;
            obj.Sexe = "";
            obj.NomPersonnePhysique = txt_Nom.Text;
            obj.PrenomPersonnePhysique = txt_Prenom.Text.Trim();
            obj.DateNaissance = dtp_DateNaissance.Value;
            obj.CodePays = lstPays.Find(l => l.NomPays.Trim() ==
                ddl_paysPP.Text.Trim()).CodePays.Trim();
            obj.LieuNaissance = txt_lieuNaissance.Text;
            obj.EstActifPersonne = chk_EstActifPersonne.Checked;
            obj.PhotoPersonnePhysique = "";
             obj.LibelleTypePersonne = "PATIENT";           
            obj.TelephoneMobile1 = meb_mobile1PP.Text;
            obj.TelephoneMobile2 = meb_mobile2PP.Text;
            obj.Email = txt_mailPP.Text;
            obj.AdresseComplete = txt_adressePP.Text;
            obj.codeLangue = CurrentUser.CurrentLangue;
            
        }

        private void constituerObjetPartenairePersonnePhysique(PartenairePersonnePhysique obj)
        {
            //obj.IdPersonne = 1;//rds_IdPersonne.Value.ToString();
            obj.Civilte = cb_Civilite.Text.Trim();
            obj.Sexe = "";
            obj.NomPersonnePhysique = txt_Nom.Text;
            obj.PrenomPersonnePhysique = txt_Prenom.Text.Trim();
            obj.DateNaissance = dtp_DateNaissance.Value;
            obj.CodePays = lstPays.Find(l => l.NomPays.Trim() ==
                ddl_paysPP.Text.Trim()).CodePays.Trim();
            obj.EstTauxVariable = chk_estVarPP.Checked;
            obj.LieuNaissance = txt_lieuNaissance.Text.Trim();
            obj.EstActifPersonne = chk_EstActifPersonne.Checked;
            obj.PhotoPersonnePhysique = "";
            obj.LibelleTypePersonne = "PARTENAIRE";
            obj.TelephoneMobile1 = meb_mobile1PP.Text.Trim();
            obj.TelephoneMobile2 = meb_mobile2PP.Text.Trim();
            obj.Email = txt_mailPP.Text.Trim();
            obj.AdresseComplete = txt_adressePP.Text.Trim();
            obj.NumPiece = txt_numPiece.Text.Trim();
            obj.TypePartenaire = "PP";
            obj.TauxRistourne = Convert.ToDecimal(meb_tauxRistounePP.Text);
            obj.codeLangue = CurrentUser.CurrentLangue;
            obj.Logo = pnl_EntetePP.BackgroundImage != null ? CurrentUser.ImagePath : "";
            obj.ARistourneFinPeriode = chk_RistournePP.Checked;
            obj.IdPersonnePrincipal = txt_PartenaireSourcePP.Text != string.Empty ? (oPartenaires != null ? oPartenaires.IdPersonne : 0) : 0;
            obj.ConditionPartenaire = cb_ConditionPartenairePH.Text.Trim();
            obj.MontantImpaye = 0;
        }

        private void constituerObjetPartenairePersonneMorale(PartenairePersonneMorale obj)
        {
            obj.NumeroAgrementPersonneMorale = txt_NumAgrement.Text;
            obj.SiglePersonneMorale = txt_Sigle.Text;
            obj.RaisonSociale = txt_Raison_Sociale.Text;
            obj.CodeFormeJuridique = lstFormeJuridique.Find(l => l.LibelleFormeJuridique.Trim() ==
                cb_FormeJuridique.Text.Trim()).CodeFormeJuridique.Trim();
            obj.EstActifPersonne = chk_EstActifPersonne.Checked;
            obj.EstTauxVariable = chk_varPM.Checked;
            obj.CodePays = lstPays.Find(l => l.NomPays.Trim() ==
                cb_Pays.Text.Trim()).CodePays.Trim();
            obj.EstActif = chk_EstActifPersonne.Checked;
            obj.EstTauxVariable = chk_estVarPP.Checked;
            obj.LibelleTypePersonne = "PARTENAIRE";
            obj.TelephoneMobile1 = txt_Mobile1.Text;
            obj.TelephoneMobile2 = txt_Mobile2.Text;
            obj.Email = txt_Email.Text;
            obj.AdresseComplete = txt_Adresse.Text;
            obj.CodeLangue = CurrentUser.CurrentLangue;
            obj.LibelleSecteurActivite = cb_SecteurActivite.Text.Trim();
            obj.CapitalSocial = Convert.ToDecimal(txt_Capital.Text.Trim());
            obj.TauxRistourne = Convert.ToDecimal(meb_tauxRistounePM.Text.Trim());
            obj.TypePartenaire = "PM";
            obj.codeLangue = CurrentUser.CurrentLangue;
            obj.Logo = pnl_EntetePM.BackgroundImage != null ? CurrentUser.ImagePath : "";
            obj.ARistourneFinPeriode = chk_RistournePM.Checked;
            obj.IdPersonnePrincipal =txt_PartenaireSourcePM.Text!=string.Empty?(oPartenaires!=null? oPartenaires.IdPersonne:0):0;
            obj.ConditionPartenaire = cb_ConditionPartenairePM.Text.Trim();
            obj.MontantImpaye = 0;
        }
        private void detaillerObjetFournisseur(Fournisseur obj)
        {
            txt_NumAgrement.Text = obj.NumeroAgrementPersonneMorale.Trim();
            txt_Num.Text =Convert.ToString(obj.IdPersonne);
            txt_Raison_Sociale.Text = obj.RaisonSociale.Trim();
            txt_Sigle.Text = obj.SiglePersonneMorale.Trim();
            chk_EstActifPersonne.Checked = Convert.ToBoolean(obj.EstActifPersonne.ToString());
            Pays obj1 = lstPays.Find(l => l.CodePays.Trim() ==
                 obj.CodePays.Trim());
            if (obj1 != null)
            {
                ddl_paysPP.Text = lstPays.Find(l => l.CodePays.Trim() ==
                obj.CodePays.Trim()).NomPays.Trim();
            }    
            txt_Mobile1.Text = obj.TelephoneMobile1;
            txt_Mobile2.Text = obj.TelephoneMobile2;
            txt_Email.Text = obj.Email;
            txt_Adresse.Text = obj.AdresseComplete;

           
        }

        private void detaillerObjetAssurance(Assurance obj)
        {
            txt_NumAgrement.Text = obj.NumeroAgrementPersonneMorale.Trim();
            txt_Num.Text = Convert.ToString(obj.IdPersonne);
            txt_Raison_Sociale.Text = obj.RaisonSociale.Trim();
            txt_Sigle.Text = obj.SiglePersonneMorale.Trim();
            chk_EstActifPersonne.Checked = Convert.ToBoolean(obj.EstActifPersonne.ToString());
            Pays obj1 = lstPays.Find(l => l.CodePays.Trim() ==
                obj.CodePays.Trim());
            if (obj1 != null)
            {
                cb_Pays.Text = lstPays.Find(l => l.CodePays.Trim() ==
                obj.CodePays.Trim()).NomPays.Trim();
            }
            txt_Mobile1.Text = obj.TelephoneMobile1;
            txt_Mobile2.Text = obj.TelephoneMobile2;
            txt_Email.Text = obj.Email;
            txt_Adresse.Text = obj.AdresseComplete;
            FormeJuridique obj2 = lstFormeJuridique.Find(l => l.CodeFormeJuridique.Trim() ==
                 obj.CodeFormeJuridique.Trim());
            if (obj2 != null)
            {
                cb_FormeJuridique.Text = lstFormeJuridique.Find(l => l.CodeFormeJuridique.Trim() ==
                obj.CodeFormeJuridique.Trim()).LibelleFormeJuridique;
            }
            
            cb_SecteurActivite.Text = obj.LibelleSecteurActivite;

        }

        private void detaillerObjetPartenairePersonneMorale(PartenairePersonneMorale obj)
        {
            idPersonne = obj.IdPersonne;
            txt_NumAgrement.Text = obj.NumeroAgrementPersonneMorale.Trim();
            txt_Num.Text = Convert.ToString(obj.IdPersonne);
            txt_Raison_Sociale.Text = obj.RaisonSociale.Trim();
            txt_Sigle.Text = obj.SiglePersonneMorale.Trim();
            chk_EstActifPersonne.Checked = Convert.ToBoolean(obj.EstActifPersonne.ToString());
            Pays obj1 = lstPays.Find(l => l.CodePays.Trim() ==
                obj.CodePays.Trim());
            if (obj1 != null)
            {
                cb_Pays.Text = lstPays.Find(l => l.CodePays.Trim() ==
                obj.CodePays.Trim()).NomPays.Trim();
            }

            chk_varPM.Checked = Convert.ToBoolean(obj.EstTauxVariable);
            txt_Mobile1.Text = obj.TelephoneMobile1;
            txt_Mobile2.Text = obj.TelephoneMobile2;
            txt_Email.Text = obj.Email;
            txt_Adresse.Text = obj.AdresseComplete;
            meb_tauxRistounePM.Value = obj.TauxRistourne;
            txt_Capital.Text = Convert.ToString(obj.CapitalSocial);
            FormeJuridique obj2 = lstFormeJuridique.Find(l => l.CodeFormeJuridique.Trim() ==
                obj.CodeFormeJuridique.Trim());
            if (obj2 != null)
            {
                cb_FormeJuridique.Text = lstFormeJuridique.Find(l => l.CodeFormeJuridique.Trim() ==
                obj.CodeFormeJuridique.Trim()).LibelleFormeJuridique;
            }
            
            cb_SecteurActivite.Text = obj.LibelleSecteurActivite;
            if (!nouveau)
            {
                cheminFichier =obj.Logo.Trim();
                //permet d'afficher la photo
                if (File.Exists(cheminFichier))
                {
                    pnl_EntetePM.BackgroundImage = Image.FromFile(cheminFichier.Trim());
                }
                else if(btn_SupprimerEntetePM.Enabled == false)
                {
                    pnl_EntetePM.BackgroundImage = null;
                }
            }

            chk_RistournePM.Checked = obj.ARistourneFinPeriode;


            gv_ListeAnalysePartenaire.Rows.Clear();
            lstAnalysePartenaire = AnalysePartenaire.Liste(obj.IdPersonne, null, null, null, null, null, null, false, null,null);
            for (int i = 0; i < lstAnalysePartenaire.Count; i++)
            {
                gv_ListeAnalysePartenaire.Rows.Add(lstAnalysePartenaire[i].CodeAnalyse, lstAnalysePartenaire[i].PrixNormal,lstAnalysePartenaire[i].Taux, lstAnalysePartenaire[i].NumLigne);
                numeroLigne = gv_ListeAnalysePartenaire.SelectedRows[0].Index;
            }


            //gv_ListeAllies.Rows.Clear();
            //lstAlliePartenaire = AlliePartenaire.Liste(obj.IdPersonne, null, null, null, null, null, null,null, false, null);
            //for (int i = 0; i < lstAlliePartenaire.Count; i++)
            //{
            //    gv_ListeAllies.Rows.Add(lstAlliePartenaire[i].LibellePersonne, lstAlliePartenaire[i].TauxRistourne, lstAlliePartenaire[i].NumLigne);
            //    numeroLigneAllie = gv_ListeAllies.SelectedRows[0].Index;
            //}

            txt_PartenaireSourcePM.Text = obj.Intitule;
           

            if(obj.IdPersonnePrincipal!=0)
            {
                oPartenaires = lstPartenaires.Find(x => x.IdPersonne == obj.IdPersonnePrincipal);
            }

            cb_ConditionPartenairePM.Text = obj.ConditionPartenaire;
        }

        private void detaillerObjetPatient(Patient obj)
        {
            //txt_IdPersonne.Text=obj.IdPersonne.Trim() ;
            txt_numPP.Text = Convert.ToString(obj.IdPersonne);
            cb_Civilite.Text = obj.Civilte.Trim();
            txt_numPP.Text = Convert.ToString(obj.IdPersonne);
            txt_Nom.Text = obj.NomPersonnePhysique.Trim();
            txt_Prenom.Text = obj.PrenomPersonnePhysique.Trim();
            dtp_DateNaissance.Value = obj.DateNaissance;
            Pays obj1 = lstPays.Find(l => l.CodePays.Trim() ==
                 obj.CodePays.Trim());
            if (obj1 != null)
            {
                ddl_paysPP.Text = lstPays.Find(l => l.CodePays.Trim() ==
                obj.CodePays.Trim()).NomPays.Trim();
            }
            txt_lieuNaissance.Text = obj.LieuNaissance.Trim();
            chk_EstActifPersonne.Checked = Convert.ToBoolean(obj.EstActifPersonne.ToString());            
            meb_mobile1PP.Text = obj.TelephoneMobile1;
            meb_mobile2PP.Text = obj.TelephoneMobile2;
            txt_mailPP.Text = obj.Email;
            txt_adressePP.Text = obj.AdresseComplete;


            if (!nouveau)
            {
                cheminFichier = CurrentUser.ImagePath + "\\" +
               obj.LibelleTypePersonne.Trim() +
               Convert.ToString(obj.IdPersonne) + ".jpg";
                //permet d'afficher la photo
                if (File.Exists(cheminFichier))
                {
                    pnl_photo.BackgroundImage = Image.FromFile(cheminFichier.Trim());
                }
                else
                {
                    pnl_photo.BackgroundImage = null;
                }
            }
        }

        private void detaillerObjetPartenairePersonnePhysique(PartenairePersonnePhysique obj)
        {
            idPersonne = obj.IdPersonne;
            //txt_IdPersonne.Text=obj.IdPersonne.Trim() ;
            cb_Civilite.Text = obj.Civilte.Trim();
            txt_numPP.Text = Convert.ToString(obj.IdPersonne);
            txt_Nom.Text = obj.NomPersonnePhysique.Trim();
            txt_Prenom.Text = obj.PrenomPersonnePhysique.Trim();
            dtp_DateNaissance.Value = obj.DateNaissance;
            Pays obj1 = lstPays.Find(l => l.CodePays.Trim() ==
                obj.CodePays.Trim());
            if (obj1 != null)
            {
                ddl_paysPP.Text = lstPays.Find(l => l.CodePays.Trim() ==
                obj.CodePays.Trim()).NomPays.Trim();
            }
            
            txt_lieuNaissance.Text = obj.LieuNaissance.Trim();
            chk_EstActifPersonne.Checked = Convert.ToBoolean(obj.EstActifPersonne.ToString());
            chk_estVarPP.Checked = Convert.ToBoolean(obj.EstTauxVariable.ToString());
            meb_mobile1PP.Text = obj.TelephoneMobile1;
            meb_mobile2PP.Text = obj.TelephoneMobile2;
            txt_mailPP.Text = obj.Email;
            txt_adressePP.Text = obj.AdresseComplete;
            txt_numPiece.Text = obj.NumPiece;
            meb_tauxRistounePP.Value = obj.TauxRistourne;
            if(!nouveau)
            {
                cheminFichier = CurrentUser.ImagePath + "\\" +
               obj.LibelleTypePersonne.Trim() + " PP" +
               Convert.ToString(obj.IdPersonne) + ".jpg";
                //permet d'afficher la photo
                if (File.Exists(cheminFichier))
                {
                    pnl_photo.BackgroundImage = Image.FromFile(cheminFichier.Trim());
                }
                else
                {
                    pnl_photo.BackgroundImage = null;
                }

                cheminFichier = obj.Logo;
                //permet d'afficher la photo
                if (File.Exists(cheminFichier))
                {
                    pnl_EntetePP.BackgroundImage = Image.FromFile(cheminFichier.Trim());
                }
                else if (btn_SupprimerEntetePP.Enabled == false)
                {
                    pnl_EntetePP.BackgroundImage = null;
                }
            }
            chk_RistournePP.Checked = obj.ARistourneFinPeriode;
            gv_ListeAnalysePartenaire.Rows.Clear();
            lstAnalysePartenaire = AnalysePartenaire.Liste(obj.IdPersonne, null, null, null, null, null, null, false, null, null);
            for (int i = 0; i < lstAnalysePartenaire.Count; i++)
            {
                gv_ListeAnalysePartenaire.Rows.Add(lstAnalysePartenaire[i].CodeAnalyse, lstAnalysePartenaire[i].PrixNormal, lstAnalysePartenaire[i].Taux, lstAnalysePartenaire[i].NumLigne);
                numeroLigne = gv_ListeAnalysePartenaire.SelectedRows[0].Index;
            }

            //gv_ListeAllies.Rows.Clear();
            //lstAlliePartenaire = AlliePartenaire.Liste(obj.IdPersonne, null, null, null, null, null, null, null, false, null);
            //for (int i = 0; i < lstAlliePartenaire.Count; i++)
            //{
            //    gv_ListeAllies.Rows.Add(lstAlliePartenaire[i].LibellePersonne, lstAlliePartenaire[i].TauxRistourne, lstAlliePartenaire[i].NumLigne);
            //    numeroLigneAllie = gv_ListeAllies.SelectedRows[0].Index;
            //}

            txt_PartenaireSourcePP.Text = obj.Intitule;
           

            if (obj.IdPersonnePrincipal != 0)
            {
                oPartenaires = lstPartenaires.Find(x => x.IdPersonne == obj.IdPersonnePrincipal);
            }

            cb_ConditionPartenairePH.Text = obj.ConditionPartenaire;
        }
       

        private void ChargerListePays()
        {
            lstPays = Pays.Liste(null, null, null, null,
                null, null, null, false, null);
            bds_Pays.DataSource = lstPays;
        }

        private void ChargerListeFournisseur(Fournisseur obj)
        {
            lstFournisseur = Fournisseur.Liste(null, null, null, null,
                null, null, null, null, null, null,
                null,null,null,null,null,null,null,null, false, null);
            bds_fournisseur.DataSource = lstFournisseur;
            dgv_ListePM.DataSource = bds_fournisseur;

            if (obj != null)
            {
                int i = 0;
                foreach (Fournisseur ligne in bds_fournisseur.List as List<Fournisseur>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_fournisseur.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        private void ChargerListeAssurance(Assurance obj)
        {
            lstAssurance = Assurance.Liste(null, null, null, null, null, null,
                null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, false, null);
            bds_Assurance.DataSource = lstAssurance;
            dgv_ListePM.DataSource = bds_Assurance;

            if (obj != null)
            {
                int i = 0;
                foreach (Assurance ligne in bds_Assurance.List as List<Assurance>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_Assurance.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        private void ChargerListePatient(Patient obj)
        {
            lstPatient = Patient.Liste(null, null, null, null,
                null, null, null, null, null, null,
                null, null, null, null, null, null, null, null,null,null,null,null, false, null);
            bds_patient.DataSource = lstPatient;
            dgv_ListePP.DataSource = bds_patient;

            if (obj != null)
            {
                int i = 0;
                foreach (Patient ligne in bds_patient.List as List<Patient>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_patient.Position = i;
                        objPatient = ligne;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        private void ChargerListePartenairePP(PartenairePersonnePhysique obj)
        {
            lstPartenairePersonnePhysique = PartenairePersonnePhysique.Liste(null, null, null, null, null,
                null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null,null,null,null, false, null);
            bds_PartenairePersonnePhysique.DataSource = lstPartenairePersonnePhysique;
            dgv_ListePP.DataSource = bds_PartenairePersonnePhysique;

            if (obj != null)
            {
                int i = 0;
                foreach (PartenairePersonnePhysique ligne in bds_PartenairePersonnePhysique.List as List<PartenairePersonnePhysique>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_PartenairePersonnePhysique.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        private void ChargerListePartenairePM(PartenairePersonneMorale obj)
        {
            lstPartenairePersonneMorale = PartenairePersonneMorale.Liste(null, null,null, null, null, null, null,
                null, null, null, null, null, null,
                null, null, null, null, null, null, null,null,null,null,null, false, null);
            bds_PartenairePersonneMorale.DataSource = lstPartenairePersonneMorale;
            dgv_ListePM.DataSource = bds_PartenairePersonneMorale;

            if (obj != null)
            {
                int i = 0;
                foreach (PartenairePersonneMorale ligne in bds_PartenairePersonneMorale.List as List<PartenairePersonneMorale>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_PartenairePersonneMorale.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        private void ChargerListeFormeJuridique()
        {
            lstFormeJuridique = FormeJuridique.Liste(null,null,null, null, null, null,
                null,false,null);
            bds_FormJuridique.DataSource = lstFormeJuridique;
        }        

        private void ChargerListeSecteurActivite()
        {
            lstSecteurActivite = SecteurActivite.Liste(null, null, null, null, null, null, false, null);
            bds_Secteur.DataSource = lstSecteurActivite;
        }

        private void activerDesactiverControleCB(bool condition)
        {
            gv_ListeAnalysePartenaire.ReadOnly = !condition;

            btn_AnnulerCB.Visible = condition;
            btn_EnregistrerCB.Visible = condition;
            btn_NouveauCB.Visible = !condition;
            btn_ModifierCB.Visible = !condition;
            btn_SupprimerCB.Enabled = !condition;
            //interdit l'ajout de frais lors de l'enregistrement d'un compte bancaire
            btn_Supprimer.Enabled = !condition;
            btn_Nouveau.Enabled = !condition;
            btn_Modifier.Enabled = !condition;
        }

       
        #endregion
        
        #region Formulaire
        public Frm_Personne()
        {
            
            InitializeComponent();
            ChargerListeFormeJuridique();
            ChargerListePays();
        }

       

        private void Frm_SocieteDeGestion_Load(object sender, EventArgs e)
        {
            lstPartenaires = Partenaires.ListePartenairesAll();

            activerDesactiverControle(false);
            ChargerListeSecteurActivite();
            bds_Analyse.DataSource = Analyse.Liste(null, null, null, null,
                 null, null, null, null, null, null, null, null, false, null);
            pv_titres_SelectedPageChanged(null, null);
            if (nouveau)
                btn_Nouveau_Click(null, null);
            
        }
        #endregion

        #region bouton de commande
        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = true;
            activerDesactiverControle(true);
            RAZ();
            
            if (libelleTypePersonne == "FOURNISSEUR")
            {
                cb_FormeJuridique.ReadOnly = true;

                cb_SecteurActivite.ReadOnly = true;
            }
        }

        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (libelleTypePersonne == "FOURNISSEUR" 
                || libelleTypePersonne == "ASSURANCE" || libelleTypePersonne=="PARTENAIRE PM")
            {
                if (dgv_ListePM.SelectedRows != null &&
                dgv_ListePM.SelectedRows.Count > 0)
                {
                    nouveau = false;
                    activerDesactiverControle(true);
                    if (libelleTypePersonne == "FOURNISSEUR")
                    {
                        cb_FormeJuridique.ReadOnly = true;

                        cb_SecteurActivite.ReadOnly = true;
                    }
                }
                else
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Veuillez selectioner une ligne " +
                        "avant d'entamer la modification.", CurrentUser.LogicielHote, MessageBoxButtons.OK,
                        RadMessageIcon.Error);
                }
            }
            else
            {
                if (dgv_ListePP.SelectedRows != null &&
                dgv_ListePP.SelectedRows.Count > 0)
                {
                    nouveau = false;
                    activerDesactiverControle(true);
                    
                }
                else
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Veuillez selectioner une ligne " +
                        "avant d'entamer la modification.", CurrentUser.LogicielHote, MessageBoxButtons.OK,
                        RadMessageIcon.Error);
                }
            }
            
        }

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            if (dgv_ListePM.SelectedRows != null &&
                dgv_ListePM.SelectedRows.Count > 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne " +
                    "sélectionnée", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                    RadMessageIcon.Question) == DialogResult.Yes)
                {
                    //PersonneMorale obj = (PersonneMorale)bds_personneMorale.Current;
                    //string res = obj.Delete();
                    //message =LGC.Business.Tools.SplitMessage(res);
                    if (int.Parse(message[0]) > 0)
                    {
                        //ChargerListe((PersonneMorale)bds_personneMorale.Current);
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    else
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        MessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner la ligne à supprimer.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }

        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            RAZ();
            activerDesactiverControle(false);
            dgv_ListePP_SelectionChanged(null, null);
            dgv_ListePM_SelectionChanged(null, null);
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            Fournisseur objFournisseur = new Fournisseur();
            Assurance objAssurance = new Assurance();
            PartenairePersonneMorale objPartenairePersonneMorale = new PartenairePersonneMorale();
            PartenairePersonnePhysique objPartenairePersonnePhysique = new PartenairePersonnePhysique();
            
            
            #region controle de saisie

            //if (lstPersonneMorale.Find(x => x.NumCompteSgi.Trim() == txt_NumCompteSgi.Text.Trim()) != null &&
            //        nouveau==true)
            //{
            //    RadMessageBox.ThemeName = this.ThemeName;
            //    RadMessageBox.Show(this, "Ce numéro de compte dépositaire existe déja.",
            //        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            //    txt_NumCompteSgi.Focus();
            //    return;

            //}
          
            if (txt_NumAgrement.Text.Trim() == "" && (libelleTypePersonne == "FOURNISSEUR" 
                || libelleTypePersonne == "ASSURANCE" || libelleTypePersonne=="PARTENAIRE PM"))
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du numéro d'agrément est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_NumAgrement.Focus();
                return;
            }

            if (cb_FormeJuridique.Text.Trim() == "" && (libelleTypePersonne == "ASSURANCE" 
                || libelleTypePersonne == "PARTENAIRE PM"))
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez choisir la forme juridique.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                cb_FormeJuridique.Focus();
                return;
            }

            if (cb_SecteurActivite.Text.Trim() == "" && (libelleTypePersonne == "ASSURANCE" 
                || libelleTypePersonne == "PARTENAIRE PM"))
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez choisir le secteur d'activité.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                cb_SecteurActivite.Focus();
                return;
            }

            if (cb_Pays.Text.Trim() == "" && (libelleTypePersonne == "FOURNISSEUR"
                || libelleTypePersonne == "ASSURANCE" || libelleTypePersonne == "PARTENAIRE PM"))
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez choisir le pays .",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                cb_Pays.Focus();
                return;
            }


            if (txt_Nom.Text.Trim() == "" && (libelleTypePersonne == "PATIENT"
                || libelleTypePersonne == "PARTENAIRE PP"))
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du nom est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_Nom.Focus();
                return;
            }




            if (cb_Civilite.Text.Trim() == "" && (libelleTypePersonne == "PATIENT"
                || libelleTypePersonne == "PARTENAIRE PP"))
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner la civilité de la personne.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                cb_Civilite.Focus();
                return;
            }


            if (ddl_paysPP.Text.Trim() == "" && (libelleTypePersonne == "PATIENT"
                || libelleTypePersonne == "PARTENAIRE PP"))
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner le pays de naissance de la personne.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                ddl_paysPP.Focus();
                return;
            }

            if (txt_lieuNaissance.Text.Trim() == "" && (libelleTypePersonne == "PATIENT"
                || libelleTypePersonne == "PARTENAIRE PP"))
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du lieu de naissance est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_lieuNaissance.Focus();
                return;
            }

            #endregion

            #region Enregistrement
            if (nouveau)
            {
                switch (libelleTypePersonne)
                {
                    case ("FOURNISSEUR"):
                        {
                            constituerObjet(FormulaireType.Fournisseur,objFournisseur,null,null,null,null);
                            sortie = objFournisseur.Insert();
                            message = LGC.Business.Tools.SplitMessage(sortie);
                            if (message[message.Length - 1].Trim() != "")
                            {
                                objFournisseur.NumLigne = int.Parse(message[message.Length - 1].Trim());
                                activerDesactiverControle(false);
                                ChargerListeFournisseur(objFournisseur);
                                nouveau = false;
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                            else
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            break;
                        }
                    case ("PARTENAIRE PP"):
                        {
                            constituerObjet(FormulaireType.PartenairePP, null, null, null, objPartenairePersonnePhysique, null);
                            sortie = objPartenairePersonnePhysique.Insert();
                            message = LGC.Business.Tools.SplitMessage(sortie);
                            if (message[message.Length - 1].Trim() != "")
                            {
                                objPartenairePersonnePhysique.NumLigne = int.Parse(message[message.Length - 1].Trim());
                                activerDesactiverControle(false);
                                
                                //sauvegarde de la tof de l'utilisateur
                                try
                                {
                                    if (pnl_photo.BackgroundImage != null)
                                    {
                                        ChargerListePartenairePP(objPartenairePersonnePhysique);
                                        objPartenairePersonnePhysique = (PartenairePersonnePhysique)bds_PartenairePersonnePhysique.Current;
                                        cheminFichier = CurrentUser.ImagePath + "\\" +
                                       libelleTypePersonne.Trim() +
                                       objPartenairePersonnePhysique.IdPersonne + ".jpg";
                                        if (File.Exists(cheminFichier.Trim()))
                                        {
                                            File.Delete(cheminFichier.Trim());
                                        }
                                        pnl_photo.BackgroundImage.Save(cheminFichier.Trim());
                                    }
                                    else
                                    {
                                        ChargerListePartenairePP(objPartenairePersonnePhysique);
                                        objPartenairePersonnePhysique = (PartenairePersonnePhysique)bds_PartenairePersonnePhysique.Current;
                                    }
                                                                   }
                                catch
                                {
                                }
                                if (objPartenairePersonnePhysique.Logo != "")
                                {
                                    cheminFichier = objPartenairePersonnePhysique.Logo;
                                    //sauvegarde de la tof de l'utilisateur
                                    try
                                    {
                                        if (pnl_EntetePP.BackgroundImage != null)
                                        {
                                            if (File.Exists(cheminFichier.Trim()))
                                            {
                                                File.Delete(cheminFichier.Trim());
                                            }
                                            pnl_EntetePP.BackgroundImage.Save(cheminFichier.Trim());
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                nouveau = false;
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                            else
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            break;
                        }
                    case ("PARTENAIRE PM"):
                        {
                            constituerObjet(FormulaireType.PartenairePM, null, null, objPartenairePersonneMorale, null, null);
                            sortie = objPartenairePersonneMorale.Insert();
                            message = LGC.Business.Tools.SplitMessage(sortie);
                            if (message[message.Length - 1].Trim() != "")
                            {
                                objPartenairePersonneMorale.NumLigne = int.Parse(message[message.Length - 1].Trim());
                                activerDesactiverControle(false);
                                
                                ChargerListePartenairePM(objPartenairePersonneMorale);
                                objPartenairePersonneMorale = (PartenairePersonneMorale)bds_PartenairePersonneMorale.Current;
                                if (objPartenairePersonneMorale.Logo != "")
                                {
                                    cheminFichier = objPartenairePersonneMorale.Logo;
                                    //sauvegarde de la tof de l'utilisateur
                                    try
                                    {
                                        if (pnl_EntetePP.BackgroundImage != null)
                                        {
                                            if (File.Exists(cheminFichier.Trim()))
                                            {
                                                File.Delete(cheminFichier.Trim());
                                            }
                                            pnl_EntetePM.BackgroundImage.Save(cheminFichier.Trim());
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                
                                nouveau = false;
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                            else
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            break;
                        }
                    case ("PATIENT"):
                        {
                            constituerObjet(FormulaireType.Patient, null, null, null, null,objPatient);
                            sortie = objPatient.Insert();
                            message = LGC.Business.Tools.SplitMessage(sortie);
                            if (message[message.Length - 1].Trim() != "")
                            {
                                objPatient.NumLigne = int.Parse(message[message.Length - 1].Trim());
                                activerDesactiverControle(false);
                                
                                //sauvegarde de la tof de l'utilisateur
                                try
                                {
                                    if (pnl_photo.BackgroundImage != null)
                                    {
                                        ChargerListePatient(objPatient);
                                        cheminFichier = CurrentUser.ImagePath + "\\" +
                                       libelleTypePersonne.Trim() +
                                       objPatient.IdPersonne + ".jpg";
                                        if (File.Exists(cheminFichier.Trim()))
                                        {
                                            File.Delete(cheminFichier.Trim());
                                        }
                                        pnl_photo.BackgroundImage.Save(cheminFichier.Trim());
                                    }
                                    else
                                    {
                                        ChargerListePatient(objPatient);
                                    }
                                    
                                }
                                catch
                                {
                                }
                               
                                nouveau = false;
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Info);

                                if(estailleurs==true)
                                {
                                    Frm_ListePatient frm = (Frm_ListePatient)Application.OpenForms["Frm_ListePatient"];
                                    frm.oPatient = objPatient;
                                    Close();
                                }
                            }
                            else
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            break;
                        }
                    case ("ASSURANCE"):
                        {
                            constituerObjet(FormulaireType.Assurance, null,objAssurance, null, null, null);
                            sortie = objAssurance.Insert();
                            message = LGC.Business.Tools.SplitMessage(sortie);
                            if (message[message.Length - 1].Trim() != "")
                            {
                                objAssurance.NumLigne = int.Parse(message[message.Length - 1].Trim());
                                activerDesactiverControle(false);
                                ChargerListeAssurance(objAssurance);
                                nouveau = false;
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                            else
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            break;
                        }
                    default:
                        btn_Annuler_Click(null, null);
                        break;
                }
                
            }
            #endregion

            #region Modification
            else
            {

                switch (libelleTypePersonne)
                {
                    case ("FOURNISSEUR"):
                        {
                            objFournisseur = (Fournisseur)bds_fournisseur.Current;
                            constituerObjet(FormulaireType.Fournisseur, objFournisseur, null, null, null, null);
                            sortie = objFournisseur.Update();
                            message = LGC.Business.Tools.SplitMessage(sortie);
                            if (message[message.Length - 1].Trim() != "")
                            {
                                activerDesactiverControle(false);
                                nouveau = false;
                                ChargerListeFournisseur((Fournisseur)bds_fournisseur.Current);
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                            else
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[4].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            break;
                        }
                    case ("PARTENAIRE PP"):
                        {
                            objPartenairePersonnePhysique = (PartenairePersonnePhysique)bds_PartenairePersonnePhysique.Current;
                            constituerObjet(FormulaireType.PartenairePP, null, null, null, objPartenairePersonnePhysique, null);
                            sortie = objPartenairePersonnePhysique.Update();
                            message = LGC.Business.Tools.SplitMessage(sortie);
                            if (message[message.Length - 1].Trim() != "")
                            {
                                cheminFichier = CurrentUser.ImagePath + "\\" +
                               libelleTypePersonne.Trim() +
                               objPartenairePersonnePhysique.IdPersonne + ".jpg";
                                //sauvegarde de la tof de l'utilisateur
                                try
                                {
                                    if (pnl_photo.BackgroundImage != null)
                                    {
                                        
                                        if (File.Exists(cheminFichier.Trim()))
                                        {
                                            pnl_photo.BackgroundImage = null;
                                            File.Delete(cheminFichier.Trim());
                                        }
                                        pnl_photo.BackgroundImage.Save(cheminFichier.Trim());
                                    }
                                    else
                                    {
                                        if (File.Exists(cheminFichier.Trim()))
                                        {

                                            File.Delete(cheminFichier.Trim());
                                        }
                                    }
                                }
                                catch
                                {
                                }
                                ChargerListePartenairePP((PartenairePersonnePhysique)bds_PartenairePersonnePhysique.Current);
                                objPartenairePersonnePhysique = (PartenairePersonnePhysique)bds_PartenairePersonnePhysique.Current;
                                activerDesactiverControle(false);
                                if (objPartenairePersonnePhysique.Logo != "")
                                {
                                    
                                    cheminFichier = objPartenairePersonnePhysique.Logo;
                                    //sauvegarde de la tof de l'utilisateur
                                    try
                                    {
                                        if (pnl_EntetePP.BackgroundImage != null)
                                        {
                                            if (File.Exists(cheminFichier.Trim()))
                                            {
                                                pnl_EntetePP.BackgroundImage = null;
                                                File.Delete(cheminFichier.Trim());
                                            }
                                            pnl_EntetePP.BackgroundImage.Save(cheminFichier.Trim());
                                        }
                                        else
                                        {
                                            if (File.Exists(cheminFichier.Trim()))
                                            {
                                                File.Delete(cheminFichier.Trim());
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                nouveau = false;
                                ChargerListePartenairePP((PartenairePersonnePhysique)bds_PartenairePersonnePhysique.Current);
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                            else
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[4].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            break;
                        }
                    case ("PARTENAIRE PM"):
                        {
                            objPartenairePersonneMorale = (PartenairePersonneMorale)bds_PartenairePersonneMorale.Current;
                            constituerObjet(FormulaireType.PartenairePM, null, null, objPartenairePersonneMorale, null, null);
                            sortie = objPartenairePersonneMorale.Update();
                            message = LGC.Business.Tools.SplitMessage(sortie);
                            if (message[message.Length - 1].Trim() != "")
                            {
                                activerDesactiverControle(false);
                                nouveau = false;
                                ChargerListePartenairePM((PartenairePersonneMorale)bds_PartenairePersonneMorale.Current);
                                objPartenairePersonneMorale = (PartenairePersonneMorale)bds_PartenairePersonneMorale.Current;
                                if (objPartenairePersonneMorale.Logo != "")
                                {
                                    cheminFichier = objPartenairePersonneMorale.Logo;
                                    //sauvegarde de la tof de l'utilisateur
                                    try
                                    {
                                        if (pnl_EntetePM.BackgroundImage != null)
                                        {
                                            if (File.Exists(cheminFichier.Trim()))
                                            {
                                                pnl_EntetePM.BackgroundImage = null;
                                                File.Delete(cheminFichier.Trim());
                                            }
                                            pnl_EntetePM.BackgroundImage.Save(cheminFichier.Trim());
                                        }
                                        else
                                        {
                                            if (File.Exists(cheminFichier.Trim()))
                                            {
                                                File.Delete(cheminFichier.Trim());
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                            else
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[4].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            break;
                        }
                    case ("PATIENT"):
                        {
                            objPatient = (Patient)bds_patient.Current;
                            constituerObjet(FormulaireType.Patient, null, null, null, null, objPatient);
                            sortie = objPatient.Update();
                            message = LGC.Business.Tools.SplitMessage(sortie);
                            if (message[message.Length - 1].Trim() != "")
                            {
                                activerDesactiverControle(false);
                                nouveau = false;
                                cheminFichier = CurrentUser.ImagePath + "\\" +
                               libelleTypePersonne.Trim() +
                               objPatient.IdPersonne + ".jpg";
                                //sauvegarde de la tof de l'utilisateur
                                try
                                {
                                    if (pnl_photo.BackgroundImage != null)
                                    {
                                        
                                        if (File.Exists(cheminFichier.Trim()))
                                        {
                                            pnl_photo.BackgroundImage = null;
                                            File.Delete(cheminFichier.Trim());
                                        }
                                        pnl_photo.BackgroundImage.Save(cheminFichier.Trim());
                                    }
                                    else
                                    {
                                        if (File.Exists(cheminFichier.Trim()))
                                        {
                                            File.Delete(cheminFichier.Trim());
                                        }
                                    }
                                }
                                catch
                                {
                                }
                                ChargerListePatient((Patient)bds_patient.Current);
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                            else
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[4].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            break;
                        }
                    case ("ASSURANCE"):
                        {
                            objAssurance = (Assurance)bds_Assurance.Current;
                            constituerObjet(FormulaireType.Assurance, null, objAssurance, null, null, null);
                            sortie = objAssurance.Update();
                            message = LGC.Business.Tools.SplitMessage(sortie);
                            if (message[message.Length - 1].Trim() != "")
                            {
                                activerDesactiverControle(false);
                                nouveau = false;
                                ChargerListeAssurance((Assurance)bds_Assurance.Current);
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                            else
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, message[4].Trim(), CurrentUser.LogicielHote,
                                    MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            break;
                        }
                    default:
                        btn_Annuler_Click(null, null);
                        break;
                }              
                
                
            }
            #endregion

            

            
           
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            //ChargerListe((PersonneMorale)bds_personneMorale.Current);
        }

       

        #endregion

        #region DataGridView

        private void dgv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListePM.SelectedRows != null &&
                dgv_ListePM.SelectedRows.Count > 0)
            {
                //detaillerObjet((PersonneMorale)bds_personneMorale.Current);
            }
            else
            {
                RAZ();
            }
        }

       
        
       
        #endregion

        #region pageView
        private void pv_titres_SelectedPageChanged(object sender, EventArgs e)
        {
            libelleTypePersonne = pv_titres.SelectedPage.Text.Trim();
            switch (libelleTypePersonne)
            {
                case ("FOURNISSEUR"):
                    {
                        ControleAffichage(FormulaireType.Fournisseur);
                        rpvp_Analyse.Enabled = false;
                       
                        break;
                    }
                case ("PARTENAIRE PP"):
                    {
                        ControleAffichage(FormulaireType.PartenairePP);
                        rpvp_Analyse.Enabled = true;
                        
                        break;
                    }
                case ("PARTENAIRE PM"):
                    {
                        ControleAffichage(FormulaireType.PartenairePM);
                        rpvp_Analyse.Enabled = true;
                      
                        break;
                    }
                case ("PATIENT"):
                    {
                        ControleAffichage(FormulaireType.Patient);
                        rpvp_Analyse.Enabled = false;
                      
                        break;
                    }
                case ("ASSURANCE"):
                    {
                        ControleAffichage(FormulaireType.Assurance);
                        rpvp_Analyse.Enabled = false;
                       
                        break;
                    }
                default:
                    this.Close();
                    break;
            }
            //ChargerListe(null);
           
        }
        #endregion

        private void dgv_ListePP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListePP.SelectedRows != null &&
                dgv_ListePP.SelectedRows.Count > 0)
            {
                switch (libelleTypePersonne)
                {
                    case("PATIENT"):
                        {
                            detaillerObjetPatient((Patient)bds_patient.Current);
                            break;
                        }
                    case("PARTENAIRE PP") :
                        {
                            detaillerObjetPartenairePersonnePhysique((PartenairePersonnePhysique)bds_PartenairePersonnePhysique.Current);
                            break;
                        }
                   
                }
               
            }
            else
            {
                RAZ();
            }
        }

        private void dgv_ListePM_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListePM.SelectedRows != null &&
                dgv_ListePM.SelectedRows.Count > 0)
            {
                switch (libelleTypePersonne)
                {
                    case ("FOURNISSEUR"):
                        {
                            detaillerObjetFournisseur((Fournisseur)bds_fournisseur.Current);
                            break;
                        }
                    case ("PARTENAIRE PM"):
                        {
                            detaillerObjetPartenairePersonneMorale((PartenairePersonneMorale)bds_PartenairePersonneMorale.Current);
                            break;
                        }
                    case ("ASSURANCE"):
                        {
                            detaillerObjetAssurance((Assurance)bds_Assurance.Current);
                            break;
                        }

                }

            }
            else
            {
                RAZ();
            }
        }

        private void btn_AddPhoto_Click(object sender, EventArgs e)
        {
            if (!txt_Prenom.ReadOnly)
            {
                OpenFileDialog OpenFile = new OpenFileDialog();
                OpenFile.Filter = "Fichier image|*.jpg";
                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    cheminFichier = OpenFile.FileName;
                    pnl_photo.BackgroundImage = Image.FromFile(cheminFichier.Trim());
                }
            }
        }

        private void btn_supPhoto_Click(object sender, EventArgs e)
        {
            pnl_photo.BackgroundImage = null;
        }

        private void btn_SupprimerEntetePM_Click(object sender, EventArgs e)
        {
            pnl_EntetePM.BackgroundImage = null;
            if (!nouveau)
            {
             PartenairePersonneMorale  objPartenairePersonneMorale = (PartenairePersonneMorale)bds_PartenairePersonneMorale.Current;
             if (objPartenairePersonneMorale.Logo.Trim() != "" && File.Exists(objPartenairePersonneMorale.Logo.Trim()))
             {
                 File.Delete(objPartenairePersonneMorale.Logo.Trim());
             }
             objPartenairePersonneMorale.Logo = "";
             objPartenairePersonneMorale.Update(); 
            }
        }

        private void btn_SupprimerEntetePP_Click(object sender, EventArgs e)
        {
            pnl_EntetePP.BackgroundImage = null;
            if (!nouveau)
            {
                PartenairePersonnePhysique objPartenairePersonnePhysique = (PartenairePersonnePhysique)bds_PartenairePersonnePhysique.Current;
                if (objPartenairePersonnePhysique.Logo.Trim() != "" && File.Exists(objPartenairePersonnePhysique.Logo.Trim()))
                {
                    File.Delete(objPartenairePersonnePhysique.Logo.Trim());
                }
                objPartenairePersonnePhysique.Logo = "";
                objPartenairePersonnePhysique.Update();
            }
        }

        private void btn_ImporterEntetePP_Click(object sender, EventArgs e)
        {
            if (!txt_Prenom.ReadOnly)
            {
                OpenFileDialog OpenFile = new OpenFileDialog();
                OpenFile.Filter = "Fichier image|*.jpg";
                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    cheminFichier = OpenFile.FileName;
                    pnl_EntetePP.BackgroundImage = Image.FromFile(cheminFichier.Trim());
                }
            }
        }

        private void btn_ImporterEntetePM_Click(object sender, EventArgs e)
        {
            if (!txt_Raison_Sociale.ReadOnly)
            {
                OpenFileDialog OpenFile = new OpenFileDialog();
                OpenFile.Filter = "Fichier image|*.jpg";
                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    cheminFichier = OpenFile.FileName;
                    pnl_EntetePM.BackgroundImage = Image.FromFile(cheminFichier.Trim());
                }
            }
        }

        private void btn_NouveauCB_Click(object sender, EventArgs e)
        {
            if (txt_Nom.Text.Trim() != "" || txt_Sigle.Text.Trim() != "")
            {
                nouveau = true;
                activerDesactiverControleCB(true);
                gv_ListeAnalysePartenaire.Rows.Add(" ",0, 0);
                numeroLigne = gv_ListeAnalysePartenaire.Rows.Count - 1;
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner un partenaire avant d'ajouter les comptes bancaires",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_ModifierCB_Click(object sender, EventArgs e)
        {
            if (gv_ListeAnalysePartenaire.SelectedRows != null &&
               gv_ListeAnalysePartenaire.SelectedRows.Count > 0)
            {
                nouveau = false;
                activerDesactiverControleCB(true);
                numeroLigne = gv_ListeAnalysePartenaire.SelectedRows[0].Index;
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez selectioner une ligne " +
                    "avant d'entamer la modification.", CurrentUser.LogicielHote, MessageBoxButtons.OK,
                    RadMessageIcon.Error);
            }
        }

        private void btn_SupprimerCB_Click(object sender, EventArgs e)
        {
            if (gv_ListeAnalysePartenaire.SelectedRows != null &&
              gv_ListeAnalysePartenaire.SelectedRows.Count > 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne " +
                    "sélectionnée", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                    RadMessageIcon.Question) == DialogResult.Yes)
                {
                    AnalysePartenaire obj = lstAnalysePartenaire.Find(x => x.NumLigne == Convert.ToDecimal(gv_ListeAnalysePartenaire.Rows[numeroLigne].Cells["numLigne"].Value.ToString().Trim()));
                    string res = obj.Delete();
                    message = LGC.Business.Tools.SplitMessage(res);
                    btn_Annuler_Click(null, null);
                    if (int.Parse(message[0]) > 0)
                    {
                        
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                       
                    }
                    else
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        MessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner la ligne à supprimer.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_AnnulerCB_Click(object sender, EventArgs e)
        {
            nouveau = false;
            activerDesactiverControleCB(false);

            gv_ListeAnalysePartenaire.Rows.Clear();
            lstAnalysePartenaire = AnalysePartenaire.Liste(idPersonne, null, null, null, null, null, null, false, null, null);
            for (int i = 0; i < lstAnalysePartenaire.Count; i++)
            {
                gv_ListeAnalysePartenaire.Rows.Add(lstAnalysePartenaire[i].CodeAnalyse, lstAnalysePartenaire[i].PrixNormal, lstAnalysePartenaire[i].Taux, lstAnalysePartenaire[i].NumLigne);
                numeroLigne = gv_ListeAnalysePartenaire.SelectedRows[0].Index;
            }
        }

        private void btn_EnregistrerCB_Click(object sender, EventArgs e)
        {
            AnalysePartenaire obj = new AnalysePartenaire();

            #region controle de saisie
            if (gv_ListeAnalysePartenaire.Rows[numeroLigne].Cells["codeAnalyse"].Value.ToString().Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La sélection du code analyse est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                gv_ListeAnalysePartenaire.Focus();
                return;
            }

            if (gv_ListeAnalysePartenaire.Rows[numeroLigne].Cells["prixNormal"].Value.ToString().Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du prix est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                gv_ListeAnalysePartenaire.Focus();
                return;
            }


            #endregion

            #region Enregistrement
            if (nouveau)
            {
                try
                {

                    obj.IdPersonne = idPersonne;
                    obj.CodeAnalyse = Convert.ToString(gv_ListeAnalysePartenaire.Rows[numeroLigne].Cells["codeAnalyse"].Value.ToString().Trim());
                    obj.PrixNormal = Convert.ToDecimal(gv_ListeAnalysePartenaire.Rows[numeroLigne].Cells["prixNormal"].Value.ToString().Trim());
                    obj.Taux = Convert.ToDecimal(gv_ListeAnalysePartenaire.Rows[numeroLigne].Cells["taux"].Value.ToString().Trim());
                    sortie = obj.Insert();
                    message = LGC.Business.Tools.SplitMessage(sortie);
                    if (message[message.Length - 1].Trim() != "")
                    {
                        obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                      
                        activerDesactiverControleCB(false);
                        nouveau = false;
                        //btn_Annuler_Click(null, null);
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    else
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
                catch { }
            }
            #endregion

            #region Modification
            else
            {
                try
                {
                    obj = lstAnalysePartenaire.Find(x => x.NumLigne == Convert.ToDecimal(gv_ListeAnalysePartenaire.Rows[numeroLigne].Cells["numLigne"].Value.ToString().Trim()));
                    obj.IdPersonne = idPersonne;
                    obj.CodeAnalyse = Convert.ToString(gv_ListeAnalysePartenaire.Rows[numeroLigne].Cells["codeAnalyse"].Value.ToString().Trim());
                    obj.PrixNormal = Convert.ToDecimal(gv_ListeAnalysePartenaire.Rows[numeroLigne].Cells["prixNormal"].Value.ToString().Trim());
                    obj.Taux = Convert.ToDecimal(gv_ListeAnalysePartenaire.Rows[numeroLigne].Cells["taux"].Value.ToString().Trim());
                    sortie = obj.Update();
                    message = LGC.Business.Tools.SplitMessage(sortie);
                    if (message[message.Length - 1].Trim() != "")
                    {
                        activerDesactiverControleCB(false);
                        nouveau = false;
                        //btn_Annuler_Click(null, null);
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    else
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[4].Trim(), CurrentUser.LogicielHote,
                            MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
                catch { }
            }
            #endregion
        }

       

        

        private void btn_ChoixPartenairePM_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_ListePartenaire frm = new Frm_ListePartenaire(false);
                frm.ShowDialog();
                oPartenaires = frm.oPartenaires;
                txt_PartenaireSourcePM.Text = oPartenaires.NomSigle + " " + oPartenaires.PrenomRaisonSociale;
            }
            catch { }
        }

      

        private void btn_ChoixPartenairePP_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_ListePartenaire frm = new Frm_ListePartenaire(false);
                frm.ShowDialog();
                oPartenaires = frm.oPartenaires;
                txt_PartenaireSourcePP.Text = oPartenaires.NomSigle + " " + oPartenaires.PrenomRaisonSociale;
            }
            catch { }
        }
    }

    public enum FormulaireType
    {
        Fournisseur,
        Assurance,
        Patient,
        PartenairePP,
        PartenairePM
    }
}
