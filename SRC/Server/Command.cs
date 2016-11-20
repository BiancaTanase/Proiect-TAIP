using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using static Server.Utilities;

namespace Server
{
    public class Command:ICommand
    {
        public Request name;
        public List<Object> parameters = new List<object>();
        public byte[] commBytes;

        public void setCommand(Request name, List<Object> objs)
        {
            this.name = name;
            parameters = objs;
        }

        public Command() { }

        public void setCommandName(Request name)
        {
            this.name = name;
        }

        public void setCommandObjs(List<Object> objs)
        {
            this.parameters = objs;
        }

        public object execute(Socket client)
        {
            Object result = null;
            List<byte> commandToSend = new List<byte>();
            StrategyConvertCommand strategy = new StrategyConvertCommand();

            try
            {
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                result = null;
            }
            return result;
        }

    }
}
