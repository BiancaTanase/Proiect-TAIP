﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SerializedData;
using Server;

namespace CurtmolaServer
{
    public class Server
    {
        #region settings
        TAIPDatabase db = TAIPDatabase.Instance;
        const int PORT = 8081;
        ManualResetEvent queryHandled = new ManualResetEvent(false);
        List<string> files;
        List<Node> A;
        List<TField> T;
        const string serializedAFile = "A.os1";
        const string serializedTFile = "T.os1";
        int clientIndex = 0;
        List<int> autentificate = new List<int>();
        #endregion

        #region Constructor
        public Server()
        {
            DeserializeStructures();

            // create a listening socket on the specified port
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, PORT);

            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(ep);
                listener.Listen(100);

                while (true)
                {
                    queryHandled.Reset();

                    // Listen for connections...
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a client has connected to wait for others
                    queryHandled.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.Read();
        }

        #endregion

        private void AcceptCallback(IAsyncResult ar)
        {
            queryHandled.Set();
            clientIndex++;
            Console.WriteLine("Client with ID {0} connected...", clientIndex);
            byte[] bytes = new byte[4];
            int nr, index;
            bool autentificate = false;
            string user = String.Empty;

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            try
            {
                while (true) // server is not concurrential since the model is Single-Writer/Single-Reader
                {
                    // receive option
                    bytes = new byte[4];

                    index = 0;
                    while (index < 4)
                    {
                        nr = handler.Receive(bytes, index, 4 - index, SocketFlags.None);
                        index += nr;
                    }
                    int option = BitConverter.ToInt32(bytes, 0);

                    switch(option)
                    {
                        case (int)Utilities.Request.Register:
                            {
                                int length = Utilities.ReadLength(handler);
                                string name = Utilities.ReadString(handler, length);
                                length = Utilities.ReadLength(handler);
                                string pass = Utilities.ReadString(handler, length);

                                string response = db.AddUser(name, pass);

                                Array.Clear(bytes, 0, bytes.Length);
                                bytes = BitConverter.GetBytes(response.Length);
                                handler.Send(bytes);
                                
                                byte[] fileNameBytes = Encoding.UTF8.GetBytes(response);
                                handler.Send(fileNameBytes);

                                break;
                            }
                        case (int)Utilities.Request.Login:
                            {
                                int length = Utilities.ReadLength(handler);
                                string name = Utilities.ReadString(handler, length);
                                length = Utilities.ReadLength(handler);
                                string pass = Utilities.ReadString(handler, length);

                                bool response = db.VerifyUser(name, pass);

                                Array.Clear(bytes, 0, bytes.Length);
                                bytes = BitConverter.GetBytes(response);
                                handler.Send(bytes);

                                if(response == true)
                                {
                                    autentificate = true;
                                    user = name;
                                }

                                break;
                            }

                        default:
                            {
                                if (autentificate)
                                {
                                    if (option == (int)Utilities.Request.AddData) // Store files
                                    {
                                        List<byte[]> fBytes = new List<byte[]>();
                                        // delete all existing files to rebuild the index
                                        //DeleteExistingFiles();

                                        // reinitialize the list of files
                                        files = new List<string>();

                                        // receive number of files
                                        Array.Clear(bytes, 0, bytes.Length);
                                        index = 0;
                                        while (index < 4)
                                        {
                                            nr = handler.Receive(bytes, index, 4 - index, SocketFlags.None);
                                            index += nr;
                                        }
                                        int nrFiles = BitConverter.ToInt32(bytes, 0);

                                        for (int i = 0; i < nrFiles; i++)
                                        {
                                            // receive file name length
                                            Array.Clear(bytes, 0, bytes.Length);
                                            index = 0;
                                            while (index < 4)
                                            {
                                                nr = handler.Receive(bytes, index, 4 - index, SocketFlags.None);
                                                index += nr;
                                            }
                                            int fileNameLength = BitConverter.ToInt32(bytes, 0);

                                            // receive file name
                                            byte[] fileNameBytes = new byte[fileNameLength];
                                            index = 0;
                                            while (index < fileNameLength)
                                            {
                                                nr = handler.Receive(fileNameBytes, index, fileNameLength - index, SocketFlags.None);
                                                index += nr;
                                            }
                                            string fileName = Encoding.UTF8.GetString(fileNameBytes, 0, fileNameBytes.Length);

                                            // receive file size
                                            Array.Clear(bytes, 0, bytes.Length);
                                            index = 0;
                                            while (index < 4)
                                            {
                                                nr = handler.Receive(bytes, index, 4 - index, SocketFlags.None);
                                                index += nr;
                                            }
                                            int fileSize = BitConverter.ToInt32(bytes, 0);

                                            //receive file
                                            byte[] fileBytes = new byte[fileSize];
                                            index = 0;
                                            while (index < fileSize)
                                            {
                                                nr = handler.Receive(fileBytes, index, fileSize - index, SocketFlags.None);
                                                index += nr;
                                            }

                                            fBytes.Add(fileBytes);
                                            //db.AddToFolder(user, fileName, fileBytes, keywords);
                                            //File.WriteAllBytes(fileName, fileBytes);
                                            files.Add(fileName);
                                        }

                                        // receive A and T structures
                                        Stream stream = new NetworkStream(handler);
                                        var bin = new BinaryFormatter();
                                        A = new List<Node>();
                                        A = (List<Node>)bin.Deserialize(stream);
                                        T = new List<TField>();
                                        T = (List<TField>)bin.Deserialize(stream);

                                        string keywords = String.Empty;
                                        foreach (TField field in T)
                                        {
                                            keywords += field.Keyword;
                                        }

                                        for (int i = 0; i < files.Count; ++i)
                                            db.AddToFolder(user, files[i], fBytes[i], keywords);

                                        // serialize the data received, so the server will keep the structures after it is reopened
                                        SerializeStructures();
                                    }
                                    else if (option == (int)Utilities.Request.RequestData) // Send files
                                    {
                                        // receive leyword length
                                        Array.Clear(bytes, 0, bytes.Length);
                                        index = 0;
                                        while (index < 4)
                                        {
                                            nr = handler.Receive(bytes, index, 4 - index, SocketFlags.None);
                                            index += nr;
                                        }
                                        int keywordLength = BitConverter.ToInt32(bytes, 0);

                                        // receive keyword
                                        byte[] keywordBytes = new byte[keywordLength];
                                        index = 0;
                                        while (index < keywordLength)
                                        {
                                            nr = handler.Receive(keywordBytes, index, keywordLength - index, SocketFlags.None);
                                            index += nr;
                                        }
                                        string keyword = Encoding.UTF8.GetString(keywordBytes, 0, keywordBytes.Length);

                                        // search through index for the received keyword
                                        List<byte[]> list = db.GetFile(user, keyword);

                                        // send number of files to user
                                        int nrFiles = list.Count;
                                        Array.Clear(bytes, 0, bytes.Length);
                                        bytes = BitConverter.GetBytes(nrFiles);
                                        handler.Send(bytes);

                                        for (int i = 0; i < list.Count; ++i)
                                        {
                                            handler.Send(list.ElementAt(i));
                                        }
                                        // send the files to user
                                        //foreach (string file in list)
                                        //{
                                        //    // send file name length
                                        //    int fileNameLength = file.Length;
                                        //    Array.Clear(bytes, 0, bytes.Length);
                                        //    bytes = BitConverter.GetBytes(fileNameLength);
                                        //    handler.Send(bytes);

                                        //    // send file name
                                        //    byte[] fileNameBytes = Encoding.UTF8.GetBytes(file);
                                        //    handler.Send(fileNameBytes);

                                        //    // send file size
                                        //    byte[] fileBytes = File.ReadAllBytes(file);
                                        //    int fileSize = fileBytes.Length;
                                        //    Array.Clear(bytes, 0, bytes.Length);
                                        //    bytes = BitConverter.GetBytes(fileSize);
                                        //    handler.Send(bytes);

                                        //    // send file
                                        //    handler.Send(fileBytes);
                                        //}

                                    }
                                }
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SocketException && (ex as SocketException).ErrorCode == 10054) // client disconnected
                {
                    Console.WriteLine("The client with ID {0} has disconnected from server", clientIndex); ;
                }
                else
                {
                    Console.WriteLine("An exception was encountered...\nException:" + ex.Message);
                }
                handler.Close();
            }
        }

        private List<string> SearchForKeyword(string keyword)
        {
            List<string> list = new List<string>();

            foreach (TField field in T)
            {
                if (field.Keyword.Equals(keyword))
                {
                    Node first = A[field.Position];
                    list.Add(first.FileID);
                    while (first.Next != null)
                    {
                        first = first.Next;
                        list.Add(first.FileID);
                    }
                    break;
                }
            }

            return list;
        }

        private void SerializeStructures()
        {
            try
            {
                using (Stream stream = File.Open(serializedAFile, FileMode.Create))
                {
                    BinaryFormatter bformatter = new BinaryFormatter();
                    bformatter.Serialize(stream, A);
                }

                using (Stream stream = File.Open(serializedTFile, FileMode.Create))
                {
                    BinaryFormatter bformatter = new BinaryFormatter();
                    bformatter.Serialize(stream, T);
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void DeserializeStructures()
        {
            try
            {
                if (File.Exists(serializedAFile))
                {
                    using (Stream stream = File.Open(serializedAFile, FileMode.Open))
                    {
                        BinaryFormatter bformatter = new BinaryFormatter();
                        A = (List<Node>)bformatter.Deserialize(stream);
                    }
                }

                if (File.Exists(serializedTFile))
                {
                    using (Stream stream = File.Open(serializedTFile, FileMode.Open))
                    {
                        BinaryFormatter bformatter = new BinaryFormatter();
                        T = (List<TField>)bformatter.Deserialize(stream);
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void DeleteExistingFiles()
        {
            if (A != null)
            {
                foreach (Node node in A)
                {
                    if (File.Exists(node.FileID))
                    {
                        File.Delete(node.FileID);
                    }
                }
            }
        }
    }
}
