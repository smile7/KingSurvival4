namespace KingSurvival4
{
    using System;

    public class StaticCell : Figure
    {
        public Position Position { get; set; }
        public StaticCell(Position initialPosition)
            : base()
        {
            this.Position = initialPosition;
        }
    }
}
