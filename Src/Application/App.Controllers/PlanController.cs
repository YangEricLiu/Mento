using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Business.Plan.BusinessLogic;
using Mento.Utility;
using Mento.Business.Plan.Entity;
using Mento.Framework.Attributes;

namespace Mento.App.Controllers
{
    [Controller]
    public static class PlanController
    {
        private static PlanBL PlanBL = new PlanBL();

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
            planID = "";
            planFile = @"D:\publish\TA\plan-example.xml";
 
        }

        [Command]
        public static void Delete([Parameter]string planID)
        {
 
        }

        [Command]
        public static PlanEntity[] View()
        {
            throw new NotImplementedException();
        }

        [Command]
        public static PlanEntity View([Parameter]string planID)
        {
            throw new NotImplementedException();
        }

        [Command]
        public static void Run([Parameter]string planID, [Parameter(ShortName = "u")]string url, [Parameter(ShortName = "b")]string browser, [Parameter(ShortName = "l")]string language)
        {

 
        }
    }
}
