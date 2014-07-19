namespace KingSurvival4
{
    using System;

    public class Pawn : Figure
    {
        public Pawn(Position initialPosition, char name) 
            //: base(initialPosition, name, 'P')
        {
            this.Position = initialPosition;
            this.Name = name;
            this.Symbol = 'P';
        }
    }
}
