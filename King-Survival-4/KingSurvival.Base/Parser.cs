namespace KingSurvival4
{
    /// <summary>
    /// A class which receives the second 2 letters of a command and parses them to a position
    /// </summary>
    internal class Parser
    {
        /// <summary>
        /// Constants for the possible directions
        /// </summary>
        private const string UpLeft = "UL";
        private const string DownLeft = "DL";
        private const string UpRight = "UR";

        public Parser(string command)
        {
            this.Command = command;
        }

        public string Command { get; set; }

        /// <summary>
        /// Parses the direction in the command to a new position
        /// </summary>
        /// <returns>The new position</returns>
        public Position GetNewPosition()
        {
            string directionStr = this.Command.ToUpper();

            switch (directionStr)
            {
                case UpLeft:
                    return new Position(-1, -1);
                case UpRight:
                    return new Position(-1, 1);
                case DownLeft:
                    return new Position(1, -1);
                default:
                    return new Position(1, 1);
            }
        }
    }
}
