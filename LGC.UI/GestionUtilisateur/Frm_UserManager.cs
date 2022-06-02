using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.IO;
using LGC.Business.GestionUtilisateur;
using LGC.Business;


namespace LGC.UI.GestionUtilisateur
{
    public partial class Frm_UserManager : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public static string chemin = string.Empty;

        public bool estChargementUtilPU = false;
        public bool estChargementUtilPD = false;
        public bool estChargementDatePD = false;

        public bool estChargement = false;
        public bool estChargementDroit = false;
        public bool nouveauProfil = false;
        public bool nouveauUtil = false;
        public bool nouveauDroit = false;
        public bool affichage = false;// Permet d'exécuter ou pas la procédure selected Changed
        public bool trouve = false;//est utilisé pour vérifier si un droit a été attribué a un profil
        public bool trouveCode = false;//est utlisé lors de la recherche du nom du formulaire, dans le dgv_listeDroitFormUtil
        public bool trouveCodeDrt = false;//est utilisé pour vé

        private RadMenu rmi_Menu;
        private RadMenu rmi_Menu2;
        private RadMenu rmi_Menu3;

        string cheminFichier;
        string sortie;
        string[] message;

        List<Droit> lstDroit = new List<Droit>();
        List<Profil> lstProfil = new List<Profil>();
        List<ProfilDroit> lstProfilDroit = new List<ProfilDroit>();
        List<ProfilDroit> lstProfilDroitAll = new List<ProfilDroit>();
        List<Utilisateur> lstUtilisateur = new List<Utilisateur>();
        List<UtilisateurProfil> lstUtilProfil = new List<UtilisateurProfil>();
        List<JournalConnexion> lstJournalConnexion = new List<JournalConnexion>();

        #endregion

        #region Autres

        #region Profil
        private void activerDesactiverControleProfil(bool condition)
        {
            txt_CodeProfil.ReadOnly = !condition;
            txt_libelleProfil.ReadOnly = !condition;
            chk_actif.ReadOnly = !condition;
            chk_ElementSelection.ReadOnly = !condition;
            chk_selectTout.ReadOnly = !condition;

            //permet de rendre invisble la colonne de choix
            dgv_profilDroit.Columns["chk_choix"].IsVisible = condition;
            dgv_listeProfil.Enabled = !condition;
            dgv_profilDroit.ReadOnly = !condition;

            btn_Annuler.Visible = condition;
            btn_Enregistrer.Visible = condition;
            btn_Nouveau.Visible = !condition;
            btn_Modifier.Visible = !condition;
            btn_Supprimer.Enabled = !condition;
            btn_Actualiser.Enabled = !condition;

            //rendre visible tous les droits  
            for (int i = 0; i < dgv_profilDroit.Rows.Count; i++)
            {
                dgv_profilDroit.Rows[i].IsVisible = true;
            }
        }

        private void RAZProfil()
        {
            txt_CodeProfil.Text = "";
            txt_libelleProfil.Text = "";
            chk_actif.Checked = true;

            //vider la liste des droits affichés pour ce profil
            for (int i = 0; i < dgv_profilDroit.Rows.Count; i++)
            {
                dgv_profilDroit.Rows[i].Cells["chk_choix"].Value = false;
                dgv_profilDroit.Rows[i].Cells["Creation"].Value = false;
                dgv_profilDroit.Rows[i].Cells["Modification"].Value = false;
                dgv_profilDroit.Rows[i].Cells["Suppression"].Value = false;
                dgv_profilDroit.Rows[i].IsVisible = nouveauProfil;
            }
        }

        private void constituerObjetProfil(Profil objPro)
        {
            objPro.CodeProfil = txt_CodeProfil.Text.Trim();
            objPro.LibelleProfil = txt_libelleProfil.Text.Trim();
            objPro.EstActif = chk_actif.Checked;
        }

        private void detaillerObjetProfil(Profil objPro)
        {
            txt_CodeProfil.Text = objPro.CodeProfil;
            txt_libelleProfil.Text = objPro.LibelleProfil.Trim();
            chk_actif.Checked = objPro.EstActif;

            //affichage de la liste des droits pour ce profil
            lstProfilDroit = lstProfilDroitAll.FindAll(l=>l.CodeProfil.Trim().ToLower()==
                objPro.CodeProfil.Trim().ToLower());
            for (int i = 0; i < dgv_profilDroit.Rows.Count; i++)
            {
                ProfilDroit obj = lstProfilDroit.Find(l => l.CodeDroit.Trim().ToLower() ==
                    dgv_profilDroit.Rows[i].Cells["CodeDroit"].Value.ToString().ToLower().Trim());
                if (obj != null)
                {
                    dgv_profilDroit.Rows[i].IsVisible = true;
                    dgv_profilDroit.Rows[i].Cells["chk_choix"].Value = true;
                    dgv_profilDroit.Rows[i].Cells["Creation"].Value = obj.Creation;
                    dgv_profilDroit.Rows[i].Cells["Modification"].Value = obj.Modification;
                    dgv_profilDroit.Rows[i].Cells["Suppression"].Value = obj.Suppression;
                }
                else
                {
                    dgv_profilDroit.Rows[i].Cells["chk_choix"].Value = false;
                    dgv_profilDroit.Rows[i].IsVisible = false;
                    dgv_profilDroit.Rows[i].Cells["Creation"].Value = false;
                    dgv_profilDroit.Rows[i].Cells["Modification"].Value = false;
                    dgv_profilDroit.Rows[i].Cells["Suppression"].Value = false;
                }
            }
        }

        private void ChargerListeProfil(Profil objPro)
        {
            lstProfilDroitAll = ProfilDroit.Liste(null, null, null, null,
                null, null, null, null, null, null, false, null);
            lstProfil = Profil.Liste(null, null, null, 
                null, null, null, null, null, false, null);
            bds_profil.DataSource = lstProfil;
            //chrger l liste des profils des utilisteurs
            dgv_ProfilUtil.Rows.Clear();
            foreach (Profil lign in lstProfil)
            {
                dgv_ProfilUtil.Rows.Add("",false, lign.CodeProfil,
                    lign.LibelleProfil);
                if (dgv_ProfilUtil.ReadOnly)
                    dgv_ProfilUtil.Rows[dgv_ProfilUtil.Rows.Count - 1].IsVisible = false;
            }
            if (!nouveauUtil && !estChargement) 
                dgv_ListeUtil_SelectionChanged(null, null);

            if (objPro != null)
            {
                int i = 0;
                foreach (Profil ligne in bds_profil.List as List<Profil>)
                {
                    if (ligne.NumLigne == objPro.NumLigne)
                    {
                        bds_profil.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        } 
        #endregion

        #region Utilisateur
        private void activerDesactiverControleFormUtilisateur(bool condition)
        {
            txt_nomUtil.ReadOnly = !condition;
            txt_prenomUtil.ReadOnly = !condition;
            txt_telUtil.ReadOnly = !condition;
            txt_mailUtil.ReadOnly = !condition;
            //txt_typeUtil.ReadOnly = !condition;
            txt_loginUtil.ReadOnly = !condition;
            txt_pwdUtil.ReadOnly = !condition;
            txt_comfirmation.ReadOnly = !condition;
            chk_estActifUtil.ReadOnly = !condition;
            chk_AutoriseSaisieDateAnterireur.ReadOnly = !condition;
            cb_sexeUtil.ReadOnly = !condition;

            dgv_ListeUtil.Enabled = !condition;
            dgv_ProfilUtil.ReadOnly = !condition;
            ////permet de rendre invisble la colonne de choix
            dgv_ProfilUtil.Columns["chk_choixProfil"].IsVisible = condition;
            dgv_ProfilUtil.Columns["Cmd_choix"].IsVisible = condition;

            btn_anuulerUtil.Visible = condition;
            btn_enregistrerUtil.Visible = condition;
            btn_nouveauUtil.Visible = !condition;
            btn_modifierUtil.Visible = !condition;
            btn_supprimerUtil.Enabled = !condition;
            btn_AddPhoto.Enabled = condition;
            btn_supPhoto.Enabled = condition;
            btn_ActualiserUtil.Enabled = !condition;

            //rendre visible tous les profils  
            for (int i = 0; i < dgv_ProfilUtil.Rows.Count; i++)
            {
                dgv_ProfilUtil.Rows[i].IsVisible = true;
            }
        }

        private void RAZFormUtilisateur()
        {
            meb_numeroUtil.Value = 0;
            txt_nomUtil.Text = "";
            txt_prenomUtil.Text = "";
            txt_telUtil.Text = "";
            txt_mailUtil.Text = "";
            txt_typeUtil.Text = "SIMPLE";
            txt_loginUtil.Text = "";
            txt_pwdUtil.Text = "";
            txt_comfirmation.Text = "";
            chk_estActifUtil.Checked = true;
            cb_sexeUtil.Text = "M";
            pnl_photo.Text = "";
            pnl_photo.BackgroundImage = null;

            cheminFichier = "";

            //vider la liste des profils affichés pour cet utilisteur
            for (int i = 0; i < dgv_ProfilUtil.Rows.Count; i++)
            {
                dgv_ProfilUtil.Rows[i].Cells["chk_choixProfil"].Value = false;
                dgv_ProfilUtil.Rows[i].IsVisible = nouveauUtil;
            }
            //vider la liste des droits
            for (int i = 0; i < dgv_DroitUtil.Rows.Count; i++)
            {
                dgv_DroitUtil.Rows[i].Cells["Creation"].Value = false;
                dgv_DroitUtil.Rows[i].Cells["Modification"].Value = false;
                dgv_DroitUtil.Rows[i].Cells["Suppression"].Value = false;
                dgv_DroitUtil.Rows[i].IsVisible = false;
            }
        }

        private void constituerObjet(Utilisateur obj)
        {
            obj.NomUtilisateur = txt_nomUtil.Text.Trim();
            obj.PrenomUtilisateur = txt_prenomUtil.Text.Trim();
            obj.Mail = txt_mailUtil.Text.Trim();
            obj.Telephone = txt_telUtil.Text.Trim();
            obj.Login = txt_loginUtil.Text.Trim();
            //hacher le mot de passe
            if (nouveauUtil || obj.Password==null || obj.Password.Trim() != txt_pwdUtil.Text.Trim())
                obj.Password = Tools.HashWithMD5(txt_pwdUtil.Text.Trim());
            obj.EstActiveDirectory = false;
            obj.EstActif = chk_estActifUtil.Checked;
            obj.Sexe = cb_sexeUtil.Text.Trim();
            obj.CheminPhoto = "";
            obj.AutoriseDateAnterieur = chk_AutoriseSaisieDateAnterireur.Checked;
        }

        private void detaillerObjet(Utilisateur obj)
        {
            meb_numeroUtil.Value = obj.NumeroUtilisateur;
            txt_nomUtil.Text = obj.NomUtilisateur.Trim();
            txt_prenomUtil.Text = obj.PrenomUtilisateur.Trim();
            txt_telUtil.Text = obj.Telephone.Trim();
            txt_mailUtil.Text = obj.Mail.Trim();
            if (Convert.ToBoolean(obj.EstActiveDirectory))
                txt_typeUtil.Text = "ACTIVE DIRECTORY";
            else
                txt_typeUtil.Text = "SIMPLE";
            txt_loginUtil.Text = obj.Login.Trim();
            txt_pwdUtil.Text = obj.Password.Trim();
            txt_comfirmation.Text = obj.Password.Trim();
            cb_sexeUtil.Text = obj.Sexe.Trim();
            chk_estActifUtil.Checked = obj.EstActif;
            chk_AutoriseSaisieDateAnterireur.Checked = obj.AutoriseDateAnterieur;

            cheminFichier = CurrentUser.ImagePath + "\\" +
                txt_nomUtil.Text.Trim().Substring(0, 4) +
                txt_prenomUtil.Text.Trim().Substring(0, 4) + "(" +
                obj.NumeroUtilisateur.ToString() + ").jpg";
            //permet d'afficher la photo
            if (File.Exists(cheminFichier))
            {
                pnl_photo.BackgroundImage = Image.FromFile(cheminFichier.Trim());
            }
            else
            {
                pnl_photo.BackgroundImage = null;
            }

            //affichage de la liste des profils de cet utilisateur
            lstUtilProfil = UtilisateurProfil.Liste(obj.NumeroUtilisateur,
                null, null, null, null, null, null, false, null);
            for (int i = 0; i < dgv_ProfilUtil.Rows.Count; i++)
            {
                UtilisateurProfil objProUti = lstUtilProfil.Find(l => 
                    l.CodeProfil.Trim().ToLower() ==
                    dgv_ProfilUtil.Rows[i].Cells["CodeProfil"
                    ].Value.ToString().ToLower().Trim());
                if (objProUti != null)
                {
                    dgv_ProfilUtil.Rows[i].IsVisible = true;
                    dgv_ProfilUtil.Rows[i].Cells["chk_choixProfil"].Value = true;
                }
                else
                {
                    dgv_ProfilUtil.Rows[i].Cells["chk_choixProfil"].Value = false;
                    dgv_ProfilUtil.Rows[i].IsVisible = false;
                }
            }
            showDroitReel();
        }

        private void ChargerListe(Utilisateur obj)
        {
            lstUtilisateur = Utilisateur.Liste(null, null, null, null, 
                null, null, null, null, null, null, null,null,
                null, null, null, null, null, false, null);
            bds_Utilisateur.DataSource = lstUtilisateur;
            if (obj != null)
            {
                int i = 0;
                foreach (Utilisateur ligne in bds_Utilisateur.List as List<Utilisateur>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_Utilisateur.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        public void showDroitReel()
        {
            //décocher tous les droits
            for (int i = 0; i < dgv_DroitUtil.Rows.Count; i++)
            {
                dgv_DroitUtil.Rows[i].Cells["Creation"].Value = false;
                dgv_DroitUtil.Rows[i].Cells["Modification"].Value = false;
                dgv_DroitUtil.Rows[i].Cells["Suppression"].Value = false;
                dgv_DroitUtil.Rows[i].IsVisible = false;
            }
            for (int i = 0; i < dgv_ProfilUtil.Rows.Count; i++)
            {
                if (Convert.ToBoolean(
                    dgv_ProfilUtil.Rows[i].Cells["chk_choixProfil"].Value))
                {
                    List<ProfilDroit> lstPro = lstProfilDroitAll.FindAll(
                    l => l.CodeProfil.Trim() ==
                        dgv_ProfilUtil.Rows[i].Cells["CodeProfil"].Value.ToString().Trim());
                    for (int j = 0; j < dgv_DroitUtil.Rows.Count; j++)
                    {
                        ProfilDroit obj = lstPro.Find(l => l.CodeDroit.Trim().ToLower() ==
                            dgv_DroitUtil.Rows[j].Cells["CodeDroit"].Value.ToString().ToLower().Trim());
                        if (obj != null)
                        {
                            dgv_DroitUtil.Rows[j].IsVisible = true;
                            if (obj.Creation)
                                dgv_DroitUtil.Rows[j].Cells["Creation"].Value = obj.Creation;
                            if (obj.Modification)
                                dgv_DroitUtil.Rows[j].Cells["Modification"].Value = obj.Modification;
                            if (obj.Suppression)
                                dgv_DroitUtil.Rows[j].Cells["Suppression"].Value = obj.Suppression;
                        }
                    }
                }
            }
        }

        #endregion

        #region Droit
        private void activerDesactiverControleDroit(bool condition)
        {
            dgv_ListeDroit.ReadOnly = !condition;

            btn_annulerDroit.Visible = condition;
            btn_EnregistrerDroit.Visible = condition;
            btn_NouveauDroit.Visible = !condition;
            btn_ModifierDroit.Visible = !condition;
        }

        private void chargerListedesDroits()
        {
            estChargementDroit = true;
            //affichage de la liste des droits
            lstDroit = Droit.Liste(null, null, null, null, null, null,
                null, null, null, null, null, false, null);
            //permet de charger la liste des droits dans le Datagrid
            dgv_DroitUtil.Rows.Clear();
            dgv_profilDroit.Rows.Clear();
            dgv_ListeDroit.Rows.Clear();
            foreach (Droit rowDroit in lstDroit)
            {
                dgv_DroitUtil.Rows.Add(rowDroit.CodeDroit,
                    rowDroit.LibelleDroit, false, false, false);
                dgv_profilDroit.Rows.Add(false, rowDroit.CodeDroit,
                    rowDroit.LibelleDroit, false, false, false);
                dgv_ListeDroit.Rows.Add(rowDroit.EstSensible,
                                        rowDroit.DegreSensibilite, 
                                        rowDroit.LibelleDroit, 
                                        rowDroit.CodeDroit.Trim(),
                                        rowDroit.NomFormulaire.Trim(),
                                        rowDroit.CheminMenu.Trim(), 0);

                dgv_profilDroit.Rows[dgv_profilDroit.Rows.Count - 1].IsVisible =
                    !dgv_profilDroit.ReadOnly;
                dgv_DroitUtil.Rows[dgv_DroitUtil.Rows.Count - 1].IsVisible = false;
            }
            if (!estChargement)
            {
                if (!nouveauProfil)
                {
                    dgv_listeProfil_SelectionChanged(null, null);
                }
                showDroitReel();
            }
            estChargementDroit = false;
            dgv_ListeDroit_SelectionChanged(null, null);
        }

        private void constituerMenu(RadMenuItem USM)
        {
            if (chemin == "")
                chemin += USM.Name;
            else
                chemin += ";" + USM.Name;
            if (USM.Items.Count > 0)
            {
                foreach (RadItem unNSousMenu in USM.Items)
                {
                    try
                    {
                        constituerMenu((RadMenuItem)unNSousMenu);
                    }
                    catch { }
                }
                chemin = chemin + "                                                                                                                         ";
                int nb = chemin.Trim().Length - USM.Name.Length;
                if (nb > 0)
                    nb -= 1;
                chemin = chemin.Substring(0, nb).Trim();
            }
            else
            {
                if (USM.Tag != null && USM.Tag.ToString().Trim() != "" &&
                    lstDroit.Find(l => l.CheminMenu.Trim().ToLower() ==
                        chemin.ToLower().Trim()) == null)
                {
                    dgv_ListeDroit.Rows.Add(false, 0, USM.Text, 0,
                                            USM.Tag.ToString().Split(';')[0],
                                            chemin, 0);
                }
                chemin = chemin + "                                                                                                                         ";
                int nb = chemin.Trim().Length - USM.Name.Length;
                if (nb > 0)
                    nb -= 1;
                chemin = chemin.Substring(0, nb).Trim();
            }
        }

        private void genererMenuChemin()
        {
            dgv_ListeDroit.Rows.Clear();
            if (rmi_Menu != null)
            {
                foreach (RadMenuItem unmenu in rmi_Menu.Items)
                {
                    constituerMenu(unmenu);
                }
                chemin = string.Empty;
            }
            if (rmi_Menu2 != null)
            {
                foreach (RadMenuItem unmenu in rmi_Menu2.Items)
                {
                    constituerMenu(unmenu);
                }
                chemin = string.Empty;
            }
            if (rmi_Menu3 != null)
            {
                foreach (RadMenuItem unmenu in rmi_Menu3.Items)
                {
                    constituerMenu(unmenu);
                }
                chemin = string.Empty;
            }
        }

        #endregion

        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }
        #endregion Autres

        #region Formulaire

        public Frm_UserManager(string theme, RadMenu rmi, RadMenu rmi2, RadMenu rmi3)
        {
            InitializeComponent();
            this.ThemeName = theme;
            rmi_Menu = rmi;
            rmi_Menu2 = rmi2;
            rmi_Menu3 = rmi3;
        }

        private void Frm_UserManager_Load(object sender, EventArgs e)
        {
            dtp_DateDeb.Value = DateTime.Now;
            dtp_DateFin.Value = DateTime.Now;
            estChargement = true;

            activerDesactiverControleFormUtilisateur(false);
            activerDesactiverControleProfil(false);
            activerDesactiverControleDroit(false);

            chargerListedesDroits();
            ChargerListeProfil(null);
            ChargerListe(null);

            if (nouveauProfil)
                btn_Nouveau_Click(null, null);
            else if (nouveauUtil)
                btn_nouveauUtil_Click(null, null); 

            //***********************************code lié au formulaire JournalConnexion

            dgv_ListeDroit_SelectionChanged(null, null);
            estChargement = false;
            
        }

        #endregion  Formulaire

        #region Bouton de commande formulaire profil

        public void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveauProfil = true;
            RAZProfil();
            activerDesactiverControleProfil(true);
            txt_CodeProfil.Focus();
        }

        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (dgv_listeProfil.SelectedRows != null && 
                dgv_listeProfil.SelectedRows.Count > 0)
            {
                activerDesactiverControleProfil(true);
                txt_libelleProfil.Focus();
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez selectioner une ligne " +
                    "avant d'entamer la modification."
                    ,"USER MANAGER", MessageBoxButtons.OK,RadMessageIcon.Error);
            }
        }

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            if (dgv_listeProfil.SelectedRows != null &&
                dgv_listeProfil.SelectedRows.Count > 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne sélectionnée"
                    , "USER MANAGER", MessageBoxButtons.YesNo,RadMessageIcon.Question) == 
                    DialogResult.Yes)
                {
                    Profil obj = (Profil)bds_profil.Current;
                    string res = obj.Delete();
                    message = Tools.SplitMessage(res);
                    if (int.Parse(message[0]) > 0)
                    {
                        ChargerListeProfil((Profil)bds_profil.Current);
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), "USER MANAGER",
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    else
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        MessageBox.Show(this, message[3].Trim(), "USER MANAGER",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner la ligne à supprimer.","USER MANAGER", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            activerDesactiverControleProfil(false);
            nouveauProfil = false;
            RAZProfil();
            ChargerListeProfil((Profil)bds_profil.Current);
        }
     
        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            Profil objPro = new Profil();

            #region controle de saisie

            if (txt_CodeProfil.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du code est obligatoire.", "USER MANAGER",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_CodeProfil.Focus();
                return;
            } 
            
            if (txt_libelleProfil.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du libelle est obligatoire.", 
                    "USER MANAGER",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_libelleProfil.Focus();
                return;
            }

            trouve = false;//remettre la valeur par défaut
            for (int i = 0; i < dgv_profilDroit.Rows.Count; i++)
            {
                if (Convert.ToBoolean(
                    dgv_profilDroit.Rows[i].Cells["chk_choix"].Value))
                {
                    trouve = true; //ca veut dire qu'une case a été coché
                    break;
                }
            }

            if (!trouve)
            {// si aucune case n'est coché
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Attention aucun droit n'est attribué à ce profil", 
                    "USER MANAGER", MessageBoxButtons.OK,
                RadMessageIcon.Error);
                return;
            }

            #endregion

            #region Enregistrement
            if (nouveauProfil)
            {
                constituerObjetProfil(objPro);
                sortie = objPro.Insert();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    objPro.NumLigne = int.Parse(message[message.Length - 1].Trim());
                     //enregistrement des droits séléctionnés
                    for (int i = 0; i < dgv_profilDroit.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgv_profilDroit.Rows[i].Cells["chk_choix"].Value.ToString()) == true)
                        {// si la case de choix a été coché alors

                            ProfilDroit objBP = new ProfilDroit();
                            objBP.CodeProfil = objPro.CodeProfil;
                            objBP.CodeDroit =
                                dgv_profilDroit.Rows[i].Cells["CodeDroit"].Value.ToString();
                            objBP.Creation =
                                Convert.ToBoolean(dgv_profilDroit.Rows[i].Cells[
                                "Creation"].Value.ToString());
                            objBP.Modification = 
                                Convert.ToBoolean(dgv_profilDroit.Rows[i].Cells[
                                "Modification"].Value.ToString());
                            objBP.Suppression = 
                                Convert.ToBoolean(dgv_profilDroit.Rows[i].Cells[
                                "Suppression"].Value.ToString());

                            string r = objBP.Insert();
                        }
                    }
                    activerDesactiverControleProfil(false);
                    nouveauProfil = false;
                    ChargerListeProfil(objPro);
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this,
                    message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(),
                    "USER MANAGER", MessageBoxButtons.OK,
                    message[message.Length - 1].Trim() != "" ?
                        RadMessageIcon.Info : RadMessageIcon.Error);
            }
            #endregion

            #region Modification
            else
            {
                objPro = (Profil)bds_profil.Current;
                constituerObjetProfil(objPro);
                sortie = objPro.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {

                    //suppression de tous les anciens droits
                    ProfilDroit.DeleteAll(objPro.CodeProfil);
   
                    //enregistrement des droits séléctionnés
                    for (int i = 0; i < dgv_profilDroit.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(
                            dgv_profilDroit.Rows[i].Cells["chk_choix"].Value.ToString()) == true)                                       
                        {// si la case de choix a été coché alors

                            ProfilDroit objBP = new ProfilDroit();
                            objBP.CodeProfil = objPro.CodeProfil;
                            objBP.CodeDroit = 
                                dgv_profilDroit.Rows[i].Cells["CodeDroit"].Value.ToString();
                            objBP.Creation = 
                                Convert.ToBoolean(dgv_profilDroit.Rows[i].Cells[
                                "Creation"].Value.ToString());
                            objBP.Modification = 
                                Convert.ToBoolean(dgv_profilDroit.Rows[i].Cells[
                                "Modification"].Value.ToString());
                            objBP.Suppression = 
                                Convert.ToBoolean(dgv_profilDroit.Rows[i].Cells[
                                "Suppression"].Value.ToString());
                            string r = objBP.Insert();                    
                        }                      
                    }
                    activerDesactiverControleProfil(false);
                    ChargerListeProfil(objPro);
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() :
                    message[3].Trim()
                , "USER MANAGER", MessageBoxButtons.OK,
                message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info :
                RadMessageIcon.Error);
            }
            #endregion 

        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            ChargerListeProfil(null);
        }

        #endregion 

        #region Bouton de commande formulaire utilisateur

        private void btn_nouveauUtil_Click(object sender, EventArgs e)
        {
            nouveauUtil = true;
            RAZFormUtilisateur();
            activerDesactiverControleFormUtilisateur(true);
            txt_nomUtil.Focus();
            txt_typeUtil.Text = "SIMPLE";
        }

        private void btn_modifierUtil_Click(object sender, EventArgs e)
        {
            if (dgv_ListeUtil.SelectedRows != null && dgv_ListeUtil.SelectedRows.Count > 0)
            {
                activerDesactiverControleFormUtilisateur(true);
                txt_nomUtil.Focus();
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez selectioner une ligne " +
                    "avant d'entamer la modification.",
                    "USER MANAGER", MessageBoxButtons.OK,
                    RadMessageIcon.Error);
            }
        }

        private void btn_supprimerUtil_Click(object sender, EventArgs e)
        {
            if (dgv_ListeUtil.SelectedRows != null &&
                           dgv_ListeUtil.SelectedRows.Count > 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne " +
                    "sélectionnée", "OPTICA", MessageBoxButtons.YesNo,
                    RadMessageIcon.Question) == DialogResult.Yes)
                {
                    Utilisateur obj = (Utilisateur)bds_Utilisateur.Current;
                    string res = obj.Delete();
                    message = Tools.SplitMessage(res);
                    if (int.Parse(message[0]) > 0)
                    {
                        ChargerListe((Utilisateur)bds_Utilisateur.Current);
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show(this, message[3].Trim(), "OPTICA",
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    else
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        MessageBox.Show(this, message[3].Trim(), "OPTICA",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner la ligne à supprimer.",
                    "OPTICA", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_ActualiserUtil_Click(object sender, EventArgs e)
        {
            ChargerListe(null);
        }

        private void btn_anuulerUtil_Click(object sender, EventArgs e)
        {
            nouveauUtil = false;
            activerDesactiverControleFormUtilisateur(false);
            RAZFormUtilisateur();
            ChargerListe((Utilisateur)bds_Utilisateur.Current);
        }

        private void btn_enregistrerUtil_Click(object sender, EventArgs e)
        {
            Utilisateur obj = new Utilisateur();

            #region controle de saisie

            if (txt_nomUtil.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du nom est obligatoire.", "USER MANAGER",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_nomUtil.Focus();
                return;
            }

            if (txt_prenomUtil.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du prénom est obligatoire.", "USER MANAGER",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_prenomUtil.Focus();
                return;
            }

            if (cb_sexeUtil.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du sexe est obligatoire.", "USER MANAGER",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                cb_sexeUtil.Focus();
                return;
            }

            if (txt_mailUtil.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du mail est obligatoire.",
                    "USER MANAGER", MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_mailUtil.Focus();
                return;
            }

            if (txt_loginUtil.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du Login est obligatoire.",
                    "USER MANAGER", MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_loginUtil.Focus();
                return;
            }

            if (txt_pwdUtil.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du mot de passe est obligatoire.",
                    "USER MANAGER", MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_pwdUtil.Focus();
                return;
            }

            if (txt_comfirmation.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez confirmer le mot de passe.",
                    "USER MANAGER", MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_comfirmation.Focus();
                return;
            }

            if (txt_pwdUtil.Text.Trim() != txt_comfirmation.Text.Trim())
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, 
                    "Attention, Veuillez revoir la confirmation du mot de passe  ",
                    "USER MANAGER", MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_comfirmation.Text = "";
                txt_comfirmation.Focus();
                return;
            }

            trouve = false;//remettre la valeur par défaut
            for (int i = 0; i < dgv_ProfilUtil.Rows.Count; i++)
            {
                if (Convert.ToBoolean(
                        dgv_ProfilUtil.Rows[i].Cells["chk_choixProfil"].Value.ToString()))
                {
                    trouve = true; //ca veut dire qu'une case a été coché
                    break;
                }
            }

            if (trouve == false)
            {// si aucune case n'est coché
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Attention aucun Profil n'est attribué à ce Utilisateur", "USER MANAGER", MessageBoxButtons.OK,
                RadMessageIcon.Error);
                return;
            }
            #endregion

            #region Enregistrement
            if (nouveauUtil)
            {
                constituerObjet(obj);
                sortie = obj.Insert();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    cheminFichier = CurrentUser.ImagePath + "\\" +
                        txt_nomUtil.Text.Trim().Substring(0, 4) + 
                        txt_prenomUtil.Text.Trim().Substring(0, 4) + "(" +
                        obj.NumLigne.ToString() + ").jpg";
                    //sauvegarde de la tof de l'utilisateur
                    try  
                    {
                        if (pnl_photo.BackgroundImage != null)
                        {
                            if (File.Exists(cheminFichier.Trim()))
                            {
                                File.Delete(cheminFichier.Trim());
                            }
                            pnl_photo.BackgroundImage.Save(cheminFichier.Trim());
                        }
                    }
                    catch
                    {
                    }
                    //enregistrement des profils de l'utilisateur
                    for (int i = 0; i < dgv_ProfilUtil.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(
                            dgv_ProfilUtil.Rows[i].Cells["chk_choixProfil"].Value.ToString()))
                        {
                            UtilisateurProfil objBP = new UtilisateurProfil();
                            objBP.NumeroUtilisateur = obj.NumLigne;
                            objBP.CodeProfil = 
                                dgv_ProfilUtil.Rows[i].Cells["CodeProfil"].Value.ToString();
                            string r = objBP.Insert();
                        }
                    }
                    activerDesactiverControleFormUtilisateur(false);
                    ChargerListe(obj);
                    nouveauUtil = false;
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), 
                    "USER MANAGER", MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }
            #endregion

            #region Modification
            else
            {
                obj = (Utilisateur)bds_Utilisateur.Current;
                constituerObjet(obj);
                sortie = obj.Update();
                message = Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    //sauvegarde de la tof de l'utilisateur
                    cheminFichier = CurrentUser.ImagePath + "\\" +
                        txt_nomUtil.Text.Trim().Substring(0, 4) +
                        txt_prenomUtil.Text.Trim().Substring(0, 4) + "(" +
                        obj.NumeroUtilisateur.ToString() + ").jpg";
                    //sauvegarde de la tof de l'utilisateur
                    try
                    {
                        if (pnl_photo.BackgroundImage != null)
                        {
                            if (File.Exists(cheminFichier.Trim()))
                            {
                                File.Delete(cheminFichier.Trim());
                            }
                            pnl_photo.BackgroundImage.Save(cheminFichier.Trim());
                        }
                    }
                    catch
                    {
                    }
                    //suppression des anciens produits de la commande encours de modification
                    UtilisateurProfil.DeleteAll(obj.NumeroUtilisateur);

                    //enregistrement des profils de l'utilisateur
                    for (int i = 0; i < dgv_ProfilUtil.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(
                            dgv_ProfilUtil.Rows[i].Cells["chk_choixProfil"].Value.ToString()))
                        {
                            UtilisateurProfil objBP = new UtilisateurProfil();
                            objBP.NumeroUtilisateur = obj.NumeroUtilisateur;
                            objBP.CodeProfil = 
                                dgv_ProfilUtil.Rows[i].Cells["CodeProfil"].Value.ToString();
                            string r = objBP.Insert();
                        }
                    }

                    affichage = false;// permet d'exécuter le seletedChanged
                    activerDesactiverControleFormUtilisateur(false);
                    ChargerListe(obj);
                }
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), 
                    "USER MANAGER", MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);
            }

            #endregion
        }
      
        private void btn_AddPhoto_Click(object sender, EventArgs e) 
        {
            if (!txt_prenomUtil.ReadOnly)
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
        #endregion

        #region Bouton de commande formulaire Journal

        private void btn_Afficher_Click(object sender, EventArgs e)
        {
            //simple
            lstJournalConnexion = JournalConnexion.Liste(
                null, null, null, null, null,
                dtp_DateDeb.Value, dtp_DateFin.Value, 
                null, null, null, null, null,
                null, null, false, null);
            bds_journalConnexion.DataSource = lstJournalConnexion;
            //par utilisateur
            estChargementUtilPU = true;
            bds_utilPourJournConPU.DataSource = JournalConnexion.ListeUtilisateur(dtp_DateDeb.Value, dtp_DateFin.Value);
            estChargementUtilPU = false;
            dgv_utilJournConPU_SelectionChanged(null, null);
            //par date
            estChargementDatePD = true;
            bds_DatePourJournCon.DataSource = JournalConnexion.ListeDate(dtp_DateDeb.Value, dtp_DateFin.Value);
            estChargementDatePD = false;
            dgv_dateConnexion_SelectionChanged(null, null);
        }

        #endregion

        #region Bouton de commande formulaire droit
        private void btn_NouveauDroit_Click(object sender, EventArgs e)
        {
            nouveauDroit = true;
            genererMenuChemin();
            dgv_ProfilsDunDroit.Rows.Clear();
            dgv_UtilisateurDunDroit.Rows.Clear();
            activerDesactiverControleDroit(true);
            dgv_ListeDroit.Focus();
        }

        private void btn_ModifierDroit_Click(object sender, EventArgs e)
        {
            if (dgv_ListeDroit.Rows != null &&
                dgv_ListeDroit.Rows.Count > 0)
            {
                nouveauDroit = false;
                activerDesactiverControleDroit(true);
                dgv_ListeDroit.Focus();
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Aucune donnée à modifier."
                    , CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btn_EnregistrerDroit_Click(object sender, EventArgs e)
        {
            if (dgv_ListeDroit.Rows.Count == 0)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Aucune donnée à enregistrer."
                    , CurrentUser.LogicielHote, MessageBoxButtons.OK, 
                    RadMessageIcon.Error);
                return;
            }
            if (nouveauDroit)
            {
                for (int i = 0; i < dgv_ListeDroit.Rows.Count; i++)
                {
                    Droit obj = new Droit();
                    obj.CheminMenu = 
                        dgv_ListeDroit.Rows[i].Cells["chemin"].Value.ToString().Trim();
                    obj.CodeDroit = 
                        dgv_ListeDroit.Rows[i].Cells["CodeDroit"].Value.ToString().Trim();
                    obj.DegreSensibilite =
                        dgv_ListeDroit.Rows[i].Cells["degreSensibilite"].Value.ToString().Trim();
                    obj.EstSensible =
                        Convert.ToBoolean(dgv_ListeDroit.Rows[i].Cells["EstSensible"].Value);
                    obj.LibelleDroit = 
                        dgv_ListeDroit.Rows[i].Cells["LibelleDroit"].Value.ToString().Trim();
                    obj.NomFormulaire = 
                        dgv_ListeDroit.Rows[i].Cells["NomFormulaire"].Value.ToString().Trim();
                    string r=obj.Insert();
                }
            }
            else
            {
                for (int i = 0; i < dgv_ListeDroit.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dgv_ListeDroit.Rows[i].Cells["estModifiee"].Value) == 1)
                    {
                        Droit obj = lstDroit.Find(l=>l.CodeDroit.Trim() ==
                            dgv_ListeDroit.Rows[i].Cells["CodeDroit"].Value.ToString().Trim());
                        obj.DegreSensibilite =
                            dgv_ListeDroit.Rows[i].Cells["degreSensibilite"].Value.ToString().Trim();
                        obj.EstSensible =
                            Convert.ToBoolean(dgv_ListeDroit.Rows[i].Cells["EstSensible"].Value);
                        obj.LibelleDroit =
                            dgv_ListeDroit.Rows[i].Cells["LibelleDroit"].Value.ToString().Trim();
                        string res = obj.Update();
                    }
                }
            }
            activerDesactiverControleDroit(false);
            chargerListedesDroits();
            RadMessageBox.Show(this, "Opération effectuée avec succès."
                    , CurrentUser.LogicielHote, MessageBoxButtons.OK,
                    RadMessageIcon.Info);
        }

        private void btn_annulerDroit_Click(object sender, EventArgs e)
        {
            nouveauDroit = false;
            activerDesactiverControleDroit(false);
            chargerListedesDroits();
        }
        #endregion

        #region check_box

        private void chk_ElementSelection_ToggleStateChanged(object sender,
            Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            //permet d'afficher uniquement les éléments séléctionnés
            if (chk_ElementSelection.IsChecked == true)
            {
                for (int i = 0; i < dgv_profilDroit.Rows.Count; i++)
                {
                    if (dgv_profilDroit.Rows[i].Cells["chk_choix"].Value == null ||
                        !Convert.ToBoolean(dgv_profilDroit.Rows[i].Cells["chk_choix"].Value))
                    {
                        dgv_profilDroit.Rows[i].IsVisible = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dgv_profilDroit.Rows.Count; i++)
                {
                    dgv_profilDroit.Rows[i].IsVisible = true;
                }
            }
        }

        private void chk_selectTout_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            for (int i = 0; i < dgv_profilDroit.Rows.Count; i++)
            {
                dgv_profilDroit.Rows[i].Cells["chk_choix"].Value = chk_selectTout.Checked;
                dgv_profilDroit.Rows[i].Cells["Creation"].Value = chk_selectTout.Checked;
                dgv_profilDroit.Rows[i].Cells["Modification"].Value = chk_selectTout.Checked;
                dgv_profilDroit.Rows[i].Cells["Suppression"].Value = chk_selectTout.Checked;
            }
        }
        #endregion

        #region DataGridView

        private void dgv_listeProfil_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_listeProfil.SelectedRows != null &&
                dgv_listeProfil.SelectedRows.Count > 0)
            {
                detaillerObjetProfil((Profil)bds_profil.Current);
            }
            else
            {
                RAZProfil();
            }
        }

        private void dgv_ListeUtil_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeUtil.SelectedRows != null &&
              dgv_ListeUtil.SelectedRows.Count > 0)
            {
                detaillerObjet((Utilisateur)bds_Utilisateur.Current);
                
            }
            else
            {
                RAZFormUtilisateur();
            }
        }
      
        private void dgv_ListeProfilFormUtil_CommandCellClick(object sender, EventArgs e)
        {
            //permet de récuperer l'index de la ligne ou le bouton a été appuyer
            GridCommandCellElement clck = sender as GridCommandCellElement;  
            
            //permet de cocher ou de décocher la case qui est sur la meme ligne que le bouton
            dgv_ProfilUtil.Rows[clck.RowIndex].Cells["chk_choixProfil"].Value =
                !Convert.ToBoolean(
                dgv_ProfilUtil.Rows[clck.RowIndex].Cells["chk_choixProfil"].Value.ToString());

            showDroitReel();
            
        }  

        private void dgv_profilDroit_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name.ToLower() == "chk_choix")
            {
                //***********Code modifié par husni le 10/06/2015 pour corriger le problème d'activation et désactivation automatique

                //if (!Convert.ToBoolean(
                //    dgv_profilDroit.Rows[e.ColumnIndex].Cells["chk_choix"].Value))
                //if (!Convert.ToBoolean(
                //    dgv_profilDroit.Rows[e.RowIndex].Cells["chk_choix"].Value))
                //{
                    //dgv_profilDroit.Rows[e.RowIndex].Cells["Creation"].Value = false;
                    //dgv_profilDroit.Rows[e.RowIndex].Cells["Modification"].Value = false;
                    //dgv_profilDroit.Rows[e.RowIndex].Cells["Suppression"].Value = false;

                dgv_profilDroit.Rows[e.RowIndex].Cells["Creation"].Value = dgv_profilDroit.Rows[e.RowIndex].Cells["chk_choix"].Value;
                dgv_profilDroit.Rows[e.RowIndex].Cells["Modification"].Value = dgv_profilDroit.Rows[e.RowIndex].Cells["chk_choix"].Value;
                dgv_profilDroit.Rows[e.RowIndex].Cells["Suppression"].Value = dgv_profilDroit.Rows[e.RowIndex].Cells["chk_choix"].Value;


                //}
            }
            else if (e.Column.Name.ToLower() == "creation" ||
                     e.Column.Name.ToLower() == "modification" ||
                     e.Column.Name.ToLower() == "suppression")
            {
                if(Convert.ToBoolean(dgv_profilDroit.Rows[e.RowIndex].Cells["Creation"].Value)||
                    Convert.ToBoolean(dgv_profilDroit.Rows[e.RowIndex].Cells["Modification"].Value)||
                    Convert.ToBoolean(dgv_profilDroit.Rows[e.RowIndex].Cells["Suppression"].Value) )
                {
                    dgv_profilDroit.Rows[e.RowIndex].Cells["chk_choix"].Value = true;
                }

                else
                {

                    dgv_profilDroit.Rows[e.RowIndex].Cells["chk_choix"].Value =false;
                }


            }
        }

        private void dgv_ListeDroit_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            dgv_ListeDroit.Rows[e.RowIndex].Cells["estModifiee"].Value = 1;
            if (e.Column.Name.ToLower() == "estsensible")
            {
                if (Convert.ToDecimal(
                       dgv_ListeDroit.Rows[e.RowIndex].Cells[
                               "degreSensibilite"].Value.ToString().Trim()) == 0 &&
                   Convert.ToBoolean(dgv_ListeDroit.Rows[e.RowIndex].Cells["EstSensible"].Value))
                {
                    dgv_ListeDroit.Rows[e.RowIndex].Cells["degreSensibilite"].Value = 1;
                }
                else if (Convert.ToDecimal(
                       dgv_ListeDroit.Rows[e.RowIndex].Cells[
                               "degreSensibilite"].Value.ToString().Trim()) != 0 &&
                   !Convert.ToBoolean(dgv_ListeDroit.Rows[e.RowIndex].Cells["EstSensible"].Value))
                {
                    dgv_ListeDroit.Rows[e.RowIndex].Cells["degreSensibilite"].Value = 0;
                }
            }
            else if (e.Column.Name.ToLower() == "degresensibilite")
            {
                if (Convert.ToDecimal(
                        dgv_ListeDroit.Rows[e.RowIndex].Cells[
                                "degreSensibilite"].Value.ToString().Trim()) > 0)
                {
                    dgv_ListeDroit.Rows[e.RowIndex].Cells["EstSensible"].Value = true;
                }
                else if (Convert.ToDecimal(
                        dgv_ListeDroit.Rows[e.RowIndex].Cells[
                                "degreSensibilite"].Value.ToString().Trim()) == 0)
                {
                    dgv_ListeDroit.Rows[e.RowIndex].Cells["EstSensible"].Value = false;
                }
            }
        }

        private void dgv_ListeDroit_SelectionChanged(object sender, EventArgs e)
        {
            if (!estChargementDroit)
            {
                dgv_ProfilsDunDroit.Rows.Clear();
                dgv_UtilisateurDunDroit.Rows.Clear();
                if (dgv_ListeDroit.SelectedRows != null &&
                    dgv_ListeDroit.SelectedRows.Count != 0)
                {
                    List<ProfilDroit> lst = ProfilDroit.ProfilByDroit(
                        dgv_ListeDroit.SelectedRows[0].Cells["codeDroit"].Value.ToString().Trim());
                    foreach (ProfilDroit obj in lst)
                    {
                        dgv_ProfilsDunDroit.Rows.Add(obj.LibelleProfil.Trim(),
                            obj.Creation, obj.Modification, obj.Suppression);
                    }

                    //affichage des utilisateurs du droit
                    List<ProfilDroit> lstPD = ProfilDroit.UtilisateurByDroit(
                        dgv_ListeDroit.SelectedRows[0].Cells["codeDroit"].Value.ToString().Trim());
                    foreach (ProfilDroit obj in lstPD)
                    {
                        dgv_UtilisateurDunDroit.Rows.Add(obj.LibelleDroit.Trim(),
                            obj.Creation, obj.Modification, obj.Suppression);
                    }
                }
            }
        }

        private void dgv_utilJournConPU_SelectionChanged(object sender, EventArgs e)
        {
            if (!estChargementUtilPU)
            {
                if (dgv_utilJournConPU.SelectedRows != null &&
                        dgv_utilJournConPU.SelectedRows.Count != 0)
                {
                    bds_journalConnexionPU.DataSource = JournalConnexion.Liste(
                    null, Convert.ToDecimal(dgv_utilJournConPU.SelectedRows[0].Cells["NumeroUtilisateur"].Value),
                    null, null, null,
                    dtp_DateDeb.Value, dtp_DateFin.Value,
                    null, null, null, null, null,
                    null, null, false, null);
                }
                else
                {
                    bds_journalConnexionPU.DataSource = new List<JournalConnexion>();
                }
            }
        }

        private void dgv_utilJournConPD_SelectionChanged(object sender, EventArgs e)
        {
            if (!estChargementUtilPD)
            {
                if (dgv_utilJournConPD.SelectedRows != null &&
                        dgv_utilJournConPD.SelectedRows.Count != 0)
                {
                    bds_journalConnexionPD.DataSource = JournalConnexion.Liste(
                    null, Convert.ToDecimal(dgv_utilJournConPD.SelectedRows[0].Cells["NumeroUtilisateur"].Value),
                    null, null, null,
                    Convert.ToDateTime(dgv_dateConnexion.SelectedRows[0].Cells["DateDebCon"].Value).Date,
                    Convert.ToDateTime(dgv_dateConnexion.SelectedRows[0].Cells["DateDebCon"].Value).Date,
                    null, null, null, null, null,
                    null, null, false, null);
                }
                else
                {
                    bds_journalConnexionPD.DataSource = new List<JournalConnexion>();
                }
            }
        }

        private void dgv_dateConnexion_SelectionChanged(object sender, EventArgs e)
        {
            if (!estChargementDatePD)
            {
                if (dgv_dateConnexion.SelectedRows != null &&
                        dgv_dateConnexion.SelectedRows.Count != 0)
                {
                    estChargementUtilPD = true;
                    bds_utilPourJournConPD.DataSource = JournalConnexion.ListeUtilisateur(
                        Convert.ToDateTime(dgv_dateConnexion.SelectedRows[0].Cells["DateDebCon"].Value).Date,
                        Convert.ToDateTime(dgv_dateConnexion.SelectedRows[0].Cells["DateDebCon"].Value).Date);
                    estChargementUtilPD = false;
                    dgv_utilJournConPD_SelectionChanged(null, null);
                }
                else
                {
                    bds_utilPourJournConPD.DataSource = new List<JournalConnexion>();
                    bds_journalConnexionPD.DataSource = new List<JournalConnexion>();
                }
            }
        }
        #endregion

        #region datetimepicker
        private void dtp_DateDeb_ValueChanged(object sender, EventArgs e)
        {
            bds_journalConnexion.DataSource = new List<JournalConnexion>();

            bds_journalConnexionPU.DataSource = new List<JournalConnexion>();
            bds_utilPourJournConPU.DataSource = new List<JournalConnexion>();

            bds_DatePourJournCon.DataSource = new List<JournalConnexion>();
            bds_utilPourJournConPD.DataSource = new List<JournalConnexion>();
            bds_journalConnexionPD.DataSource = new List<JournalConnexion>();
        }
        #endregion

        #region groupbox
        private void gb_detailProfil_Resize(object sender, EventArgs e)
        {
            try
            {
                txt_libelleProfil.Width = gb_detailProfil.Width - 265;
            }
            catch
            {
            }
        } 
        #endregion

        
    }
}
