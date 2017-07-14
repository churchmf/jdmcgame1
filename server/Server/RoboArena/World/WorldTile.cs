namespace RoboArena
{
    public class WorldTile
    {
        public bool IsSpawn()
        {
            // TODO spawn logic
            return true;
        }

        public bool IsOccupied { get; set; }

        public string DebugPrint()
        {
            if(IsOccupied)
            {
               return "O";
            }
            else
            {
                return " ";
            }
        }
    }
}
