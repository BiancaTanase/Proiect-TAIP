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
        byte[] publicKey = new byte[] { 60, 63, 120, 109, 108, 32, 118, 101, 114, 115, 105, 111, 110, 61, 34, 49, 46, 48, 34, 32, 101, 110, 99, 111, 100, 105, 110, 103, 61, 34, 117, 116, 102, 45, 49, 54, 34, 63, 62, 13, 10, 60, 82, 83, 65, 80, 97, 114, 97, 109, 101, 116, 101, 114, 115, 32, 120, 109, 108, 110, 115, 58, 120, 115, 105, 61, 34, 104, 116, 116, 112, 58, 47, 47, 119, 119, 119, 46, 119, 51, 46, 111, 114, 103, 47, 50, 48, 48, 49, 47, 88, 77, 76, 83, 99, 104, 101, 109, 97, 45, 105, 110, 115, 116, 97, 110, 99, 101, 34, 32, 120, 109, 108, 110, 115, 58, 120, 115, 100, 61, 34, 104, 116, 116, 112, 58, 47, 47, 119, 119, 119, 46, 119, 51, 46, 111, 114, 103, 47, 50, 48, 48, 49, 47, 88, 77, 76, 83, 99, 104, 101, 109, 97, 34, 62, 13, 10, 32, 32, 60, 69, 120, 112, 111, 110, 101, 110, 116, 62, 65, 81, 65, 66, 60, 47, 69, 120, 112, 111, 110, 101, 110, 116, 62, 13, 10, 32, 32, 60, 77, 111, 100, 117, 108, 117, 115, 62, 120, 70, 51, 68, 81, 122, 119, 111, 104, 119, 85, 89, 80, 79, 88, 65, 81, 90, 90, 90, 100, 104, 57, 77, 115, 79, 90, 73, 102, 83, 67, 65, 69, 47, 98, 55, 78, 77, 70, 118, 72, 118, 80, 97, 49, 80, 103, 52, 116, 76, 120, 107, 47, 78, 43, 71, 118, 81, 83, 121, 43, 112, 53, 105, 79, 53, 105, 111, 118, 108, 113, 67, 71, 68, 65, 73, 49, 66, 122, 100, 121, 73, 70, 117, 117, 108, 108, 100, 83, 109, 69, 112, 68, 112, 65, 86, 66, 52, 82, 122, 122, 75, 79, 81, 43, 79, 56, 103, 110, 65, 78, 100, 52, 107, 122, 108, 85, 115, 47, 111, 100, 52, 85, 54, 81, 110, 68, 121, 97, 57, 48, 104, 107, 88, 81, 80, 111, 108, 50, 88, 103, 65, 118, 54, 119, 115, 66, 103, 52, 50, 70, 75, 89, 78, 86, 65, 109, 76, 80, 86, 114, 70, 98, 79, 99, 117, 81, 121, 89, 65, 122, 113, 104, 73, 77, 72, 80, 67, 53, 107, 102, 43, 102, 65, 88, 53, 114, 80, 111, 97, 68, 115, 117, 84, 101, 98, 83, 102, 117, 89, 68, 120, 121, 112, 97, 98, 47, 48, 114, 110, 88, 72, 73, 50, 119, 79, 75, 85, 90, 105, 57, 118, 118, 49, 53, 112, 80, 51, 104, 78, 68, 87, 106, 43, 122, 51, 78, 102, 110, 71, 54, 66, 119, 121, 77, 76, 101, 109, 68, 97, 97, 102, 84, 57, 118, 70, 102, 55, 100, 88, 122, 69, 110, 67, 47, 118, 87, 71, 117, 118, 50, 55, 50, 51, 110, 55, 108, 48, 105, 71, 121, 80, 76, 101, 43, 79, 68, 90, 109, 118, 56, 114, 116, 48, 88, 119, 106, 83, 43, 51, 83, 43, 52, 69, 106, 65, 76, 85, 82, 83, 48, 50, 107, 87, 50, 103, 88, 89, 75, 84, 81, 78, 83, 102, 111, 119, 68, 118, 84, 107, 49, 107, 107, 105, 43, 86, 69, 66, 100, 73, 108, 81, 61, 61, 60, 47, 77, 111, 100, 117, 108, 117, 115, 62, 13, 10, 60, 47, 82, 83, 65, 80, 97, 114, 97, 109, 101, 116, 101, 114, 115, 62 };

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

                    byte[] encryptedBytes = objectCommand.PreparePackageToSend(bytes, Encoding.ASCII.GetString(publicKey));
                    


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
