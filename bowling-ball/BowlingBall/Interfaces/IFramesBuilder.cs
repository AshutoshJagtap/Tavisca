using BowlingBall.Model;
using System.Collections.Generic;

namespace BowlingBall.Interfaces
{
    public interface IFramesBuilder
    {
        IList<Frame> Frames { get; set; }
        Frame GetFrame(int rollOne, int rollTwo);
    }
}
