using System.Collections.Generic;
using System.Linq;

namespace RoboArena
{
    public class Robot
    {
        public RobotData Data { get; }

        public int Speed { get; set; }
        public int Energy { get; set; }
        public int Health { get; set; }

        public Robot(RobotData data)
        {
            Data = data;
            Data.Initialize(this);
        }

        public CardinalDirection Facing { get; set; }
        public Location Position { get; set; }

        private int ActionIndex = 0;

        public void Execute(World world, IEnumerable<Robot> others)
        {
            if (Data.Actions != null && Data.Actions.Any())
            {
                RobotAction nextAction = Data.Actions[ActionIndex];
                if (nextAction.EnergyCost <= Energy)
                {
                    nextAction.Execute(this, world, others);
                }
            }
        }

        public bool Alive
        {
            get
            {
                return Health > 0;
            }
        }
    }
}
