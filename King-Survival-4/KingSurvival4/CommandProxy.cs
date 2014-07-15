using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival4
{
    internal class CommandProxy :ICommand
    {
        private Command realCommand;
        private string input;
        private const string[] COMMANDS = {"KUL", "KUR", "KDL", "KDR", "ADL", "ADR", "BDL", "BDR", "CDL", "CDR", "DDL", "DDR" };

        public string Input
        {
            get
            {
                return this.input;
            }
            set
            {
                if (IsValid(value.ToUpper()))
                {
                    this.input = value;
                }
                else
                {
                    Console.WriteLine("Illegal move!");
                }
            }
        }

        private bool IsValid(string currentInput)
        {
            if (COMMANDS.Contains(currentInput))
            {
                return true;
            }

            return false;
        }
    }
}
