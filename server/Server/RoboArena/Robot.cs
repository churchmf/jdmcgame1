using RoboArena.Actions;
using RoboArena.World;
using System.Collections.Generic;
using System.Linq;

namespace RoboArena
{
    public class Robot
    {
        public int MaxHealth { get; set; }
        public int MaxEnergy { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }
        public int Speed { get; set; }
        public string Id { get; set; }

        public CardinalDirection Facing { get; set; }

        public Position Position { get; set; }

        public IList<RobotAction> Actions { get; set; }
        private int ActionIndex = 0;

        public void Execute(RobotWorld world, IEnumerable<Robot> others)
        {
            if (Actions != null && Actions.Any())
            {
                RobotAction nextAction = Actions[ActionIndex];
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
