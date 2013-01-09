using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.Library.Functions;
using Mento.TestApi.WebUserInterface;

namespace Mento.Script.Administration.CarbonFactor
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2012-12-28")]
    [ManualCaseID("TC-J1-SmokeTest-015")]
    public class CarbonManagement:TestSuiteBase
    {
        [SetUp]
        public void ScriptSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CarbonSettings);
        }

        [TearDown]
        public void ScriptTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-Carbon-001")]
        public void AddCarbonForValid()
        {
            string a = "";

        }
    }
}
