using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class KPISettings
    {
        internal KPISettings()
        {
        }

        private static Button CreateKPIButton = JazzButton.CreateKPIButton;

        /// <summary>
        /// Click "add KPI" button to add one KPI
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void PrepareToAddKPI()
        {
            CreateKPIButton.Click();
        }

        public void FillInKPI()
        { 
            
        }
    }
}
