using System.Collections.Generic;

namespace RoboArena.Script
{
    public interface ICondition
    {
        bool CheckCondition(Robot robot, World world, IEnumerable<Robot> others);
    }
}
