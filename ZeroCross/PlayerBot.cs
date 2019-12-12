using System;

namespace ZeroCross
{
    class PlayerBot
    {
        /*
         * Делаем ход
         */
        public static (int x, int y) MakeStep()
        {
            bool?[,] field = Table.field;

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
        private static (int x, int y) FindCombo(bool?[,] field)
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
        private static (int x, int y) FindLineWinCombo(bool?[,] field)
        {
            for(int y = 0; y < field.GetLength(1); y++)
            {
                if ((field[1, y] == false) && (field[2, y] == false) && (field[0, y] == null)) return (0, y);
                if ((field[0, y] == false) && (field[2, y] == false) && (field[1, y] == null)) return (1, y);
                if ((field[0, y] == false) && (field[1, y] == false) && (field[2, y] == null)) return (2, y);
            }

            return (-1, -1);
        }


        /*
         * Ищем столбик, в которой нам не хватает одного элемента для победы
         */
        private static (int x, int y) FindColumnWinCombo(bool?[,] field)
        {
            for (int x = 0; x < field.GetLength(0); x++)
            {
                if ((field[x, 1] == false) && (field[x, 2] == false) && (field[x, 0] == null)) return (x, 0);
                if ((field[x, 0] == false) && (field[x, 2] == false) && (field[x, 1] == null)) return (x, 1);
                if ((field[x, 0] == false) && (field[x, 1] == false) && (field[x, 2] == null)) return (x, 2);
            }

            return (-1, -1);
        }


        /*
         * Ищем главную диагональ, в которой нам не хватает одного элемента для победы
         */
        private static (int x, int y) FindMainDiagonalWinCombo(bool?[,] field)
        {
            if ((field[1, 1] == false) && (field[2, 2] == false) && (field[0, 0] == null)) return (0, 0);
            if ((field[0, 0] == false) && (field[2, 2] == false) && (field[1, 1] == null)) return (1, 1);
            if ((field[0, 0] == false) && (field[1, 1] == false) && (field[2, 2] == null)) return (2, 2);

            return (-1, -1);
        }


        /*
         * Ищем второстепенную диагональ, в которой нам не хватает одного элемента для победы
         */
        private static (int x, int y) FindSubDiagonalWinCombo(bool?[,] field)
        {
            if ((field[1, 1] == false) && (field[0, 2] == false) && (field[2, 0] == null)) return (2, 0);
            if ((field[0, 2] == false) && (field[2, 0] == false) && (field[1, 1] == null)) return (1, 1);
            if ((field[2, 0] == false) && (field[1, 1] == false) && (field[0, 2] == null)) return (0, 2);

            return (-1, -1);
        }


        /*
         * Ищем линию, в которой нам не хватает одного элемента до поражения
         */
        private static (int x, int y) FindLineFailCombo(bool?[,] field)
        {
            for (int y = 0; y < field.GetLength(1); y++)
            {
                if ((field[1, y] == true) && (field[2, y] == true) && (field[0, y] == null)) return (0, y);
                if ((field[0, y] == true) && (field[2, y] == true) && (field[1, y] == null)) return (1, y);
                if ((field[0, y] == true) && (field[1, y] == true) && (field[2, y] == null)) return (2, y);
            }

            return (-1, -1);
        }


        /*
         * Ищем столбик, в которой нам не хватает одного элемента до поражения
         */
        private static (int x, int y) FindColumnFailCombo(bool?[,] field)
        {
            for (int x = 0; x < field.GetLength(0); x++)
            {
                if ((field[x, 1] == true) && (field[x, 2] == true) && (field[x, 0] == null)) return (x, 0);
                if ((field[x, 0] == true) && (field[x, 2] == true) && (field[x, 1] == null)) return (x, 1);
                if ((field[x, 0] == true) && (field[x, 1] == true) && (field[x, 2] == null)) return (x, 2);
            }

            return (-1, -1);
        }


        /*
         * Ищем главную диагональ, в которой нам не хватает одного элемента до поражения
         */
        private static (int x, int y) FindMainDiagonalFailCombo(bool?[,] field)
        {
            if ((field[1, 1] == true) && (field[2, 2] == true) && (field[0, 0] == null)) return (0, 0);
            if ((field[0, 0] == true) && (field[2, 2] == true) && (field[1, 1] == null)) return (1, 1);
            if ((field[0, 0] == true) && (field[1, 1] == true) && (field[2, 2] == null)) return (2, 2);

            return (-1, -1);
        }


        /*
         * Ищем второстепенную диагональ, в которой нам не хватает одного элемента до поражения
         */
        private static (int x, int y) FindSubDiagonalFailCombo(bool?[,] field)
        {
            if ((field[1, 1] == true) && (field[0, 2] == true) && (field[2, 0] == null)) return (2, 0);
            if ((field[0, 2] == true) && (field[2, 0] == true) && (field[1, 1] == null)) return (1, 1);
            if ((field[2, 0] == true) && (field[1, 1] == true) && (field[0, 2] == null)) return (0, 2);

            return (-1, -1);
        }
    }
}
