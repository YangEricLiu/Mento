using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    public class RadioPanel : EnergyViewPanel
    {
        #region Controls
        //Select system dimension tree button
        private static Button SelectSystemDimensionButton
        {
            get;
            set;
        }
        private static SystemDimensionTree SystemDimensionTree
        {
            get;
            set;
        }


        //TagGrid
        private static Grid TagGrid
        {
            get;
            set;
        }

        protected override Chart Chart
        {
            get { return JazzChart.EnergyViewChart; }
        }

        protected override Grid EnergyDataGrid
        {
            get { return JazzGrid.EnergyAnalysisEnergyDataList; }
        }
        #endregion

        internal RadioPanel()
        {
            TagGrid = JazzGrid.RadioAllTagList;

            SelectSystemDimensionButton = JazzButton.EnergyViewSelectSystemDimensionButton;
            SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;
        }

    }
}
