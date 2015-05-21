using System;
using Tetris.Shapes;

namespace Tetris
{
    class Board
    {
        private Cell[,] board;

        public Board()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            board = new Cell[20, 10];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = new Cell(ConsoleColor.Gray);
                }
            }
        }

        public int GetWidth()
        {
            return board.GetLength(1);
        }

        public int GetHeight()
        {
            return board.GetLength(0);
        }

        public bool IsRowFull(int row)
        {
            for (int column = 0; column < GetWidth(); column++)
            {
                if (board[row, column].IsEmpty())
                {
                    return false;
                }
            }
            return true;
        }

        public void ClearRow(int row)
        {
            for (int column = 0; column < GetWidth(); column++)
            {
                board[row, column] = new Cell(ConsoleColor.Gray);
            }
        }

        public void SwitchRows(int currentRow, int previousRow)
        {
            for (int column = 0; column < GetWidth(); column++)
            {
                var temp = board[currentRow, column];
                board[currentRow, column] = board[previousRow, column];
                board[previousRow, column] = temp;
            }
        }

        public void DrawBoard(Shape shape, Coordinate coordinate)
        {
            for (int row = 0; row < GetHeight(); row++)
            {
                for (int column = 0; column < GetWidth(); column++)
                {
                    var isLetterZone = row >= coordinate.GetRow() &&
                                       row < coordinate.GetRow() + shape.GetHeight() &&
                                       column >= coordinate.GetColumn() &&
                                       column < coordinate.GetColumn() + shape.GetWidth();

                    if (isLetterZone)
                    {
                        var deltaRow = row - coordinate.GetRow();
                        var deltaColumn = column - coordinate.GetColumn();

                        var letterCoordinate = new Coordinate(deltaColumn, deltaRow);

                        if (shape.IsHighlighted(letterCoordinate))
                        {
                            shape.Draw(letterCoordinate);
                        }
                        else
                            board[row, column].Draw();
                    }
                    else
                    {
                        board[row, column].Draw();
                    }
                }
                Console.WriteLine();
            }
        }

        public void IncorporateLetter(Shape shape, Coordinate coordinate)
        {
            for (int row = 0; row < GetHeight(); row++)
            {
                for (int column = 0; column < GetWidth(); column++)
                {
                    var isLetterZone = row >= coordinate.GetRow() &&
                                       row < coordinate.GetRow() + shape.GetHeight() &&
                                       column >= coordinate.GetColumn() &&
                                       column < coordinate.GetColumn() + shape.GetWidth();

                    if (isLetterZone)
                    {
                        var deltaY = row - coordinate.GetRow();
                        var deltaX = column - coordinate.GetColumn();

                        var letterCoordinate = new Coordinate(deltaX, deltaY);

                        if (shape.IsHighlighted(letterCoordinate))
                        {
                            board[row, column].Set();
                        }
                    }
                }
            }
        }

        public bool CanDraw(Shape shape, Coordinate coordinate)
        {
            if (coordinate.GetColumn() < 0)
                return false;

            if (coordinate.GetRow() < 0)
                return false;

            if ((coordinate.GetColumn() + shape.GetWidth()) > GetWidth())
                return false;

            if ((coordinate.GetRow() + shape.GetHeight()) > GetHeight())
                return false;

            for (int row = coordinate.GetRow(); row < coordinate.GetRow() + shape.GetHeight(); row++)
            {
                for (int column = coordinate.GetColumn(); column < coordinate.GetColumn() + shape.GetWidth(); column++)
                {
                    var letterCoordinate = new Coordinate(column - coordinate.GetColumn(), row - coordinate.GetRow());

                    if (!board[row, column].IsEmpty() && shape.IsHighlighted(letterCoordinate))
                        return false;
                }
            }

            return true;
        }
    }
}

