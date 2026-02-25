using OpravaHada2.Enums;
using OpravaHada2.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpravaHada2.Functions
{
    internal class Movements
    {
        public static MovementDirect Movement(MovementDirect currentMovement)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentMovement != MovementDirect.Down)
                            currentMovement = MovementDirect.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentMovement != MovementDirect.Up)
                            currentMovement = MovementDirect.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (currentMovement != MovementDirect.Right)
                            currentMovement = MovementDirect.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentMovement != MovementDirect.Left)
                            currentMovement = MovementDirect.Right;
                        break;
                }
            }

            return currentMovement;
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
