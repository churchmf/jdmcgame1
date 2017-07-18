using System.Collections.Generic;

namespace RoboArena
{
    public class Match
    {
        public int? Id { get; set; }
        public int? Seed { get; set; }
        public World World { get; set; }
        public IEnumerable<Robot> Participants { get; set; }
    }
}
