using BowlingBall;
using BowlingBall.DependencyInjection;
using System;

namespace BowlingBallConsoleGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Dependency Injection
            Bootstrapper.Init();
            Game bowlingGame = DependencyInjector.Retrieve<Game>();

            //Pass your input here 
            //e.g.
            //bowlingGame.Roll(10);
            //Console.WriteLine(bowlingGame.GetScore());

            Console.ReadLine();
        }
    }
}
