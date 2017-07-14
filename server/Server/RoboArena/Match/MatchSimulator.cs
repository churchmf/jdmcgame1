using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RoboArena
{
    public class MatchResult
    {
        public string WinnerId { get; set; }
    }

    public class MatchSimulator
    {
        private const int MaxTurnsBeforeDraw = 25;

        public Match Create(IEnumerable<string> participantIds)
        {
            List<Robot> participants = new List<Robot>();
            foreach(string participantId in participantIds)
            {
                RobotData data = DataManager.GetRobotData(participantId);
                participants.Add(new Robot(data));
            }

            World world = WorldGenerator.Generate();
            world.Initialize(participants);

            return new Match
            {
                World = world,
                Participants = participants
            };
        }

        public MatchResult Simulate(Match match)
        {
            IEnumerable<Robot> remainingRobots = match.Participants.Where(r => r.IsAlive);

            int TurnCount = 0;

            // While(more than one robot is alive)
            while (remainingRobots.Count() > 1 && TurnCount < MaxTurnsBeforeDraw)
            {
                // Replenish each robots energy
                foreach(Robot robot in remainingRobots)
                {
                    robot.Energy = robot.Data.MaxEnergy;
                }

                // While(any robot can still act)
                while(remainingRobots.Where(r=>r.CanAct).Any())
                {
                    // Sort robots by speed 
                    remainingRobots = remainingRobots.OrderByDescending(r => r.Speed);

                    // Execute each robots action
                    foreach (Robot robot in remainingRobots)
                    {
                        if(robot.IsAlive && robot.CanAct && remainingRobots.Where(r => r.CanAct).Any())
                        {
                            IEnumerable<Robot> otherRobots = remainingRobots.Where(r => r != robot);
                            robot.Act(match.World, otherRobots);

                            //Debug
                            DebugPrint(match);
                        }
                    }
                }

                remainingRobots = remainingRobots.Where(r => r.IsAlive);
                TurnCount++;
            }

            return new MatchResult
            {
                WinnerId = remainingRobots.Count() > 1 ? String.Empty : remainingRobots.First().Data.Id
            };
        }

        private void DebugPrint(Match match)
        {
            Debug.WriteLine("World:");
            Debug.Write(match.World.DebugOutput());

            Debug.WriteLine("Participants:");
            foreach(Robot participant in match.Participants)
            {
                Debug.WriteLine(participant.DebugOutput());
            }
        }
    }
}
