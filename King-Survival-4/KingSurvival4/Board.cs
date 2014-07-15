namespace KingSurvival4
{
    public sealed class Board
    {
        private static volatile Board instance;

        private const int NumberOfRows = 8;

        private const int NumberOfCols = 8;

        public string[,] field;

        private static object syncLock = new object();

        private Board() 
        {
            field = new string[NumberOfRows, NumberOfCols];
        }

        public string[,] Field { get; private set; }

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
    }
}
