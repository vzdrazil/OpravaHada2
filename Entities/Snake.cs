using OpravaHada2.Enums;



namespace OpravaHada2.Entities
{
    public class Snake
    {
        public List<Pixel> Body { get; private set; }

        public Direction Direction { get; set; }

        public Pixel Head => Body[0];

        public Snake()
{
    Body = new List<Pixel>();

    Body.Add(new Pixel(10, 10, ConsoleColor.Green));
    Body.Add(new Pixel(9, 10, ConsoleColor.Green));
    Body.Add(new Pixel(8, 10, ConsoleColor.Green));

    Direction = Direction.Right;
}

        public void Move(bool grow)
        {
            Pixel newHead = GetNextHeadPosition();
            AddHead(newHead);

            if (!grow)
                RemoveTail();
        }

        private Pixel GetNextHeadPosition()
        {
            int newX = Head.X;
            int newY = Head.Y;

            switch (Direction)
            {
                case Direction.Up: newY--; break;
                case Direction.Down: newY++; break;
                case Direction.Left: newX--; break;
                case Direction.Right: newX++; break;
            }

            return new Pixel(newX, newY, ConsoleColor.Green);
        }

        private void AddHead(Pixel newHead)
        {
            Body.Insert(0, newHead);
        }

        private void RemoveTail()
        {
            Body.RemoveAt(Body.Count - 1);
        }

       

        public void Grow()
        {
            Pixel tail = Body.Last();
            Body.Add(new Pixel(tail.X, tail.Y, ConsoleColor.Green));
        }

        public void DrawSnake()
        {
            foreach (Pixel part in Body)
            {
                part.DrawPixel();
            }
        }

        public bool CheckSelfCollision()
        {
            for (int i = 1; i < Body.Count; i++)
            {
                if (Head.X == Body[i].X &&
                    Head.Y == Body[i].Y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}