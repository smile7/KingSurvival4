namespace KingSurvival.Base
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Static class with all the constants in the game.
    /// </summary>
    public static class Constants
    {
        public const int CommandLength = 3;

        public const string WhiteCell = "+";

        public const string BlackCell = "-";

        public const int MaxNumberOfRows = 8;

        public const int MaxNumberOfCols = 8;

        public const int MinNumberOfRows = 0;

        public const int MinNumberOfCols = 0;

        public const int FirstPawnInitialRow = 0;

        public const int FirstPawnInitialCol = 0;

        public const int SecondPawnInitialRow = 0;

        public const int SecondPawnInitialCol = 2;

        public const int ThirdPawnInitialRow = 0;

        public const int ThirdPawnInitialCol = 4;

        public const int FourthPawnInitialRow = 0;

        public const int FourthPawnInitialCol = 6;

        public const int KingInitialRow = 7;

        public const int KingInitialCol = 3;

        public const char FirstPawnSymbol = 'A';

        public const char SecondPawnSymbol = 'B';

        public const char ThirdPawnSymbol = 'C';

        public const char FourthPawnSymbol = 'D';

        public const char KingSymbol = 'K';

        public const string MoveUpRight = "UR";

        public const string MoveUpLeft = "UL";

        public const string MoveDownRight = "DR";

        public const string MoveDownLeft = "DL";

        public const string KingName = "King";

        public const string PawnName = "Pawn";

        public static readonly List<char> ListOfSymbols = new List<char>(new char[] { 'A', 'B', 'C', 'K' });

        public static readonly List<string> ListOfConstants = new List<string>(new string[] { "UR", "UL", "DR", "DL" });
    }
}
