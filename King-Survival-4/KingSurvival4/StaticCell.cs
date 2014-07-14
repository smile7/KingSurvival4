namespace KingSurvival4
{
    using System;

    public class StaticCell : Figure
    {
        public StaticCell(Position initialPosition)
            : base(initialPosition)
        {
            this.Position = initialPosition;
        }
    }
}
