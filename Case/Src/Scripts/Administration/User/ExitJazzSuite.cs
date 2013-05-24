using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using System.IO;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Administration;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Administration.User
{
    [TestFixture]
    [Owner("Nancy")]
    [CreateTime("2013-01-08")]
    [ManualCaseID("TC-J1-SmokeTest")]
    public class ExitJazzSuite : TestSuiteBase
    {
        private UserSettings UserSettings = JazzFunction.UserSettings;

        [SetUp]
        public void CaseSetUp()
        {
            UserSettings.NavigatorToUserSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-034"), CreateTime("2013-01-08"), Owner("Nancy")]
        public void ExitJazz()
        {
            //JazzFunction.UserProfile.ExitJazz();
            JazzMessageBox.MessageBox.GetMessage();
            JazzMessageBox.MessageBox.Confirm();
            TimeManager.LongPause();
            //User login window display
        }
    }
}
