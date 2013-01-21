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
    public class HierarchyManagementSuite : TestSuiteBase
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
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-001-001")]
        [Priority("12")]
        [Type(ScriptType.BVT)]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(HierarchyManagementSuite), "TC-J1-SmokeTest-001-001")]
        public void AddOrgnizationAndSiteNodeTest(HierarchyData input)
        {
            /// <summary>
            /// PrepareData:  1. Add one org node "systemAssociate" for system dimension Un/Associate 
            ///               2. Add one site node "AddCalendarProperty" for hierarchy calendar property setting 
            /// </summary> 
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

        [Test]
        [CaseID("TC-J1-SmokeTest-001-002")]
        [Priority("13")]
        [Type(ScriptType.BVT)]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(HierarchyManagementSuite), "TC-J1-SmokeTest-001-002")]
        public void AddBuildingNodeTest(HierarchyData input)
        {
            /// <summary>
            /// PrepareData:  1. Add one building node "AddPeopleProperty" for hierarchy cost&peoplearea property
            /// </summary> 
            HierarchySettings.ExpandNode("自动化测试");
            HierarchySettings.FillInHierarchyNode("AddCalendarProperty", input.InputData);
            
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
