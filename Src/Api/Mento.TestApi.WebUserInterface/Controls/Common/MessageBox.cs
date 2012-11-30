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
        private static Locator MessageContainerLocator = new Locator("div/div/div/div/div/div/div/table/tbody/tr/td[@class='x-form-item-body']/div[@data-errorqtip]", ByType.XPath);

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
            return FindChild(MessageContainerLocator).Text;
        }
    }
}
