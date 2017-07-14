using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoboArena
{
    public class MatchResult
    {


    }

    public class Robot
    {
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int MaxEnergy { get; set; }
        public int Energy { get; set; }
        public int Speed { get; set; }

        public enum CardinalDirection
        {
            NorthWest,
            NorthEast,
            East,
            SouthEast,
            SouthWest,
            West
        }

        public CardinalDirection Facing { get; set; }

        public IList<Action> Actions { get; set; }
        private int ActionIndex = 0;

        public void Execute(World world, IEnumerable<Robot> others)
        {
            if(Actions != null && Actions.Any())
            {
                Action nextAction = Actions[ActionIndex];
                if(nextAction.EnergyCost <= Energy)
                {
                    nextAction.Execute(this, world, others);
                }
            }
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }

    public class World
    {

    }

    public class Action
    {
        public int EnergyCost { get; set; }

        public void Execute(Robot robot, World world, IEnumerable<Robot> others)
        {

        }
    }

    public class MatchSimulator
    {
        private const int MaxTurnsBeforeDraw = 100;
        private int Turn = 0;

        public void Simulate(IEnumerable<Robot> robots, World world)
        {
            IEnumerable<Robot> alive = robots.Where(r => r.IsAlive());

            // While(more than one robot is alive)
            while (alive.Count() > 1)
            {
                // ReplenishRobotEnergy(robots)
                alive.Select(r => r.Energy = r.MaxEnergy);

                // SortBySpeedDescending(robots) 
                alive.OrderByDescending(r => r.Speed);

                // Execute each robots action
                foreach(Robot robot in alive)
                {
                    robot.Execute(world, alive.Where(r=> r != robot));
                }
            }
        }
    }
}
