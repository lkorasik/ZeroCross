using System;

namespace ZeroCross
{
    class ShowCoordinatesOfCells
    {
        /*
         * Вывод подсказки с адресами ячеек
         */
        public static void WriteTable()
        {
            Console.Clear();
            var startX = (Measurements.GetWindowSizeX() / 2) - (Table.GetTableSizeX() / 2);
            //var startY = (Measurements.windowSizeY / 2) - (tableSizeY / 2);
            var startY = 0;

            Console.SetCursorPosition(startX, startY);
            Console.Write("   |   |   ");
            Console.SetCursorPosition(startX, startY + 1);
            Console.Write(" 7 | 8 | 9 ");
            Console.SetCursorPosition(startX, startY + 2);
            Console.Write("   |   |   ");
            Console.SetCursorPosition(startX, startY + 3);
            Console.Write("---+---+---");
            Console.SetCursorPosition(startX, startY + 4);
            Console.Write("   |   |   ");
            Console.SetCursorPosition(startX, startY + 5);
            Console.Write(" 4 | 5 | 6 ");
            Console.SetCursorPosition(startX, startY + 6);
            Console.Write("   |   |   ");
            Console.SetCursorPosition(startX, startY + 7);
            Console.Write("---+---+---");
            Console.SetCursorPosition(startX, startY + 8);
            Console.Write("   |   |   ");
            Console.SetCursorPosition(startX, startY + 9);
            Console.Write(" 1 | 2 | 3 ");
            Console.SetCursorPosition(startX, startY + 10);
            Console.Write("   |   |   ");
            WriteSuggestionToContinue();
        }

        /*
         * Вывод предложения продолжить
         */
        private static void WriteSuggestionToContinue()
        {
            var phrase = "Press enter for continue...";
            Console.SetCursorPosition(
                (Measurements.GetWindowSizeX() / 2) - (phrase.Length / 2),
                (Measurements.GetWindowSizeY() - 1));
            Console.Write(phrase);

            Console.ReadKey();
        }
    }
}
