using System;
using Tetris.Shapes;

namespace Tetris
{
    public class Keyboard
    {
        public void OnKeyPressed()
        {
            while (true)
            {
                var key = Console.ReadKey(true);

                if (KeyPressed != null)
                    KeyPressed(key);
            }
        }

        public event Action<ConsoleKeyInfo> KeyPressed;
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}

