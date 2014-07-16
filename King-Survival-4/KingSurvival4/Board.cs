namespace KingSurvival4
{
    public sealed class Board
    {
        private static volatile Board instance;

        private const int NumberOfRows = 8;

        private const int NumberOfCols = 8;

        public static string[,] field;

        private static object syncLock = new object();

        private Board() 
        {
            field = new string[NumberOfRows, NumberOfCols];
        }

        public static string[,] Field 
        { 
            get 
            { 
                return field;
            } 
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
    }
}
