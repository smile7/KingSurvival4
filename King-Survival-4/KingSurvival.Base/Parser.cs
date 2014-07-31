namespace KingSurvival.Base
{
    using KingSurvival.Base.Interfaces;

    /// <summary>
    /// A class which receives the second 2 letters of a command and parses them to a position
    /// </summary>
    public class Parser : IParser
    {
        /// <summary>
        /// Determines what is the new position of the figure based on the last 2 letters of the command
        /// </summary>
        /// <returns>The new position</returns>
        public Position GetNewPosition(string command)
        {
            string directionStr = command.ToUpper();

            switch (directionStr)
            {
                case Constants.MoveUpLeft:
                    return new Position(-1, -1);
                case Constants.MoveUpRight:
                    return new Position(-1, 1);
                case Constants.MoveDownLeft:
                    return new Position(1, -1);
                default:
                    return new Position(1, 1);
            }
        }
    }
}
