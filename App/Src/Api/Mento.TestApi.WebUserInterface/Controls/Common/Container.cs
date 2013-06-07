using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.TestApi.WebUserInterface;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class Container : JazzControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locator">Container locator</param>
        public Container(Locator locator)
            : base(locator)
        { 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locator">Container locator</param>
        public int GetElementNumber()
        {
            return this.RootElements.Count();
        }

        public string GetContainerErrorTips()
        {
            return this.RootElement.Text;
        }

    }
}
