using System.Collections.Generic;
using System.Linq;

namespace RoboArena
{
    public class AttackAction : RobotAction
    {
        private int m_Damage;

        public AttackAction(int damage) : base(1)
        {
            m_Damage = damage;
        }

        protected override void Act(Robot robot, World world, IEnumerable<Robot> others)
        {
            Location attackLocation = robot.Position.Extrapolate(robot.Facing);
            Robot target = others.Where(o => o.Position.Equals(attackLocation)).FirstOrDefault();
            if(target != null)
            {
                target.Health -= m_Damage;
            }
        }
    }
}
