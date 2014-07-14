namespace KingSurvival4
{
    using System;
    public class Pawn : Figure
    {

        public Pawn(Position initialPosition, char name, IMoveable mover) 
            : base(initialPosition, name, 'P', mover) 
        {
        }

        public override void Move()
        {
            this.Mover.Move(this, new Direction()); // TO DO: not correct direction
        }
    }
}
