using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.ScriptCommon.Library
{
    public sealed class JazzChart : JazzControlCollection
    {
        #region get one chart

        public static Chart GetOneChart(string key, string nameIndex)
        {
            return GetControl<Chart>(key, nameIndex);
        }

        #endregion

        public static Chart EnergyViewChart
        {
            get
            {
                return GetControl<Chart>(JazzControlLocatorKey.ChartEnergyView);
            }
        }

        public static Chart CarbonChart
        {
            get
            {
                return GetControl<Chart>(JazzControlLocatorKey.ChartCarbonUsage);
            }
        }

        public static Chart CostChart
        {
            get
            {
                return GetControl<Chart>(JazzControlLocatorKey.ChartCostUsage);
            }
        }

        public static Chart UnitIndicatorChart
        {
            get
            {
                return GetControl<Chart>(JazzControlLocatorKey.ChartUnitIndicator);
            }
        }

        public static Chart RadioChart
        {
            get
            {
                return GetControl<Chart>(JazzControlLocatorKey.ChartRadio);
            }
        }

        public static Chart IndustryLabellingChart
        {
            get
            {
                return GetControl<Chart>(JazzControlLocatorKey.ChartIndustryLabelling);
            }
        }

        public static Chart MaxWidgetLabellingChart
        {
            get
            {
                return GetControl<Chart>(JazzControlLocatorKey.ChartMaxWidgetLabelling);
            }
        }

        public static Chart WidgetMaxDialogChart
        {
            get
            {
                return GetControl<Chart>(JazzControlLocatorKey.ChartWidgetMaxDialog);
            }
        }

        public static Chart PTagRawDataLineChart
        {
            get
            {
                return GetControl<Chart>(JazzControlLocatorKey.ChartPTagRawData);
            }
        }
    }
}
