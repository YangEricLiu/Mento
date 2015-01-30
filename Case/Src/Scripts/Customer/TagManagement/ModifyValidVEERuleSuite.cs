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

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Pearl")]
    [CreateTime("2015-01-04")]
    [ManualCaseID("TC-J1-FVT-ModifyVEECases-101")]
    public class ModifyValidVEERuleSuite : TestSuiteBase
    {
        private VEERuleSettings VEERuleSettings = JazzFunction.VEERuleSettings;

        [SetUp]
        public void CaseSetUp()
        {
            VEERuleSettings.VEERuleSettingsCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            VEERuleSettings.VEERuleSettingsCaseTearDown();
        }

        [Test]
        [CaseID("TC-J1-FVT-ModifyVEECases-101-1")]
        [MultipleTestDataSource(typeof(VEEData[]), typeof(ModifyValidVEERuleSuite), "TC-J1-FVT-ModifyVEECases-101-1")]
        public void ModifyWithoutChange(VEEData input)
        {
            //Click "Modify" button and input nothing to vee field
            VEERuleSettings.FocusOnVEEByName(input.InputData.OriginalName);
            TimeManager.LongPause();
            TimeManager.LongPause();
            VEERuleSettings.ClickModifyButton();
            TimeManager.LongPause();
            //Click "Save" button
            VEERuleSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(VEERuleSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VEERuleSettings.IsCancelButtonDisplayed());

           //   Verify that vee keep the same successfully
            VEERuleSettings.FocusOnVEEByName(input.InputData.OriginalName);
            Assert.AreEqual(input.ExpectedData.CommonName, VEERuleSettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.SpikeGT, VEERuleSettings.GetSpikeGTValue());
            Assert.AreEqual(input.ExpectedData.SpikeLT, VEERuleSettings.GetSpikeLTValue());
            Assert.AreEqual(input.ExpectedData.Special, VEERuleSettings.GetSpecialValue());
            Assert.AreEqual(input.ExpectedData.ScanInterval, VEERuleSettings.GetScanIntervalValue());
            Assert.AreEqual(input.ExpectedData.ScanDelay, VEERuleSettings.GetScanDelayValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-ModifyVEECases-101-2")]
        [MultipleTestDataSource(typeof(VEEData[]), typeof(ModifyValidVEERuleSuite), "TC-J1-FVT-ModifyVEECases-101-2")]
        public void ModifyThenSave(VEEData input)
        {
            //Click "Modify" button 
            VEERuleSettings.FocusOnVEEByName(input.InputData.CommonNameArray[0]);
            TimeManager.LongPause();
            VEERuleSettings.ClickModifyButton();
            TimeManager.LongPause();
            
            //Change Name, 正常峰/异常峰，特殊值values,扫描开始时间
            //var ManualTimeRange = input.InputData.ManualTimeRange;
            VEERuleSettings.FillInName(input.InputData.CommonName);
            VEERuleSettings.FillSpikeGT(input.InputData.SpikeGT);
            VEERuleSettings.FillSpikeLT(input.InputData.SpikeLT);
            VEERuleSettings.FillSpecial(input.InputData.Special);

            //Click "Save" button
            VEERuleSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(VEERuleSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VEERuleSettings.IsCancelButtonDisplayed());

            //   Verify that vee parameter saved successfully
            Assert.AreEqual(input.ExpectedData.CommonName, VEERuleSettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.SpikeGT, VEERuleSettings.GetSpikeGTValue());
            Assert.AreEqual(input.ExpectedData.SpikeLT, VEERuleSettings.GetSpikeLTValue());
            Assert.AreEqual(input.ExpectedData.Special, VEERuleSettings.GetSpecialValue());
            Assert.AreEqual(input.ExpectedData.ScanIntervalArray[0], VEERuleSettings.GetScanIntervalValue());
            Assert.AreEqual(input.ExpectedData.ScanDelayArray[0], VEERuleSettings.GetScanDelayValue());

            //select another vee rule "VEEAutoTest1"
            VEERuleSettings.FocusOnVEEByName(input.InputData.CommonNameArray[1]);
            TimeManager.LongPause();
            VEERuleSettings.ClickModifyButton();
            TimeManager.LongPause();

            //Check 空值， 负值，特殊值
            VEERuleSettings.CheckVEERule(input.InputData.VEERules[0]);
            VEERuleSettings.CheckVEERule(input.InputData.VEERules[1]);
            VEERuleSettings.CheckVEERule(input.InputData.VEERules[2]);

            //输入特殊值
            VEERuleSettings.FillSpecial(input.InputData.Special);

            //Uncheck spike normal checkbox
            VEERuleSettings.UnCheckVEERule(input.InputData.VEERules[3]);

            //Change scan interval
            VEERuleSettings.FillInIntervalAndDelay(input.InputData.ScanInterval, input.InputData.ScanDelay);

            //Click "Save" button
            VEERuleSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //   Verify that vee parameter saved successfully
            VEERuleSettings.FocusOnVEEByName(input.InputData.CommonNameArray[1]);
            Assert.AreEqual(input.ExpectedData.CommonNameArray[1], VEERuleSettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Special, VEERuleSettings.GetSpecialValue());
            Assert.AreEqual(input.ExpectedData.ScanIntervalArray[1], VEERuleSettings.GetScanIntervalValue());
            Assert.AreEqual(input.ExpectedData.ScanDelayArray[1], VEERuleSettings.GetScanDelayValue());

        }
    }
}
