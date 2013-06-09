using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using System.IO;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Greenie")]
    [CreateTime("2013-06-08")]
    [ManualCaseID("TC-J1-FVT-VtagConfiguration-Delete-001")]
    public class DeleteVtagSuite : TestSuiteBase
    {
        private VTagSettings VTagSettings = JazzFunction.VTagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            VTagSettings.NavigatorToVTagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Delete-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(DeleteVtagSuite), "TC-J1-FVT-VtagConfiguration-Delete-001-1")]
        public void DeleteVtagThenCancel(VtagData input)
        {
            //Select the vtag
            VTagSettings.FocusOnVTagByName(input.InputData.CommonName);

            //Click "Delete" button
            VTagSettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for confirm delete
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));

            //Click "Cancel" button
            JazzMessageBox.MessageBox.Cancel();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsTrue(VTagSettings.IsModifyButtonDisplayed());
            Assert.IsTrue(VTagSettings.IsDeleteButtonDisplayed());

            //Verify that vtag not deleted
            Assert.IsTrue(VTagSettings.FocusOnVTagByName(input.InputData.CommonName));
        }


        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Delete-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(DeleteVtagSuite), "TC-J1-FVT-VtagConfiguration-Delete-101-1")]
        public void DeleteVtagAndVerify(VtagData input)
        {

            /*
            //Select the vtag
           VTagSettings.FocusOnVTagByName(input.InputData.CommonName);

            //Click "Delete" button
            VTagSettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for confirm delete
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));

            //Click "Confirm" button
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify delete successful
            Assert.IsFalse(VTagSettings.IsModifyButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsDeleteButtonDisplayed());

            //1. Verify that Vtag is deleted from Vtag list
            Assert.IsFalse(VTagSettings.FocusOnVTagByName(input.InputData.CommonName));
            */

            //3. Verify vtag is deleted from associated tag list

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
            JazzFunction.AreaDimensionSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            JazzFunction.AreaDimensionSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            //JazzFunction.AreaDimensionSettings.ExpandAreaDimensionNodePath(input.ExpectedData.AreaNodePath);
            
            JazzFunction.AreaDimensionSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath);
            TimeManager.MediumPause();
            Assert.IsFalse(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.ExpectedData.CommonName));

            /*
            //2. Verify Vtag is deleted from formula tag list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzFunction.VTagSettings.FocusOnVTagByName(vtagName);
            JazzFunction.VTagSettings.SwitchToFormulaTab();
            JazzFunction.VTagSettings.ClickModifyFormulaButton();
            Assert.IsFalse(JazzFunction.VTagSettings.IsTagNameOnFormulaTagList(input.ExpectedData.CommonName));
            
            //3. Verify vtag is deleted from associated tag list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
            JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            Assert.IsFalse(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.ExpectedData.CommonName));

            //4. Verify ptag is deleted from energy analysis tag list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);
            TimeManager.ShortPause();
            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.ExpectedData.CommonName));
             */

        }

        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Delete-001-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(DeleteVtagSuite), "TC-J1-FVT-VtagConfiguration-Delete-001-2")]
        public void DeleteVtagUsedByOther(VtagData input)
        {
            //Select the vtag
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);

            //Click "Delete" button
            VTagSettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for confirm delete
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.MessageArray[0]));

            //Click "Confirm" button
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            string msgText2 = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText2.Contains(input.ExpectedData.MessageArray[1]));

            
        }

    }     
}
