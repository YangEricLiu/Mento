using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Mento.Utility;
using Mento.Framework.Constants;
using Mento.Framework.Attributes;
using Mento.Framework.Configuration;
using Mento.Business.Plan.Entity;
using Mento.Business.Plan.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using Mento.Framework;
using Mento.Business.Plan.BusinessLogic;

namespace Mento.Business.Plan.Test
{
    [TestClass]
    public class ScriptDataExportTest
    {
        private static PlanDA PlanDA = new PlanDA();
        private static PlanBL ll = new PlanBL();

        [TestInitialize]
        public void TestInitialize()
        {
            //
        }

        /*
        [TestMethod]
        public void GetPlansDataTest()
        {
            PlanEntity plan1 = new PlanEntity() { PlanID = "Plan_001", Name = "N1", ProductVersion = "0.5", Owner = "Emma", UpdateTime = DateTime.Now, Status = Framework.Enumeration.EntityStatus.Active };
            PlanEntity plan2 = new PlanEntity() { PlanID = "Plan_002", Name = "N2", ProductVersion = "0.5", Owner = "Emma", UpdateTime = DateTime.Now, Status = Framework.Enumeration.EntityStatus.Active };
            PlanEntity plan3 = new PlanEntity() { PlanID = "Plan_003", Name = "N3", ProductVersion = "0.5", Owner = "Emma", UpdateTime = DateTime.Now, Status = Framework.Enumeration.EntityStatus.Active };

            long result = PlanDA.Create(plan1);
            long result2 = PlanDA.Create(plan2);
            long result3 = PlanDA.Create(plan3);

            ll.Export();
        }*/

        [TestMethod]
        public void GetPlansDataTest()
        {
            //string planid = "Plan_002";

            //string pathApp = "";

            ll.Export();
            //Assert.AreEqual(AppDomain.CurrentDomain.BaseDirectory.ToString(), "hello");
        }

    }
}
