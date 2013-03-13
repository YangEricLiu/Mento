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
    [ManualCaseID("TC-J1-FVT-Hierarchy-001")]
    public class AddInvalidHierarhcyNodeSuite : TestCaseAttribute
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
        [CaseID("Hierarchy-001-AddInvalidInput")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(HierarchyData[]))]
        public void AddInvalidInput(HierarchyData input)
        {
            //Add organization and site node to "自动化测试"
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickCreateChildHierarchyButton();
            HierarchySettings.FillInHierarchyNode(input.InputData);

            //Click "Save" button
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify that the error message popup and the input field is invalid
            Assert.IsTrue(HierarchySettings.IsNameInvalid());
            Assert.IsTrue(HierarchySettings.IsNameInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(HierarchySettings.IsCodeInvalid());
            Assert.IsTrue(HierarchySettings.IsCodeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(HierarchySettings.IsTypeInvalid());
            Assert.IsTrue(HierarchySettings.IsTypeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(HierarchySettings.IsCommentsInvalid(input.ExpectedData));
            Assert.IsTrue(HierarchySettings.IsCommentsInvalidMsgCorrect(input.ExpectedData));
        }
    }
}
