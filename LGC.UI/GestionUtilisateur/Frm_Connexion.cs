// Website : http://www.google.bj

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using BS.Business;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Localization;
using LGC.Business.GestionUtilisateur;
using LGC.Business;
using LGC.Business.Parametre;
//using LGC.UI; 
//using LGC.Business.Parametre;

namespace LGC.UI.GestionUtilisateur
{
    public partial class Frm_Connexion : RadForm
    {
        #region declaration
        List<Utilisateur> LstU;
        string mode = "NewCon";
        private bool gere = true;
        public bool connexionReussie = false;
        public List<Societe> lstSociete = new List<Societe>();
        #endregion

        #region autres
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        } 
        #endregion

        #region formulaire
        public Frm_Connexion(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
            RadGridLocalizationProvider.CurrentProvider = new FrenchRadGridLocalizationProvider();
        }

        public Frm_Connexion(string mModeConnexion, string theme)
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new FrenchRadGridLocalizationProvider();
            mode = mModeConnexion;
            this.ThemeName = theme;
        }

        private void Frm_connexion_Load(object sender, EventArgs e)
        {
            if (mode == "NewCon")
            {
                LstU = Utilisateur.Liste(null, null, null, null,
                        null, null, null, true, null, null, null,null,
                        null, null, null, null, null, false, null);
                bds_utilisateur.DataSource = LstU;
                cb_Utilisateur.Text = "";//a remettre en place avant genration
                //cb_Utilisateur.Text = "dorilas";
                //txt_MotDePasse.Text = "dorilas";
                lbl_NomServeur.Text = CurrentUser.NomServeurProduction.ToUpper();
            }
            else
            {
                cb_Utilisateur.Text = CurrentUser.OUtilisateur.Login.Trim();
                cb_Utilisateur.Enabled = false;
            }
        }

        private void Frm_connexion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mode != "NewCon" && gere)
            {
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this,
                    "Si vous fermer cette fenêtre, l'application va se fermer.\n" +
                    "Voulez-vous continuer?", "", MessageBoxButtons.YesNo,
                    RadMessageIcon.Question) == DialogResult.Yes)
                {
                    connexionReussie=false;
                }
                else
                    e.Cancel = true;
            }
        }
        #endregion

        #region Bouton de commande
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (mode != "NewCon")
            {
                if (CurrentUser.OUtilisateur.Password.Trim() != 
                    Tools.HashWithMD5(txt_MotDePasse.Text.Trim()) )
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show("Mot de passe incorrect ! ", CurrentUser.LogicielHote, 
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
                else
                {
                    connexionReussie = true;
                    gere = false;
                    this.Close();
                }
                return;
            }
            Utilisateur Utu = new Utilisateur();

            if (((cb_Utilisateur.Text == string.Empty) 
                && (txt_MotDePasse.Text == string.Empty)))
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show("Veullez renseigner les champs vides",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Info);
                this.Close();
                return;
            }
            else
            {
                Utu = LstU.Find(delegate(Utilisateur oUtilisateur)
                {
                    if (oUtilisateur.Login.Trim() == cb_Utilisateur.Text.Trim())
                        return true;
                    else
                        return false;
                }
                 );
                if (Utu == null)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show("Cet utilisateur n'est pas dans le système.\n"+
                        "Prière vous faire enregistrer", CurrentUser.LogicielHote, 
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
                else
                {
                    if (!Utu.EstActif)
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show("Cet utilisateur n'est pas dans le système, "+
                            "prière vous faire enregistrer", CurrentUser.LogicielHote, 
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }
                    else if (Utu.Password.Trim() != 
                        Tools.HashWithMD5( txt_MotDePasse.Text.Trim()))
                    {
                        RadMessageBox.ThemeName = this.ThemeName;
                        RadMessageBox.Show("Mot de passe incorrect ! ",
                            CurrentUser.LogicielHote, 
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }
                    else
                    {
                        string pcid = "";
                        List<ShowMacPc> lstMc = ShowMacPc.Liste();
                        if (lstMc != null && lstMc.Count != 0)
                        {
                            pcid = lstMc[0].MacAdres.Trim();
                        }
                        connexionReussie = true;
                        CurrentUser.OUtilisateur = Utu;
                        CurrentUser.UserLogin = Utu.Login.Trim();
                        try
                        {
                            CurrentUser.OProfil = Profil.Liste(UtilisateurProfil.Liste(Utu.NumeroUtilisateur, null, null, null, null, null, null, false, null)[0].CodeProfil, null, null, null, null, null, null, null, false, null)[0];
                        }
                        catch { CurrentUser.OProfil = null; }
                        lstSociete = Societe.Liste(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                                                    null, null, null, null, null, null, null, null, null, null, null, false, null);
                        if (lstSociete != null && lstSociete.Count != 0)
                        {
                            CurrentUser.OSociete = (lstSociete[0]);
                        }
                        try
                        {
                            try
                            {
                                if (CurrentUser.OJournalConnexion != null)
                                {
                                    CurrentUser.OJournalConnexion.DateFinCon = DateTime.Now;
                                    CurrentUser.OJournalConnexion.Update();
                                    CurrentUser.OJournalConnexion = null;
                                }
                            }
                            catch
                            {

                            }
                            //journalisation de la connexion
                            CurrentUser.OJournalConnexion = new JournalConnexion();
                            
                            //**********code ajouté par husni le 11/06/2015
                            CurrentUser.OJournalConnexion.AdresseIP = ShowInternetProtocolPC.GetIPaddresses(Environment.MachineName)
                                [ShowInternetProtocolPC.GetIPaddresses(Environment.MachineName).Length - 1].ToString();                      
                            //****fin

                            CurrentUser.OJournalConnexion.AdresseMac = pcid;
                            CurrentUser.OJournalConnexion.DateDebCon = DateTime.Now;
                            CurrentUser.OJournalConnexion.DateFinCon = Convert.ToDateTime("31/12/2050");
                            CurrentUser.OJournalConnexion.NomMachine = Environment.MachineName;
                            CurrentUser.OJournalConnexion.NumeroUtilisateur = Utu.NumeroUtilisateur;
                            CurrentUser.OJournalConnexion.UtilisateurWindows = Environment.UserDomainName + "\\" +
                                Environment.UserName;
                            string r = CurrentUser.OJournalConnexion.Insert();
                            string[]  message = LGC.Business.Tools.SplitMessage(r);
                            if (message[message.Length - 1].Trim() != "")
                            {
                                CurrentUser.OJournalConnexion = JournalConnexion.Liste(
                                    decimal.Parse(message[message.Length - 1].Trim()),
                                    null,null,null,null,null,null,null,
                                    null,null,null,null,null,null,false,null)[0];
                            }
                            else
                            {
                                CurrentUser.OJournalConnexion = null;
                            }
                        }
                        catch 
                        {
                            CurrentUser.OJournalConnexion = null;
                        }
                        this.Close();
                    }
                }
            }
        }
        #endregion
    }
}