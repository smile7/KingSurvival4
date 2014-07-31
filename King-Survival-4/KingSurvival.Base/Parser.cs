namespace KingSurvival.Base
{
    using KingSurvival.Base.Interfaces;

    /// <summary>
    /// A class which receives the second 2 letters of a command and parses them to a position
    /// </summary>
    public class Parser : IParser
    {
        /// <summary>
        /// Constants for the possible directions
        /// </summary>
        private const string UpLeft = "UL";
        private const string DownLeft = "DL";
        private const string UpRight = "UR";

        /// <summary>
        /// Determines what is the new position of the figure based on the last 2 letters of the command
        /// </summary>
        /// <returns>The new position</returns>
        public Position GetNewPosition(string command)
        {
            string directionStr = command.ToUpper();

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
