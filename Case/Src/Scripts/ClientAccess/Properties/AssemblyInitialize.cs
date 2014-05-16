using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library;
using Mento.Framework.Execution;

namespace Mento.Script.ClientAccess
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            TestAssemblyInitializer.InitializeExecutionContext();         
            JazzBrowseManager.OpenJazz();

        }

        [TearDown]
        public void RunAfterAnyTests()
        {            
            JazzBrowseManager.CloseJazz();
            ExecutionContext.Destruct();
        }

    }
}
