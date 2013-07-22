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
    [Owner("Hardy")]
    [CreateTime("2013-07-22")]
    [ManualCaseID("TC-J1-FVT-TagAssociation-Disassociate")]
    public class DisassociateTagSuite : TestSuiteBase
    {
        private static AssociateSettings Association = JazzFunction.AssociateSettings;
        private static AreaDimensionSettings AreaSettings = JazzFunction.AreaDimensionSettings;
        private static SystemDimensionSettings SystemSettings = JazzFunction.SystemDimensionSettings;

        [SetUp]
        public void CaseSetUp()
        {
            Association.NavigateToHierarchyAssociate();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private void AssociateOnWhichNode(AssociateTagData input)
        {
            Association.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
        }

        private void CheckEVOnWhichNode(AssociateTagData input)
        {
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            if (input.InputData.SystemDimensionPath != null)
            {
                //Navigate to systemdimension
                //JazzFunction.EnergyAnalysisPanel.
                SystemSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);
            }

            if (input.InputData.AreaDimensionPath != null)
            {
                //Navigate to areadimension
                Association.NavigateToAreaDimensionAssociate();
                AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaDimensionPath);
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Disassociate-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(DisassociateTagSuite), "TC-J1-FVT-TagAssociation-Disassociate-101-1")]
        public void DisassociateTagVerify(AssociateTagData input)
        {
            //navigate and select node
            AssociateOnWhichNode(input);

            //Navigate to system dimension node and disassociate ptag 
            JazzFunction.DisassociateSettings.FocusOnTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            Association.ClickDisassociateButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(Association.IsTagOnAssociatedGridView(input.ExpectedData.TagName));

            Association.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Association.CheckedTag(input.ExpectedData.TagName);
            Assert.IsTrue(Association.IsTagChecked(input.ExpectedData.TagName));

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.ExpectedData.TagName));
      
        }
    }
}
