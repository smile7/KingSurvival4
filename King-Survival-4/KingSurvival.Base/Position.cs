namespace KingSurvival.Base
{
    using System;

    using KingSurvival.Base.Interfaces;

    /// <summary>
    /// A class representing the coordinates of the figures on the board
    /// </summary>
    public class Position : ICloneable, IPosition
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