using Assets.Parts;
using System.Collections.Generic;

namespace Assets.Robots
{
    public enum SlotEnum
    {
        Head,
        LeftArm,
        RightArm,
        Torso,
        Wheels
    }

    public class Robot
    {
        public IDictionary<SlotEnum, Part> Parts;
    }
}
