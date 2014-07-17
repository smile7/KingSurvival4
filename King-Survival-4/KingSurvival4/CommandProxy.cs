namespace KingSurvival4
{
    using System;
    using System.Linq;

    internal class CommandProxy : ICommand
    {
        public Command realCommand;

        private string FigureLetter { get; set; }

        private string DirectionLetters { get; set; }

        public string Input
        {
            get
            {
                if (this.realCommand == null)
                {
                    throw new ArgumentNullException("You haven't set value to the input!");
                }

                return this.realCommand.Input;
            }

            set
            {
                if (this.IsValid(value.ToUpper()))
                {
                    this.realCommand = new Command(value.ToUpper());
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Illegal move");
                }
            }
        }

        private string[] COMMANDS = { "KUL", "KUR", "KDL", "KDR", "ADL", "ADR", "BDL", "BDR", "CDL", "CDR", "DDL", "DDR" };

        public int[] DetermineDirection()
        {
            return this.realCommand.DetermineDirection();
        }

        public int[] DetermineOppositeDirection()
        {
            return this.realCommand.DetermineOppositeDirection();
        }

        private bool IsValid(string currentInput)
        {
            if (this.COMMANDS.Contains(currentInput))
            {
                return true;
            }

            return false;
        }
    }
}
