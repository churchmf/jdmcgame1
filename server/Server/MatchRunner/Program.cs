using System;
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
                runner.Tick();
                Thread.Sleep(1);
            }
        }
    }
}