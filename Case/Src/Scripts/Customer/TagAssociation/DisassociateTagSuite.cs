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
    [Owner("Emma")]
    [CreateTime("2013-07-11")]
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

            if (input.InputData.SystemDimensionPath != null)
            {
                //Navigate to systemdimension
                Association.NavigateToSystemDimensionAssociate();
                SystemSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);
            }

            if (input.InputData.AreaDimensionPath != null)
            {
                //Navigate to areadimension
                Association.NavigateToAreaDimensionAssociate();
                AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaDimensionPath);
            }       
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
            
            Association.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Do not select tag and click "Cancel" button directly
            Association.ClickCancelButton();
            TimeManager.ShortPause();

            //verify go back to the previous page
            Assert.IsTrue(Association.IsAssociateTagButtonDisplayed());

            //Select 2 tags and cancel
            Association.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Association.CheckedTags(input.InputData.TagNames);
            Association.ClickCancelButton();
            TimeManager.ShortPause();

            //verify go back to the previous page
            Assert.IsTrue(Association.IsAssociateTagButtonDisplayed());
        }
    }
}
