using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Exceptions;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class Chart : JazzControl
    {
        public Chart(Locator locator) : base(locator) { }

        private const string VARIABLE_LEGENDNAME = "legendname";

        private static Locator LegendLocator = new Locator("g.highcharts-legend", ByType.CssSelector);
        private static Locator LegendItemsLocator = new Locator("g.highcharts-legend-item", ByType.CssSelector);
        private static Locator LegendItemsCloseLocator = new Locator("svg/g[contains(@class,'highcharts-legend')]/g/g/g[@class='highcharts-legend-item' and text[text()='$#legendname']]/image", ByType.XPath);
        private static Locator LegendItemTextLocator = new Locator("svg/g[contains(@class,'highcharts-legend')]/g/g/g[@class='highcharts-legend-item']/text[text()='$#legendname']", ByType.XPath);

        private static Locator CurveLocator = new Locator("g.highcharts-series", ByType.CssSelector);
        private static Locator PieLocator = new Locator("//div[contains(@id, 'piechartcomponent')]", ByType.CssSelector);

        private static Locator TitleLocator = new Locator("svg/text[2]", ByType.XPath);
        private static Locator UomLocator = new Locator("svg/text[1]", ByType.XPath);
        private static Locator NavigatorLocator = new Locator("g.highcharts-navigator", ByType.CssSelector);
        private static Locator ScrollbarLocator = new Locator("g.highcharts-scrollbar", ByType.CssSelector);

        #region Title
        public string GetTitle()
        {
            var titleElement = FindChild(TitleLocator);

            if (titleElement == null)
                throw new ApiException("The title element was not found.");

            return FindChild(TitleLocator).Text;
        }
        #endregion

        #region Legend
        public bool LegendExists()
        {
            return ChildExists(LegendLocator);
        }

        public bool IsNavigatorExists()
        {
            return ChildExists(NavigatorLocator);
        }

        public bool IsScrollbarExists()
        {
            return ChildExists(ScrollbarLocator);
        }

        public bool LegendItemExists(string legendName)
        {
            if (GetLegendItemElement(LegendItemsLocator, legendName) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowCurve(string legendName)
        {
            if (!IsLegendItemShown(legendName))
                ClickLegendItem(legendName);
        }

        public void HideCurve(string legendName)
        {
            if (IsLegendItemShown(legendName))
                ClickLegendItem(legendName);
        }

        public void CloseLegendItem(string legendName)
        {
            var legendClose = GetLegendItemElement(LegendItemsCloseLocator, legendName);

            legendClose.Click();
        }

        public void ClickLegendItem(string legendName)
        {
            var legend = GetLegendItemElement(LegendItemsLocator, legendName);

            if (legend != null)
            {
                legend.Click();
            }
        }


        #region Private methods
        private IWebElement GetLegendItemElement(Locator locator, string legendName)
        {
            IWebElement[] items = FindChildren(locator);

            foreach (IWebElement item in items)
            {
                if (item.Text.Contains(legendName))
                {
                    return item;
                }
            }

            return null;
        }

        private bool IsLegendItemShown(string legendName)
        {
            var textElement = GetLegendItemElement(LegendItemTextLocator, legendName);

            return !textElement.GetAttribute("style").Contains("color:#CCC;fill:#CCC;");
        }
        #endregion
        #endregion

        #region Uom

        public string GetUom()
        {
            var uomElement = FindChild(UomLocator);

            if (uomElement == null)
                throw new ApiException("The uom element was not found.");

            return FindChild(UomLocator).Text;
        }

        #endregion

        #region Curve (Not finished yet)
        public bool HasDrawnTrend()
        {
            return ChildExists(CurveLocator);
        }

        public bool HasDrawnDistribute()
        {
            return ChildExists(PieLocator);
        }
        #endregion
        
        #region Common
        private bool ChildExists(Locator locator)
        {
            return FindChildren(locator).Count() > 0;
        }
        #endregion
    }
}
