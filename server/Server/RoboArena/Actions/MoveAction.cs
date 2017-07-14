using RoboArena.World;
using System.Collections.Generic;

namespace RoboArena.Actions
{
    public class MoveAction : RobotAction
    {
        private CardinalDirection m_Direction;

        public MoveAction(CardinalDirection direction)
        {
            m_Direction = direction;
        }

        public int EnergyCost { get { return 1; } }

        public void Execute(Robot robot, RobotWorld world, IEnumerable<Robot> others)
        {
            if(robot.Energy > EnergyCost)
            {
                world.Move(robot, m_Direction);
                robot.Energy -= EnergyCost;
            }
        }
    }
}
