using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Administration;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Administration.IndustryLabeling
{
    [TestFixture]
    [Owner("Amber")]
    [CreateTime("2013-10-12")]
    public class LabelingAddInvalidSuite : TestSuiteBase
    {
        private static LabelingSetting LabelingSetting = JazzFunction.LabelingSetting;
        [SetUp]
        public void CaseSetUp()
        {
            LabelingSetting.NavigatorToLabelSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.MediumPause();
        }

        #region TestCase1 AddIndustryBenchmarkCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustryBenchmarkSetting-Add-001")]
        [CaseID("TC-J1-FVT-IndustryBenchmarkSetting-Add-001-1")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryLabelingData[]), typeof(LabelingAddInvalidSuite), "TC-J1-FVT-IndustryBenchmarkSetting-Add-001-1")]
        public void AddIndustryBenchmarkCancelled(IndustryLabelingData input)
        {

            //Click +行业对标 buttons.
            LabelingSetting.ClickAddLabeling();
            
            

        }
        #endregion

      

    }
}
