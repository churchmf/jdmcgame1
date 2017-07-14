using System;
using System.Collections.Generic;

namespace RoboArena
{
    public class World
    {
        public WorldTile[][] Tiles { get; set; }

        public void Initialize(IEnumerable<Robot> participants)
        {
            foreach(Robot participant in participants)
            {
                Location spawn = GetTilePosition((t) => { return t.IsSpawn() && !t.IsOccupied; });
                if(spawn != null)
                {
                    participant.Position = spawn;
                }
                else
                {
                    throw new InvalidOperationException(
                        String.Format("Unable to determine spawn position for {0}", participant)
                    );
                }
            }
        }

        private Location GetTilePosition(Func<WorldTile, bool> predicate)
        {
            for(int x = 0; x < Tiles.Length; ++x)
            {
                for (int y = 0; y < Tiles[x].Length; ++y)
                {
                    WorldTile tile = Tiles[x][y];
                    if(predicate(tile))
                    {
                        return new Location { X = x, Y = y };
                    }
                }
            }

            return null;
        }

        public bool Move(Robot robot, CardinalDirection direction)
        {
            Location potentialPosition = robot.Position.Extrapolate(direction);
            WorldTile newTile = null;
            try
            {
                newTile = Tiles[potentialPosition.X][potentialPosition.Y];
            }
            catch(IndexOutOfRangeException)
            {
                return false;
            }

            if (newTile != null && newTile.CanTraverse())
            {
                robot.Position = potentialPosition;
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

    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location Extrapolate(CardinalDirection direction, int distance = 1)
        {
            var extrapolated = new Location();
            switch (direction)
            {
                case CardinalDirection.North:
                    extrapolated.Y = Y + distance;
                    break;
                case CardinalDirection.East:
                    extrapolated.X = X + distance;
                    break;
                case CardinalDirection.South:
                    extrapolated.Y = X - distance;
                    break;
                case CardinalDirection.West:
                    extrapolated.X = X - distance;
                    break;
                default:
                    throw new ArgumentException("Unhandled direction: " + direction);
            }
            return extrapolated;
        }
    }
}
