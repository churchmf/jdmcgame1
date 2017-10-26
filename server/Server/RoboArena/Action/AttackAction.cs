using System.Collections.Generic;
using System.Linq;

namespace RoboArena
{
    public class AttackAction : RobotAction
    {
        private int m_Damage;
        private int m_Range;

        public AttackAction(Dictionary<string, int> arguments) : base(arguments)
        {
            m_Damage = arguments["Damage"];
            m_Range = arguments["Range"];
        }

        protected override void Act(Robot robot, World world, IEnumerable<Robot> others)
        {
            Location attackLocation = robot.Position.Extrapolate(robot.Facing, m_Range);
            Robot target = others.Where(o => o.Position.Equals(attackLocation)).FirstOrDefault();
            if(target != null)
            {
                target.ApplyStat(RobotStat.Health, -m_Damage);
            }
        }
    }
}
