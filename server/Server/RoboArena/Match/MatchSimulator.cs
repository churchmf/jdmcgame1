using System;
using System.Collections.Generic;
using System.Linq;

namespace RoboArena
{
    public class MatchResult
    {
        public string WinnerId { get; set; }
    }

    public class MatchSimulator
    {
        private const int MaxTurnsBeforeDraw = 100;

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
            IEnumerable<Robot> remainingRobots = match.Participants.Where(r => r.Alive);

            int TurnCount = 0;

            // While(more than one robot is alive)
            while (remainingRobots.Count() > 1 && TurnCount < MaxTurnsBeforeDraw)
            {
                // ReplenishRobotEnergy(robots)
                foreach(Robot robot in remainingRobots)
                {
                    robot.Energy = robot.Data.MaxEnergy;
                }

                // SortBySpeedDescending(robots) 
                remainingRobots = remainingRobots.OrderByDescending(r => r.Speed);

                // Execute each robots action
                foreach (Robot robot in remainingRobots)
                {
                    if(robot.Alive)
                    {
                        IEnumerable<Robot> otherRobots = remainingRobots.Where(r => r != robot);
                        robot.Execute(match.World, otherRobots);
                    }
                }

                remainingRobots = remainingRobots.Where(r => r.Alive);
                TurnCount++;
            }

            return new MatchResult
            {
                WinnerId = remainingRobots.Count() > 1 ? String.Empty : remainingRobots.First().Data.Id
            };
        }
    }
}
