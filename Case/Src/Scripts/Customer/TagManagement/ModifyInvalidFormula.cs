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
    [CreateTime("2013-07-09")]
    [ManualCaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101")]
    public class ModifyInvalidFormula : TestSuiteBase
    {
        private VTagSettings VTagSettings = JazzFunction.VTagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            VTagSettings.VTagSettingCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            VTagSettings.VTagSettingCaseTearDown();
        }

        /// <summary>
        /// Prepare Data:  1. Make sure the vtags have been added "PtagForCheckVtagFormula"  
        ///                          2. VtagForFormula001 VtagForFormula002 VtagForFormula003 
        /// </summary> 
        [Test]
        [CaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyInvalidFormula), "TC-J1-FVT-VtagFormulaConfiguration-Modify-001-1")]
        public void FormulaInvalidInputs(VtagData input)
        {

            //Click "+" button and fill nothing
            VTagSettings.ClickAddVTagButton();
            VTagSettings.FillInAddVTagData(input.InputData);
            //Click "Save" button
            VTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            
            //verify add successful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());

            Assert.AreEqual(input.ExpectedData.CommonName, VTagSettings.GetVTagNameValue());
            Assert.AreEqual(input.ExpectedData.Code, VTagSettings.GetVTagcodeValue());
            Assert.AreEqual(VTagSettings.GetVTagCommodityExpectedValue(input.InputData.Commodity), VTagSettings.GetVTagCommodityValue());
            Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(input.InputData.UOM), VTagSettings.GetVTagUOMValue());
            Assert.AreEqual(VTagSettings.GetVTagCalculationTypeExpectedValue(input.InputData.CalculationType), VTagSettings.GetVTagCalculationTypeValue());
            Assert.AreEqual(VTagSettings.GetVTagCalculationStepExpectedValue(input.InputData.Step), VTagSettings.GetVTagCalculationStepValue());



            //1. Click save button on formula tab directly

            VTagSettings.SwitchToFormulaTab();
            TimeManager.MediumPause();
            VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            VTagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();
            
            //2.常数(正数，负数，带2位小数)，缺少tag

            VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            VTagSettings.FillInFormulaField("-3+5+4.05");
            VTagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            // Cancel modify the formula
            VTagSettings.ClickCancelFormulaButton();
           

           //3.多个vtag之间缺少运算符


           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();

           VTagSettings.FillInFormulaField("{vtag|VtagForValidFormula001}{vtag|VtagForValidFormula002}");
           //VTagSettings.DragTagToFormula("VtagForValidFormula001");

           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           TimeManager.MediumPause();

            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);
            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();

           //4.多个vtag之间运算符多于一个
           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();
            

           VTagSettings.FillInFormulaField("{vtag|VtagForFormula001}+-{vtag|VtagForFormula002}*/{vtag|VtagForFormula003}");

           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           TimeManager.MediumPause();
           
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();

           //5.公式中包括格式不正确的P-tag或者V-tag
           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();

           VTagSettings.FillInFormulaField("|VtagForFormula001}");

           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           TimeManager.MediumPause();

            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);
            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();

           //7.公式中包括无效字符或者空格。“@#$-”；“Space”；“中文字符”；{abc}

           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();
           VTagSettings.FillInFormulaField("@#$- 中文字符");
           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();
            // Space null
            VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            VTagSettings.FillInFormulaField(" ");
            VTagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            VTagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();


            VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            VTagSettings.FillInFormulaField("中文字符");
            VTagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            VTagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();
            
           // 8.公式中只包括动态属性，缺少tag。

           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();

           VTagSettings.FillInFormulaField("{FormulaBuilding|prop|CoolingArea}");

           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();

            VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            VTagSettings.FillInFormulaField("{FormulaBuilding|prop|HeatingArea}");

            VTagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();

            VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            VTagSettings.FillInFormulaField("{FormulaBuilding|prop|TotalArea}");

            VTagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();

            VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            VTagSettings.FillInFormulaField("{FormulaBuilding|prop|TotalPopulation}");

            VTagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();

            // 9.公式中包括不存在的tag( manually input V1= Pxxxxx (Pxxxxx doesn't exist in system actually))

           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();

           VTagSettings.FillInFormulaField("{vtag|Vtag123456789}");
           TimeManager.ShortPause();
           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           TimeManager.MediumPause();
             // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();
            

            /*
            //11.公式中包括不存在的人口面积属性

           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();

           VTagSettings.FillInFormulaField("{NotExistProperties|prop|CoolingArea}");

           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();


            VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            VTagSettings.FillInFormulaField("{NotExistProperties|prop|TotalPopulation}");

            VTagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();
           
           //12.公式中包括没有数据权限的tag  
           //  defined a V1= V2+V3, the source tag V2 is associated to hierarchynodeA, 
           //  but user's data permission for the hierarchy node was removed, when click save button of V1's formula again.
          
            JazzFunction.UserProfile.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption("PlatformAdmin","P@ssw0rd","自动化测试TWO");
            JazzFunction.LoginPage.LoginToAdmin();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagementUser);
            JazzFunction.UserSettings.FocusOnUser("PerfTestCustomer");
            // Swtich to data permisstion
            //JazzFunction.UserSettings.
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            VTagSettings.FocusOnVTagByName("VtagBuildingB");

           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();

           VTagSettings.FillInFormulaField("{vtag|VtagBuildingA}+{ptag|PtagFormula}");

           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.InputData.Message);
            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();
            
            //13.公式中包括没有数据权限的人口面积属性   
           //e.g. V1= pulation property of a hierarchy node, but user's data permission for the hierarchy node was removed, 
           //when he clicks save button of V1's formula.
            VTagSettings.FocusOnVTagByName("VtagBuildingAProp");
           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();
           VTagSettings.FillInFormulaField("{ptag|PtagFormula}/{BuildingA|prop|TotalPopulation}");
           
           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.InputData.Message);
            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();
            */
            
            //14.公式中包括尚未定义公式的tag  
           //e.g. V1= V2  The source tag V2 is a newly created one and haven't defined any formula yet, when try to save formula of V1.

           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();

           VTagSettings.FillInFormulaField("VtagNotExisted0000000");

           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();

           //15.公式中包括步长大于自身的tag   
           //e.g. V1= V3+V4  V1's step is hour, source tag V3's step is day, when try to save formula of V1.

           VTagSettings.ClickModifyFormulaButton();
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.MediumPause();

           VTagSettings.FillInFormulaField("{vtag|Vtag1_Hour_Step}+{vtag|Vtag1_Day_Step}");
           TimeManager.ShortPause();
           VTagSettings.ClickSaveFormulaButton();
           JazzMessageBox.LoadingMask.WaitLoading();
           TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();

            /*
            //10.Prepare a V1 tag (V1=P1+buildingA.property)  Delete the buildingA node successfully.  View V1's formula again.

            HierarchySettings.NavigatorToHierarchySetting();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.HierarchySettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.HierarchySettings.ClickDeleteButton();
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(VTagSettings.FocusOnVTagByCode("VtagForFormula010"));
            TimeManager.MediumPause();
            VTagSettings.SwitchToFormulaTab();
            TimeManager.MediumPause();
            Assert.AreEqual(VTagSettings.GetFormulaValue(), "{ptag|PtagByFormula}+{Invalid_Prop}");
            TimeManager.ShortPause();

            //6.包含循环调用。Defined V1=V2，then modify V2's formula to be V2=V1, click save。
            VTagSettings.FocusOnVTagByName(input.InputData.CommonName);
            VTagSettings.SwitchToFormulaTab();
            VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            VTagSettings.DragTagToFormula("VtagForFormula006");

            VTagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            VTagSettings.FocusOnVTagByName("VtagForFormula006");
            VTagSettings.SwitchToFormulaTab();
            VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            VTagSettings.DragTagToFormula(input.InputData.CommonName);

            VTagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            // Verfied the error message
            VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage);

            VTagSettings.ClickCancelFormulaButton();
            TimeManager.ShortPause();
            */
        }
    }
}
