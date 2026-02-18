using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace OpravaHada
{
    class Program
    {
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
        class Berry
        {
            Random random = new Random();
            public int position { get; set; }
            public Berry(int screenWidthHeight_)
            {
                position = random.Next(1, screenWidthHeight_ - 2);
            }


            public void RandomPositon(int screenWidthHeight_)
            {
                position = random.Next(1, screenWidthHeight_ - 2);


            }
        }
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
        static int BerryEaten(Pixel head_,Berry berryx_,Berry berryy_,int score_,int screenwidth_,int screenheight_)
        {
            if (berryx_.position == head_.xpos && berryy_.position == head_.ypos)
            {
                score_++;
                berryx_.RandomPositon(screenwidth_);
                berryy_.RandomPositon(screenheight_);
            }
            return score_;
        }
        static bool Body(List<int> xposlijf_, List<int> yposlijf_,Pixel head_)
        {
            bool gameover_=false;

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
        static void Head(Pixel head_)
        {
            Console.SetCursorPosition(head_.xpos, head_.ypos);
            Console.ForegroundColor = head_.schermkleur;
            Console.Write("■");
        }
        static void BerryInit(Berry berryx_, Berry berryy_)
        {
            Console.SetCursorPosition(berryx_.position, berryy_.position);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("■");

        }
        static void AddHead(List<int> xposlijf_, List<int> yposlijf_, Pixel head_)
        {
            xposlijf_.Add(head_.xpos);
            yposlijf_.Add(head_.ypos);
        }
        static void NextMove(byte movement_, Pixel head_)
        {
            switch (movement_)
            {               
                case 3: head_.ypos--; break;
                case 2: head_.ypos++; break;
                case 1: head_.xpos--; break;
                case 0: head_.xpos++; break;
            }
        }
        static void RemoveLastPoint(List<int> xposlijf_, List<int> yposlijf_,int score)
        {
            if (xposlijf_.Count > score)
            {
                xposlijf_.RemoveAt(0);
                yposlijf_.RemoveAt(0);
            }

        }
        static void GameoverScreen(int screenwidth_, int screenheight_, int score_)
        {
            Console.Clear();
            Console.SetCursorPosition(screenwidth_ / 4, screenheight_ / 2);
            Console.WriteLine("Game Over! Score: " + score_);
            Console.ReadKey();
        }
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
            byte movement = 0;

            Pixel head = new Pixel(screenwidth / 2, screenheight / 2, ConsoleColor.Red);

            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();
         
            while (!gameover)
            {
                gameover = DrawEnvironment(head, screenwidth, screenheight);
                if (gameover)
                {
                    break;
                }
                // berry snědena
                score = BerryEaten(head, berryx, berryy, score, screenwidth, screenheight);
                // tělo
                gameover = Body(xposlijf, yposlijf, head);
                if (gameover)
                {
                    break;
                }
                // hlava
                Head(head);
                // berry
                BerryInit(berryx, berryy);
                // pohyb
                movement = Movement(movement);

                AddHead(xposlijf, yposlijf, head);

                NextMove(movement, head);

                RemoveLastPoint(xposlijf, yposlijf, score);
            }

            GameoverScreen(screenwidth, screenheight, score);
        }

        

    }
}
