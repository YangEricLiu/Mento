using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Administration;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;


namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of Industry BenchmarkSetting.
    /// </summary>
    public class LabelingSetting
    {
        internal LabelingSetting()
        {
        }

        #region Controls
        public static Button AddLabelingButton = JazzButton.AddLabelingButton;


        #endregion

        #region common action
        /// <summary>
        /// Navigate to Workday Calendar Setting Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToLabelSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.IndustryLabelingSettings);
            //TimeManager.ShortPause();
            //BenchMarkcom.SelectItem();
        }

        /// <summary>
        /// Click Add button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddLabeling()
        {
            AddLabelingButton.Click();
        }
        #endregion
    }
}