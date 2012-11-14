using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Business.Script.BusinessLogic;
using Mento.Business.Script.Entity;
using System.Reflection;
using Mento.Utility;
using Mento.Framework.Constants;
using Mento.Framework.Attributes;

namespace Mento.App.Controllers
{
    [Controller]
    public static class ScriptController
    {
        private static ScriptBL ScriptBL = new ScriptBL();

        [Command]
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
                    StringBuilder messageBuilder = new StringBuilder();
                    foreach(var type in item.Value)
                        messageBuilder.Append(type.Name).Append(type == item.Value.Last() ? String.Empty : ASCII.COMMA);

                    ColorConsole.WriteLine(String.Format("{0}.{1}:{2}", item.Key.DeclaringType.FullName,item.Key.Name, messageBuilder.ToString()), ConsoleColor.Red);
                }
            }
            else
            {
                ColorConsole.WriteLine("Synchronization successfully finished!", ConsoleColor.Green);
            }
        }

        [Command]
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
