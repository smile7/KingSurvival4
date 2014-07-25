namespace KingSurvival.Validations
{
    using System;
    using KingSurvival.Base.GameObjects;
    using KingSurvival.Base.Exceptions;
    using KingSurvival.Base;

    /// <summary>
    /// The class which does the validations for the engine
    /// </summary>
    public static class EngineValidator
    {
        private const int MinRowIndex = 0;
        private const int MaxRowIndex = 8;
        private const int MinColumnIndex = 0;
        private const int MaxColumnIndex = 8;

        /// <summary>
        /// Method which checks if the game has ended: the king has won or the king has lost
        /// </summary>
        /// <param name="king">The king figure</param>
        /// <returns>True or false</returns>
        public static bool HasGameEnded(Figure king)
        {
            if (king.Position.X == 0)
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

            bool canMoveDownRight = IsSurrounded(king.Position.X + 1, king.Position.Y + 1);
            bool canMoveDownLeft = IsSurrounded(king.Position.X + 1, king.Position.Y - 1);
            bool canMoveUpRight = IsSurrounded(king.Position.X - 1, king.Position.Y + 1);
            bool canMoveUpLeft = IsSurrounded(king.Position.X - 1, king.Position.Y - 1);

            if (!canMoveDownRight && !canMoveDownLeft && !canMoveUpRight && !canMoveUpLeft)
            {
                return true;
            }

            return false;
        }

        private static bool IsSurrounded(int row, int col)
        {
            if (IsPositionInsideBoard(row, col))
            {
                if (HasSteppedOverAnotherFigure(row, col))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsMoveValid(Figure figure, Position newPosition)
        {
            int newX = figure.Position.X + newPosition.X;
            int newY = figure.Position.Y + newPosition.Y;

            if (IsPositionInsideBoard(newX, newY))
            {
                if (HasSteppedOverAnotherFigure(newX, newY))
                {
                    return true;
                }

                throw new StepOverException();
            }

            throw new IndexOutOfRangeException();
        }

        private static bool HasSteppedOverAnotherFigure(int row, int col)
        {
            if (Board.Field[row, col] == Board.WhiteCell || Board.Field[row, col] == Board.BlackCell)
            {
                return true;
            }

            return false;
        }

        private static bool IsPositionInsideBoard(int row, int col)
        {
            if (col >= MaxColumnIndex || col < MinColumnIndex || row >= MaxRowIndex || row < MinRowIndex)
            {
                return false;
            }

            return true;
        }
    }
}
