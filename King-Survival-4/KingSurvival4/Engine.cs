namespace KingSurvival4
{
    public class Engine
    {
        public Engine()
        {
        }

        public void Start()
        {
            var board = Board.Instance;
            fillBoard();
        }

        private void fillBoard()
        {
            const string WhiteCell = "+";
            const string BlackCell = "-";

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if ((row + col) % 2 == 0)
                    {
                        Board.Field[row, col] = WhiteCell;
                    }
                    else
                    {
                        Board.Field[row, col] = BlackCell;
                    }
                }
            }

           var firstPawn = FigureGetter.GetFigure(new Position(0, 0), 'A', 'P', new MovePawn());
           var secondPawn = FigureGetter.GetFigure(new Position(0, 2), 'B', 'P', new MovePawn());
           var thirdPawn = FigureGetter.GetFigure(new Position(0, 4), 'C', 'P', new MovePawn());
           var fourthPawn =   FigureGetter.GetFigure(new Position(0, 6), 'D', 'P', new MovePawn());
           var king = FigureGetter.GetFigure(new Position(7, 3), 'K', 'K', new MoveKing());

           Board.Field[firstPawn.Position.X, firstPawn.Position.Y] = firstPawn.Name.ToString();
           Board.Field[secondPawn.Position.X, secondPawn.Position.Y] = secondPawn.Name.ToString();
           Board.Field[thirdPawn.Position.X, thirdPawn.Position.Y] = thirdPawn.Name.ToString();
           Board.Field[fourthPawn.Position.X, fourthPawn.Position.Y] = fourthPawn.Name.ToString();
           Board.Field[king.Position.X, king.Position.Y] = king.Name.ToString();
            
        }
    }
}
