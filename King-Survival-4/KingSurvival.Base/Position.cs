namespace KingSurvival4
{
    using System;

    public class Position : ICloneable
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}