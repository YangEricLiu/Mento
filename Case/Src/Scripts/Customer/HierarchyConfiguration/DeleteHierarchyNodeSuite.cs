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
        private AssociateSettings AssociateSettings = JazzFunction.AssociateSettings;
        private static AreaDimensionSettings AreaSettings = JazzFunction.AreaDimensionSettings;
        private static SystemDimensionSettings SystemSettings = JazzFunction.SystemDimensionSettings;

        [SetUp]
        public void CaseSetUp()
        {
            HierarchySettings.NavigatorToHierarchySetting();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.LoginPage.RefreshJazz("自动化测试");
            TimeManager.LongPause();
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
            TimeManager.LongPause();

            //Verify that message box popup for confirm delete
            string msgText = HierarchySettings.GetMessageText();

            //因为双引号的写法不一样，因此在判断字符比较的时候，会认为不相等，中文输入法和英文输入法下的双引号不一致问题，是框架解析的问题，需要日后解决
            //Assert.IsTrue(msgText.Contains(input.ExpectedData.Messages[0]));
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Messages[1]));
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
            string[] Messages = { "无法删除层级节点\"DeleteSite001\"。请先删除该节点下的所有子节点。", "删除层级节点\"DeleteBuilding001\"吗？您将同时删除层级节点下所有的信息和仪表盘。", "删除层级节点\"DeleteSite001\"吗？您将同时删除层级节点下所有的信息和仪表盘。" };

            //Select one leaf node
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for confirm delete
            string msgText = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText.Contains(Messages[0]));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmCreateOKMagBox();
            TimeManager.LongPause();

            //delete child node then delete it again
            HierarchySettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for confirm delete
            string msgText2 = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText2.Contains(Messages[1]));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmErrorMsgBox();
            TimeManager.LongPause();

            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for confirm delete
            string msgText3 = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText3.Contains(Messages[2]));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmErrorMsgBox();
            TimeManager.LongPause();

            //Verify the node has been deleted
            Assert.IsFalse(HierarchySettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Delete-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(DeleteHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Delete-101-2")]
        public void DeleteNodeWithTags(HierarchyData input)
        {
            string[] Messages = { "无法删除层级节点\"OrgWithTags001\"。请先删除该节点下的所有数据点关联关系。", "删除层级节点\"OrgWithTags001\"吗？您将同时删除层级节点下所有的信息和仪表盘。"};

            //Select one leaf node
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for can't delete
            string msgText = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText.Contains(Messages[0]));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmCreateOKMagBox();
            TimeManager.ShortPause();

            //Disassociated tags then delete it again
            AssociateSettings.NavigateToHierarchyAssociate();
            TimeManager.ShortPause();

            AssociateSettings.FocusOnTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();
            AssociateSettings.ClickDisassociateButton(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            AssociateSettings.FocusOnTag(input.InputData.TagNames[1]);
            TimeManager.ShortPause();
            AssociateSettings.ClickDisassociateButton(input.InputData.TagNames[1]);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            HierarchySettings.NavigatorToHierarchySetting();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for can't delete
            string msgText1 = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText1.Contains(Messages[1]));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmErrorMsgBox();
            TimeManager.ShortPause();

            //Verify the node has been deleted
            Assert.IsFalse(HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath));
            
            //verify the associated tags are on disassociated list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
            Assert.IsFalse(JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath));
            JazzFunction.AssociateSettings.SelectHierarchyNode(input.ExpectedData.HierarchyNodePath[0]);
            //.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.AssociateSettings.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagNames[0]));
            Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagNames[1]));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Delete-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(DeleteHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Delete-101-3")]
        public void DeleteHnodeAssociatedDimensionNode(HierarchyData input)
        {
            string[] Messages = { "无法删除层级节点\"DeleteBuilding004\"。请先删除该节点下的所有维度结构。", "删除层级节点\"DeleteBuilding004\"吗？您将同时删除层级节点下所有的信息和仪表盘。", "无法删除层级节点\"DeleteSite004\"。请先删除该节点下的所有维度结构", "删除层级节点\"DeleteSite004\"吗？您将同时删除层级节点下所有的信息和仪表盘。" };

            //Select one leaf node which associated to area
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();
            TimeManager.MediumPause();

            //Verify that message box popup for can't delete
            string msgText = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText.Contains(Messages[0]));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmCreateOKMagBox();
            TimeManager.ShortPause();

            //Delete area node then delete
            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.MediumPause();

            //Click "删除" button and "确认"
            AreaSettings.ClickDeleteButton();
            TimeManager.MediumPause();
            AreaSettings.ConfirmErrorMsgBox();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            HierarchySettings.NavigatorToHierarchySettingHierarchy();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for can't delete
            string msgText1 = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText1.Contains(Messages[1]));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmErrorMsgBox();
            TimeManager.ShortPause();

            //delete node which associate with  system dimension
            //Select one leaf node which associated to area
            HierarchySettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for can't delete
            string msgText2 = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText2.Contains(Messages[2]));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmCreateOKMagBox();
            TimeManager.ShortPause();

            SystemSettings.NavigateToSystemDimension();
            TimeManager.LongPause();

            SystemSettings.ShowSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //2.disassociate system dimension node
            SystemSettings.ExpandDialogSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            SystemSettings.UncheckSystemDimensionNodeWithoutConfirm(input.InputData.SystemDimensionItemPath.Last());
            JazzMessageBox.LoadingMask.WaitLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Message box popup and confirm it
            JazzMessageBox.MessageBox.Delete();
            TimeManager.ShortPause();

            SystemSettings.ConfirmSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //delete hierarchy node again
            HierarchySettings.NavigatorToHierarchySettingHierarchy();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for can't delete
            string msgText3 = HierarchySettings.GetMessageText();
            Assert.IsTrue(msgText3.Contains(Messages[3]));
            TimeManager.ShortPause();

            //confirm message box
            HierarchySettings.ConfirmErrorMsgBox();
            TimeManager.ShortPause();

            //Verify the node has been deleted
            Assert.IsFalse(HierarchySettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath));
        }
    }
}
