namespace KingSurvival.Base.GameObjects
{
    /// <summary>
    /// A specific implementation of the abstract class Figure representing the Pawns in the game
    /// </summary>
    public class Pawn : Figure
    {
        private const string PawnName = "Pawn";

        public Pawn(Position initialPosition, char symbol) 
            : base(initialPosition, symbol, PawnName)
        {
        }
    }
}