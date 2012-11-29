using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class CreateSuccessMessageBox : MessageBox
    {
        
        private static Locator locator = new Locator(@"div[index-of(tokenize(@class,'\s+'),'x-message-box')>0 and ]", ByType.Xpath);

        private Button _IKnowButton;
        private Button IKnowButton
        {
            get
            {
                return this._IKnowButton;
            }
        }

        public CreateSuccessMessageBox(Locator locator) : base(locator) { }

        /// <summary>
        /// Click "OK, I know." button
        /// </summary>
        public void Close()
        {
            IKnowButton.Click();
        }
    }
}
