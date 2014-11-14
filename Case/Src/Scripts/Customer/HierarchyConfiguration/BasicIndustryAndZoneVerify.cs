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

namespace Mento.Script.Customer.HierarchyConfiguration
{
    [TestFixture]
    [Owner("Cathy")]
    [CreateTime("2014-9-29")]
    public class BasicIndustryAndZoneSettingSuite : TestSuiteBase
    {
        private static BasicIndustryAndZoneSetting BasicIndustryAndZoneSetting = JazzFunction.BasicIndustryAndZoneSetting;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.SelectCustomer("CommodityTestCustomer");
            BasicIndustryAndZoneSetting.NavigatorToHierarchySetting();
            TimeManager.MediumPause();

        }

        [TearDown]
        public void CaseTearDown()
        {
            
        }
        
        #region TestCase1 Verify Basic industry and zone setting
        [Test]
        [ManualCaseID("TC-J1-FVT-BasicIndustryAndZoneSetting-View-101")]
        [CaseID("TC-J1-FVT-BasicIndustryAndZoneSetting-View-101")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryAndZoneData[]), typeof(BasicIndustryAndZoneSettingSuite), "TC-J1-FVT-BasicIndustryAndZoneSetting-View-101")]
        public void VerifyIndustryAndZoneCorrect(IndustryAndZoneData input)
        {
            //Verify Industry and Zone in building hierarchy
            BasicIndustryAndZoneSetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.LongPause();
            BasicIndustryAndZoneSetting.ClickModifyButton();
            TimeManager.LongPause();
            //Verify Industry as expect.
            Assert.AreEqual(input.ExpectedData.Industry, BasicIndustryAndZoneSetting.GetIndustryIdComboBoxList());
            BasicIndustryAndZoneSetting.ClickCancelButton();
            BasicIndustryAndZoneSetting.ClickModifyButton();
            TimeManager.LongPause();
            //Verify Zone as expect.
            Assert.AreEqual(input.ExpectedData.Zone, BasicIndustryAndZoneSetting.GetZoneIdComboBoxList());
        }
        #endregion
    }
}
