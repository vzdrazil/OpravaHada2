using System;
using System.Collections.Generic;
using System.Text;

namespace OpravaHada2.ObjectClasses
{
    internal class Pixel
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
