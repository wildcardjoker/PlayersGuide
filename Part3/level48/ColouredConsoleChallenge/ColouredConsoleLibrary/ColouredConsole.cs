namespace ColouredConsoleLibrary
{
    /// <summary>
    ///     Write to the console using coloured text.
    /// </summary>
    public static class ColouredConsole
    {
        public static string? Prompt(string question)
        {
            Console.Write($"{question}? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            return Console.ReadLine();
        }

        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }
    }
}