using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-01-06")]
    [ManualCaseID("TC-J1-SmokeTest-021")]
    public class AddPeopleAreaPropertySuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static HierarchyPeopleAreaSettings PeopleAreaSetting = JazzFunction.HierarchyPeopleAreaSettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-021-001")]
        [Priority("38")]
        [Type(ScriptType.BVT)]
        public void AddAreaProperty()
        {
            HierarchySetting.ExpandNode("自动化测试");
            HierarchySetting.ExpandNode("AddCalendarProperty");
            HierarchySetting.FocusOnHierarchyNode("AddPeopleProperty");
            
            PeopleAreaSetting.ClickPeopleAreaTab();
            TimeManager.ShortPause();
            PeopleAreaSetting.ClickPeopleAreaCreateButton();

            PeopleAreaSetting.InputTotalAreaValue("10");
            PeopleAreaSetting.InputHeatingAreaValue("20");
            PeopleAreaSetting.InputCoolingAreaValue("30");
            TimeManager.ShortPause();

            PeopleAreaSetting.ClickSaveButton();
            TimeManager.ShortPause();

            Assert.AreEqual(PeopleAreaSetting.GetTotalAreaValue(), "10");
            Assert.AreEqual(PeopleAreaSetting.GetHeatingAreaValue(), "20");
            Assert.AreEqual(PeopleAreaSetting.GetCoolingAreaValue(), "30");
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-021-002")]
        [Priority("P1")]
        [Type(ScriptType.BVT)]
        public void AddPeoplePeoperty()
        {
            HierarchySetting.ExpandNode("自动化测试");
            HierarchySetting.ExpandNode("AddCalendarProperty");
            HierarchySetting.FocusOnHierarchyNode("AddPeopleProperty");

            PeopleAreaSetting.ClickPeopleAreaTab();
            TimeManager.ShortPause();
            PeopleAreaSetting.ClickPeopleAreaCreateButton();

            PeopleAreaSetting.ClickPeopleCreateButton();
            TimeManager.ShortPause();
            PeopleAreaSetting.SelectEffectiveDate(new DateTime(2031, 3, 2));
            TimeManager.ShortPause();
            PeopleAreaSetting.InputPeopleNumber("30");
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.ShortPause();
            Assert.AreEqual(PeopleAreaSetting.GetEffectiveDateValue(), "2031-03");
            Assert.AreEqual(PeopleAreaSetting.GetPeopleNumberValue(), "30");
        }
    }
}
