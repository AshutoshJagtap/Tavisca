using BowlingBall.Interfaces;

namespace BowlingBall
{
    public class Game
    {
        private readonly IBowlingGame _bowlingGame;

        public Game(IBowlingGame bowlingGame)
        {
            _bowlingGame = bowlingGame;
        }
        public void Roll(int pins)
        {
            // Add your logic here. Add classes as needed.
            _bowlingGame.Roll(pins);
        }

        public int GetScore()
        {
            // Returns the final score of the game.
            return _bowlingGame.Score();
        }
    }
}
