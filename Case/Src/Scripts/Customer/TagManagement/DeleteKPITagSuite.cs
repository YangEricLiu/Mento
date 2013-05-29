using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.WebUserInterface.Controls;


namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-KPItagConfiguration-003")]
    [CreateTime("2013-02-06")]
    [Owner("Alice")]
    public class DeleteKPITagSuite : TestSuiteBase
    {
        private KPITagSettings KPITagSettings = JazzFunction.KPITagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            KPITagSettings.NavigatorToKPITagSetting();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }
        [Test]
        [CaseID("TC-J1-FVT-KPItagConfiguration-003-DeletebutCancel")]
        [Priority("1")]
        [Type("FVT")]

        public void DeleteKPItagbutCancel()
        {
            string tagcode = "KPI2";
            KPITagSettings.FocusOnKPITagcode(tagcode);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            KPITagSettings.ClickDeleteKPITagButton();
            TimeManager.LongPause();
            string msgText = KPITagSettings.GetMessageText();
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(msgText.Contains("确认删除KPI2"));
            KPITagSettings.CancelDeleteMagBox();
            //FunctionWrapper.WaitForLoadingDisappeared(5000);
            JazzMessageBox.LoadingMask.WaitLoading();
            Assert.IsTrue(KPITagSettings.KPITagIsExist(tagcode));
            TimeManager.ShortPause();
         }
        [Test]
        [CaseID("TC-J1-FVT-KPItagConfiguration-003-DeleteandSave")]
        [Priority("1")]
        [Type("FVT")]

        public void DeleteKPItagandSave()
        {
            string tagname = "KPI2";
            TimeManager.LongPause();
            TimeManager.LongPause();
            KPITagSettings.FocusOnKPITag(tagname);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            KPITagSettings.ClickDeleteKPITagButton();
            TimeManager.LongPause();
            string msgText = KPITagSettings.GetMessageText();
            Assert.IsTrue(msgText.Contains("确认删除KPI2"));
            KPITagSettings.ConfirmDeleteMagBox();
            //FunctionWrapper.WaitForLoadingDisappeared(5000);
            JazzMessageBox.LoadingMask.WaitLoading();
            Assert.IsFalse(KPITagSettings.KPITagIsNotDeleted(tagname));
            TimeManager.ShortPause();

        }
    }
}