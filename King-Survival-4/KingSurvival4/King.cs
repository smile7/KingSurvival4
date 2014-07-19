namespace KingSurvival4
{
    using System;

    public class King : Figure
    {
        public King(Position initialPosition, bool onTurn = true)
        {
            this.OnTurn = onTurn;
            this.Position = initialPosition;
            this.Name = 'K';
            this.Symbol = 'K';
        }

        public bool OnTurn { get; set; }

    }
}
