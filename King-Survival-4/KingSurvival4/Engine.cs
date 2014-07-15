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

        public void fillBoard()
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

            FigureGetter.GetFigure(new Position(0, 0), 'A', 'P', null);
            FigureGetter.GetFigure(new Position(0, 2), 'B', 'P', null);
            FigureGetter.GetFigure(new Position(0, 4), 'C', 'P', null);
            FigureGetter.GetFigure(new Position(0, 6), 'D', 'P', null);
            FigureGetter.GetFigure(new Position(7, 3), 'K', 'K', null);
            
        }
    }
}
