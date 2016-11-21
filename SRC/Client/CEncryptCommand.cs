using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Client
{
    public class CEncryptCommand
    {
        private byte[] bytesPlainText = null;
        private byte[] bytesCipherText = null;
        private byte[] messageToSend = null;
        private string publicKey = "";
        private string privateKey = "";

        public byte[] PreparePackageToSend(byte[] bytesPlainText, string publicKey)
        {
            this.bytesPlainText = bytesPlainText;
            this.publicKey = publicKey;

            Encryption();
            byte[] result = Sha256(bytesCipherText);

            try
            {
                messageToSend = new byte[bytesCipherText.Length + result.Length];

                bytesCipherText.CopyTo(messageToSend, 0);
                result.CopyTo(messageToSend, bytesCipherText.Length);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Concatenation failed.");
            }

            return messageToSend;
        }

        public byte[] DecodifyPackage(byte[] bytesCipherText, string privateKey)
        {
            this.privateKey = privateKey;
            this.bytesCipherText = null;

            try
            {
                var testSha256 = bytesCipherText.Skip(bytesCipherText.Length - 32).Take(32).ToArray();
                this.bytesCipherText = bytesCipherText.Take(bytesCipherText.Length - 32).ToArray();

                if (testSha256.SequenceEqual(Sha256(this.bytesCipherText)))
                {
                    Decryption();
                    return bytesPlainText;
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Test Package failed.");
            }

            return null;

        }

        public void generateKey()
        {
            try
            {
                var csp = new RSACryptoServiceProvider(2048);
                var privKey = csp.ExportParameters(true);
                var pubKey = csp.ExportParameters(false);

                var sw = new System.IO.StringWriter();
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                xs.Serialize(sw, pubKey);

                publicKey = sw.ToString();

                sw = new System.IO.StringWriter();
                xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                xs.Serialize(sw, privKey);

                privateKey = sw.ToString();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Generate Key failed.");

            }
        }

        public string getPubKey()
        {
            return publicKey;
        }

        public string getPrivKey()
        {
            return privateKey;
        }

        private void Encryption()
        {
            try
            {
                var sr = new System.IO.StringReader(publicKey);
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                var pubKey = (RSAParameters)xs.Deserialize(sr);
                var csp = new RSACryptoServiceProvider();
                csp.ImportParameters(pubKey);

                bytesCipherText = csp.Encrypt(bytesPlainText, false);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Encryption failed.");

            }
        }

        private void Decryption()
        {
            try
            {
                var sr = new System.IO.StringReader(privateKey);
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                var privKey = (RSAParameters)xs.Deserialize(sr);
                var csp = new RSACryptoServiceProvider();
                csp.ImportParameters(privKey);

                bytesPlainText = csp.Decrypt(bytesCipherText, false);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Decryption failed.");

            }
        }

        private byte[] Sha256(byte[] textToHash)
        {
            byte[] result = null;

            try
            {
                SHA256 hash = SHA256Managed.Create();
                result = hash.ComputeHash(textToHash);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Hash failed.");
            }

            return result;

        }
    }
}

