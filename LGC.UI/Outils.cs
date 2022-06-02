using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;
using LGC.Business;
using LGC.Business.GestionUtilisateur;
using LGC.Business.Parametre;

namespace LGC.UI
{
    public class Outils
    {
        #region Gestion des droits des utilisateurs
        public static void DesactiverMenu(ToolStripMenuItem unSousMenu)
        {
            if (unSousMenu.DropDownItems.Count > 0)
            {
                foreach (ToolStripItem unNSousMenu in unSousMenu.DropDownItems)
                {
                    try
                    {
                        DesactiverMenu((ToolStripMenuItem)unNSousMenu);
                    }
                    catch { }
                }
            }
            if ((unSousMenu.Tag != null) && (unSousMenu.Tag.ToString().Trim() != ""))
                unSousMenu.Visible = false;
        }

        public static void DesactiverMenu(ToolStripMenuItem unSousMenu, string mode)
        {
            if (unSousMenu.DropDownItems.Count > 0)
            {
                foreach (ToolStripItem unNSousMenu in unSousMenu.DropDownItems)
                {
                    try
                    {
                        DesactiverMenu((ToolStripMenuItem)unNSousMenu, mode);
                    }
                    catch { }
                }
            }
            if ((unSousMenu.Tag != null) &&
                (unSousMenu.Tag.ToString().Trim() == mode.Trim() ||
                (unSousMenu.Tag.ToString().Trim().Split(';').Length == 2 &&
                 unSousMenu.Tag.ToString().Trim().Split(';')[1] == mode.Trim())))
                unSousMenu.Visible = false;
        }

        public static void DesactiverMenu(RadMenuItem unSousMenu, string mode)
        {
            if (unSousMenu.Items.Count > 0)
            {
                foreach (RadMenuItem unNSousMenu in unSousMenu.Items)
                {
                    try
                    {
                        DesactiverMenu((RadMenuItem)unNSousMenu, mode);
                    }
                    catch { }
                }
            }
            if (unSousMenu.Tag != null &&
                (unSousMenu.Tag.ToString().Trim() == mode.Trim() ||
                (unSousMenu.Tag.ToString().Trim().Split(';').Length == 2 &&
                 unSousMenu.Tag.ToString().Trim().Split(';')[1] == mode.Trim()
                 )
                 )
                )
                unSousMenu.Visibility = ElementVisibility.Collapsed;
        }

        public static void DesactiverMenu(RadMenu rm)
        {
            foreach (RadMenuItem unMenu in rm.Items)
            {
                DesactiverMenu(unMenu);
            }
        }

        public static void DesactiverMenu(RadMenuItem unSousMenu)
        {
            if (unSousMenu.Items.Count > 0)
            {
                foreach (RadMenuItem unNSousMenu in unSousMenu.Items)
                {
                    try
                    {
                        DesactiverMenu((RadMenuItem)unNSousMenu);
                    }
                    catch { }
                }
            }
            if ((unSousMenu.Tag != null) && (unSousMenu.Tag.ToString() != ""))
                unSousMenu.Visibility = ElementVisibility.Collapsed;
        }

        public static void DesactiverMenu(RadMenu rm, string mode)
        {
            foreach (RadMenuItem unMenu in rm.Items)
            {
                DesactiverMenu(unMenu, mode);
            }
        }






        public static void DesactiverCommandBar(CommandBarStripElement cbse)
        {
            foreach (RadCommandBarBaseItem cb in cbse.Items)
            {
                if (cb.Tag != null && cb.Tag.ToString().Trim() != "")
                {
                    cb.Visibility = ElementVisibility.Collapsed;
                }
            }
        }

        public static void DesactiverCommandBar(CommandBarStripElement cbse, string mode)
        {
            foreach (RadCommandBarBaseItem cb in cbse.Items)
            {
                if (cb.Tag != null &&
                    (cb.Tag.ToString().Trim() == mode.Trim() ||
                    (cb.Tag.ToString().Trim().Split(';').Length == 2 &&
                     cb.Tag.ToString().Trim().Split(';')[1] == mode.Trim())))
                {
                    cb.Visibility = ElementVisibility.Collapsed;
                }
            }
        }


        public static void activerMenu(RadMenu rm,
                                CommandBarStripElement cbse)
        {
            CurrentUser.LstDroitReelUser =
                ProfilDroit.DroitReelUtilisateur(CurrentUser.OUtilisateur.NumeroUtilisateur);
            if (rm != null)
            {
                #region Activation de menu
                foreach (ProfilDroit unDroitProfilUtil in CurrentUser.LstDroitReelUser)
                {
                    RadMenuItem unSM = new RadMenuItem();
                    string[] tabMenu = unDroitProfilUtil.ODroit.CheminMenu.Trim().Split(';');
                    for (int i = 0; i < tabMenu.Length; i++)
                    {
                        try
                        {
                            if (i == 0)
                            {
                                unSM = (RadMenuItem)rm.Items[tabMenu[i]];
                            }
                            else
                            {
                                unSM = (RadMenuItem)(unSM.Items[tabMenu[i]]);
                            }
                            unSM.Visibility = ElementVisibility.Visible;
                        }
                        catch { }
                    }
                }
                #endregion
            }
            if (cbse != null)
            {
                #region désactivation et activation des boutons du toolstrip

                foreach (RadCommandBarBaseItem cb in cbse.Items)
                {
                    if (cb.Tag != null && cb.Tag.ToString().Trim() != "")
                    {
                        if (CurrentUser.LstDroitReelUser.Find(l => l.ODroit.CodeDroit.Trim() ==
                            cb.Tag.ToString().Trim()) == null)
                        {
                            cb.Visibility = ElementVisibility.Collapsed;
                        }
                        else
                            cb.Visibility = ElementVisibility.Visible;
                    }
                }
                #endregion
            }
        }

        public static void MenuBycodeDroit(RadMenu rm,
                                           string mode,
                                            string mCodeDroit, bool aCacher)
        {
            string[] tabCodeDroit = null;
            CurrentUser.LstDroitReelUser =
                ProfilDroit.DroitReelUtilisateur(CurrentUser.OUtilisateur.NumeroUtilisateur);
            List<ProfilDroit> liste = new List<ProfilDroit>();

            if (CurrentUser.LstDroitReelUser.Count > 0)
            {
                tabCodeDroit = mCodeDroit.Split(';');
            }

            for (int j = 0; j < tabCodeDroit.Length; j++)
            {

                if (rm != null)
                {
                    liste = CurrentUser.LstDroitReelUser.FindAll(x => x.CodeDroit.Trim() == tabCodeDroit[j].Trim());
                    #region Activation de menu
                    foreach (ProfilDroit unDroitProfilUtil in liste)
                    {
                        RadMenuItem unSM = new RadMenuItem();
                        string[] tabMenu = unDroitProfilUtil.ODroit.CheminMenu.Trim().Split(';');
                        for (int i = 0; i < tabMenu.Length; i++)
                        {
                            try
                            {
                                if (i == 0)
                                {
                                    unSM = (RadMenuItem)rm.Items[tabMenu[i]];
                                    unSM.Visibility = ElementVisibility.Visible;
                                }
                                else
                                {
                                    unSM = (RadMenuItem)(unSM.Items[tabMenu[i]]);

                                    if (aCacher == true)
                                    {
                                        unSM.Visibility = ElementVisibility.Collapsed;
                                    }
                                    else
                                    {
                                        unSM.Visibility = ElementVisibility.Visible;
                                    }
                                }

                            }
                            catch { }
                        }
                    }
                    #endregion
                }
            }

        }

        public static void activerMenu(RadMenu rm,
                                       CommandBarStripElement cbse,
                                       string mode)
        {
            CurrentUser.LstDroitReelUser =
                ProfilDroit.DroitReelUtilisateur(CurrentUser.OUtilisateur.NumeroUtilisateur);
            if (rm != null)
            {
                #region Activation de menu
                foreach (ProfilDroit unDroitProfilUtil in CurrentUser.LstDroitReelUser)
                {
                    RadMenuItem unSM = new RadMenuItem();
                    string[] tabMenu = unDroitProfilUtil.ODroit.CheminMenu.Trim().Split(';');
                    for (int i = 0; i < tabMenu.Length; i++)
                    {
                        try
                        {
                            if (i == 0)
                            {
                                unSM = (RadMenuItem)rm.Items[tabMenu[i]];
                            }
                            else
                            {
                                unSM = (RadMenuItem)(unSM.Items[tabMenu[i]]);
                            }
                            if (unSM.Tag != null &&
                                (unSM.Tag.ToString().Trim() == mode.Trim() ||
                                (unSM.Tag.ToString().Trim().Split(';').Length == 2 &&
                                 unSM.Tag.ToString().Trim().Split(';')[1] == mode.Trim())))
                            {
                                unSM.Visibility = ElementVisibility.Visible;
                            }
                        }
                        catch { }
                    }
                }
                #endregion
            }
            if (cbse != null)
            {
                #region désactivation et activation des boutons du toolstrip

                foreach (RadCommandBarBaseItem cb in cbse.Items)
                {
                    if (cb.Tag != null && cb.Tag.ToString().Trim() != "")
                    {
                        if (CurrentUser.LstDroitReelUser.Find(l => l.ODroit.CodeDroit.Trim() ==
                            cb.Tag.ToString().Trim().Split(';')[0]) == null)
                        {
                            cb.Visibility = ElementVisibility.Collapsed;
                        }
                        else if (cb.Tag.ToString().Trim().Split(';').Length == 2 &&
                            cb.Tag.ToString().Trim().Split(';')[1] == mode.Trim())
                        {
                            cb.Visibility = ElementVisibility.Visible;

                        }
                    }
                }
                #endregion
            }
        }


        //public static void DesactiverMenuOperation(RadMenu rm,
        //                               CommandBarStripElement cbse,
        //                               string mode)
        //{
        //    #region chargerla liste des formulaires d'opérations
        //    List<FormulairesOperation> lstFormulairesOperation = new List<FormulairesOperation>();
        //    lstFormulairesOperation = FormulairesOperation.Liste(null, null, null, null, null, null, null, false, null);
        //    #endregion

        //    CurrentUser.LstDroitReelUser =
        //        ProfilDroit.DroitReelUtilisateur(CurrentUser.OUtilisateur.NumeroUtilisateur);
        //    if (rm != null)
        //    {
        //        #region Activation de menu
        //        foreach (FormulairesOperation unFormulairesOperation in lstFormulairesOperation)
        //        {
        //            foreach (ProfilDroit unDroitProfilUtil in CurrentUser.LstDroitReelUser)
        //            {
        //                RadMenuItem unSM = new RadMenuItem();
        //                string[] tabMenu = unDroitProfilUtil.ODroit.CheminMenu.Trim().Split(';');
        //                for (int i = 0; i < tabMenu.Length; i++)
        //                {
        //                    try
        //                    {
        //                        if (i == 0)
        //                        {
        //                            unSM = (RadMenuItem)rm.Items[tabMenu[i]];
        //                        }
        //                        else
        //                        {
        //                            unSM = (RadMenuItem)(unSM.Items[tabMenu[i]]);
        //                        }
        //                        if (unSM.Tag != null &&
        //                            (unSM.Tag.ToString().Trim() == mode.Trim() ||
        //                            (unSM.Tag.ToString().Trim().Split(';').Length == 2 &&
        //                             unSM.Tag.ToString().Trim().Split(';')[1] == mode.Trim())) && unSM.Name.Trim() == unFormulairesOperation.Menu.Trim())
        //                        {
        //                            unSM.Visibility = ElementVisibility.Collapsed;
        //                            break;
        //                        }
        //                    }
        //                    catch { }
        //                }
        //            }
        //        }
        //        #endregion
        //    }
        //    if (cbse != null)
        //    {
        //        #region désactivation et activation des boutons du toolstrip
        //        foreach (FormulairesOperation unFormulairesOperation in lstFormulairesOperation)
        //        {
        //            foreach (RadCommandBarBaseItem cb in cbse.Items)
        //            {
        //                if (cb.Tag != null && cb.Tag.ToString().Trim() != "")
        //                {
        //                    string[] tbDroit;
        //                    if (CurrentUser.LstDroitReelUser.Find(l => l.ODroit.CodeDroit.Trim() ==
        //                        cb.Tag.ToString().Trim().Split(';')[0]) != null)
        //                    {
        //                        tbDroit = CurrentUser.LstDroitReelUser.Find(l => l.ODroit.CodeDroit.Trim() ==
        //                        cb.Tag.ToString().Trim().Split(';')[0]).ODroit.CheminMenu.Split(';');

        //                        if (tbDroit[tbDroit.Length - 1].Trim() == unFormulairesOperation.Menu.Trim())
        //                            cb.Visibility = ElementVisibility.Collapsed;
        //                    }

        //                }
        //            }
        //        }
        //        #endregion
        //    }
        //}


        public static DateTime? RecupererDerniereDate(string mChamp, string mTableName)
        {
            DateTime? objRetour = null;
            SqlConnection sqlCon = new SqlConnection(Tools.GetDataBasePath());
            sqlCon.Open();
            string requete = "select isnull(max(" + mChamp +
                "),'01/01/1900') as date " +
                "From " + mTableName;
            SqlCommand sqlCmd = new SqlCommand(requete, sqlCon);
            objRetour = Convert.ToDateTime(sqlCmd.ExecuteScalar());
            sqlCon.Close();
            sqlCon = null;
            sqlCmd = null;
            return objRetour;
        }

        public static bool DetectClockManipulation(ref DateTime thresholdTime)
        {
            try
            {
                DateTime adjustedThresholdTime = new DateTime(thresholdTime.Year,
                        thresholdTime.Month, thresholdTime.Day, 23, 59, 59);

                EventLog eventLog = new System.Diagnostics.EventLog("system");

                foreach (EventLogEntry entry in eventLog.Entries)
                {
                    if (entry.TimeWritten.Date > adjustedThresholdTime.Date)
                    {
                        thresholdTime = entry.TimeWritten;
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
