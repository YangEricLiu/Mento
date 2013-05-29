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
    [ManualCaseID("TC-J1-FVT-Hierarchy-Modify-001")]
    public class ModifyInvalidHierarchyNodeSuite : TestCaseAttribute
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
        [CaseID("TC-J1-FVT-Hierarchy-Modify-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(ModifyInvalidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Modify-001-1")]
        public void ModifywithSamecode(HierarchyData input)
        {
            //Select the node which want to change
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickModifyButton();
            HierarchySettings.FillInHierarchyNode(input.InputData);

            //Click "Save" button
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            Assert.IsTrue(HierarchySettings.IscodeInvalid());
            Assert.IsTrue(HierarchySettings.IscodeInvalidMsgCorrect(input.ExpectedData.ErrorMessage));

            //Click "Cancel" button
            HierarchySettings.ClickCancelButton();
            TimeManager.ShortPause();

            //Verify that the code is not modified
            Assert.AreEqual(input.ExpectedData.Code, HierarchySettings.GetcodeValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Modify-001-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(ModifyInvalidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Modify-001-2")]
        public void ModifySameNameOnlevel(HierarchyData input)
        {
            //Select the node which want to change
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickModifyButton();
            HierarchySettings.FillInHierarchyNode(input.InputData);

            //Click "Save" button
            TimeManager.MediumPause();
            HierarchySettings.ClickSaveButton();
            TimeManager.ShortPause();

            Assert.IsTrue(HierarchySettings.IsNameInvalid());
            Assert.IsTrue(HierarchySettings.IsNameInvalidMsgCorrect(input.ExpectedData.ErrorMessage));

            //Click "Cancel" button
            HierarchySettings.ClickCancelButton();
            TimeManager.ShortPause();

            //Verify that the name is not modified
            Assert.AreEqual(input.ExpectedData.CommonName, HierarchySettings.GetNameValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Modify-001-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(ModifyInvalidHierarchyNodeSuite), "TC-J1-FVT-Hierarchy-Modify-001-3")]
        public void ModifyThenCancel(HierarchyData input)
        {
            //Select the node which want to change
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            HierarchySettings.ClickModifyButton();
            HierarchySettings.FillInHierarchyNode(input.InputData);

            //Click "Cancel" button
            HierarchySettings.ClickCancelButton();
            TimeManager.ShortPause();

            //veirify that no "save" and "cancel" button,but "modify" and "delete"
            Assert.IsFalse(HierarchySettings.IsCancelButtonDisplayed());
            Assert.IsFalse(HierarchySettings.IsSaveButtonDisplayed());
            Assert.IsTrue(HierarchySettings.IsModifyButtonDisplayed());
            Assert.IsTrue(HierarchySettings.IsDeleteButtonDisplayed());

            //Verify that the code is not modified
            Assert.AreEqual(input.ExpectedData.CommonName, HierarchySettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Code, HierarchySettings.GetcodeValue());
            Assert.AreEqual(input.ExpectedData.Comments, HierarchySettings.GetCommentValue());
        }
    }
}
