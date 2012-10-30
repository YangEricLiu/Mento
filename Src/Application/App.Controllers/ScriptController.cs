using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Business.Script.BusinessLogic;
using Mento.Business.Script.Entity;
using System.Reflection;
using Mento.Utility;

namespace Mento.App.Controllers
{
    public static class ScriptController
    {
        private static ScriptBL ScriptBL = new ScriptBL();

        public static void Sync()
        {
            Console.WriteLine("Starting synchronize all test scripts..");
            Dictionary<MethodInfo, List<Type>> validationResult;
            bool result = ScriptBL.Synchronize(out validationResult);

            if (!result)
            {
                Console.WriteLine("Synchronization error:");
                foreach (var item in validationResult)
                {
                    ColorConsole.WriteLine(item.Key.Name, ConsoleColor.Red);
                }
            }
            else
            {
                ColorConsole.WriteLine("Synchronization successfully finished!", ConsoleColor.Green);
            }
        }

        public static void View()
        {
            ScriptEntity[] scripts = ScriptBL.Export();

            foreach (var script in scripts)
            {
                //should format the script information
                Console.WriteLine(scripts);
            }
        }
    }
}
