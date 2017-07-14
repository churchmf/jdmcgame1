using System.Collections.Generic;

namespace RoboArena
{
    public class AttackAction : RobotAction
    {
        public int EnergyCost { get { return 1; } }

        public void Execute(Robot robot, World world, IEnumerable<Robot> others)
        {
            if (robot.Energy > EnergyCost)
            {
                robot.Energy -= EnergyCost;
            }

            Location attackLocation = robot.Position.Extrapolate(robot.Facing);
        }
    }
}
