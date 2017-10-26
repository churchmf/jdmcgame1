using System.Collections.Generic;

namespace RoboArena
{
    public abstract class RobotAction
    {
        private int m_EnergyCost;

        public RobotAction(Dictionary<string, int> arguments)
        {
            m_EnergyCost = arguments["EnergyCost"];
        }

        public bool HasSufficientEnergy(Robot robot)
        {
            return robot.GetStat(RobotStat.Energy) >= m_EnergyCost;
        }

        public void Perform(Robot robot, World world, IEnumerable<Robot> others)
        {
            if(HasSufficientEnergy(robot))
            {
                Act(robot, world, others);
                robot.ApplyStat(RobotStat.Energy, -m_EnergyCost);
            }
        }

        protected abstract void Act(Robot robot, World world, IEnumerable<Robot> others);
    }
}