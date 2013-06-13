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
            //Click "+" button and fill vtag field
            VTagSettings.ClickAddVTagButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            //waiting for "quanjuzhezhao" disappear
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //verify add successful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());

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
            //Click "+" button and fill vtag field
            VTagSettings.ClickAddVTagButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            //waiting for "quanjuzhezhao" disappear
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //verify add successful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());


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
            

            //3. Verify vtag is deleted from associated tag list
            //Verify vtag is deleted from AeraDimensionNode
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
            
            //Verify vtag is deleted from SystemDimensionNode
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationSystemDimension);
            JazzFunction.SystemDimensionSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            JazzFunction.SystemDimensionSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            TimeManager.MediumPause();

            JazzFunction.SystemDimensionSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemNodePath);
            TimeManager.MediumPause();
            Assert.IsFalse(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.ExpectedData.CommonName));
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
