﻿using System;
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
   [TestFixture]
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
            CustomizedLabellingSettings.NavigatorToNonCustomizedLabelling();
        }

        [Test]
        [Category("P1_Emma")]
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
            TimeManager.MediumPause();

            //Change Uom from dropdown list.
            CustomizedLabellingSettings.SelectUomComboBox(input.InputData.Uom);

            //Select 能效标识级别 from dropdown list.
            CustomizedLabellingSettings.SelectLabellingLevelComboBox(input.InputData.LabellingLevel);

            //check labelingGrade count
            int count = Convert.ToInt32(input.InputData.LabellingLevelValue);
            Assert.AreEqual(count, CustomizedLabellingSettings.GetLabellingGradeCount());

            //Select KPI type=昼夜比.
            CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[0]);
            Assert.AreEqual(input.ExpectedData.KPITypes[0], input.InputData.KPITypes[0]);

            //Check AscendingCustomizedLabellingButton is "倒序"
            Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetDescendingCustomizedLabellingButton());

            //Change to select KPI type=单位人口.(这里改变以后就直接是正序了，不再是倒序)
            CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[1]);

            //check labelingGrade Firstlabel&Lastlabel.
            Assert.AreEqual(input.ExpectedData.Firstlabel, CustomizedLabellingSettings.GetLabellingGradeFirstLabel());
            Assert.AreEqual(input.ExpectedData.Lastlabel, CustomizedLabellingSettings.GetLabellingGradeLastLabel());

            //这里有个问题，对于中文版，有些单位还是习惯性的用缩写英文表示，没有显示成中文，这个后续会和UI确认
            //Check UOM
            for (int num = 0; num < Convert.ToInt32(input.InputData.LabellingLevelValue.ToString()); num++)
            {
                Assert.AreEqual(input.ExpectedData.UOM, CustomizedLabellingSettings.GetLabellingUOMValue(num + 1));
            }

            //Input Labelling level A<=5.144.
            CustomizedLabellingSettings.FillInLabellingLevelLeftValue(1, input.InputData.LabellingValue[0][0].LabellingLeftValue);
            TimeManager.LongPause();

            //Input Labelling level C=1000000000.
            CustomizedLabellingSettings.FillInLabellingLevelLeftValue(3, input.InputData.LabellingValue[1][0].LabellingLeftValue);
            TimeManager.LongPause();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.LabellingValue[1][0].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftInvalidMassage(3));
            
            //Input Labelling level C=10.
            CustomizedLabellingSettings.FillInLabellingLevelLeftValue(3, "");
            CustomizedLabellingSettings.FillInLabellingLevelLeftValue(3, input.InputData.LabellingValue[0][2].LabellingLeftValue);
            TimeManager.LongPause();

            //Save
            CustomizedLabellingSettings.ClickSaveButton();
            TimeManager.LongPause();

            //Auto change level B left border=5.14,Auto round level A<=5.14
            Assert.AreEqual(input.ExpectedData.LabellingValue[0][0].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftValue(1));
            Assert.AreEqual(input.ExpectedData.LabellingValue[0][1].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftValue(2));

            //Auto change level B right border=10.
            Assert.AreEqual(input.ExpectedData.LabellingValue[0][1].LabellingRightValue, CustomizedLabellingSettings.GetLabellingGradeRightValue(2));

            //Go to view status display Labelling successfully the same as before save.
            Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
            Assert.AreEqual(input.ExpectedData.Commodity, input.InputData.Commodity);
            Assert.AreEqual(input.ExpectedData.Uom, input.InputData.Uom);
            Assert.AreEqual(input.ExpectedData.LabellingLevel, input.InputData.LabellingLevel);
            Assert.AreEqual(input.ExpectedData.KPITypes[1], input.InputData.KPITypes[1]);

            //The labelling name/create user/create time display in labelling grid. 
            Assert.IsTrue(CustomizedLabellingSettings.IslabelingNameExist(input.ExpectedData.CommonName));

            //有个bug，现在备注是空的时候不隐藏，每次到这里会失败
            Assert.IsTrue(CustomizedLabellingSettings.IsCommentHidden());        
        }
         
         [Test]
         [Category("P2_Emma")]
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

            //这里有个问题，对于中文版，有些单位还是习惯性的用缩写英文表示，没有显示成中文，这个后续会和UI确认
            //check UOM
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
             TimeManager.LongPause();

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
         [Category("P2_Emma")]
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

             //Input Labelling Left Value
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValues[1]); num++)
             {
                 CustomizedLabellingSettings.FillInLabellingLevelLeftValue(num + 1, input.InputData.LabellingValue[1][num].LabellingLeftValue);
             }              

             //Change select other KPI type=工休比 from dropdown list.
             CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[1]);
             TimeManager.LongPause();


             //Input Labelling Left Value
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValues[1]); num++)
             {
                 CustomizedLabellingSettings.FillInLabellingLevelLeftValue(num + 1, input.InputData.LabellingValue[3][num].LabellingLeftValue);
             }

             //change to "正序"
             CustomizedLabellingSettings.ClickAscendingCustomizedLabellingButton();
             TimeManager.LongPause();
             TimeManager.LongPause();

             //check the values is "正序"
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValues[1]); num++)
             {
                 Assert.AreEqual(input.ExpectedData.LabellingValue[2][num].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftValue(num + 1));
             }

             //change to "倒序"
             CustomizedLabellingSettings.ClickDescendingCustomizedLabellingButton();
             TimeManager.LongPause();
             TimeManager.LongPause();

             //Save
             CustomizedLabellingSettings.ClickSaveButton();
             TimeManager.LongPause();
             TimeManager.LongPause();

             //Check the 公休比 levels saved successfully.
             CustomizedLabellingSettings.FocusOnCustomizedLabelling(input.InputData.CommonName, input.ExpectedData.ConfigurationUser);
             TimeManager.LongPause();

             //Check lalelling level's left value after saved.
             for (int num = 0; num < Convert.ToInt32(input.InputData.LabellingLevelValue); num++)
             {
                 Assert.AreEqual(input.ExpectedData.LabellingValue[3][num].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftValue(num + 1));
             }

             //Check lalelling level's right value 
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValue) - 1; num++)
             {
                 Assert.AreEqual(input.ExpectedData.LabellingValue[0][num].LabellingRightValue, CustomizedLabellingSettings.GetLabellingGradeRightValue(num + 1));
             }
         }

         [Test]
         [Category("P4_Emma")]
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

             //Change Uom from dropdown list.
             CustomizedLabellingSettings.SelectUomComboBox(input.InputData.Uom);

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

             //这里有个问题，对于中文版，有些单位还是习惯性的用缩写英文表示，没有显示成中文，这个后续会和UI确认
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

         [Test]
         [Category("P3_Emma")]
         [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Add-105")]
         [Type("BFT")]
         [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(AddValidCustomizedLabelingSuite), "TC-J1-FVT-CustomizedLabellingSetting-Add-105")]
         public void AddCustomizedLabelingValidInput(CustomizedLabellingSettingData input)
         {
             //Click "+能效标识" button 
             CustomizedLabellingSettings.ClickAddCustomizedLabellingButton();
             TimeManager.LongPause();

             //Input valid Labelling name. 
             CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonName);
             TimeManager.MediumPause();

             //Change to select KPI type.
             CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPIType);

             CustomizedLabellingSettings.FillInCommentTextField(input.InputData.Comments);
             TimeManager.MediumPause();

             //Input Labelling Left Value
             for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValue); num++)
             {
                 CustomizedLabellingSettings.FillInLabellingLevelLeftValue(num + 1, input.InputData.LabellingValue[0][num].LabellingLeftValue);
             }
             //Save
             CustomizedLabellingSettings.ClickSaveButton();
             JazzMessageBox.LoadingMask.WaitLoading(15);
             TimeManager.LongPause();

             Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
             Assert.AreEqual(input.ExpectedData.Comments, CustomizedLabellingSettings.GetCommentTextFieldValue());
         }
    }           
}


