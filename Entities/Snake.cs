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

    Body.Add(new Pixel(10, 10, ConsoleColor.Green)); // hlava
    Body.Add(new Pixel(9, 10, ConsoleColor.Green));
    Body.Add(new Pixel(8, 10, ConsoleColor.Green));

    Direction = Direction.Right;
}

        public void Move(bool grow)
        {
            int newX = Head.X;
            int newY = Head.Y;

            switch (Direction)
            {
                case Direction.Up:
                    newY--;
                    break;

                case Direction.Down:
                    newY++;
                    break;

                case Direction.Left:
                    newX--;
                    break;

                case Direction.Right:
                    newX++;
                    break;
            }

            Pixel newHead = new Pixel(newX, newY, ConsoleColor.Green);

            Body.Insert(0, newHead);

            if (!grow)
            {
                Body.RemoveAt(Body.Count - 1);
            }
        }

        public void Grow()
        {
            Pixel tail = this.Body.Last();
            this.Body.Add(new Pixel(tail.X, tail.Y, ConsoleColor.Green));
        }

        public void Draw()
        {
            foreach (Pixel part in this.Body)
            {
                part.Draw();
            }
        }

        public bool CheckSelfCollision()
        {
            for (int i = 1; i < this.Body.Count; i++)
            {
                if (this.Head.X == this.Body[i].X &&
                    this.Head.Y == this.Body[i].Y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}