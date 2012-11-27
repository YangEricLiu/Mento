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
                        messageBuilder.Append(type.Name).Append(type == item.Value.Last() ? String.Empty : ASCII.COMMA.ToString());

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
            int scriptNumber = scripts.GetLength(0);

            Console.WriteLine("There are {0} scripts currently", scriptNumber);

            //Console.WriteLine("\n{0,-10}{1,-16}{2,-8}{3,-13}{4,-8}{5,-12}{6,-11}{7,-10}{8,-9}{9,-14}{10,-12}", "CaseID", "ManualCaseID", "Name",
            //    "SuiteName", "Type", "Priority", "Feature", "Module", "Owner", "CreateTime", "SyncTime");
            //Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            //For the item string is too long, so just display 5 column
            Console.WriteLine("\n{0,-25}{1,-40}{2,-8}{3,-13}{4,-9}", "CaseID", "Name", "Type", "Priority", "Owner");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            foreach (var script in scripts)
            {
                //Console.WriteLine("\n{0,-10}{1,-16}{2,-8}{3,-13}{4,-8}{5,-12}{6,-11}{7,-10}{8,-9}{9,-14}{10,-12}",script.CaseID, script.ManualCaseID, script.Name,
                //script.SuiteName, script.Type, script.Priority, script.Feature, script.Module, script.Owner, script.CreateTime, script.SyncTime);
                
                //format the script information
                //For the item string is too long, so just display 5 column
                Console.WriteLine("\n{0,-25}{1,-40}{2,-8}{3,-13}{4,-9}", script.CaseID, script.Name,script.Type, script.Priority, script.Owner);
            }
        }
    }
}
