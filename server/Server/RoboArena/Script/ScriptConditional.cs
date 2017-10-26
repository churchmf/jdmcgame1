using System.Collections.Generic;

namespace RoboArena.Script
{
    public abstract class ScriptConditional : ScriptComplex
    {
        public ICondition Condition { get; set; }

        public override void Execute(Robot robot, World world, IEnumerable<Robot> others)
        {
            if(Condition.CheckCondition(robot, world, others))
            {
                foreach(IScript child in Children)
                {
                    child.Execute(robot, world, others);
                }
            }
        }
    }
}
