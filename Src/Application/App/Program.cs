using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Mento.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                StartWindowsForm();
            }
            else
            {
                StartConsole();
            }
        }

        private static void StartWindowsForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void StartConsole()
        {
            Console.WriteLine("hello mento!");
            Console.Read();
        }
    }
}
