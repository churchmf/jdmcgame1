using System.Collections.Generic;

namespace RoboArena
{
    public class MoveAction : RobotAction
    {
        private CardinalDirection m_Direction;

        public MoveAction(Dictionary<string, int> arguments, CardinalDirection direction) : base(arguments)
        {
            m_Direction = direction;
        }

        protected override void Act(Robot robot, World world, IEnumerable<Robot> others)
        {
            Location potentialPosition = robot.Position.Extrapolate(m_Direction);
            WorldTile potentialTile = world.GetTile(potentialPosition);
            if (potentialTile != null && !potentialTile.IsOccupied)
            {
                world.GetTile(robot.Position).IsOccupied = false;
                robot.Position = potentialPosition;
                world.GetTile(robot.Position).IsOccupied = true;
            }
        }
    }
}
