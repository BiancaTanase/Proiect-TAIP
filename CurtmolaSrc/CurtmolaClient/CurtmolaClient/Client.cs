using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerializedData;
using Server;

namespace CurtmolaClient
{
    class Client
    {
        public string password = string.Empty;
        public static string ipAddress = "127.0.0.1";
        public static int PORT = 8081;
        public const string ENC = "ENCRYPTED";
        public const string DEC = "DECRYPTED";
        public List<string> files = new List<string>();
        public List<string> keywords = new List<string>();
        public List<Node> A;
        public List<TField> T;
        public Socket socket;
        public const string serializedFiles = "Files.os1";
        public const string serializedKeywords = "Keywords.os1";
        internal string name;

        string GetPassword()
        {
            string pass = string.Empty;

            using (StreamReader reader = new StreamReader("SETTINGS.txt"))
            {
                pass = reader.ReadLine();
            }

            return pass;
        }

        void CreateStructures()
        {
            A = new List<Node>();
            T = new List<TField>();

            foreach (string keyword in keywords)
            {
                List<Node> tempList = new List<Node>();
                int index = 0;

                // build the linked list of current keyword
                foreach (string file in files)
                {
                    // get the file's ID
                    string fileName = Path.GetFileNameWithoutExtension(file) + new FileInfo(file).Extension;

                    if (KeywordInFile(keyword, file))
                    {
                        Node node = new Node();
                        node.FileID = fileName;

                        if (index > 0) // other nodes
                        {
                            tempList[index - 1].Next = node;
                            tempList.Add(node);
                        }
                        else // first node
                        {
                            tempList.Add(node);
                        }

                        index++;
                    }
                }

                // add nodes to array A
                for (index = 0; index < tempList.Count; index++)
                {
                    A.Add(tempList[index]);
                    if (index == 0)
                    {
                        TField field = new TField();
                        field.Keyword = CryptographicService.EncryptKeyword(keyword, password);
                        field.Position = A.Count - 1;
                        T.Add(field);
                    }
                }
            }

            // randomize nodes' positions in A
            ShuffleArrayA();
        }

        void ShuffleArrayA()
        {
            Random rng = new Random();

            int index = A.Count - 1;
            while (index > 0)
            {
                int k = rng.Next(index + 1);

                Node value = A[k];
                A[k] = A[index];
                A[index] = value;

                foreach (TField field in T)
                {
                    if (field.Position == index)
                    {
                        field.Position = k;
                    }
                    else if (field.Position == k)
                    {
                        field.Position = index;
                    }
                }

                index--;
            }
        }

        public void Register()
        {
            int nr;
            bool result = false;
            byte[] response = null;

            try
            {
                if (socket != null)
                {
                    // send option for Index Generation
                    int option = (int)Utilities.Request.Register;
                    byte[] buffer = new byte[4];
                    buffer = BitConverter.GetBytes(option);
                    socket.Send(buffer);

                    buffer = Encoding.UTF8.GetBytes(this.name);
                    socket.Send(BitConverter.GetBytes(buffer.Length));
                    socket.Send(buffer);

                    buffer = Encoding.UTF8.GetBytes(this.password);
                    socket.Send(BitConverter.GetBytes(buffer.Length));
                    socket.Send(buffer);

                    // receive
                    buffer = new byte[4];
                    int index = 0;
                    while (index < 4)
                    {
                        nr = socket.Receive(buffer, index, 4 - index, SocketFlags.None);
                        index += nr;
                    }
                    int size = BitConverter.ToInt32(buffer, 0);

                    response = new byte[size];
                    index = 0;
                    while (index < size)
                    {
                        nr = socket.Receive(response, index, size - index, SocketFlags.None);
                        index += nr;
                    }

                    string resultStr = Encoding.UTF8.GetString(response);
                    
                    MessageBox.Show(resultStr);
                }
            }
            catch (Exception ex)
            {
                socket.Disconnect(false);
                socket.Close();
            }
        }

        public bool Login()
        {
            int nr;
            bool result = false;
            byte[] response = null;

            try
            {
                if (socket != null)
                {
                    // send option for Index Generation
                    int option = (int)Utilities.Request.Login;
                    byte[] buffer = new byte[4];
                    buffer = BitConverter.GetBytes(option);
                    socket.Send(buffer);

                    buffer = Encoding.UTF8.GetBytes(this.name);
                    socket.Send(BitConverter.GetBytes(buffer.Length));
                    socket.Send(buffer);

                    buffer = Encoding.UTF8.GetBytes(this.password);
                    socket.Send(BitConverter.GetBytes(buffer.Length));
                    socket.Send(buffer);

                    // receive
                    Array.Clear(buffer, 0, buffer.Length);
                    int index = 0;
                    while (index < 1)
                    {
                        nr = socket.Receive(buffer, index, 1 - index, SocketFlags.None);
                        index += nr;
                    }
                    result = BitConverter.ToBoolean(buffer, 0);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                socket.Disconnect(false);
                socket.Close();
            }
            return result;
        }


        public void SendToServer()
        {
            try
            {
                CreateStructures();

                if (socket != null)
                {
                    // send option for Index Generation
                    int option = (int)Utilities.Request.AddData;
                    byte[] buffer = new byte[4];
                    buffer = BitConverter.GetBytes(option);
                    socket.Send(buffer);
                                        
                    // send the number of files
                    int nrFiles = files.Count;
                    buffer = BitConverter.GetBytes(nrFiles);
                    socket.Send(buffer);

                    // send the encrypted files
                    foreach (string file in files)
                    {
                        string ext = new FileInfo(file).Extension;
                        string encFile = file.Replace(ext, "") + ENC + ext;

                        CryptographicService.EncryptFile(file, encFile, password);
                        File.Delete(file);
                        File.Move(encFile, file);

                        // get the file's ID
                        string fileName = Path.GetFileNameWithoutExtension(file) + new FileInfo(file).Extension;

                        // send filename length
                        int length = fileName.Length;
                        buffer = BitConverter.GetBytes(length);
                        socket.Send(buffer);

                        // send filename
                        buffer = Encoding.UTF8.GetBytes(fileName);
                        socket.Send(buffer);

                        // send file size
                        byte[] fileBytes = File.ReadAllBytes(file);
                        length = fileBytes.Length;
                        buffer = BitConverter.GetBytes(length);
                        socket.Send(buffer);

                        // send file
                        socket.Send(fileBytes);
                        //File.Delete(file);
                    }

                    // send A and T structures
                    Stream stream = new NetworkStream(socket);
                    var bin = new BinaryFormatter();
                    bin.Serialize(stream, A);
                    bin.Serialize(stream, T);

                }

                // serialize the file names and keywords so the user knows the current state of the remote database
                SerializeStructures();
            }
            catch (Exception ex)
            {
                socket.Disconnect(false);
                socket.Close();
            }
        }

        public void ReceiveFromServer(string keyword)
        {
            byte[] buffer = new byte[4];
            int index, nr;

            try
            {
                // send option for Retrieve
                int option = (int)Utilities.Request.RequestData;
                buffer = BitConverter.GetBytes(option);
                socket.Send(buffer);

                // encrypt keyword
                string encKeyWord = CryptographicService.EncryptKeyword(keyword, password);

                // send keyword length
                int keyWordLength = encKeyWord.Length;
                buffer = BitConverter.GetBytes(keyWordLength);
                socket.Send(buffer);

                // send keyword
                byte[] keywordBytes = Encoding.UTF8.GetBytes(encKeyWord);
                socket.Send(keywordBytes);

                // receive number of files
                Array.Clear(buffer, 0, buffer.Length);
                index = 0;
                while (index < 4)
                {
                    nr = socket.Receive(buffer, index, 4 - index, SocketFlags.None);
                    index += nr;
                }
                int nrFiles = BitConverter.ToInt32(buffer, 0);

                for (int i = 0; i < nrFiles; i++)
                {
                    // receive file name length
                    Array.Clear(buffer, 0, buffer.Length);
                    index = 0;
                    while (index < 4)
                    {
                        nr = socket.Receive(buffer, index, 4 - index, SocketFlags.None);
                        index += nr;
                    }
                    int fileNameLength = BitConverter.ToInt32(buffer, 0);

                    // receive file name
                    byte[] fileNameBytes = new byte[fileNameLength];
                    index = 0;
                    while (index < fileNameLength)
                    {
                        nr = socket.Receive(fileNameBytes, index, fileNameLength - index, SocketFlags.None);
                        index += nr;
                    }
                    string file = Encoding.UTF8.GetString(fileNameBytes, 0, fileNameBytes.Length);

                    // receive file Size
                    Array.Clear(buffer, 0, buffer.Length);
                    index = 0;
                    while (index < 4)
                    {
                        nr = socket.Receive(buffer, index, 4 - index, SocketFlags.None);
                        index += nr;
                    }
                    int fileSize = BitConverter.ToInt32(buffer, 0);

                    // receive file
                    byte[] fileBytes = new byte[fileSize];
                    index = 0;
                    while (index < fileSize)
                    {
                        nr = socket.Receive(fileBytes, index, fileSize - index, SocketFlags.None);
                        index += nr;
                    }
                    File.WriteAllBytes(file, fileBytes);

                    // decrypt the received file
                    string ext = new FileInfo(file).Extension;
                    string decFileName = file.Replace(ext, "") + DEC + ext;
                    CryptographicService.DecryptFile(file, decFileName, password);
                    File.Delete(file);
                    File.Move(decFileName, file);
                }
            }
            catch (Exception)
            {
                socket.Disconnect(false);
                socket.Close();
            }
        }

        static bool KeywordInFile(string keyword, string filePath)
        {
            bool retVal = false;
            string line;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(keyword))
                        {
                            retVal = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                retVal = false;
            }

            return retVal;
        }

        public Socket CreateEndPoint()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), PORT);

            try
            {
                socket.Connect(ep);
            }
            catch (Exception)
            {
                socket = null;
            }

            return socket;
        }

        public void SerializeStructures()
        {
            try
            {
                using (Stream stream = File.Open(serializedFiles, FileMode.Create))
                {
                    BinaryFormatter bformatter = new BinaryFormatter();
                    bformatter.Serialize(stream, files);
                }

                using (Stream stream = File.Open(serializedKeywords, FileMode.Create))
                {
                    BinaryFormatter bformatter = new BinaryFormatter();
                    bformatter.Serialize(stream, keywords);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void DeserializeStructures()
        {
            try
            {
                if (File.Exists(serializedFiles))
                {
                    using (Stream stream = File.Open(serializedFiles, FileMode.Open))
                    {
                        BinaryFormatter bformatter = new BinaryFormatter();
                        files = (List<string>)bformatter.Deserialize(stream);
                    }
                }

                if (File.Exists(serializedKeywords))
                {
                    using (Stream stream = File.Open(serializedKeywords, FileMode.Open))
                    {
                        BinaryFormatter bformatter = new BinaryFormatter();
                        keywords = (List<string>)bformatter.Deserialize(stream);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


    }
}
