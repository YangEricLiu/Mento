using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library;
using Mento.Framework.Execution;

namespace Mento.Script.TestScript
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            TestAssemblyInitializer.InitializeExecutionContext();
            Mento.Framework.DataAccess.JazzDataInitializer.Initialize();
            JazzBrowseManager.OpenJazz();
            
            Mento.ScriptCommon.TestData.ClientAccess.LoginInputData input=new ScriptCommon.TestData.ClientAccess.LoginInputData();
            input.UserName="PlatformAdmin";
            input.Password="P@ssw0rd";
            JazzFunction.LoginPage.LoginToSelectCusromerPage(input);
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            JazzBrowseManager.CloseJazz();
            ExecutionContext.Destruct();
        }
    }
}
