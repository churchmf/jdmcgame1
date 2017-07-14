using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RoboArena
{
    public class Robot
    {
        public RobotData Data { get; }

        public int Speed { get; set; }
        public int Energy { get; set; }
        public int Health { get; set; }

        public Robot(RobotData data)
        {
            Data = data;
            Data.Initialize(this);
        }

        public CardinalDirection Facing { get; set; }
        public Location Position { get; set; }

        private int ActionIndex = 0;

        public void Act(World world, IEnumerable<Robot> others)
        {
            if (CanAct)
            {
                Data.Actions[ActionIndex].Perform(this, world, others);

                if (ActionIndex < Data.Actions.Count - 1)
                {
                    ActionIndex++;
                }
                else
                {
                    ActionIndex = 0;
                }
            }
        }

        public bool CanAct
        {
            get
            {
                return IsAlive
                    && Data.Actions != null
                    && Data.Actions.Any()
                    && Data.Actions[ActionIndex].HasSufficientEnergy(this);
            }
        }

        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        public override string ToString()
        {
            return string.Format("Id[{0}] Position[{1}] Facing[{2}] Health[{3}]", Data.Id, Position, Facing, Health); 
        }

        public string DebugOutput()
        {
            return ToString();
        }
    }
}
