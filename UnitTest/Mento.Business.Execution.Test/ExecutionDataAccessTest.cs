using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mento.Business.Execution.Entity;
using Mento.Business.Execution.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using Mento.Framework;
using Mento.Business.Plan.DataAccess;
using Mento.Business.Plan.Entity;

namespace Mento.Business.Execution.Test
{
    [TestClass]
    public class ExecutionDataAccessTest
    {
        private static Database Database = DatabaseContainer.Database;

        private static ExecutionDA ExecutionDA = new ExecutionDA();
        private static PlanDA PlanDA = new PlanDA();

        private static string UnitTestPlanIdentity = "Execution_Plan_Unit_Test";
        private static long UnitTestPlanID = 0;

        [TestInitialize]
        public void TestInitialize()
        {
            CreateTestingData();
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            DeleteTestingData();
        }

        [TestMethod]
        public void CreateTest()
        {
            ExecutionEntity execution = new ExecutionEntity()
            {
                PlanID = UnitTestPlanID,
                Browser = Browser.Chrome,
                Language = Language.CN,
                StartTime = DateTime.Now.AddMinutes(-1),
                EndTime = DateTime.Now,
                Owner = "Aries",
                Url = "Https://jazz",
                CpuCount = 4,
                CpuFrequency = 2,
                MemorySize = 4096,
                ScreenResolution = "1366*768",
            };

            long result = ExecutionDA.Create(execution);

            Assert.IsTrue(result > 0);
        }

        private void CreateTestingData()
        {
            PlanEntity plan = new PlanEntity()
            {
                PlanID = UnitTestPlanIdentity,
                Name = "UnitTestPlan",
                Owner = "Aries",
                Status = Framework.Enumeration.EntityStatus.Active,
                UpdateTime = DateTime.Now,
                Version = String.Empty,
            };

            UnitTestPlanID = PlanDA.Create(plan);
        }

        private void DeleteTestingData()
        {
            string sql1 = String.Format("DELETE FROM [Execution] WHERE [PlanID]={0}", UnitTestPlanID);
            Database.ExecuteNonQuery(CommandType.Text, sql1);

            string sql0 = String.Format("DELETE FROM [Plan] WHERE [PlanID]='{0}'",UnitTestPlanIdentity );
            Database.ExecuteNonQuery(CommandType.Text, sql0);
        }
    }
}
