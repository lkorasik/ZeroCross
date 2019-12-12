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
        public static PlayersCodes[,] field = new PlayersCodes[sizeX, sizeY];
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
                    field[x, y] = PlayersCodes.NULL;
                }
            }
        }

        /*
         * Заполнение поля в соответствии с ходами
         */
        public static bool InsertValue(int x, int y, PlayersCodes isUser)
        {
            if (field[x, y] != PlayersCodes.NULL) return false;
            else field[x, y] = isUser;
            return true;
        }

        /*
         * Проверка на то, что клетка пустая
         */
        public static bool IsCellEmpty(int x, int y)
        {
            if (x < 0 || x > 8 || y < 0 || y > 8) return false;
            return field[x, y] == PlayersCodes.NULL;
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

            ConvertFromPlayerCodesToChar();

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
        private static void ConvertFromPlayerCodesToChar()
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    if (field[x, y] == PlayersCodes.PLAYER) fielsChar[x, y] = 'X';
                    if (field[x, y] == PlayersCodes.BOT) fielsChar[x, y] = 'O';
                    if (field[x, y] == PlayersCodes.NULL) fielsChar[x, y] = ' ';
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
        public static PlayersCodes CheckWinLines()
        {
            var player = PlayersCodes.PLAYER;
            var bot = PlayersCodes.BOT;

            if ((field[0, 0] == player) && (field[1, 0] == player) && (field[2, 0] == player)) return player;
            if ((field[0, 1] == player) && (field[1, 1] == player) && (field[2, 1] == player)) return player;
            if ((field[0, 2] == player) && (field[1, 2] == player) && (field[2, 2] == player)) return player;

            if ((field[0, 0] == player) && (field[0, 1] == player) && (field[0, 2] == player)) return player;
            if ((field[1, 0] == player) && (field[1, 1] == player) && (field[1, 2] == player)) return player;
            if ((field[2, 0] == player) && (field[2, 1] == player) && (field[2, 2] == player)) return player;

            if ((field[0, 0] == player) && (field[1, 1] == player) && (field[2, 2] == player)) return player;

            if ((field[2, 0] == player) && (field[1, 1] == player) && (field[0, 2] == player)) return player;


            if ((field[0, 0] == bot) && (field[1, 0] == bot) && (field[2, 0] == bot)) return bot;
            if ((field[0, 1] == bot) && (field[1, 1] == bot) && (field[2, 1] == bot)) return bot;
            if ((field[0, 2] == bot) && (field[1, 2] == bot) && (field[2, 2] == bot)) return bot;

            if ((field[0, 0] == bot) && (field[0, 1] == bot) && (field[0, 2] == bot)) return bot;
            if ((field[1, 0] == bot) && (field[1, 1] == bot) && (field[1, 2] == bot)) return bot;
            if ((field[2, 0] == bot) && (field[2, 1] == bot) && (field[2, 2] == bot)) return bot;

            if ((field[0, 0] == bot) && (field[1, 1] == bot) && (field[2, 2] == bot)) return bot;
            
            if ((field[2, 0] == bot) && (field[1, 1] == bot) && (field[0, 2] == bot)) return bot;

            return PlayersCodes.NULL;
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
                    if (field[x, y] == PlayersCodes.NULL) return true;
                }
            }

            return false;
        }
    }
}
