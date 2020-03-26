namespace BowlingBall.Model
{
    public class Frame
    {
        #region Constant
        private const int MaxPins = 10;
        #endregion

        #region Public Fields
        public int RollOne { get; set; }
        public int RollTwo { get; set; }
        #endregion

        #region Constructor
        public Frame(int _rollOne, int _rollTwo)
        {
            RollOne = _rollOne;
            RollTwo = _rollTwo;
            TotalScore = RollOne + RollTwo;
        }
        #endregion

        #region Public Properties
        public int TotalScore { get; set; }
        #endregion

        #region Public Methods
        public bool IsSpare()
        {
            return !IsStrike() && (RollOne + RollTwo) == MaxPins;
        }

        public bool IsStrike()
        {
            return RollOne == MaxPins;
        }
        #endregion
    }
}
