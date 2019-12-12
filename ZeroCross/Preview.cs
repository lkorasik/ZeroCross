using System;

namespace ZeroCross
{
    class Preview
    {
        private static ConsoleColor[,] field = new ConsoleColor[Measurements.GetPreviewSizeX(), Measurements.GetPreviewSizeY()];

        /*
         * Инициализация первого изображения м названием
         * Инициализация фона
         * Установка размеров окна
         * Добавление букв в поле
         * вывод поля
         */
        public static void InitPreview()
        {
            FillBackground();

            SetWindowSize();

            InitLetters();

            Write();

            WriteSuggstionForContinue();

            WriteAuthor();

            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
        }

        /*
         * Заполнение массива цветов красным и черным цветом
         * первые 7 строк - красные
         * осатльные 2 - черные
         */
        private static void FillBackground()
        {
            for (int x = 0; x < Measurements.GetPreviewSizeX(); x++)
            {
                for (int y = 0; y < Measurements.GetPreviewSizeY(); y++)
                {
                    if (y >= 10) field[x, y] = ConsoleColor.Black;
                    else field[x, y] = ConsoleColor.Red;
                }
            }
        }

        /*
         * Вывод поля на экран
         */
        private static void Write()
        {
            Console.Clear();

            for (int y = 0; y < Measurements.GetWindowSizeY(); y++)
            {
                for (int x = 0; x < Measurements.GetWindowSizeX(); x++)
                {
                    Console.BackgroundColor = field[x, y];
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        /*
         * Вывод предложения для продолжения
         */
        private static void WriteSuggstionForContinue()
        {
            var phrase = "Press any key for continue...";
            var start = (Measurements.GetWindowSizeX() / 2) - (phrase.Length / 2);
            Console.SetCursorPosition(start, Measurements.GetWindowSizeY() - 3);
            Console.Write(phrase);
        }

        /*
         * Вывод имени (псевдонима) автора игры
         */
        private static void WriteAuthor()
        {
            var phrase = "Written by: SoloLev 2019";
            var start = (Measurements.GetPreviewSizeX() / 2) - (phrase.Length / 2);
            Console.SetCursorPosition(start, Measurements.GetWindowSizeY() - 1);
            Console.Write(phrase);
        }

        /*
         * Установка размеров окна
         * 
         * NOTE: если убрать, две посление строчки, 
         * то все будет не правильно отображаться
         */
        private static void SetWindowSize()
        {
            Console.WindowWidth = Measurements.GetWindowSizeX();
            Console.WindowHeight = Measurements.GetWindowSizeY();
            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            Console.BufferWidth = Measurements.GetWindowSizeX();
            Console.BufferHeight = Measurements.GetWindowSizeY();
            Console.WindowWidth = Measurements.GetWindowSizeX();
            Console.WindowHeight = Measurements.GetWindowSizeY();
        }

        /*
         * Вставка букв в поле в правильном порядке
         */
        private static void InitLetters()
        {
            int size = 6;

            InitLetterZ(ConsoleColor.Black, 1, 2);
            InitLetterE(ConsoleColor.Black, size + 1, 2);
            InitLetterR(ConsoleColor.Black, 2 * size + 1, 2);
            InitLetterO(ConsoleColor.Black, 3 * size + 1, 2);
            InitLetterC(ConsoleColor.Black, 4 * size + 1, 3);
            InitLetterR(ConsoleColor.Black, 5 * size + 1, 3);
            InitLetterO(ConsoleColor.Black, 6 * size + 1, 3);
            InitLetterS(ConsoleColor.Black, 7 * size + 1, 3);
            InitLetterS(ConsoleColor.Black, 8 * size + 1, 3);
        }

        /*
         * Буква Z
         */
        private static void InitLetterZ(ConsoleColor color, int x, int y)
        {
            field[0 + x, 0 + y] = color;
            field[1 + x, 0 + y] = color;
            field[2 + x, 0 + y] = color;
            field[3 + x, 0 + y] = color;
            field[4 + x, 0 + y] = color;

            field[3 + x, 1 + y] = color;
            field[2 + x, 2 + y] = color;
            field[1 + x, 3 + y] = color;

            field[0 + x, 4 + y] = color;
            field[1 + x, 4 + y] = color;
            field[2 + x, 4 + y] = color;
            field[3 + x, 4 + y] = color;
            field[4 + x, 4 + y] = color;
        }

        /*
         * Буква E
         */
        private static void InitLetterE(ConsoleColor color, int x, int y)
        {
            field[0 + x, 0 + y] = color;
            field[1 + x, 0 + y] = color;
            field[2 + x, 0 + y] = color;
            field[3 + x, 0 + y] = color;
            field[4 + x, 0 + y] = color;

            field[0 + x, 1 + y] = color;
            field[0 + x, 2 + y] = color;
            field[0 + x, 3 + y] = color;

            field[1 + x, 2 + y] = color;
            field[2 + x, 2 + y] = color;
            field[3 + x, 2 + y] = color;
            field[4 + x, 2 + y] = color;

            field[0 + x, 4 + y] = color;
            field[1 + x, 4 + y] = color;
            field[2 + x, 4 + y] = color;
            field[3 + x, 4 + y] = color;
            field[4 + x, 4 + y] = color;
        }

        /*
         * Буква C
         */
        private static void InitLetterC(ConsoleColor color, int x, int y)
        {
            field[0 + x, 0 + y] = color;
            field[1 + x, 0 + y] = color;
            field[2 + x, 0 + y] = color;
            field[3 + x, 0 + y] = color;
            field[4 + x, 0 + y] = color;

            field[0 + x, 1 + y] = color;
            field[0 + x, 2 + y] = color;
            field[0 + x, 3 + y] = color;

            field[0 + x, 4 + y] = color;
            field[1 + x, 4 + y] = color;
            field[2 + x, 4 + y] = color;
            field[3 + x, 4 + y] = color;
            field[4 + x, 4 + y] = color;
        }

        /*
         * Буква R
         */
        private static void InitLetterR(ConsoleColor color, int x, int y)
        {
            field[0 + x, 0 + y] = color;
            field[0 + x, 1 + y] = color;
            field[0 + x, 2 + y] = color;
            field[0 + x, 3 + y] = color;
            field[0 + x, 4 + y] = color;

            field[1 + x, 0 + y] = color;
            field[2 + x, 0 + y] = color;
            field[3 + x, 0 + y] = color;

            field[4 + x, 1 + y] = color;

            field[1 + x, 2 + y] = color;
            field[2 + x, 2 + y] = color;
            field[3 + x, 2 + y] = color;

            field[2 + x, 3 + y] = color;
            field[3 + x, 4 + y] = color;
        }

        /*
         * Буква O
         */
        private static void InitLetterO(ConsoleColor color, int x, int y)
        {
            field[0 + x, 0 + y] = color;
            field[1 + x, 0 + y] = color;
            field[2 + x, 0 + y] = color;
            field[3 + x, 0 + y] = color;
            field[4 + x, 0 + y] = color;

            field[0 + x, 1 + y] = color;
            field[0 + x, 2 + y] = color;
            field[0 + x, 3 + y] = color;

            field[4 + x, 1 + y] = color;
            field[4 + x, 2 + y] = color;
            field[4 + x, 3 + y] = color;

            field[0 + x, 4 + y] = color;
            field[1 + x, 4 + y] = color;
            field[2 + x, 4 + y] = color;
            field[3 + x, 4 + y] = color;
            field[4 + x, 4 + y] = color;
        }

        /*
         * Буква S
         */
        private static void InitLetterS(ConsoleColor color, int x, int y)
        {
            field[1 + x, 0 + y] = color;
            field[2 + x, 0 + y] = color;
            field[3 + x, 0 + y] = color;

            field[0 + x, 1 + y] = color;

            field[1 + x, 2 + y] = color;
            field[2 + x, 2 + y] = color;
            field[3 + x, 2 + y] = color;

            field[4 + x, 3 + y] = color;

            field[1 + x, 4 + y] = color;
            field[2 + x, 4 + y] = color;
            field[3 + x, 4 + y] = color;
        }
    }
}
