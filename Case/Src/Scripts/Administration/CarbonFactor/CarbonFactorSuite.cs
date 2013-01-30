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

namespace Mento.Script.Administration.CarbonFactor
{
    [TestFixture]
    [Owner("Amy")]
    [CreateTime("2013-01-09")]
    [ManualCaseID("TC-J1-SmokeTest")]
    public class CarbonFactorSuite:TestSuiteBase
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
        }
                
        [Test]
        [CaseID("TC-J1-SmokeTest-024")]
        [Priority("11")]
        [MultipleTestDataSource(typeof(CarbonFactorData[]), typeof(CarbonFactorSuite), "TC-J1-SmokeTest-024")]
        public void AddCarbonFactor(CarbonFactorData testData)
        {
            CarbonFactorSettings.PrepareToAddCarbonFactor();
            TimeManager.ShortPause();
            
            CarbonFactorSettings.SelectFactorSource(testData.InputData.Source);
            TimeManager.ShortPause();

            //Input 'Effective Year' and 'Factor Value' for the record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.RecordNumber; elementPosition++)
            {
                if (elementPosition > 1)
                {
                    //Click '添加生效日期' button if more than one record need to be entered (Amy's note: this is not working now since the link button can't be found due to unknown reason.)
                    //CarbonFactorSettings.ClickAddMoreRangesButton();
                    //TimeManager.ShortPause();
                }

                int inputDataArrayPosition = elementPosition - 1;
                CarbonFactorSettings.SelectEffectiveYear(testData.InputData.EffectiveYear[inputDataArrayPosition], elementPosition);
                CarbonFactorSettings.FillInFactorValue(testData.InputData.FactorValue[inputDataArrayPosition], elementPosition);                
            }

            CarbonFactorSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the 'Factor Source' and 'Factor Destination'
            Assert.AreEqual(testData.InputData.Source, CarbonFactorSettings.GetFactorSourceValue());
            Assert.AreEqual(testData.ExpectedData.Destination, CarbonFactorSettings.GetFactorDestinationValue());

            //Verify 'Effective Year' and 'Factor Value' of the record(s)
            for (int elementPosition = 1; elementPosition <= testData.InputData.RecordNumber; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                Assert.AreEqual(testData.InputData.EffectiveYear[inputDataArrayPosition], CarbonFactorSettings.GetEffectiveYearValue(elementPosition));
                Assert.AreEqual(testData.InputData.FactorValue[inputDataArrayPosition], CarbonFactorSettings.GetFactorValue(elementPosition));
            }
        }       
    }
}
