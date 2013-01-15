using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    public class TimeSpanDialog : Window
    {
        private static Locator Locator = new Locator("//div[contains(@id,'addintervalwindow') and contains(@class,'x-window')]", ByType.XPath);

        //private static void StartDate;
        private static ComboBox StartTime;
        //private static void EndDate;
        private static ComboBox EndTime;
        
        public TimeSpanDialog() : base(Locator) { }

        public void InputStartTime(DateTime startTime)
        {
            throw new NotImplementedException();
        }

        public DateTime? GetEndTime()
        {
            throw new NotImplementedException();
        }
    }
}
