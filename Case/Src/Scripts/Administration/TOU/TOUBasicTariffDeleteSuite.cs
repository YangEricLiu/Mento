using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Administration;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Administration.TOU
{
    [TestFixture]
    [Owner("Amy")]
    [CreateTime("2013-03-13")]    
    public class TOUBasicTariffDeleteSuite : TestSuiteBase
    {
        private static TOUBasicTariffSettings TOUBasicTariffSettings = JazzFunction.TOUBasicTariffSettings;
        [SetUp]
        public void CaseSetUp()
        {
            TOUBasicTariffSettings.NavigatorToPriceSettings();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        #region TestCase1 DeleteTOUSuccessful
        /// <summary>
        /// Pre-condition: Prepare a TOU with name '价格未被引用For删除确认', make sure it is NOT being used by any hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Delete-101")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Delete-101")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffDeleteSuite), "TC-J1-FVT-TOUTariffSettingBasic-Delete-101")]
        public void DeleteTOUSuccessful(TOUBasicTariffData testData)
        {
            //Select a TOU, make sure it is not beeing used by any hierarchy node.
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName);

            //Click 'Delete' button
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickBasicPropertyDeleteButton();

            //Click 'Confirm' button on the confirmation window.
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickMsgBoxConfirmButton();

            TimeManager.MediumPause();

            //Verify that the TOU is deleted successfully and NOT exists in the list.
            Assert.IsFalse(TOUBasicTariffSettings.IsTOUExist(testData.InputData.CommonName));
        }
        #endregion

        #region TestCase2 DeleteTOUCancelled
        /// <summary>
        /// Pre-condition: Prepare a TOU with name '价格未被引用For删除取消', make sure it is NOT being used by any hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Delete-001")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Delete-001")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffDeleteSuite), "TC-J1-FVT-TOUTariffSettingBasic-Delete-001")]
        public void DeleteTOUCancelled(TOUBasicTariffData testData)
        {
            //Select a TOU, make sure it is not beeing used by any hierarchy node.
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName);        
            
            //Click 'Delete' button
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickBasicPropertyDeleteButton();

            //Click 'Cancel' button to cancel the deletion.
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickMsgBoxCancelButton();

            //Select the TOU again.
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName);

            //Click 'Delete' button
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickBasicPropertyDeleteButton();

            //Click 'x' icon to close the deletion confirmation popup.
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickMsgBoxCloseButton();

            //Verify that the TOU is not deleted when cancel or close the window, and still exists in the list.
            TimeManager.ShortPause();
            Assert.IsTrue(TOUBasicTariffSettings.IsTOUExist(testData.InputData.CommonName));
        }
        #endregion

        #region TestCase3 DeleteTOUFailed
        /// <summary>
        /// Pre-condition: Prepare a TOU with name '价格已被引用For删除', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Delete-002")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Delete-002")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffDeleteSuite), "TC-J1-FVT-TOUTariffSettingBasic-Delete-002")]
        public void DeleteTOUFailed(TOUBasicTariffData testData)
        {
            //Select a TOU, make sure it is not beeing used by any hierarchy node.
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName);

            //Click 'Delete' button
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickBasicPropertyDeleteButton();

            //Click 'Confirm' button to confirm the deletion.
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickMsgBoxConfirmButton();

            //Verify that deletion failed and message like "TOU has been used and can't be modified or deleted" pops up.
            //此处注意message是否要使用test data中另一个单独的字段，而非commonname？
            Assert.IsTrue(TOUBasicTariffSettings.IsPopMsgCorrect(testData.ExpectedData));
            TimeManager.ShortPause();

            //Click 'Confirm' button to close the deletion failed message box.
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickMsgBoxConfirmButton();
            
            //Verify that the TOU is not deleted and still exists in the list.
            TimeManager.ShortPause();
            Assert.IsTrue(TOUBasicTariffSettings.IsTOUExist(testData.InputData.CommonName));
        }
        #endregion
        
    }
}
