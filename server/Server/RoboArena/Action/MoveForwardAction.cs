using System.Collections.Generic;

namespace RoboArena
{
    public class MoveForwardAction : RobotAction
    {
        public MoveForwardAction(Dictionary<string, int> arguments) : base(arguments)
        {
        }

        protected override void Act(Robot robot, World world, IEnumerable<Robot> others)
        {
            Location potentialPosition = robot.Position.Extrapolate(robot.Facing);
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
