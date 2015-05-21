using System;

namespace Tetris.Shapes
{
    public class S_Shape : Shape
    {
        public S_Shape()
            : base(3, 2, ConsoleColor.Cyan)
        {

        }

        protected override void SetPattern()
        {
            shapeForm[0, 1].Set();
            shapeForm[0, 2].Set();
            shapeForm[1, 0].Set();
            shapeForm[1, 1].Set();
        }
    }
}
