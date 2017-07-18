using RoboArena;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Runner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Match Engine");
            var runner = new MatchRunner();
            while(true)
            {
                List<Match> newMatches = runner.ClaimNewMatches();

                List<MatchResult> results = new List<MatchResult>();
                foreach (Match match in newMatches)
                {
                    results.Add(runner.Simulate(match));
                }

                // TODO submit results
                Thread.Sleep(1);
            }
        }
    }
}