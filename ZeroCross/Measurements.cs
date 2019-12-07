namespace ZeroCross
{
    class Measurements
    {
        private static int windowSizeX = 55;
        private static int windowSizeY = 12;
        private static int previewSizeX = windowSizeX;
        private static int previewSizeY = windowSizeY;

        /*
         * Получить размеры окна (по ширине)
         * Значение = количество столбцов в консоли
         */
        public static int GetWindowSizeX()
        {
            return windowSizeX;
        }

        /*
         * Получить ращмер окна по высоте
         * (значение = количество строк в консоли)
         */
        public static int GetWindowSizeY()
        {
            return windowSizeY;
        }

        /*
         * Получить ращмер окна с лого по Ширине
         * (значение = количество строк в консоли)
         */
        public static int GetPreviewSizeX()
        {
            return previewSizeX;
        }

        /*
         * Получить ращмер окна с лого по высоте
         * (значение = количество строк в консоли)
         */
        public static int GetPreviewSizeY()
        {
            return previewSizeY;
        }
    }
}
