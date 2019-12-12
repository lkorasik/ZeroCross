using System;

namespace ZeroCross
{
    class PlayerBot
    {
        const PlayersCodes Bot = PlayersCodes.BOT;
        const PlayersCodes Nothing = PlayersCodes.NULL;
        const PlayersCodes Player = PlayersCodes.PLAYER;

        /*
         * Делаем ход
         */
        public static (int x, int y) MakeStep()
        {
            PlayersCodes[,] field = Table.field;

            (int x, int y) turn;

            while (true)
            {
                turn = FindCombo(field);

                if (Table.IsCellEmpty(turn.x, turn.y)) break;
            }

            return turn;
        }

        /*
         * Думаем, куда сделать ход
         */
        private static (int x, int y) FindCombo(PlayersCodes[,] field)
        {
            var coord = FindLineWinCombo(field);
            if ((coord.x != -1) && (coord.y != -1)) return coord;
            coord = FindColumnWinCombo(field);
            if ((coord.x != -1) && (coord.y != -1)) return coord;
            coord = FindMainDiagonalWinCombo(field);
            if ((coord.x != -1) && (coord.y != -1)) return coord;
            coord = FindSubDiagonalWinCombo(field);
            if ((coord.x != -1) && (coord.y != -1)) return coord;

            coord = FindLineFailCombo(field);
            if ((coord.x != -1) && (coord.y != -1)) return coord;
            coord = FindColumnFailCombo(field);
            if ((coord.x != -1) && (coord.y != -1)) return coord;
            coord = FindMainDiagonalFailCombo(field);
            if ((coord.x != -1) && (coord.y != -1)) return coord;
            coord = FindSubDiagonalFailCombo(field);
            if ((coord.x != -1) && (coord.y != -1)) return coord;

            var rnd = new Random();
            return (rnd.Next(0, 3), rnd.Next(0, 3));
        }

        /*
         * Ищем линию, в которой нам не хватает одного элемента для победы
         */ 
        private static (int x, int y) FindLineWinCombo(PlayersCodes[,] field)
        {
            for(int y = 0; y < field.GetLength(1); y++)
            {
                if ((field[1, y] == Bot) && (field[2, y] == Bot) && (field[0, y] == Nothing)) return (0, y);
                if ((field[0, y] == Bot) && (field[2, y] == Bot) && (field[1, y] == Nothing)) return (1, y);
                if ((field[0, y] == Bot) && (field[1, y] == Bot) && (field[2, y] == Nothing)) return (2, y);
            }

            return (-1, -1);
        }


        /*
         * Ищем столбик, в которой нам не хватает одного элемента для победы
         */
        private static (int x, int y) FindColumnWinCombo(PlayersCodes[,] field)
        {
            for (int x = 0; x < field.GetLength(0); x++)
            {
                if ((field[x, 1] == Bot) && (field[x, 2] == Bot) && (field[x, 0] == Nothing)) return (x, 0);
                if ((field[x, 0] == Bot) && (field[x, 2] == Bot) && (field[x, 1] == Nothing)) return (x, 1);
                if ((field[x, 0] == Bot) && (field[x, 1] == Bot) && (field[x, 2] == Nothing)) return (x, 2);
            }

            return (-1, -1);
        }


        /*
         * Ищем главную диагональ, в которой нам не хватает одного элемента для победы
         */
        private static (int x, int y) FindMainDiagonalWinCombo(PlayersCodes[,] field)
        {
            if ((field[1, 1] == Bot) && (field[2, 2] == Bot) && (field[0, 0] == Nothing)) return (0, 0);
            if ((field[0, 0] == Bot) && (field[2, 2] == Bot) && (field[1, 1] == Nothing)) return (1, 1);
            if ((field[0, 0] == Bot) && (field[1, 1] == Bot) && (field[2, 2] == Nothing)) return (2, 2);

            return (-1, -1);
        }


        /*
         * Ищем второстепенную диагональ, в которой нам не хватает одного элемента для победы
         */
        private static (int x, int y) FindSubDiagonalWinCombo(PlayersCodes[,] field)
        {
            if ((field[1, 1] == Bot) && (field[0, 2] == Bot) && (field[2, 0] == Nothing)) return (2, 0);
            if ((field[0, 2] == Bot) && (field[2, 0] == Bot) && (field[1, 1] == Nothing)) return (1, 1);
            if ((field[2, 0] == Bot) && (field[1, 1] == Bot) && (field[0, 2] == Nothing)) return (0, 2);

            return (-1, -1);
        }


        /*
         * Ищем линию, в которой нам не хватает одного элемента до поражения
         */
        private static (int x, int y) FindLineFailCombo(PlayersCodes[,] field)
        {
            for (int y = 0; y < field.GetLength(1); y++)
            {
                if ((field[1, y] == Player) && (field[2, y] == Player) && (field[0, y] == Nothing)) return (0, y);
                if ((field[0, y] == Player) && (field[2, y] == Player) && (field[1, y] == Nothing)) return (1, y);
                if ((field[0, y] == Player) && (field[1, y] == Player) && (field[2, y] == Nothing)) return (2, y);
            }

            return (-1, -1);
        }


        /*
         * Ищем столбик, в которой нам не хватает одного элемента до поражения
         */
        private static (int x, int y) FindColumnFailCombo(PlayersCodes[,] field)
        {
            for (int x = 0; x < field.GetLength(0); x++)
            {
                if ((field[x, 1] == Player) && (field[x, 2] == Player) && (field[x, 0] == Nothing)) return (x, 0);
                if ((field[x, 0] == Player) && (field[x, 2] == Player) && (field[x, 1] == Nothing)) return (x, 1);
                if ((field[x, 0] == Player) && (field[x, 1] == Player) && (field[x, 2] == Nothing)) return (x, 2);
            }

            return (-1, -1);
        }


        /*
         * Ищем главную диагональ, в которой нам не хватает одного элемента до поражения
         */
        private static (int x, int y) FindMainDiagonalFailCombo(PlayersCodes[,] field)
        {
            if ((field[1, 1] == Player) && (field[2, 2] == Player) && (field[0, 0] == Nothing)) return (0, 0);
            if ((field[0, 0] == Player) && (field[2, 2] == Player) && (field[1, 1] == Nothing)) return (1, 1);
            if ((field[0, 0] == Player) && (field[1, 1] == Player) && (field[2, 2] == Nothing)) return (2, 2);

            return (-1, -1);
        }


        /*
         * Ищем второстепенную диагональ, в которой нам не хватает одного элемента до поражения
         */
        private static (int x, int y) FindSubDiagonalFailCombo(PlayersCodes[,] field)
        {
            if ((field[1, 1] == Player) && (field[0, 2] == Player) && (field[2, 0] == Nothing)) return (2, 0);
            if ((field[0, 2] == Player) && (field[2, 0] == Player) && (field[1, 1] == Nothing)) return (1, 1);
            if ((field[2, 0] == Player) && (field[1, 1] == Player) && (field[0, 2] == Nothing)) return (0, 2);

            return (-1, -1);
        }
    }
}
