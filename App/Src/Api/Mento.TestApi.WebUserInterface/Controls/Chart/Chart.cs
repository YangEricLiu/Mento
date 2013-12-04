﻿using System;
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
        private static Locator LegendItemsCloseLocator = new Locator("rect", ByType.TagName);
        private static Locator LegendItemtspanLocator = new Locator("tspan", ByType.TagName);
        private static Locator LegendItemTextLocator = new Locator("text", ByType.TagName);

        private static Locator CurveLocator = new Locator("g.highcharts-series", ByType.CssSelector);
        private static Locator ColumnLocator = new Locator("g.highcharts-tracker", ByType.CssSelector);
        private static Locator PieLocator = new Locator("g.highcharts-tracker", ByType.CssSelector);
        private static Locator PathLocator = new Locator("path", ByType.TagName);
        private static Locator RectLocator = new Locator("rect", ByType.TagName);
        private static Locator MarkersLocator = new Locator("g.highcharts-markers", ByType.CssSelector);
        
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

        public bool IsCloseLegendButtonExist(string legendName)
        {
            IWebElement LegendElement = GetLegendItemElement(legendName);

            return ChildExists(LegendItemsCloseLocator, LegendElement); 
        }

        public bool LegendItemExists(string legendName)
        {
            if (GetLegendItemElement(legendName) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LegendItemsExists(string[] legendNames)
        {
            bool allExisted = true;

            foreach (string legendName in legendNames)
            {
                if (GetLegendItemElement(legendName) == null)
                {
                    allExisted = false;
                }
            }

            return allExisted;
        }

        public void ShowLineCurve(string legendName)
        {
            if (!IsLineLegendItemShown(legendName))
                ClickLegendItem(legendName);
        }

        public void HideLineCurve(string legendName)
        {
            if (IsLineLegendItemShown(legendName))
                ClickLegendItem(legendName);
        }

        public void ShowColumnCurve(string legendName)
        {
            if (!IsColumnLegendItemShown(legendName))
                ClickLegendItem(legendName);
        }

        public void HideColumnCurve(string legendName)
        {
            if (IsColumnLegendItemShown(legendName))
                ClickLegendItem(legendName);
        }


        public void CloseLegendItem(string legendName)
        {
            IWebElement LegendElement = GetLegendItemElement(legendName);
            IWebElement closeLegend = FindChild(LegendItemsCloseLocator, LegendElement);

            closeLegend.Click();
        }

        public void ClickLegendItem(string legendName)
        {
            IWebElement LegendElement = GetLegendItemElement(legendName);
            IWebElement legendText = FindChild(LegendItemtspanLocator, LegendElement);

            legendText.Click();
        }

        public bool IsColumnLegendItemShown(string legendName)
        {
            IWebElement LegendElement = GetLegendItemElement(legendName);
            IWebElement rectLegend = FindChild(RectLocator, LegendElement);

            return !rectLegend.GetAttribute("fill").Contains("#CCC");
        }

        public bool IsLineLegendItemShown(string legendName)
        {
            IWebElement LegendElement = GetLegendItemElement(legendName);
            IWebElement pathLegend = FindChild(PathLocator, LegendElement);

            return !pathLegend.GetAttribute("stroke").Contains("#CCC");
        }

        #region Private methods

        private IWebElement GetLegendItemElement(string legendName)
        {
            IWebElement[] items = FindChildren(LegendItemsLocator);

            foreach (IWebElement item in items)
            {
                if (item.Text.Contains(legendName))
                {
                    return item;
                }
            }

            return null;
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

        #region TrendChart (Not finished yet)

        public bool HasDrawnTrend()
        {
            IWebElement[] lines = FindChildren(CurveLocator);
            IWebElement[] markers = FindChildren(MarkersLocator);
            int haveLine = 0;
            int noLine = 0;
            int haveMarkers = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                bool pathExisted = ChildExists(PathLocator, lines[i]);
                bool isLineVisible = lines[i].GetAttribute("visibility").Contains("visible");
                bool isMarkersVisible = markers[i].GetAttribute("visibility").Contains("visible");
                bool markersExisted = IsMarkersExisted(PathLocator, markers[i]);

                if (lines[i].GetAttribute("transform").Contains("translate(0,100)"))
                {
                    noLine++;
                }
                else if (pathExisted && isLineVisible)
                {
                    haveLine++;
                }
                else if (markersExisted && isMarkersVisible)
                {
                    haveMarkers++;
                }
            }

            return (haveLine > 1) || (haveMarkers > 0);
        }

        public int GetTrendChartLines()
        {
            IWebElement[] lines = FindChildren(CurveLocator);
            int haveLine = 0;
            int noLine = 0;

            foreach (IWebElement line in lines)
            {
                bool pathExisted = ChildExists(PathLocator, line);
                bool isVisible = line.GetAttribute("visibility").Contains("visible");

                if (line.GetAttribute("transform").Contains("translate(0,100)"))
                {
                    noLine++;
                }
                else if (pathExisted&&isVisible)
                {
                    haveLine++;
                }
            }

            return haveLine - 1 - noLine;   
        }

        public int GetTrendChartLinesMarkers()
        {
            IWebElement[] lines = FindChildren(CurveLocator);
            IWebElement[] markers = FindChildren(MarkersLocator);
            int haveMarkers = 0;
            int markersLine = 0;

            for (int i = 0; i < markers.Length; i++)
            {
                bool isVisible = markers[i].GetAttribute("visibility").Contains("visible");
                bool markersExisted = IsMarkersExisted(PathLocator, markers[i]);
                if (isVisible && markersExisted)
                {
                    markersLine = GetLineMarkers(PathLocator, markers[i]);
                    haveMarkers = haveMarkers + markersLine;
                }    
            }

            return haveMarkers;
        }

        #endregion

        #region Column Chart

        public bool HasDrawnColumn()
        {
            IWebElement[] lines = FindChildren(ColumnLocator);
            int haveColumn = 0;
            int noColumn = 0;

            foreach (IWebElement line in lines)
            {
                bool rectExisted = ChildExists(RectLocator, line);
                bool isVisible = line.GetAttribute("visibility").Contains("visible");

                if (line.GetAttribute("transform").Contains("translate(0,100)"))
                {
                    noColumn++;
                }
                else if (rectExisted && isVisible)
                {
                    haveColumn++;
                }
            }

            return haveColumn > 0;
        }

        public int GetColumnChartColumns()
        {
            IWebElement[] lines = FindChildren(ColumnLocator);
            int haveColumn = 0;
            int noColumn = 0;

            foreach (IWebElement line in lines)
            {
                bool rectExisted = ChildExists(RectLocator, line);
                bool isVisible = line.GetAttribute("visibility").Contains("visible");

                if (line.GetAttribute("transform").Contains("translate(0,100)"))
                {
                    noColumn++;
                }
                else if (rectExisted && isVisible)
                {
                    haveColumn++;
                }
            }

            return haveColumn - noColumn;
        }

        public int GetTotalColumns()
        {
            IWebElement[] lines = FindChildren(ColumnLocator);
            int haveColumn = 0;
            int lineColumns = 0;

            foreach (IWebElement line in lines)
            {
                lineColumns = FindChildren(RectLocator, line).Length;
                haveColumn = haveColumn + lineColumns;
            }

            return haveColumn;
        }
        #endregion

        #region Pie Chart

        public bool HasDrawnPie()
        {
            IWebElement pie = FindChild(PieLocator);
            IWebElement[] piePaths = ElementHandler.FindElements(PathLocator, pie).ToArray();
            int pieNumbers = piePaths.Length / 2;

            return pieNumbers > 0;
        }

        public int GetPieDistributions()
        {
            IWebElement pie = FindChild(PieLocator);
            IWebElement[] piePaths = ElementHandler.FindElements(PathLocator, pie).ToArray();
            int pieNumbers = piePaths.Length / 2;

            return pieNumbers;
        }

        #endregion

        #region Common

        public bool IsNavigatorExists()
        {
            return ElementHandler.Exists(NavigatorLocator);
        }

        public bool IsScrollbarExists()
        {
            return ElementHandler.Exists(ScrollbarLocator);
        }

        private bool ChildExists(Locator locator)
        {
            return FindChildren(locator).Count() > 0;
        }

        private bool ChildExists(Locator locator, IWebElement parent)
        {
            return ElementHandler.FindElements(locator, parent).ToArray().Length > 0;
        }

        private bool LineChartPathChildExists(Locator locator, IWebElement parent)
        {
            return ElementHandler.FindElements(locator, parent).ToArray().Length > 1;
        }

        private IWebElement[] FindChildren(Locator locator, IWebElement parent)
        {
            return ElementHandler.FindElements(locator, parent).ToArray();
        }

        private IWebElement FindChild(Locator locator, IWebElement parent)
        {
            return ElementHandler.FindElement(locator, parent);
        }

        private bool IsMarkersExisted(Locator locator, IWebElement parent)
        {
            return FindChildren(locator, parent).Length > 1;
        }

        private int GetLineMarkers(Locator locator, IWebElement parent)
        {
            int markersNum = 0;
            IWebElement[] paths = FindChildren(locator, parent);

            foreach (IWebElement path in paths)
            {
                if (path.GetAttribute("visibility").Contains("inherit"))
                    markersNum++;
            }

            return markersNum;
        }

        public bool EntirelyNoChartDrawn()
        {
            return !(ElementHandler.Exists(this._RootLocator));
        }
        #endregion
    }
}
