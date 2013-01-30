using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mento.Business.Plan.Entity;
using Mento.Business.Plan.DataAccess;

namespace Mento.Business.Result.Test
{
    [TestClass]
    public class ResultDataAccessTest
    {
        private ResultDA ResultDA = new ResultDA();

        [TestMethod]
        public void CreateTest()
        {
            ResultEntity entity = new ResultEntity()
            {
                CaseID = "",
                ExecutionID = 1,
                FailDetail = "",
                FailReason = "",
                ImageUrl = "",
                Status = ScriptExecutionStatus.Passed
            };

            long result = ResultDA.Create(entity);

            Assert.IsTrue(result != 0);
        }
    }
}
