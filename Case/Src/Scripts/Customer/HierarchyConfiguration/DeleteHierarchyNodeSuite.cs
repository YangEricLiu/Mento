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
    [CreateTime("2013-03-19")]
    [ManualCaseID("TC-J1-FVT-Hierarchy-001")]
    public class DeleteHierarchyNodeSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-Hierarchy-Delete-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(DeleteHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Delete-001-1")]
        public void DeleteRootNode(HierarchyData input)
        {
            //Select root node
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Verify "Delete" button is disabled
            Assert.IsFalse(HierarchySettings.IsDeleteButtonEnabled());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Delete-001-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(DeleteHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Delete-001-2")]
        public void DeleteThenCancel(HierarchyData input)
        {
            //Select one leaf node
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();

            //Verify that message box popup for confirm delete
            string msgText = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.CancelErrorMsgBox();

            //Verify the node not be deleted
            Assert.IsTrue(HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Delete-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(DeleteHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Delete-101-1")]
        public void DeleteLeafAndNonLeafNode(HierarchyData input)
        {
            //Select one leaf node
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();

            //Verify that message box popup for confirm delete
            string msgText = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmErrorMsgBox();
            TimeManager.ShortPause();

            //Verify the node has been deleted
            Assert.IsFalse(HierarchySettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Delete-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(DeleteHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Delete-101-2")]
        public void DeleteNodeWithTags(HierarchyData input)
        {
            string tag1 = "Ptag_OrgWithTags_Delete001";
            string tag2 = "Vtag_OrgWithTags_Delete001";

            //Select one leaf node
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();

            //Verify that message box popup for confirm delete
            string msgText = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmErrorMsgBox();

            //Verify the node has been deleted
            Assert.IsFalse(HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath));

            //verify the associated tags are on disassociated list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
            Assert.IsFalse(JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath));
            JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            JazzFunction.AssociateSettings.ClickAssociateButton();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(tag1));
            Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(tag2));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Delete-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(DeleteHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Delete-101-3")]
        public void DeleteNodeAndVerify(HierarchyData input)
        {

            //Select one leaf node
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();

            //Verify that message box popup for confirm delete
            string msgText = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmErrorMsgBox();

            //1. Verify the node has been deleted
            Assert.IsFalse(HierarchySettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath));

            //2. refresh the page and verify the node has been deleted
            JazzFunction.Navigator.NavigateHome();
            HierarchySettings.NavigatorToHierarchySetting();
            Assert.IsFalse(HierarchySettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath));

            //3. verify the the node has been deleted on associated tag page
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
            Assert.IsFalse(JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath));

            //4. verify the node has been deleted on energy view page
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Delete-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(DeleteHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Delete-101-4")]
        public void DeleteParentNodewithChildNodeTags(HierarchyData input)
        {
            string tag1 = "Ptag_OrgWithTags_Delete002";
            string tag2 = "Vtag_OrgWithTags_Delete002";

            //Select one leaf node
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();

            //Verify that message box popup for confirm delete
            string msgText = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmErrorMsgBox();

            //Verify the node has been deleted
            Assert.IsFalse(HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath));

            //verify the associated tags are on disassociated list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
            Assert.IsFalse(JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath));
            JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            JazzFunction.AssociateSettings.ClickAssociateButton();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(tag1));
            Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(tag2));
        }
    }
}
