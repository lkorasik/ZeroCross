using System;

namespace ZeroCross
{
    class Program
    {
        static void Main(string[] args)
        {
            IsConsoleCursorVisible();
            Music.InitMusic();
            Preview.InitPreview();
            Menu.InitMenu();

            Cursor.InitCursor();
            var decision = Cursor.ReturnMainMenuDecision();

            if (decision == MenuDecision.EXIT) Exit();

            if (decision == MenuDecision.PLAYER_VS_PLAYER)
                ShowWhoseStep.WritePlayersName(true);
            else
                ShowWhoseStep.WritePlayersName(false);

            while (true)
            {
                ShowCoordinatesOfCells.WriteTable();

                if (decision == MenuDecision.PLAYER_VS_PLAYER)
                    Game.StartGame(GameMode.PLAYER_VS_PLAYER);
                else if (decision == MenuDecision.PLAYER_VS_COMPUTER)
                    Game.StartGame(GameMode.PLAYER_VS_COMPUTER);

                ManuAfterGame.InitMenu();
                Cursor.InitCursor(true);
                var decision0 = Cursor.ReturnAfterGameDecision();
                if (decision0 == AfterGameDesicion.EXIT) break;
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
