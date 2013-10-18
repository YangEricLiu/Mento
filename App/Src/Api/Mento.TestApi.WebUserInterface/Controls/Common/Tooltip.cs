using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.TestApi.WebUserInterface;
using System.Collections;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class Tooltip : JazzControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locator"> locator</param>
        public Tooltip(Locator locator)
            : base(locator)
        { 
        }

        /// <summary>
        /// get the displayed text of this tooltip
        /// </summary>
        /// <param></param>
        public string GetTooltipTexts()
        {
            return this.RootElement.Text;
        }

        /// <summary>
        /// judge if all the texts existed in the tooltip
        /// </summary>
        /// <param></param>
        public Boolean IsTooltipTextsExisted(string[] tooltipTexts)
        {
            string allTexts = GetTooltipTexts();

            foreach (string text in tooltipTexts)
            {
                if (!allTexts.Contains(text))
                {
                    Console.Out.WriteLine(text);
                    return false;
                }
            }

            return true;
        } 
    }
}
