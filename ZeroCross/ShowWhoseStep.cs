using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroCross
{
    class ShowWhoseStep
    {
        private static string player = "Player";
        private static string computer = "Computer";

        public static void WritePlayersName(bool isMultiplayer)
        {
            Console.SetCursorPosition(Measurements.GetWindowSizeX() - 1 - player.Length, 1);
            Console.Write(player);
            
            if (isMultiplayer)
            {
                Console.SetCursorPosition(1, 1);
                Console.Write(player);
            }
            else
            {
                Console.SetCursorPosition(1, 1);
                Console.Write(computer);
            }

            Console.SetCursorPosition(Measurements.GetWindowSizeX() / 2, Measurements.GetWindowSizeY() - 2);
        }
    }
}