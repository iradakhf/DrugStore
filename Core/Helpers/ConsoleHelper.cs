

namespace Core.Helpers
{
    public class ConsoleHelper
    {
        public static void WriteTextWithColor(ConsoleColor consoleColor, string text)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
