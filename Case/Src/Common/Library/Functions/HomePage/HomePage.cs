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
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.EnergyView;
using System.Data;
using System.IO;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// Operation on home page
    /// </summary>
    public class HomePage
    {
        internal HomePage()

        {
        }

        #region controls

        private static Button AllDashboardsHierarchyTreeButton = JazzButton.AllDashboardsHierarchyTreeButton;
        private static HierarchyTree AllDashboardsTree = JazzTreeView.AllDashboardsTree;
        private static Container WidgetsOnOneDashboard = JazzContainer.ContainerWidgetsToDashboard;
        private static Label DashboardHeaderName = JazzLabel.DashboardHeaderNameLabel;
        private static MenuButton SelectCustmerMenuButton = JazzButton.SelectCustomerMenuButton;

        #endregion

        #region common

        public void SelectCustomer(string customerName)
        {
            SelectCustmerMenuButton.SelectOneItem(customerName);
        }

        public bool IsTrendDrawnOnWidgetMin()
        {
            return true;
        }

        public void ClickDashboardButton(string dsName)
        {
            Button dsButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonHomePageDashboard, dsName);

            dsButton.Click();
        }

        public int GetWidgetsNumberOfDashboard()
        {
            return WidgetsOnOneDashboard.GetElementNumber();
        }

        public string GetDashboardHeaderName()
        {
            return DashboardHeaderName.GetLabelTextValue();
        }

        public DataTable GetWidgetMinDataViewAllData(string widgetName)
        {
            Grid dataGrid = JazzGrid.GetOneGrid(JazzControlLocatorKey.GridHomepageMinWidgetDataView, widgetName);

            return dataGrid.GetAllData();
        }

          /// <summary>
        /// Exit Jazz
        /// </summary>
        public void ExitJazz()
        {
            JazzFunction.UserProfile.NavigatorToUserProfile();
            JazzFunction.UserProfile.ExitJazz();
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
        }      

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// <param name="failedFileName"></param>
        /// /// <param name="basePath"></param>
        /// <param name="widgetName"></param>
        public bool CompareMinWidgetDataView(string basePath, string expectedFileName, string failedFileName, string widgetName)
        {
            string filePath = Path.Combine(basePath, expectedFileName);
            DataTable actualData = GetWidgetMinDataViewAllData(widgetName);

            DataTable expectedDataTable = JazzFunction.DataViewOperation.ImportExpectedFileToDataTable(filePath, JazzFunction.DataViewOperation.sheetNameExpected);

            return JazzFunction.DataViewOperation.CompareDataTables(expectedDataTable, actualData, failedFileName);
        }

        #endregion

        #region All dashboard

        /// <summary>
        /// Select hierarchy node 
        /// </summary>
        /// <param name="treePath"></param>
        /// <returns></returns>
        public bool SelectHierarchyNode(string[] treePath)
        {
            AllDashboardsHierarchyTreeButton.Click();
            TimeManager.ShortPause();

            try
            {
                AllDashboardsTree.SelectNode(treePath);
                return true;
            }
            catch(Exception Ex)
            {
                return false;
            }
        }

        public bool IsWidgetExistedOnDashboard(string name)
        {
            Label WidgetNameMin = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelWidgetNameMin, name);
            
            return WidgetNameMin.IsLabelExisted();
        }

        #endregion

        #region private method


        #endregion
    }
}