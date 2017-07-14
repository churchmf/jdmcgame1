namespace RoboArena
{
    public class WorldTile
    {
        public bool CanTraverse()
        {
            // TODO collision
            return true;
        }

        public bool IsSpawn()
        {
            // TODO spawn logic
            return true;
        }

        public bool IsOccupied { get; set; }
    }
}
