using System;

namespace ZeroCross
{
    class Table
    {
        //NOTE: sizeX == sizeY
        private static int sizeX = 3;
        private static int sizeY = 3;
        //NOTE: tableSizeX == tableSizeY
        private static int tableSizeX = (sizeX - 1) * 4 + 3;
        private static int tableSizeY = (sizeY - 1) * 4 + 3;
        //null - empty
        //true - Player
        //false - Computer
        public static bool?[,] field = new bool?[sizeX, sizeY];
        public static char[,] fielsChar = new char[sizeX, sizeY];

        /*
         * Заполнение поля пустыми значениями
         */
        public static void InitField()
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    field[x, y] = null;
                }
            }
        }

        /*
         * Заполнение поля в соответствии с ходами
         */
        public static bool InsertValue(int x, int y, bool isUser)
        {
            if (field[x, y] != null) return false;
            else field[x, y] = isUser;
            return true;
        }

        /*
         * Проверка на то, что клетка пустая
         */
        public static bool IsCellEmpty(int x, int y)
        {
            if (x < 0 || x > 8 || y < 0 || y > 8) return false;
            return field[x, y] == null;
        }

        /*
         * Вывод поля на экран
         */
        public static void WriteTable()
        {
            Console.Clear();
            var startX = (Measurements.GetWindowSizeX() / 2) - (tableSizeX / 2);
            //var startY = (Measurements.windowSizeY / 2) - (tableSizeY / 2);
            var startY = 0;

            ConvertFromBoolToChar();

            Console.SetCursorPosition(startX, startY);
            Console.Write("   |   |   ");
            Console.SetCursorPosition(startX, startY + 1);
            Console.Write(" " + fielsChar[0, 0] + " | " + fielsChar[1, 0] + " | " + fielsChar[2, 0] + " ");
            Console.SetCursorPosition(startX, startY + 2);
            Console.Write("   |   |   ");
            Console.SetCursorPosition(startX, startY + 3);
            Console.Write("---+---+---");
            Console.SetCursorPosition(startX, startY + 4);
            Console.Write("   |   |   ");
            Console.SetCursorPosition(startX, startY + 5);
            Console.Write(" " + fielsChar[0, 1] + " | " + fielsChar[1, 1] + " | " + fielsChar[2, 1] + " ");
            Console.SetCursorPosition(startX, startY + 6);
            Console.Write("   |   |   ");
            Console.SetCursorPosition(startX, startY + 7);
            Console.Write("---+---+---");
            Console.SetCursorPosition(startX, startY + 8);
            Console.Write("   |   |   ");
            Console.SetCursorPosition(startX, startY + 9);
            Console.Write(" " + fielsChar[0, 2] + " | " + fielsChar[1, 2] + " | " + fielsChar[2, 2] + " ");
            Console.SetCursorPosition(startX, startY + 10);
            Console.Write("   |   |   ");
        }

        /*
         * Конвертация значений ячеек поля в Вывод на экран
         */
        private static void ConvertFromBoolToChar()
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    if (field[x, y] == true) fielsChar[x, y] = 'X';
                    if (field[x, y] == false) fielsChar[x, y] = 'O';
                    if (field[x, y] == null) fielsChar[x, y] = ' ';
                }
            }
        }

        /*
         * Получение размеров таблицы (по ширине)
         */
        public static int GetTableSizeX()
        {
            return tableSizeX;
        }

        /*
         * Получение размеров таблицы
         * (по высоте)
         */
        public static int GetTableSizeY()
        {
            return tableSizeY;
        }

        /*
         * Проверяем на то, что кто-то выйграл
         */
        public static bool? CheckWinLines()
        {
            if ((field[0, 0] == true) && (field[1, 0] == true) && (field[2, 0] == true)) return true;
            if ((field[0, 1] == true) && (field[1, 1] == true) && (field[2, 1] == true)) return true;
            if ((field[0, 2] == true) && (field[1, 2] == true) && (field[2, 2] == true)) return true;

            if ((field[0, 0] == true) && (field[0, 1] == true) && (field[0, 2] == true)) return true;
            if ((field[1, 0] == true) && (field[1, 1] == true) && (field[1, 2] == true)) return true;
            if ((field[2, 0] == true) && (field[2, 1] == true) && (field[2, 2] == true)) return true;

            if ((field[0, 0] == true) && (field[1, 1] == true) && (field[2, 2] == true)) return true;

            if ((field[2, 0] == true) && (field[1, 1] == true) && (field[0, 2] == true)) return true;


            if ((field[0, 0] == false) && (field[1, 0] == false) && (field[2, 0] == false)) return false;
            if ((field[0, 1] == false) && (field[1, 1] == false) && (field[2, 1] == false)) return false;
            if ((field[0, 2] == false) && (field[1, 2] == false) && (field[2, 2] == false)) return false;

            if ((field[0, 0] == false) && (field[0, 1] == false) && (field[0, 2] == false)) return false;
            if ((field[1, 0] == false) && (field[1, 1] == false) && (field[1, 2] == false)) return false;
            if ((field[2, 0] == false) && (field[2, 1] == false) && (field[2, 2] == false)) return false;

            if ((field[0, 0] == false) && (field[1, 1] == false) && (field[2, 2] == false)) return false;

            if ((field[2, 0] == false) && (field[1, 1] == false) && (field[0, 2] == false)) return false;

            return null;
        }

        /*
         * Проверяем наличие пустых полей
         */
        public static bool HaveEmptyField()
        {
            for (int y = 0; y < field.GetLength(0); y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    if (field[x, y] == null) return true;
                }
            }

            return false;
        }
    }
}
