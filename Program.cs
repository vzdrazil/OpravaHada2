using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using OpravaHada2.Enums;
using OpravaHada2.Functions;
using OpravaHada2.ObjectClasses;

namespace OpravaHada
{
    class Program
    {        
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.WindowHeight = 20;
            Console.WindowWidth = 40;
            int screenwidth = Console.WindowWidth;
            int screenheight = Console.WindowHeight;
            Berry berryx = new Berry(screenwidth);
            Berry berryy = new Berry(screenheight);
            Console.CursorVisible = false;
            int score = 5;
            bool gameover = false;
            MovementDirect movement=MovementDirect.Right;

            Pixel head = new Pixel(screenwidth / 2, screenheight / 2, ConsoleColor.Red);

            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();
         
            while (!gameover)
            {
                gameover = Draw.DrawEnvironment(head, screenwidth, screenheight);
                if (gameover)
                {
                    break;
                }
                
                score = Berrys.BerryEaten(head, berryx, berryy, score, screenwidth, screenheight);
                
                gameover = SnakeBody.Body(xposlijf, yposlijf, head);
                if (gameover)
                {
                    break;
                }
               
                SnakeBody.Head(head);
                
                Berrys.BerryInit(berryx, berryy);
                
                movement = Movements.Movement(movement);

                SnakeBody.AddHead(xposlijf, yposlijf, head);

                Movements.NextMove(movement, head);

                SnakeBody.RemoveLastPoint(xposlijf, yposlijf, score);
            }

            Draw.GameoverScreen(screenwidth, screenheight, score);
        }

        

    }
}
