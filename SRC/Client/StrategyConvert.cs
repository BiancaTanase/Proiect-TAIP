using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    interface StrategyConvert
    {
        byte[] GetBytesSpecific(Object str);
        Object GetObjectSpecific(byte[] bytes);
    }

    public class StrategyConvertString : StrategyConvert
    {
        public byte[] GetBytesSpecific(object str)
        {
            byte[] bytes = new byte[((string)str).Length * sizeof(char)];
            System.Buffer.BlockCopy(((string)str).ToCharArray(), 0, bytes, 0, bytes.Length);
            byte[] intBytes = BitConverter.GetBytes(bytes.Length);
            Array.Reverse(intBytes);
            return bytes.Concat(intBytes).ToArray();
        }

        public object GetObjectSpecific(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return (new string(chars));
        }

        public byte[] GetBytes(string str)
        {
            return GetBytesSpecific(str);
        }
        
        public string GetObject(byte[] bytes)
        {
            return (string)GetObjectSpecific(bytes);
        }
    }

    public class StrategyConvertInt : StrategyConvert
    {
        public byte[] GetBytesSpecific(object str)
        {
            byte[] intBytes = BitConverter.GetBytes((int)str);
            Array.Reverse(intBytes);
            byte[] intBytesl = BitConverter.GetBytes(sizeof(int));
            return intBytes.Concat(intBytesl).ToArray();
        }

        public object GetObjectSpecific(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0);
        }
    }


    public class StrategyConvertCommand : StrategyConvert
    {
        StrategyConvertInt intStrat = new StrategyConvertInt();
        StrategyConvertString stringStrat = new StrategyConvertString();

        public byte[] GetBytesSpecific(object str)
        {
            Command comm = (Command)str;
            List<byte> result = new List<byte>();
            string type = String.Empty;
           
            try
            {
                result.AddRange(intStrat.GetBytesSpecific(comm.name));
                for(int i =0; i<comm.parameters.Count; ++i)
                {
                    type = comm.parameters[i].GetType().ToString();
                    switch(type.ToLower())
                    {
                        case "string": result.AddRange(stringStrat.GetBytesSpecific((string)comm.parameters[i]));break;
                        case "int": result.AddRange(intStrat.GetBytesSpecific((int)comm.parameters[i])); break;
                        default: result.AddRange(stringStrat.GetBytesSpecific((string)comm.parameters[i])); break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return result.ToArray();
        }

        public object GetObjectSpecific(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }


}
