using System.Collections.Generic;

namespace RoboArena.Script
{
    public class ScriptLine : IScript
    {
        private RobotAction Action { get; set; }

        public void Execute(Robot robot, World world, IEnumerable<Robot> others)
        {
            Action.Perform(robot, world, others);
        }
    }
}
