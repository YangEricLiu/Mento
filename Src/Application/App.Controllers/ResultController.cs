using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Attributes;
using Mento.Business.Plan.BusinessLogic;
using Mento.Framework.Exceptions;
using Mento.Business.Result.BusinessLogic;

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
            long parsedPlanID = 0;
            if (long.TryParse(planID, out parsedPlanID))
            {
                ExecutionBL.ExportByPlanID(parsedPlanID);
            }
            else
            {
                throw new AppException("parameter error: planID");
            }
        }

        [Command(Name = "View")]
        public static void ViewCase([Parameter(ShortName = "c")]string caseID)
        {
            ExecutionBL.ExportByCaseID(caseID);
        }

        [Command(Name = "View")]
        public static void ViewPlan([Parameter(ShortName = "p")]string planID, [Parameter(ShortName = "e")]long executionID)
        {
            ResultBL.Exeport(planID,executionID);
        }

        [Command(Name = "View")]
        public static void ViewCase([Parameter(ShortName = "c")]string caseID, [Parameter(ShortName = "e")]long executionID)
        {
        }

        [Command]
        public static void View([Parameter(ShortName = "p")]string planID, [Parameter(ShortName = "c")]string caseID, [Parameter(ShortName = "e")]long executionID)
        {
        }
    }
}
