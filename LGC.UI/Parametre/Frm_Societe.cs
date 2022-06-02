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
namespace LGC.UI.Parametre
{
    public partial class Frm_Societe : Telerik.WinControls.UI.RadForm
    {
        
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        string[] message;
        List<Societe> lstSociete = new List<Societe>();
        List<Pays> lstPays = new List<Pays>();
        //List<Ville> lstVille = new List<Ville>();
        List<FormeJuridique> lstFormeJuridique = new List<FormeJuridique>();
        string cheminFichier, cheminFichierAdd;
        #endregion

        #region Autres
        private void activerDesactiverControle(bool condition)
        {
            txt_NumAgrement.ReadOnly = !condition;
            txt_Directeur.ReadOnly = !condition;
            dtp_DateAgrement.Enabled = condition; 
            dtp_DateCreation.Enabled = condition;
            meb_tva.ReadOnly = !condition;
            meb_aib.ReadOnly = !condition;
            txt_Capital.ReadOnly=!condition;
            txt_Sigle.ReadOnly=!condition;
            
            txt_Adresse.ReadOnly=!condition;
            txt_RaisonSocial.ReadOnly=!condition;            
            txt_Telephone1.ReadOnly=!condition;
            txt_Telephone2.ReadOnly=!condition;
            txt_Mobile1.ReadOnly=!condition;
            txt_Mobile2.ReadOnly=!condition;
            txt_CodeSkype.ReadOnly=!condition;
            txt_Email.ReadOnly=!condition;
            txt_SiteWeb.ReadOnly=!condition;
            txt_BoitePostale.ReadOnly=!condition;
            //dgv_Liste.Enabled = !condition;
            btn_Annuler.Visible = condition;
            btn_Enregistrer.Visible = condition;
            btn_Nouveau.Visible = !condition;
            btn_Modifier.Visible = !condition;
            btn_Supprimer.Enabled = !condition;
            btn_Importer.Enabled = condition;

            txt_IFU.ReadOnly = !condition;
            txt_Devise.ReadOnly = !condition;
            txt_CompteBancaire.ReadOnly = !condition;
        }

        private void RAZ()
        {
            txt_NumAgrement.Text = "";
            txt_Directeur.Text = "";
            txt_Capital.Text = "";
            txt_Sigle.Text = "";
            meb_aib.Value = 0;
            meb_tva.Value = 0;
            txt_Adresse.Text = "";
            txt_RaisonSocial.Text = "";            
            txt_Telephone1.Text = "";
            txt_Telephone2.Text = "";
            txt_Mobile1.Text = "";
            txt_Mobile2.Text = "";
            txt_CodeSkype.Text = "";
            txt_Email.Text = "";
            txt_SiteWeb.Text = "";
            txt_BoitePostale.Text = "";

            txt_IFU.Text = "";
            txt_Devise.Text = "";
            txt_CompteBancaire.Text = "";
        }

        private void constituerObjet(Societe obj)
        {
            obj.NumAgrement =txt_NumAgrement.Text;
            obj.Directeur = txt_Directeur.Text;
            obj.DateAgrement=dtp_DateAgrement.Value;
            obj.DateCreation=dtp_DateCreation.Value;
            
            obj.Capital=Convert.ToDecimal(txt_Capital.Text);
            obj.Sigle=txt_Sigle.Text ;
            
            obj.Ville="";
            obj.AdresseComplete=txt_Adresse.Text;
            obj.Tva = Convert.ToDecimal(meb_tva.Value);
            obj.Aib = Convert.ToDecimal(meb_aib.Value);
            obj.RaisonSocial=txt_RaisonSocial.Text ;
            
            obj.TelephoneFixe1=txt_Telephone1.Text ;
            obj.TelephoneFixe2=txt_Telephone2.Text ;
            obj.TelephoneMobile1=txt_Mobile1.Text ;
            obj.TelephoneMobile2=txt_Mobile2.Text ;
            obj.Fax = txt_Fax.Text;
            obj.CodeSkype=txt_CodeSkype.Text;
            obj.Email=txt_Email.Text ;
            obj.Siteweb=txt_SiteWeb.Text;
            obj.BoitePostale=txt_BoitePostale.Text ;
            obj.Logo = pnl_photo.BackgroundImage == null ? "" : cheminFichier;

            obj.Ifu = txt_IFU.Text;
            obj.Devise = txt_Devise.Text;
            obj.CompteBancaire = txt_CompteBancaire.Text;
        }

        private void detaillerObjet(Societe obj)
        {
            txt_NumAgrement.Text=obj.NumAgrement.Trim() ;
            txt_Directeur.Text = obj.Directeur.Trim();
            dtp_DateAgrement.Value=obj.DateAgrement;
            dtp_DateCreation.Value=obj.DateCreation;
           
            txt_Capital.Text=obj.Capital.ToString();
            txt_Sigle.Text =obj.Sigle.Trim();
            meb_aib.Value = obj.Aib;
            meb_tva.Value = obj.Tva;
            txt_Adresse.Text=obj.AdresseComplete.Trim();
            txt_RaisonSocial.Text =obj.RaisonSocial.Trim();           
            txt_Telephone1.Text =obj.TelephoneFixe1.Trim();
            txt_Telephone2.Text=obj.TelephoneFixe2.Trim() ;
            txt_Mobile1.Text=obj.TelephoneMobile1.Trim() ;
            txt_Mobile2.Text=obj.TelephoneMobile2.Trim() ;
            txt_Fax.Text = obj.Fax;
            txt_CodeSkype.Text=obj.CodeSkype.Trim();
            txt_Email.Text=obj.Email.Trim() ;
            txt_SiteWeb.Text=obj.Siteweb.Trim();
            txt_BoitePostale.Text=obj.BoitePostale.Trim() ;
            cheminFichier = cheminFichierAdd = CurrentUser.ImagePath + "\\" +
                        "logo_" + "(" + obj.NumLigne.ToString() + ").jpg";

            txt_IFU.Text = obj.Ifu;
            txt_Devise.Text = obj.Devise;
            txt_CompteBancaire.Text = obj.CompteBancaire;

            //permet d'afficher la photo
            if (File.Exists(cheminFichier))
            {
                try
                {
                    FileStream stream = new FileStream(cheminFichier,
                                      FileMode.Open);
                    pnl_photo.BackgroundImage = Image.FromStream(stream);
                    //pnl_photo.BackgroundImage = Image.FromFile(cheminFichier);
                    stream.Close();
                }
                catch
                {
                    pnl_photo.BackgroundImage = null;
                }
            }
            else
            {
                pnl_photo.BackgroundImage = null;
            }

        }

        private void ChargerListe(Societe obj)
        {
            lstSociete = Societe.Liste( null, null,null,null,null,null,null,null,null,null,null,null,null,null,null,
                null,null,null,null,null,null,null,null,
                null, null, null, false, null);
            bds_Societe.DataSource = lstSociete;
            //if (obj != null)
            //{
            //    int i = 0;
            //    foreach (Societe ligne in bds_Societe.List as List<Societe>)
            //    {
            //        if (ligne.NumLigne == obj.NumLigne)
            //        {
            //            bds_Societe.Position = i;
            //            break;
            //        }
            //        else
            //        {
            //            i++;
            //        }
            //    }
            //}
        }

       

        #endregion
        
        #region Formulaire
        public Frm_Societe()
        {
            InitializeComponent();
        }


        private void Frm_Societe_Load(object sender, EventArgs e)
        {
            activerDesactiverControle(false);
            ChargerListe(null);
          
            if (nouveau)
                btn_Nouveau_Click(null, null);
            try
            {
                detaillerObjet((Societe)bds_Societe.Current);
            }
            catch
            {
            }
        }
        #endregion

        #region bouton de commande
        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = true;
            activerDesactiverControle(true);
            RAZ();
            txt_NumAgrement.Focus();
            dtp_DateAgrement.Value = DateTime.Now;
            dtp_DateCreation.Value = DateTime.Now;
        }


        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (bds_Societe.Count!=0)
            {
                nouveau = false;
                activerDesactiverControle(true);
                txt_NumAgrement.Focus();
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez selectioner une ligne " +
                    "avant d'entamer la modification.", CurrentUser.LogicielHote, MessageBoxButtons.OK,
                    RadMessageIcon.Error);
            }
        }

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            try
            {
                RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer ces informations " +
                    "sélectionnée", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                    RadMessageIcon.Question) == DialogResult.Yes)
                {
                    Societe obj = (Societe)bds_Societe.Current;
                    string res = obj.Delete();
                    message =LGC.Business.Tools.SplitMessage(res);
                    if (int.Parse(message[0]) > 0)
                    {
                        ChargerListe((Societe)bds_Societe.Current);
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
            catch
            {
            }
            
        }

        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            nouveau = false;
            RAZ();
            activerDesactiverControle(false);
            ChargerListe((Societe)bds_Societe.Current);
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            Societe obj = new Societe();

            #region controle de saisie
            if (txt_NumAgrement.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du numero d'agrément  est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_NumAgrement.Focus();
                return;
            }

            if (txt_Directeur.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La saisie du directeur  est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                txt_NumAgrement.Focus();
                return;
            }

            

            #endregion

            #region Enregistrement
            if (nouveau)
            {
                constituerObjet(obj);
                sortie = obj.Insert();
                message =LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    #region Enregistrement de l'image
                    if (!Directory.Exists(CurrentUser.ImagePath))
                        Directory.CreateDirectory(CurrentUser.ImagePath);
                    //sauvegarde de la tof de l'utilisateur
                    cheminFichier = CurrentUser.ImagePath + "\\" +
                        "logo_" + "(" + obj.NumLigne.ToString() + ").jpg";
                    try
                    {
                        if (pnl_photo.BackgroundImage != null &&
                            cheminFichierAdd.Trim() != cheminFichier.Trim())
                        {
                            if (File.Exists(cheminFichier.Trim()))
                            {
                                try
                                {
                                    File.Delete(cheminFichier.Trim());

                                }
                                catch { }
                            }
                            pnl_photo.BackgroundImage.Save(cheminFichier.Trim());
                        }
                    }
                    catch { }
                    #endregion

                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    CurrentUser.OSociete = obj;
                    ChargerListe(obj);
                    activerDesactiverControle(false);
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
            }
            #endregion

            #region Modification
            else
            {
                

                obj = (Societe)bds_Societe.Current;
                constituerObjet(obj);
                sortie = obj.Update();
                message =LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    CurrentUser.OSociete = obj;                   

                    #region Modification de l'image
                    if (!Directory.Exists(CurrentUser.ImagePath))
                        Directory.CreateDirectory(CurrentUser.ImagePath);
                    //sauvegarde de la tof de l'utilisateur
                    cheminFichier = CurrentUser.ImagePath + "\\" +
                        "logo_" + "(" + obj.NumLigne.ToString() + ").jpg";
                    try
                    {
                        if (pnl_photo.BackgroundImage != null &&
                            cheminFichierAdd.Trim() != cheminFichier.Trim())
                        {
                            if (File.Exists(cheminFichier.Trim()))
                            {
                                try
                                {
                                    File.Delete(cheminFichier.Trim());

                                }
                                catch { }
                            }
                            pnl_photo.BackgroundImage.Save(cheminFichier.Trim());
                        }
                    }
                    catch { }
                    #endregion

                    activerDesactiverControle(false);
                    nouveau = false;
                    ChargerListe((Societe)bds_Societe.Current);
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
            #endregion
        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            ChargerListe(null);
        }

        private void btn_Importer_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "Fichier image(JPEG)|*.jpg|Fichier image(PNG)|*.png";
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                if (!nouveau)
                {
                    cheminFichierAdd = OpenFile.FileName;
                    pnl_photo.BackgroundImage = Image.FromFile(cheminFichierAdd.Trim());
                }
                else
                {
                    cheminFichier = OpenFile.FileName;
                    pnl_photo.BackgroundImage = Image.FromFile(cheminFichier.Trim());
                }

            }
        }

        private void btn_supPhoto_Click(object sender, EventArgs e)
        {
            pnl_photo.BackgroundImage = null;

            if (File.Exists(cheminFichier.Trim()))
            {
                try
                {
                    File.Delete(cheminFichier.Trim());

                }
                catch { }
            }
        }
        
        #endregion

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

      

        #region DataGridView
        //private void dgv_Liste_Resize(object sender, EventArgs e)
        //{
        //    if (dgv_Liste.Width > 650)
        //    {
        //        dgv_Liste.Columns["Reference"].Width = dgv_Liste.Width -
        //            dgv_Liste.Columns["LibelleSociete"].Width - 7;
        //    }
        //    else
        //    {
        //        dgv_Liste.Columns["Reference"].Width = 505;
        //        dgv_Liste.Columns["LibelleSociete"].Width = 138;
        //    }
        //}

        //private void dgv_Liste_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgv_Liste.SelectedRows != null &&
        //        dgv_Liste.SelectedRows.Count > 0)
        //    {
        //        detaillerObjet((Societe)bds_Societe.Current);
        //    }
        //    else
        //    {
        //        RAZ();
        //    }
        //}
        #endregion
    }
}
