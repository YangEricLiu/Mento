using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Script;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface;

namespace Mento.Script.TestScript.Login
{
    [TestFixture]
    [Owner("Eric")]
    [CreateTime("2013-05-10")]
    [ManualCaseID("TC-J1-SmokeTest-031")]
    public class CommonUserLoginSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzBrowseManager.OpenJazz();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-031")]
        public void Login()
        {
            JazzFunction.LoginPage.LoginWithOption("PlatformAdmin", "P@ssw0rd", "REM管理平台");

            Assert.IsTrue(JazzFunction.LoginPage.IsAlreadyLogin());
        }
    }
}
