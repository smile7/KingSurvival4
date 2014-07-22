namespace KingSurvival4
{
    /// <summary>
    /// The 'ConcreteDecorator' class which enables a figure to move to a different position by extending its behaviour
    /// </summary>
    public class MoveableFigure : FigureDecorator
    {
        public MoveableFigure(Figure figure)
            : base(figure)
        {
        }

        /// <summary>
        /// Moves the figure to a different position
        /// </summary>
        /// <param name="directions">The new coordinates of the position</param>
        public void MoveFigure(Position directions)
        {
            this.Figure.Position.X += directions.X;
            this.Figure.Position.Y += directions.Y;
        }
    }
}
