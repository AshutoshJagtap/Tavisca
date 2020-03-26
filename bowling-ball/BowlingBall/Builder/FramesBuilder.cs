using BowlingBall.Interfaces;
using BowlingBall.Model;
using System.Collections.Generic;

namespace BowlingBall.Builder
{
    public class FramesBuilder : IFramesBuilder
    {
        #region Constant 
        public const int DEFAULT_FRAME = 10;
        #endregion

        #region Constructor
        public FramesBuilder()
        {
            Frames = new List<Frame>(DEFAULT_FRAME + 1);
        }
        #endregion

        #region Public Properties
        public IList<Frame> Frames { get; set; }
        #endregion

        #region Public Methods
        public Frame GetFrame(int rollOne, int rollTwo)
        {
            return new Frame(rollOne, rollTwo);
        }
        #endregion
    }
}
