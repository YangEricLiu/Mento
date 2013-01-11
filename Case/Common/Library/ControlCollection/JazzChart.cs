﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.ScriptCommon.Library
{
    public sealed class JazzChart : JazzControlCollection
    {
        public static Chart EnergyViewChart
        {
            get
            {
                return GetControl<Chart>(JazzControlLocatorKey.ChartEnergyView);
            }
        }
    }
}
