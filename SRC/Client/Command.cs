using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class Command
    {
        public Request name;
        public List<Object> parameters = new List<object>();

        public Command(Request name, List<Object> objs)
        {
            this.name = name;
            parameters = objs;
        }

        public Command() { }

        public void SetCommandName(Request name)
        {
            this.name = name;
        }

        public void SetCommandObjs(List<Object> objs)
        {
            this.parameters = objs;
        }

        public object Execute(Socket client)
        {
            Object result = null;
            List<byte> commandToSend = new List<byte>();
            StrategyConvertCommand strategy = new StrategyConvertCommand();

            try
            {
                if(0 <= name && null != parameters)
                {
                    byte[] bytes = strategy.GetBytesSpecific(this);
                    AsynchronousClient.Send(client, bytes);
                    AsynchronousClient.ReceiveBytes(client);

                    return AsynchronousClient.responseBytes;
                }
                else
                {
                    throw new Exception("Wrong command " + name);
                }

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
