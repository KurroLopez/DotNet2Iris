using System;
using System.Configuration;

namespace DotNet2Iris
{
    internal class Program
    {
        public IrisParam irisParam { get; set; }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.irisParam = new IrisParam();
            p.LoadConfig();
            bool exit = false;
            while (!exit)
            {
                p.ShowMenu();
                Console.Write("Select your option ");
                string option = Console.ReadLine();
                switch (option.ToUpper())
                {
                    case "1":
                        p.Config();
                        break;
                    case "2":
                        p.TestGetNamespace();
                        break;
                    case "3":
                        p.TestTemperatureConverter();
                        break;
                    case "X":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press a key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void LoadConfig()
        {
            irisParam.irisUrl = ConfigurationManager.AppSettings["host"];
            irisParam.irisNamespace = ConfigurationManager.AppSettings["namespace"];
            irisParam.irisUsername = ConfigurationManager.AppSettings["username"];
            irisParam.irisPassword = ConfigurationManager.AppSettings["password"];
            irisParam.irisPort = ConfigurationManager.AppSettings["port"];
        }

        /// <summary>
        /// Method to update the configuration connectio to IRIS
        /// </summary>
        public void Config()
        {
            string value;
            Console.Clear();
            Write("Insert IRIS Url",irisParam.irisUrl);
            value = Console.ReadLine();
            if (value != null && value != "") irisParam.irisUrl = value;
            Write("Insert IRIS Port", irisParam.irisPort);
            value = Console.ReadLine();
            if (value != null && value != "") irisParam.irisPort = value;
            Write("Insert IRIS Namespace", irisParam.irisNamespace);
            value = Console.ReadLine();
            if (value != null && value != "") irisParam.irisNamespace = value;
            Write("Insert IRIS User", irisParam.irisUsername);
            value = Console.ReadLine();
            if (value != null && value != "") irisParam.irisUsername = value;
            Write("Insert IRIS Password", irisParam.irisPassword);
            value = Console.ReadLine();
            if (value != null && value != "") irisParam.irisPassword = value;
        }

        /// <summary>
        /// Method to show prompt of parameter
        /// </summary>
        /// <param name="text"></param>
        /// <param name="param"></param>
        private void Write(string text, string param = "")
        {
            string prompt = text;
            if (param != null && param.Trim() != "")
                prompt += " [" + param + "]";
            
            prompt += ": ";
            Console.Write(prompt);
        }

        /// <summary>
        /// Display de menu items.
        /// </summary>
        private void ShowMenu()
        {
            Console.Clear();
            ShowConfig();
            Console.WriteLine("1 - Change connection configuration");
            Console.WriteLine("2 - Test: Get namespace");
            Console.WriteLine("3 - Test: Temperature converter");
            Console.WriteLine();
            Console.WriteLine("X - Exit");
        }

        /// <summary>
        /// Display de current configuration
        /// </summary>
        private void ShowConfig()
        {
            Console.WriteLine("IRIS connection");
            Console.WriteLine("---------------");
            Console.WriteLine("URL: \t\t" + irisParam.irisUrl);
            Console.WriteLine("Port: \t\t" + irisParam.irisPort);
            Console.WriteLine("Namespace: \t" + irisParam.irisNamespace);
            Console.WriteLine("User: \t\t" + irisParam.irisUsername);
            Console.WriteLine("Password: \t" + irisParam.irisPassword);
            Console.WriteLine("---------------");
        }

        #region Test method
        /// <summary>
        /// Run the 1st test. Show the namespace from .Net
        /// </summary>
        private void TestGetNamespace()
        {
            Test test = new Test(irisParam);
            Console.WriteLine("Result of test 'Get Namespace'");
            Console.WriteLine(test.GetNamespace());
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
        private void TestTemperatureConverter()
        {
            Test test = new Test(irisParam);
            Console.WriteLine();
            Console.WriteLine("Convert 30ºC to Fahrenheit and Kelvin: ");
            Console.WriteLine(test.ConvertTemperature(30.0,"C","F") + "º F");
            Console.WriteLine(test.ConvertTemperature(30.0,"C","K") + "º K");
            Console.WriteLine();
            Console.WriteLine("Convert 30ºF to Celisus and Kelvin");
            Console.WriteLine(test.ConvertTemperature(30.0, "F", "C") + "º C");
            Console.WriteLine(test.ConvertTemperature(30.0, "F", "K") + "º K");
            Console.WriteLine(); 
            Console.WriteLine("Convert 30ºK to Celisus and Fahrenheit");
            Console.WriteLine(test.ConvertTemperature(30.0, "K", "C") + "º C");
            Console.WriteLine(test.ConvertTemperature(30.0, "K", "F") + "º F");
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
        #endregion
    }
}
