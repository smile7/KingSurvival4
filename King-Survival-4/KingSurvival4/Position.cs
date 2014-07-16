using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival4
{
    public class Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        //TODO: Maybe check for a valid position

        //private bool IsPositionInsideBoard(int row, int col)
        //{
        //    if (row < 0 || row > this.board.GetLength(0) - 1 || col < 0 || col > this.board.GetLength(1) - 1)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        public int X { get; set; }
        public int Y { get; set; }

    }
}
