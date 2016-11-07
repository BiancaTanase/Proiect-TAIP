using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CurtmolaClient
{
    public static class CryptographicService
    {
        #region settings
        
        // Initialization vector
        static byte[] IV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        static int keySize = 256;
        static int blockSize = 128;
        static int noIterations = 1000;
        static int IVsize = 8;
        #endregion

        #region Encryption

        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = keySize;
                    AES.BlockSize = blockSize;

                    var key = new Rfc2898DeriveBytes(passwordBytes, IV, noIterations);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var stream = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        stream.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        stream.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        public static void EncryptFile(string filePath, string encryptedFilePath, string password)
        {
            byte[] bytesToBeEncrypted = File.ReadAllBytes(filePath);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // compute a SHA-256 of password
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            // append random IV to encryption - achieve IND-CPA security for file encryption
            byte[] randomIV = GetRandomBytes();
            byte[] randomBytesToEncrypt = new byte[randomIV.Length + bytesToBeEncrypted.Length];

            for (int i = 0; i < randomIV.Length; i++)
            {
                randomBytesToEncrypt[i] = randomIV[i];
            }
            for (int i = 0; i < bytesToBeEncrypted.Length; i++)
            {
                randomBytesToEncrypt[i + randomIV.Length] = bytesToBeEncrypted[i];
            }

            byte[] bytesEncrypted = AES_Encrypt(randomBytesToEncrypt, passwordBytes);

            File.WriteAllBytes(encryptedFilePath, bytesEncrypted);
        }

        public static string EncryptKeyword(string keyword, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(keyword);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // compute a SHA-256 of password
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        #endregion

        #region Decryption

        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = keySize;
                    AES.BlockSize = blockSize;

                    var key = new Rfc2898DeriveBytes(passwordBytes, IV, noIterations);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var stream = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        stream.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        stream.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public static void DecryptFile(string encryptedFilePath, string filePath, string password)
        {
            byte[] bytesToBeDecrypted = File.ReadAllBytes(encryptedFilePath);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            //compute a SHA-256 of password
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] randomBytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
            byte[] bytesDecrypted = new byte[randomBytesDecrypted.Length - IVsize];

            for(int i=0;i<bytesDecrypted.Length;i++)
            {
                bytesDecrypted[i] = randomBytesDecrypted[i + IVsize];
            }

            File.WriteAllBytes(filePath, bytesDecrypted);
        }

        #endregion

        private static byte[] GetRandomBytes()
        {
            byte[] randomBytes = new byte[IVsize];
            RNGCryptoServiceProvider.Create().GetBytes(randomBytes);
            return randomBytes;
        }
    }
}
