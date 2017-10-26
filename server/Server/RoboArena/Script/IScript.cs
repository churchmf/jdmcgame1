using System.Collections.Generic;

namespace RoboArena.Script
{
    public interface IScript
    {
        void Execute(Robot robot, World world, IEnumerable<Robot> others);
    }
}
