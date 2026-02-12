using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OpravaHada
{
    class Program
    {
/* MOVEMENT:
0 = right
1 = left
2 = down
3 = up
*/
    static byte Movement(byte currentMovement)
        {
            byte movement = currentMovement;
            DateTime tijd_ = DateTime.Now;
            bool buttonpressed = false;

            while (true)
            {
                if ((DateTime.Now - tijd_).TotalMilliseconds > 50)
                    break;

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo toets = Console.ReadKey(true);

                    if (toets.Key == ConsoleKey.UpArrow && movement != 2 && !buttonpressed)
                    {
                        movement = 3;
                        buttonpressed = true;
                    }
                    if (toets.Key == ConsoleKey.DownArrow && movement != 3 && !buttonpressed)
                    {
                        movement = 2;
                        buttonpressed = true;
                    }
                    if (toets.Key == ConsoleKey.LeftArrow && movement != 0 && !buttonpressed)
                    {
                        movement = 1;
                        buttonpressed = true;
                    }
                    if (toets.Key == ConsoleKey.RightArrow && movement != 1 && !buttonpressed)
                    {
                        movement = 0;
                        buttonpressed = true;
                    }
                }
            }

            return movement;
        }

        static bool DrawEnvironment(Pixel head, int screenwidth, int screenheight)
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

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 20;
            Console.WindowWidth = 40;

            int screenwidth = Console.WindowWidth;
            int screenheight = Console.WindowHeight;

            Random random = new Random();
            int score = 5;
            bool gameover = false;

            Pixel head = new Pixel(screenwidth / 2, screenheight / 2, ConsoleColor.Red);

            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();

            int berryx = random.Next(1, screenwidth - 2);
            int berryy = random.Next(1, screenheight - 2);

            byte movement = 0;

            while (!gameover)
            {
                gameover = DrawEnvironment(head, screenwidth, screenheight);

                // berry snědena
                if (berryx == head.xpos && berryy == head.ypos)
                {
                    score++;
                    berryx = random.Next(1, screenwidth - 2);
                    berryy = random.Next(1, screenheight - 2);
                }

                // tělo
                for (int i = 0; i < xposlijf.Count; i++)
                {
                    Console.SetCursorPosition(xposlijf[i], yposlijf[i]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("■");

                    if (xposlijf[i] == head.xpos && yposlijf[i] == head.ypos)
                        gameover = true;
                }

                // hlava
                Console.SetCursorPosition(head.xpos, head.ypos);
                Console.ForegroundColor = head.schermkleur;
                Console.Write("■");

                // berry
                Console.SetCursorPosition(berryx, berryy);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");

                // pohyb
                movement = Movement(movement);

                xposlijf.Add(head.xpos);
                yposlijf.Add(head.ypos);

                switch (movement)
                {
                    case 3: head.ypos--; break;
                    case 2: head.ypos++; break;
                    case 1: head.xpos--; break;
                    case 0: head.xpos++; break;
                }

                if (xposlijf.Count > score)
                {
                    xposlijf.RemoveAt(0);
                    yposlijf.RemoveAt(0);
                }
            }

            Console.Clear();
            Console.SetCursorPosition(screenwidth / 4, screenheight / 2);
            Console.WriteLine("Game Over! Score: " + score);
            Console.ReadKey();
        }

        class Pixel
        {
            public int xpos { get; set; }
            public int ypos { get; set; }
            public ConsoleColor schermkleur { get; set; }

            public Pixel(int x, int y, ConsoleColor color)
            {
                xpos = x;
                ypos = y;
                schermkleur = color;
            }
        }
    }

}
