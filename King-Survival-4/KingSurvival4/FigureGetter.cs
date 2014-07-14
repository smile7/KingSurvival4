using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival4
{
    public static class FigureGetter
    {
        public static Figure GetFigure(char symbol, Position position)
        {
            switch (symbol)
            {
                case 'K':
                    return new King(position);
                case 'P':
                    return new Pawn(position);
                case 'S':
                    return new StaticCell(position);
                default:
                    return new Figure(position);
            }
        }
    }
}
