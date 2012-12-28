﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.Utility;
using Mento.Framework.Attributes;

namespace Mento.Script.Administration.Calendar
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2012-12-28")]
    [ManualCaseID("TC-J1-SmokeTest-015")]
    public class TimeMagament: TestSuiteBase
    {
        [SetUp]
        public void ScriptSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
        }

        [TearDown]
        public void ScriptTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-Workday-001")]
        public void AddWorkDayForValid()
        { 
            

        }

    }
}
