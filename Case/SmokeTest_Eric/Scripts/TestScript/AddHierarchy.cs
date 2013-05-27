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

namespace Mento.Script.TestScript.HierarchyConfiguration
{
    [TestFixture]
    [Owner("Eric")]
    [CreateTime("2013-05-10")]
    [ManualCaseID("TA-Smoke-Hierarchy-001")]
    public class AddValidHierarchyNodeSuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzBrowseManager.RefreshJazz();
            JazzFunction.LoginPage.SelectCustomer("Auto_Customer");

            HierarchySettings.NavigatorToHierarchySetting();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        [TearDown]
        public void CaseTearDown()
        {
            
        }

        [Test]
        [CaseID("TA-Smoke-Hierarchy-001-001")]
        [Owner("Eric")]
        [MultipleTestDataSource(typeof(HierarchyDataTree[]), typeof(AddValidHierarchyNodeSuite), "TA-Smoke-Hierarchy-001-001")]
        public void AddThreeOrgnization(HierarchyDataTree inputs)
        {
            int hierarchyLength = inputs.InputData.InList.Length;

            for (int i = 0; i < hierarchyLength; i++)
            {
                HierarchySettings.SelectHierarchyNodePath(inputs.InputData.InList[i].HierarchyNodePath);
                HierarchySettings.ClickCreateChildHierarchyButton();
                HierarchySettings.FillInName(inputs.InputData.InList[i].CommonName);
                HierarchySettings.FillInCode(inputs.InputData.InList[i].Code);
                HierarchySettings.FillInType(inputs.InputData.InList[i].Type);
                HierarchySettings.FillInComment(inputs.InputData.InList[i].Comments);

                //Click "Save" button
                TimeManager.MediumPause();
                HierarchySettings.ClickSaveButton();
                TimeManager.MediumPause();
            }

            //Verify the last nodes is added as child
            Assert.IsTrue(HierarchySettings.IsNodesChildParent(inputs.ExpectedData.CommonName, inputs.InputData.InList[hierarchyLength-1].HierarchyNodePath.Last()));
            HierarchySettings.SelectHierarchyNode(inputs.ExpectedData.CommonName);
            Assert.AreEqual(inputs.ExpectedData.CommonName, HierarchySettings.GetNameValue());
            Assert.AreEqual(inputs.ExpectedData.Code, HierarchySettings.GetCodeValue());
            Assert.AreEqual(HierarchySettings.GetTypeExpectedValue(inputs.ExpectedData.Type), HierarchySettings.GetTypeValue());
            Assert.AreEqual(inputs.ExpectedData.Comments, HierarchySettings.GetCommentValue());
        }

    }
}
