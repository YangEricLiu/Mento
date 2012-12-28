using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using Mento.Utility;
using Mento.Framework.Attributes;
using Mento.TestApi.TestData;
using System.IO;
using Mento.Framework.Script;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;


namespace Mento.Script.Customer.HierarchySettings
{
    [TestFixture]
    public class HierarchyManagement : TestSuiteBase
    {
        private static Mento.ScriptCommon.Library.Functions.HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;

        [TestFixtureSetUp]
        public void CaseFixtureSetUp()
        {
            //ElementLocator.OpenJazz();
            //FunctionWrapper.Login.Login();
        }

        [TestFixtureTearDown]
        public void CaseFixtureTearDown()
        {
            //ElementLocator.CloseJazz();
        }

        [SetUp]
        public void CaseSetUp()
        {
            //FunctionWrapper.Hierarchy.NavigatorToHSetting();
            //ElementLocator.Pause(2000);
            HierarchySettings.NavigatorToHierarchySetting();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //
            //JazzFunction.Navigator.NavigateHome();
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TA-Hierarchy-001"), ManualCaseID("TJ-Hierarchy-001"), CreateTime("2012-10-30"), Owner("Emma")]
        [MultipleTestDataSource(typeof(AddHierarchyData[]), typeof(HierarchyManagement), "TA-Hierarchy-001")]
        public void AddOrgnizationNodeTest(AddHierarchyData input)
        {
            HierarchySettings.FillInHierarchyNode("自动化测试", input.InputData);
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();
            
            string msgText = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText.Contains("添加成功"));

            TimeManager.ShortPause();

            HierarchySettings.ConfirmCreateOKMagBox();

            Assert.IsTrue(HierarchySettings.IsNodesChildParent(input.InputData.Name, "自动化测试"));

            HierarchySettings.FocusOnHierarchyNode(input.InputData.Name);

            Assert.AreEqual(HierarchySettings.GetTypeExpectedValue(input.InputData.Type), HierarchySettings.GetTypeValue());
        }

    }
}
