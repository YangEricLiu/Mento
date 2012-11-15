using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Mento.App.Controllers;
using System.IO;

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

            //PlanController.Run("", "", "", "");

            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"../result"));
            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../result"));
            Console.WriteLine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName);

            Console.WriteLine("Press any key to continue..");
            Console.Read();
        }

    }
}
