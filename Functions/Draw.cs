using OpravaHada2.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpravaHada2.Functions
{
    internal class Draw
    {
        public static bool DrawEnvironment(Pixel head, int screenwidth, int screenheight)
        {
            Console.Clear();

            // kolize se zdí
            if (head.xpos == 0 || head.xpos == screenwidth - 1 ||
                head.ypos == 0 || head.ypos == screenheight - 1)
            {

                return true;
            }

            // rámeček
            for (int i = 0; i < screenwidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, screenheight - 1);
                Console.Write("■");
            }

            for (int i = 0; i < screenheight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(screenwidth - 1, i);
                Console.Write("■");
            }

            return false;
        }
        public static void GameoverScreen(int screenwidth_, int screenheight_, int score_)
        {
            Console.Clear();
            Console.SetCursorPosition(screenwidth_ / 4, screenheight_ / 2);
            Console.WriteLine("Game Over! Score: " + score_);
            Console.ReadKey();
        }
    }
}
