using System;

namespace ZeroCross
{
    class Program
    {
        static void Main(string[] args)
        {
            IsConsoleCursorVisible();
            Preview.InitPreview();
            Menu.InitMenu();

            while (true)
            {
                Cursor.InitCursor();
                var decision = Cursor.ReturnDecision();

                if (decision == Decision.EXIT) break;
                if (decision == Decision.NEW_GAME)
                {
                    ShowCoordinatesOfCells.WriteTable();
                    Game.StartGame();
                }

                ManuAfterGame.InitMenu();
            }

            Exit();
        }

        /*
         * Выход из игры
         */
        private static void Exit()
        {
            Console.Clear();
            Environment.Exit(0);
        }

        /*
         * Установка видимости курсора консоли
         * (Именно курсор консоли, который не имеет никакого отношения к
         * классу Cursor)
         */
        private static void IsConsoleCursorVisible(bool isVisible = false)
        {
            Console.CursorVisible = isVisible;
        }
    }
}
