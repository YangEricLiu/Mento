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
   public class AddValidCustomizedLabeling
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
        [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(AddValidCustomizedLabeling), "TC-J1-FVT-CustomizedLabellingSetting-Add-101")]
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
            CustomizedLabellingSettings.SelectCustomizedLabellingLevelComboBox(input.InputData.LabellingLevel);

            //check labelingGrade count
           Assert.AreEqual(input.InputData.LabellingLevel,CustomizedLabellingSettings.GetCustomizedLabellingListCount());

            //Select KPI type=昼夜比.
            CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[0]);
            Assert.AreEqual(input.ExpectedData.KPITypes[0], input.InputData.KPITypes[0]);

            //Check AscendingCustomizedLabellingButton is "正序"
            Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetAscendingCustomizedLabellingButton());

            //Change to select KPI type=单位人口.
            CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[1]);

            //Input Labelling level A<=5.144.
            Assert.AreSame(input.ExpectedData.Firstlabel, CustomizedLabellingSettings.GetLabellingLevelFrontLabel());
            Assert.AreSame(input.ExpectedData.Lastlabel, CustomizedLabellingSettings.GetLabellingLevelLastLabel());
            CustomizedLabellingSettings.FillInLabellingLevelLeftValue(3, "5.144");

            //Auto change level B left border=5.14,Auto round level A<=5.14
            Assert.AreEqual(input.ExpectedData.LabellingValue[0][0].LabellingLeftValue,CustomizedLabellingSettings.GetLabellingLevelLeftValue(1));
            Assert.AreEqual(input.ExpectedData.LabellingValue[0][1].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingLevelLeftValue(1));

            //Input Labelling level C=10.
            //CustomizedLabellingSettings.FillInLabellingLevelLeftValue(3, "10");

            //Auto change level B right border=10.
            Assert.AreEqual(input.ExpectedData.LabellingValue[0][1].LabellingRightValue,CustomizedLabellingSettings.GetLabellingLevelLeftValue(3));
            
            //Check UOM
            for (int i = 0; i < Convert.ToInt32(input.InputData.LabellingLevel.ToString()); i++)
            {
                Assert.AreSame(input.ExpectedData.UOM, CustomizedLabellingSettings.GetLabellingUOMValue(i + 1));
            }

            //Save
            CustomizedLabellingSettings.ClickSaveButton();

            //Go to view status display Labelling successfully the same as before save.
            Assert.AreSame(input.ExpectedData.CommonName,CustomizedLabellingSettings.GetNameTextFieldValue());
            Assert.AreSame(input.ExpectedData.Commodity, input.InputData.Commodity);
            Assert.AreSame(input.ExpectedData.LabellingLevel, input.InputData.LabellingLevel);
            Assert.AreSame(input.ExpectedData.KPITypes[1], input.InputData.KPITypes[1]);

            //The labelling name/create user/create time display in labelling grid. 
            CustomizedLabellingSettings.IslabelingNameExist(input.InputData.CommonName);
        }
         
         [Test]
         [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Add-102")]
         [Type("BFT")]
         [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(AddCustomizedLabelingValid), "TC-J1-FVT-CustomizedLabellingSetting-Add-102")]
         public void AddCustomizedLabelingValidSuite02(CustomizedLabellingSettingData input)
         {
             //Click "+能效标识" button 
             CustomizedLabellingSettings.ClickAddCustomizedLabellingButton();

             //Input valid Labelling name. 
             CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonName);


             //Input Labelling level A<=5.
             Assert.AreSame(input.ExpectedData.Firstlabel, CustomizedLabellingSettings.GetLabellingLevelFrontLabel());
             Assert.AreSame(input.ExpectedData.Lastlabel, CustomizedLabellingSettings.GetLabellingLevelLastLabel());
             CustomizedLabellingSettings.FillInLabellingLevelLeftValue(1, "5");

             //Auto change level B left border=5
             Assert.AreEqual(input.ExpectedData.LabellingValue[0][1].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingLevelLeftValue(1));

             //Input Labelling level B right border=10.
             CustomizedLabellingSettings.FillInLabellingLevelRightValue(2, "10");

             //Auto change level C left border=10
             Assert.AreEqual(input.ExpectedData.LabellingValue[0][2].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingLevelRightValue(2));

             //Input Labelling level C right border=20.
             CustomizedLabellingSettings.FillInLabellingLevelRightValue(3, "20");

             //Auto change level D left border=20
             Assert.AreEqual(input.ExpectedData.LabellingValue[0][3].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingLevelRightValue(3));

             //Input Labelling level E=40. 
             CustomizedLabellingSettings.FillInLabellingLevelLeftValue(5, "40");

             //Auto change level D right border=40
             Assert.AreEqual(input.ExpectedData.LabellingValue[0][3].LabellingRightValue, CustomizedLabellingSettings.GetLabellingLevelLeftValue(5));

             //Save
             CustomizedLabellingSettings.ClickSaveButton();

             //Go to view status display Labelling successfully the same as before save.
             Assert.AreSame(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
             Assert.AreSame(input.ExpectedData.Commodity, CustomizedLabellingSettings.GetCommodityComboBoxValue());
             Assert.AreSame(input.ExpectedData.KPIType, CustomizedLabellingSettings.GetKPITypeComboBoxValue());
             Assert.AreSame(input.ExpectedData.LabellingLevel, CustomizedLabellingSettings.GetLabellingLevelComboBoxValue());

             //Check AscendingCustomizedLabellingButton is "正序"
             Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetAscendingCustomizedLabellingButton());

             //The labelling name/create user/create time display in labelling grid. 
             CustomizedLabellingSettings.IslabelingNameExist(input.InputData.CommonName);
         }
        
         [Test]
         [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Add-103")]
         [Type("BFT")]
         [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(AddCustomizedLabelingValid), "TC-J1-FVT-CustomizedLabellingSetting-Add-103")]
         public void AddCustomizedLabelingValidSuite03(CustomizedLabellingSettingData input)
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
             CustomizedLabellingSettings.SelectCustomizedLabellingLevelComboBox(input.InputData.LabellingLevels[0]);

             //Input Labelling level A<=1.
             Assert.AreSame(input.ExpectedData.Firstlabel, CustomizedLabellingSettings.GetLabellingLevelFrontLabel());
             Assert.AreSame(input.ExpectedData.Lastlabel, CustomizedLabellingSettings.GetLabellingLevelLastLabel());
             CustomizedLabellingSettings.FillInLabellingLevelLeftValue(1, "1");

             //Auto change level B left border=1
             Assert.AreEqual(input.ExpectedData.LabellingValue[0][1].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingLevelLeftValue(1));

             //Input Labelling level B right border=2.
             CustomizedLabellingSettings.FillInLabellingLevelRightValue(2, "2");

             //Auto change level C left border=2
             Assert.AreEqual(input.ExpectedData.LabellingValue[0][2].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingLevelRightValue(2));

             //Input Labelling level C right border=3.
             CustomizedLabellingSettings.FillInLabellingLevelRightValue(3, "3");

             //Auto change level D left border=3
             Assert.AreEqual(input.ExpectedData.LabellingValue[0][3].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingLevelRightValue(3));

             //Input Labelling level D right border=4. 
             CustomizedLabellingSettings.FillInLabellingLevelRightValue(4, "4");

             //Auto change level E left border=4
             Assert.AreEqual(input.ExpectedData.LabellingValue[0][4].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingLevelRightValue(4));

             //Input Labelling level E right border=5. 
             CustomizedLabellingSettings.FillInLabellingLevelRightValue(5, "5");

             //Auto change level F left border=5
             Assert.AreEqual(input.ExpectedData.LabellingValue[0][5].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingLevelRightValue(5));
            
             //Input Labelling level F right border=6. 
             CustomizedLabellingSettings.FillInLabellingLevelRightValue(6, "6");

             //Auto change level G left border=6
             Assert.AreEqual(input.ExpectedData.LabellingValue[0][6].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingLevelRightValue(6));

             //Input Labelling level G right border=7. 
             CustomizedLabellingSettings.FillInLabellingLevelLeftValue(7, "7");

             //Auto change level H left border=7
             Assert.AreEqual(input.ExpectedData.LabellingValue[0][7].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingLevelRightValue(7));


             //Save
             CustomizedLabellingSettings.ClickSaveButton();

             //Go to view status display Labelling successfully the same as before save.
             Assert.AreSame(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
             Assert.AreSame(input.ExpectedData.Commodity, CustomizedLabellingSettings.GetCommodityComboBoxValue());
             Assert.AreSame(input.ExpectedData.KPIType, CustomizedLabellingSettings.GetKPITypeComboBoxValue());
             Assert.AreSame(input.ExpectedData.LabellingLevel, CustomizedLabellingSettings.GetLabellingLevelComboBoxValue());

             //Check AscendingCustomizedLabellingButton is "正序"
             Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetAscendingCustomizedLabellingButton());

             //The labelling name/create user/create time display in labelling grid. 
             CustomizedLabellingSettings.IslabelingNameExist(input.InputData.CommonName);
         }

   }
        
}
