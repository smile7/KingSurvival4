using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival4
{
    public class Figure
    {
        private char symbol;

        public Figure(char symbol)
        {
            this.Symbol = symbol;
        }

        public char Symbol { get; set; }
    }
}
