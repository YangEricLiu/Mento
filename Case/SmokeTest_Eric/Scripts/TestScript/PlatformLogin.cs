﻿using System;
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
    [ManualCaseID("TA-Smoke-Login-000")]
    public class CommonUserLoginSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzBrowseManager.RefreshJazz();
            JazzFunction.LoginPage.SelectCustomer("REM管理平台");
        }
        [TearDown]
        public void CaseTearDown()
        {
            
        }

        [Test]
        [Owner("Eric")]
        [CaseID("TA-Smoke-Login-000")]
        public void Login()
        {            
            Assert.IsTrue(JazzFunction.LoginPage.IsAlreadyLogin());
        }
    }
}
