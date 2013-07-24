
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class CarbonUsagePanel : EnergyViewPanel
    {
        private static Grid CommodityGrid = JazzGrid.CommodityCarbonGrid;
        private static Grid TotalCommotidyGrid = JazzGrid.TotalCommodityCarbonGrid;

        protected override Chart Chart
        {
            get { return JazzChart.EnergyViewChart; }
        }

        protected override Grid EnergyDataGrid
        {
            get { return JazzGrid.EnergyAnalysisEnergyDataList; }
        }

        internal CarbonUsagePanel() { }

        public void SelectCommodity(string[] commodityNames = null)
        {
            //total
            if (commodityNames == null || commodityNames.Length <= 0)
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "介质总览", false);
            }
            else //specified commodity
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "介质单项", false);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();

                foreach (var commodity in commodityNames)
                {
                    CommodityGrid.CheckRowCheckbox(2, commodity, false);
                    JazzMessageBox.LoadingMask.WaitLoading();
                }
            }
        }

        public void DeselectCommodity(string[] commodityNames)
        {
            throw new NotImplementedException();
        }
    }
}
