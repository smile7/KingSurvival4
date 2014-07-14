namespace KingSurvival4
{
    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    internal abstract class Decorator : Figure
    {
        protected Decorator(Figure figureItem)
        {
            this.FigureItem = figureItem;
        }

        public Figure FigureItem { get; set; }

        public override void Move()
        {
            //TO DO
        }

    }
}