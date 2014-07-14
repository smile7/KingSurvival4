namespace KingSurvival4
{
    public sealed class Board
    {
        private static volatile Board instance; 

        private static object syncLock = new object();

        private Board() { }

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
