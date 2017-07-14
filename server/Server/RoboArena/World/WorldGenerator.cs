namespace RoboArena
{
    public class WorldGenerator
    {
        public static World Generate()
        {
            // TODO generate
            return new World
            {
                Tiles = new WorldTile[][]
                {
                    new WorldTile[]{ new WorldTile(), new WorldTile() },
                    new WorldTile[]{ new WorldTile(), new WorldTile() },
                    new WorldTile[]{ new WorldTile(), new WorldTile() }
                }
            };
        }
    }
}
