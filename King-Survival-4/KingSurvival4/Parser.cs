namespace KingSurvival4
{
    internal class Parser
    {
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
                case "UL":
                    return new Direction ( -1, -1 );
                case "UR":
                    return new Direction ( -1, 1 );
                case "DL":
                    return new Direction ( 1, -1 );
                case "DR":
                    return new Direction ( 1, 1 ); 
                default:
                    return new Direction ( 0, 0 ); 
            }
        }
    }
}
