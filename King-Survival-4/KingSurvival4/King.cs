namespace KingSurvival4
{
    using System;
    public class King : Figure
    {
        public King(Position initialPosition, IMoveable mover)
            : base(initialPosition, 'K', 'K', mover)
        {
        }

        public override void Move()
        {
            this.Mover.Move(this, new Direction()); // TO DO: not correct direction
        }
    }
}
