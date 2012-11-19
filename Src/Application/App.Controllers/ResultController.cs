using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Attributes;
using Mento.Business.Plan.BusinessLogic;
using Mento.Framework.Exceptions;

namespace Mento.App.Controllers
{
    [Controller]
    public static class ResultController
    {
        private static ExecutionBL ExecutionBL = new ExecutionBL();
        private static ResultBL ResultBL = new ResultBL();


        [Command(Name = "View")]
        public static void ViewPlan([Parameter(ShortName = "p")]string planID)
        {
            var executions = ExecutionBL.ExportByPlanID(planID);

            //TODO:
            //Print the execution information list
            Console.WriteLine("There are {0} scripts currently", executions.Length);

            //For the item string is too long, so just display 5 column
            Console.WriteLine("\n{0,-25}{1,-40}{2,-8}{3,-13}{4,-9}", "CaseID", "Name", "Type", "Priority", "Owner");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            //foreach (var execution in executions)
            //{
            //    Console.WriteLine("\n{0,-25}{1,-40}{2,-8}{3,-13}{4,-9}", script.CaseID, script.Name, script.Type, script.Priority, script.Owner);
            //}
        }

        [Command(Name = "View")]
        public static void ViewCase([Parameter(ShortName = "c")]string caseID)
        {
            ExecutionBL.ExportByCaseID(caseID);

            //TODO:
            //Print the execution information list
        }

        [Command(Name = "View")]
        public static void ViewPlan([Parameter(ShortName = "p")]string planID, [Parameter(ShortName = "e")]long executionID)
        {
            ResultBL.ExeportByPlanID(planID,executionID);

            //TODO:
            //Print the result detail
        }

        [Command(Name = "View")]
        public static void ViewCase([Parameter(ShortName = "c")]string caseID, [Parameter(ShortName = "e")]long executionID)
        {
            ResultBL.ExeportByCaseID(caseID, executionID);

            //TODO:
            //Print the result detail
        }

        [Command]
        public static void View([Parameter(ShortName = "p")]string planID, [Parameter(ShortName = "c")]string caseID, [Parameter(ShortName = "e")]long executionID)
        {
            ResultBL.Exeport(planID, caseID, executionID);

            //TODO:
            //Print the result detail
        }
    }
}
