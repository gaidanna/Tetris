using System;

namespace Tetris
{
    public class Cell
    {
        private char cellSign;
        private ConsoleColor color;
        private const char EmptyCell = '∙';

        public Cell(ConsoleColor color)
        {
            cellSign = EmptyCell;
            this.color = color;
        }

        public void Draw()
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.Write(cellSign);

            Console.ForegroundColor = previousColor;
        }

        public void Set()
        {
            cellSign = '☺';
        }

        public bool IsEmpty()
        {
            return cellSign == EmptyCell;
        } 
    }
}
