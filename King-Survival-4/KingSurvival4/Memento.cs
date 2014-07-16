using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival4
{
    public class Memento
    {
        public Memento(string direstionString)
        {
            this.DirectionString = direstionString;
        }
        public string DirectionString { get; set; }
    }
}
