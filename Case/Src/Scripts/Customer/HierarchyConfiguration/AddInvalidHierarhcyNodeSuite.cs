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
    [CreateTime("2013-03-15")]
    [ManualCaseID("TC-J1-FVT-Hierarchy-Add-001")]
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
        [CaseID("TC-J1-FVT-Hierarchy-Add-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddInvalidHierarhcyNodeSuite), "TC-J1-FVT-Hierarchy-Add-001-1")]
        public void AddHierarchyCancel(HierarchyData input)
        {
            //Add organization and site node to "自动化测试"
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickCreateChildHierarchyButton();
            HierarchySettings.FillInHierarchyNode(input.InputData);

            //Click "Cancel" button
            TimeManager.MediumPause();
            HierarchySettings.ClickCancelButton();
            TimeManager.ShortPause();

            //veirify that no "save" and "cancel" button
            Assert.IsFalse(HierarchySettings.IsCancelButtonDisplayed());
            Assert.IsFalse(HierarchySettings.IsSaveButtonDisplayed());

            //Verify nodes are not added as children
            Assert.IsFalse(HierarchySettings.IsNodesChildParent(input.InputData.CommonName, input.InputData.HierarchyNodePath.Last()));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Add-001-2")]
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
            Assert.IsTrue(HierarchySettings.IscodeInvalid());
            Assert.IsTrue(HierarchySettings.IscodeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(HierarchySettings.IsCommentsInvalid());
            Assert.IsTrue(HierarchySettings.IsCommentsInvalidMsgCorrect(input.ExpectedData));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Add-001-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddInvalidHierarhcyNodeSuite), "TC-J1-FVT-Hierarchy-Add-001-3")]
        public void AddSamecode(HierarchyData input)
        {
            //xxx
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickCreateChildHierarchyButton();
            HierarchySettings.FillInHierarchyNode(input.InputData);

            //Click "Save" button
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            Assert.IsTrue(HierarchySettings.IscodeInvalid());
            Assert.IsTrue(HierarchySettings.IscodeInvalidMsgCorrect(input.ExpectedData));

            //Verify nodes are not added as children
            Assert.IsFalse(HierarchySettings.IsNodesChildParent(input.InputData.CommonName, input.InputData.HierarchyNodePath.Last()));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Add-001-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddInvalidHierarhcyNodeSuite), "TC-J1-FVT-Hierarchy-Add-001-4")]
        public void SameNameOnlevel(HierarchyData input)
        {
            //Add same name 
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();
            HierarchySettings.ClickCreateChildHierarchyButton();
            TimeManager.ShortPause();
            HierarchySettings.FillInHierarchyNode(input.InputData);
            TimeManager.ShortPause();

            //Click "Save" button
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            Assert.IsTrue(HierarchySettings.IsNameInvalid());
            Assert.IsTrue(HierarchySettings.IsNameInvalidMsgCorrect(input.ExpectedData));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Add-001-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(AddInvalidHierarhcyNodeSuite), "TC-J1-FVT-Hierarchy-Add-001-5")]
        public void EmptyField(HierarchyData input)
        {
            //Add organization and site node to "自动化测试"
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickCreateChildHierarchyButton();

            //Input nothing and click "Save" button
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify that the error message popup and the input field is invalid
            Assert.IsTrue(HierarchySettings.IsNameInvalid());
            Assert.IsTrue(HierarchySettings.IsNameInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(HierarchySettings.IscodeInvalid());
            Assert.IsTrue(HierarchySettings.IscodeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(HierarchySettings.IsTypeInvalid());
            Assert.IsTrue(HierarchySettings.IsTypeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsFalse(HierarchySettings.IsCommentsInvalid());
        }
    }
}
