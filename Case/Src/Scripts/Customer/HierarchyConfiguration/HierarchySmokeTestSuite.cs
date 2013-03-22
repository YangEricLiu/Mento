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
using Mento.TestApi.TestData.Attribute;


namespace Mento.Script.Customer.HierarchyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2012-10-30")]
    [ManualCaseID("TC-J1-SmokeTest-001")]
    public class HierarchySmokeTestSuite : TestSuiteBase
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

        /// <summary>
        /// PrepareData:  1. Add one org node "systemAssociate" for system dimension Un/Associate 
        ///               2. Add one site node "AddCalendarProperty" for hierarchy calendar property setting 
        ///               3. Add one building node "AddPeopleProperty" for hierarchy cost&peoplearea property
        /// </summary> 
        ///
        [Test]
        [CaseID("TC-J1-SmokeTest-Hierarchy-001")]
        [Priority("12")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(HierarchySmokeTestSuite), "TC-J1-SmokeTest-Hierarchy-001")]
        public void SmokeTestAddHierarchyNode(HierarchyData input)
        {
            //Add organization and site node to "自动化测试"
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickCreateChildHierarchyButton();
            HierarchySettings.FillInHierarchyNode(input.InputData);
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify that the "添加成功" message box popup, other is failed
            string msgText = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmCreateOKMagBox();

            //Verify nodes are added as children
            Assert.IsTrue(HierarchySettings.IsNodesChildParent(input.InputData.CommonName, input.InputData.HierarchyNodePath.Last()));
            HierarchySettings.SelectHierarchyNode(input.InputData.CommonName);
            Assert.AreEqual(input.ExpectedData.CommonName, HierarchySettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Code, HierarchySettings.GetCodeValue());
            Assert.AreEqual(HierarchySettings.GetTypeExpectedValue(input.ExpectedData.Type), HierarchySettings.GetTypeValue());
            Assert.AreEqual(input.ExpectedData.Comments, HierarchySettings.GetCommentValue());
        }

    }
}
