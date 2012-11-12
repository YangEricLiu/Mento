using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mento.Business.Plan.Entity;
using Mento.Business.Plan.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Mento.Framework.Constants;
using System.Data;
using Mento.Framework;

namespace Mento.Business.Plan.Test
{
    [TestClass]
    public class PlanDataAccessTest
    {
        private static PlanDA PlanDA = new PlanDA();
        private static string UnitTestPlanID = "Plan_Unit_Test";
        private static Database Database = DatabaseContainer.Database;

        [TestCleanup]
        public void TestCleanup()
        {
            DeleteTestingData();
        }

        [TestMethod]
        public void CreateTest()
        {
            PlanEntity plan = new PlanEntity() 
            {
                PlanID = UnitTestPlanID,
                Name = "UnitTestPlan",
                Owner="Aries",
                Status = Framework.Enumeration.EntityStatus.Active,
                UpdateTime = DateTime.Now,
                TargetVersion = String.Empty,                
            };

            long result = PlanDA.Create(plan);

            Assert.IsTrue(result>0);
        }

        private void DeleteTestingData()
        {
            string sql = String.Format("DELETE FROM [Plan] WHERE [PlanID]='{0}'", UnitTestPlanID);

            Database.ExecuteNonQuery(CommandType.Text,sql);
        }
    }
}
