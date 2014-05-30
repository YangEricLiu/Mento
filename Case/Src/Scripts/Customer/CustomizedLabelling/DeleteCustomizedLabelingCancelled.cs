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
    public class DeleteCustomizedLabelingCancelled
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
        [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Delete-001")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(DeleteCustomizedLabelingCancelled), "TC-J1-FVT-CustomizedLabellingSetting-Delete-001")]
        public void DeleteCustomizedLabelingCancelled01(CustomizedLabellingSettingData input)
        {
            //Click a labeling from list 
            CustomizedLabellingSettings.FocusOnCustomizedLabelling(input.InputData.CommonName);
            Assert.AreEqual(input.ExpectedData.CommonName, CustomizedLabellingSettings.GetNameTextFieldValue());
            Assert.AreEqual(input.ExpectedData.Commodity, input.InputData.Commodity);
            Assert.AreEqual(input.ExpectedData.LabellingLevel, input.InputData.LabellingLevel);


            //click 删除 button.
            CustomizedLabellingSettings.ClickDeleteButton();
            TimeManager.LongPause();

            //After click confirmation 取消 button.
            CustomizedLabellingSettings.ClickCancelButton();

            //· The labeling still display in labeling list.
            Assert.IsTrue(CustomizedLabellingSettings.IslabelingNameExist(input.InputData.CommonName));


            //click 删除 button.
            CustomizedLabellingSettings.ClickDeleteButton();
            TimeManager.LongPause();

            //After click confirmation "X" button.
            CustomizedLabellingSettings.ClickCloseButton();

            // The labeling still display in labeling list.
            Assert.IsTrue(CustomizedLabellingSettings.IslabelingNameExist(input.InputData.CommonName));

            //Go to other page (e.g. HomePage) then back to customized labeling page to view.
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HomePage);
            TimeManager.LongPause();
            TimeManager.LongPause();
            CustomizedLabellingSettings.NavigatorToCustomizedLabelling();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //· The labeling still display in labeling list correctly.
            Assert.IsTrue(CustomizedLabellingSettings.IslabelingNameExist(input.InputData.CommonName));


        }
    }
}
