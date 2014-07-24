namespace KingSurvival4
{
    /// <summary>
    /// A Singleton class for the board which also implements method Notify for the Observer pattern
    /// </summary>
    public sealed class Board
    {
        public const string WhiteCell = "+";

        public const string BlackCell = "-";

        private const int NumberOfRows = 8;

        private const int NumberOfCols = 8;

        private static volatile Board instance;

        private static object syncLock = new object();

        /// <summary>
        /// A private constructor for the Singleton implementation
        /// </summary>
        private Board()
        {
            Field = new string[NumberOfRows, NumberOfCols];
            this.FillBoard();
        }

        public static string[,] Field { get; private set; }

        /// <summary>
        /// Board property which makes sure that there is only one instance of the class
        /// </summary>
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

        /// <summary>
        /// Notifies the board that there is a figure on it
        /// </summary>
        /// <param name="figure">The given figure</param>
        public void Notify(Figure figure)
        {
            Field[figure.Position.X, figure.Position.Y] = figure.Symbol.ToString();
        }

        /// <summary>
        /// Notifies the board that a figure has changed its position
        /// </summary>
        /// <param name="figure">The figure which is with new position</param>
        /// <param name="oldPosition">The old position of the figure</param>
        public void Notify(Figure figure, Position oldPosition)
        {
            Field[figure.Position.X, figure.Position.Y] = figure.Symbol.ToString();
            Field[oldPosition.X, oldPosition.Y] = "+";
        }

        /// <summary>
        /// A method which fill the board with + and - in the beginning
        /// </summary>
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
    }
}
