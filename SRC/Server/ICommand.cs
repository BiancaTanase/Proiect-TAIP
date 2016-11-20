using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using static Server.Utilities;

namespace Server
{
    public interface ICommand
    {
        void setCommand(Request name, List<Object> objs);

        void setCommandName(Request name);

        void setCommandObjs(List<Object> objs);

        object execute(Socket client);

    }
}
