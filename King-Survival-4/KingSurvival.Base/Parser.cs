﻿namespace KingSurvival4
{
    internal class Parser
    {
        private const string UpLeft = "UL";
        private const string DownLeft = "DL";
        private const string UpRight = "UR";

        public Parser(string command)
        {
            this.Command = command;
        }

        public string Command { get; set; }

        public Position GetDirection()
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
