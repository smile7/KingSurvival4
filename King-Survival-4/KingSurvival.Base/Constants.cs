using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Base
{
    /// <summary>
    /// Static class with all the constants in the game.
    /// </summary>
    public static class Constants
    {
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

        public static List<char> ListOfSymbols = new List<char>(new char[] { 'A', 'B', 'C', 'K' });

        public static List<string> ListOfConstants = new List<string>(new string[] { "UR", "UL", "DR", "DL" });
    }
}
