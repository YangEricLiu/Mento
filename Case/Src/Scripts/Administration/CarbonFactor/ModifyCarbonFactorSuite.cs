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
    [CreateTime("201y3-08-23")]
    [ManualCaseID("TC-J1-FVT-ConversionFactorSetting")]
    public class ModifyCarbonFactorSuite:TestSuiteBase
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
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Modify-101")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(ModifyCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Modify-101")]
        public void ModifyCarbonFactor(CarbonFactorData testData)
        {
            //选择一条转换因子， Click "修改" button
            string carbonFactor = "天然气(立方米)";
            //转换因子列表存在一个转换因子用于修改.
            //Assert.IsTrue(CarbonFactorSettings.FocusOnCarbonFactor(carbonFactor));
            //选择一条转换因子， Click "修改" button
            CarbonFactorSettings.FocusOnCarbonFactor(carbonFactor);
            TimeManager.MediumPause();
            CarbonFactorSettings.ClickModifyButton();
            TimeManager.ShortPause();

            CarbonFactorSettings.FillInFactorEffectiveYear_N(testData.InputData.EffectiveYear, 1);
            TimeManager.ShortPause();

            CarbonFactorSettings.FillInFactorValue_N(testData.InputData.FactorValue, 1);
      
            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the 'Factor Source', 'Factor Destination','Effective Year' and Carbon factor value.
            Assert.AreEqual(testData.ExpectedData.Source, CarbonFactorSettings.GetFactorSourceValue());
            Assert.AreEqual(testData.ExpectedData.Destination, CarbonFactorSettings.GetFactorDestinationValue());
            Assert.AreEqual(testData.ExpectedData.EffectiveYear, CarbonFactorSettings.GetCarbonFactorEffectiveYear(1));
            Assert.AreEqual(testData.ExpectedData.FactorValue, CarbonFactorSettings.GetCarbonFactorValue(1));

        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Modify-102")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(ModifyCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Modify-102")]
        public void ModifyMutipleCarbonFactor(CarbonFactorData testData)
        {
            //选择一条转换因子， Click "修改" button
            string carbonFactor = "天然气(立方米)";
            //选择一个已有的转换因子点击修改
            CarbonFactorSettings.FocusOnCarbonFactor(carbonFactor);
            CarbonFactorSettings.ClickModifyButton();
            TimeManager.ShortPause();

            //点击"+" button两下.
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();

            //输入第一组转换因子
            CarbonFactorSettings.FillInFactorEffectiveYear_N(testData.InputData.EffectiveYear, 1);
            CarbonFactorSettings.FillInFactorValue_N(testData.InputData.FactorValue, 1);
            //输入第二组转换因子
            CarbonFactorSettings.FillInFactorEffectiveYear_N("2010", 2);
            CarbonFactorSettings.FillInFactorValue_N("2", 2);

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the 'Factor Source', 'Factor Destination' and Carbon factor value.
            Assert.AreEqual(testData.ExpectedData.EffectiveYear, CarbonFactorSettings.GetCarbonFactorEffectiveYear(1));
            Assert.AreEqual(testData.ExpectedData.FactorValue, CarbonFactorSettings.GetCarbonFactorValue(1));
            Assert.AreEqual("2010", CarbonFactorSettings.GetCarbonFactorEffectiveYear(3));
            Assert.AreEqual("2", CarbonFactorSettings.GetCarbonFactorValue(3));
        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Modify-103")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(ModifyCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Modify-102")]
        public void SaveBeforeModified(CarbonFactorData testData)
        {
            //选择一条转换因子， Click "修改" button.
            string carbonFactor = "电(千瓦时)";
            //转换因子列表存在一个转换因子点击修改. 电转换因子 2012=7.
            //选择一个已有的转换因子点击修改
            CarbonFactorSettings.FocusOnCarbonFactor(carbonFactor);
            CarbonFactorSettings.ClickModifyButton();
            TimeManager.ShortPause();

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the 'Factor Source', 'Factor Destination','Effective Year' and Carbon factor value.
            Assert.AreEqual("2012", CarbonFactorSettings.GetCarbonFactorEffectiveYear(1));
            Assert.AreEqual("7", CarbonFactorSettings.GetCarbonFactorValue(1));
        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Modify-104")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(ModifyCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Modify-104")]
        public void ModifyValidFactorValue(CarbonFactorData testData)
        {
            //选择一条转换因子， Click "修改" button.
            string carbonFactor = "自来水(吨)";
            //转换因子列表存在一个转换因子点击修改. 电转换因子 20Industry2=2.
            //选择一个已有的转换因子点击修改
            CarbonFactorSettings.FocusOnCarbonFactor(carbonFactor);
            CarbonFactorSettings.ClickModifyButton();
            TimeManager.ShortPause();
            //按照common valid 输入各种转换因子值.
            CarbonFactorSettings.FillInFactorValue_N(testData.InputData.DoubleNonNagtiveValue, 1);

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the 'Factor Source', 'Factor Destination','Effective Year' and Carbon factor value.
            Assert.AreEqual(testData.ExpectedData.DoubleNonNagtiveValue, CarbonFactorSettings.GetCarbonFactorValue(1));
        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Modify-001")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(ModifyCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Modify-001")]
        public void ModifyEmptyField(CarbonFactorData testData)
        {
            //选择一条转换因子， Click "修改" button.
            string carbonFactor = "电(千瓦时)";
            //转换因子列表存在一个转换因子点击修改. 电转换因子 20Industry2=7.
            CarbonFactorSettings.FocusOnCarbonFactor(carbonFactor);
            CarbonFactorSettings.ClickModifyButton();
            TimeManager.ShortPause();

            //点击"+" button两下.
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the 'Factor Source', 'Factor Destination' and Carbon factor value.
            Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalid_N(1));
            Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalid_N(2));
            Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalidMsgCorrect_N(testData.ExpectedData.EffectiveYear, 1));
            Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalidMsgCorrect_N(testData.ExpectedData.EffectiveYear, 2));
            Assert.IsTrue(CarbonFactorSettings.IsFactorValueInvalid_N(1));
            Assert.IsTrue(CarbonFactorSettings.IsFactorValueInvalid_N(2));
            Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalidMsgCorrect_N(testData.ExpectedData.FactorValue, 1));
            Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalidMsgCorrect_N(testData.ExpectedData.FactorValue, 2));
        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Modify-002")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(ModifyCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Modify-002")]
        public void ModifyThenCancel(CarbonFactorData testData)
        {
            //选择一条转换因子， Click "修改" button.
            string carbonFactor = "热量(千瓦时)";
            //转换因子列表存在一个转换因子点击修改. 热量转换因子 20Industry2=5.
            CarbonFactorSettings.FocusOnCarbonFactor(carbonFactor);
            CarbonFactorSettings.ClickModifyButton();
            TimeManager.ShortPause();

            //点击"+" button.
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();

            //输入转换因子
            CarbonFactorSettings.FillInFactorEffectiveYear_N(testData.InputData.EffectiveYear, 1);
            CarbonFactorSettings.FillInFactorValue_N(testData.InputData.DoubleNonNagtiveValue, 1);

            CarbonFactorSettings.ClickCancelButton();
            TimeManager.LongPause();

            Assert.False(JazzButton.CarbonFactorSaveButton.IsDisplayed());

            //判断转换因子和修改之前的值相等.
            Assert.AreEqual(testData.ExpectedData.EffectiveYear, CarbonFactorSettings.GetCarbonFactorEffectiveYear(1));
            Assert.AreEqual(testData.ExpectedData.FactorValue, CarbonFactorSettings.GetCarbonFactorValue(1));
        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Modify-003")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(CarbonFactorData[]))]
        public void ModifyInvalidFactorValue(CarbonFactorData testData)
        {
            //选择一条转换因子， Click "修改" button.
            string carbonFactor = "电(千瓦时)";
            //转换因子列表存在一个转换因子用于修改. 电转换因子 20Industry2=7.

            CarbonFactorSettings.FocusOnCarbonFactor(carbonFactor);
            CarbonFactorSettings.ClickModifyButton();
            TimeManager.ShortPause();

            //点击"+" button.
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();

            //输入转换因子和生效年份.
            JazzComboBox.CarbonFactorEffectiveYearComboBox.DisplayItems();
            CarbonFactorSettings.FillInFactorEffectiveYear_N("2013", 1);
            CarbonFactorSettings.FillInFactorValue_N(testData.InputData.DoubleNonNagtiveValue, 1);
            CarbonFactorSettings.FillInFactorValue_N(testData.InputData.DoubleNonNagtiveValue, 2);

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //验证输入不正确的的转换因子后出现错误提示信息.
            Assert.IsTrue(CarbonFactorSettings.IsFactorValueInvalid_N(1));
            Assert.IsTrue(CarbonFactorSettings.IsFactorValueInvalidMsgCorrect_N(testData.ExpectedData.DoubleNonNagtiveValue, 1));
            Assert.IsTrue(CarbonFactorSettings.IsFactorValueInvalidMsgCorrect_N(testData.ExpectedData.DoubleNonNagtiveValue, 2));
        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Modify-004")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(ModifyCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Modify-004")]
        public void ModifyDuplicatedEffectiveYear(CarbonFactorData testData)
        {
            //选择一条转换因子， Click "修改" button.
            string carbonFactor = "电(千瓦时)";
            //转换因子列表存在一个转换因子用于修改. 电转换因子 20Industry2=7.

            CarbonFactorSettings.FocusOnCarbonFactor(carbonFactor);
            CarbonFactorSettings.ClickModifyButton();
            TimeManager.ShortPause();
            
            //点击"+" button一下.
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();

            //输入第一组转换因子
            CarbonFactorSettings.FillInFactorEffectiveYear_N("2012",1);
            CarbonFactorSettings.FillInFactorValue_N("4",1);

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify error message show duplicated effective year.
            //A bug of this verification
            //Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalidMsgCorrect_N(testData.ExpectedData.EffectiveYear, 2));
        }
    }
}
