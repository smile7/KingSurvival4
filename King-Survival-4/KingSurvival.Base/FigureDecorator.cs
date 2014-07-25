namespace KingSurvival.Base
{
    using KingSurvival.Base.GameObjects;

    /// <summary>
    /// The 'Decorator' abstract class which enables to extend the class Figure
    /// </summary>
    public abstract class FigureDecorator : Figure
    {
        public FigureDecorator(Figure figure)
            : base(figure.Position, figure.Symbol, figure.Name)
        {
            this.Figure = figure;
        }

        public Figure Figure { get; set; }
    }
}
