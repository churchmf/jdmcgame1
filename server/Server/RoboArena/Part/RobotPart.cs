using System;
using System.Collections.Generic;

namespace RoboArena.Part
{
    public class RobotPart
    {
        public string Id { get; set; }
        public Type ActionType { get; set; }
        public Dictionary<string, int> ActionArguments { get; set; }
        public Dictionary<RobotStat, int> Stats { get; set; }
    }
}
