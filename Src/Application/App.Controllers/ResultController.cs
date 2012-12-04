using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Attributes;
using Mento.Business.Plan.BusinessLogic;
using Mento.Framework.Exceptions;
using Mento.Framework.Constants;
using System.Data;
using Mento.Utility;

namespace Mento.App.Controllers
{
    [Controller]
    public static class ResultController
    {
        private static PlanBL PlanBL = new PlanBL();
        private static ExecutionBL ExecutionBL = new ExecutionBL();
        private static ResultBL ResultBL = new ResultBL();


        [Command(Name = "View")]
        public static void ViewPlan([Parameter(ShortName = "p")]string planID)
        {
            Console.WriteLine("Begin query..");

            var datatable = ExecutionBL.ExportByPlanID(planID);

            //TODO:
            //Print the execution information list
            Console.WriteLine("There are {0} executions for plan '{1}':", datatable.Rows.Count, planID);

            string[] headers = new string[] { "ID", "PlanID", "Browser", "Language", "Url" };
            string[] format = new string[] { "{0,-8}", "{1,-20}", "{2,-8}", "{3,-10}", "{4,-40}" };

            ConsoleHelper.PrintDataTable(datatable, headers, format);

            Console.WriteLine("In the mean while, the execution record are exported to result export directory.");
        }

        [Command(Name = "View")]
        public static void ViewCase([Parameter(ShortName = "c")]string caseID)
        {
            Console.WriteLine("Begin query..");

            var datatable = ExecutionBL.ExportByCaseID(caseID);

            //TODO:
            //Print the execution information list
            Console.WriteLine("There are {0} executions for script '{1}':", datatable.Rows.Count, caseID);

            string[] headers = new string[] { "ID", "PlanID", "Browser", "Language", "Url" };
            string[] format = new string[] { "{0,-8}", "{1,-20}", "{2,-8}", "{3,-10}", "{4,-40}" };

            ConsoleHelper.PrintDataTable(datatable, headers, format);

            Console.WriteLine("In the mean while, the execution record are exported to result export directory.");
        }

        [Command(Name = "View")]
        public static void ViewPlan([Parameter(ShortName = "p")]string planID, [Parameter(ShortName = "e")]long executionID)
        {
            Console.WriteLine("Begin query..");

            var datatable = ResultBL.ExeportByPlanID(planID,executionID);

            //TODO:
            //Print the result detail
            Console.WriteLine("There are {0} results for execution '{1}' of plan '{2}':", datatable.Rows.Count, executionID, planID);

            string[] headers = new string[] { "PlanID", "CaseID", "ExecutionID", "Status", "FailReason" };
            string[] format = new string[] { "{0,-20}", "{1,-20}", "{2,-14}", "{3,-8}", "{4,-30}" };

            ConsoleHelper.PrintDataTable(datatable, headers, format);

            Console.WriteLine("In the mean while, the results are exported to result export directory.");
        }

        [Command(Name = "View")]
        public static void ViewCase([Parameter(ShortName = "c")]string caseID, [Parameter(ShortName = "e")]long executionID)
        {
            Console.WriteLine("Begin query..");

            var datatable = ResultBL.ExeportByCaseID(caseID, executionID);

            //TODO:
            //Print the result detail
            Console.WriteLine("There are {0} results for execution '{1}' of case '{2}':", datatable.Rows.Count, executionID, caseID);

            string[] headers = new string[] { "PlanID", "CaseID", "ExecutionID", "Status", "FailReason" };
            string[] format = new string[] { "{0,-20}", "{1,-20}", "{2,-14}", "{3,-8}", "{4,-30}" };

            ConsoleHelper.PrintDataTable(datatable, headers, format);

            Console.WriteLine("In the mean while, the results are exported to result export directory.");
        }

        [Command]
        public static void View([Parameter(ShortName = "p")]string planID, [Parameter(ShortName = "c")]string caseID, [Parameter(ShortName = "e")]long executionID)
        {
            Console.WriteLine("Begin query..");

            var datatable = ResultBL.Exeport(planID, caseID, executionID);

            //TODO:
            //Print the result detail
            Console.WriteLine("There are {0} results for execution '{1}' of case '{2}' in plan '{3}':", datatable.Rows.Count, executionID, caseID,planID);

            string[] headers = new string[] { "CaseID", "ExecutionID", "Status", "FailReason" };
            string[] format = new string[] { "PlanID", "{0,-20}", "{1,-14}", "{2,-8}", "{3,-30}" };

            ConsoleHelper.PrintDataTable(datatable, headers, format);

            Console.WriteLine("In the mean while, the results are exported to result export directory.");
        }
    }
}
