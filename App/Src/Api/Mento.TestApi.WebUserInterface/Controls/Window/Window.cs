using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class Window : JazzControl
    {
        public Window(Locator locator) : base(locator) { }
        
        //Title
        private IWebElement Title
        {
            get { return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.WindowTitleLabel)); }
        }

        //Close button
        private IWebElement CloseButton
        {
            get { return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.WindowCloseButton)); }
        }

        //Confirm button
        private IWebElement ConfirmButton
        {
            get { return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.WindowConfirmButton)); }
        }

        //Cancel button
        private IWebElement CancelButton
        {
            get { return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.WindowCancelButton)); }
        }

        //Cancel button
        private IWebElement QuitButton
        {
            get { return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.WindowQuitButton)); }
        }

        public string GetTitle()
        {
            return Title.Text;
        }

        public void Close()
        {
            CloseButton.Click();
        }

        public void Confirm()
        {
            ConfirmButton.Click();
        }

        public void Cancel()
        {
            CancelButton.Click();
        }

        public void Quit()
        {
            QuitButton.Click();
        }

        public bool IsWindowExisted()
        {
            return this.Exists();
        }

        public string GetContentValue()
        {
            return this.RootElement.Text;
        }
    }
}
