namespace KingSurvival4
{
    using System;
    using System.Linq;
    public class Command : ICommand
    {
        private Parser parser;
        private ProspectMemory memory = new ProspectMemory();
        private string input;

        private string[] COMMANDS = { "KUL", "KUR", "KDL", "KDR", "ADL", "ADR", "BDL", "BDR", "CDL", "CDR", "DDL", "DDR" };

        public Command(string initialInput)
        {
            this.Input = initialInput;
            this.FigureLetter = initialInput.Substring(0, 1);
            this.DirectionLetters = initialInput.Substring(1);
        }

        public string FigureLetter { get; set; }

        private string DirectionLetters { get; set; }

        public string Input
        {
            get
            {
                return this.input;
            }
            set
            {
                if (this.IsValid(value.ToUpper()))
                {
                    this.input = value.ToUpper();
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Illegal move");
                }
            }
        }

        public Direction DetermineDirection()
        {
            this.parser = new Parser(this.DirectionLetters);
            var direction = this.parser.GetDirection();
            return direction;
        }

        private bool IsValid(string currentInput)
        {
            if (this.COMMANDS.Contains(currentInput))
            {
                return true;
            }

            return false;
        }
        public Direction DetermineOppositeDirection()
        {
            switch (this.DirectionLetters)
            {
                case "UL":
                    this.DirectionLetters = "DR";
                    break;
                case "UR":
                    this.DirectionLetters = "DL";
                    break;
                case "DL":
                    this.DirectionLetters = "UR";
                    break;
                case "DR":
                    this.DirectionLetters = "UL";
                    break;
            }

            this.parser = new Parser(this.DirectionLetters);
            var direction = this.parser.GetDirection();
            return direction;
        }
    }
}
