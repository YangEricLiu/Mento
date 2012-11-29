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


namespace Mento.Script.Customer.Hierarchy
{
    [TestFixture]
    public class HierarchyManagement : TestSuiteBase
    {
        private static HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;

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
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TA-Hierarchy-001"), ManualCaseID("TJ-Hierarchy-001"), CreateTime("2012-10-30"), Owner("Emma")]
        [MultipleTestDataSource(typeof(AddHierarchyData[]), typeof(HierarchyManagement), "TA-Hierarchy-001")]
        public void AddOrgnizationNodeTest(AddHierarchyData input)
        {
            HierarchySettings.FillInHierarchyNode("Schneider", input.InputData);
            HierarchySettings.ClickSaveButton();
            HierarchySettings.WaitForCreateOKDisplay(120);

            //ElementLocator.Pause(500);
            TimeManager.PauseShort();

            HierarchySettings.ConfirmCreateOKMagBox();

            Assert.IsTrue(HierarchySettings.IsNodesChildParent(input.InputData.Name, "Schneider"));

            HierarchySettings.FocusOnHierarchyNode(input.InputData.Name);

            Assert.AreEqual(HierarchySettings.GetTypeExpectedValue(input.InputData.Type), HierarchySettings.GetTypeValue());
        }

    }
}
