using BowlingBall.Builder;
using BowlingBall.Interfaces;
using BowlingBall.Model;

namespace BowlingBall.DependencyInjection
{
    public static class Bootstrapper
    {
        public static void Init()
        {
            DependencyInjector.Register<IFramesBuilder, FramesBuilder>();
            DependencyInjector.Register<IBowlingGame, BowlingGame>();
        }
    }
}
