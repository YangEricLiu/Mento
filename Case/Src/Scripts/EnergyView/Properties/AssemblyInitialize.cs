
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
            TimeManager.Pause(5000);

            TestAssemblyInitializer.NewJazz_DeleteActualExcelFiles();

            TestAssemblyInitializer.InitializeWithOption("EmmaDataVerify", "123456Qq", "喜达屋酒店集团");
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            TestAssemblyInitializer.Desctuct();          
        }
    }
}
