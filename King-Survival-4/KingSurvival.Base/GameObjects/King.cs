namespace KingSurvival.Base.GameObjects
{
    /// <summary>
    /// A specific implementation of the abstract class Figure representing the King in the game
    /// </summary>
    public class King : Figure
    {
        public King(Position initialPosition)
            : base(initialPosition, Constants.KingSymbol, Constants.KingName)
        {
        }
    }
}