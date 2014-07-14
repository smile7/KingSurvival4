using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival4
{
    public static class FigureGetter
    {
        public static Figure GetFigure(char symbol){
            switch(symbol)
            {
                case 'K':
                    return new King();
                case 'P':
                    return new Pawn();
                case 'S':
                    return new StaticCell();
                default:
                    return new Figure();
            }
        }
    }
}
