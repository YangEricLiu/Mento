using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.TestApi.WebUserInterface;
using System.Collections;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class Container : JazzControl
    {
        protected IWebElement[] HiddenItems
        {
            get
            {
                return FindChildren(ControlLocatorRepository.GetLocator(ControlLocatorKey.ContainerNotHiddenItems));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locator">Container locator</param>
        public Container(Locator locator)
            : base(locator)
        { 
        }

        /// <summary>
        /// get the items number which included by this container
        /// </summary>
        /// <param></param>
        public int GetElementNumber()
        {
            return this.RootElements.Count();
        }

        /// <summary>
        /// get the error tips  of this container
        /// </summary>
        /// <param></param>
        public string GetContainerErrorTips()
        {
            return this.RootElement.Text;
        }

        /// <summary>
        /// get the displayed text of this container
        /// </summary>
        /// <param></param>
        public string GetContainerTexts()
        {
            return this.RootElement.Text;
        }

        /// <summary>
        /// judge if all the texts existed in the container
        /// </summary>
        /// <param></param>
        public Boolean IsContainerTextsExisted(string[] containerTexts)
        {
            string allTexts = GetContainerTexts();

            foreach (string text in containerTexts)
            {
                if (!allTexts.Contains(text))
                {
                    Console.Out.WriteLine(text);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// get the text array list for hidden item in this container
        /// </summary>
        /// <param></param>
        public ArrayList GetHiddenItemsText()
        {
            ArrayList items = new ArrayList();

            foreach (IWebElement item in HiddenItems)
            {
                items.Add(item.Text);
            }

            return items;
        }
    }
}
