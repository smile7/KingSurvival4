namespace KingSurvival4
{
    public abstract class Decorator : Figure
    {
        public Figure Figure { get; set; }
        public Decorator(Figure figure)
        {
            this.Figure = figure;
        }
    }
}
