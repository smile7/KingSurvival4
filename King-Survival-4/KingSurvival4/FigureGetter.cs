using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival4
{
    public static class FigureGetter
    {
        public static Figure GetFigure(Position position, char name, char symbol, IMoveable mover)
        {
            switch (symbol)
            {
                case 'K':
                    return new King(position, mover);
                case 'P':
                    return new Pawn(position, name, mover);
                case 'S':
                    return new StaticCell(position, name, mover);
                default:
                    return new Figure(position, name, symbol, mover);
            }
        }
    }
}
