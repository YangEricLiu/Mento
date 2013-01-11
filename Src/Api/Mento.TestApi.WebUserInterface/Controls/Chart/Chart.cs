using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class Chart : JazzControl
    {
        public Chart(Locator locator) : base(locator) { }

        private static Locator LegendLocator = new Locator("g.highcharts-legend", ByType.CssSelector);

        private static Locator CurveLocator = new Locator("g.highcharts-tracker", ByType.CssSelector);
        private static Locator PieLocator = new Locator("g.highcharts-point", ByType.CssSelector);


        public bool HasDrawnTrend()
        {
            return ChildExists(CurveLocator);
        }

        public bool HasDrawnDistribute()
        {
            return ChildExists(PieLocator);
        }

        public bool HasDrawnLegend()
        {
            return ChildExists(LegendLocator);
        }

        private bool ChildExists(Locator locator)
        {
            return FindChildren(locator).Count() > 0;
        }
    }
}
