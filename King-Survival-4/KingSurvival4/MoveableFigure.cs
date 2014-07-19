namespace KingSurvival4
{
    public class MoveableFigure : Decorator
    {
        public MoveableFigure(Figure figure)
            : base(figure)
        {
        }

        public void MoveFigure(Direction directions)
        {
            this.Figure.Position.X += directions.X;
            this.Figure.Position.Y += directions.Y;
        }
    }
}
