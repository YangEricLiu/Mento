using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library;

namespace Mento.Script.Administration
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            TestAssemblyInitializer.InitializeWithOption("SchneiderElectricChina", "P@ssw0rd", "“云能效”系统管理");
            //TestAssemblyInitializer.InitializeWithOption("PlatformAdmin", "P@ssw0rd", "“云能效”系统管理");
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            TestAssemblyInitializer.Desctuct();
        }
    }
}
