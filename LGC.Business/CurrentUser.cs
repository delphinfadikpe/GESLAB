using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using LGC.Business.Parametre;
using System.Windows.Forms;
using System.Security.Cryptography;
using LGC.Business.GestionUtilisateur;
using LGC.Business.Parametre;
using System.IO.Ports;
//using LGC.Business.Comptabilite;
//using BGS.Business.School;
//using System.Windows.Forms;

namespace LGC.Business
{
    public static class CurrentUser
    {

        public static string port = string.Empty;
        public static int SEQ_INT = 1;
        public static string nom = "";
        public static string adresse = "";
        public static string ville = "";
        public static string telephone = "";
        public static string mail = "";
        public static int p = 0;
        public static SerialPort serialPort = null;

        private static string appPath = Path.GetDirectoryName(Application.ExecutablePath);

        public static string AppPath
        {
            get { return CurrentUser.appPath; }
            set { CurrentUser.appPath = value; }
        }
        //private static Opcvm oOpcvm = null;

        //public static Opcvm OOpcvm
        //{
        //    get { return CurrentUser.oOpcvm; }
        //    set { CurrentUser.oOpcvm = value; }
        //}

        private static Societe oSociete = null;

        public static Societe OSociete
        {
            get { return CurrentUser.oSociete; }
            set { CurrentUser.oSociete = value; }


        }
        private static string userLogin = "GALI";

        private static string currentLangue = "fr-FR";

        private static string nomServeurProductionTitre = "";
        private static int idOpcvm = 0;
        private static decimal idSeance = 1;
        private static DateTime dateOuverture = DateTime.Now;
        private static DateTime dateFermeture = DateTime.Now;
        private static decimal vL = 5000;
        private static string idTransaction = "1";
        private static bool estEnCloture = false;

        public static bool EstEnCloture
        {
            get { return CurrentUser.estEnCloture; }
            set { CurrentUser.estEnCloture = value; }
        }
        public static string NomServeurProduction
        {
            get { return CurrentUser.nomServeurProductionTitre; }
            set { CurrentUser.nomServeurProductionTitre = value; }
        }

        private static DateTime dateExpirationLogiciel;

        public static DateTime DateExpirationLogiciel
        {
            get
            {
                List<Securite> lstSecurite = Securite.Liste(
                    null, null, null, null,
                    null, null, false, null);
                if (lstSecurite != null &&
                    lstSecurite.Count != 0)
                {
                    try
                    {
                        return Convert.ToDateTime(
                                    Tools.DecryptString(lstSecurite[0].Str,
                                    "abc123deaoezdf77", "abc123deaoezdf78"));
                    }
                    catch
                    {
                        return DateTime.Now.Date.AddDays(-1);
                    }
                }
                else
                {
                    return DateTime.Now.Date.AddDays(-1);
                }
            }
        }

        private static Utilisateur oUtilisateur = null;
        private static Profil oProfil = null;

        public static Profil OProfil
        {
            get { return CurrentUser.oProfil; }
            set { CurrentUser.oProfil = value; }
        }

        public static Utilisateur OUtilisateur
        {
            get { return oUtilisateur; }
            set { oUtilisateur = value; }
        }

        public static int IdOpcvm
        {
            get { return CurrentUser.idOpcvm; }
            set { CurrentUser.idOpcvm = value; }
        }

        public static string IdTransaction
        {
            get { return CurrentUser.idTransaction.Trim(); }
            set { CurrentUser.idTransaction = value; }
        }

        public static decimal IdSeance
        {
            get { return CurrentUser.idSeance; }
            set { CurrentUser.idSeance = value; }
        }

        public static decimal VL
        {
            get { return CurrentUser.vL; }
            set { CurrentUser.vL = value; }
        }

        public static DateTime DateOuverture
        {
            get { return CurrentUser.dateOuverture; }
            set { CurrentUser.dateOuverture = value; }
        }

        public static DateTime DateFermeture
        {
            get { return CurrentUser.dateFermeture; }
            set { CurrentUser.dateFermeture = value; }
        }

        private static string nomServeurProductionPersonne = "";

        public static string NomServeurProductionPersonne
        {
            get { return CurrentUser.nomServeurProductionPersonne; }
            set { CurrentUser.nomServeurProductionPersonne = value; }
        }

        //private static string appPath = Path.GetDirectoryName(Application.ExecutablePath);

        //public static string AppPath
        //{
        //    get { return CurrentUser.appPath; }
        //    set { CurrentUser.appPath = value; }
        //}

        private static string themeName = "";

        public static string ThemeName
        {
            get { return CurrentUser.themeName; }
            set { CurrentUser.themeName = value; }
        }
        public static string UserLogin
        {
            get
            {
                return userLogin;
            }
            set
            {
                userLogin = value;
            }
        }

        public static string CurrentLangue
        {
            get
            {
                return currentLangue;
            }
            set
            {
                currentLangue = value;
            }
        }

        private static JournalConnexion oJournalConnexion = null;

        public static JournalConnexion OJournalConnexion
        {
            get { return CurrentUser.oJournalConnexion; }
            set { CurrentUser.oJournalConnexion = value; }
        }

        private static string modeCon = string.Empty;

        public static string ModeCon
        {
            get { return CurrentUser.modeCon; }
            set { CurrentUser.modeCon = value; }
        }

        private static string nomUtilisateur = string.Empty;

        public static string NomUtilisateur
        {
            get { return CurrentUser.nomUtilisateur; }
            set { CurrentUser.nomUtilisateur = value; }
        }

        private static string pwd = string.Empty;

        public static string Pwd
        {
            get { return CurrentUser.pwd; }
            set { CurrentUser.pwd = value; }
        }

        private static List<ProfilDroit> lstDroitReelUser = new List<ProfilDroit>();

        public static List<ProfilDroit> LstDroitReelUser
        {
            get { return CurrentUser.lstDroitReelUser; }
            set { CurrentUser.lstDroitReelUser = value; }
        }
        private static string imagePath = "";

        public static string ImagePath
        {
            get { return CurrentUser.imagePath; }
            set { CurrentUser.imagePath = value; }
        }
        private static string logicielHote = "GESLAB 1.0";

        public static string LogicielHote
        {
            get { return CurrentUser.logicielHote; }
            set { CurrentUser.logicielHote = value; }
        }

        //private static Exercice oExercice;
        public static string MessageErreur = "Une erreur s'est produite lors de l'exécution de cette instruction.\n Veuillez conctacter l'administrateur";


        //public static Exercice OExercice
        //{
        //    get { return CurrentUser.oExercice; }
        //    set { CurrentUser.oExercice = value; }
        //}
        
        public static void MAJ_DB_Connection()
        {
            if (CurrentUser.ModeCon.Trim() == "S")
            {
                LGC.DataAccess.Properties.Settings.Default.DB_LABOConnectionString =
                    @"Data Source=" + CurrentUser.NomServeurProduction.Trim() +
                                    ";Initial Catalog= DB_LABO" +
                                    ";Persist Security Info=True;User ID=" + CurrentUser.nomUtilisateur.Trim() +
                                    ";Password=" + CurrentUser.pwd.Trim() + "";

               


            }
            else
            {
                LGC.DataAccess.Properties.Settings.Default.DB_LABOConnectionString =
                    @"Data Source=" + CurrentUser.NomServeurProduction.Trim() +
                                    ";Initial Catalog= DB_LABO" +
                                    ";Integrated Security=True";

               


            }

            //LGC.Business.CurrentUser.MAJ_DB_Connection();

        }

        public static bool IsNumeric(string Nombre)
        {
            try
            {
                int.Parse(Nombre);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #region cryptographie
        public static string HashWithMD5(string stringToHash)
        {
            MD5 md5HashALGC = MD5.Create();

            // Place le texte à hacher dans un tableau d'octets 
            byte[] byteArrayToHash = Encoding.UTF8.GetBytes(stringToHash);

            // Hash le texte et place le résulat dans un tableau d'octets 
            byte[] hashResult = md5HashALGC.ComputeHash(byteArrayToHash);

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hashResult.Length; i++)
            {
                // Affiche le Hash en hexadecimal 
                result.Append(hashResult[i].ToString("X2"));
            }

            return result.ToString();
        }

        /// 
        /// Chiffre une chaîne de caractère
        /// 
        /// Texte clair à chiffrer
        /// Clé de chiffrement
        /// Vecteur d'initialisation
        /// Retourne le texte chiffré
        public static string EncryptString(string clearText, string strKey, string strIv)
        {

            // Place le texte à chiffrer dans un tableau d'octets
            byte[] plainText = Encoding.UTF8.GetBytes(clearText);

            // Place la clé de chiffrement dans un tableau d'octets
            byte[] key = Encoding.UTF8.GetBytes(strKey);

            // Place le vecteur d'initialisation dans un tableau d'octets
            byte[] iv = Encoding.UTF8.GetBytes(strIv);


            RijndaelManaged rijndael = new RijndaelManaged();

            // Définit le mode utilisé
            rijndael.Mode = CipherMode.CBC;

            // Crée le chiffreur AES - Rijndael
            ICryptoTransform aesEncryptor = rijndael.CreateEncryptor(key, iv);

            MemoryStream ms = new MemoryStream();

            // Ecris les données chiffrées dans le MemoryStream
            CryptoStream cs = new CryptoStream(ms, aesEncryptor, CryptoStreamMode.Write);
            cs.Write(plainText, 0, plainText.Length);
            cs.FlushFinalBlock();


            // Place les données chiffrées dans un tableau d'octet
            byte[] CipherBytes = ms.ToArray();


            ms.Close();
            cs.Close();

            // Place les données chiffrées dans une chaine encodée en Base64
            return Convert.ToBase64String(CipherBytes);


        }

        /// <summary>
        /// Déchiffre une chaîne de caractère
        /// </summary>
        /// <param name="cipherText">Texte chiffré</param>
        /// <param name="strKey">Clé de déchiffrement</param>
        /// <param name="strIv">Vecteur d'initialisation</param>
        /// <returns></returns>
        public static string DecryptString(string cipherText, string strKey, string strIv)
        {

            // Place le texte à déchiffrer dans un tableau d'octets
            byte[] cipheredData = Convert.FromBase64String(cipherText);

            // Place la clé de déchiffrement dans un tableau d'octets
            byte[] key = Encoding.UTF8.GetBytes(strKey);

            // Place le vecteur d'initialisation dans un tableau d'octets
            byte[] iv = Encoding.UTF8.GetBytes(strIv);

            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.Mode = CipherMode.CBC;


            // Ecris les données déchiffrées dans le MemoryStream
            ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv);
            MemoryStream ms = new MemoryStream(cipheredData);
            CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);

            // Place les données déchiffrées dans un tableau d'octet
            byte[] plainTextData = new byte[cipheredData.Length];

            int decryptedByteCount = cs.Read(plainTextData, 0, plainTextData.Length);

            ms.Close();
            cs.Close();

            return Encoding.UTF8.GetString(plainTextData, 0, decryptedByteCount);

        }
        #endregion

    }
}
