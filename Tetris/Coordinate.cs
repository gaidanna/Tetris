
namespace Tetris
{
    public class Coordinate
    {
        private int column;
        private int row;

        public Coordinate(int column, int row)
        {
            this.column = column;
            this.row = row;
        }

        public int GetColumn()
        {
            return column;
        }

        public int GetRow()
        {
            return row;
        }
    }
}
