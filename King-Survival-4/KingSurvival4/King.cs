namespace KingSurvival4
{
    using System;
    public class King : Figure
    {
        public Position Position { get; set; }
        public King(Position initialPosition)
            : base()
        {
            this.Position = initialPosition;
        }

    }
}
