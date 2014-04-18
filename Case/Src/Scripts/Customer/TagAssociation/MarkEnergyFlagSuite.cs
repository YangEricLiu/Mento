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
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagAssociation
{
    [TestFixture]
    [Owner("Greenie")]
    [CreateTime("2013-08-23")]
    [ManualCaseID("TC-J1-FVT-TagAssociation-MarkEnergyFlag")]
    public class MarkEnergyFlagSuite : TestSuiteBase
    {
        private AssociateSettings AssociateSettings = JazzFunction.AssociateSettings;
        private static AreaDimensionSettings AreaNodeSettings = JazzFunction.AreaDimensionSettings;
        private static SystemDimensionSettings SystemNodeSettings = JazzFunction.SystemDimensionSettings;

        [SetUp]
        public void CaseSetUp()
        {
            AssociateSettings.NavigateToHierarchyAssociate();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            AssociateSettings.NavigateToNonAssociate();
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-MarkEnergyFlag-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(MarkEnergyFlagSuite), "TC-J1-FVT-TagAssociation-MarkEnergyFlag-101-1")]
        public void NoSupportMarkedNode(AssociateTagData input)
        {
            //Select a Non-building node(CustomerNode, OrgNode, SiteNode), then select an associated tag
            AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AssociateSettings.FocusOnVTagByName(input.InputData.TagNames[0]);
            //There is no light displayed for all tags (Ptag/Vtag) under the non-building node, so they can't be marked as energy consumption tag.
            //
            Assert.IsTrue(AssociateSettings.NoLight(input.InputData.TagNames[0]));
           
            //Select system dimension or area dimension of a Non-building node(CustomerNode, OrgNode, SiteNode), then select an associated tag.
            AssociateSettings.NavigateToSystemDimensionAssociate();
            SystemNodeSettings.ShowHierarchyTree();
            SystemNodeSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemNodeSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);
            AssociateSettings.FocusOnVTagByName(input.InputData.TagNames[1]);
            //  this method not finish 
            Assert.IsTrue(AssociateSettings.NoLight(input.InputData.TagNames[1]));
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-MarkEnergyFlag-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(MarkEnergyFlagSuite), "TC-J1-FVT-TagAssociation-MarkEnergyFlag-101-2")]
        public void MarkedElectricTags(AssociateTagData input)
        {
            //Select a building node, then select an associated tag 
            AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AssociateSettings.FocusOnVTagByName(input.InputData.TagNames[0]);
            AssociateSettings.LightenTag(input.InputData.TagNames[0]);
            Assert.IsTrue(AssociateSettings.IsTagLighted(input.InputData.TagNames[0]));
            AssociateSettings.LightenTag(input.InputData.TagNames[1]);

            Assert.AreEqual(JazzMessageBox.MessageBox.GetMessage(),input.InputData.TagName);
            JazzMessageBox.MessageBox.Close();
            TimeManager.ShortPause();
            //Disassociate Ptag1, then light Ptag2 again.
            AssociateSettings.FocusOnVTagByName(input.InputData.TagNames[0]);
            AssociateSettings.ClickDisassociateButton(input.InputData.TagNames[0]);
            AssociateSettings.LightenTag(input.InputData.TagNames[1]);
            Assert.IsTrue(AssociateSettings.IsTagLighted(input.InputData.TagNames[1]));
            //Disassociate Ptag2, then associate Ptag2 to one system dimension node under this building node.
            AssociateSettings.FocusOnVTagByName(input.InputData.TagNames[1]);
            AssociateSettings.ClickDisassociateButton(input.InputData.TagNames[1]);
            AssociateSettings.NavigateToSystemDimensionAssociate();
            //SystemNodeSettings.ShowHierarchyTree();
            //SystemNodeSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemNodeSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);
            AssociateSettings.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            AssociateSettings.CheckedTag(input.InputData.TagNames[1]);
            AssociateSettings.ClickAssociateButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            //The flag turn light if there are no tag whose commodity is electricity is lighted in the same system dimension node.
            AssociateSettings.LightenTag(input.InputData.TagNames[1]);
            Assert.IsTrue(AssociateSettings.IsTagLighted(input.InputData.TagNames[1]));
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-MarkEnergyFlag-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(MarkEnergyFlagSuite), "TC-J1-FVT-TagAssociation-MarkEnergyFlag-101-3")]
        public void MarkedWaterTags(AssociateTagData input)
        {
            //Select one system dimension node under building node  
            AssociateSettings.NavigateToSystemDimensionAssociate();
            SystemNodeSettings.ShowHierarchyTree();
            SystemNodeSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemNodeSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);

            //select a associated Vtag whose commodity is water and light the energy consumption flag.
            AssociateSettings.LightenTag(input.InputData.TagNames[0]);
            Assert.IsTrue(AssociateSettings.IsTagLighted(input.InputData.TagNames[0]));
            //select a associated Vtag whose commodity is water and light the energy consumption flag.
            AssociateSettings.LightenTag(input.InputData.TagNames[1]);
            Assert.AreEqual(JazzMessageBox.MessageBox.GetMessage(), input.InputData.TagName);
            JazzMessageBox.MessageBox.Close();         

        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-MarkEnergyFlag-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(MarkEnergyFlagSuite), "TC-J1-FVT-TagAssociation-MarkEnergyFlag-101-4")]
        public void MarkedTagsSystemOrArea(AssociateTagData input)
        {
            //Find a tag which has been associated with both system dimension and area dimension node, light it separately in two dimensions.
            AssociateSettings.NavigateToAreaDimensionAssociate();
            AreaNodeSettings.ShowHierarchyTree();
            AreaNodeSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaNodeSettings.SelectAreaDimensionNodePath(input.InputData.AreaDimensionPath);
            AssociateSettings.LightenTag(input.InputData.TagName);
            Assert.IsTrue(AssociateSettings.IsTagLighted(input.InputData.TagName));

            AssociateSettings.NavigateToSystemDimensionAssociate();
            SystemNodeSettings.ShowHierarchyTree();
            SystemNodeSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemNodeSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);
            AssociateSettings.LightenTag(input.InputData.TagName);
            Assert.IsTrue(AssociateSettings.IsTagLighted(input.InputData.TagName));

            //Darken the associated tag in the system dimension. Doing nothing to the other dimension.
            //The first energy consumption flag turn dark.
            AssociateSettings.DarkenTag(input.InputData.TagName);
            Assert.IsTrue(AssociateSettings.IsTagLighted(input.InputData.TagName));
            AssociateSettings.FocusOnVTagByName(input.InputData.TagName);
            AssociateSettings.ClickDisassociateButton(input.InputData.TagName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            Assert.IsFalse(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagName));

            //The other energy consumption flag is lighted still.
            AssociateSettings.NavigateToAreaDimensionAssociate();
            AreaNodeSettings.ShowHierarchyTree();
            AreaNodeSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaNodeSettings.SelectAreaDimensionNodePath(input.InputData.AreaDimensionPath);
            Assert.IsTrue(AssociateSettings.IsTagLighted(input.InputData.TagName));
            Assert.IsTrue(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagName));
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-MarkEnergyFlag-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(MarkEnergyFlagSuite), "TC-J1-FVT-TagAssociation-MarkEnergyFlag-101-5")]
        public void ModifyCommodityAndMarked(AssociateTagData input)
        {
            //Under one hierarchy light a tag whose commodity is electricity.Light another tag whose commodity is water.
            AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AssociateSettings.LightenTag(input.InputData.TagNames[0]);
            AssociateSettings.LightenTag(input.InputData.TagNames[1]);
            Assert.IsTrue(AssociateSettings.IsTagLighted(input.InputData.TagNames[0]));
            Assert.IsTrue(AssociateSettings.IsTagLighted(input.InputData.TagNames[1]));
            ///Then modify the second tag(water->electricity).
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
            TimeManager.ShortPause();
            JazzFunction.PTagSettings.FocusOnPTagByName(input.InputData.TagNames[1]);
            JazzFunction.PTagSettings.ClickModifyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.PTagSettings.FillInCommodityAndUom(input.ExpectedData.TagNames[0], input.ExpectedData.TagNames[1]);
            TimeManager.ShortPause();
            JazzFunction.PTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            //Assert.AreEqual(JazzFunction.PTagSettings.GetCommodityValue(),input.InputData.TagName);
            JazzFunction.PTagSettings.IsCommodityInvalidMsgCorrectByCommodity(input.InputData.TagName);
            JazzFunction.PTagSettings.ClickCancelButton();
            TimeManager.ShortPause();
            
        }
    }
}
