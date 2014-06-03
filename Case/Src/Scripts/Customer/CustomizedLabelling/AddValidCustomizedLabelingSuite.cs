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

namespace Mento.Script.Customer.CustomizedLabelling
{
   public class AddValidCustomizedLabelingSuite
    {
        private CustomizedLabellingSettings CustomizedLabellingSettings = JazzFunction.CustomizedLabellingSettings;

        [SetUp]
        public void CaseSetUp()
        {
            CustomizedLabellingSettings.NavigatorToCustomizedLabelling();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            CustomizedLabellingSettings.NavigatorToCustomizedLabelling();
        }

        [Test]
        [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Add-101")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(AddValidCustomizedLabelingSuite), "TC-J1-FVT-CustomizedLabellingSetting-Add-101")]
        public void AddCustomizedLabelingValid(CustomizedLabellingSettingData input)
        {
            //Click "+能效标识" button 
            CustomizedLabellingSettings.ClickAddCustomizedLabellingButton();
            TimeManager.LongPause();
            
            //Input valid Labelling name. 
            CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonName);
            TimeManager.MediumPause();

            //Change Commodity from dropdown list.
            CustomizedLabellingSettings.SelectCommodityComboBox(input.InputData.Commodity);

            //Select 能效标识级别 from dropdown list.
            CustomizedLabellingSettings.SelectLabellingLevelComboBox(input.InputData.LabellingLevel);

            //check labelingGrade count
            int count = Convert.ToInt32(input.InputData.LabellingLevelValue);
            Assert.AreEqual(count,CustomizedLabellingSettings.GetLabellingGradeCount());

            //Select KPI type=昼夜比.
            CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[0]);
            Assert.AreEqual(input.ExpectedData.KPITypes[0], input.InputData.KPITypes[0]);

            //Check AscendingCustomizedLabellingButton is "倒序"
            Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetDescendingCustomizedLabellingButton());

            //Change to select KPI type=单位人口.
            CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[1]);

            //check labelingGrade Firstlabel&Lastlabel.
            Assert.AreEqual(input.ExpectedData.Firstlabel, CustomizedLabellingSettings.GetLabellingGradeFirstLabel());
            Assert.AreEqual(input.ExpectedData.Lastlabel, CustomizedLabellingSettings.GetLabellingGradeLastLabel());

            //Check UOM
            for (int num = 0; num < Convert.ToInt32(input.InputData.LabellingLevelValue.ToString()); num++)
            {
                Assert.AreEqual(input.ExpectedData.UOM, CustomizedLabellingSettings.GetLabellingUOMValue(num + 1));
            }

            //Input Labelling level A<=5.144.
            CustomizedLabellingSettings.FillInLabellingLevelLeftValue(1, input.InputData.LabellingValue[0][0].LabellingLeftValue);

            //Input Labelling level C=10000000000000000000000.
            CustomizedLabellingSettings.FillInLabellingLevelLeftValue(3, input.InputData.LabellingValue[1][0].LabellingLeftValue);
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.LabellingValue[1][0].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftInvalidMassage(3));

            //Input Labelling level C=10.
            CustomizedLabellingSettings.FillInLabellingLevelLeftValue(3, "");
            CustomizedLabellingSettings.FillInLabellingLevelLeftValue(3, input.InputData.LabellingValue[0][2].LabellingLeftValue);

            //Save
            CustomizedLabellingSettings.ClickSaveButton();
            TimeManager.LongPause();

            //Auto change level B left border=5.14,Auto round level A<=5.14
            Assert.AreEqual(input.ExpectedData.LabellingValue[0][0].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftValue(1));
            Assert.AreEqual(input.ExpectedData.LabellingValue[0][1].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftValue(2));

            //Auto change level B right border=10.
            Assert.AreEqual(input.ExpectedData.LabellingValue[0][1].LabellingRightValue, CustomizedLabellingSettings.GetLabellingGradeRightValue(2));
            
            //Go to view status display Labelling successfully the same as before save.
            Assert.AreEqual(input.ExpectedData.CommonName,CustomizedLabellingSettings.GetNameTextFieldValue());
            Assert.AreEqual(input.ExpectedData.Commodity, input.InputData.Commodity);
            Assert.AreEqual(input.ExpectedData.LabellingLevel, input.InputData.LabellingLevel);
            Assert.AreEqual(input.ExpectedData.KPITypes[1], input.InputData.KPITypes[1]);

            //The labelling name/create user/create time display in labelling grid. 
            Assert.IsTrue(CustomizedLabellingSettings.IslabelingNameExist(input.ExpectedData.CommonName));
        }
         
         [Test]
         [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Add-102")]
         [Type("BFT")]
         [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(AddValidCustomizedLabelingSuite), "TC-J1-FVT-CustomizedLabellingSetting-Add-102")]
        public void AddCustomizedLabelingDefault(CustomizedLabellingSettingData input)
         {
             //Click "+能效标识" button 
             CustomizedLabellingSettings.ClickAddCustomizedLabellingButton();

             //Input valid Labelling name. 
             CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonName);

             //check labelingGrade Firstlabel&Lastlabel.
             Assert.AreEqual(input.ExpectedData.Firstlabel, CustomizedLabellingSettings.GetLabellingGradeFirstLabel());
             Assert.AreEqual(input.ExpectedData.Lastlabel, CustomizedLabellingSettings.GetLabellingGradeLastLabel());

             //Check AscendingCustomizedLabellingButton is "正序"
             Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetAscendingCustomizedLabellingButton());

             //check labelingGrade count
             int count = Convert.ToInt32(input.InputData.LabellingLevelValue);
             Assert.AreEqual(count, CustomizedLabellingSettings.GetLabellingGradeCount());

            //Check UOM
            for (int num = 0; num < Convert.ToInt32(input.InputData.LabellingLevelValue.ToString()); num++)
            {
                Assert.AreEqual(input.ExpectedData.UOM, CustomizedLabellingSettings.GetLabellingUOMValue(num + 1));
            }

             //Input Labelling Left Value
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValue); num++)
             {
                 CustomizedLabellingSettings.FillInLabellingLevelLeftValue(num + 1, input.InputData.LabellingValue[0][num].LabellingLeftValue);
             }

             //Save
             CustomizedLabellingSettings.ClickSaveButton();

             //Go to view status display Labelling successfully the same as before save.
             Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
             Assert.AreEqual(input.ExpectedData.Commodity, CustomizedLabellingSettings.GetCommodityComboBoxValue());
             Assert.AreEqual(input.ExpectedData.KPIType, CustomizedLabellingSettings.GetKPITypeComboBoxValue());
             Assert.AreEqual(input.ExpectedData.LabellingLevel, CustomizedLabellingSettings.GetLabellingLevelComboBoxValue());
             
             //Check lalelling level's left value 
             for (int num = 0; num < Convert.ToInt32(input.InputData.LabellingLevelValue); num++)
             {
                 Assert.AreEqual(input.ExpectedData.LabellingValue[0][num].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftValue(num+1));
             }

             //Check lalelling level's right value 
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValue)-1; num++)
             {
                 Assert.AreEqual(input.ExpectedData.LabellingValue[0][num].LabellingRightValue, CustomizedLabellingSettings.GetLabellingGradeRightValue(num + 1));
             }

             //The labelling name/create user/create time display in labelling grid. 
             Assert.IsTrue(CustomizedLabellingSettings.IslabelingNameExist(input.ExpectedData.CommonName));
         }
        
         [Test]
         [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Add-103")]
         [Type("BFT")]
         [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(AddValidCustomizedLabelingSuite), "TC-J1-FVT-CustomizedLabellingSetting-Add-103")]
         public void AddCustomizedLabellingChangeLevels(CustomizedLabellingSettingData input)
         {
             //Click "+能效标识" button 
             CustomizedLabellingSettings.ClickAddCustomizedLabellingButton();

             //Input valid Labelling name. 
             CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonName);

             //Change Commodity from dropdown list.
             CustomizedLabellingSettings.SelectCommodityComboBox(input.InputData.Commodities[0]);

             //Change to select KPI type=单位面积.
             CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[0]);

             //Select 能耗标识级别=8 from dropdown list.
             CustomizedLabellingSettings.SelectLabellingLevelComboBox(input.InputData.LabellingLevels[0]);
             
             //Check AscendingCustomizedLabellingButton is "正序"
             Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetAscendingCustomizedLabellingButton());

             //check labelingGrade Firstlabel&Lastlabel.
             Assert.AreEqual(input.ExpectedData.Firstlabels[0], CustomizedLabellingSettings.GetLabellingGradeFirstLabel());
             Assert.AreEqual(input.ExpectedData.Lastlabels[0], CustomizedLabellingSettings.GetLabellingGradeLastLabel());

             //check labelingGrade count
             int count = Convert.ToInt32(input.InputData.LabellingLevelValues[0]);
             Assert.AreEqual(count, CustomizedLabellingSettings.GetLabellingGradeCount());

             //Input Labelling Left Value
             for (int num = 1; num <count; num++)
             {
                 CustomizedLabellingSettings.FillInLabellingLevelLeftValue(num + 1, input.InputData.LabellingValue[0][num].LabellingLeftValue);
             }

             //Select 能耗标识级别=6 from dropdown list.
             CustomizedLabellingSettings.SelectLabellingLevelComboBox(input.InputData.LabellingLevels[1]);

             //check Labelling right Value
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValues[1]) - 1; num++)
             {
                 Assert.AreEqual(input.ExpectedData.LabellingValue[0][num].LabellingRightValue, CustomizedLabellingSettings.GetLabellingGradeRightValue(num + 1));
             }

             //Input Labelling Left Value
             for (int num = 0; num < Convert.ToInt32(input.InputData.LabellingLevelValues[1]); num++)
             {
                 CustomizedLabellingSettings.FillInLabellingLevelLeftValue(num + 1, input.InputData.LabellingValue[1][num].LabellingLeftValue);
             }

             //Change select other commodity=天然气 from dropdown list.
             CustomizedLabellingSettings.SelectCommodityComboBox(input.InputData.Commodities[1]);

             //Check AscendingCustomizedLabellingButton is "正序"
             Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetAscendingCustomizedLabellingButton());

             //Input Labelling right Value
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValues[1]) - 1; num++)
             {
                 Assert.AreEqual(input.ExpectedData.LabellingValue[0][num].LabellingRightValue, CustomizedLabellingSettings.GetLabellingGradeRightValue(num + 1));
             }

             //Input Labelling Left Value
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValues[1]); num++)
             {
                 CustomizedLabellingSettings.FillInLabellingLevelLeftValue(num + 1, input.InputData.LabellingValue[1][num].LabellingLeftValue);
             }

             //Change select other KPI type=工休比 from dropdown list.
             CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[1]);

             //Check AscendingCustomizedLabellingButton is "倒序"
             Assert.AreEqual(input.ExpectedData.Order[1], CustomizedLabellingSettings.GetDescendingCustomizedLabellingButton());

             //check labelingGrade Firstlabel&Lastlabel.
             Assert.AreEqual(input.ExpectedData.Firstlabels[1], CustomizedLabellingSettings.GetLabellingGradeFirstLabel());
             Assert.AreEqual(input.ExpectedData.Lastlabels[1], CustomizedLabellingSettings.GetLabellingGradeLastLabel());

             //Check Labelling right Value
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValues[1]) - 1; num++)
             {
                 Assert.AreEqual(input.ExpectedData.LabellingValue[0][num].LabellingRightValue, CustomizedLabellingSettings.GetLabellingGradeRightValue(num + 1));
             }

             //Input Labelling Left Value
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValues[1]); num++)
             {
                 CustomizedLabellingSettings.FillInLabellingLevelLeftValue(num + 1, input.InputData.LabellingValue[1][num].LabellingLeftValue);
             }

             //Save
             CustomizedLabellingSettings.ClickSaveButton();
             TimeManager.LongPause();
             TimeManager.LongPause();

             //The labelling name/create user/create time display in labelling grid. 
             Assert.IsTrue(CustomizedLabellingSettings.IslabelingNameExist(input.ExpectedData.CommonName));

             //Go to view status display Labelling successfully the same as before save.
             Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
             Assert.AreEqual(input.ExpectedData.Commodity, CustomizedLabellingSettings.GetCommodityComboBoxValue());
             Assert.AreEqual(input.ExpectedData.KPIType, CustomizedLabellingSettings.GetKPITypeComboBoxValue());
             Assert.AreEqual(input.ExpectedData.LabellingLevel, CustomizedLabellingSettings.GetLabellingLevelComboBoxValue());

             //Check lalelling level's left value 
             for (int num = 0; num < Convert.ToInt32(input.InputData.LabellingLevelValue); num++)
             {
                 Assert.AreEqual(input.ExpectedData.LabellingValue[0][num].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftValue(num + 1));
             }

             //Check lalelling level's right value 
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValue) - 1; num++)
             {
                 Assert.AreEqual(input.ExpectedData.LabellingValue[0][num].LabellingRightValue, CustomizedLabellingSettings.GetLabellingGradeRightValue(num + 1));
             }
         }

         [Test]
         [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Add-104")]
         [Type("BFT")]
         [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(AddValidCustomizedLabelingSuite), "TC-J1-FVT-CustomizedLabellingSetting-Add-104")]
         public void AddCustomizedLabelling8Levels(CustomizedLabellingSettingData input)
         {
             //Click "+能效标识" button 
             CustomizedLabellingSettings.ClickAddCustomizedLabellingButton();

             //Input valid Labelling name. 
             CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonName);

             //Change Commodity from dropdown list.
             CustomizedLabellingSettings.SelectCommodityComboBox(input.InputData.Commodity);

             //Change to select KPI type=单位面积.
             CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPIType);

             //Select 能耗标识级别=8 from dropdown list.
             CustomizedLabellingSettings.SelectLabellingLevelComboBox(input.InputData.LabellingLevel);

             //check labelingGrade Firstlabel&Lastlabel.
             Assert.AreEqual(input.ExpectedData.Firstlabel, CustomizedLabellingSettings.GetLabellingGradeFirstLabel());
             Assert.AreEqual(input.ExpectedData.Lastlabel, CustomizedLabellingSettings.GetLabellingGradeLastLabel());

             //Check AscendingCustomizedLabellingButton is "正序"
             Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetAscendingCustomizedLabellingButton());

             //check labelingGrade count
             int count = Convert.ToInt32(input.InputData.LabellingLevelValue);
             Assert.AreEqual(count, CustomizedLabellingSettings.GetLabellingGradeCount());

             //Check UOM
             for (int num = 0; num < Convert.ToInt32(input.InputData.LabellingLevelValue.ToString()); num++)
             {
                 Assert.AreEqual(input.ExpectedData.UOM, CustomizedLabellingSettings.GetLabellingUOMValue(num + 1));
             }

             //Input Labelling Left Value
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValue); num++)
             {
                 CustomizedLabellingSettings.FillInLabellingLevelLeftValue(num + 1, input.InputData.LabellingValue[0][num].LabellingLeftValue);
             }

             //Save
             CustomizedLabellingSettings.ClickSaveButton();

             //Go to view status display Labelling successfully the same as before save.
             Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
             Assert.AreEqual(input.ExpectedData.Commodity, CustomizedLabellingSettings.GetCommodityComboBoxValue());
             Assert.AreEqual(input.ExpectedData.KPIType, CustomizedLabellingSettings.GetKPITypeComboBoxValue());
             Assert.AreEqual(input.ExpectedData.LabellingLevel, CustomizedLabellingSettings.GetLabellingLevelComboBoxValue());
            
             //Check lalelling level's left value 
             for (int num = 0; num < Convert.ToInt32(input.InputData.LabellingLevelValue); num++)
             {
                 Assert.AreEqual(input.ExpectedData.LabellingValue[0][num].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftValue(num + 1));
             }

             //Check lalelling level's right value 
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValue) - 1; num++)
             {
                 Assert.AreEqual(input.ExpectedData.LabellingValue[0][num].LabellingRightValue, CustomizedLabellingSettings.GetLabellingGradeRightValue(num + 1));
             }

             //The labelling name/create user/create time display in labelling grid. 
             Assert.IsTrue(CustomizedLabellingSettings.IslabelingNameExist(input.ExpectedData.CommonName));
         }

   }
        
}
