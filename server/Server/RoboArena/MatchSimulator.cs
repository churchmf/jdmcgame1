using RoboArena.World;
using System.Collections.Generic;
using System.Linq;

namespace RoboArena
{
    public class MatchSimulator
    {
        public void Simulate(IEnumerable<Robot> robots, RobotWorld world)
        {
            IEnumerable<Robot> remainingRobots = robots.Where(r => r.Alive);

            // While(more than one robot is alive)
            while (remainingRobots.Count() > 1)
            {
                // ReplenishRobotEnergy(robots)
                foreach(Robot robot in remainingRobots)
                {
                    robot.Energy = robot.MaxEnergy;
                }

                // SortBySpeedDescending(robots) 
                remainingRobots = remainingRobots.OrderByDescending(r => r.Speed);

                // Execute each robots action
                foreach (Robot robot in remainingRobots)
                {
                    IEnumerable<Robot> otherRobots = remainingRobots.Where(r => r != robot);
                    robot.Execute(world, otherRobots);
                }
            }
        }
    }
}
