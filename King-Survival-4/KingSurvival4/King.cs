namespace KingSurvival4
{
    using System;
    public class King : Figure
    {
        public bool OnTurn { get; set; }

        public King(Position initialPosition, IMoveable mover, bool onTurn = true)
            : base(initialPosition, 'K', 'K', mover)
        {
            this.OnTurn = onTurn;
        }

        public override void Move()
        {
            this.Mover.Move(this, new Direction()); // TO DO: not correct direction
        }
    }
}
