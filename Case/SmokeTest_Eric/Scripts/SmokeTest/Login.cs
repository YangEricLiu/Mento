using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Script;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;

namespace Mento.Script.SmokeTest
{
    [TestFixture]
    [Owner("Eric")]
    [CreateTime("2013-05-09")]
    [ManualCaseID("TC-J1-SmokeTest-031")]
    public class Login : TestSuiteBase
    {
        [Test]
        [CaseID("TC-J1-SmokeTest-031")]
        public void LoginAsPlatformAdmin()
        {
            JazzFunction.LoginPage.LoginToAdmin();

            Assert.IsTrue(JazzFunction.LoginPage.IsAlreadyLogin());
        }
    }
}
