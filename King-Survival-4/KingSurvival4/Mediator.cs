using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival4
{
    internal class Mediator : AbstractMediator
    {
        List<Figure> listOfFigures = new List<Figure>();

       
        public override void AddFigure(Figure figure)
        {
            this.listOfFigures.Add(figure);
        }

        public override void ChangePosition(Figure figure, Command comand)
        {
            //TO DO: check if new position is not available or is outside the board
        }
    }
}
