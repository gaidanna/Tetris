using System;

namespace Tetris.Shapes
{
    public class I_Shape : Shape
    {
        public I_Shape()
            : base(1, 4, ConsoleColor.Yellow)
        {

        }

        protected override void SetPattern()
        {
            shapeForm[0, 0].Set();
            shapeForm[1, 0].Set();
            shapeForm[2, 0].Set();
            shapeForm[3, 0].Set();
        }
    }
}
