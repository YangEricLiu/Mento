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
    public class ModifyCustomizedLabelingValid
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
        [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Modify-101")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(ModifyCustomizedLabelingValid), "TC-J1-FVT-CustomizedLabellingSetting-Modify-101")]
        public void ModifyCustomizedLabelingValid01(CustomizedLabellingSettingData input)
        {
            
            //Click an exist labelling.
            TimeManager.LongPause();
            TimeManager.LongPause();
            CustomizedLabellingSettings.FocusOnCustomizedLabelling(input.InputData.CommonNames[0],input.ExpectedData.ConfigurationUser);
            TimeManager.LongPause();
            
            //check the labeling's data
            Assert.AreEqual(input.InputData.CommonNames[0], CustomizedLabellingSettings.GetNameTextFieldValue());
            Assert.AreEqual(input.InputData.Commodities[0], CustomizedLabellingSettings.GetCommodityComboBoxValue());
            Assert.AreEqual(input.InputData.KPITypes[0], CustomizedLabellingSettings.GetKPITypeComboBoxValue());
            Assert.AreEqual(input.InputData.LabellingLevels[0], CustomizedLabellingSettings.GetLabellingLevelComboBoxValue());

            //check labelingGrade Firstlabel&Lastlabel.
            Assert.AreEqual(input.ExpectedData.Firstlabels[0], CustomizedLabellingSettings.GetLabellingGradeFirstLabel());
            Assert.AreEqual(input.ExpectedData.Lastlabels[0], CustomizedLabellingSettings.GetLabellingGradeLastLabel());

            //Check AscendingCustomizedLabellingButton is "正序"
            Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetAscendingCustomizedLabellingButton());

            //check labelingGrade count
            int count = Convert.ToInt32(input.InputData.LabellingLevelValues[0]);
            Assert.AreEqual(count, CustomizedLabellingSettings.GetLabellingGradeCount());

            //Check UOM
            for (int num = 0; num < Convert.ToInt32(input.InputData.LabellingLevelValues[0]); num++)
            {
                Assert.AreEqual(input.ExpectedData.UOM, CustomizedLabellingSettings.GetLabellingUOMValue(num + 1));
            }

            //Check lalelling level's left value 
            for (int num = 0; num < Convert.ToInt32(input.InputData.LabellingLevelValues[0]); num++)
            {
                Assert.AreEqual(input.ExpectedData.LabellingValue[0][num].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftValue(num + 1));
            }

            //Check lalelling level's right value 
            for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValues[0]) - 1; num++)
            {
                Assert.AreEqual(input.ExpectedData.LabellingValue[0][num].LabellingRightValue, CustomizedLabellingSettings.GetLabellingGradeRightValue(num + 1));
            }

            //Modify valid Labelling name. 
            CustomizedLabellingSettings.ClickModifyButton();
            CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonNames[1]);

            //Change Commodity from dropdown list.
            CustomizedLabellingSettings.SelectCommodityComboBox(input.InputData.Commodities[1]);

            //Change 能耗标识级别=4 from dropdown list.
            CustomizedLabellingSettings.SelectLabellingLevelComboBox(input.InputData.LabellingLevels[1]);

            //Change to select KPI type=公休比.
            CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[1]);

            //Check AscendingCustomizedLabellingButton is "倒序"
            Assert.AreEqual(input.ExpectedData.Order[1], CustomizedLabellingSettings.GetDescendingCustomizedLabellingButton());

            //Input Labelling Left Value
            for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValues[1]); num++)
            {
                CustomizedLabellingSettings.FillInLabellingLevelLeftValue(num + 1, input.InputData.LabellingValue[1][num].LabellingLeftValue);
            }

            //Click Save button.
            CustomizedLabellingSettings.ClickSaveButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            

            //Go to select "Modify to 自定义能效标识8"
            CustomizedLabellingSettings.FocusOnCustomizedLabelling(input.InputData.CommonNames[1]);
            CustomizedLabellingSettings.ClickModifyButton();

            //Change C right border from 0.5 to 3.
            CustomizedLabellingSettings.FillInLabellingLevelRightValue(3, input.InputData.LabellingValue[2][2].LabellingRightValue);

            //Click Save button.
            CustomizedLabellingSettings.ClickSaveButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(CustomizedLabellingSettings.IsInputValueErrTipsDisplayed());

            //Change B right border from 2 to 5.
            CustomizedLabellingSettings.FillInLabellingLevelRightValue(2,input.InputData.LabellingValue[3][1].LabellingRightValue);

            //Click Save button.
            CustomizedLabellingSettings.ClickSaveButton();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //· Modify successfully and go to view status display Labelling the same as before save.
            Assert.IsTrue(CustomizedLabellingSettings.IslabelingNameExist(input.ExpectedData.CommonName));

            //check the labeling's data
            Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
            Assert.AreEqual(input.ExpectedData.Commodity, CustomizedLabellingSettings.GetCommodityComboBoxValue());
            Assert.AreEqual(input.ExpectedData.KPIType, CustomizedLabellingSettings.GetKPITypeComboBoxValue());
            Assert.AreEqual(input.ExpectedData.LabellingLevel, CustomizedLabellingSettings.GetLabellingLevelComboBoxValue());

            //Check lalelling level's left value 
            for (int num = 0; num < Convert.ToInt32(input.ExpectedData.LabellingLevelValue); num++)
            {
                Assert.AreEqual(input.ExpectedData.LabellingValue[1][num].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftValue(num + 1));
            }

            //Check lalelling level's right value 
            for (int num = 1; num < Convert.ToInt32(input.ExpectedData.LabellingLevelValue) - 1; num++)
            {
                Assert.AreEqual(input.ExpectedData.LabellingValue[1][num].LabellingRightValue, CustomizedLabellingSettings.GetLabellingGradeRightValue(num + 1));
            }
        }
    }
}
