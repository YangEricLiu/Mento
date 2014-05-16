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
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.Administration.CarbonFactor
{
    [TestFixture]
    [Owner("Nancy")]
    [CreateTime("2013-08-23")]
    [ManualCaseID("TC-J1-FVT-ConversionFactorSetting")]
    public class DeleteCarbonFactorSuite:TestSuiteBase
    {
        private static CarbonFactorSettings CarbonFactorSettings = JazzFunction.CarbonFactorSettings;
        [SetUp]
        public void CaseSetUp()
        {
            CarbonFactorSettings.NavigatorToCarbonFactorSettings();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            CarbonFactorSettings.NavigatorToTimeSettings();
        }
                
        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Delete-001")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(DeleteCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Delete-001")]
        public void DeleteAndCancel(CarbonFactorData testData)
        {
            //选择一条转换因子， Click "修改" button
            //转换因子列表存在一个转换因子用于删除.
            CarbonFactorSettings.FocusOnCarbonFactor(testData.ExpectedData.Source);
            TimeManager.MediumPause();

            //选择一条转换因子， Click "删除" button.
            CarbonFactorSettings.ClickDeleteButton();
            TimeManager.LongPause();
            
            //验证弹出消息框包含信息.
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(testData.ExpectedData.Source));

            //在确认消息框点击取消.
            JazzMessageBox.MessageBox.GiveUp();

            //Verify carbon factor still exist and the 'Factor Source', 'Factor Destination' and Carbon factor value keep.
            Assert.AreEqual(testData.ExpectedData.Source, CarbonFactorSettings.GetFactorSourceValue());
            Assert.AreEqual(testData.ExpectedData.Destination, CarbonFactorSettings.GetFactorDestinationValue());
            Assert.AreEqual(testData.ExpectedData.EffectiveYear, CarbonFactorSettings.GetCarbonFactorEffectiveYear(1));
            Assert.AreEqual(testData.ExpectedData.FactorValue, CarbonFactorSettings.GetCarbonFactorValue(1));

            CarbonFactorSettings.ClickCancelButton();
        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Delete-002")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(DeleteCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Delete-002")]
        public void DeleteAndClose(CarbonFactorData testData)
        {
            //选择一条转换因子， Click "修改" button
            //转换因子列表存在一个转换因子用于删除.
            CarbonFactorSettings.FocusOnCarbonFactor(testData.ExpectedData.Source);
            TimeManager.MediumPause();

            //选择一条转换因子， Click "删除" button.
            CarbonFactorSettings.ClickDeleteButton();

            //在确认消息框点击取消.
            JazzMessageBox.MessageBox.Close();

            //Verify carbon factor still exist and the 'Factor Source', 'Factor Destination' and Carbon factor value keep.
            Assert.AreEqual(testData.ExpectedData.Source, CarbonFactorSettings.GetFactorSourceValue());
            Assert.AreEqual(testData.ExpectedData.Destination, CarbonFactorSettings.GetFactorDestinationValue());
            Assert.AreEqual(testData.ExpectedData.EffectiveYear, CarbonFactorSettings.GetCarbonFactorEffectiveYear(1));
            Assert.AreEqual(testData.ExpectedData.FactorValue, CarbonFactorSettings.GetCarbonFactorValue(1));

            CarbonFactorSettings.ClickCancelButton();
        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Delete-101")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(DeleteCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Delete-101")]
        public void DeleteAndConfirm(CarbonFactorData testData)
        {
            //选择一条转换因子， Click "修改" button
            //转换因子列表存在一个转换因子用于删除.
            CarbonFactorSettings.FocusOnCarbonFactor(testData.InputData.Source);
            TimeManager.MediumPause();

            //选择一条转换因子， Click "删除" button.
            CarbonFactorSettings.ClickDeleteButton();

            //在确认消息框点击确认.
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //删除成功后不再显示修改按钮.
            Assert.False(JazzButton.CarbonFactorModifyButton.IsDisplayed());

            //判断转换因子删除成功以后，再次新建时，原因子下拉列表包含删除成功的项.
            CarbonFactorSettings.PrepareToAddCarbonFactor();
            TimeManager.ShortPause();

            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();

            //输入和删除成功完全一样的转换因子并保存.
            CarbonFactorSettings.SelectFactorSource(testData.InputData.Source);
            CarbonFactorSettings.FillInFactorEffectiveYear_N(testData.InputData.EffectiveYear, 1);
            TimeManager.ShortPause();
            CarbonFactorSettings.FillInFactorValue_N(testData.InputData.FactorValue, 1);

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();
            //验证保存成功.
            Assert.AreEqual(testData.InputData.Source, CarbonFactorSettings.GetFactorSourceValue());
            Assert.AreEqual(testData.ExpectedData.EffectiveYear, CarbonFactorSettings.GetCarbonFactorEffectiveYear(1));
            Assert.AreEqual(testData.ExpectedData.FactorValue, CarbonFactorSettings.GetCarbonFactorValue(1));
        }
    }
}
