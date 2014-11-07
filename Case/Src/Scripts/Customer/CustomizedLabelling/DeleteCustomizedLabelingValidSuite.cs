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
    public class DeleteCustomizedLabelingValidSuite
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
        [CaseID("TC-J1-FVT-CustomizedLabellingSetting-Delete-101")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CustomizedLabellingSettingData[]), typeof(DeleteCustomizedLabelingValidSuite), "TC-J1-FVT-CustomizedLabellingSetting-Delete-101")]
        public void DeleteCustomizedLabelingValid01(CustomizedLabellingSettingData input)
        {
            //Click a labeling from list 
            CustomizedLabellingSettings.FocusOnCustomizedLabelling(input.InputData.CommonNames[0]);
            Assert.AreEqual(input.ExpectedData.CommonNames[0], CustomizedLabellingSettings.GetNameTextFieldValue());
            Assert.AreEqual(input.ExpectedData.Commodity, input.InputData.Commodity);
            Assert.AreEqual(input.ExpectedData.LabellingLevel, input.InputData.LabellingLevel);


            //click 删除 button.
            CustomizedLabellingSettings.ClickDeleteButton();
            TimeManager.LongPause();

            //After click confirmation 确定 button.
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //Go to labeling list to check.
            // Deleted labeling can't display in labeling list correctly.
            Assert.IsFalse(CustomizedLabellingSettings.IslabelingNameExist(input.InputData.CommonNames[0]));

            //Go to other page (e.g. HomePage) then back to customized labeling page to view.
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HomePage);
            TimeManager.LongPause();
            TimeManager.LongPause();
            CustomizedLabellingSettings.NavigatorToCustomizedLabelling();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //· The labeling still Not display in labeling list correctly.
            Assert.IsFalse(CustomizedLabellingSettings.IslabelingNameExist(input.InputData.CommonName));

        }


    }
}
