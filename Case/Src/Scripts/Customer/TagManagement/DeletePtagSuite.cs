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
    [Owner("Emma")]
    [CreateTime("2013-05-30")]
    [ManualCaseID("TC-J1-FVT-PtagConfiguration-Delete-001")]
    public class DeletePtagSuite : TestSuiteBase
    {
        private PTagSettings PTagSettings = JazzFunction.PTagSettings;

        [SetUp]
        public void CaseSetUp()
        {   
            PTagSettings.NavigatorToPtagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            PTagSettings.NavigatorToEnergyView();
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Delete-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(DeletePtagSuite), "TC-J1-FVT-PtagConfiguration-Delete-001-1")]
        public void DeletePtagThenCancel(PtagData input)
        {
            //Select the ptag
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);

            //Click "Delete" button
            PTagSettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for confirm delete
            string msgText = JazzMessageBox.MessageBox.GetMessage(); 
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));

            //Click "Cancel" button
            JazzMessageBox.MessageBox.GiveUp();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsTrue(PTagSettings.IsModifyButtonDisplayed());
            Assert.IsTrue(PTagSettings.IsDeleteButtonDisplayed());

            //Verify that ptag not deleted
            Assert.IsTrue(PTagSettings.FocusOnPTagByName(input.InputData.OriginalName));
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Delete-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(DeletePtagSuite), "TC-J1-FVT-PtagConfiguration-Delete-101-1")]
        public void DeletePtagAndVerify(PtagData input)
        {
            string vtagName = "VtagForCheckPtagAll";

            //Select the ptag
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);

            //Click "Delete" button
            PTagSettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for confirm delete
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));

            //Click "Confirm" button
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify delete successful
            Assert.IsFalse(PTagSettings.IsModifyButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsDeleteButtonDisplayed());

            //1. Verify that ptag is deleted from ptag list
            Assert.IsFalse(PTagSettings.FocusOnPTagByName(input.InputData.OriginalName));

            //2. Verify ptag is deleted from formula tag list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzFunction.VTagSettings.FocusOnVTagByName(vtagName);
            JazzFunction.VTagSettings.SwitchToFormulaTab();
            JazzFunction.VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            //
            Assert.IsFalse(JazzFunction.VTagSettings.IsTagNameOnFormulaTagList(input.ExpectedData.CommonName));

            //3. Verify ptag is deleted from associated tag list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.ExpectedData.CommonName));
            
            //4. Verify ptag is deleted from energy analysis tag list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.ExpectedData.CommonName));
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Delete-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(DeletePtagSuite), "TC-J1-FVT-PtagConfiguration-Delete-101-2")]
        public void DeletePtagUsedByCost(PtagData input)
        {
            //Select the ptag
            PTagSettings.FocusOnPTagByName(input.InputData.CommonName);

            //Click "Delete" button
            PTagSettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for confirm delete
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.MessageArray[0]));

            //Click "Confirm" button
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            string msgText2 = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText2.Contains(input.ExpectedData.MessageArray[1]));

            //Click "OK" button
            JazzMessageBox.MessageBox.OK();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify delete failed
            Assert.IsTrue(PTagSettings.IsModifyButtonDisplayed());
            Assert.IsTrue(PTagSettings.IsDeleteButtonDisplayed());
            
            //1. Verify that ptag is not deleted from ptag list
            Assert.IsTrue(PTagSettings.FocusOnPTagByName(input.InputData.CommonName));

        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Delete-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(DeletePtagSuite), "TC-J1-FVT-PtagConfiguration-Delete-101-3")]
        public void DeletePtagUsedByAll(PtagData input)
        {
            //Select the ptag
            PTagSettings.FocusOnPTagByName(input.InputData.CommonName);

            //Click "Delete" button
            PTagSettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for confirm delete
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.MessageArray[0]));

            //Click "Confirm" button
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            string msgText2 = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText2.Contains(input.ExpectedData.MessageArray[1]));

            //Click "OK" button
            JazzMessageBox.MessageBox.OK();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify delete failed
            Assert.IsTrue(PTagSettings.IsModifyButtonDisplayed());
            Assert.IsTrue(PTagSettings.IsDeleteButtonDisplayed());
            
            //1. Verify that ptag is not deleted from ptag list
            Assert.IsTrue(PTagSettings.FocusOnPTagByName(input.InputData.CommonName));
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Delete-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(DeletePtagSuite), "TC-J1-FVT-PtagConfiguration-Delete-101-4")]
        public void DeletePtagUsedByFormula(PtagData input)
        {
            string vtagName = "VtagUsePtagKVAH002";
            
            //Select the ptag
            PTagSettings.FocusOnPTagByName(input.InputData.CommonName);

            //Click "Delete" button
            PTagSettings.ClickDeleteButton();
            TimeManager.ShortPause();

            //Verify that message box popup for confirm delete
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.MessageArray[0]));

            //Click "Confirm" button
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            string msgText2 = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText2.Contains(input.ExpectedData.MessageArray[1]));

            //Click "OK" button
            JazzMessageBox.MessageBox.OK();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify delete failed
            Assert.IsTrue(PTagSettings.IsModifyButtonDisplayed());
            Assert.IsTrue(PTagSettings.IsDeleteButtonDisplayed());

            //1. Verify that ptag is not deleted from ptag list
            Assert.IsTrue(PTagSettings.FocusOnPTagByName(input.InputData.CommonName));

            //2. Delete the vtag which using ptag 
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzFunction.VTagSettings.GotoPageOnVTagList(2);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            JazzFunction.VTagSettings.FocusOnVTagByName(vtagName);
            JazzFunction.VTagSettings.ClickDeleteButton();
            string msgText3 = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText3.Contains(input.ExpectedData.MessageArray[2]));
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            Assert.IsFalse(JazzFunction.VTagSettings.FocusOnVTagByName(vtagName));

            //delete ptag again
            PTagSettings.NavigatorToPtagSetting();
            PTagSettings.FocusOnPTagByName(input.InputData.CommonName);
            PTagSettings.ClickDeleteButton();
            TimeManager.ShortPause();
            string msgText4 = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText4.Contains(input.ExpectedData.MessageArray[0]));
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //1. Verify that ptag is deleted from ptag list
            Assert.IsFalse(PTagSettings.FocusOnPTagByName(input.InputData.CommonName));
        }
    }
}
