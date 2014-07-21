namespace KingSurvival4
{
    internal class Parser
    {
        private const string UpLeft = "UL";
        private const string DownLeft = "DL";
        private const string UpRight = "UR";
        private const string DownRight = "DR";
        public Parser(string command)
        {
            this.Command = command;
        }

        public string Command { get; set; }

        public Direction GetDirection()
        {
            string directionStr = this.Command;
            switch (directionStr)
            {
                case UpLeft:
                    return new Direction ( -1, -1 );
                case UpRight:
                    return new Direction ( -1, 1 );
                case DownLeft:
                    return new Direction ( 1, -1 );
                case DownRight:
                    return new Direction ( 1, 1 ); 
                default:
                    return new Direction ( 0, 0 ); 
            }
        }
    }
}
