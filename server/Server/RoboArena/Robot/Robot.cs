using System;
using System.Collections.Generic;
using System.Linq;

namespace RoboArena
{
    public enum RobotPartSlot
    {
        RightArm,
        LeftArm,
        Head,
        Torso,
        Base
    }

    public enum RobotStat
    {
        Speed,
        Energy,
        Health
    }

    public class Robot
    {
        private RobotData Data { get; }
        private Dictionary<RobotStat, int> Stats { get; set; }
        private int ActionIndex = 0;

        public string Id
        {
            get
            {
                return Data.Id;
            }
        }

        public CardinalDirection Facing { get; set; }
        public Location Position { get; set; }

        public Robot(RobotData data)
        {
            Data = data;

            Stats = new Dictionary<RobotStat, int>();
            foreach (RobotStat stat in Enum.GetValues(typeof(RobotStat)))
            {
                SetMaxStat(stat);
            }
        }

        public int GetStat(RobotStat stat)
        {
            return Stats[stat];
        }

        public void ApplyStat(RobotStat stat, int amount)
        {
            Stats[stat] += amount;
        }

        public void SetMaxStat(RobotStat stat)
        {
            Stats[stat] = GetStatMax(stat);
        }

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
                return Stats[RobotStat.Health] > 0;
            }
        }

        public override string ToString()
        {
            return string.Format("Id[{0}] Position[{1}] Facing[{2}] Health[{3}]", Data.Id, Position, Facing, Stats[RobotStat.Health]);
        }

        private int GetStatMax(RobotStat stat)
        {
            int statSum = 0;

            // Add Parts
            foreach (var part in Data.Slots)
            {
                statSum = part.Value.Stats.ContainsKey(stat) ? part.Value.Stats[stat] : 0;
            }

            return statSum + Data.BaseStats[stat];
        }
    }
}
