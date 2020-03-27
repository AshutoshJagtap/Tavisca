using BowlingBall.Builder;
using BowlingBall.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        #region Public TestMethod
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            var game = new Game(new BowlingGame(new FramesBuilder()));
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void Score_should_be_strikes_test()
        {
            var game = new Game(new BowlingGame(new FramesBuilder()));

            for (int i = 0; i < 12; i++)
            {
                game.Roll(10);
            }

            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void Score_should_be_spare_test()
        {
            var game = new Game(new BowlingGame(new FramesBuilder()));

            for (int i = 0; i < 21; i++)
            {
                game.Roll(5);
            }

            Assert.AreEqual(150, game.GetScore());
        }

        [TestMethod]
        public void Score_should_be_correct_test()
        {
            var game = new Game(new BowlingGame(new FramesBuilder()));

            int[] pins = new int[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            foreach (var pin in pins)
            {
                game.Roll(pin);
            }

            Assert.AreEqual(187, game.GetScore());
        }
        #endregion 

        #region Private Methods
        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
        #endregion
    }
}
