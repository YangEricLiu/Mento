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
            planFile = @"D:\publish\TA\plan-example.xml";

            Console.WriteLine("creating plan..");
            try
            {
                PlanBL.Create(planFile);
            }
            catch (Exception ex)
            {
                ColorConsole.WriteLine(ex.Message, ConsoleColor.Red);
            }
        }

        [Command]
        public static void Update([Parameter]string planID, [Parameter]string planFile)
        {
            planID = "TA-P01";
            planFile = @"D:\publish\TA\plan-example.xml";

            PlanBL.Update(planID,planFile);
        }

        [Command]
        public static void Delete([Parameter]string planID)
        {
            planID = "TA-P01";
            PlanBL.Delete(planID);
        }

        [Command]
        public static void View()
        {
            PlanEntity[] plans = PlanBL.Export();
            int planNumber = plans.GetLength(0);

            Console.WriteLine("There are {0} plans currently", planNumber);

            //Display the plan 
            Console.WriteLine("\n{0,-20}{1,-20}{2,-8}{3,-13}{4,-9}{5,-10}", "PlanID", "Name", "ProductVersion", "Owner", "UpdateTime","Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            foreach (var plan in plans)
            {   
                //format the plan information
                Console.WriteLine("\n{0,-20}{1,-20}{2,-8}{3,-13}{4,-9}{5,-10}", plan.PlanID, plan.Name,plan.ProductVersion, plan.Owner, plan.UpdateTime,plan.Status);
            }
        }

        [Command]
        public static void View([Parameter]string planID)
        {
            ScriptEntity[] scripts = PlanBL.Export(planID);
            int scriptsNumber = scripts.GetLength(0);

            Console.WriteLine("There are {0} scripts in plan -- {1}currently", scriptsNumber, planID);

            //Display scripts list
            Console.WriteLine("\n{0,-25}{1,-40}{2,-8}{3,-13}{4,-9}", "CaseID", "Name", "Type", "Priority", "Owner");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            foreach (var script in scripts)
            {
                //format the script information
                Console.WriteLine("\n{0,-25}{1,-40}{2,-8}{3,-13}{4,-9}", script.CaseID, script.Name, script.Type, script.Priority, script.Owner);
            }
        }

        [Command]
        public static void Run([Parameter]string planID, [Parameter(ShortName = "u")]string url, [Parameter(ShortName = "b")]string browser, [Parameter(ShortName = "l")]string language)
        {
            planID = "TA-P02";
            ExecutionBL.Execute(planID,url,browser,language); 
        }
    }
}
