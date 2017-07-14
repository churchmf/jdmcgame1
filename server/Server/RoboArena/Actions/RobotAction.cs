using System.Collections.Generic;
using RoboArena.World;

namespace RoboArena.Actions
{
    public interface RobotAction
    {
        int EnergyCost { get; }

        void Execute(Robot robot, RobotWorld world, IEnumerable<Robot> others);
    }
}
