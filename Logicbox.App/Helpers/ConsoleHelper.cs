namespace Logicbox.App.Helpers
{
    internal static class ConsoleHelper
    {
        private static readonly ConsoleColor DarkColor = ConsoleColor.Black;
        private static readonly ConsoleColor BrightColor = ConsoleColor.White;
        private static readonly ConsoleColor PrimaryColor = ConsoleColor.Cyan;
        private static readonly ConsoleColor AccentColor = ConsoleColor.Yellow;

        private static void Write(string text, ConsoleColor foregroundColor, bool newLine = false)
        {
            Console.BackgroundColor = DarkColor;
            Console.ForegroundColor = foregroundColor;
            if (newLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }
            Console.ResetColor();
        }

        private static void WriteLine(string text, ConsoleColor foregroundColor) => Write(text, foregroundColor, true);

        internal static void NewLine() => Console.Write("\n");
        internal static void WriteLine(string text) => WriteLine(text, BrightColor);
        internal static void Write(string text) => Write(text, BrightColor);
        internal static void PrimaryWriteLine(string text) => WriteLine(text, PrimaryColor);
        internal static void PrimaryWrite(string text) => Write(text, PrimaryColor);
        internal static void AccentWriteLine(string text) => WriteLine(text, AccentColor);
        internal static void AccentWrite(string text) => Write(text, AccentColor);

        private static void WriteSelectionList(object[] list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                var item = list[i];
                if (item is not null)
                {
                    Write("[");
                    PrimaryWrite($"{i}");
                    Write("]\t");
                    Write(item.ToString() ?? string.Empty);
                    NewLine();
                }
            }
        }

        internal static int Selection(Array list, string? selectionText = null)
        {
            const int defaultSelectionValue = -1;
            const string defaultSelectionText = "Make you selection: ";
            if (list is null || list.Length == 0)
            {
                throw new ArgumentNullException(nameof(list));
            }
            WriteSelectionList((object[])list);
            int selection = defaultSelectionValue;
            while ((selection < 0 || selection > (list.Length - 1)) && list.Length > 1)
            {
                WriteLine("Make your selection using a numerical value. Natural numbers only as displayed in the list above.");
                Write($"{selectionText ?? defaultSelectionText}: ");
                string? answer = Console.ReadLine();
                if (answer is not null)
                {
                    try
                    {
                        selection = int.Parse(answer);
                    }
                    catch (Exception)
                    {
                        selection = defaultSelectionValue;
                    }
                }
            }
            if (list.Length == 1)
            {
                WriteLine("The selection only contains one item, otherwise you would had the option to choose.");
                return 0;
            }
            return selection;
        }

        internal static void WriteList(Array list, string? prepend = null, string? append = null)
        {
            const string listStyle = "* ";
            foreach (var item in list)
	        {
                PrimaryWrite($"{listStyle}");
                WriteLine($"{prepend ?? string.Empty}{item}{append ?? string.Empty}");
	        }
        }
    }
}
