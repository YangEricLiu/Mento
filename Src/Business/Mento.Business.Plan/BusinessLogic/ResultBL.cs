using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Business.Plan.DataAccess;
using System.Data;
using Mento.Business.Plan.Entity;
using Mento.Framework.Configuration;
using System.IO;
using Mento.Utility;

namespace Mento.Business.Plan.BusinessLogic
{
    public class ResultBL
    {
        private static ResultDA ResultDA = new ResultDA();
        private static PlanBL PlanBL = new PlanBL();

        public DataTable ExeportByPlanID(string planID, long executionID)
        {
            PlanEntity plan = PlanBL.GetPlanByPlanID(planID);

            DataTable results = ResultDA.Retrieve(plan.ID, executionID);

            results.Columns.Add("PlanID");
            foreach (DataRow row in results.Rows)
                row["PlanID"] = planID;

            //TODO:
            //Export to excel
            string fileName = Path.Combine(ExportConfig.ResultExportDirectory, String.Format("{0}-{1}.xls", plan.PlanID, executionID));

            ExcelHelper.ExportToExcel(results, fileName, "ResultList");

            return results;
        }

        public DataTable ExeportByCaseID(string caseID, long executionID)
        {
            DataTable results = ResultDA.Retrieve(caseID, executionID);

            results.Columns.Add("PlanID");
            foreach (DataRow row in results.Rows)
                row["PlanID"] = PlanBL.GetPlanByExecutionID(executionID).PlanID;

            //TODO:
            //Export to excel
            string fileName = Path.Combine(ExportConfig.ResultExportDirectory, String.Format("{0}-{1}.xls", caseID, executionID));

            ExcelHelper.ExportToExcel(results, fileName, "ResultList");

            return results;
        }

        public DataTable Exeport(string planID, string caseID, long executionID)
        {
            PlanEntity plan = PlanBL.GetPlanByPlanID(planID);

            DataTable results = ResultDA.Retrieve(plan.ID, caseID, executionID);

            //TODO:
            //Export to excel
            string fileName = Path.Combine(ExportConfig.ResultExportDirectory, String.Format("{0}-{1}-{2}.xls", plan.PlanID, caseID, executionID));

            ExcelHelper.ExportToExcel(results, fileName, "ResultList");

            return results;
        }
    }
}
