using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Runner
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Starting Match Making Engine");
            try
            {
                var matchMaker = new MatchMaker();
                while (true)
                {
                    List<QueuedParticipant> queued = matchMaker.GetQueuedParticipants();

                    //TODO better match making logic
                    if (queued.Count > 1)
                    {
                        // Grabs pairs
                        for (int i = 0; i < queued.Count; i += 2)
                        {
                            if (i + 1 < queued.Count)
                            {
                                matchMaker.MatchQueued(queued[i], queued[i + 1]);
                            }
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Debugger.Break();
            }
        }
    }
}