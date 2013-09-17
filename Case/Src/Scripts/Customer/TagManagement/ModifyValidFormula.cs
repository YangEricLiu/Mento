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
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Greenie")]
    [CreateTime("2013-07-22")]
    [ManualCaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101")]
    public class ModifyValidFormula : TestSuiteBase
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
        /// <summary>
        /// Prepare Data:  1. make sure the vtags have been added "PtagForFormula"
        /// </summary> 
        [Test]
        [CaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101-0")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidFormula), "TC-J1-FVT-VtagFormulaConfiguration-Modify-101-0")]
        public void NotSupportFormula(VtagData input)
        {
            // Navigate to the ptag configuration page
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            // Select a  ptag
            JazzFunction.PTagSettings.FocusOnPTagByName(input.ExpectedData.CommonName);
            TimeManager.MediumPause();
            Assert.IsFalse(VTagSettings.IsSwitchToFormulaTabExist());
        }

      
        [Test]
        [CaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidFormula), "TC-J1-FVT-VtagFormulaConfiguration-Modify-101-1")]
        public void AddValidFormula(VtagData input)
        {
            //V(N)=3.05*P(M)
            VTagSettings.FocusOnVTagByName(input.InputData.CommonName);
            VTagSettings.SwitchToFormulaTab();
            VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();

           VTagSettings.FillInFormulaField("3.5*{ptag|PtagByFormula}");
           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           Assert.IsFalse(VTagSettings.IsFormulaInvalid());
           Assert.AreEqual(VTagSettings.GetFormulaValue(), "3.5*{ptag|PtagByFormula}");
           //二级运算：f(n)包括一级运算的V(N)之间以及P（M）的四则运算。
           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();

           VTagSettings.FillInFormulaField("{ptag|PtagByFormula}+{vtag|VtagForValidFormula001}/3.05");
           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           Assert.IsFalse(VTagSettings.IsFormulaInvalid());
           Assert.AreEqual(VTagSettings.GetFormulaValue(), "{ptag|PtagByFormula}+{vtag|VtagForValidFormula001}/3.05");
            //三级以上运算
           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();

           VTagSettings.FillInFormulaField("{vtag|VtagForValidFormula001}+{vtag|VtagForValidFormula001}-{vtag|VtagForValidFormula002}+1.05*{ptag|PtagByFormula}");
           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           Assert.IsFalse(VTagSettings.IsFormulaInvalid());
           Assert.AreEqual(VTagSettings.GetFormulaValue(), "{vtag|VtagForValidFormula001}+{vtag|VtagForValidFormula001}-{vtag|VtagForValidFormula002}+1.05*{ptag|PtagByFormula}");

            //Property参与运算
            /*
           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();

           VTagSettings.FillInFormulaField("{vtag|VtagForValidFormula001}/{FormulaBuilding|prop|TotalPopulation}");
           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           Assert.IsFalse(VTagSettings.IsFormulaInvalid());
           Assert.AreEqual(VTagSettings.GetFormulaValue(), "{vtag|VtagForValidFormula001}/{FormulaBuilding|prop|TotalPopulation}");
           */
        }

       /*
      [Test]
      [CaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101-2")]
      [Type("BFT")]
      [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidFormula), "TC-J1-FVT-VtagFormulaConfiguration-Modify-101-2")]
        public void DragTagsFormula(VtagData input)
      {

          JazzFunction.LoginPage.LoginToCustomer();
          VTagSettings.FocusOnVTagByName(input.InputData.CommonName);
          VTagSettings.ClickModifyFormulaButton();
          JazzMessageBox.LoadingMask.WaitSubMaskLoading();
          TimeManager.MediumPause();

          VTagSettings.DragTagToFormula("");

           
      }

      [Test]
      [CaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101-3")]
      [Type("BFT")]
      [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidFormula), "TC-J1-FVT-VtagFormulaConfiguration-Modify-101-3")]
      public void ModifyTagCode(VtagData input)
      {
          VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
          VTagSettings.ClickModifyFormulaButton();
          JazzMessageBox.LoadingMask.WaitSubMaskLoading();
          TimeManager.MediumPause();
          VTagSettings.FillInAddVTagData(input.InputData);
          VTagSettings.ClickSaveFormulaButton();
          JazzMessageBox.LoadingMask.WaitLoading();
          TimeManager.ShortPause();

          JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
          TimeManager.MediumPause();
          JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
          TimeManager.MediumPause();
          VTagSettings.FocusOnVTagByName("VtagValidFormula");
          VTagSettings.SwitchToFormulaTab();
          Assert.AreEqual(VTagSettings.GetFormulaValue(), "{vtag|CodeModified}");

      }

      [Test]
      [CaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101-4")]
      [Type("BFT")]
      [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidFormula), "TC-J1-FVT-VtagFormulaConfiguration-Modify-101-4")]
      public void FormulaCaseInsensive(VtagData input)
      {
          HierarchySettings.NavigatorToHierarchySetting();
          JazzFunction.HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
          JazzFunction.HierarchySettings.ClickCreateChildHierarchyButton();
          JazzFunction.HierarchySettings.FillInName("Building1");
          JazzFunction.HierarchySettings.FillIncode("Building1");
          JazzFunction.HierarchySettings.FillInType("Building");

          JazzFunction.HierarchySettings.ClickSaveButton();
          JazzMessageBox.LoadingMask.WaitLoading();
          TimeManager.ShortPause();
          JazzFunction.HierarchyPeopleAreaSettings.ClickPeopleAreaTab();
          TimeManager.MediumPause();
          JazzFunction.HierarchyPeopleAreaSettings.ClickPeopleAreaCreateButton();
          JazzFunction.HierarchyPeopleAreaSettings.InputHeatingAreaValue("1");
          JazzFunction.HierarchyPeopleAreaSettings.ClickSaveButton();
          JazzMessageBox.LoadingMask.WaitSubMaskLoading();
          TimeManager.MediumPause();

          JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
          JazzMessageBox.LoadingMask.WaitSubMaskLoading();
          TimeManager.MediumPause();

          VTagSettings.FocusOnVTagByName(input.InputData.CommonName);
          VTagSettings.SwitchToFormulaTab();
          TimeManager.ShortPause();
          VTagSettings.ClickModifyFormulaButton();
          JazzMessageBox.LoadingMask.WaitSubMaskLoading();
          TimeManager.ShortPause();
          VTagSettings.FillInFormulaField("{Building1|prop|CoolingArea}");
          VTagSettings.ClickSaveFormulaButton();
          JazzMessageBox.LoadingMask.WaitLoading();
          TimeManager.ShortPause();
      }
       */
    }
}
