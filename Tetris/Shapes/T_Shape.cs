using System;

namespace Tetris.Shapes
{
    public class T_Shape : Shape
    {
        public T_Shape()
            : base(3, 2, ConsoleColor.Red)
        {

        }

        protected override void SetPattern()
        {
            shapeForm[0, 1].Set();
            shapeForm[1, 0].Set();
            shapeForm[1, 1].Set();
            shapeForm[1, 2].Set();
        }
    }
}
