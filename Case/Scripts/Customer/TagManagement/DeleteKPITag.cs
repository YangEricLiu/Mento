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
    [ManualCaseID("TC-J1-SmokeTest-004")]
    [CreateTime("2013-01-16")]
    [Owner("Alice")]
    public class DeleteKPITag : TestSuiteBase
    {
        private KPITagSettings KPITagSettings = JazzFunction.KPITagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            KPITagSettings.NavigatorToKPITagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            BrowserHandler.Refresh();
        }
        [Test]
        [CaseID("TA-DeleteKPITag-001")]
        [Priority("1")]
        [Type("Smoke")]

        public void DeleteKPItag()
        {
            string tagname = "KPI2";
            TimeManager.LongPause();
            TimeManager.LongPause();
            KPITagSettings.FocusOnKPITag(tagname);
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
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