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
    [CreateTime("2013-03-12")]
    [ManualCaseID("TC-J1-FVT-Hierarchy-001")]
    public class AddValidHierarhcyNodeSuite : TestSuiteBase
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
        [CaseID("Hierarchy-001-AddValidNode")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddValidHierarhcyNodeSuite), "Hierarchy-001-AddValidNode")]
        public void AddValidNode(HierarchyData input)
        {
            //Add organization and site node to "自动化测试"
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickCreateChildHierarchyButton();
            HierarchySettings.FillInHierarchyNode(input.InputData);

            //Click "Save" button
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify that the "添加成功" message box popup, other is failed
            string msgText = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText.Contains("添加成功"));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmCreateOKMagBox();

            //Verify nodes are added as children
            Assert.IsTrue(HierarchySettings.IsNodesChildParent(input.ExpectedData.CommonName, input.InputData.HierarchyNodePath.Last()));
            HierarchySettings.SelectHierarchyNode(input.ExpectedData.CommonName);
            Assert.AreEqual(input.ExpectedData.CommonName, HierarchySettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Code, HierarchySettings.GetCodeValue());
            Assert.AreEqual(HierarchySettings.GetTypeExpectedValue(input.ExpectedData.Type), HierarchySettings.GetTypeValue());
            Assert.AreEqual(input.ExpectedData.Comments, HierarchySettings.GetCommentValue());
        }
    }
}
