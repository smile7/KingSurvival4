namespace KingSurvival4
{
    using System;
    public class King : Figure
    {
        public bool OnTurn { get; set; }

        public King(Position initialPosition, bool onTurn = true)
            : base(initialPosition, 'K', 'K')
        {
            this.OnTurn = onTurn;
        }

        public override void Move()
        {
            // TO DO
        }
    }
}
