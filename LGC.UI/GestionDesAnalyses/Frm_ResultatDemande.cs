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
using LGC.Business.GestionDesAnalyses;
using LGG.UI.Parametre;
using System.Windows.Forms;
using Telerik.WinControls.Tests;
using Telerik.WinControls.UI;
using LGC.Business.GestionDeStock;
using System.IO;
//using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Telerik.WinForms.Documents.Model;
using Telerik.WinForms.Documents.FormatProviders.OpenXml.Docx;
using Telerik.WinForms.Documents;
using Telerik.WinForms.Documents.DocumentStructure;
using Telerik.WinForms.Documents.Layout;




namespace LGC.UI.GestionDesAnalyses
{
    public partial class Frm_ResultatDemande : Telerik.WinControls.UI.RadForm
    {
        #region Déclarations
        public bool nouveau = false;
        string sortie;
        string unite = "", libelleParametre = "" ,codeAnalyse = "";
        int index;
        DataTable dt, dt1;
        string[] message;
        List<ResultatParametreAnalyse> lstResultatParametreAnalyse = new List<ResultatParametreAnalyse>();
        List<AnalyseDemande> lstInterpretation = new List<AnalyseDemande>();
        List<ResultatDemande> lstResultatDemande = new List<ResultatDemande>();
        List<DemandeAnalyse> lstDemandeAnalyse = new List<DemandeAnalyse>();
        List<UniteMesure> lstUniteMesure = new List<UniteMesure>();
        decimal totalQteSaisie;
        List<ParametrageInterpretationParametre> lstParametrageInterpretationParametre = new List<ParametrageInterpretationParametre>();
        CustomShape customShape1;
        #endregion

        #region Autres

        //private static List CreateInitialShape(int vertices, double radius1, double radius2)
        //{ 
        //    List pts = new List(); 
        //    if (radius1 == 0) 
        //        return null;
        //    if (radius2 == 0) 
        //        return null; 
        //    for (int i = 0; i < vertices; i++) 
        //    { 
        //        double angle1 = ((4.0 * i - vertices) * Math.PI) / (2.0f * vertices);
        //        double angle2 = ((4.0 * i - vertices + 2) * Math.PI) / (2.0f * vertices);
        //        pts.Add(new PointF((float)(Math.Cos(angle1) * radius1), (float)(Math.Sin(angle1) * radius1))); 
        //        pts.Add(new PointF((float)(Math.Cos(angle2) * radius2), (float)(Math.Sin(angle2) * radius2))); 
        //    }
        //    return pts; 
        //}          
        //private void SetShapes() 
        //{
            
        //    RoundRectShape square = new RoundRectShape(); square.Radius = 0; 
        //    this.radRadioSquare.RootElement.Children[0].Children[1].Children[1].Shape = square; 
        //    this.radRadioRound.RootElement.Children[0].Children[1].Children[1].Shape = new RoundRectShape(); 
        //    this.radRadioOffice.RootElement.Children[0].Children[1].Children[1].Shape = new OfficeShape();
        //} 
        private void activerDesactiverControle(bool condition)
        {
            dtp_dateOperation.ReadOnly = !condition;
            dgv_ListeInterpretation.AllowEditRow = condition;
            dgv_ListeParametre.AllowEditRow = condition;
            mcb_Demandes.Enabled = condition;
            dgv_ListeResultat.Enabled = !condition;
           
            btn_Annuler.Visible = condition;
            btn_Enregistrer.Visible = condition;
            btn_Nouveau.Visible = !condition;
            btn_Modifier.Visible = !condition;
            btn_Supprimer.Enabled = !condition;
            btn_Actualiser.Enabled = !condition;
            btn_Transmettre.Enabled = !condition;
            btn_AjouterParametre.Enabled = condition;
            btn_SupprimerParametre.Enabled = condition;
        }
        
        private void RAZ()
        {
            txt_num.Text = "EN CREATION";
            mcb_Demandes.Text = "";
            //dgv_ListeParametre.Rows.Clear();
           
            dtp_dateOperation.Value = DateTime.Now;
            //for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
            //{
            //    dgv_ListeParametre.Rows.RemoveAt(i);
            //    i--;
            //}
            bds_ResultatParametreAnalyse.DataSource = new List<ResultatParametreAnalyse>();
            //for (int i = 0; i < dgv_ListeInterpretation.RowCount; i++)
            //{
            //    dgv_ListeInterpretation.Rows.RemoveAt(i);
            //    i--;
            //}

            bds_Interpretation.DataSource = new List<AnalyseDemande>();
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.Rows.Clear();
            }
            
        }

       
        private void constituerObjetResultat(ResultatDemande obj)
        {
            obj.NumDemande = Convert.ToDecimal(mcb_Demandes.Text.Trim());
            obj.EstVerifie1 = false;
            obj.DateVerification1 = Convert.ToDateTime("01/01/2050");
            obj.EstVerifie2 = false;
            obj.DateVerification2 = Convert.ToDateTime("01/01/2050");
            obj.DateOperation = dtp_dateOperation.Value;
            obj.EstTransmi = false;
            obj.Conclusion =  "";
            obj.Statut = nouveau == true ? "EN ATTENTE" : obj.Statut;
        }

        private void creerObjetResultatParametreAnalyse(ResultatParametreAnalyse obj, decimal idResultat, int l)
        {
            obj.IdResultatDemande = idResultat;
            obj.CodeAnalyse = dgv_ListeParametre.Rows[l].Cells["CodeAnalyse"].Value.ToString();
            obj.LibelleParametre = dgv_ListeParametre.Rows[l].Cells["LibelleParametre"].Value.ToString();
            obj.EstValide = nouveau == true ? "" : dgv_ListeParametre.Rows[l].Cells["EstValide"].Value.ToString().Trim();
            obj.Unite = dgv_ListeParametre.Rows[l].Cells["Unite"].Value.ToString();
            obj.ValeurResultat = dgv_ListeParametre.Rows[l].Cells["ValeurResultat"].Value.ToString();
            obj.MotifRejet = dgv_ListeParametre.Rows[l].Cells["MotifRejet"].Value == null ? "" : dgv_ListeParametre.Rows[l].Cells["MotifRejet"].Value.ToString();
            obj.Interpretation = dgv_ListeParametre.Rows[l].Cells["Interpretation"].Value == null ? "" : dgv_ListeParametre.Rows[l].Cells["Interpretation"].Value.ToString();
            obj.Etat = dgv_ListeParametre.Rows[l].Cells["Etat"].Value == null ? "STANDARD" : dgv_ListeParametre.Rows[l].Cells["Etat"].Value.ToString().Trim();

        }
        private void creerObjetResultatInterpretation(AnalyseDemande obj, int l)
        {
            obj.Interpretation = dgv_ListeInterpretation.Rows[l].Cells["Interpretation"].Value.ToString();
         }
        private void detaillerObjetResultatDemande(ResultatDemande obj)
        {
            txt_num.Text = Convert.ToString(obj.IdResultatDemande);
            mcb_Demandes.Text = Convert.ToString(obj.NumDemande);
            dtp_dateOperation.Value = Convert.ToDateTime(obj.DateOperation);
            
            if (obj.Statut.Trim() == "EN ATTENTE")
            {
                ChargerListeResultatParametreAnalyse(obj);
                dgv_ListeParametre.Columns["MotifRejet"].IsVisible = false;
            }
            else if (obj.Statut.Trim() == "REJETE")
            {
                ChargerListeResultatParametreAnalyseRejeter(obj);
                dgv_ListeParametre.Columns["MotifRejet"].IsVisible = true;
            }

            ChargerListeInterpretation(obj.NumDemande);
        }
        private void ChargerListeResultatParametreAnalyseRejeter(ResultatDemande obj)
        {
            lstResultatParametreAnalyse = ResultatParametreAnalyse.Liste(obj.IdResultatDemande, null,null, null, "NON", null,
                null, null, null, null, null, null, null, null, false, null);
            bds_ResultatParametreAnalyse.DataSource = lstResultatParametreAnalyse;
        }
        private void ChargerListeInterpretationValeurResultat()
        {
            lstParametrageInterpretationParametre = ParametrageInterpretationParametre.Liste(null, null, null, null, null, null, null, null, null, null,
            null, false, null);
        }
        private void ChargerListeResultatParametreAnalyse(ResultatDemande obj)
        {
            lstResultatParametreAnalyse = ResultatParametreAnalyse.Liste(obj.IdResultatDemande,null, null, null, null, null,
                null, null, null, null, null, null, null, null, false, null);
            bds_ResultatParametreAnalyse.DataSource = lstResultatParametreAnalyse;
        }
        private void ChargerListeUnite()
        {
            lstUniteMesure = UniteMesure.Liste(null, null, null, null,
                null, null, null, false, null);
            bds_UniteMesure.DataSource = lstUniteMesure;
        }
        private void ChargerListeDemandeParametreAnalyse(decimal numDemande)
        {
            //for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
            //{
            //    dgv_ListeParametre.Rows.RemoveAt(i);
            //    i--;
            //}
            bds_ResultatParametreAnalyse.DataSource = new List<ResultatParametreAnalyse>();
            //ResultatParametreAnalyse obj = new ResultatParametreAnalyse();
            dt = ResultatDemande.ParametreAnalyseDemande(numDemande);
            bds_ResultatParametreAnalyse.DataSource = dt;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    obj.CodeAnalyse = dt.Rows[i]["codeAnalyse"].ToString().Trim();
            //    obj.LibelleParametre = dt.Rows[i]["libelleParametre"].ToString().Trim();
            //    dgv_ListeParametre.Rows.Add(0,
            //        obj.CodeAnalyse
            //        , ""
            //        , obj.LibelleParametre
            //        , ""
            //        , dt.Rows[i]["unite"].ToString().Trim(),
            //        "",
            //        "",
            //        dt.Rows[i]["libelleAnalyse"].ToString().Trim());
            //}
            
        }
        private void ChargerListeInterpretation(decimal numDemande)
        {
            lstInterpretation = AnalyseDemande.Liste(null, numDemande
                , null, null, null, null, null, null, null, null, false, null, null);
            bds_Interpretation.DataSource = lstInterpretation;
        }


        private void ChargerListeNouveaux(ResultatDemande obj)
        {
            lstResultatDemande = ResultatDemande.Liste(null, null, null, null, false,
                null, null, null, "EN ATTENTE",null,null,null,null,null,null,false,null);
            bds_Resultat.DataSource = lstResultatDemande;
            if (obj != null)
            {
                int i = 0;
                foreach (ResultatDemande ligne in bds_Resultat.List as List<ResultatDemande>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_Resultat.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        private void ChargerListeRejete(ResultatDemande obj)
        {
            lstResultatDemande = ResultatDemande.Liste(null, null, null, null, false,
                null, null, null, "REJETE", null, null, null, null, null, null, false, null);
            bds_Resultat.DataSource = lstResultatDemande;
            if (obj != null)
            {
                int i = 0;
                foreach (ResultatDemande ligne in bds_Resultat.List as List<ResultatDemande>)
                {
                    if (ligne.NumLigne == obj.NumLigne)
                    {
                        bds_Resultat.Position = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        private void ChargerListeDemandes()
        {
            lstDemandeAnalyse = DemandeAnalyse.Liste(null, null, null, null,null,
                null, null, null, null, null, null, null, null, null, null, null,null,null,null,null,null,null,null,null,false, null);
            lstDemandeAnalyse = lstDemandeAnalyse.FindAll(l => l.NiveauExecution.Trim() == "DESTOCKAGE INTRANT" ||
                l.NiveauExecution.Trim() == "PRELEVEMENT");
            bds_Demandes.DataSource = lstDemandeAnalyse;
        }
        #endregion
        
        #region Formulaire
        public Frm_ResultatDemande()
        {
            InitializeComponent();
            dgv_ListeInterpretation.TableElement.RowHeight = 100;
            this.customShape1 = new CustomShape(); 
            //customShape1.CreateClosedShape(CreateInitialShape(5, 100, 60)); 
            //SetShapes();
            this.rb_Rejete.RootElement.Children[0].Children[1].Children[1].Shape =  new OfficeShape();
            this.rb_New.RootElement.Children[0].Children[1].Children[1].Shape =  new OfficeShape();
            ConditionalFormattingObject obj = new ConditionalFormattingObject("ConditionEstTransmi", ConditionTypes.Equal, "true", "", true);
            obj.CellForeColor = Color.Red;
            obj.RowBackColor = Color.Green;
            this.dgv_ListeResultat.Columns["EstTransmi"].ConditionalFormattingObjectList.Add(obj);
             dt1 = new DataTable();
            dt1.Columns.Add("codeAnalyse");
            dt1.Columns.Add("libelleAnalyse");
            dt1.Columns.Add("codeIntrant");
            dt1.Columns.Add("libelleIntrant");
            dt1.Columns.Add("QuantiteMax");
            dt1.Columns.Add("quantiteMin");
            dt1.Columns.Add("CodeUniteMesure");
            dt1.Columns.Add("stockDisponible");
            dt1.Columns.Add("QteDesctocke");
            dt1.Columns.Add("NumLigne");
            dt1.Columns.Add("NumDemande");
            dt1.Columns.Add("IdDestockage");
            dt1.Columns.Add("QteDispoReelle");
            dt1.Columns.Add("chk");
            
            //this.SelectedControl = this.radRadioCustShape;
            
        }

        private void Frm_ResultatDemande_Load(object sender, EventArgs e)
        {
            activerDesactiverControle(false);
            ChargerListeDemandes();
            ChargerListeInterpretationValeurResultat();
            ChargerListeUnite();
            RAZ();
            radRadioDonut_ToggleStateChanged(null, null);
           if (nouveau)
                btn_Nouveau_Click(null, null);



             

                //this.radRichTextEditor1.Document.Sections.Add(section);
        }

       
        #endregion

        #region bouton de commande
        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            nouveau = true;
            activerDesactiverControle(true);
            RAZ();
            mcb_Demandes.Focus();
        }
        

        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            if (dgv_ListeResultat.SelectedRows != null &&
               dgv_ListeResultat.SelectedRows.Count > 0)
            {
                if (Convert.ToBoolean(dgv_ListeResultat.CurrentRow.Cells["EstTransmi"].Value.ToString()) == false)
                {
                    nouveau = false;
                    activerDesactiverControle(true);
                    mcb_Demandes.Enabled = false;
                    dtp_dateOperation.ReadOnly = true;
                    btn_AjouterParametre.Enabled = false;
                   
                    dgv_ListeParametre.Focus();
                }
                else
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Résultat transmi. Veuillez-attendre le retour.", 
                        CurrentUser.LogicielHote, MessageBoxButtons.OK,
                        RadMessageIcon.Error);
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

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            if (dgv_ListeResultat.SelectedRows != null &&
                dgv_ListeResultat.SelectedRows.Count > 0)
            {
                //RadMessageBox.ThemeName = this.ThemeName;
                //if (RadMessageBox.Show(this, "Voulez-vous vraiment supprimer la ligne " +
                //    "sélectionnée", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                //    RadMessageIcon.Question) == DialogResult.Yes)
                //{
                //    ResultatDemande obj = (ResultatDemande)bds_Resultat.Current;
                //    string res = obj.Delete();
                //    message =LGC.Business.Tools.SplitMessage(res);
                //    if (int.Parse(message[0]) > 0)
                //    {
                //        ChargerListe((ResultatDemande)bds_Resultat.Current);
                //        RadMessageBox.ThemeName = this.ThemeName;
                //        RadMessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                //            MessageBoxButtons.OK, RadMessageIcon.Info);
                //    }
                //    else
                //    {
                //        RadMessageBox.ThemeName = this.ThemeName;
                //        MessageBox.Show(this, message[3].Trim(), CurrentUser.LogicielHote,
                //            MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
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
            if (rb_New.IsChecked)
            {
                ChargerListeNouveaux((ResultatDemande)bds_Resultat.Current);
            }
            else
            {
                ChargerListeRejete((ResultatDemande)bds_Resultat.Current);
            }
            
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            ResultatDemande obj = new ResultatDemande();
            ResultatParametreAnalyse objResultatParametreAnalyse = new ResultatParametreAnalyse();
            AnalyseDemande objAnalyseDemande = new AnalyseDemande();
            if (dt1.Rows.Count > 0)
            {
                dt1.Rows.Clear();
            } 
            #region controle de saisie
            if (mcb_Demandes.Text.Trim() == "")
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "La sélection de la demande est obligatoire.",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                mcb_Demandes.Focus();
                return;
            }
            for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
            {
                if (dgv_ListeParametre.Rows[i].Cells["ValeurResultat"].Value == null ||
                    dgv_ListeParametre.Rows[i].Cells["ValeurResultat"].Value.ToString().Trim() == string.Empty)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Il y a un moins un parametre dont vous n'aviez pas renseigner sa valeur résultat.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    dgv_ListeParametre.Focus();
                    return; 
                }
               
            }
            //for (int i = 0; i < dgv_ListeInterpretation.RowCount; i++)
            //{
            //    if (dgv_ListeInterpretation.Rows[i].Cells["Interpretation"].Value == null ||
            //        dgv_ListeInterpretation.Rows[i].Cells["Interpretation"].Value.ToString().Trim() == string.Empty)
            //    {
            //        RadMessageBox.ThemeName = this.ThemeName;
            //        RadMessageBox.Show(this, "Il y a un moins une analyse qui n'a pas d'intepretation.",
            //            CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
            //        dgv_ListeParametre.Focus();
            //        return;
            //    }

            //}

            #endregion

            #region Enregistrement
            if (nouveau)
            {
                constituerObjetResultat(obj);
                sortie = obj.Insert();
                message =LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
                    {
                        creerObjetResultatParametreAnalyse(objResultatParametreAnalyse, obj.NumLigne, i);
                        objResultatParametreAnalyse.Insert();
                    }

                   
                    for (int i = 0; i < dgv_ListeInterpretation.RowCount; i++)
                    {
                        bds_Interpretation.Position = i;
                        objAnalyseDemande = (AnalyseDemande)bds_Interpretation.Current;
                        creerObjetResultatInterpretation(objAnalyseDemande, i);
                        objAnalyseDemande.Update();
                    }
                    
                        if (rb_New.IsChecked)
                        {
                            ChargerListeNouveaux(obj);
                        }
                        else
                        {
                            ChargerListeRejete(obj);
                        };
                    dt = IntrantAnalyseDestocke.IntrantAnalyse(obj.NumDemande);
                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        totalQteSaisie = 0;
                        for (int k = 0; k < dt1.Rows.Count; k++)
                        {
                            if (dt1.Rows[k]["CodeIntrant"].ToString().Trim() ==
                                dt.Rows[i]["CodeIntrant"].ToString().Trim())
                            {
                                totalQteSaisie += Convert.ToDecimal(dt1.Rows[k]["QteDesctocke"].ToString().Trim());
                            }

                        }
                        //dt1.Rows.Add(dt.Rows[i]);
                        dt1.Rows.Add(dt.Rows[i]["codeAnalyse"].ToString().Trim()
                            , dt.Rows[i]["libelleAnalyse"].ToString().Trim()
                            , dt.Rows[i]["codeIntrant"].ToString().Trim()
                            , dt.Rows[i]["libelleIntrant"].ToString().Trim(),
                            dt.Rows[i]["QuantiteMax"].ToString().Trim()
                            , dt.Rows[i]["quantiteMin"].ToString().Trim()
                            , dt.Rows[i]["CodeUniteMesure"].ToString().Trim()
                            , dt.Rows[i]["stockDisponible"].ToString().Trim(),
                            Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim())
                            > Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) ?
                            Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) :
                            Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim())
                            , 0
                            , obj.NumDemande
                            , 0
                            , Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim())
                            - totalQteSaisie - (Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim())
                            > Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) ?
                            Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) :
                            Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim()))
                            , Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim())
                            - totalQteSaisie - (Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim())
                            > Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) ?
                            Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) :
                            Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim()))
                           < 0 ? false : true);
                    }
                    Frm_DestockageAnalyse frm = new Frm_DestockageAnalyse(dt1);
                    frm.ShowDialog();
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
                obj = (ResultatDemande)bds_Resultat.Current;
                constituerObjetResultat(obj);
                sortie = obj.Update();
                message =LGC.Business.Tools.SplitMessage(sortie);
                if (message[message.Length - 1].Trim() != "")
                {
                    obj.NumLigne = int.Parse(message[message.Length - 1].Trim());
                    for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
                    {
                        creerObjetResultatParametreAnalyse(objResultatParametreAnalyse, obj.NumLigne, i);
                        if (dgv_ListeParametre.Rows[i].Cells["NumLigne"].Value != null
                        && Convert.ToDecimal(dgv_ListeParametre.Rows[i].Cells["NumLigne"].Value.ToString().Trim()) != 0)
                        {
                            objResultatParametreAnalyse.NumLigne = Convert.ToDecimal(dgv_ListeParametre.Rows[i].Cells["NumLigne"].Value.ToString().Trim());
                             objResultatParametreAnalyse.Update();
                        }
                        else{
                            objResultatParametreAnalyse.Insert();
                        }
                    }

                    for (int i = 0; i < dgv_ListeInterpretation.RowCount; i++)
                    {
                        bds_Interpretation.Position = i;
                        objAnalyseDemande = (AnalyseDemande)bds_Interpretation.Current;
                        creerObjetResultatInterpretation(objAnalyseDemande, i);
                        objAnalyseDemande.Update();
                    }
                    activerDesactiverControle(false);
                    nouveau = false;
                    if (rb_New.IsChecked)
                    {
                        ChargerListeNouveaux((ResultatDemande)bds_Resultat.Current);
                    }
                    else
                    {
                        ChargerListeRejete((ResultatDemande)bds_Resultat.Current);
                    }
                     RadMessageBox.ThemeName = this.ThemeName;
                if (RadMessageBox.Show(this, "Voulez-vous éffectuer à nouveau de déstockage d'intrant ", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                    RadMessageIcon.Question) == DialogResult.Yes)
                {
                    dt = IntrantAnalyseDestocke.IntrantAnalyse(obj.NumDemande);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        totalQteSaisie = 0;
                        for (int k = 0; k < dt1.Rows.Count; k++)
                        {
                            if (dt1.Rows[k]["CodeIntrant"].ToString().Trim() ==
                                dt.Rows[i]["CodeIntrant"].ToString().Trim())
                            {
                                totalQteSaisie += 
                                    Convert.ToDecimal(dt1.Rows[k]["QteDesctocke"].ToString().Trim());
                            }

                        }
                        //dt1.Rows.Add(dt.Rows[i]);
                        dt1.Rows.Add(dt.Rows[i]["codeAnalyse"].ToString().Trim()
                            , dt.Rows[i]["libelleAnalyse"].ToString().Trim()
                            , dt.Rows[i]["codeIntrant"].ToString().Trim()
                            , dt.Rows[i]["libelleIntrant"].ToString().Trim(),
                            dt.Rows[i]["QuantiteMax"].ToString().Trim()
                            , dt.Rows[i]["quantiteMin"].ToString().Trim()
                            , dt.Rows[i]["CodeUniteMesure"].ToString().Trim()
                            , dt.Rows[i]["stockDisponible"].ToString().Trim(),
                            Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim())
                            > Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) ?
                            Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) :
                            Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim())
                            , 0
                            , obj.NumDemande
                            , 0
                            , Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim())
                            - totalQteSaisie - (Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim())
                            > Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) ?
                            Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) :
                            Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim()))
                            , Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim())
                            - totalQteSaisie - (Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim())
                            > Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) ?
                            Convert.ToDecimal(dt.Rows[i]["stockDisponible"].ToString().Trim()) :
                            Convert.ToDecimal(dt.Rows[i]["quantiteMin"].ToString().Trim()))
                             < 0 ? false : true);
                    }
                    Frm_DestockageAnalyse frm = new Frm_DestockageAnalyse(dt1);
                    frm.ShowDialog();
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
            }
            #endregion

            #region Gestion du document de résultat
            DocxFormatProvider provider = new DocxFormatProvider();
            using (FileStream output = File.OpenWrite(CurrentUser.ImagePath + "\\"+obj.NumDemande+".docx"))
            {
                RadDocument document = this.radRichTextEditor1.Document;
                provider.Export(document, output);
            }
            #endregion

        }

        private void btn_Actualiser_Click(object sender, EventArgs e)
        {
            if (rb_New.IsChecked)
            {
                ChargerListeNouveaux(null);
            }
            else
            {
                ChargerListeRejete(null);
            }
        }
        #endregion

        #region BindingSource
        private void bds_ResultatDemande_CurrentChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region DataGridView
        private void dgv_Liste_Resize(object sender, EventArgs e)
        {
        //    if (dgv_ListeEdition.Width > 650)
        //    {
        //        dgv_ListeEdition.Columns["libelleResultatDemande"].Width = dgv_ListeEdition.Width -
        //            dgv_ListeEdition.Columns["codeResultatDemande"].Width - 7;
        //    }
        //    else
        //    {
        //        dgv_ListeEdition.Columns["libelleResultatDemande"].Width = 505;
        //        dgv_ListeEdition.Columns["codeResultatDemande"].Width = 138;
        //    }
        }

        private void dgv_Liste_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeEdition.SelectedRows != null &&
                dgv_ListeEdition.SelectedRows.Count > 0)
            {
                //detaillerObjet((ResultatDemande)bds_Resultat.Current);
            }
            else
            {
                RAZ();
            }
        }
      
        private void dgv_Liste_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            Program.activerGridViewTooltipText(sender, e);
        }
        #endregion

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void radMultiColumnComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_Motif_TextChanged(object sender, EventArgs e)
        {

        }

        private void radLabel3_Click(object sender, EventArgs e)
        {

        }

        private void mcb_Demandes_TextChanged(object sender, EventArgs e)
        {
            if (mcb_Demandes.Text.Trim() != "")
            {
                ChargerListeDemandeParametreAnalyse(Convert.ToDecimal(mcb_Demandes.Text.Trim()));
                ChargerListeInterpretation(Convert.ToDecimal(mcb_Demandes.Text.Trim()));
              
            }
        }


        private void dgv_ListeResultat_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListeResultat.SelectedRows != null &&
                dgv_ListeResultat.SelectedRows.Count > 0)
            {
                detaillerObjetResultatDemande((ResultatDemande)bds_Resultat.Current);
            }
            else
            {
                RAZ();
            }
        }

        private void btn_Transmettre_Click(object sender, EventArgs e)
        {
            if (dgv_ListeResultat.SelectedRows != null &&
               dgv_ListeResultat.SelectedRows.Count > 0)
            {
                if (Convert.ToBoolean(dgv_ListeResultat.CurrentRow.Cells["EstTransmi"].Value.ToString()) == false)
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    if (RadMessageBox.Show(this, "Voulez-vous vraiment transmettre le résultat " +
                        "sélectionné pour vérification?", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                        RadMessageIcon.Question) == DialogResult.Yes)
                    {
                        ResultatDemande obj = new ResultatDemande();
                        obj = (ResultatDemande)bds_Resultat.Current;
                        obj.EstTransmi = true;
                        sortie = obj.Update();
                        message = LGC.Business.Tools.SplitMessage(sortie);
                        if (message[message.Length - 1].Trim() != "")
                        {

                            if (rb_New.IsChecked)
                            {
                                ChargerListeNouveaux((ResultatDemande)bds_Resultat.Current);
                            }
                            else
                            {
                                ChargerListeRejete((ResultatDemande)bds_Resultat.Current);
                            }
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, "Résultat transmi avec succès.", CurrentUser.LogicielHote,
                                MessageBoxButtons.OK, RadMessageIcon.Info);
                        }
                        else
                        {
                            RadMessageBox.ThemeName = this.ThemeName;
                            RadMessageBox.Show(this, message[4].Trim(), CurrentUser.LogicielHote,
                                MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                    }
                }
                else
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Le résultat sélectionné est déjà transmi pour vérification",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                   
                    return;
                }
            }
            else
            {
               
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Veuillez sélectionner le résultat que vous voulez transmettre pour vérification",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                   
                    return;
                
            }
        }

        private void btn_AjouterParametre_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                Frm_AddParametreAnalyseResultat frm = new Frm_AddParametreAnalyseResultat(dt);
                frm.ShowDialog();
            }
            else
            {
                RadMessageBox.ThemeName = this.ThemeName;
                RadMessageBox.Show(this, "Veuillez sélectionner la demande d'abord",
                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);

                return;
            }
        }

        private void dgv_ListeParametre_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
        {
            if (dgv_ListeParametre.SelectedRows != null &&
              dgv_ListeParametre.SelectedRows.Count > 0)
            {
                if (e.Column.Name.ToLower() == "unite")
                {
                    unite = dgv_ListeParametre.CurrentRow.Cells["Unite"].Value.ToString().Trim();
                    index = 0;
                    for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
                    {
                        index = i;
                        if (dgv_ListeParametre.CurrentRow.Cells["libelleAnalyse"].Value.ToString().Trim() ==
                                dgv_ListeParametre.Rows[i].Cells["libelleAnalyse"].Value.ToString().Trim() &&
                                dgv_ListeParametre.CurrentRow.Cells["LibelleParametre"].Value.ToString().Trim() ==
                                dgv_ListeParametre.Rows[i].Cells["LibelleParametre"].Value.ToString().Trim() &&
                               dgv_ListeParametre.CurrentRow.Cells["Unite"].Value.ToString().Trim() ==
                                dgv_ListeParametre.Rows[i].Cells["Unite"].Value.ToString().Trim())
                        {
                            
                            break;
                        }
                        
                    }
                }
            }
        }

        private void dgv_ListeParametre_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (dgv_ListeParametre.SelectedRows != null &&
             dgv_ListeParametre.SelectedRows.Count > 0)
            {
                if (e.Column.Name.ToLower() == "unite")
                {
                   for (int i = 0; i < dgv_ListeParametre.RowCount; i++)//parcour de la liste des produits déjà sélectionnés
                    {
                        if (index != i)
                        {
                            //si le produit en cours sélectionné est déjà sélectionné au paravant il faut arreter la recherche
                            if (dgv_ListeParametre.CurrentRow.Cells["libelleAnalyse"].Value.ToString().Trim() ==
                                dgv_ListeParametre.Rows[i].Cells["libelleAnalyse"].Value.ToString().Trim() &&
                                dgv_ListeParametre.CurrentRow.Cells["LibelleParametre"].Value.ToString().Trim() ==
                                dgv_ListeParametre.Rows[i].Cells["LibelleParametre"].Value.ToString().Trim() &&
                               dgv_ListeParametre.CurrentRow.Cells["Unite"].Value.ToString().Trim() ==
                                dgv_ListeParametre.Rows[i].Cells["Unite"].Value.ToString().Trim())
                            {
                                RadMessageBox.ThemeName = this.ThemeName;
                                RadMessageBox.Show(this, "Ces informations existe déjà.",
                                    CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                                dgv_ListeParametre.CurrentRow.Cells["Unite"].Value = unite;
                                break;//permet de quitter  la boucle sans aller à la derniere ittération
                            }
                        }
                        
                    }
                }
                else if (e.Column.Name.ToLower() == "valeurresultat")
                {
                    ParametrageInterpretationParametre obj =  lstParametrageInterpretationParametre.Find(x => x.CodeAnalyse.Trim() ==
                        dgv_ListeParametre.CurrentRow.Cells["CodeAnalyse"].Value.ToString().Trim() && x.LibelleParametre.Trim() ==
                        dgv_ListeParametre.CurrentRow.Cells["LibelleParametre"].Value.ToString().Trim() && dgv_ListeParametre.CurrentRow.Cells["ValeurResultat"].Value.ToString().Trim() ==
                        x.Valeur);
                    if (obj != null)
	                {
                        dgv_ListeParametre.CurrentRow.Cells["Interpretation"].Value = obj.Interpretation;
	                }
                    else
                    {
                        ParametrageInterpretationParametre obj1 = lstParametrageInterpretationParametre.Find(x => x.CodeAnalyse.Trim() ==
                        dgv_ListeParametre.CurrentRow.Cells["CodeAnalyse"].Value.ToString().Trim() && x.LibelleParametre.Trim() ==
                        dgv_ListeParametre.CurrentRow.Cells["LibelleParametre"].Value.ToString().Trim() && 
                        Convert.ToDecimal(dgv_ListeParametre.CurrentRow.Cells["ValeurResultat"].Value.ToString().Trim()) >= x.BorneInferieure
                        && Convert.ToDecimal(dgv_ListeParametre.CurrentRow.Cells["ValeurResultat"].Value.ToString().Trim()) <= x.BorneSuperieure);

                        dgv_ListeParametre.CurrentRow.Cells["Interpretation"].Value = obj1 != null ? obj1.Interpretation : "";
                    }
                   
                }
            }
        }

        private void btn_SupprimerParametre_Click(object sender, EventArgs e)
        {
            if (dgv_ListeParametre.SelectedRows != null &&
             dgv_ListeParametre.SelectedRows.Count > 0)
            {
                if (dgv_ListeParametre.CurrentRow.Cells["Etat"].Value != null 
                    && dgv_ListeParametre.CurrentRow.Cells["Etat"].Value.ToString().Trim() == "COMPLETE")
                {
                    if (dgv_ListeParametre.CurrentRow.Cells["NumLigne"].Value != null
                        && Convert.ToDecimal(dgv_ListeParametre.CurrentRow.Cells["NumLigne"].Value.ToString().Trim()) != 0)
                    {
                        if (RadMessageBox.Show(this, "Le parametre sélectionner sera aussi supprimé dans la base de donnée." +
                            "Voulez-vous continuer ?", CurrentUser.LogicielHote, MessageBoxButtons.YesNo,
                        RadMessageIcon.Question) == DialogResult.Yes)
                        {
                            ResultatParametreAnalyse obj = (ResultatParametreAnalyse)bds_ResultatParametreAnalyse.Current;
                            string res = obj.Delete();
                            message = LGC.Business.Tools.SplitMessage(res);
                            if (int.Parse(message[0]) > 0)
                            {
                                index = 0;
                                for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
                                {
                                    index = i;
                                    if (dgv_ListeParametre.CurrentRow == dgv_ListeParametre.Rows[i])
                                    {
                                        break;
                                    }
                                }
                                dgv_ListeParametre.Rows.RemoveAt(index);
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
                        index = 0;
                        for (int i = 0; i < dgv_ListeParametre.RowCount; i++)
                        {
                            index = i;
                            if (dgv_ListeParametre.CurrentRow == dgv_ListeParametre.Rows[i])
                            {
                                break;
                            }
                        }
                        dgv_ListeParametre.Rows.RemoveAt(index);
                    }
                }
                else
                {
                    RadMessageBox.ThemeName = this.ThemeName;
                    RadMessageBox.Show(this, "Vous ne pouvez pas supprimer ce parametre car il a été ajouté depuis la créaction de l'analyse.",
                        CurrentUser.LogicielHote, MessageBoxButtons.OK, RadMessageIcon.Error);
                    
                }
            }
        }

        private void radRadioDonut_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            RAZ();
             if (rb_New.IsChecked)
             {
                 ChargerListeNouveaux(null);
             }
             else
             {
                 ChargerListeRejete(null);
             }
        }

        private void radGroupBox5_Click(object sender, EventArgs e)
        {

        }

        private void richTextEditorRibbonBar1_Click(object sender, EventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //Microsoft.Office.Interop.Word._Application oWord;
            //object oMissing = Type.Missing;
            //oWord = new Microsoft.Office.Interop.Word.Application();
            //oWord.Visible = false;

            //Word.Document doc = oWord.Documents.Add();
            //object start = 0;
            //object end = 0;
            //doc=(Word.Document)radRichTextEditor1.Document.ToString;

            
          
            //object fileName = CurrentUser.ImagePath + "\\toto.docx";
            //doc.SaveAs(ref fileName,
            //        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            //        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            //        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);



            #region En-tete de pages
            RadDocument radDocument = new RadDocument();
            Section section = new Section();
            Paragraph paragraph = new Paragraph();
            ImageInline image;
            Telerik.WinControls.RichTextEditor.UI.Size size = new Telerik.WinControls.RichTextEditor.UI.Size(17.38, 2.59);
            using (MemoryStream ms = new MemoryStream())
            {
                string fileName = CurrentUser.ImagePath + "\\logo.JPG";
                Image.FromFile(fileName).Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                image = new ImageInline(ms, size, "png");
            }

            paragraph.Inlines.Add(image);
            section.Children.Add(paragraph);
            radDocument.Sections.Add(section);
            Header header = new Header() { Body = radDocument, IsLinkedToPrevious = false };
            this.radRichTextEditor1.UpdateHeader(this.radRichTextEditor1.Document.Sections.First, HeaderFooterType.Default, header); 
            #endregion

            #region Pied de pages
            RadDocument radDocument1 = new RadDocument();
            Section section1 = new Section();
            Paragraph paragraph1 = new Paragraph();
           
            
            //paragraph.Inlines.Add();
            //section.Children.Add(paragraph);
            //radDocument.Sections.Add(section);
            //Header header = new Header() { Body = radDocument, IsLinkedToPrevious = false };
            //this.radRichTextEditor1.UpdateHeader(this.radRichTextEditor1.Document.Sections.First, HeaderFooterType.Default, header);
            #endregion




            DocxFormatProvider provider = new DocxFormatProvider();
            using (FileStream output = File.OpenWrite(CurrentUser.ImagePath + "\\toto.docx"))
            {
                RadDocument document = this.radRichTextEditor1.Document;
                provider.Export(document, output);
            }
            
          
            
        }

      
    }
}
