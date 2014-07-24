namespace KingSurvival4
{
    using System;
    using System.Linq;

    /// <summary>
    /// The command class which receives a string and divides its letters 
    ///  - the first letter is for the figure which is about to be played
    ///  - the second and third letter are for the new position of the figure
    /// </summary>
    public class Command
    {
        private string input;
        private string[] validCommands = { "KUL", "KUR", "KDL", "KDR", "ADL", "ADR", "BDL", "BDR", "CDL", "CDR", "DDL", "DDR" };

        public Command(string initialInput)
        {
            this.Input = initialInput;
            this.FigureLetter = initialInput.Substring(0, 1);
            this.NewPositionLetters = initialInput.Substring(1);
        }

        public string FigureLetter { get; private set; }

        public string NewPositionLetters { get; private set; }

        private string Input
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
                    throw new ArgumentOutOfRangeException("The command is not valid.");
                }
            }
        }

        /// <summary>
        /// Checks if the input string is a valid command. 
        /// There are only 12 valid commands.
        /// </summary>
        /// <param name="currentInput">The given command</param>
        /// <returns>Does the command list contain the given input or not</returns>

        private bool IsValid(string input)
        {
            if (this.validCommands.Contains(input))
            {
                return true;
            }

            return false;
        }
    }
}
