using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializedData
{
    [Serializable]
    public class Node
    {
        public string FileID;
        public Node Next;
    }

    [Serializable]
    public class FileLinkedList
    {
        public Node FirstNode;
    }

    [Serializable]
    public class TField
    {
        public string Keyword;
        public int Position;
    }
}
