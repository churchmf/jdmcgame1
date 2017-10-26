using System.Collections.Generic;

namespace RoboArena.Script
{
    public abstract class ScriptComplex : IScript
    {
        public IList<IScript> Children { get; set; }

        public abstract void Execute(Robot robot, World world, IEnumerable<Robot> others);
    }
}
