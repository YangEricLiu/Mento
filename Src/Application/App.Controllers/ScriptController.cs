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

                    ConsoleHelper.WriteColorLine(String.Format("{0}.{1}:{2}", item.Key.DeclaringType.FullName,item.Key.Name, messageBuilder.ToString()), ConsoleColor.Red);
                }
            }
            else
            {
                ConsoleHelper.WriteColorLine("Synchronization successfully finished!", ConsoleColor.Green);
            }
        }

        [Command]
        public static void View()
        {
            Console.WriteLine("Begin to retrieve all script data..");

            ScriptEntity[] scripts = ScriptBL.Export();
            int scriptNumber = scripts.GetLength(0);

            Console.WriteLine("There are {0} scripts currently", scriptNumber);
                        
            string[] headers = new string[] { "CaseID", "Name", "Type", "Priority", "Owner" };
            string[] formats = new string[] { "{0,-25}", "{1,-40}", "{2,-8}", "{3,-13}", "{4,-9}" };
            
            string format = String.Join(String.Empty, formats);

            Console.WriteLine(format, headers);
            Console.WriteLine(new String(ASCII.SUBTRACT, 10));

            foreach (var script in scripts)
            {
                Console.WriteLine(format, script.CaseID, script.Name, script.Type, script.Priority, script.Owner);
            }

            Console.WriteLine("In the mean while, the script data are exported to script export directory.");
        }
    }
}
