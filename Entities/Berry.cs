using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;


namespace OpravaHada2.Entities
{
    public class Berry
    {
        private Random random = new Random();

        public Pixel Position { get; private set; }
        public Berry(int width, int height, Snake snake)
        {
            Respawn(width, height, snake.Body);
        }

        public void Respawn(int width, int height, List<Pixel> snakeBody)
        {
            int x, y;

            do
            {
                x = random.Next(1, width - 2);
                y = random.Next(1, height - 2);
            }
            while (snakeBody.Any(p => p.X == x && p.Y == y));

            Position = new Pixel(x, y, ConsoleColor.Cyan);
        }

        public void Draw()
        {
            Position.Draw();
        }
    }
}
