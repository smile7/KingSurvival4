namespace KingSurvival4
{
    /// <summary>
    /// The class which contains all the messages that are printed on the board during the game
    /// </summary>
    public static class ConsoleMessages
    {
        public static string KingsTurnMessage()
        {
            return "King's turn:";
        }

        public static string PawnsTurnMessage()
        {
            return "Pawn's turn:";
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
    }
}
