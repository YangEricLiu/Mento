﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class EnergyAnalysisData : TestDataBase<EnergyAnalysisDataInput, EnergyAnalysisDataOutput>
    {
    }

    public class EnergyAnalysisDataInput : InputTestDataBase
    { 
        public string[] Hierarchies { get; set; }

        public string[] WidgetPath { get; set; }

        public string[] AreaDimensionPath { get; set; }

        public string[] TagNames { get; set; }

        public string[] failedFileName { get; set; }

        public EnergyViewType ViewType { get; set; }

        public ManualTimeRange[] ManualTimeRange { get; set; }

        public ManualTimeRange[] BaselineTimeRange { get; set; }

        public string[] HierarchyTexts { get; set; }

        public string[] ReviseValue { get; set; }
    }

    public class EnergyAnalysisDataOutput : ExpectedTestDataBase
    {
        public string[] expectedFileName { get; set; }
        public string ClearAllMessage { get; set; }
        public string QuitMultipleMessage { get; set; }
    }
}
