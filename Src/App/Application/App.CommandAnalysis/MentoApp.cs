using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Constants;
using Mento.Framework.Exceptions;
using Mento.Framework.Log;
using Mento.Utility;

namespace Mento.App.CommandAnalysis
{
    public class MentoApp
    {
        private static string SIGNAL = new string(ASCII.LARGERTHAN, 2);

        public void Run(string[] args)
        {
            SetConsoleStyle();

            if (args == null || args.Length <= 0)
            {
                PrintWelcome();
                k: Console.Write(SIGNAL);

                string s = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(s))
                {
                    goto k;
                }
                if (!String.Equals(s.Trim(), "exit", StringComparison.OrdinalIgnoreCase))
                
                {
                    Go(s.Split(ASCII.SPACE));
                    goto k;
                }
            }
            else
            {
                Go(args);
            }
        }

        private static void Go(string[] args)
        {
            try
            {
                CommandAnalyer.Execute(args);
            }
            catch (Exception ex)
            {
                string errorType = "System error";

                if (ex.GetType() == typeof(ApiException))
                    errorType = "Api Error";

                if (ex.GetType() == typeof(AppException))
                    errorType = "App Error";


                ConsoleHelper.WriteColorLine(String.Format("{0}: {1}", errorType, ex.Message), ConsoleColor.Red);

                AppLog.Instance.LogError(ex.ToString());
            } 
        }

        private static void SetConsoleStyle()
        {
            Console.SetWindowSize(100, 32);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintWelcome()
        {
            Console.WriteLine("Welcome to {0} {1}.", Manufacture.PRODUCTNAME , Manufacture.PRODUCTVERSION);
            Console.WriteLine("Type \"help\", for more information.");
            Console.WriteLine(Manufacture.COPYRIGHT);
        }
    }
}
