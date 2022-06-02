using LGO.Business;
using LGO.Business.GestionUtilisateur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LGO.Business.Parametre;


namespace LGO.UI.GestionUtilisateur
{
    public partial class Frm_ParamEnvoieMail : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        
        string sortie;
        string[] message;
        public List<SocieteDeGestion> lstSociete = new List<SocieteDeGestion>();     
        #endregion

        #region Autre
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }

        private void creerObjet(SocieteDeGestion obj)
        {
            
            obj.Message = txt_Message.Text;
            obj.Email = txt_Mail.Text;
            obj.Message = txt_Message.Text;
            obj.PassWord = Tools.EncryptString(txt_Mdp.Text.Trim(), "abc123deaoezdf77", "abc123deaoezdf78");
            obj.Smtp = txt_Smtp.Text.Trim();
            obj.Port = Convert.ToInt32(msk_port.Value);
            obj.EnableSsl = chk_protocole.Checked;

        }
        #endregion


        private void Detailler(SocieteDeGestion obj)
        {
            CurrentUser.OSociete = obj;
            txt_Mail.Text = obj.Email;
            txt_Mdp.Text = obj.PassWord;
            txt_Smtp.Text = obj.Smtp;
            msk_port.Value = obj.Port;
            chk_protocole.Checked = obj.EnableSsl;
            txt_Message.Text = obj.Message;
            

        }

        public Frm_ParamEnvoieMail(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }

        private void ChargerSociete()
        {
            lstSociete = SocieteDeGestion.Liste(null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null,
                null, null, false, null);
            if (lstSociete != null && lstSociete.Count != 0)
            {
                CurrentUser.OSociete = lstSociete[0];
                Detailler(lstSociete[0]);
            }
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            SocieteDeGestion obj = new SocieteDeGestion();
           #region controle de saisie

           if (txt_Mail.Text.Trim() == "")
           {
               RadMessageBox.ThemeName = this.ThemeName;
               RadMessageBox.Show(this, "La saisie du MAIL est obligatoire",
                   CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
               txt_Mail.Focus();
               return;
           }
           if (txt_Mdp.Text.Trim() == "")
           {
               RadMessageBox.ThemeName = this.ThemeName;
               RadMessageBox.Show(this, "La saisie du MOT DE PASSE est obligatoire",
                   CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
               txt_Mdp.Focus();
               return;
           }
           if (txt_Smtp.Text.Trim() == "")
           {
               RadMessageBox.ThemeName = this.ThemeName;
               RadMessageBox.Show(this, "La saisie du SMTP est obligatoire",
                   CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
               txt_Smtp.Focus();
               return;
           }
           if (msk_port.Text.Trim() == "")
           {
               RadMessageBox.ThemeName = this.ThemeName;
               RadMessageBox.Show(this, "La saisie du PORT est obligatoire",
                   CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
               msk_port.Focus();
               return;
           }
           #endregion

           #region Enregistrement

           lstSociete = SocieteDeGestion.Liste(null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null,
                null, null, false, null);

           if (lstSociete == null || lstSociete.Count == 0)
           {
               RadMessageBox.ThemeName = this.ThemeName;
               RadMessageBox.Show(this, "Veuillez enrégistrer les société d'abord. Merci",
                   CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
               msk_port.Focus();
               return;
           }
           else
           {
               obj = lstSociete[0];
               creerObjet(obj);
               sortie = obj.Update();
               message = Tools.SplitMessage(sortie);

               RadMessageBox.ThemeName = this.ThemeName;
               RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), CurrentUser.LogicielHote,
               MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);

            }
           
           }
           #endregion

        private void Frm_ConfigCheminProfil_Load(object sender, EventArgs e)

        {
            ChargerSociete();
         }
        }
    }

