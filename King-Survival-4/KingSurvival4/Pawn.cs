namespace KingSurvival4
{
    using System;
    public class Pawn : Figure
    {
        public Position Position { get; set; }
        public Pawn(Position initialPosition) 
            : base() 
        {
            this.Position = initialPosition;
        }

        
    }
}
