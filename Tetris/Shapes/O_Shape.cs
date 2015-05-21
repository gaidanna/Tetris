using System;

namespace Tetris.Shapes
{
    public class O_Shape : Shape
    {
        public O_Shape()
            : base(2, 2, ConsoleColor.Green)
        {

        }

        protected override void SetPattern()
        {
            shapeForm[0, 0].Set();
            shapeForm[0, 1].Set();
            shapeForm[1, 0].Set();
            shapeForm[1, 1].Set();
        }
    }
}
