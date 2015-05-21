using System;

namespace Tetris.Shapes
{
    public class L_Shape : Shape
    {
        public L_Shape()
            : base(3, 2, ConsoleColor.Magenta)
        {

        }

        protected override void SetPattern()
        {
            shapeForm[0, 0].Set();
            shapeForm[0, 1].Set();
            shapeForm[0, 2].Set();
            shapeForm[1, 0].Set();
        }
    }
}
