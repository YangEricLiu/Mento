using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Business.Plan.BusinessLogic;
using Mento.Utility;
using Mento.Business.Plan.Entity;
using Mento.Business.Script.Entity;
using Mento.Business.Script.BusinessLogic;
using Mento.Framework.Attributes;
using Mento.Framework.Constants;
using System.IO;

namespace Mento.App.Controllers
{
    [Controller]
    public static class PlanController
    {
        private static PlanBL PlanBL = new PlanBL();
        private static ExecutionBL ExecutionBL = new ExecutionBL();

        [Command]
        public static void Create([Parameter]string planFile)
        {
            Console.WriteLine("creating plan..");

            PlanBL.Create(planFile);

            ConsoleHelper.PrintSuccessMessage();
        }

        [Command]
        public static void Update([Parameter]string planID, [Parameter]string planFile)
        {
            Console.WriteLine("updating plan '{0}'..",planID);

            PlanBL.Update(planID, planFile);

            ConsoleHelper.PrintSuccessMessage();
        }

        [Command]
        public static void Delete([Parameter]string planID)
        {
            Console.WriteLine("deleting plan '{0}'..", planID);

            PlanBL.Delete(planID);

            ConsoleHelper.PrintSuccessMessage();
        }

        [Command]
        public static void View()
        {
            Console.WriteLine("Begin to retrieve all plan data..");

            string exportFilePath = String.Empty;
            PlanEntity[] plans = PlanBL.Export(out exportFilePath);
            int planNumber = plans.GetLength(0);

            Console.WriteLine("There are {0} plans currently", planNumber);

            string[] headers = new string[] { "PlanID", "Name", "Version", "Owner", "UpdateTime", "Status" };
            string[] formats = new string[] { "{0,-20}", "{1,-20}", "{2,-8}", "{3,-13}", "{4,-15}", "{5,-10}" };

            string format = String.Join(String.Empty, formats);

            Console.WriteLine(format, headers);
            Console.WriteLine(new String(ASCII.SUBTRACT, 10));

            foreach (var plan in plans)
            {
                Console.WriteLine(format, plan.PlanID, plan.Name, plan.ProductVersion, plan.Owner, plan.UpdateTime.ToString("yyyy-MM-dd"), plan.Status);
            }

            Console.WriteLine("You can also see the exported file at:\n{0}", Path.GetFullPath(exportFilePath));
        }

        [Command]
        public static void View([Parameter]string planID)
        {
            Console.WriteLine("Begin to retrieve all scripts in plan '{0}'..", planID);
            
            string exportFilePath = String.Empty;
            ScriptEntity[] scripts = PlanBL.Export(planID, out exportFilePath);
            int scriptsNumber = scripts.GetLength(0);

            Console.WriteLine("There are {0} scripts in plan '{1}' currently", scriptsNumber, planID);
            
            string[] headers = new string[] { "CaseID", "Name", "Type", "Priority", "Owner" };
            string[] formats = new string[] { "{0,-25}", "{1,-40}", "{2,-8}", "{3,-13}", "{4,-9}" };

            string format = String.Join(String.Empty, formats);

            Console.WriteLine(format, headers);
            Console.WriteLine(new String(ASCII.SUBTRACT, 10));

            foreach (var script in scripts)
            {
                Console.WriteLine(format, script.CaseID, script.Name, script.Type, script.Priority, script.Owner);
            }

            Console.WriteLine("You can also see the exported file at:\n{0}", Path.GetFullPath(exportFilePath));
        }

        [Command]
        public static void Run([Parameter]string planID, [Parameter(ShortName = "u")]string url, [Parameter(ShortName = "b")]string browser, [Parameter(ShortName = "l")]string language)
        {
            Console.WriteLine("Start execution..");

            List<ResultEntity> results = ExecutionBL.Execute(planID, url, browser, language);

            Console.WriteLine("Execution finished.");

            if (results.Count <= 0)
            {
                Console.WriteLine("No result collected.");
                return;
            }

            ExecutionEntity execution = ExecutionBL.GetExecutionByID(results.First().ExecutionID);

            int caseCount = PlanBL.GetPlanByPlanID(planID).ScriptList.Count;
            TimeSpan? elapsedTime = execution.EndTime.HasValue ? (execution.EndTime - execution.StartTime) : null;
            Console.WriteLine("{0} {1} scripts run, time taken {2}s", planID, caseCount, elapsedTime.HasValue ? elapsedTime.ToString() : "0");
            Console.WriteLine("Result:");

            string[] headers = new string[] { "ExecutionID", "CaseID", "Status", "FailReason" };
            string[] formats = new string[] { "{0,-8}", "{1,-30}", "{2,-14}", "{3,-30}" };

            string format = String.Join(String.Empty, formats);

            foreach (var group in results.GroupBy(r => r.CaseID))
            {
                ConsoleColor color = group.First().Status == ScriptExecutionStatus.Passed ? ConsoleColor.Green : group.First().Status == ScriptExecutionStatus.NotRun ? ConsoleColor.Yellow : ConsoleColor.Red;
                ConsoleHelper.WriteColorLine(String.Format(format, group.Key, group.First().ExecutionID, group.First().Status, group.First().FailReason), color);
            }
        }
    }
}
