using System;

namespace Tetris.Shapes
{
    public class Shape
    {
        private ConsoleColor color;
        protected Cell[,] shapeForm;

        public Shape(int width, int height, ConsoleColor color)
        {
            SetColor(color);
            CreateShape(width, height);
            SetPattern();
        }

        private void SetColor(ConsoleColor color)
        {
            this.color = color;
        }

        public int GetHeight()
        {
            return shapeForm.GetLength(0);
        }

        public int GetWidth()
        {
            return shapeForm.GetLength(1);
        }

        private void CreateShape(int width, int height)
        {
            shapeForm = new Cell[height, width];

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    shapeForm[row, column] = new Cell(color);
                }
            }
        }

        protected virtual void SetPattern()
        { }

        public void Rotate()
        {
            int columnsNewArray;
            int rawsNewArray;
            Cell[,] rotatedArray;

            columnsNewArray = shapeForm.GetLength(0);
            rawsNewArray = shapeForm.GetLength(1);
            rotatedArray = new Cell[rawsNewArray, columnsNewArray];

            for (int i = 0; i < rawsNewArray; i++)
            {
                for (int j = 0; j < columnsNewArray; j++)
                {
                    rotatedArray[i, j] = shapeForm[columnsNewArray - j - 1, i];
                }
            }
            shapeForm = rotatedArray;
        }

        public bool IsHighlighted(Coordinate coordinate)
        {
            return !shapeForm[coordinate.GetRow(), coordinate.GetColumn()].IsEmpty();
        }

        internal void Draw(Coordinate letterCoordinate)
        {
            shapeForm[letterCoordinate.GetRow(), letterCoordinate.GetColumn()].Draw();
        }

        internal Shape Clone()
        {
            var clonedArray = (Cell[,])this.shapeForm.Clone();

            return new Shape(GetWidth(), GetHeight(), color) { shapeForm = clonedArray };
        }
    }
}
