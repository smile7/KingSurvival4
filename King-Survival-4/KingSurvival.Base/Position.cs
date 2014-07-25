namespace KingSurvival.Base
{
    using System;

    /// <summary>
    /// A class representing the coordinates of the figures on the board
    /// </summary>
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