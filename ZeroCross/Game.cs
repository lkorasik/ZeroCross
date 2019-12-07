using System;

namespace ZeroCross
{
    class Game
    {
        private static bool isUsersStep = false;

        /*
         * Метод, где происходит сам процесс игры
         */
        public static void StartGame()
        {
            Console.Clear();

            ShowCoordinatesOfCells.WriteTable();

            Table.InitField();
            Table.WriteTable();
            (int x, int y) stepCoordinates = (-1, -1);

            bool? winner = CheckWinLine();

            while ((winner == null) && HaveEmptyField())
            {
                var isContinue = CheckWinLine();
                if (isContinue == null) ChangeStep();
                else break;

                if (isUsersStep)
                    stepCoordinates = GetUserStep();
                else
                    stepCoordinates = GetComputerStep();

                //stepCoordinates = ConvertStep(step);
                Table.InsertValue(stepCoordinates.x, stepCoordinates.y, isUsersStep);
                Table.WriteTable();

                winner = CheckWinLine();
            }

            FinishGame(winner);
        }

        /*
         * Метод завершения игры
         */
        private static void FinishGame(bool? winner)
        {
            var phrase = " win!!! Press enter for continue...";
            if (winner == true) phrase = "User" + phrase;
            else if (winner == false) phrase = "Computer" + phrase;
            else phrase = "Nobody wins!!! Press enter for continue...";

            Console.SetCursorPosition((Measurements.GetWindowSizeX() / 2 - phrase.Length / 2), (Measurements.GetWindowSizeY() - 1));
            Console.Write(phrase);

            Console.ReadLine();
        }

        /*
         * Метод для смены флага (того, кто ходит)
         */
        private static void ChangeStep()
        {
            isUsersStep = !isUsersStep;
        }

        /*
         * Чтение и обработка ввода пользователя
         */
        private static (int x, int y) GetUserStep()
        {
            (int x, int y) coordStep = (-1, -1);
            var curPosX = Console.CursorLeft;
            var curPosY = Console.CursorTop;

            while (true)
            {
                //var step = int.Parse(Console.ReadLine());
                var step = GetUserChoice();
                Console.SetCursorPosition(curPosX, curPosY);
                coordStep = ConvertStep(step);

                if (step < 0 || step > 8 || !Table.IsCellEmpty(coordStep.x, coordStep.y)) continue;

                return coordStep;
            }
        }

        /*
         * Обработка ввода
         */
        private static int GetUserChoice()
        {
            var step = -1;
            try
            {
                step = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

            }

            return step;
        }

        /*
         * Генерация ввода со стороны компьютера
         */
        private static (int x, int y) GetComputerStep()
        {
            (int x, int y) coordStep = (-1, -1);
            var rnd = new Random();

            while (true)
            {
                var step = rnd.Next(0, 8);
                coordStep = ConvertStep(step);

                if (step < 0 || step > 8 || !Table.IsCellEmpty(coordStep.x, coordStep.y)) continue;

                return coordStep;
            }
        }

        /*
         * Конвертировать номер ячейки в ее координаты
         */
        private static (int x, int y) ConvertStep(int step)
        {
            (int x, int y) stepCoordinates = (-1, -1);

            switch (step)
            {
                case 0: stepCoordinates = (0, 0); break;
                case 1: stepCoordinates = (1, 0); break;
                case 2: stepCoordinates = (2, 0); break;
                case 3: stepCoordinates = (0, 1); break;
                case 4: stepCoordinates = (1, 1); break;
                case 5: stepCoordinates = (2, 1); break;
                case 6: stepCoordinates = (0, 2); break;
                case 7: stepCoordinates = (1, 2); break;
                case 8: stepCoordinates = (2, 2); break;
            }

            return stepCoordinates;
        }

        /*
         * Проверить наличие выйгрышных линий
         */
        private static bool? CheckWinLine()
        {
            return Table.CheckWinLines();
        }

        /*
         * Проверяем наличие пустых полей
         */
        private static bool HaveEmptyField()
        {
            return Table.HaveEmptyField();
        }
    }
}
