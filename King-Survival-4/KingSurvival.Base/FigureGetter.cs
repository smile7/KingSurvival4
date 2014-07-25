namespace KingSurvival.Base
{
    using KingSurvival.Base.GameObjects;

    /// <summary>
    /// The Figure 'Creator' class implementing the Simple Factory pattern
    /// </summary>
    public static class FigureGetter
    {
        /// <summary>
        /// Creates the figures on the board
        /// </summary>
        /// <param name="position">The position of the figure which is going to be created</param>
        /// <param name="name">The name of the figure which is going to be created</param>
        /// <param name="symbol">The symbol of the figure which is going to be created</param>
        /// <returns>Returns King or Pawn depending on the symbol</returns>
        public static Figure GetFigure(Position position, char symbol, string name)
        {
            switch (name)
            {
                case "King":
                    return new King(position);
                default:
                    return new Pawn(position, symbol);
            }
        }
    }
}
