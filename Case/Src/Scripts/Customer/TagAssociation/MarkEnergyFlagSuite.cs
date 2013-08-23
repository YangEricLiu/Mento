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
    [CreateTime("2013-08-22")]
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
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-MarkEnergyFlag-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(MarkEnergyFlagSuite), "TC-J1-FVT-TagAssociation-MarkEnergyFlag-101-1")]
        public void NoSupportMarkedNode(AssociateTagData input)
        {
            //Select a Non-building node(CustomerNode, OrgNode, SiteNode), then select an associated tag
            AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            //Select system dimension or area dimension of a Non-building node(CustomerNode, OrgNode, SiteNode), then select an associated tag
            AssociateSettings.FocusOnVTagByName(input.InputData.TagName);
            //There is no light displayed for all tags (Ptag/Vtag) under the non-building node, so they can't be marked as energy consumption tag.
            Assert.IsTrue(AssociateSettings.IsTagLighteNotExist(input.InputData.TagNames[0]));
            //Select system dimension or area dimension of a Non-building node(CustomerNode, OrgNode, SiteNode), then select an associated tag.
            AssociateSettings.NavigateToAreaDimensionAssociate();
            AreaNodeSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);

        }
    }
}
