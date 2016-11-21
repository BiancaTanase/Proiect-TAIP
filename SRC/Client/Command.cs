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
        public byte[] commandBytes;

        public void setCommand(Request name, List<Object> objs)
        {
            this.name = name;
            parameters = objs;
        }

        public void setCommandBytes(byte[] bytes)
        {
            this.commandBytes = bytes;
        }
        public void setCommandBytes()
        {
            StrategyConvertCommand strategy = new StrategyConvertCommand();
            this.commandBytes = strategy.GetBytesSpecific(this);
        }
        public byte[] getCommandBytes()
        {
            return this.commandBytes;
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

            try
            {
                if (null == client) throw new Exception("No connection!");
                if(0 <= name && null != parameters && commandBytes != null)
                {
                    
                    AsynchronousClient.Send(client, commandBytes);
                    AsynchronousClient.sendDone.WaitOne();

                    AsynchronousClient.Send(client, Encoding.ASCII.GetBytes("<EOF>"));
                    AsynchronousClient.sendDone.WaitOne();

                    AsynchronousClient.ReceiveBytes(client);
                    AsynchronousClient.receiveDone.WaitOne();
                    MessageBox.Show(AsynchronousClient.response);
                    return AsynchronousClient.response;
                    
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
