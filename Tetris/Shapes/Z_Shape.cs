using System;

namespace Tetris.Shapes
{
    public class Z_Shape : Shape
    {
        public Z_Shape()
            : base(3, 2, ConsoleColor.White)
        {

        }

        protected override void SetPattern()
        {
            shapeForm[0, 0].Set();
            shapeForm[0, 1].Set();
            shapeForm[1, 1].Set();
            shapeForm[1, 2].Set();
        }
    }
}
