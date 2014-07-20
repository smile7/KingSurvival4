namespace KingSurvival4
{
    /// <summary>
    /// Singleton pattern and Concrete observer class for Observer pattern
    /// </summary>
    public sealed class Board
    {
        private const string WhiteCell = "+";
        private const string BlackCell = "-";

        private const int NumberOfRows = 8;

        private const int NumberOfCols = 8;

        private static volatile Board instance;

        private static object syncLock = new object();

        public static string[,] Field { get; private set; }
        private Board()
        {
            Field = new string[NumberOfRows, NumberOfCols];
            this.FillBoard();
        }

        public static Board Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new Board();
                        }
                    }
                }

                return instance;
            }
        }

        private void FillBoard()
        {
            for (int row = 0; row < Field.GetLength(0); row++)
            {
                for (int col = 0; col < Field.GetLength(1); col++)
                {
                    if ((row + col) % 2 == 0)
                    {
                        Field[row, col] = WhiteCell;
                    }
                    else
                    {
                        Field[row, col] = BlackCell;
                    }
                }
            }
        }

        public void Notify(Figure figure)
        {
            Field[figure.Position.X, figure.Position.Y] = figure.Name.ToString();
        }

        public void Notify(Figure figure, Position oldPosition)
        {
            Field[figure.Position.X, figure.Position.Y] = figure.Name.ToString();
            Field[oldPosition.X, oldPosition.Y] = "+";
        }
    }
}
