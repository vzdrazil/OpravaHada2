
using System.Xml.Linq;
using OpravaHada2.Entities;
using OpravaHada2.Enums;

namespace OpravaHada2.Core
{
    public class Game
    {
        private Snake snake;
        private Berry berry;

        private int width = 40;
        private int height = 20;

        private bool gameOver;
        private int score;

        public void Run()
        {
            Initialize();

            while (!gameOver)
            {
                HandleInput();
                Update();
                Draw();

                Thread.Sleep(120);
            }

            GameOverScreen();
        }

        private void Initialize()
        {
            Console.CursorVisible = false;
            Console.WindowWidth = width;
            Console.WindowHeight = height;

            snake = new Snake();
            berry = new Berry(width, height,snake);
        }

        private void HandleInput()
        {
            if (!Console.KeyAvailable) return;

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (snake.Direction != Direction.Down)
                        snake.Direction = Direction.Up;
                    break;

                case ConsoleKey.DownArrow:
                    if (snake.Direction != Direction.Up)
                        snake.Direction = Direction.Down;
                    break;

                case ConsoleKey.LeftArrow:
                    if (snake.Direction != Direction.Right)
                        snake.Direction = Direction.Left;
                    break;

                case ConsoleKey.RightArrow:
                    if (snake.Direction != Direction.Left)
                        snake.Direction = Direction.Right;
                    break;
            }
        }

        private void Update()
        {
            bool grow = false;

            int nextX = snake.Head.X;
            int nextY = snake.Head.Y;

            switch (snake.Direction)
            {
                case Direction.Up: nextY--; break;
                case Direction.Down: nextY++; break;
                case Direction.Left: nextX--; break;
                case Direction.Right: nextX++; break;
            }

            if (nextX == berry.Position.X && nextY == berry.Position.Y)
            {
                grow = true;
                score++;
                berry.Respawn(width, height, snake.Body);
            }

            snake.Move(grow);

            CheckWallCollision();
            CheckSelfCollision();
        }

        private void CheckWallCollision()
        {
            if (snake.Head.X <= 0 || snake.Head.X >= width - 1 ||
                snake.Head.Y <= 0 || snake.Head.Y >= height - 1)
            {
                gameOver = true;
            }
        }

        

        private void CheckSelfCollision()
        {
            if (snake.CheckSelfCollision())
            {
                gameOver = true;
            }
        }

        private void Draw()
        {
            Console.Clear();

            DrawWalls();

            berry.Draw();
            snake.Draw();

            Console.SetCursorPosition(2, 0);
            Console.Write("Score: " + score);
        }

        private void DrawWalls()
        {
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");

                Console.SetCursorPosition(i, height - 1);
                Console.Write("#");
            }

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");

                Console.SetCursorPosition(width - 1, i);
                Console.Write("#");
            }
        }

        private void GameOverScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(width / 2 - 5, height / 2);

            Console.WriteLine("GAME OVER");
            Console.WriteLine("Score: " + score);

            Console.ReadKey();
        }
       
    }
}