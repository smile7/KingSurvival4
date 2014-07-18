namespace KingSurvival4
{
    internal class MoveKing : MoveFigure
    {
        public override void Move(Figure figure, Direction directions)
        {
            figure.Position.X += directions.X;
            figure.Position.Y += directions.Y;
        }
    }
}
