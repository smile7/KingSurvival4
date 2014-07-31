namespace KingSurvival.Base.GameObjects
{
    using KingSurvival.Base.Enums;

    /// <summary>
    /// A specific implementation of the abstract class Figure representing the King in the game
    /// </summary>
    public class King : Figure
    {
        private const string KingName = "King";
        private const char KingSymbol = (char)FigureSymbols.KingSymbol;

        public King(Position initialPosition)
            : base(initialPosition, KingSymbol, KingName)
        {
        }
    }
}