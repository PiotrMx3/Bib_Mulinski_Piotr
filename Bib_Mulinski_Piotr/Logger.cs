using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    //TODO: UML ANNAPSSEN Logger
    internal class Logger
    {
        public static void LogError(string message, Exception? e = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Er ging iets mis - {message}{(e != null ? $": {e.Message}" : "")}");
            Console.ResetColor();
        }

        public static void LogSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        public static void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{message}");
            Console.ResetColor();
        }
    }
}
