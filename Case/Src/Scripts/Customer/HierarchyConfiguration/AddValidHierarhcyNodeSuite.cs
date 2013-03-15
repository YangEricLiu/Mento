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
    [ManualCaseID("TC-J1-FVT-Hierarchy-Add-101")]
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
        [CaseID("TC-J1-FVT-Hierarchy-Add-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddValidHierarhcyNodeSuite), "TC-J1-FVT-Hierarchy-Add-101-1")]
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

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Add-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddValidHierarhcyNodeSuite), "TC-J1-FVT-Hierarchy-Add-101-2")]
        public void HierarchyType(HierarchyData input)
        {
            //Select buidling node
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Verify the child button is disable
            Assert.IsFalse(HierarchySettings.IsChildButtonEnable());

            //Select site node and click "childlevel" button
            HierarchySettings.SelectHierarchyNode(input.InputData.HierarchyNodePath[1]);
            HierarchySettings.ClickCreateChildHierarchyButton();
            
            //Verify the type list not contain "org" and "site"
            Assert.IsFalse(HierarchySettings.IsTypeContainsOrgnization());
            Assert.IsFalse(HierarchySettings.IsTypeContainsSite());

            //Select orgnization node and click "childlevel" button
            HierarchySettings.SelectHierarchyNode(input.InputData.HierarchyNodePath[0]);
            HierarchySettings.ClickCreateChildHierarchyButton();

            //Verify the type list not contain "building"
            Assert.IsFalse(HierarchySettings.IsTypeContainsBuilding());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Add-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddValidHierarhcyNodeSuite), "TC-J1-FVT-Hierarchy-Add-101-4")]
        public void EmptyItemNotDisplay(HierarchyData input)
        {
            //Select root node and add node without comments 
            HierarchySettings.SelectHierarchyNode(input.InputData.HierarchyNodePath[0]);
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

            //Verify the comments not display
            Assert.IsTrue(HierarchySettings.IsCommentHidden());
        }
    }
}
