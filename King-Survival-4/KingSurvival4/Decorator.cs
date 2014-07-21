namespace KingSurvival4
{
    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    public abstract class Decorator : Figure
    {
        public Figure Figure { get; set; }
        public Decorator(Figure figure)
            :base(figure.Position, figure.Name, figure.Symbol)
        {
            this.Figure = figure;
        }
    }
}
