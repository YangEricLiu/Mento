using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Business.Result.DataAccess;
using System.Data;

namespace Mento.Business.Result.BusinessLogic
{
    public class ResultBL
    {
        private static ResultDA ResultDA = new ResultDA();

        public DataTable ExeportByPlanID(string planID, long executionID)
        {
            DataTable results = ResultDA.Retrieve(planID, executionID);


            return results;
        }

        public DataTable ExeportByCaseID(string caseID, long executionID)
        {
            DataTable results = ResultDA.Retrieve(caseID, executionID);



            return results;
        }

        public DataTable Exeport(long planID, string caseID, long executionID)
        {
            DataTable results = ResultDA.Retrieve(planID, caseID, executionID);


            return results;
        }
    }
}
