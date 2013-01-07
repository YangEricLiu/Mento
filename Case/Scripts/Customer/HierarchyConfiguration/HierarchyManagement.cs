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
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.ScriptCommon.TestData.Customer;


namespace Mento.Script.Customer.HierarchyConfiguration
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
            //JazzFunction.Navigator.NavigateHome();
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TA-Hierarchy-001"), ManualCaseID("TJ-Hierarchy-001"), CreateTime("2012-10-30"), Owner("Emma")]
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
