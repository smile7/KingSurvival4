namespace KingSurvival4
{
    using System;
    public class King : Figure
    {
        public King(Position initialPosition, IMoveable mover)
            : base(initialPosition, 'K', 'K', mover)
        {
        }

    }
}
