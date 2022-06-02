using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LGC.Business;
using System.Drawing;
using LGC.UI; 
using LGC.Business.GestionUtilisateur;
using LGC.UI.GestionUtilisateur;
//using LGC.Business.Parametre;
using System.Data.SqlClient;
using System.IO;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace LGC.UI
{
    static class Program
    {

        public static bool connexion = false;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>

        #region methode
        public static void formatDate(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridDateTimeCellElement)
            {
                GridDateTimeCellElement dateTimeCell = e.CellElement as GridDateTimeCellElement;
                e.CellElement.Text = String.Format("{0: dd/MM/yyyy}", dateTimeCell.Value);
            }
        }
        public static void activerGridViewTooltipText(object sender, ToolTipTextNeededEventArgs e)
        {
            try
            {
                GridDataCellElement dataCell = sender as GridDataCellElement;
                if (dataCell != null)
                {
                    e.ToolTipText = dataCell.Value.ToString();
                }
            }
            catch
            {

            }
        }

        public static bool testerConnexionDB()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
                connectionBuilder.DataSource = CurrentUser.NomServeurProduction.Trim();
                connectionBuilder.PersistSecurityInfo = true;

                if (CurrentUser.ModeCon.Trim() == "S")
                {
                    connectionBuilder.UserID = CurrentUser.NomUtilisateur.Trim();
                    connectionBuilder.Password = CurrentUser.Pwd.Trim();
                    connectionBuilder.InitialCatalog = "DB_LABO";
                }
                else
                    connectionBuilder.IntegratedSecurity = true;

                using (SqlConnection dbConnection = new SqlConnection(connectionBuilder.ConnectionString))
                {
                    dbConnection.Open();
                    dbConnection.Close();
                }
                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                return false;
            }
        }

        #endregion

        [STAThread]
        static void Main()
        {
            LGC.Business.CurrentUser.UserLogin = "galicanto";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            CurrentUser.LogicielHote = CurrentUser.LogicielHote;



            bool para = true;

            StreamReader sr = null;
            string line;
            string[] recuperationT;

            sr = new StreamReader(CurrentUser.AppPath + "/strc.csv");
            line = sr.ReadLine();

            line = Tools.DecryptString(line, "abc123deaoezdf77", "abc123deaoezdf78");
            recuperationT = line.Split(';');
            sr.Close();

            CurrentUser.NomServeurProduction = recuperationT[0].Trim();
            CurrentUser.Pwd = recuperationT[3].Trim();
            CurrentUser.NomUtilisateur = recuperationT[2].Trim();
            CurrentUser.ModeCon = recuperationT[4].Trim();

            while (para && !Program.testerConnexionDB())
            {
                /*RadMessageBox.ThemeName =
                        Properties.Settings.Default.theme.Trim();*/
                if (RadMessageBox.Show(null, "Impossible de se connecter à la base de données." +
                "\nVoulez-Vous Paramétrer la chaine de connexion au serveur?",
                    CurrentUser.LogicielHote, MessageBoxButtons.YesNo, RadMessageIcon.Question)
                    == DialogResult.Yes)
                {
                    LGC.UI.DataBaseConfig.Frm_ConfigDataBase frm = new LGC.UI.DataBaseConfig.Frm_ConfigDataBase();
                    frm.mode = "c";
                    frm.ShowDialog();
                }
                else
                {
                    para = false;
                }
            }


            if (para)
            {
                CurrentUser.MAJ_DB_Connection();
                List<ConfigurationUM> lstChemin = new List<ConfigurationUM>();
                lstChemin = ConfigurationUM.Liste(null, null, null, null, null, null, false, null);
                if (lstChemin != null && lstChemin.Count != 0)
                {
                    CurrentUser.ImagePath = lstChemin[0].StrPath;
                }

                DateTime DtDerniereJC = Convert.ToDateTime(Outils.RecupererDerniereDate(
                    "dateDernModifServeur", "Parametre.T_JournalConnexion"));

                DateTime DtDerniereDV = Convert.ToDateTime(Outils.RecupererDerniereDate(
                    "dateCreationServeur", "Parametre.T_ConfigurationUM"));

                DateTime delai = CurrentUser.DateExpirationLogiciel;
                if (delai.Date >= DateTime.Now.Date &&
                    DateTime.Now.Date <= Convert.ToDateTime("31/12/2050"))
                {
                    if (delai.Date >= DtDerniereJC.Date &&
                        delai.Date >= DtDerniereDV.Date &&
                        DtDerniereDV.Date <= Convert.ToDateTime("31/12/2050") &&
                        DtDerniereJC.Date <= Convert.ToDateTime("31/12/2050"))
                    {
                        Application.Run(new Frm_Menu());
                    }
                    else
                    {
                        Frm_ExpirationLicence frm = new Frm_ExpirationLicence();
                        frm.lbl_Info.Text = "BANDIT, VOLEUR, ESCROT. TU N'AS PAS HONTE. QUITTES LA." +
                             " TU CROYAIS QUE JE N'ALLAIS PAS VOIR QUE TU AS CHANGE TA DATE." +
                             " SI TU NE FERMES PAS MON APPLICATION MAINTENANT TU VAS VOIR.";
                        frm.lbl_Info.ForeColor = System.Drawing.Color.Red;
                        Application.Run(frm);
                    }
                }
                else
                {
                    Frm_ExpirationLicence frm = new Frm_ExpirationLicence();
                    frm.lbl_Info.Text = "UN PROBLEME EST SURVENU LORS DU LANCEMENT DU LOGICIEL. " +
                        "VEUILLEZ CONTACTER L'ADMINISTRATEUR POUR " +
                        "LA RESOLUTION DU PROBLEME";

                    Application.Run(frm);
                    if (frm.connexion)
                    {
                        Application.Run(new Frm_Menu());
                    }
                }
            }
        }
    }
}
