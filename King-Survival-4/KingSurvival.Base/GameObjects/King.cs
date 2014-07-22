namespace KingSurvival4
{
    /// <summary>
    /// A specific implementation of the abstract class Figure representing the King in the game
    /// </summary>
    public class King : Figure
    {
        private const char KingName = 'K';
        private const char KingSymbol = 'K';

        public King(Position initialPosition)
            : base(initialPosition, KingName, KingSymbol)
        {
        }
    }
}