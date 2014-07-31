namespace KingSurvival.Base
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

        public Command(string initialInput)
        {
            this.Input = initialInput;
        }

        /// <summary>
        /// A property for the first letter in the command 
        /// which says which figure should be played
        /// </summary>
        public char FigureLetter
        {
            get
            {
                return this.Input[0];
            }
        }

        /// <summary>
        /// A property for the second and third letter in the command 
        /// which says which direction the figure should go
        /// </summary>
        public string NewPositionLetters
        {
            get
            {
                return this.Input.Substring(1);
            }
        }

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
            if (input.Length == 3)
            {
                if (Constants.ListOfSymbols.Contains(input[0]))
                {
                    if (Constants.ListOfConstants.Contains(input.Substring(1)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
