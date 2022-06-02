using LGC.Business;
using LGC.Business.GestionUtilisateur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LGC.Business.Parametre;
using Telerik.WinControls.UI;


namespace LGC.UI.Parametre
{
    public partial class Frm_ParamCodeBarre : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        
        string sortie;
        string[] message;
        public List<CodeBarre> lstCodeBarre = new List<CodeBarre>();     
        #endregion

        #region Autre
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
            Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(this, this.ThemeName);
        }

        private void creerObjet(CodeBarre obj)
        {
            
            obj.Encoder = cb_encoder.Text.Trim();
            obj.DatedebutUtilisation = DateTime.Now;
            obj.DatedebutFinUtilisation = Convert.ToDateTime("01/01/2050");
            obj.ShowTexte = Convert.ToBoolean(chk_showTexte.Checked); ;
            obj.EstCourant = true;
            
        }
        #endregion


        private void Detailler(CodeBarre obj)
        {
           
            cb_encoder.Text = obj.Encoder;
            chk_showTexte.Checked = Convert.ToBoolean(obj.ShowTexte.ToString());
             

        }

        public Frm_ParamCodeBarre(string theme)
        {
            InitializeComponent();
            this.ThemeName = theme;
        }

        private void ChargerCodeBarre()
        {
            lstCodeBarre = CodeBarre.Liste(null, null, null, true, null, null, null, null, null, null,null, false, null);
            if (lstCodeBarre != null && lstCodeBarre.Count != 0)
            {
               Detailler(lstCodeBarre[0]);
            }
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            CodeBarre obj = new CodeBarre();
           #region controle de saisie

           if (cb_encoder.Text.Trim() == "")
           {
               RadMessageBox.ThemeName = this.ThemeName;
               RadMessageBox.Show(this, "La selection de l'Encoder est obligatoire",
                   CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
               cb_encoder.Focus();
               return;
           }
           
           #endregion

           #region Enregistrement
                
            creerObjet(obj);
               sortie = obj.Insert();
               message = Tools.SplitMessage(sortie);

               RadMessageBox.ThemeName = this.ThemeName;
               RadMessageBox.Show(this, message[3].Trim() == "" ? message[4].Trim() : message[3].Trim(), CurrentUser.LogicielHote,
               MessageBoxButtons.OK, message[message.Length - 1].Trim() != "" ? RadMessageIcon.Info : RadMessageIcon.Error);

            
           
           }
           #endregion

        private void Frm_ConfigCheminProfil_Load(object sender, EventArgs e)

        {
             Telerik.Reporting.Barcodes.Code128Encoder code128Encoder1 = new Telerik.Reporting.Barcodes.Code128Encoder();
             Telerik.Reporting.Barcode.SymbologyType co ;


             cb_encoder.Items.Add("Code128");
             cb_encoder.Items.Add("Codabar");
             cb_encoder.Items.Add("Code11");
             cb_encoder.Items.Add("Code25Standard");
             cb_encoder.Items.Add("Code25Interleaved");
             cb_encoder.Items.Add("Code39");
             cb_encoder.Items.Add("Code39Extended");
             cb_encoder.Items.Add("Code93");
             cb_encoder.Items.Add("Code93Extended");
             cb_encoder.Items.Add("Code128");
             cb_encoder.Items.Add("Code128A");
             cb_encoder.Items.Add("Code128B");
             cb_encoder.Items.Add("Code128C");
             cb_encoder.Items.Add("CodeMSI");
             cb_encoder.Items.Add("EAN8");
             cb_encoder.Items.Add("EAN13");
             cb_encoder.Items.Add("EAN128");
             cb_encoder.Items.Add("EAN128A");
             cb_encoder.Items.Add("EAN128B");
             cb_encoder.Items.Add("EAN128C");
             cb_encoder.Items.Add("Postnet");
             cb_encoder.Items.Add("UPCA");
             cb_encoder.Items.Add("UPCE");
             cb_encoder.Items.Add("UPCSupplement2");
             cb_encoder.Items.Add("UPCSupplement5");
             cb_encoder.Items.Add("QRCode");
             cb_encoder.Items.Add("PDF417");
            
            ChargerCodeBarre();
         }
       }
    }

