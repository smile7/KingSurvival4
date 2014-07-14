using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival4
{
    public class Figure
    {
        public Position Position { get; set; }

        public char Name { get; set; }

        public char Symbol { get; set; }

        public Figure(Position initialPosition, char initialName, char initialSymbol)
        {
            this.Position = initialPosition;
            this.Name = initialName;
            this.Symbol = initialSymbol;
        }
    }
}
