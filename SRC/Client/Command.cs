using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;

namespace Client
{
    public class Command:ICommand
    {
        public Request name;
        public List<Object> parameters = new List<object>();

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
                if (null == client) throw new Exception("No connection!");
                if(0 <= name && null != parameters)
                {
                    byte[] bytes = strategy.GetBytesSpecific(this);
                    AsynchronousClient.Send(client, bytes);
                    AsynchronousClient.sendDone.WaitOne();

                    AsynchronousClient.Send(client, "<EOF>");
                    AsynchronousClient.sendDone.WaitOne();

                    AsynchronousClient.ReceiveBytes(client);
                    AsynchronousClient.receiveDone.WaitOne();

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
