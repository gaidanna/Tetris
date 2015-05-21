using System;
using Tetris.Shapes;

namespace Tetris
{
    public class Game
    {
        private Score score;
        private System.Threading.Timer timer;
        private Board board;
        private Shape letterShape;
        private Coordinate coordinate;
        private Random random;
        private object sync = new object();

        public Game()
        {
            random = new Random();
            board = new Board();
            score = new Score();
        }

        public void Start()
        {
            letterShape = GetNextLetter();
            coordinate = GetStartCoordinate();
            StartTimer();

            var keyboard = new Keyboard();
            keyboard.KeyPressed += KeyPressed;
            keyboard.OnKeyPressed();
        }

        private void KeyPressed(ConsoleKeyInfo key)
        {
            lock (sync)
            {
                if (key.Key == ConsoleKey.RightArrow)
                {
                    var nextCoordinate = new Coordinate(coordinate.GetColumn() + 1, coordinate.GetRow());
                    if (board.CanDraw(letterShape, nextCoordinate))
                    {
                        coordinate = nextCoordinate;
                    }
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    var nextCoordinate = new Coordinate(coordinate.GetColumn() - 1, coordinate.GetRow());
                    if (board.CanDraw(letterShape, nextCoordinate))
                    {
                        coordinate = nextCoordinate;
                    }
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    var nextCoordinate = new Coordinate(coordinate.GetColumn(), coordinate.GetRow() + 1);
                    if (board.CanDraw(letterShape, nextCoordinate))
                    {
                        coordinate = nextCoordinate;
                    }
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    var clonedLetter = letterShape.Clone();
                    clonedLetter.Rotate();

                    if (board.CanDraw(clonedLetter, coordinate))
                    {
                        letterShape = clonedLetter;
                    }
                }

                this.CollapseField();
                Console.SetCursorPosition(0, 0);
                this.score.Draw();
                this.board.DrawBoard(this.letterShape, this.coordinate);
            }
        }

        private void CollapseField()
        {
            int num = 0;

            for (int row = 0; row < this.board.GetHeight(); row++)
            {
                if (this.board.IsRowFull(row))
                {
                    num++;
                    this.board.ClearRow(row);

                    for (int firstRowIndex = row; firstRowIndex > 0; firstRowIndex--)
                    {
                        this.board.SwitchRows(firstRowIndex, firstRowIndex - 1);
                    }
                }
            }
            switch (num)
            {
                case 1:
                    this.score.AddScore(100);
                    break;
                case 2:
                    this.score.AddScore(300);
                    break;
                case 3:
                    this.score.AddScore(700);
                    break;
                case 4:
                    this.score.AddScore(1500);
                    break;
            }
        }

        private void StartTimer()
        {
            timer = new System.Threading.Timer(Tick, null, new TimeSpan(0, 0, 1), TimeSpan.FromMilliseconds(500));
        }

        private void Tick(object state)
        {
            lock (sync)
            {
                if (this.board.CanDraw(this.letterShape, this.coordinate))
                {
                    var nextCoordinate = new Coordinate(coordinate.GetColumn(), coordinate.GetRow() + 1);

                    if (board.CanDraw(letterShape, nextCoordinate))
                    {
                        coordinate = nextCoordinate;
                    }
                    else
                    {
                        board.IncorporateLetter(letterShape, coordinate);
                        letterShape = GetNextLetter();
                        coordinate = GetStartCoordinate();
                    }
                }
                else
                {
                    Console.WriteLine("End");
                    this.StopTimer();
                }
                this.CollapseField();
                Console.SetCursorPosition(0, 0);
                this.score.Draw();
                this.board.DrawBoard(this.letterShape, this.coordinate);
            }
        }

        private void StopTimer()
        {
            this.timer.Dispose();
        }

        private Shape GetNextLetter()
        {
            var letterNumber = random.Next(0, 7);

            switch (letterNumber)
            {
                case 0: return new Z_Shape();
                case 1: return new S_Shape();
                case 2: return new L_Shape();
                case 3: return new J_Shape();
                case 4: return new O_Shape();
                case 5: return new T_Shape();
                default: return new I_Shape();
            }
        }

        private Coordinate GetStartCoordinate()
        {
            return new Coordinate(4, 0);
        }
    }
}
