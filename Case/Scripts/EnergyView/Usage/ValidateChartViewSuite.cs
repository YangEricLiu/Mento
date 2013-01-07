using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Script;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.EnergyView.Usage
{
    [TestFixture]
    [Owner("Aries")]
    [CreateTime("2012-11-14")]
    [ManualCaseID("TC-J1-SmokeTest-034")]
    public class ValidateChartViewSuite : TestSuiteBase
    {
        [Test]
        [CaseID("TC-J1-SmokeTest-034")]
        public void ValidateChartRendered()
        {
            var button = JazzButton.AreaDimensionCreateButton;

            LanguageResourceRepository.GetLanguageVariableValue("$@Common.AggregationStep.Hourly");
        }
    }
}