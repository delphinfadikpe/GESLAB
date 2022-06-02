using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace LGG.Business.GestionUtilisateur
{
    public class ShowInternetProtocolPC
    {
       
        public static string[] GetIPaddresses(string computername) 
        { 
            //string chaine = null; 
            string[] saddr = null;
            IPAddress[] addr = Dns.GetHostEntry(computername).AddressList; 
          
            if (addr.Length > 0) 
            {
                saddr = new String[addr.Length]; 
                for (int i = 0; i < addr.Length; i++) 
                    //chaine +=  addr[i].ToString();
                    saddr[i] = addr[i].ToString();
            } 
            //return chaine; 

            return saddr;
        }



    }
}
