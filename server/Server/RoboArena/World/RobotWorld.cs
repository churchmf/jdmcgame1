using System;

namespace RoboArena.World
{
    public class RobotWorld
    {
        public WorldTile[,] Tiles { get; set; }

        public RobotWorld()
        {
            Tiles = new WorldTile[,]
            {
                { new WorldTile(), new WorldTile() }
            };
        }

        public bool Move(Robot robot, CardinalDirection direction)
        {
            Position newPosition = robot.Position;
            switch (direction)
            {
                case CardinalDirection.North:
                    newPosition.Y = robot.Position.Y + 1;
                    break;
                case CardinalDirection.East:
                    newPosition.X = robot.Position.X + 1;
                    break;
                case CardinalDirection.South:
                    newPosition.Y = robot.Position.X - 1;
                    break;
                case CardinalDirection.West:
                    newPosition.X = robot.Position.X - 1;
                    break;
                default:
                    throw new ArgumentException("Unhandled direction: " + direction);
            }

            WorldTile newTile = Tiles[newPosition.X, newPosition.Y];
            if (newTile != null && newTile.CanTraverse())
            {
                robot.Position = newPosition;
                return true;
            }
            return false;
        }
    }

    public enum CardinalDirection
    {
        North,
        East,
        South,
        West
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
