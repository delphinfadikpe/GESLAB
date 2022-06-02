using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LGG.Business
{
    public static class Fonction
    {
        public static string executerCommande(SerialPort serialPort, byte seq, byte cmd, List<byte> data)
        {
            #region DECLARATION DES VARIABLES

            byte soh = 0x01;
            byte etx = 0x03;
            byte amb = 0x05;
            byte len;
            byte bcc;
            List<byte> commande = new List<byte>();

            #endregion

            #region CONSTITUTION DE LA COMMANDE

            commande.Add(soh); // SOH -> 1ERE POSITION

            // CALCUL DE LA VALEUR DE "LEN"
            int size = data.Count + 4;
            //len = (byte)(int.Parse("" + size, System.Globalization.NumberStyles.HexNumber));
            //len += 0x20;
            len = (byte)size;
            len += 32;

            commande.Add(len); // LEN -> 2EME POSITION
            commande.Add(seq); // SEQ -> 3EME POSITION
            commande.Add(cmd); // CMD -> 4EME POSITION
            commande.AddRange(data); // DATA -> 5EME POSITION
            commande.Add(0x05); // AMB -> 6EME POSITION



            // CALCUL DE LA BCC
            var BCC = calculateCheckSum(commande.ToArray(), 1, size);

            commande.AddRange(BCC); // BCC -> 7EME POSITION
            commande.Add(0x03); // ETX -> 8EME POSITION

            //for (int i = 0; i < commande.Count; i++)
            //{
            //    Console.WriteLine(string.Format("{0:X}", commande[i]));
            //}
            #endregion

            #region EXECUTION DE LA COMMANDE ET TRAITEMENT DU RETOUR

            try
            {
                serialPort.Write(commande.ToArray(), 0, commande.Count);
                var response = new byte[256];
                int verif = 0;
                int index = 0;
                int endOfData = 0;
                bool done = false;
                // if (serialPort.BytesToRead > 0)
                {
                    while (!done)
                    {


                        byte current = (byte)serialPort.ReadByte();
                        if (index == 0 && current != 1)
                        {
                            verif = 0;
                        }
                        else
                        {
                            verif = 1;
                        }
                        if (verif == 1)
                        {
                            response[index++] = current;

                            if (current == 0x04)
                            {
                                endOfData = index;
                            }
                            if (current == 0x03)
                            {
                                done = true;
                            }
                        }

                    }

                    return Encoding.UTF8.GetString(response, 4, endOfData - 5);
                }
                //else
                //    return null;
            }
            catch (Exception ex)
            {

                //MessageBox.Show(null, ex.Message,
                //    CurrentInfo.LogicielHote, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;

            #endregion
        }

        public static byte[] calculateCheckSum(byte[] command, int start, int end)
        {
            var ret = new byte[4];
            var sum = 0;
            for (int i = start; i <= end; i++)
            {
                sum += command[i];
            }
            ret[0] = (byte)(((sum >> 12) & 0x0F) + 0x30);
            ret[1] = (byte)(((sum >> 8) & 0x0F) + 0x30);
            ret[2] = (byte)(((sum >> 4) & 0x0F) + 0x30);
            ret[3] = (byte)(((sum >> 0) & 0x0F) + 0x30);
            return ret;
        }

        public static byte convertirSeqInt(int seq_int)
        {
            //byte seq = (byte)(int.Parse("" + seq_int, System.Globalization.NumberStyles.HexNumber));
            byte seq = (byte)seq_int;
            seq += 0x20;

            if (seq == 0)
            {
                Commandes.SEQ_INT = 0;
                seq_int = Commandes.SEQ_INT;
                seq = (byte)seq_int;
                seq += 0x20;
            }

            return seq;
        }


        public static List<byte> getData(string data)
        {
            string tata = (data);
            byte[] toto = Encoding.UTF8.GetBytes(tata);
            List<byte> oListRetour = new List<byte>();
            oListRetour.AddRange(toto);
            //char[] values = data.ToCharArray();
            //List<byte> oListRetour = new List<byte>();
            //foreach (char letter in values)
            //{
            //    int value = Convert.ToInt32(letter);
            //    //byte toto = (byte)int.Parse("" + value, System.Globalization.NumberStyles.HexNumber);
            //    oListRetour.Add((byte)int.Parse("" + value, System.Globalization.NumberStyles.HexNumber));
            //}
            return oListRetour;
        }

        public static string[] traiterRetourCmde(string retour)
        {
            return retour.Split(',');
        }

        public static string RemplacerCaracSpec(string data)
        {
            string toto = data.Replace("\r", "^xa;").Replace("\n", "^xd;").Replace(",", "^x2c;").Replace("<", "^lt;").Replace(">", "^gt;").Replace("&", "^amp;");
            //return data.Replace("F", "1")/*.Replace("\r", "^xa;").Replace("\n", "^xd;").Replace(",", "^x2c;").Replace("<", "^lt;").Replace(">", "^gt;").Replace("&", "^amp;").Replace("F", "1")*/;
            return toto;
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        //public static string FormatEnterParameter(string nom, string desc, string tax, 
        //    string pr, string qt, string ts, string tsdesc, string prorig, string prdesc)
        //{

        //}

        public static List<byte> convertir(string input)
        {
            List<byte> oliste = new List<byte>();
            input = RemplacerCaracSpec(input);
            char[] values = input.ToCharArray();

            for (int i = 0; i < values.Length; i++)
            {
                if (Convert.ToInt32(values[i]) == 32)
                {
                    //var a = (byte)9;
                    //if (Convert.ToInt32(values[i + 1]) == 32 && Convert.ToInt32(values[i + 2]) == 32)
                    //{
                    //oliste.Add((byte)9);
                    //    i+=2;
                    //}
                    //else
                    //{
                    //    oliste.Add((byte)32);
                    //}
                }
                else
                {
                    oliste.Add((byte)Convert.ToInt32(values[i]));
                }
            }

            return oliste;
        }

        public static string Signature(string signature)
        {
            string output = "";
            char[] values = signature.ToCharArray();

            for (int i = 0; i < values.Length; i++)
            {
                if (i % 4 == 0 && i != values.Length - 1 && i != 0)
                {
                    output += "-";
                }
                output += values[i];
            }
            return output;
        }


        public static string dateSignature(string dateString)
        {
            string output = "";
            char[] values = dateString.ToCharArray();
            output = values[6].ToString() + values[7].ToString() + "/" + values[4].ToString() + values[5].ToString() + "/" +
                     values[0].ToString() + values[1].ToString() + values[2].ToString() + values[3].ToString() + " " +
                     values[8].ToString() + values[9].ToString() + ":" + values[10].ToString() + values[11].ToString() + ":" +
                     values[12].ToString() + values[13].ToString();
            return output;
        }

        public static string convertirNombreEnLettre(decimal chiffre)
        {
            int centaine, dizaine, unite, reste, y;
            bool dix = false;
            string lettre = "";
            //strcpy(lettre, "");

            reste = Convert.ToInt32(chiffre / 1);

            for (int i = 1000000000; i >= 1; i /= 1000)
            {
                y = reste / i;
                if (y != 0)
                {
                    centaine = y / 100;
                    dizaine = (y - centaine * 100) / 10;
                    unite = y - (centaine * 100) - (dizaine * 10);
                    switch (centaine)
                    {
                        case 0:
                            break;
                        case 1:
                            lettre += "cent ";
                            break;
                        case 2:
                            if ((dizaine == 0) && (unite == 0)) lettre += "deux cents ";
                            else lettre += "deux cent ";
                            break;
                        case 3:
                            if ((dizaine == 0) && (unite == 0)) lettre += "trois cents ";
                            else lettre += "trois cent ";
                            break;
                        case 4:
                            if ((dizaine == 0) && (unite == 0)) lettre += "quatre cents ";
                            else lettre += "quatre cent ";
                            break;
                        case 5:
                            if ((dizaine == 0) && (unite == 0)) lettre += "cinq cents ";
                            else lettre += "cinq cent ";
                            break;
                        case 6:
                            if ((dizaine == 0) && (unite == 0)) lettre += "six cents ";
                            else lettre += "six cent ";
                            break;
                        case 7:
                            if ((dizaine == 0) && (unite == 0)) lettre += "sept cents ";
                            else lettre += "sept cent ";
                            break;
                        case 8:
                            if ((dizaine == 0) && (unite == 0)) lettre += "huit cents ";
                            else lettre += "huit cent ";
                            break;
                        case 9:
                            if ((dizaine == 0) && (unite == 0)) lettre += "neuf cents ";
                            else lettre += "neuf cent ";
                            break;
                    }// endSwitch(centaine)

                    switch (dizaine)
                    {
                        case 0:
                            break;
                        case 1:
                            dix = true;
                            break;
                        case 2:
                            lettre += "vingt ";
                            break;
                        case 3:
                            lettre += "trente ";
                            break;
                        case 4:
                            lettre += "quarante ";
                            break;
                        case 5:
                            lettre += "cinquante ";
                            break;
                        case 6:
                            lettre += "soixante ";
                            break;
                        case 7:
                            dix = true;
                            lettre += "soixante ";
                            break;
                        case 8:
                            lettre += "quatre-vingt ";
                            break;
                        case 9:
                            dix = true;
                            lettre += "quatre-vingt ";
                            break;
                    } // endSwitch(dizaine)

                    switch (unite)
                    {
                        case 0:
                            if (dix) lettre += "dix ";
                            break;
                        case 1:
                            if (dix) lettre += "onze ";
                            else lettre += "un ";
                            break;
                        case 2:
                            if (dix) lettre += "douze ";
                            else lettre += "deux ";
                            break;
                        case 3:
                            if (dix) lettre += "treize ";
                            else lettre += "trois ";
                            break;
                        case 4:
                            if (dix) lettre += "quatorze ";
                            else lettre += "quatre ";
                            break;
                        case 5:
                            if (dix) lettre += "quinze ";
                            else lettre += "cinq ";
                            break;
                        case 6:
                            if (dix) lettre += "seize ";
                            else lettre += "six ";
                            break;
                        case 7:
                            if (dix) lettre += "dix-sept ";
                            else lettre += "sept ";
                            break;
                        case 8:
                            if (dix) lettre += "dix-huit ";
                            else lettre += "huit ";
                            break;
                        case 9:
                            if (dix) lettre += "dix-neuf ";
                            else lettre += "neuf ";
                            break;
                    } // endSwitch(unite)

                    switch (i)
                    {
                        case 1000000000:
                            if (y > 1) lettre += "milliards ";
                            else lettre += "milliard ";
                            break;
                        case 1000000:
                            if (y > 1) lettre += "millions ";
                            else lettre += "million ";
                            break;
                        case 1000:
                            lettre += "mille ";
                            break;
                    }
                } // end if(y!=0)
                reste -= y * i;
                dix = false;
            } // end for
            if (lettre.Length == 0) lettre += "zero";

            return lettre;
        }

        public static string Modereg(string modeReglement)
        {
            string retour = "";
            switch (modeReglement.Trim())
            {
                case "CHEQUES":
                    retour = "D";
                    break;
                case "ESPECES":
                    retour = "E";
                    break;
                case "VIREMENT":
                    retour = "V";
                    break;
                case "CARTE BANCAIRE":
                    retour = "C";
                    break;
                case "MOBILE MONEY":
                    retour = "M";
                    break;
                default:
                    retour = "A";
                    break;

            }

            return retour;
        }

    }
}
