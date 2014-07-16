using System;
namespace KingSurvival4
{
    internal class Parser
    {
        public Command Command { get; set; }
        public Parser(Command command)
        {
            this.Command = command;
        }

        private int[] GetDirection()
        {
            string directionStr = this.Command.Input.Substring(1);
            switch (directionStr)
            {
                case "UL":
                    return new int[] { -1, 1 };
                case "UR":
                    return new int[] { 1, 1 };
                case "DL":
                    return new int[] { -1, -1 };
                case "DR":
                    return new int[] { 1, -1 };
                default:
                    return new int[] { 0, 0 };
            }
        }
    }
}
