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
    public class AddInvalidCustomizedLabeling
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
        [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Add-001")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(AddInvalidCustomizedLabeling), "TC-J1-FVT-CustomizedLabellingSetting-Add-001")]
        public void AddCustomizedLabelingCancelled(CustomizedLabellingSettingData input)
        {
            //Click "+能效标识" button 
            CustomizedLabellingSettings.ClickAddCustomizedLabellingButton();
            TimeManager.LongPause();

            // Get labelinglist's row count
            int i=CustomizedLabellingSettings.GetCustomizedLabellingListCount();

            //Click Cancel button before input.
            CustomizedLabellingSettings.ClickUpdateButton();

            //Cancel and there isn't any labeling added to list.
            int j = CustomizedLabellingSettings.GetCustomizedLabellingListCount();
            Assert.AreEqual(i, j);

            //Click "+能效标识" button 
            CustomizedLabellingSettings.ClickAddCustomizedLabellingButton();
            TimeManager.LongPause();

            //Input all fields :CommonName="自定义能效标识2"，Commdodity=电，能效标识级别=4，KPI type=单位人口.
            CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonName);
            TimeManager.MediumPause();
            CustomizedLabellingSettings.SelectCommodityComboBox(input.InputData.Commodity);
            CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPIType);
            CustomizedLabellingSettings.SelectCustomizedLabellingLevelComboBox(input.InputData.LabellingLevel);

            //check labelingGrade count
            Assert.AreEqual(input.InputData.LabellingLevel,CustomizedLabellingSettings.GetCustomizedLabellingListCount());

            //Check AscendingCustomizedLabellingButton is "正序"
            Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetDescendingCustomizedLabellingButton());

            //Input Labelling Left Value
            int count = 0;
            //count = Int32.Parse(input.ExpectedData.LabellingLevel);
            //Convert.ToInt32(input.ExpectedData.LabellingLevel);
            for (int m = 1; m < 4; m++)
            {
                CustomizedLabellingSettings.FillInLabellingLevelLeftValue(m+ 1, input.InputData.LabellingValue[0][m].LabellingLeftValue);
            }

            //Click Cancel button.
            CustomizedLabellingSettings.ClickUpdateButton();

            //·Cancel and there isn't any labeling added to list.
            Assert.AreEqual(j, CustomizedLabellingSettings.GetCustomizedLabellingListCount());

            //All input field cleared.
  




        }

        [Test]
        [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Add-002")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(AddInvalidCustomizedLabeling), "TC-J1-FVT-CustomizedLabellingSetting-Add-002")]
        public void AddCustomizedLabelingInvalid(CustomizedLabellingSettingData input)
        {
            //Click "+能效标识" button 
            CustomizedLabellingSettings.ClickAddCustomizedLabellingButton();
            TimeManager.LongPause();

            //Click Save button before input.
            CustomizedLabellingSettings.ClickSaveButton();

            //·Red line and error message display at 名称.
            //Red line and error message display at A-E Levels value input fields.
            Assert.AreEqual(input.ExpectedData.CommonNames[1],CustomizedLabellingSettings.GetLabellingNameInvalidTips());


            //Click Cancel button.Click "+能效标识" button 
            CustomizedLabellingSettings.ClickUpdateButton();
            CustomizedLabellingSettings.ClickAddCustomizedLabellingButton();
            TimeManager.LongPause();

            //Input all fields :CommonName="自定义能效标识1"，Commdodity=电，能效标识级别=4，KPI type=单位人口.
            CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonName);
            TimeManager.MediumPause();
            CustomizedLabellingSettings.SelectCommodityComboBox(input.InputData.Commodity);
            CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPIType);
            CustomizedLabellingSettings.SelectCustomizedLabellingLevelComboBox(input.InputData.LabellingLevel);

            //check labelingGrade count
            Assert.AreEqual(input.InputData.LabellingLevel, CustomizedLabellingSettings.GetCustomizedLabellingListCount());

            //Check AscendingCustomizedLabellingButton is "正序"
            Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetDescendingCustomizedLabellingButton());

            //Input Labelling Left Value
            int count = 0;
            //count = Int32.Parse(input.ExpectedData.LabellingLevel);
            //Convert.ToInt32(input.ExpectedData.LabellingLevel);
            for (int m = 1; m < 4; m++)
            {
                CustomizedLabellingSettings.FillInLabellingLevelLeftValue(m + 1, input.InputData.LabellingValue[0][m].LabellingLeftValue);
            }

            //Click Save button.
            CustomizedLabellingSettings.ClickSaveButton();

            //· All redline disappeared.The Labelling save successfully.
            //Go to view status display Labelling successfully the same as before save.
            Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
            Assert.AreEqual(input.ExpectedData.Commodity, input.InputData.Commodity);
            Assert.AreEqual(input.ExpectedData.LabellingLevel, input.InputData.LabellingLevel);
            Assert.AreEqual(input.ExpectedData.KPITypes[1], input.InputData.KPITypes[1]);

            //Check lalelling level's right border 
            for (int m = 1; m < 5; m++)
            {
                Assert.AreEqual(input.ExpectedData.LabellingValue[0][m + 1].LabellingLeftValue, CustomizedLabellingSettings.GetLabellingGradeRightValue(m + 1));
            }


            //The labelling name/create user/create time display in labelling grid. 
            CustomizedLabellingSettings.IslabelingNameExist(input.InputData.CommonName);





        }


    }
}
