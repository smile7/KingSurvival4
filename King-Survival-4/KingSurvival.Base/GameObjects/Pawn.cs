namespace KingSurvival4
{
    /// <summary>
    /// A specific implementation of the abstract class Figure representing the Pawns in the game
    /// </summary>
    public class Pawn : Figure
    {
        private const char PawnSymbol = 'P';

        public Pawn(Position initialPosition, char name) 
            : base(initialPosition, name, PawnSymbol)
        {
        }
    }
}