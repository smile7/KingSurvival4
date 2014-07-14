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
        public Figure(Position initialPosition)
        {
            this.Position = initialPosition;
        }
    }
}
