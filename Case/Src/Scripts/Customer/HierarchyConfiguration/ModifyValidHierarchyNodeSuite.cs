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
    [CreateTime("2013-03-18")]
    [ManualCaseID("TC-J1-FVT-Hierarchy-Modify-101")]
    public class ModifyValidHierarchyNodeSuite : TestSuiteBase
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
            HierarchySettings.NavigatorToNonHierarchy();
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Modify-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(ModifyValidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Modify-101-1")]
        public void ModifyRootNode(HierarchyData input)
        {
            //Select root node "自动化测试"
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickModifyButton();

            //Verify "Name", "code" and "Type" field is disabled, only "Comment" field is enabled
            Assert.IsFalse(HierarchySettings.IsNameFieldEnabled());
            Assert.IsFalse(HierarchySettings.IscodeFieldEnabled());
            Assert.IsFalse(HierarchySettings.IsTypeFieldEnabled());
            Assert.IsTrue(HierarchySettings.IsCommentFieldEnabled());

            //Modify the comments for root node and save
            HierarchySettings.FillInComment(input.InputData.Comments);

            //Click "Save" button
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify the root node comments can be edited and saved
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            Assert.AreEqual(input.ExpectedData.Comments, HierarchySettings.GetCommentValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Modify-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(ModifyValidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Modify-101-2")]
        public void ModifyValidNode(HierarchyData input)
        {
            //Select the node which need to modify
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickModifyButton();

            //Verify "Type" field is disabled
            Assert.IsFalse(HierarchySettings.IsTypeFieldEnabled());
            HierarchySettings.FillInHierarchyNode(input.InputData);

            //Click "Save" button
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify nodes are modified correctly
            Assert.AreEqual(input.ExpectedData.CommonName, HierarchySettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Code, HierarchySettings.GetcodeValue());
            Assert.AreEqual(input.ExpectedData.Comments, HierarchySettings.GetCommentValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Modify-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(ModifyValidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Modify-101-3")]
        public void ModifyWithoutChange(HierarchyData input)
        {
            //Select the node which need to modify
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickModifyButton();

            //Type can't be modified
            Assert.IsFalse(HierarchySettings.IsTypeFieldEnabled());

            //Click "Save" button
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify nodes are same
            Assert.AreEqual(input.ExpectedData.CommonName, HierarchySettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Code, HierarchySettings.GetcodeValue());
            Assert.AreEqual(input.ExpectedData.Comments, HierarchySettings.GetCommentValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Modify-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(ModifyValidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Modify-101-4")]
        public void EmptyItemNotDisplay(HierarchyData input)
        {
            //Select root node and add node without comments 
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Verify that before clear comments, it is displayed
            Assert.IsFalse(HierarchySettings.IsCommentHidden());

            HierarchySettings.ClickModifyButton();
            HierarchySettings.FillInHierarchyNode(input.InputData);

            //Click "Save" button
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify the comments not display
            Assert.IsFalse(HierarchySettings.IsCommentsDisplayed());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Modify-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(ModifyValidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Modify-101-5")]
        public void ModifyValidAndVerify(HierarchyData input)
        {
            //Select the node which need to modify
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickModifyButton();
            HierarchySettings.FillInHierarchyNode(input.InputData);

            //Click "Save" button
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            //veirify that no "save" and "cancel" button
            Assert.IsFalse(HierarchySettings.IsCancelButtonDisplayed());
            Assert.IsFalse(HierarchySettings.IsSaveButtonDisplayed());

            //Verify nodes are modified correctly
            Assert.AreEqual(input.ExpectedData.CommonName, HierarchySettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Code, HierarchySettings.GetcodeValue());
            Assert.AreEqual(input.ExpectedData.Comments, HierarchySettings.GetCommentValue());

            //Verify hierarchy node has been modified correctly everywhere
            //1. verify on system dimension configration
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzFunction.SystemDimensionSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            JazzFunction.SystemDimensionSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);

            //2. verify on area dimension configration
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzFunction.AreaDimensionSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            JazzFunction.AreaDimensionSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);

            //3. verify on hierarchy for data association
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
            JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);

            //4. verify on system dimension for data association
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationSystemDimension);
            JazzFunction.SystemDimensionSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            JazzFunction.SystemDimensionSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);

            //5. verify on system dimension for data association
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
            JazzFunction.AreaDimensionSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            JazzFunction.AreaDimensionSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);

            //6. verify on energy analysis on energy view
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);
        }
    }
}
