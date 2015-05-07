using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library;

namespace Mento.Script.Platform
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            //TestAssemblyInitializer.Initialize();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            //TestAssemblyInitializer.Desctuct();
        }
    }
}
