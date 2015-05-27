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
    [TestFixture]
    public class ModifyCustomizedLabelingInvalidSuite
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
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Modify-001")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(ModifyCustomizedLabelingInvalidSuite), "TC-J1-FVT-CustomizedLabellingSetting-Modify-001")]
        public void ModifyCustomizedLabelingCancelled(CustomizedLabellingSettingData input)
        {
            //Click a labeling  from list and click 修改 button.
            CustomizedLabellingSettings.FocusOnCustomizedLabelling(input.InputData.CommonNames[0]);
            TimeManager.LongPause();

            //Click Cancel button directly.
            CustomizedLabellingSettings.ClickCancelButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //check the labeling's data
            Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
            Assert.AreEqual(input.ExpectedData.Commodity, CustomizedLabellingSettings.GetCommodityComboBoxValue());
            Assert.AreEqual(input.ExpectedData.KPIType, CustomizedLabellingSettings.GetKPITypeComboBoxValue());
            Assert.AreEqual(input.ExpectedData.LabellingLevel, CustomizedLabellingSettings.GetLabellingLevelComboBoxValue());

            //check labelingGrade Firstlabel&Lastlabel.
            Assert.AreEqual(input.ExpectedData.Firstlabels[0], CustomizedLabellingSettings.GetLabellingGradeFirstLabel());
            Assert.AreEqual(input.ExpectedData.Lastlabels[0], CustomizedLabellingSettings.GetLabellingGradeLastLabel());

            //Check AscendingCustomizedLabellingButton is "正序"
            Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetAscendingCustomizedLabellingButton());

            //check labelingGrade count
            int count = Convert.ToInt32(input.InputData.LabellingLevelValues[0]);
            Assert.AreEqual(count, CustomizedLabellingSettings.GetLabellingGradeCount());

            //这里有个问题，对于中文版，有些单位还是习惯性的用缩写英文表示，没有显示成中文，这个后续会和UI确认
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

            //Click labeling "自定义能效标识9" from list and click 修改 button.
            CustomizedLabellingSettings.FocusOnCustomizedLabelling(input.InputData.CommonNames[0]);
            CustomizedLabellingSettings.ClickModifyButton();

            // Change all fields as TestData. 
            CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonNames[1]);
            CustomizedLabellingSettings.SelectCommodityComboBox(input.InputData.Commodities[1]);
            CustomizedLabellingSettings.SelectLabellingLevelComboBox(input.InputData.LabellingLevels[1]);
            CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[1]);

            //Input Labelling Left Value
            for (int num = 1; num < Convert.ToInt32(input.InputData.LabellingLevelValues[1]); num++)
            {
                CustomizedLabellingSettings.FillInLabellingLevelLeftValue(num + 1, input.InputData.LabellingValue[1][num].LabellingLeftValue);
            }

            //Click Cancel button directly.
            CustomizedLabellingSettings.ClickCancelButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //Go to select "Modify to 自定义能效标识9"
            CustomizedLabellingSettings.FocusOnCustomizedLabelling(input.InputData.CommonNames[0]);
            CustomizedLabellingSettings.ClickModifyButton();

            //he labeling display view status before modify. 
            //check the labeling's data
            Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
            Assert.AreEqual(input.ExpectedData.Commodity, CustomizedLabellingSettings.GetCommodityComboBoxValue());
            Assert.AreEqual(input.ExpectedData.KPIType, CustomizedLabellingSettings.GetKPITypeComboBoxValue());
            Assert.AreEqual(input.ExpectedData.LabellingLevel, CustomizedLabellingSettings.GetLabellingLevelComboBoxValue());

            //Check AscendingCustomizedLabellingButton is "倒序"
            Assert.AreEqual(input.ExpectedData.Order[1], CustomizedLabellingSettings.GetDescendingCustomizedLabellingButton());

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
        }

        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Modify-002")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(ModifyCustomizedLabelingInvalidSuite), "TC-J1-FVT-CustomizedLabellingSetting-Modify-002")]
        public void ModifyCustomizedLabellingWithoutChange(CustomizedLabellingSettingData input)
        {
            //Click an exist labeling from list and click 修改 button.
            CustomizedLabellingSettings.FocusOnCustomizedLabelling(input.InputData.CommonName);
            TimeManager.LongPause();

            //Click Save button.
            CustomizedLabellingSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //· labeling save to labeling list successfully without modified any fields.
            Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
            Assert.AreEqual(input.ExpectedData.Commodity, CustomizedLabellingSettings.GetCommodityComboBoxValue());
            Assert.AreEqual(input.ExpectedData.KPIType, CustomizedLabellingSettings.GetKPITypeComboBoxValue());
            Assert.AreEqual(input.ExpectedData.LabellingLevel, CustomizedLabellingSettings.GetLabellingLevelComboBoxValue());

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
            for (int num = 0; num < Convert.ToInt32(input.InputData.LabellingLevelValue); num++)
            {
                Assert.AreEqual(input.ExpectedData.UOM, CustomizedLabellingSettings.GetLabellingUOMValue(num + 1));
            }

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
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Modify-003")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(ModifyCustomizedLabelingInvalidSuite), "TC-J1-FVT-CustomizedLabellingSetting-Modify-003")]
        public void ModifyCustomizedLabelingInvalid(CustomizedLabellingSettingData input)
        {
            //Click an exist labeling from list and click 修改 button.
            CustomizedLabellingSettings.FocusOnCustomizedLabelling(input.InputData.CommonNames[0]);
            TimeManager.LongPause();

            //Change name to invalid as validation rule.Click Save button.
            CustomizedLabellingSettings.ClickModifyButton();
            CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonNames[1]);
            CustomizedLabellingSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //·Red line and error message display at 名称.
            Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetLabellingNameInvalidTips());
           
            // Change labelling levels value fields to invalid as validation rule.
            CustomizedLabellingSettings.FillInLabellingLevelLeftValue(1, input.InputData.LabellingValue[1][0].LabellingLeftValue);
            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.LabellingValue[1][0].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeLeftInvalidMassage(1));
        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Modify-004")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(ModifyCustomizedLabelingInvalidSuite), "TC-J1-FVT-CustomizedLabellingSetting-Modify-004")]
        public void ModifyCustomizedLabellingDuplicatedName(CustomizedLabellingSettingData input)
        {
            //Click an exist labeling from list and click 修改 button.
            CustomizedLabellingSettings.FocusOnCustomizedLabelling(input.InputData.CommonNames[0]);
            TimeManager.LongPause();

            //Change name to the same as exist labelling.Click Save button.
            CustomizedLabellingSettings.ClickModifyButton();
            CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonNames[1]);
            CustomizedLabellingSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //·Redline display at name.
            Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetLabellingNameInvalidTips());
        }

    }
}
