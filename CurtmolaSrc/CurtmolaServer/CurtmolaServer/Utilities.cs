﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class Utilities
    {
        public static byte[] privateKey = new byte[] { 60, 63, 120, 109, 108, 32, 118, 101, 114, 115, 105, 111, 110, 61, 34, 49, 46, 48, 34, 32, 101, 110, 99, 111, 100, 105, 110, 103, 61, 34, 117, 116, 102, 45, 49, 54, 34, 63, 62, 13, 10, 60, 82, 83, 65, 80, 97, 114, 97, 109, 101, 116, 101, 114, 115, 32, 120, 109, 108, 110, 115, 58, 120, 115, 105, 61, 34, 104, 116, 116, 112, 58, 47, 47, 119, 119, 119, 46, 119, 51, 46, 111, 114, 103, 47, 50, 48, 48, 49, 47, 88, 77, 76, 83, 99, 104, 101, 109, 97, 45, 105, 110, 115, 116, 97, 110, 99, 101, 34, 32, 120, 109, 108, 110, 115, 58, 120, 115, 100, 61, 34, 104, 116, 116, 112, 58, 47, 47, 119, 119, 119, 46, 119, 51, 46, 111, 114, 103, 47, 50, 48, 48, 49, 47, 88, 77, 76, 83, 99, 104, 101, 109, 97, 34, 62, 13, 10, 32, 32, 60, 69, 120, 112, 111, 110, 101, 110, 116, 62, 65, 81, 65, 66, 60, 47, 69, 120, 112, 111, 110, 101, 110, 116, 62, 13, 10, 32, 32, 60, 77, 111, 100, 117, 108, 117, 115, 62, 120, 70, 51, 68, 81, 122, 119, 111, 104, 119, 85, 89, 80, 79, 88, 65, 81, 90, 90, 90, 100, 104, 57, 77, 115, 79, 90, 73, 102, 83, 67, 65, 69, 47, 98, 55, 78, 77, 70, 118, 72, 118, 80, 97, 49, 80, 103, 52, 116, 76, 120, 107, 47, 78, 43, 71, 118, 81, 83, 121, 43, 112, 53, 105, 79, 53, 105, 111, 118, 108, 113, 67, 71, 68, 65, 73, 49, 66, 122, 100, 121, 73, 70, 117, 117, 108, 108, 100, 83, 109, 69, 112, 68, 112, 65, 86, 66, 52, 82, 122, 122, 75, 79, 81, 43, 79, 56, 103, 110, 65, 78, 100, 52, 107, 122, 108, 85, 115, 47, 111, 100, 52, 85, 54, 81, 110, 68, 121, 97, 57, 48, 104, 107, 88, 81, 80, 111, 108, 50, 88, 103, 65, 118, 54, 119, 115, 66, 103, 52, 50, 70, 75, 89, 78, 86, 65, 109, 76, 80, 86, 114, 70, 98, 79, 99, 117, 81, 121, 89, 65, 122, 113, 104, 73, 77, 72, 80, 67, 53, 107, 102, 43, 102, 65, 88, 53, 114, 80, 111, 97, 68, 115, 117, 84, 101, 98, 83, 102, 117, 89, 68, 120, 121, 112, 97, 98, 47, 48, 114, 110, 88, 72, 73, 50, 119, 79, 75, 85, 90, 105, 57, 118, 118, 49, 53, 112, 80, 51, 104, 78, 68, 87, 106, 43, 122, 51, 78, 102, 110, 71, 54, 66, 119, 121, 77, 76, 101, 109, 68, 97, 97, 102, 84, 57, 118, 70, 102, 55, 100, 88, 122, 69, 110, 67, 47, 118, 87, 71, 117, 118, 50, 55, 50, 51, 110, 55, 108, 48, 105, 71, 121, 80, 76, 101, 43, 79, 68, 90, 109, 118, 56, 114, 116, 48, 88, 119, 106, 83, 43, 51, 83, 43, 52, 69, 106, 65, 76, 85, 82, 83, 48, 50, 107, 87, 50, 103, 88, 89, 75, 84, 81, 78, 83, 102, 111, 119, 68, 118, 84, 107, 49, 107, 107, 105, 43, 86, 69, 66, 100, 73, 108, 81, 61, 61, 60, 47, 77, 111, 100, 117, 108, 117, 115, 62, 13, 10, 32, 32, 60, 80, 62, 121, 79, 69, 70, 84, 84, 102, 76, 117, 69, 55, 54, 69, 76, 89, 98, 78, 99, 57, 98, 80, 112, 88, 72, 97, 118, 106, 66, 73, 71, 89, 120, 75, 84, 98, 67, 106, 90, 76, 88, 111, 69, 119, 88, 121, 53, 51, 110, 69, 112, 65, 114, 122, 108, 54, 68, 68, 117, 105, 118, 87, 100, 74, 70, 102, 83, 72, 49, 54, 121, 83, 97, 84, 98, 49, 79, 51, 71, 84, 70, 98, 90, 51, 107, 114, 120, 65, 113, 113, 97, 118, 68, 88, 84, 68, 116, 113, 116, 83, 73, 118, 82, 69, 88, 68, 78, 84, 99, 103, 113, 103, 90, 71, 110, 53, 52, 120, 51, 67, 85, 78, 114, 83, 106, 110, 74, 51, 56, 54, 49, 75, 114, 89, 108, 81, 121, 122, 99, 69, 89, 97, 79, 79, 75, 73, 54, 87, 105, 108, 74, 102, 109, 115, 100, 90, 97, 120, 85, 82, 51, 109, 52, 66, 56, 52, 87, 77, 74, 99, 55, 56, 61, 60, 47, 80, 62, 13, 10, 32, 32, 60, 81, 62, 43, 106, 43, 57, 103, 56, 80, 66, 88, 71, 99, 120, 50, 51, 113, 76, 79, 80, 68, 66, 72, 78, 76, 76, 85, 86, 109, 87, 76, 68, 113, 50, 51, 83, 119, 97, 48, 56, 108, 47, 76, 65, 107, 90, 70, 102, 47, 88, 54, 74, 67, 120, 86, 98, 113, 47, 105, 100, 116, 107, 49, 68, 77, 43, 114, 104, 97, 48, 111, 48, 76, 75, 103, 85, 75, 74, 71, 85, 51, 122, 85, 119, 76, 52, 88, 102, 50, 110, 103, 53, 103, 102, 85, 47, 88, 67, 81, 67, 78, 82, 51, 52, 87, 74, 103, 55, 82, 100, 51, 116, 110, 102, 90, 70, 99, 72, 79, 87, 67, 49, 105, 80, 117, 65, 43, 108, 78, 89, 72, 65, 65, 54, 85, 100, 89, 100, 106, 118, 104, 83, 107, 114, 43, 74, 48, 122, 104, 79, 43, 80, 65, 114, 80, 100, 43, 115, 117, 49, 113, 70, 85, 107, 116, 119, 71, 52, 107, 88, 67, 75, 115, 61, 60, 47, 81, 62, 13, 10, 32, 32, 60, 68, 80, 62, 97, 86, 107, 112, 99, 74, 43, 115, 90, 86, 74, 49, 55, 115, 71, 121, 98, 51, 118, 53, 118, 69, 55, 77, 115, 74, 115, 89, 110, 97, 99, 54, 98, 81, 84, 99, 55, 50, 90, 116, 85, 120, 72, 86, 65, 79, 73, 107, 120, 121, 86, 52, 56, 57, 101, 53, 72, 57, 54, 68, 53, 55, 86, 81, 52, 66, 107, 112, 89, 86, 74, 109, 52, 104, 74, 65, 65, 51, 71, 78, 52, 76, 107, 72, 114, 52, 47, 111, 55, 43, 97, 50, 112, 71, 55, 43, 108, 98, 75, 48, 113, 52, 77, 69, 57, 97, 80, 69, 113, 88, 107, 68, 65, 86, 81, 71, 102, 52, 72, 90, 71, 80, 43, 80, 78, 112, 110, 99, 104, 73, 86, 115, 103, 68, 114, 115, 69, 101, 65, 77, 114, 121, 86, 49, 48, 116, 65, 81, 47, 97, 68, 85, 83, 98, 118, 68, 67, 117, 87, 110, 88, 74, 80, 55, 54, 106, 65, 73, 83, 118, 48, 61, 60, 47, 68, 80, 62, 13, 10, 32, 32, 60, 68, 81, 62, 103, 53, 115, 49, 55, 97, 47, 114, 90, 115, 56, 87, 108, 49, 104, 120, 69, 51, 98, 53, 43, 70, 67, 98, 103, 75, 76, 101, 113, 86, 65, 80, 106, 50, 49, 56, 104, 108, 106, 51, 117, 111, 55, 109, 86, 72, 50, 67, 98, 78, 112, 55, 105, 74, 120, 51, 48, 117, 90, 65, 116, 113, 66, 107, 110, 71, 86, 119, 104, 108, 79, 47, 56, 65, 54, 118, 122, 49, 69, 66, 89, 71, 121, 49, 100, 97, 106, 75, 105, 104, 104, 99, 107, 87, 107, 122, 121, 85, 116, 74, 54, 89, 86, 117, 57, 111, 98, 75, 118, 48, 74, 82, 105, 53, 71, 66, 83, 82, 109, 108, 72, 117, 56, 49, 117, 51, 66, 78, 98, 66, 120, 113, 106, 49, 78, 78, 112, 68, 122, 81, 73, 69, 68, 47, 71, 77, 103, 75, 77, 68, 48, 79, 89, 76, 72, 98, 81, 52, 83, 116, 106, 77, 81, 68, 112, 49, 101, 72, 100, 53, 85, 61, 60, 47, 68, 81, 62, 13, 10, 32, 32, 60, 73, 110, 118, 101, 114, 115, 101, 81, 62, 84, 72, 89, 81, 122, 68, 53, 104, 78, 80, 71, 109, 48, 53, 79, 88, 78, 43, 47, 65, 43, 108, 71, 85, 51, 43, 115, 117, 65, 101, 71, 87, 88, 43, 107, 57, 113, 77, 89, 82, 56, 78, 85, 110, 107, 102, 98, 66, 71, 111, 66, 57, 110, 73, 78, 53, 110, 79, 118, 66, 89, 110, 68, 117, 89, 103, 72, 90, 56, 79, 76, 103, 88, 90, 119, 107, 122, 77, 104, 55, 88, 97, 111, 75, 109, 70, 55, 71, 84, 84, 87, 50, 67, 120, 74, 52, 84, 49, 97, 78, 79, 81, 107, 57, 108, 108, 70, 49, 119, 51, 117, 115, 102, 107, 88, 111, 84, 105, 49, 82, 106, 82, 47, 112, 48, 84, 76, 81, 57, 100, 52, 105, 84, 69, 101, 48, 89, 84, 109, 101, 50, 117, 43, 47, 116, 107, 113, 112, 54, 56, 87, 104, 88, 78, 90, 109, 100, 102, 56, 109, 67, 103, 106, 110, 109, 112, 117, 67, 102, 55, 69, 61, 60, 47, 73, 110, 118, 101, 114, 115, 101, 81, 62, 13, 10, 32, 32, 60, 68, 62, 70, 66, 79, 48, 120, 57, 117, 54, 70, 109, 80, 56, 57, 99, 74, 86, 76, 57, 43, 71, 120, 50, 109, 116, 75, 54, 117, 47, 51, 118, 67, 89, 90, 56, 100, 43, 48, 55, 70, 98, 86, 57, 100, 57, 109, 80, 122, 70, 97, 105, 86, 65, 43, 50, 72, 88, 84, 89, 103, 110, 100, 122, 71, 117, 97, 116, 103, 109, 55, 102, 84, 80, 68, 70, 105, 51, 109, 81, 104, 88, 51, 76, 101, 90, 120, 48, 47, 80, 119, 86, 112, 115, 98, 52, 49, 110, 117, 81, 99, 75, 103, 112, 48, 106, 43, 50, 43, 56, 55, 110, 97, 104, 113, 76, 117, 105, 112, 66, 55, 115, 98, 110, 70, 74, 89, 118, 87, 116, 88, 106, 51, 112, 70, 87, 75, 47, 121, 83, 75, 51, 80, 50, 79, 107, 49, 101, 78, 90, 104, 75, 89, 74, 78, 115, 97, 115, 85, 51, 67, 85, 43, 78, 54, 85, 107, 56, 97, 108, 74, 43, 89, 82, 89, 90, 111, 50, 72, 72, 119, 51, 71, 78, 121, 67, 121, 48, 101, 78, 77, 117, 120, 72, 111, 101, 54, 69, 74, 89, 109, 47, 100, 74, 115, 101, 101, 65, 90, 112, 73, 118, 101, 114, 54, 81, 105, 47, 48, 73, 98, 121, 43, 106, 43, 68, 71, 112, 122, 55, 51, 56, 111, 47, 107, 43, 72, 104, 121, 87, 47, 75, 72, 56, 55, 49, 109, 75, 84, 55, 111, 81, 87, 54, 98, 106, 116, 79, 82, 120, 119, 122, 51, 71, 101, 57, 90, 65, 70, 112, 57, 90, 84, 57, 68, 105, 66, 102, 87, 82, 69, 49, 76, 57, 97, 103, 82, 120, 77, 81, 103, 101, 110, 72, 89, 83, 67, 86, 121, 117, 68, 120, 48, 81, 48, 108, 79, 115, 49, 71, 101, 110, 71, 105, 71, 78, 116, 68, 86, 101, 55, 55, 56, 51, 73, 80, 68, 114, 82, 75, 68, 116, 81, 74, 82, 105, 103, 85, 54, 104, 51, 67, 87, 81, 61, 61, 60, 47, 68, 62, 13, 10, 60, 47, 82, 83, 65, 80, 97, 114, 97, 109, 101, 116, 101, 114, 115, 62 };
        public enum Request
        {
            VerifyLogin,
            Login,
            Logout,
            Register,
            ChangeInfo,
            AddData,
            RequestData,
            RemoveData,
            UndoRemovedData,
            Invalid
        };

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public static int ReadLength(Socket handler)
        {
            byte[] bytes = new byte[4];
            int index = 0;
            int nr = 0;

            while (index < 4)
            {
                nr = handler.Receive(bytes, index, 4 - index, SocketFlags.None);
                index += nr;
            }

            return BitConverter.ToInt32(bytes, 0);
        }

        public static string ReadString(Socket handler, int length)
        {
            byte[] bytes = new byte[length];
            int index = 0;
            int nr = 0;
            while (index < length)
            {
                nr = handler.Receive(bytes, index, length - index, SocketFlags.None);
                index += nr;
            }

            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}
