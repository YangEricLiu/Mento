using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Mento.App.Controllers;
using System.IO;
using Mento.Utility;
using Mento.Framework.Configuration;
using System.Xml;
using System.Xml.Linq;
using Mento.Framework.Execution;

namespace Mento.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            //ScriptController.Sync();

            //PlanController.Create("");
            //PlanController.Update("", "");
            //PlanController.Delete("");

            PlanController.Run("", "", "", "");


            
            Console.WriteLine("Press any key to continue..");
            Console.Read();
        }

    }
}
