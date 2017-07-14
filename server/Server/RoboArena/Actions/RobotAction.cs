using System.Collections.Generic;

namespace RoboArena
{
    public interface RobotAction
    {
        int EnergyCost { get; }

        void Execute(Robot robot, World world, IEnumerable<Robot> others);
    }
}