using System;

namespace Tetris.Shapes
{
    public class J_Shape : Shape
    {
        public J_Shape()
            : base(2, 3, ConsoleColor.Gray)
        {

        }

        protected override void SetPattern()
        {
            shapeForm[0, 1].Set();
            shapeForm[1, 1].Set();
            shapeForm[2, 0].Set();
            shapeForm[2, 1].Set();
        }
    }
}
