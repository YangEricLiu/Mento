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

namespace Mento.Script.Administration.CommodityAndUOMSetting
{
    [TestFixture]
    [Owner("Cathy")]
    [CreateTime("2014-9-25")]
    public class CommodityAndUOMSettingSuite : TestSuiteBase
    {
        private static CommodifyUomSetting CommodifyUomSetting = JazzFunction.CommodifyUomSetting;
        private PTagSettings PTagSettings = JazzFunction.PTagSettings;
        private VTagSettings VTagSettings = JazzFunction.VTagSettings;
        private CustomizedLabellingSettings CustomizedLabellingSettings = JazzFunction.CustomizedLabellingSettings;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.SelectCustomer("CommodityTestCustomer");
            PTagSettings.NavigatorToPtagSetting();
            TimeManager.MediumPause();

        }

        [TearDown]
        public void CaseTearDown()
        {
            
        }
        
        #region TestCase1 Verify Commoditys display correct
        [Test]
        [ManualCaseID("TC-J1-FVT-CommodityAndUOMSetting-View-101")]
        [CaseID("TC-J1-FVT-CommodityAndUOMSetting-View-101")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(CommodityAndUomData[]), typeof(CommodityAndUOMSettingSuite), "TC-J1-FVT-CommodityAndUOMSetting-View-101")]
        public void VerifyCommodityCorrect(CommodityAndUomData input)
        {
            HomePagePanel.SelectCustomer("CommodityTestCustomer");
            //Verify Commodity is Ptag setting page
            string Name1 = "Ptagtest1";
            CommodifyUomSetting.FocusOnPTagByName(Name1);
            TimeManager.LongPause();
            CommodifyUomSetting.ClickPModifyButton();
            TimeManager.LongPause();
            //Verify Commodity as expect.
            Assert.AreEqual(input.ExpectedData.Commoditys, CommodifyUomSetting.GetPCommodityComboBoxList());

            //Verify Commodity is Vtag setting page
            VTagSettings.NavigatorToVTagSetting();
            string Name2 = "Vtagtest1";
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            CommodifyUomSetting.FocusOnVTagByName(Name2);
            TimeManager.LongPause();
            TimeManager.LongPause();
            CommodifyUomSetting.ClickVModifyButton();
            TimeManager.LongPause();
            //Verify Commodity as expect.
            Assert.AreEqual(input.ExpectedData.Commoditys, CommodifyUomSetting.GetVCommodityComboBoxList());

            //Verify Commodity in Customize labeling page
            CustomizedLabellingSettings.NavigatorToCustomizedLabelling();
            string Name3 = "CustomizeLabeling1";
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            CommodifyUomSetting.FocusOnCustomizedLabelling(Name3);
            TimeManager.LongPause();
            CommodifyUomSetting.ClickCusLabelingModifyButton();
            TimeManager.LongPause();
            //Verify Commodity as expect.
            Assert.AreEqual(input.ExpectedData.Commoditys, CommodifyUomSetting.GetCCommodityComboBoxList());
        }
        #endregion
       
        #region TestCase1 Verify Commoditys display correct
        [Test]
        [ManualCaseID("TC-J1-FVT-CommodityAndUOMSetting-View-102")]
        [CaseID("TC-J1-FVT-CommodityAndUOMSetting-View-102"), CreateTime("2014-10-9"), Owner("Cathy")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(CommodityAndUomData[]), typeof(CommodityAndUOMSettingSuite), "TC-J1-FVT-CommodityAndUOMSetting-View-102")]
        public void VerifyUOMCorrect(CommodityAndUomData input)
        {
           
            //Verify UOM is Ptag setting page
            string Name1 = "Ptagtest1";
            CommodifyUomSetting.FocusOnPTagByName(Name1);
            TimeManager.LongPause();
            CommodifyUomSetting.ClickPModifyButton();
            TimeManager.LongPause();

            CommodifyUomSetting.SelectPCommodityComboBox(input.InputData.Commoditys[0]);
            //Verify UOM as expect.
            Assert.AreEqual(input.ExpectedData.UOMs, CommodifyUomSetting.GetPUOMsComboBoxList());

            //Verify UOM is Vtag setting page
            VTagSettings.NavigatorToVTagSetting();
            string Name2 = "Vtagtest1";
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            CommodifyUomSetting.FocusOnVTagByName(Name2);
            TimeManager.LongPause();
            TimeManager.LongPause();
            CommodifyUomSetting.ClickVModifyButton();
            TimeManager.LongPause();
            CommodifyUomSetting.SelectVCommodityComboBox(input.InputData.Commoditys[0]);
            //Verify UOM as expect.
            Assert.AreEqual(input.ExpectedData.UOMs, CommodifyUomSetting.GetVUOMsComboBoxList());

            //Verify UOM in Customize labeling page
            CustomizedLabellingSettings.NavigatorToCustomizedLabelling();
            string Name3 = "CustomizeLabeling1";
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            CommodifyUomSetting.FocusOnCustomizedLabelling(Name3);
            TimeManager.LongPause();
            CommodifyUomSetting.ClickCusLabelingModifyButton();
            TimeManager.LongPause();
            CommodifyUomSetting.SelectCCommodityComboBox(input.InputData.Commoditys[0]);
            //Verify UOM as expect.
            Assert.AreEqual(input.ExpectedData.UOMs, CommodifyUomSetting.GetCUOMsComboBoxList());
        }
        #endregion
     

    }
}
