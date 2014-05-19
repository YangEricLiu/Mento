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
   public class AddCustomizedLabelingValid
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
        [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(AddCustomizedLabelingValid), "TC-J1-FVT-CustomizedLabellingSetting-Add-101")]
        public void AddCustomizedLabelingValidSuite(CustomizedLabellingSettingData input)
        {
            //Click "+能效标识" button 
            CustomizedLabellingSettings.ClickAddCustomizedLabellingButton();


            //Input valid Labelling name. 
            CustomizedLabellingSettings.FillInNameTextField(input.InputData.CommonName);

            //Select 能效标识级别 from dropdown list.
            CustomizedLabellingSettings.SelectCommodityComboBox(input.InputData.Commodity);

            //Select KPI type=昼夜比.
            CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[0]);
            Assert.AreSame(input.ExpectedData.KPITypes[0], input.InputData.KPITypes[0]);

            //Check AscendingCustomizedLabellingButton is "正序"
            Assert.AreEqual(input.ExpectedData.Order[0], CustomizedLabellingSettings.GetAscendingCustomizedLabellingButton());

            //Change to select KPI type=单位人口.
            CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[1]);

            //Input Labelling level A<=5.144/5.136.
            CustomizedLabellingSettings.FillInLabellingLevelLeftValue(0, "5.144");

            //Auto change level B left border=5.14,Auto round level A<=5.14
            Assert.AreEqual(input.ExpectedData.LabellingValue[0].LabellingLeftValue[0],CustomizedLabellingSettings.GetLabellingLevelLeftValue(0));
            Assert.AreEqual(input.ExpectedData.LabellingValue[1].LabellingLeftValue[1], CustomizedLabellingSettings.GetLabellingLevelLeftValue(0));

            //Input Labelling level C=10.
            CustomizedLabellingSettings.FillInLabellingLevelLeftValue(2, "5.144");

            //Auto change level B right border=10.
            Assert.AreEqual(input.ExpectedData.LabellingValue[1].LabellingRightValue[1],CustomizedLabellingSettings.GetLabellingLevelLeftValue(2));

            //Save
            CustomizedLabellingSettings.ClickSaveButton();

            //Go to view status display Labelling successfully the same as before save.
            Assert.AreSame(input.ExpectedData.CommonName,CustomizedLabellingSettings.GetNameTextFieldValue());
            Assert.AreSame(input.ExpectedData.Commodity, input.InputData.Commodity);
            Assert.AreSame(input.ExpectedData.KPITypes[1], input.InputData.KPITypes[1]);
            Assert.AreEqual(input.ExpectedData.LabellingValue[2].LabellingLeftValue[2], CustomizedLabellingSettings.GetLabellingLevelLeftValue(2));

            //The labelling name/create user/create time display in labelling grid. 
            CustomizedLabellingSettings.IslabelingNameExist(input.InputData.CommonName);
        }
    }
        
}
