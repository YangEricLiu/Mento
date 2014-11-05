using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library;

namespace Mento.Script.EnergyView
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            TestAssemblyInitializer.InitializeWithOption("SchneiderelectricChina", "P@ssw0rdChina", "NancyCustomer1");
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            TestAssemblyInitializer.Desctuct();
        }
    }
}
