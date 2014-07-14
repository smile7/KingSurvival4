namespace KingSurvival4
{
    using System;

    public class StaticCell : Figure
    {
        public StaticCell(Position initialPosition, char name)
            : base(initialPosition, name, 'S')
        {
        }
    }
}
