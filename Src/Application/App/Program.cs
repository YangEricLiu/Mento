using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Mento.App.Controllers;
using System.IO;
using Mento.Utility;
using Mento.Framework.Configuration;
using System.Xml;
using System.Xml.Linq;
using Mento.Framework.Execution;
using App.CommandAnalysis;

namespace Mento.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            //ScriptController.Sync();

            //PlanController.Create("");
            //PlanController.Update("", "");
            //PlanController.Delete("");

            //PlanController.Run("", "", "", "");
            //PlanController.View("TA-P02");

            try
            {
                CommandAnalyer.CommandsAnalysis(args);
            }
            catch (Exception ex)
            {
                ColorConsole.WriteLine("Error:" + ex.Message,ConsoleColor.Red);
                Console.WriteLine("StactTrace:");
                Console.WriteLine(ex.StackTrace);
            }

            //Console.WriteLine(args[0]);
            Console.WriteLine("Press any key to continue..");
            
            Console.Read();
        }

    }
}
