using System;

namespace Tetris
{
    public class Score
    {
        private int score;

        public void AddScore(int score)
        {
            this.score += score;
        }

        public void Draw()
        {
            Console.WriteLine("Score: " + (object)this.score);
        }
    }
}
