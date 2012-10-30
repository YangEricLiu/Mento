using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Mento.App.Controllers;

namespace Mento.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            ScriptController.Sync();

            Console.WriteLine("Press any key to continue..");
            Console.Read();
        }

    }
}
