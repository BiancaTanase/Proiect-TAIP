using Microsoft.Practices;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class LoggingBehavior : IInterceptionBehavior
    {
        private StreamWriter logsFile;
        CCommandEncryption objectCommand = new CCommandEncryption();
        public LoggingBehavior()
        {
            string currentTime = DateTime.Now.ToString("yyyy_mm_dd_hh_mm_ss");
            logsFile = new StreamWriter(Environment.CurrentDirectory + "/" + currentTime + "_client_logs.txt");
        }

        /// <summary>
        /// will this behavior actually perform any operations when invoked
        /// </summary>
        public bool WillExecute
        {
            get
            {
                return true;
                //throw new NotImplementedException();
            }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            Type[] t = new Type[1];
            t[0] =typeof(Client.ICommand);
            return t;
            //throw new NotImplementedException();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn msg;
            string classMethodName = string.Format("{0}::{1}", input.MethodBase.ReflectedType.Name, input.MethodBase.Name);

            try
            {
                logsFile.WriteLine(string.Format("******Before method executio -> {0}", classMethodName));
                logsFile.WriteLine(GetParameterInfo(input));

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                //Nicu  change commandBytes
                if(classMethodName.Contains("ICommand::execute"))
                {
                    byte[] bytes = ClientForm.command.getCommandBytes();
                    objectCommand.generateKey();

                    byte[] encryptedBytes = objectCommand.PreparePackageToSend(bytes, Encoding.ASCII.GetString(Utilities.publicKey));
                    


                    ClientForm.command.setCommandBytes(encryptedBytes);
                }

                //execute original method
                msg = getNext()(input, getNext);
                stopwatch.Stop();

                logsFile.WriteLine("Time elapsed excuting method " + classMethodName + " is = " + stopwatch.Elapsed);
                logsFile.WriteLine(string.Format("Returned value from method {0}: {1}", classMethodName, msg.ReturnValue==null?"void":msg.ReturnValue.ToString()));
                logsFile.WriteLine(string.Format("Exiting from {0} ", classMethodName));
            }
            catch (Exception ex)
            {
                logsFile.WriteLine(string.Format("Exception in Method {0} with error {1}", classMethodName, ex.ToString()));
                throw;
            }
            finally
            {
                logsFile.WriteLine(string.Format("****** Finaly of method {0}", classMethodName));
            }
            return msg;
        }

        private string GetParameterInfo(IMethodInvocation input)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                for(int i=0; i < input.Arguments.Count; ++i)
                {
                    result.Append(input.Arguments.GetParameterInfo(i).Name + " - " + input.Arguments[i] + " ; ");
                }
            }
            catch(Exception ex)
            {
                
            }
            return result.ToString();
        }
    }
}
