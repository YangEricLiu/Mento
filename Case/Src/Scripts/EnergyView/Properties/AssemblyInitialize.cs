
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.Library.Functions;

namespace Mento.Script.EnergyView
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            //TestAssemblyInitializer.InitializeWithOption("SP2", "P@ssw0rd", "NancyOtherCustomer3");
            TestAssemblyInitializer.InitializeWithOption("EmmaDataVerify", "123456Qq", "NancyCustomer1");
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            //delete the dashboards which add when running 
            //JazzFunction.HomePage.DeleteDashboardsAfterExecution();

            TestAssemblyInitializer.Desctuct();       
        }
    }
}
