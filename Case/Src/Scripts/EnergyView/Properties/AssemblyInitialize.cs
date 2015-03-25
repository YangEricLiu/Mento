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
            TestAssemblyInitializer.InitializeWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCustomer1");
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            //delete the dashboards which add when running 
            JazzFunction.HomePage.DeleteDashboardsAfterExecution();

            TestAssemblyInitializer.Desctuct();       
        }
    }
}
