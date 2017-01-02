using System;

namespace Assets.Hexagons
{
    [Serializable]
    public struct HexagonCoordinates
    {
        public int X { get; private set; }
        public int Z { get; private set; }

        public HexagonCoordinates(int x, int z)
        {
            X = x;
            Z = z;
        }

        public static HexagonCoordinates FromOffsetCoordinates(int x, int z)
        {
            return new HexagonCoordinates(x - z / 2, z);
        }

        public override string ToString()
        {
            return "(" + X.ToString() + ", " + Z.ToString() + ")";
        }

        public string ToStringOnSeparateLines()
        {
            return X.ToString() + "\n" + Z.ToString();
        }
    }
}
