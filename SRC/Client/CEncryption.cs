using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;


namespace Client
{
    public interface Procedure
    {
        string AES_Encrypt(string plainT, byte[] password);
        string AES_Decrypt(string cipherT, byte[] password);
    }

    public class PrincipalProcedure : Procedure
    {
        private CEncryption objEncryption;
        public string AES_Encrypt(string plainT, byte[] password)
        {
            if (objEncryption == null)
                objEncryption = new CEncryption();

            return objEncryption.AES_Encrypt(plainT, password);
        }

        public string AES_Decrypt(string cipherT, byte[] password)
        {
            if (objEncryption == null)
                objEncryption = new CEncryption();

            return objEncryption.AES_Decrypt(cipherT, password);
        }
    }

    class CEncryption : Procedure
    {
        
        public string AES_Encrypt(string plainT, byte[] password)
        {
            byte[] plainText = Encoding.UTF8.GetBytes(plainT);
            password = SHA256.Create().ComputeHash(password);

            byte[] encryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize   = 256;
                    AES.BlockSize = 128;

                    var key  = new Rfc2898DeriveBytes(password, password, 1000);
                    AES.Key  = key.GetBytes(AES.KeySize / 8);
                    AES.IV   = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (CryptoStream cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(plainText, 0, plainText.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public string AES_Decrypt(string cipherT, byte[] password)
        {
            byte[] cipherText = Convert.FromBase64String(cipherT);
            password          = SHA256.Create().ComputeHash(password);

            byte[] plainText = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize   = 256;
                    AES.BlockSize = 128;

                    var key  = new Rfc2898DeriveBytes(password, password, 1000);
                    AES.Key  = key.GetBytes(AES.KeySize / 8);
                    AES.IV   = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (CryptoStream cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherText, 0, cipherText.Length);
                        cs.Close();
                    }
                    plainText = ms.ToArray();
                }
            }

            return Encoding.UTF8.GetString(plainText);
        }
    }
}
