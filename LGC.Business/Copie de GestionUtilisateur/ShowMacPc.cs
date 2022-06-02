using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace LGG.Business.GestionUtilisateur
{
    public class ShowMacPc
    {
        private string macAdres;

        public string MacAdres
        {
            get { return macAdres; }
            //set { macAdres = value; }
        }

        public static List<ShowMacPc> Liste()
        {
            List<ShowMacPc> listeMacAdresse = new List<ShowMacPc>();
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in nics)
            {
                //  MacAdresse oMacAdresse = new MacAdresse();
                IPInterfaceProperties properties = adapter.GetIPProperties();
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                string chaine = "";
                for (int i = 0; i < bytes.Length; i++)
                {
                    chaine += bytes[i].ToString("X2");
                    if (i != bytes.Length - 1)
                    {
                        chaine += "-";
                    }
                }
                if ((chaine.ToString().Trim() != "") 
                    && (chaine.ToString().Trim() != "00-00-00-00-00-00-00-E0"))
                {
                    ShowMacPc obj = new ShowMacPc();
                    obj.macAdres = chaine;
                    listeMacAdresse.Add(obj);
                }
            }
            return listeMacAdresse;
        }
    }

}
