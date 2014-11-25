using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library;

namespace Mento.Script.Information
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            TestAssemblyInitializer.InitializeWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCostCustomer2");
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            TestAssemblyInitializer.Desctuct();
        }
    }
}
