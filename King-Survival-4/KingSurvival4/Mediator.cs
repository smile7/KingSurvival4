namespace KingSurvival4
{
    using System.Collections.Generic;

    internal class Mediator : AbstractMediator
    {
        private List<Figure> listOfFigures = new List<Figure>();

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
