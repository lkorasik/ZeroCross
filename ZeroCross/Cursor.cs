using System;

namespace ZeroCross
{
    class Cursor
    {
        private static int[,] positions;
        private static (int x, int y) temperPosition;
        private static char symbol = '>';

        private static int length;
        private static int startX;
        private static int startY;

        /*
         * Инициализация курсора
         */
        public static void InitCursor(bool isAfterGame = false)
        {
            InitParams(isAfterGame);

            InitCoordinatesMenuItems();

            InitStartCursorPosition();

            ListningKeyPress();
            //Эта штука нужна, чтоб прога после отработки не закрывалась
            //Console.ReadKey();
        }

        /*
         * вытаскивание необходимых координат из класса Menu
         */
        private static void InitParams(bool isAfterGame)
        {
            if (!isAfterGame)
            {
                length = Menu.GetLength();
                startX = Menu.GetStartPositionX();
                startY = Menu.GetStartPositionY();
            }
            else
            {
                length = ManuAfterGame.GetLength();
                startX = ManuAfterGame.GetStartPositionX();
                startY = ManuAfterGame.GetStartPositionY();
            }
        }

        /*
         * Вычислить координаты меню на экране
         */
        private static void InitCoordinatesMenuItems()
        {
            positions = new int[2, length];

            for (int i = 0; i < length; i++)
            {
                positions[0, i] = startX - 2;
                positions[1, i] = startY + i;
            }
        }

        /*
         * Установить курсор на стартовую позицию
         */
        private static void InitStartCursorPosition()
        {
            temperPosition.x = positions[0, 0];
            temperPosition.y = positions[1, 0];

            Console.SetCursorPosition(temperPosition.x, temperPosition.y);
            Console.Write(symbol);
        }

        /*
         * Получение сигнала о том, что пользователь нажал на какую-то кнопку
         */
        public static void ListningKeyPress()
        {
            var key = Console.ReadKey().Key;

            var newX = temperPosition.x;
            var newY = temperPosition.y;

            while (key != ConsoleKey.Enter)
            {
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        newY = MoveCursorUp(newY);
                        break;
                    case ConsoleKey.DownArrow:
                        newY = MoveCursorDown(newY);
                        break;
                }

                RedrawCursor(newY);
                temperPosition.y = newY;
                key = Console.ReadKey().Key;
            }
        }

        /*
         * Изменение координат курсора (движение вверх)
         */
        private static int MoveCursorUp(int newY)
        {
            newY--;
            if (newY < startY) newY++;
            return newY;
        }

        /*
         * Изменение координат курсора (движение вверх)
         */
        private static int MoveCursorDown(int newY)
        {
            newY++;
            if (newY == length + startY) newY--;
            return newY;
        }

        /*
         * Перерисовать курсор с учетом изменения позиции
         */
        private static void RedrawCursor(int newY)
        {
            Console.SetCursorPosition(temperPosition.x, temperPosition.y);
            Console.Write(" ");
            Console.SetCursorPosition(temperPosition.x, newY);
            Console.Write(symbol);
        }

        /*
         * Возвращает решение игрока
         */
        public static MenuDecision ReturnMainMenuDecision()
        {
            if (temperPosition.y == startY) return MenuDecision.PLAYER_VS_COMPUTER;
            if (temperPosition.y == startY + 1) return MenuDecision.PLAYER_VS_PLAYER;
            else return MenuDecision.EXIT;
        }

        public static AfterGameDesicion ReturnAfterGameDecision()
        {
            if (temperPosition.y == startY) return AfterGameDesicion.CONTINUE;
            return AfterGameDesicion.EXIT;
        }
    }
}
