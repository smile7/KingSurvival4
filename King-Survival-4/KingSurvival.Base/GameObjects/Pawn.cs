namespace KingSurvival4
{
    using System;

    public class Pawn : Figure
    {
        private const char PawnSymbol = 'P';

        public Pawn(Position initialPosition, char name) 
            : base(initialPosition, name, PawnSymbol)
        {
            this.Position = initialPosition;
            this.Name = name;
            this.Symbol = PawnSymbol;
        }
    }
}