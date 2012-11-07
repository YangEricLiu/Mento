using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Utility
{
    /// <summary>
    /// Color console
    /// </summary>
    public static class ColorConsole
    {
        /// <summary>
        /// Writes the specified string value to the standard output stream.
        /// </summary>
        /// <param name="text">Write text</param>
        /// <param name="textColor">Text color</param>
        /// <returns></returns>
        public static void Write(string text, ConsoleColor textColor)
        {
            var originColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.Write(text);
            Console.ForegroundColor = originColor;
        }
        
        /// <summary>
        /// Writes the specified string value, followed by the current line terminator,
        /// to the standard output stream.
        /// </summary>
        /// <param name="text">Write text</param>
        /// <param name="textColor">Text color</param>
        /// <returns></returns>
        public static void WriteLine(string text, ConsoleColor textColor)
        {
            var originColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.WriteLine(text);
            Console.ForegroundColor = originColor;
        }
    }
}
