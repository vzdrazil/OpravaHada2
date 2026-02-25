using OpravaHada2.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpravaHada2.Functions
{
    internal class SnakeBody
    {
        public static bool Body(List<int> xposlijf_, List<int> yposlijf_, Pixel head_)
        {
            bool gameover_ = false;

            for (int i = 0; i < xposlijf_.Count; i++)
            {
                Console.SetCursorPosition(xposlijf_[i], yposlijf_[i]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("■");

                if (xposlijf_[i] == head_.xpos && yposlijf_[i] == head_.ypos)
                {
                    gameover_ = true;
                }

            }
            return gameover_;
        }
        public static void Head(Pixel head_)
        {
            Console.SetCursorPosition(head_.xpos, head_.ypos);
            Console.ForegroundColor = head_.schermkleur;
            Console.Write("■");
        }
        public static void AddHead(List<int> xposlijf_, List<int> yposlijf_, Pixel head_)
        {
            xposlijf_.Add(head_.xpos);
            yposlijf_.Add(head_.ypos);
        }
        public static void RemoveLastPoint(List<int> xposlijf_, List<int> yposlijf_, int score)
        {
            if (xposlijf_.Count > score)
            {
                xposlijf_.RemoveAt(0);
                yposlijf_.RemoveAt(0);
            }

        }
    }
}
