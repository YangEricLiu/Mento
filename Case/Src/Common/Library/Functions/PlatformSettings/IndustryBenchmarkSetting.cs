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
    public class IndustryBenchmarkSetting
    {
        internal IndustryBenchmarkSetting()
        {
        }

        #region Controls
        public static Button AddBenchMarkButton = JazzButton.AddBenchMarkButton;
        public static Grid BenchMarkList = JazzGrid.BenchMarkList;
        public static ComboBox BenchMarkcom = JazzComboBox.KPITagSettingsUomComboBox;
        #endregion

        #region common action
        /// <summary>
        /// Navigate to Workday Calendar Setting Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToWorkdayCalendarSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.ShortPause();
            //BenchMarkcom.SelectItem();
        }

        #endregion

        #region item operation
        public void ClickDeleteRangeItemButton(int num)
        {
            
        }        

        #endregion

        #region verification
      
        #endregion

        #region Get value
        /// <summary>
        /// Get message in the pop up message box. 
        /// </summary>
        /// <returns></returns>
        public string GetMessageText()
        {
            JazzMessageBox.LoadingMask.WaitLoading();
            return JazzMessageBox.MessageBox.GetMessage();
        }

       
        #endregion

        #region private method
       
        #endregion
    }
}
