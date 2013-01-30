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
using Mento.Framework.Exceptions;
using Mento.Framework.Log;
using Mento.App.CommandAnalysis;

namespace Mento.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            new MentoApp().Run(args);
        }

    }
}
