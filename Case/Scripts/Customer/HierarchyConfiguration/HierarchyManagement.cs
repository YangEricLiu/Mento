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
using Mento.TestApi.TestData;


namespace Mento.Script.Customer.HierarchyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2012-10-30")]
    [ManualCaseID("TC-J1-SmokeTest-001")]
    public class HierarchyManagement : TestSuiteBase
    {
        private static HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;

        [SetUp]
        public void CaseSetUp()
        {
            HierarchySettings.NavigatorToHierarchySetting();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        [TearDown]
        public void CaseTearDown()
        {
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-001-001")]
        [Priority("P1")]
        [Type("Smoke")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(HierarchyManagement), "TC-J1-SmokeTest-001-001")]
        public void AddOrgnizationNodeTest(HierarchyData input)
        {
            HierarchySettings.FillInHierarchyNode("自动化测试", input.InputData);
            TimeManager.MediumPause();
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
