namespace KingSurvival.Base.GameObjects
{
    /// <summary>
    /// A specific implementation of the abstract class Figure representing the King in the game
    /// </summary>
    public class King : Figure
    {
        private const string KingName = "King";
        private const char KingSymbol = 'K';

        public King(Position initialPosition)
            : base(initialPosition, KingSymbol, KingName)
        {
        }
    }
}