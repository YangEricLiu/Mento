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
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Linda")]
    [CreateTime("2014-08-18")]
    [ManualCaseID("TC-J1-FVT-PtagRawData-Modify")]
    public class ModifyPtagRawDataSuite : TestSuiteBase
    {
        private PTagSettings PTagSettings = JazzFunction.PTagSettings;
        private PTagRawData PTagRawData = JazzFunction.PTagRawData;
        private static Chart PTagRawDataLineChart = JazzChart.PTagRawDataLineChart;
        private static Grid PTagRawDataGrid = JazzGrid.GridPTagRawData;

        [SetUp]
        public void CaseSetUp()
        {
            PTagSettings.NavigatorToPtagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }


        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-Modify-101")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-101")]
        public void SaveAndTooltipShowWell(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set time range = 2014年01月01日00点00分-2014年1月1日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Check the line chart and rawdata grid exist
            Assert.IsTrue(PTagRawData.IsExisted(JazzControlLocatorKey.ChartPTagRawData));
            Assert.IsTrue(PTagRawData.IsExisted(JazzControlLocatorKey.GridPTagRawData));

            //Click the first row by default (2014年01月01日00点00分-00点15分), and input a valid modified value.
            PTagRawData.InputValue(1,"1.23");

            //Click another row (The second row:2014年01月01日00点15分-00点30分), and input a valid modified value.
            PTagRawData.InputValue(2,"4.56");

            //Verify the tooltip of this modify value display as red color.
            //Verify the neiboring two timestamps tooltip display as black color.
            if (input.InputData.OriginalName == PTagRawDataLineChart.GetRawDataLineChartTooltip(2))
            {
                Assert.IsTrue(PTagRawData.IsExisted(JazzControlLocatorKey.RedTagNameInTooltip));
                Assert.IsTrue(PTagRawData.IsExisted(JazzControlLocatorKey.BoldValueInTooltip));
            }

            //Click "Save" button
            PTagRawData.ClickSaveRawDataButton();

            //Save this changed values into database.
            Assert.AreEqual("1.23" + input.InputData.Uom.ToString(), PTagRawDataLineChart.GetRawDataLineChartTooltip(3));
            Assert.AreEqual("4.56" + input.InputData.Uom.ToString(), PTagRawDataLineChart.GetRawDataLineChartTooltip(3));

            //Set relevant Status fields as Modified.
            Assert.IsTrue(PTagRawData.IsExisted(JazzControlLocatorKey.GridPTagRawDataFirstRow));
            Assert.IsTrue(PTagRawData.IsExisted(JazzControlLocatorKey.GridPTagRawDataSecondRow));

            //Verify /the tooltip of this modify value from red color change to black color.
            if (input.InputData.OriginalName == PTagRawDataLineChart.GetRawDataLineChartTooltip(2))
            {
                Assert.IsTrue(PTagRawData.IsExisted(JazzControlLocatorKey.BlueTagNameInTooltip));
            }
        
        }

       
    }
}
