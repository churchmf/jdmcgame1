using System;
using System.Collections.Generic;

namespace RoboArena.Script
{
    public class ScriptLoop : ScriptComplex
    {
        public Func<Robot, World, IEnumerable<Robot>, bool> Condition { get; set; }

        public override void Execute(Robot robot, World world, IEnumerable<Robot> others)
        {
            while (Condition.Invoke(robot, world, others))
            {
                foreach (IScript child in Children)
                {
                    child.Execute(robot, world, others);
                }
            }
        }
    }
}
