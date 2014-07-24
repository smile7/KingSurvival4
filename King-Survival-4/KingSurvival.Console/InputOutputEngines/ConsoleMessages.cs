namespace KingSurvival4
{
    /// <summary>
    /// The class which contains all the messages that are printed on the board during the game
    /// </summary>
    public static class ConsoleMessages
    {
        public static string FiguresTurnMessage(string figuresName)
        {
            return string.Format("{0}'s turn:", figuresName);
        }

        public static string InvalidMoveMessage()
        {
            return "Illegal move. Please try again.";
        }

        public static string OutsideBoardMoveMessage()
        {
            return "You're trying to move outside the board. Please try again.";
        }

        public static string StepOverFigureMoveMessage()
        {
            return "You can't step over another figure. Please enter a new command.";
        }

        public static string KingWonMessage(int steps)
        {
            return string.Format("King won in {0} turns", steps);
        }

        public static string KingLostMessage(int steps)
        {
            return string.Format("King lost in {0} turns", steps);
        }
    }
}
