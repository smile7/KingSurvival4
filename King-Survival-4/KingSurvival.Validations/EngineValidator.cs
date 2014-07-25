namespace KingSurvival.Validations
{
    using System;
    using KingSurvival.Console;
    using KingSurvival.Base.GameObjects;
    public class EngineValidator : KingSurvivalConsoleEngine
    {
        protected bool HasGameEnded()
        {
            if (this.king.Position.X == 0)
            {
                return true;
            }

            var canPawnsMove = false;

            for (int i = 0; i < Board.Field.GetLength(0); i += 2)
            {
                if (Board.Field[Board.Field.GetLength(1) - 1, i] == Board.WhiteCell || Board.Field[Board.Field.GetLength(1) - 1, i] == Board.BlackCell)
                {
                    canPawnsMove = true;
                }
            }

            if (!canPawnsMove)
            {
                return true;
            }

            bool canMoveDownRight = this.IsSurrounded(this.king.Position.X + 1, this.king.Position.Y + 1);
            bool canMoveDownLeft = this.IsSurrounded(this.king.Position.X + 1, this.king.Position.Y - 1);
            bool canMoveUpRight = this.IsSurrounded(this.king.Position.X - 1, this.king.Position.Y + 1);
            bool canMoveUpLeft = this.IsSurrounded(this.king.Position.X - 1, this.king.Position.Y - 1);

            if (!canMoveDownRight && !canMoveDownLeft && !canMoveUpRight && !canMoveUpLeft)
            {
                return true;
            }

            return false;
        }

        //protected bool HasKingWon()
        //{
        //    if (this.king.Position.X == 0)
        //    {
        //        return true;
        //    }

        //    for (int i = 0; i < Board.Field.GetLength(0); i += 2)
        //    {
        //        if (Board.Field[Board.Field.GetLength(1) - 1, i] == Board.WhiteCell || Board.Field[Board.Field.GetLength(1) - 1, i] == Board.BlackCell)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        //protected override bool HasKingLost()
        //{
        //    bool canMoveDownRight = this.IsSurrounded(this.king.Position.X + 1, this.king.Position.Y + 1);
        //    bool canMoveDownLeft = this.IsSurrounded(this.king.Position.X + 1, this.king.Position.Y - 1);
        //    bool canMoveUpRight = this.IsSurrounded(this.king.Position.X - 1, this.king.Position.Y + 1);
        //    bool canMoveUpLeft = this.IsSurrounded(this.king.Position.X - 1, this.king.Position.Y - 1);

        //    if (!canMoveDownRight && !canMoveDownLeft && !canMoveUpRight && !canMoveUpLeft)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        private bool IsSurrounded(int row, int col)
        {
            if (this.IsPositionInsideBoard(row, col))
            {
                if (this.HasSteppedOverAnotherFigure(row, col))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
