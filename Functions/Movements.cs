using OpravaHada2.Enums;
using OpravaHada2.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpravaHada2.Functions
{
    internal class Movements
    {
        private static bool TimeToPress(DateTime tijd_)
        {
            if ((DateTime.Now - tijd_).TotalMilliseconds > 50)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
        public static MovementDirect Movement(MovementDirect movement)
        {
            
            DateTime tijd = DateTime.Now;
            bool buttonpressed = false;

            while (true)
            {
                if (TimeToPress(tijd))
                    break;

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo toets = Console.ReadKey(true);

                    if (toets.Key == ConsoleKey.UpArrow && movement != MovementDirect.Down && !buttonpressed)
                    {
                        movement = MovementDirect.Up;
                        buttonpressed = true;
                    }
                    if (toets.Key == ConsoleKey.DownArrow && movement != MovementDirect.Up && !buttonpressed)
                    {
                        movement = MovementDirect.Down;
                        buttonpressed = true;
                    }
                    if (toets.Key == ConsoleKey.LeftArrow && movement != MovementDirect.Right && !buttonpressed)
                    {
                        movement = MovementDirect.Left;
                        buttonpressed = true;
                    }
                    if (toets.Key == ConsoleKey.RightArrow && movement != MovementDirect.Left && !buttonpressed)
                    {
                        movement = MovementDirect.Right;
                        buttonpressed = true;
                    }
                }
            }

            return movement;
        }
        public static void NextMove(MovementDirect movement_, Pixel head_)
        {
            switch (movement_)
            {
                case MovementDirect.Up: head_.ypos--; break;
                case MovementDirect.Down: head_.ypos++; break;
                case MovementDirect.Left: head_.xpos--; break;
                case MovementDirect.Right: head_.xpos++; break;
            }
        }
    }
}
