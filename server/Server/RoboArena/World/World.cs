using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RoboArena
{
    public class World
    {
        private WorldTile[][] m_Tiles;

        public World(WorldTile[][] tiles)
        {
            m_Tiles = tiles;
        }

        public void Initialize(IEnumerable<Robot> participants)
        {
            foreach(Robot participant in participants)
            {
                Location spawn = GetTilePosition((t) => { return t.IsSpawn() && !t.IsOccupied; });
                if(spawn != null)
                {
                    participant.Position = spawn;
                    m_Tiles[spawn.X][spawn.Y].IsOccupied = true;
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
            for(int x = 0; x < m_Tiles.Length; ++x)
            {
                for (int y = 0; y < m_Tiles[x].Length; ++y)
                {
                    WorldTile tile = m_Tiles[x][y];
                    if(predicate(tile))
                    {
                        return new Location { X = x, Y = y };
                    }
                }
            }

            return null;
        }

        public WorldTile GetTile(Location location)
        {
            return GetTile(location.X, location.Y);
        }

        public WorldTile GetTile(int x, int y)
        {
            WorldTile newTile = null;
            try
            {
                newTile = m_Tiles[x][y];
            }
            catch (IndexOutOfRangeException)
            {
            }
            return newTile;
        }

        public string DebugOutput()
        {
            var builder = new StringBuilder();
            for (int x = 0; x < m_Tiles.Length; ++x)
            {
                for (int y = 0; y < m_Tiles[x].Length; ++y)
                {
                    WorldTile tile = m_Tiles[x][y];
                    builder.AppendFormat("X{0}Y{1} {2}", x, y, tile.DebugPrint());
                    if(y != m_Tiles[x].Length - 1)
                    {
                        builder.Append(" ");
                    }
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }

    public enum RotationDirection
    {
        Left,
        Right
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
            var extrapolated = new Location { X = X, Y = Y};
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

        public override string ToString()
        {
            return String.Format("X:{0} Y:{1}", X, Y);
        }

        public override bool Equals(Object other)
        {
            if (other != null)
            {
                Location p = other as Location;
                if (p != null)
                {
                    return (X == p.X) && (Y == p.Y);
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return new { X, Y }.GetHashCode();
        }
    }
}
