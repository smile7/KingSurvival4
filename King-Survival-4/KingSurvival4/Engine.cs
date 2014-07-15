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

        }

        public void fillBoard()
        {
            const string WhiteCell = "+";
            const string BlackCell = "-";

            for (int row = 0; row < Board.Field.GetLength(0); row++)
            {
                for (int col = 0; col < Board.Field.GetLength(1); col++)
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


        }
    }
}
