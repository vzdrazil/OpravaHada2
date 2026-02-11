using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

///█ ■
////https://www.youtube.com/watch?v=SGZgvMwjq2U
///

/* MOVEMENT: 
    0 = right
    1 = left
    2 = down    
    3 = up
 
 
 
 
 
 */
namespace OpravaHada
{
    class Program
    {

        static void DrawEnvironment(Pixel hoofd_, int screenwidth_, int screenheight_, bool gameover_)
        {
            Console.Clear();
            if (hoofd_.xpos == screenwidth_ - 1 || hoofd_.xpos == 0 || hoofd_.ypos == screenheight_ - 1 || hoofd_.ypos == 0)
            {
                gameover_ = true;
            }
            for (int i = 0; i < screenwidth_; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
            }
            for (int i = 0; i < screenwidth_; i++)
            {
                Console.SetCursorPosition(i, screenheight_ - 1);
                Console.Write("■");
            }
            for (int i = 0; i < screenheight_; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
            }
            for (int i = 0; i < screenheight_; i++)
            {
                Console.SetCursorPosition(screenwidth_ - 1, i);
                Console.Write("■");
            }
            Console.ForegroundColor = ConsoleColor.Green;
        }


        static void Main(string[] args)
        {
            Console.WindowHeight = 16;
            Console.WindowWidth = 32;
            int screenwidth = Console.WindowWidth;
            int screenheight = Console.WindowHeight;
            Random randomnummer = new Random();
            int score = 5;
            bool gameover = false;
            Pixel hoofd = new Pixel(screenwidth / 2, screenheight / 2, ConsoleColor.Red);
            byte movement = 0;
            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();
            int berryx = randomnummer.Next(0, screenwidth);
            int berryy = randomnummer.Next(0, screenheight);
            DateTime tijd = DateTime.Now;
            DateTime tijd2 = DateTime.Now;
            bool buttonpressed = false;




            while (true)
            {
                Console.Clear();
                if (hoofd.xpos == screenwidth - 1 || hoofd.xpos == 0 || hoofd.ypos == screenheight - 1 || hoofd.ypos == 0)
                {
                    gameover = true;
                }
                for (int i = 0; i < screenwidth; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                }
                for (int i = 0; i < screenwidth; i++)
                {
                    Console.SetCursorPosition(i, screenheight - 1);
                    Console.Write("■");
                }
                for (int i = 0; i < screenheight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");
                }
                for (int i = 0; i < screenheight; i++)
                {
                    Console.SetCursorPosition(screenwidth - 1, i);
                    Console.Write("■");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                if (berryx == hoofd.xpos && berryy == hoofd.ypos)
                {
                    score++;
                    berryx = randomnummer.Next(1, screenwidth - 2);
                    berryy = randomnummer.Next(1, screenheight - 2);
                }
                for (int i = 0; i < xposlijf.Count(); i++)
                {
                    Console.SetCursorPosition(xposlijf[i], yposlijf[i]);
                    Console.Write("■");
                    if (xposlijf[i] == hoofd.xpos && yposlijf[i] == hoofd.ypos)
                    {
                        gameover = true;
                    }
                }
                if (gameover == true)
                {
                    break;
                }
                Console.SetCursorPosition(hoofd.xpos, hoofd.ypos);
                Console.ForegroundColor = hoofd.schermkleur;
                Console.Write("■");
                Console.SetCursorPosition(berryx, berryy);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");
                tijd = DateTime.Now;
                buttonpressed = false;
                while (true)
                {
                    tijd2 = DateTime.Now;
                    if (tijd2.Subtract(tijd).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = Console.ReadKey(true);

                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != 2 && buttonpressed == false)
                        {
                            movement = 3;
                            buttonpressed = true;
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != 3 && buttonpressed == false)
                        {
                            movement = 2;
                            buttonpressed = true;
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != 0 && buttonpressed == false)
                        {
                            movement = 1;
                            buttonpressed = true;
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != 1 && buttonpressed == false)
                        {
                            movement = 0;
                            buttonpressed = true;
                        }
                    }
                }
                xposlijf.Add(hoofd.xpos);
                yposlijf.Add(hoofd.ypos);
                switch (movement)
                {
                    case 3:
                        hoofd.ypos--;
                        break;
                    case 2:
                        hoofd.ypos++;
                        break;
                    case 1:
                        hoofd.xpos--;
                        break;
                    case 0:
                        hoofd.xpos++;
                        break;
                }



                if (xposlijf.Count() > score)
                {
                    xposlijf.RemoveAt(0);
                    yposlijf.RemoveAt(0);
                }
            }
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
        }
        class Pixel
        {

            public int xpos { get; set; }
            public int ypos { get; set; }
            public ConsoleColor schermkleur { get; set; }
            public Pixel(int xpos, int ypos, ConsoleColor schermkleur)
            {
                this.xpos = xpos;
                this.ypos = ypos;
                this.schermkleur = schermkleur;
            }
        }
    }
}
//¦