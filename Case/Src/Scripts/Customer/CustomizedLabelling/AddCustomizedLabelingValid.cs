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
        public void AddCustomizedLabelingValid(CustomizedLabellingSettingData input)
        {
            //Click "+能效标识" button 
            CustomizedLabellingSettings.ClickAddCustomizedLabellingButton();

            for(int i=0;i<5;i++)
            {
                //Input valid Labelling name. 
                 CustomizedLabellingSettings.FillInNameTextField(input.InputData.Names[i]);

                //Select 能效标识级别 from dropdown list.
                CustomizedLabellingSettings.SelectCommodityComboBox(input.InputData.Commodity);

                //Select KPI type=昼夜比.
                CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[0]);
                Assert.AreSame(input.ExpectedData.KPITypes[0], input.InputData.KPITypes[0]);

                //Check AscendingCustomizedLabellingButton is "正序"
                 Assert.AreEqual("正序", CustomizedLabellingSettings.GetAscendingCustomizedLabellingButton());

                //Change to select KPI type=单位人口.
                CustomizedLabellingSettings.SelectKPITypeComboBox(input.InputData.KPITypes[1]);

                //Input labeling level





                //Save
                CustomizedLabellingSettings.ClickSaveButton();

                //Go to view status display Labelling successfully the same as before save.
                Assert.AreSame(input.ExpectedData.Name[i],CustomizedLabellingSettings.GetNameTextFieldValue());
                Assert.AreSame(input.ExpectedData.Commodity, input.InputData.Commodity);
                Assert.AreSame(input.ExpectedData.KPITypes[1], input.InputData.KPITypes[1]);

            }
            


        }
    }
        
}
