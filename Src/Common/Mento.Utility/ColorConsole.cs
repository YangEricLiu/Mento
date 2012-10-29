using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Utility
{
    public static class ColorConsole
    {
        public static void Write(string text, ConsoleColor textColor)
        {
            var originColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.Write(text);
            Console.ForegroundColor = originColor;
        }

        public static void WriteLine(string text, ConsoleColor textColor)
        {
            var originColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.WriteLine(text);
            Console.ForegroundColor = originColor;
        }
    }
}
