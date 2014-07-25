namespace KingSurvival.Console.InputOutputEngines
{
    /// <summary>
    /// The class which contains all the messages that are printed on the board during the game
    /// </summary>
    public static class ConsoleMessages
    {
        /// <summary>
        /// The message displayed when it is the king's turn
        /// </summary>
        /// <returns>String message</returns>
        public static string KingsTurnMessage()
        {
            return string.Format("King's turn:");
        }

        /// <summary>
        /// The message displayed when it is the pawn's turn
        /// </summary>
        /// <returns>String message</returns>
        public static string PawnsTurnMessage()
        {
            return string.Format("Pawn's turn:");
        }

        /// <summary>
        /// The message displayed when the command is invalid
        /// </summary>
        /// <returns>String message</returns>
        public static string InvalidMoveMessage()
        {
            return "There is no such command. Please try again.";
        }

        /// <summary>
        /// The message displayed when the player is trying to move 
        /// a figure outside the board.
        /// </summary>
        /// <returns>String message</returns>
        public static string OutsideBoardMoveMessage()
        {
            return "You're trying to move outside the board. Please try again.";
        }

        /// <summary>
        /// The message displayed whe the player is trying to move 
        /// a figure to a position where another figure sits.
        /// </summary>
        /// <returns>String message</returns>
        public static string StepOverFigureMoveMessage()
        {
            return "You can't step over another figure. Please enter a new command.";
        }

        /// <summary>
        /// The message displayed when it is the king's turn and 
        /// the player is trying to move a pawn and vise versa
        /// </summary>
        /// <returns>String message</returns>
        public static string WrongFigureCommand()
        {
            return "It's not this figure's turn at the moment. Please enter a new command.";
        }

        /// <summary>
        /// The message displayed when the king has won
        /// </summary>
        /// <returns>String message</returns>
        public static string KingWonMessage(int steps)
        {
            return string.Format("King won in {0} turns", steps);
        }

        /// <summary>
        /// The message displayed when the king has lost
        /// </summary>
        /// <returns>String message</returns>
        public static string KingLostMessage(int steps)
        {
            return string.Format("King lost in {0} turns", steps);
        }
    }
}
