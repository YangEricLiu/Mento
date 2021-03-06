﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Script;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;

namespace Mento.Script.ClientAccess.Login
{
    [TestFixture]
    [Owner("Aries")]
    [CreateTime("2012-11-22")]
    [ManualCaseID("TC-J1-SmokeTest-031")]
    public class SmokeTestCommonUserLoginSuite : TestSuiteBase
    {
        [Test]
        [CaseID("TC-J1-SmokeTest-031")]
        public void Login()
        {
            JazzFunction.LoginPage.LoginToCustomer();

            Assert.IsTrue(JazzFunction.LoginPage.IsAlreadyLogin());
        }
    }
}
