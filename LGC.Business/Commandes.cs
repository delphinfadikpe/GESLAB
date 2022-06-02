using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace LGG.Business
{
    public class Commandes
    {

        public static int SEQ_INT = 0;
        public static string IFU = "", TAXA = "", TAXB = "", TAXC = "", TAXD = "", NIM = "";

        //static void Main(string[] args)
        //{
        //    try
        //    {

        //        Console.WriteLine("Veuillez saisir le port de connexion svp:");
        //        string port = Console.ReadLine();

        //        var serialPort = new SerialPort(port.ToUpper(), 115200);
        //        serialPort.Open();

        //        Console.WriteLine("=========INFOS SUR LE CONTRIBUABLE===============");


        //        byte seq = Fonction.convertirSeqInt(SEQ_INT);
        //        _2Bh(serialPort, seq, "I0");

        //        SEQ_INT++;
        //        seq = Fonction.convertirSeqInt(SEQ_INT);
        //        _2Bh(serialPort, seq, "I1");

        //        SEQ_INT++;
        //        seq = Fonction.convertirSeqInt(SEQ_INT);
        //        _2Bh(serialPort, seq, "I2");

        //        SEQ_INT++;
        //        seq = Fonction.convertirSeqInt(SEQ_INT);
        //        _2Bh(serialPort, seq, "I3");

        //        SEQ_INT++;
        //        seq = Fonction.convertirSeqInt(SEQ_INT);
        //        _2Bh(serialPort, seq, "I4");
        //        Console.WriteLine("=========FIN INFOS SUR LE CONTRIBUABLE===============\n\n");

        //        Console.WriteLine("=========ETAT DE LA CONNECTIVITE AU SERVEUR (C2h)===============");
        //        SEQ_INT++;
        //        seq = Fonction.convertirSeqInt(SEQ_INT);
        //        C2h(serialPort, seq);
        //        Console.WriteLine("=========ETAT DE LA CONNECTIVITE AU SERVEUR (C2h)===============\n\n");




        //        Console.WriteLine("=========DEBUT DE LA NOUVELLE FACTURE===============\n\n");

        //        Console.WriteLine("[*******C1h (LIRE L'ETAT)******]");
        //        Console.WriteLine("DONNEES POUR C1h = [PAS DE DONNES] ");
        //        SEQ_INT++;
        //        seq = Fonction.convertirSeqInt(SEQ_INT);
        //        bool C1Valide;
        //        do
        //        {
        //            C1Valide = C1h(serialPort, seq);

        //            if (!C1Valide)
        //            {
        //                Console.WriteLine("[======ECHEC DE CONNEXION AU PC !======]");
        //            }
        //            else
        //                Console.WriteLine("[======CONNEXION EFFECTUEE AVEC SUCCES !======]");

        //        } while (!C1Valide);



        //        Console.WriteLine("[******* FIN C1h ******]\n\n");


        //        Console.WriteLine("[*******C0h (OUVRIR FACTURE)******]");
        //        SEQ_INT++;
        //        seq = Fonction.convertirSeqInt(SEQ_INT);
        //        testC0h(serialPort, seq);
        //        Console.WriteLine("[******* FIN C0h ******]\n\n");


        //        SEQ_INT++;
        //        seq = Fonction.convertirSeqInt(SEQ_INT);
        //        Console.WriteLine("[*******31h (INSCRIRE DES ARTICLES)******]\n\n");

        //        Console.WriteLine("ARTICLE 1: [Eau A380]");
        //        test31h(serialPort, seq, "Eau A380");
        //        Console.WriteLine("REPONSE: [AUCUNE REPONSE]");
        //        Console.WriteLine("[*******33h (SOUS-TOTAL)******]");
        //        test33h(serialPort, seq);
        //        Console.WriteLine("[******* FIN 33h******]");
        //        Console.WriteLine("FIN ARTICLE 1\n\n");


        //        Console.WriteLine("ARTICLE 2: [JUS B980]");
        //        test31h(serialPort, seq, "JUS B980");
        //        Console.WriteLine("REPONSE: [AUCUNE REPONSE]");
        //        Console.WriteLine("[*******33h (SOUS-TOTAL)******]");
        //        test33h(serialPort, seq);
        //        Console.WriteLine("[******* FIN 33h******]");
        //        Console.WriteLine("FIN ARTICLE 2\n\n");

        //        Console.WriteLine("ARTICLE 3: [JUS B980*2]");
        //        test31h(serialPort, seq, "JUS B980*2");
        //        Console.WriteLine("REPONSE: [AUCUNE REPONSE]");
        //        Console.WriteLine("[*******33h (SOUS-TOTAL)******]");
        //        test33h(serialPort, seq);
        //        Console.WriteLine("[******* FIN 33h******]");
        //        Console.WriteLine("FIN ARTICLE 3\n\n");

        //        Console.WriteLine("ARTICLE 4: [SPEC  B500*4;350]");
        //        test31h(serialPort, seq, "SPEC  B500*4;350");
        //        Console.WriteLine("REPONSE: [AUCUNE REPONSE]");
        //        Console.WriteLine("[*******33h (SOUS-TOTAL)******]");
        //        test33h(serialPort, seq);
        //        Console.WriteLine("[******* FIN 33h******]");
        //        Console.WriteLine("FIN ARTICLE 4\n\n");

        //        Console.WriteLine("[******* FIN C1h ******]\n\n");

        //        SEQ_INT++;
        //        seq = Fonction.convertirSeqInt(SEQ_INT);
        //        Console.WriteLine("[*******35h (CONFIRMATION FACTURE)******]");
        //        test35h(serialPort, seq);
        //        Console.WriteLine("[******* FIN 35hh ******]\n\n");

        //        SEQ_INT++;
        //        seq = Fonction.convertirSeqInt(SEQ_INT);
        //        Console.WriteLine("[*******38h (FERMER FACTURE)******]");
        //        test38h(serialPort, seq);
        //        Console.WriteLine("[******* FIN 38h ******]\n\n");



        //        Console.WriteLine("=========FIN DE LA FACTURE===============\n\n");

        //        serialPort.Close();

        //        Console.ReadKey(); // POUR FAIRE PAUSE
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.ReadKey();
        //    }
        //}

        public static bool C1h(SerialPort serialPort, byte seq)
        {
            byte cmd = 0xC1;
            string resultat1 = Fonction.executerCommande(serialPort, seq, cmd, new List<byte>());
            string[] retour = Fonction.traiterRetourCmde(resultat1);

            if (retour != null)
            {
                if (retour.Length != 10)
                {
                    return false;
                }
                else
                {
                    NIM = retour[0]; // RECUPERATION DU NUMERO DE SERIE DU MCF
                    IFU = retour[1]; // RECUPERATION DE L'IFU
                    TAXA = retour[6]; // RECUPERATION DE LA TAXA
                    TAXB = retour[7]; // RECUPERATION DE LA TAXB
                    TAXC = retour[8]; // RECUPERATION DE LA TAXC
                    TAXD = retour[9]; // RECUPERATION DE LA TAXD

                    return true;
                }
            }
            else
                return false;
        }

        public static void C2h(SerialPort serialPort, byte seq)
        {
            Console.WriteLine("DONNEES POUR C2h = [AUCUNE DONNEES]");
            byte cmd = 0xC2;
            string resultat1 = Fonction.executerCommande(serialPort, seq, cmd, new List<byte>());
            Console.WriteLine("REPONSE DE C2h = " + resultat1);
            //string[] retour = Fonction.traiterRetourCmde(resultat1);
            //Console.WriteLine(resultat1);
        }

        public static string _2Bh(SerialPort serialPort, byte seq, string donnees)
        {
            List<byte> data = new List<byte>();
            data = Fonction.getData(donnees);
            byte cmd = 0x2B;
            string resultat1 = Fonction.executerCommande(serialPort, seq, cmd, data);
            return (resultat1);
        }

        public static string testC0h(SerialPort serialPort, byte seq, int idOperateur, string nomOperateur, string ifuAcheteur, string nomAcheteur, string AIB, string typeFacture, string reference)
        {
            List<byte> data = new List<byte>();
            string donnee = idOperateur + "," + nomOperateur + "," + IFU.Replace(" ", "") + "," + TAXA + "," + TAXB + "," + TAXC + "," + TAXD + "," + typeFacture;

            if (typeFacture == "FA" || typeFacture == "EA")
                donnee += "," + reference;
            if (AIB == "0")
            {
                if (ifuAcheteur != string.Empty || nomAcheteur != string.Empty)
                    donnee += "," + ifuAcheteur.Replace(" ", "");

                if (nomAcheteur != string.Empty)
                    donnee += "," + nomAcheteur;
            }
            else
            {
                donnee += "," + ifuAcheteur.Replace(" ", "");
                donnee += "," + nomAcheteur;
                donnee += ",AIB" + AIB;
            }

            //Console.WriteLine("DONNEES POUR C0h = " + donnee);
            data = Fonction.getData(donnee);
            byte cmd = 0xC0;
            string resultat1 = Fonction.executerCommande(serialPort, seq, cmd, data);
            //Console.WriteLine("REPONSE DE C0h = " + resultat1 );
            return (resultat1);
        }

        public static string C0h(SerialPort serialPort, byte seq, 
            int idOperateur, string nomOperateur, string ifuAcheteur, 
            string nomAcheteur, string AIB, string typeFacture, string reference)
        {
            List<byte> donnee = new List<byte>();
            List<byte> idOperateurL = new List<Byte>(Encoding.UTF8.GetBytes(Fonction.RemplacerCaracSpec(Convert.ToString(idOperateur))));
            List<byte> nomOperateurL = new List<Byte>(Encoding.UTF8.GetBytes(Fonction.RemplacerCaracSpec(Convert.ToString(nomOperateur))));
            List<byte> ifuAcheteurL = new List<Byte>(Encoding.UTF8.GetBytes(Fonction.RemplacerCaracSpec(Convert.ToString(ifuAcheteur))));
            List<byte> nomAcheteurL = new List<Byte>(Encoding.UTF8.GetBytes(Fonction.RemplacerCaracSpec(Convert.ToString(nomAcheteur))));
            List<byte> AIBL = new List<Byte>(Encoding.UTF8.GetBytes(Fonction.RemplacerCaracSpec(Convert.ToString(AIB))));
            List<byte> typeFactureL = new List<Byte>(Encoding.UTF8.GetBytes(Fonction.RemplacerCaracSpec(Convert.ToString(typeFacture))));
            List<byte> referenceL = new List<Byte>(Encoding.UTF8.GetBytes(Fonction.RemplacerCaracSpec(Convert.ToString(reference))));
            List<byte> ifuL = new List<Byte>(Encoding.UTF8.GetBytes(Convert.ToString(IFU)));
            List<byte> TAXAL = new List<Byte>(Encoding.UTF8.GetBytes(Fonction.RemplacerCaracSpec(Convert.ToString(TAXA))));
            List<byte> TAXBL = new List<Byte>(Encoding.UTF8.GetBytes(Fonction.RemplacerCaracSpec(Convert.ToString(TAXB))));
            List<byte> TAXCL = new List<Byte>(Encoding.UTF8.GetBytes(Fonction.RemplacerCaracSpec(Convert.ToString(TAXC))));
            List<byte> TAXDL = new List<Byte>(Encoding.UTF8.GetBytes(Fonction.RemplacerCaracSpec(Convert.ToString(TAXD))));
            string virgule = Fonction.RemplacerCaracSpec(",");

            donnee.AddRange(idOperateurL);
            donnee.Add((byte)Convert.ToInt32(virgule[0]));
            donnee.AddRange(nomOperateurL);
            donnee.Add((byte)Convert.ToInt32(virgule[0]));
            donnee.AddRange(ifuL);
            donnee.Add((byte)Convert.ToInt32(virgule[0]));
            donnee.AddRange(TAXAL);
            donnee.Add((byte)Convert.ToInt32(virgule[0]));
            donnee.AddRange(TAXBL);
            donnee.Add((byte)Convert.ToInt32(virgule[0]));
            donnee.AddRange(TAXCL);
            donnee.Add((byte)Convert.ToInt32(virgule[0]));
            donnee.AddRange(TAXDL);
            donnee.Add((byte)Convert.ToInt32(virgule[0]));
            donnee.AddRange(typeFactureL);

            if (typeFacture == "FA")
            {
                donnee.Add((byte)Convert.ToInt32(virgule[0]));
                donnee.AddRange(referenceL);
            }
            if (AIB == "0")
            {
                if (ifuAcheteur != string.Empty || nomAcheteur != string.Empty)
                {
                    donnee.Add((byte)Convert.ToInt32(virgule[0]));
                    donnee.AddRange(ifuAcheteurL);
                }

                if (nomAcheteur != string.Empty)
                {
                    donnee.Add((byte)Convert.ToInt32(virgule[0]));
                    donnee.AddRange(nomAcheteurL);
                }
            }
            else
            {
                donnee.Add((byte)Convert.ToInt32(virgule[0]));
                donnee.AddRange(ifuAcheteurL);
                donnee.Add((byte)Convert.ToInt32(virgule[0]));
                donnee.AddRange(nomAcheteurL);
                donnee.Add((byte)Convert.ToInt32(virgule[0]));
                donnee.AddRange(AIBL);
            }

            byte cmd = 0xC0;
            string resultat1 = Fonction.executerCommande(serialPort, seq, cmd, donnee);

            return (resultat1);
        }

        public static string test31h(SerialPort serialPort, byte seq, string article)
        {
            List<byte> data = new List<byte>();
            //data = (Fonction.RemplacerCaracSpec(article));
            data = Fonction.convertir((article));
            byte cmd = 0x31;
            string resultat1 = Fonction.executerCommande(serialPort, seq, cmd, data);
            return (resultat1);
        }

        public static string C31h(SerialPort serialPort, byte seq, List<byte> data)
        {
            byte cmd = 0x31;
            string resultat1 = Fonction.executerCommande(serialPort, seq, cmd, data);
            return (resultat1);
        }

        public static string test33h(SerialPort serialPort, byte seq)
        {
            byte cmd = 0x33;
            string resultat1 = Fonction.executerCommande(serialPort, seq, cmd, new List<byte>());
            return (resultat1);
        }

        public static string test35h(SerialPort serialPort, byte seq)
        {
            //Console.WriteLine("DONNEES POUR 35h = [AUCUNE DONNEES]");
            byte cmd = 0x35;
            string resultat1 = Fonction.executerCommande(serialPort, seq, cmd, new List<byte>());
            //Console.WriteLine("REPONSE DE 35h =" + resultat1);
            return (resultat1);
        }

        public static string test35h(SerialPort serialPort, byte seq, string reglement)
        {
            //Console.WriteLine("DONNEES POUR 35h = [AVEC DONNEES]");
            List<byte> data = new List<byte>();
            data = Fonction.convertir((reglement));
            byte cmd = 0x35;
            string resultat1 = Fonction.executerCommande(serialPort, seq, cmd, data);
            //Console.WriteLine("REPONSE DE 35h =" + resultat1);
            return (resultat1);
        }
        public static string test38h(SerialPort serialPort, byte seq)
        {
            //Console.WriteLine("DONNEES POUR 38h = [AUCUNE DONNEES]");
            byte cmd = 0x38;
            string resultat1 = Fonction.executerCommande(serialPort, seq, cmd, new List<byte>());
            //Console.WriteLine("REPONSE DE 38h =" + resultat1 );
            return (resultat1);
        }
    }
}
