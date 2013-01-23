using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Framework.Exceptions;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class MessageBox : JazzControl
    {
        private static Locator MessageContainerLocator = new Locator("/div/div/div/div/div/div/div/table/tbody/tr/td[@class='x-form-item-body']/div[@data-errorqtip]", ByType.XPath);
        //private static Locator MessageContainerLocator = new Locator("//div[contains(@id, 'messagebox')]", ByType.XPath);

        protected IWebElement OkButton
        {
            get
            {
                return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.MessageBoxOkButton));
            }
        }

        private IWebElement _ConfirmButton;
        protected IWebElement ConfirmButton
        {
            get
            {
                if (this._ConfirmButton == null)
                    this._ConfirmButton = FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.MessageBoxConfirmButton));
                return this._ConfirmButton;
            }
        }

        private IWebElement _YesButton;
        protected IWebElement YesButton
        {
            get
            {
                if (this._YesButton == null)
                    this._YesButton = FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.MessageBoxYesButton));
                return this._YesButton;
            }
        }

        private IWebElement _NoButton;
        protected IWebElement NoButton
        {
            get
            {
                if (this._NoButton == null)
                    this._NoButton = FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.MessageBoxNoButton));
                return this._NoButton;
            }
        }

        private IWebElement _DeleteButton;
        protected IWebElement DeleteButton
        {
            get
            {
                if (this._DeleteButton == null)
                    this._DeleteButton = FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.MessageBoxDeleteButton));
                return this._DeleteButton;
            }
        }

        private IWebElement _CancelButton;
        protected IWebElement CancelButton
        {
            get
            {
                if (this._CancelButton == null)
                    this._CancelButton = FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.MessageBoxCancelButton));
                return this._CancelButton;
            }
        }

        public MessageBox() : base(ControlLocatorRepository.GetLocator(ControlLocatorKey.MessageBox)) { }

        public void WaitMeAppear()
        {
            ElementHandler.Wait(this._RootLocator, WaitType.ToAppear);
        }
        public void Delete()
        {
            if (!this.DeleteButton.Enabled)
                throw new ApiException("Delete button can not be clicked because it is not enabled in the messagebox.");

            this.DeleteButton.Click();
        }

        public void OK()
        {
            if (!this.OkButton.Enabled)
                throw new ApiException("Ok button can not be clicked because it is not enabled in the messagebox.");

            this.OkButton.Click();
        }

        public void Confirm()
        {
            if (!this.ConfirmButton.Enabled)
                throw new ApiException("Confirm button can not be clicked because it is not enabled in the messagebox.");

            this.ConfirmButton.Click();
        }

        public void Yes()
        {
            if (!this.YesButton.Enabled)
                throw new ApiException("Yes button can not be clicked because it is not enabled in the messagebox.");

            this.YesButton.Click();
        }

        
        public void No()
        {
            if (!this.NoButton.Enabled)
                throw new ApiException("No button can not be clicked because it is not enabled in the messagebox.");

            this.NoButton.Click();
        }

        public void Cancel()
        {
            if (!this.CancelButton.Enabled)
                throw new ApiException("Cancel button can not be clicked because it is not enabled in the messagebox.");

            this.CancelButton.Click();
        }

        public string GetMessage()
        {
            return RootElement.Text;
            //return FindChild(MessageContainerLocator).Text;
        }
    }
}
