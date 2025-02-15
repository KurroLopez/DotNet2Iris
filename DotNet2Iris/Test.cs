using InterSystems.Data.IRISClient;
using InterSystems.Data.IRISClient.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet2Iris
{
    public class Test
    {
        static public IrisParam irisParam { get; set; }
        public IRIS iris { get; set; }

        public Test(IrisParam param)
        {
            irisParam = param;
            OpenConnection();
        }

        public void OpenConnection()
        {
            Console.WriteLine("Opening connection");
            IRISConnection IrisConnect = new IRISConnection();
            IrisConnect.ConnectionString = "Server = " + irisParam.irisUrl + "; " + "Port = " + irisParam.irisPort + "; "
    + "Namespace = " + irisParam.irisNamespace + "; " + "Password = " + irisParam.irisPassword + "; " + "User ID = " + irisParam.irisUsername + ";";
            Console.WriteLine(IrisConnect.ConnectionString);
            try
            {
                IrisConnect.Open();
                iris = IRIS.CreateIRIS(IrisConnect);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public String GetNamespace()
        {
            return "Current namespace: " + iris.ClassMethodString("%SYSTEM.SYS", "NameSpace");
        }

        internal string ConvertTemperature(double value, string from, string to)
        {
            return iris.ClassMethodString("St.Sample.Connection.Csharp.conversion", "ConvertTemperature", value, from, to);
        }
    }
}
