namespace RoboArena
{
    public class WorldGenerator
    {
        public static World Generate()
        {
            // TODO generate
            return new World(new WorldTile[][]
            {
                new WorldTile[]{ new WorldTile(), new WorldTile() },
                new WorldTile[]{ new WorldTile(), new WorldTile() },
                new WorldTile[]{ new WorldTile(), new WorldTile() }
            });
        }
    }
}
