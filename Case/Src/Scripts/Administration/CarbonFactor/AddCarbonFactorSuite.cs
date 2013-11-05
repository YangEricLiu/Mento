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
    public class AddCarbonFactorSuite:TestSuiteBase
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
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Add-101")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(AddCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Add-101")]
        public void AddCarbonFactor(CarbonFactorData testData)
        {
            //Click "+转换因子" button
            CarbonFactorSettings.PrepareToAddCarbonFactor();
            TimeManager.ShortPause();

            CarbonFactorSettings.SelectFactorSource(testData.InputData.Source);
            //Click "+" to add carbonfactor
            CarbonFactorSettings.ClickAddMoreRangesButton();

            CarbonFactorSettings.FillInFactorEffectiveYear_N(testData.InputData.EffectiveYear, 1);
            TimeManager.ShortPause();

            CarbonFactorSettings.FillInFactorValue_N(testData.InputData.FactorValue, 1);
      
            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the 'Factor Source', 'Factor Destination' and Carbon factor value.
            Assert.AreEqual(testData.InputData.Source, CarbonFactorSettings.GetFactorSourceValue());
            Assert.AreEqual(testData.ExpectedData.Destination, CarbonFactorSettings.GetFactorDestinationValue());
            Assert.AreEqual(testData.ExpectedData.EffectiveYear, CarbonFactorSettings.GetCarbonFactorEffectiveYear(1));
            Assert.AreEqual(testData.ExpectedData.FactorValue, CarbonFactorSettings.GetCarbonFactorValue(1));

            //判断转换因子新建成功以后，再次新建时，原因子下拉列表不再包含成功的项.
            CarbonFactorSettings.PrepareToAddCarbonFactor();
            TimeManager.ShortPause();
            JazzComboBox.CarbonFactorSourceComboBox.DisplayItems();
            Assert.False(JazzComboBox.CarbonFactorSourceComboBox.IsComboBoxItemExisted(testData.InputData.Source));
            CarbonFactorSettings.ClickCancelButton();
        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Add-102")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(AddCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Add-102")]
        public void AddMutipleCarbonFactor(CarbonFactorData testData)
        {
            //Click "+转换因子" button
            CarbonFactorSettings.PrepareToAddCarbonFactor();
            TimeManager.ShortPause();
            CarbonFactorSettings.SelectFactorSource(testData.InputData.Source);

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
            CarbonFactorSettings.FillInFactorValue_N("4", 2);

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify 第二组 the 'Factor Source', 'Factor Destination' and Carbon factor value.
            Assert.AreEqual(testData.ExpectedData.EffectiveYear, CarbonFactorSettings.GetCarbonFactorEffectiveYear(2));
            Assert.AreEqual(testData.ExpectedData.FactorValue, CarbonFactorSettings.GetCarbonFactorValue(2));
        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Add-001")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(AddCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Add-001")]
        public void EmptySourceField(CarbonFactorData testData)
        {
            //Click "+转换因子" button
            CarbonFactorSettings.PrepareToAddCarbonFactor();
            TimeManager.ShortPause();

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the 'Factor Source'.
            Assert.IsTrue(CarbonFactorSettings.IsFactorSourceInvalid());
            Assert.IsTrue(CarbonFactorSettings.IsFactorSourceInvalidMsgCorrect(testData.ExpectedData.Source));

            CarbonFactorSettings.ClickCancelButton();
        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Add-002")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(AddCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Add-002")]
        public void EmptyAllField(CarbonFactorData testData)
        {
            //Click "+转换因子" button
            CarbonFactorSettings.PrepareToAddCarbonFactor();
            TimeManager.ShortPause();

            //点击"+" button两下.
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the 'Factor Source', 'Factor Destination' and Carbon factor value.
            Assert.IsTrue(CarbonFactorSettings.IsFactorSourceInvalid());
            Assert.IsTrue(CarbonFactorSettings.IsFactorSourceInvalidMsgCorrect(testData.ExpectedData.Source));
            Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalid_N(1));
            Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalid_N(2));
            Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalidMsgCorrect_N(testData.ExpectedData.EffectiveYear, 1));
            Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalidMsgCorrect_N(testData.ExpectedData.EffectiveYear, 2));
            Assert.IsTrue(CarbonFactorSettings.IsFactorValueInvalid_N(1));
            Assert.IsTrue(CarbonFactorSettings.IsFactorValueInvalid_N(2));
            Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalidMsgCorrect_N(testData.ExpectedData.FactorValue, 1));
            Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalidMsgCorrect_N(testData.ExpectedData.FactorValue, 2));

            CarbonFactorSettings.ClickCancelButton();
        }

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Add-003")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(AddCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Add-003")]
        public void AddThenCancel(CarbonFactorData testData)
        {
            //Click "+转换因子" button
            CarbonFactorSettings.PrepareToAddCarbonFactor();
            TimeManager.ShortPause();
            CarbonFactorSettings.SelectFactorSource(testData.InputData.Source);

            //点击"+" button.
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();

            //输入转换因子
            CarbonFactorSettings.FillInFactorEffectiveYear_N(testData.InputData.EffectiveYear, 1);
            CarbonFactorSettings.FillInFactorValue_N(testData.InputData.FactorValue, 1);

            CarbonFactorSettings.ClickCancelButton();
            TimeManager.LongPause();

            Assert.False(JazzButton.CarbonFactorSaveButton.IsDisplayed());

            //判断转换因子新建取消以后，再次新建时，原因子下拉列表包含新建失败的项.
            CarbonFactorSettings.PrepareToAddCarbonFactor();
            TimeManager.ShortPause();
            JazzComboBox.CarbonFactorSourceComboBox.DisplayItems();
            Assert.IsTrue(JazzComboBox.CarbonFactorSourceComboBox.IsComboBoxItemExisted(testData.InputData.Source));

            CarbonFactorSettings.ClickCancelButton();
        }

        /*
        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Add-004")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(CarbonFactorData[]))]
        public void AddInvalidFactorValue(CarbonFactorData testData)
        {
            //Click "+转换因子" button
            CarbonFactorSettings.PrepareToAddCarbonFactor();
            TimeManager.ShortPause();
            CarbonFactorSettings.SelectFactorSource(testData.InputData.Source);

            //点击"+" button.
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();

            //输入转换因子
            CarbonFactorSettings.FillInFactorValue_N(testData.InputData.FactorValue, 1);

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //验证输入不正确的的转换因子后出现错误提示信息.
            Assert.IsTrue(CarbonFactorSettings.IsFactorValueInvalid_N(1));
            Assert.IsTrue(CarbonFactorSettings.IsFactorValueInvalidMsgCorrect_N(testData.ExpectedData.DoubleNonNagtiveValue, 1));

            //CarbonFactorSettings.ClickCancelButton();
        }
        */

        [Test]
        [CaseID("TC-J1-FVT-ConversionFactorSetting-Add-005")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(AddCarbonFactorSuite), "TC-J1-FVT-ConversionFactorSetting-Add-005")]
        public void AddDuplicatedEffectiveYear(CarbonFactorData testData)
        {

            //Click "+转换因子" button
            CarbonFactorSettings.PrepareToAddCarbonFactor();
            TimeManager.ShortPause();
            CarbonFactorSettings.SelectFactorSource("柴油(千克)");

            //点击"+" button两下.
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();
            CarbonFactorSettings.ClickAddMoreRangesButton();
            TimeManager.ShortPause();

            //输入第一组转换因子
            CarbonFactorSettings.FillInFactorEffectiveYear_N("2010", 1);
            CarbonFactorSettings.FillInFactorValue_N("4", 1);
            //输入第二组转换因子
            CarbonFactorSettings.FillInFactorEffectiveYear_N("2010", 2);
            CarbonFactorSettings.FillInFactorValue_N("4", 2);

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify error message show duplicated effective year.
            //A bug of this verification
            //Assert.IsTrue(CarbonFactorSettings.IsFactorEffectiveYearInvalidMsgCorrect_N(testData.ExpectedData.EffectiveYear, 2));
        }
    }
}
