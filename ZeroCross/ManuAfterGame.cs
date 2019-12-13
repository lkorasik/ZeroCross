using System;

namespace ZeroCross
{
    class ManuAfterGame
    {
        private static string[] menuItems;
        private static int length;
        private static int startX;
        private static int startY;

        /*
         * Инициализация меню
         * инициализация списка меню
         * инициализация стартовых координат
         * вывод на экран
         */
        public static void InitMenu()
        {
            Console.Clear();

            InitMenuArray();

            InitCoordinates();

            WriteMenu();
        }

        /*
         * Инициализация координат
         */
        private static void InitCoordinates()
        {
            var max = GetMaxStringLength();

            startX = (Measurements.GetWindowSizeX() / 2) - (max / 2);
            startY = (Measurements.GetWindowSizeY() / 2) - (length / 2);
        }

        /*
         * Инициализация списка меню
         */
        private static void InitMenuArray()
        {
            menuItems = new string[]
            {
                "1) Play again",
                "2) Exit"
            };

            length = menuItems.Length;
        }

        /*
         * Ввыод меню на экран
         */
        private static void WriteMenu()
        {
            Console.SetCursorPosition(startX, startY);

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(menuItems[i]);
                Console.SetCursorPosition(startX, startY + i + 1);
            }
        }

        /*
         * Вычислить максимальную длинну строчки в массиве
         * (для того, чтоб отображать список по середине)
         */
        private static int GetMaxStringLength()
        {
            var max = int.MinValue;

            for (int i = 0; i < length; i++)
            {
                if (menuItems[i].Length > max) max = menuItems[i].Length;
            }

            return max;
        }

        /*
         * Получение высоты списка
         * получение количества элементов
         */
        public static int GetLength()
        {
            return length;
        }

        /*
         * Получение координаты начала списка (левый верхний угол)
         */
        public static int GetStartPositionX()
        {
            return startX;
        }

        /*
         * Получение координаты начала списка (левый верхний угол)
         */
        public static int GetStartPositionY()
        {
            return startY;
        }
    }
}
