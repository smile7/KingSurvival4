namespace KingSurvival4
{
    using System;

    public class King : Figure, ICloneable

    {
        public King(Position initialPosition, bool onTurn = true)
        {
            this.OnTurn = onTurn;
            this.Position = initialPosition;
            this.Name = 'K';
            this.Symbol = 'K';
        }

        public bool OnTurn { get; set; }

        public override object Clone()
        {
            King newKing = (King)this.MemberwiseClone();
            newKing.Position = (Position)this.Position.Clone();
            return newKing;
        }

    }
}
