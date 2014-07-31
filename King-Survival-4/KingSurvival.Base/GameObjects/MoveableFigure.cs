namespace KingSurvival.Base.GameObjects
{
    using KingSurvival.Base.FigureExtensions;

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
        /// <param name="newPosition">The new coordinates of the position</param>
        public void MoveFigure(Position newPosition)
        {
            this.Figure.Position.X += newPosition.X;
            this.Figure.Position.Y += newPosition.Y;
        }
    }
}
