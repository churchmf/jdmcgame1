﻿using System.Collections.Generic;

namespace RoboArena
{
    public class Match
    {
        public World World { get; set; }
        public IEnumerable<Robot> Participants { get; set; }
    }
}
