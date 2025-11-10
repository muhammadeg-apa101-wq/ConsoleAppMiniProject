using System;

namespace Service.Helper
{
    public static class ConsoleHelper
    {
        public static void MsgColor(ConsoleColor color, string message)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = previousColor;
        }
    }
}
