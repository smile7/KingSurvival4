using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival4
{
    internal abstract class AbstractMediator
    {
        public abstract void AddFigure(Figure figure);
        public abstract void ChangePosition(Figure figure, Command command);
    }
}
