namespace KingSurvival4
{
    using System;
    public class King : Figure
    {
        public King(Position initialPosition)
            : base(initialPosition)
        {
            this.Position = initialPosition;
        }

    }
}
