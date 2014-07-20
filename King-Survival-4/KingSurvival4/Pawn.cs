namespace KingSurvival4
{
    using System;

    public class Pawn : Figure
    {
        public Pawn(Position initialPosition, char name) 
        {
            this.Position = initialPosition;
            this.Name = name;
            this.Symbol = 'P';
        }

        public override object Clone()
        {
            Pawn newKing = (Pawn)this.MemberwiseClone();
            newKing.Position = (Position)this.Position.Clone();
            return newKing;
        }
    }
}
