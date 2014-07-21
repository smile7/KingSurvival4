namespace KingSurvival4
{
    using System;
    using System.Linq;
    public class Command : ICommand
    {
        private Parser parser;
        private ProspectMemory memory;
        private string input;

        private string[] Commands = { "KUL", "KUR", "KDL", "KDR", "ADL", "ADR", "BDL", "BDR", "CDL", "CDR", "DDL", "DDR" };

        public Command(string initialInput)
        {
            this.memory = new ProspectMemory();
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

        public Position DetermineDirection()
        {
            this.parser = new Parser(this.DirectionLetters);
            var direction = this.parser.GetDirection();
            return direction;
        }

        private bool IsValid(string currentInput)
        {
            if (this.Commands.Contains(currentInput))
            {
                return true;
            }

            return false;
        }
    }
}
