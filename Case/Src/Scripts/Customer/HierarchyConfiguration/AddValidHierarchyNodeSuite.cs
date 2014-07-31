
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
    public class AddValidHierarchyNodeSuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;

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
            HierarchySettings.NavigatorToNonHierarchy();
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Add-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddValidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Add-101-1")]
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

            //veirify that no "save" and "cancel" button
            Assert.IsFalse(HierarchySettings.IsCancelButtonDisplayed());
            Assert.IsFalse(HierarchySettings.IsSaveButtonDisplayed());

            //Verify nodes are added as children
            //Assert.IsTrue(HierarchySettings.IsNodesChildParent(input.ExpectedData.CommonName, input.InputData.HierarchyNodePath.Last()));
            //HierarchySettings.SelectHierarchyNode(input.ExpectedData.CommonName);
            Assert.AreEqual(input.ExpectedData.CommonName, HierarchySettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Code, HierarchySettings.GetcodeValue());
            Assert.AreEqual(HierarchySettings.GetTypeExpectedValue(input.ExpectedData.Type), HierarchySettings.GetTypeValue());
            Assert.AreEqual(input.ExpectedData.Comments, HierarchySettings.GetCommentValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Add-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddValidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Add-101-2")]
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
            Assert.IsTrue(HierarchySettings.IsTypeContainsBuilding());

            //Select orgnization node and click "childlevel" button
            HierarchySettings.SelectHierarchyNode(input.InputData.HierarchyNodePath[0]);
            HierarchySettings.ClickCreateChildHierarchyButton();

            //Verify the type list not contain "building"
            Assert.IsFalse(HierarchySettings.IsTypeContainsBuilding());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Add-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddValidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Add-101-3")]
        public void AddFiveOrgnization(HierarchyData input)
        {
            int hierarchyLength = input.InputData.HierarchyNodePath.Length;

            for (int i = 0; i < (hierarchyLength - 1); i++)
            {
                HierarchySettings.SelectHierarchyNode(input.InputData.HierarchyNodePath[i]);
                HierarchySettings.ClickCreateChildHierarchyButton();
                HierarchySettings.FillInName(input.InputData.HierarchyNodePath[i + 1]);
                HierarchySettings.FillIncode(input.InputData.HierarchyNodePath[i + 1]);
                HierarchySettings.FillInType(input.InputData.Type);

                Assert.IsTrue(HierarchySettings.IsTypeContainsOrgnization());
                Assert.IsTrue(HierarchySettings.IsTypeContainsSite());
                Assert.IsTrue(HierarchySettings.IsTypeContainsBuilding());

                //Click "Save" button
                TimeManager.MediumPause();
                HierarchySettings.ClickSaveButton();
                TimeManager.ShortPause();

                //confirm message box
                //HierarchySettings.ConfirmCreateOKMagBox();
                TimeManager.LongPause();
            }

            //Click the level 5 orgnization
            HierarchySettings.SelectHierarchyNode(input.InputData.HierarchyNodePath.Last());
            HierarchySettings.ClickCreateChildHierarchyButton();
            TimeManager.MediumPause();

            //Verify the type list not contain "org", only "site", "building"
            Assert.IsFalse(HierarchySettings.IsTypeContainsOrgnization());
            Assert.IsTrue(HierarchySettings.IsTypeContainsSite());
            Assert.IsTrue(HierarchySettings.IsTypeContainsBuilding());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Add-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddValidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Add-101-4")]
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

            //Verify the comments and picture not display
            Assert.IsTrue(HierarchySettings.IsCommentHidden());
            Assert.IsTrue(HierarchySettings.IsPictureHidden());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Add-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddValidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Add-101-5")]
        public void AddValidAndVerify(HierarchyData input)
        {
            //Add organization to "自动化测试"
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickCreateChildHierarchyButton();
            HierarchySettings.FillInHierarchyNode(input.InputData);

            //Click "Save" button
            TimeManager.ShortPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify hierarchy node has been added correctly everywhere
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
