namespace KingSurvival4
{
    using System;
    public class Pawn : Figure
    {
      
        public Pawn(Position initialPosition) 
            : base(initialPosition) 
        {
            this.Position = initialPosition;
        }

        
    }
}
