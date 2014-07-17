namespace KingSurvival4
{
    internal class MoveKing : MoveFigure
    {
        public override void Move(Figure figure, int[] directions)
        {
            figure.Position.X += directions[0];
            figure.Position.Y += directions[1];
        }
    }
}
