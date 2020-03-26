using BowlingBall.Builder;
using BowlingBall.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall.Model
{
    public class BowlingGame : IBowlingGame
    {
        #region Injectable Member
        private readonly IFramesBuilder _IFramesBuilder;
        #endregion

        #region Constant
        private const int MAX_PINS = 10;
        #endregion

        #region Private Fields 
        private IList<Frame> Frames { get; set; }
        private int PinsRollOne = 0;
        private bool IsRollOne = true;
        private int FrameIndex = 0;
        #endregion

        #region Constructor
        public BowlingGame(IFramesBuilder IFramesBuilder)
        {
            _IFramesBuilder = IFramesBuilder;
            Frames = IFramesBuilder.Frames;
        }
        public BowlingGame()
        {

        }
        #endregion

        #region Private Methods
        private void CalculateBounseScore()
        {
            for (int i = 0; i < Frames.Count() - 1; i++)
            {
                if (Frames[i].IsStrike())
                {
                    Frames[i].TotalScore += Frames[i + 1].TotalScore;
                    if (Frames[i + 1].IsStrike())
                    {
                        if ((i + 2) <= Frames.Count() - 1)
                            Frames[i].TotalScore += Frames[i + 2].TotalScore;
                    }
                }
                if (Frames[i].IsSpare())
                {
                    Frames[i].TotalScore += Frames[i + 1].RollOne;
                }
            }
        }
        private void RollOne(int pins)
        {
            Frames.Add(_IFramesBuilder.GetFrame(pins, 0));
            PinsRollOne = pins;
            if (pins == MAX_PINS)
            {
                FrameIndex++;
            }
            else
            {
                IsRollOne = false;
            }
        }
        private void RollTwo(int pins)
        {
            Frames[FrameIndex].RollOne = PinsRollOne;
            Frames[FrameIndex].RollTwo = pins;
            Frames[FrameIndex].TotalScore = PinsRollOne + pins;
            IsRollOne = true;
            PinsRollOne = 0;
            FrameIndex++;
        }
        #endregion

        #region Public Methods
        public void Roll(int pins)
        {
            if (IsRollOne)
            {
                RollOne(pins);
            }
            else
            {
                RollTwo(pins);
            }
        }

        public int Score()
        {
            int result = 0;
            CalculateBounseScore();
            for (int i = 0; i < FramesBuilder.DEFAULT_FRAME; i++)
            {
                result += Frames[i].TotalScore;
            }
            return result;
        }
        #endregion

    }
}
