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
        public void DeleteLeafNode(HierarchyData input)
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

            if (null != input.ExpectedData.ErrorMessage)
            {
                //Verify that message box popup for confirm delete
                msgText = HierarchySettings.GetMessageText();
                Assert.IsTrue(msgText.Contains(input.ExpectedData.ErrorMessage));
                TimeManager.ShortPause();

                //confirm message box
                HierarchySettings.ConfirmErrorMsgBox();

                //Verify the node not be deleted
                Assert.IsTrue(HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath));
            }
            else
            {
                //Verify the node has been deleted
                Assert.IsFalse(HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath));
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Delete-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(DeleteHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Delete-101-2")]
        public void DeleteNodeWithTags(HierarchyData input)
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

            //Verify the node has been deleted
            Assert.IsFalse(HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath));
        }
    }
}
