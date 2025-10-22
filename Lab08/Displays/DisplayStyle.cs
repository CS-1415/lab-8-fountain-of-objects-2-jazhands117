using System;
namespace FountainOfObjects.Displays
{
    public static class DisplayStyle
    {
        public static void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}