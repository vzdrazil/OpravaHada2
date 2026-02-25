using OpravaHada2.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpravaHada2.Functions
{
    internal class Berrys
    {
        public static void BerryInit(Berry berryx_, Berry berryy_)
        {
            Console.SetCursorPosition(berryx_.position, berryy_.position);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("■");

        }
        public static int BerryEaten(Pixel head_, Berry berryx_, Berry berryy_, int score_, int screenwidth_, int screenheight_)
        {
            if (berryx_.position == head_.xpos && berryy_.position == head_.ypos)
            {
                score_++;
                berryx_.RandomPositon(screenwidth_);
                berryy_.RandomPositon(screenheight_);
            }
            return score_;
        }
    }
}
