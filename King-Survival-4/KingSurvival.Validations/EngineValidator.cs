namespace KingSurvival.Validations
{
    using System;
    using System.Collections.Generic;

    using KingSurvival.Base;
    using KingSurvival.Base.Exceptions;
    using KingSurvival.Base.GameObjects;

    /// <summary>
    /// The class which does the validations for the engine
    /// </summary>
    public class EngineValidator : IEngineValidator
    {
        private const int MinRowIndex = 0;
        private const int MaxRowIndex = 8;
        private const int MinColumnIndex = 0;
        private const int MaxColumnIndex = 8;

        /// <summary>
        /// Checks if a figure moves to a new position, the new position is valid
        /// </summary>
        /// <param name="figure">The figure that is about to move</param>
        /// <param name="newPosition">The position that we want to move the figure to</param>
        /// <returns></returns>
        public bool IsMoveValid(Figure figure, Position newPosition)
        {
            int newX = figure.Position.X + newPosition.X;
            int newY = figure.Position.Y + newPosition.Y;

            if (this.IsPositionInsideBoard(newX, newY))
            {
                if (this.HasSteppedOverAnotherFigure(newX, newY))
                {
                    return true;
                }

                throw new StepOverException();
            }

            throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Method which checks if the game has ended
        /// </summary>
        /// <param name="king">List of figures</param>
        /// <returns>True or false</returns>
        public bool HasGameEnded(IDictionary<string, Figure> figures)
        {
            if (this.IsFigureOnTopOfBoard(figures["K"]) || this.ArePawnsOnBottomOfBoard(figures) || this.IsSurrounded(figures["K"]))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method which checks if the king has won or lost
        /// </summary>
        /// <param name="king">List of figures</param>
        /// <returns>True or false</returns>
        public bool HasKingWon(IDictionary<string, Figure> figures)
        {
            if (this.IsFigureOnTopOfBoard(figures["K"]) || this.ArePawnsOnBottomOfBoard(figures))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a position is inside the board or not
        /// </summary>
        /// <param name="row">The x coordinate</param>
        /// <param name="col">The y coordinate</param>
        /// <returns>True/false</returns>
        private bool IsPositionInsideBoard(int row, int col)
        {
            if (col >= MaxColumnIndex || col < MinColumnIndex || row >= MaxRowIndex || row < MinRowIndex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the pawns can move or they are all at the bottom of the board
        /// </summary>
        /// <param name="figures">List of figures</param>
        /// <returns>True/false</returns>
        private bool ArePawnsOnBottomOfBoard(IDictionary<string, Figure> figures)
        {
            if(figures["A"].Position.Y != 0 || 
                figures["B"].Position.Y != 0 || 
                figures["C"].Position.Y != 0 ||
                figures["D"].Position.Y != 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if a figure is on the top of the board
        /// </summary>
        /// <param name="figure">The figure</param>
        /// <returns>true/false</returns>
        private bool IsFigureOnTopOfBoard(Figure figure)
        {
            if (figure.Position.X == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a figure is surrounded and cannot move anymore
        /// </summary>
        /// <param name="figure">The figure</param>
        /// <returns>true/false</returns>
        private bool IsSurrounded(Figure figure)
        {
            try
            {
                bool canMoveDownRight = this.IsMoveValid(figure, new Position(figure.Position.X + 1, figure.Position.Y + 1));
                bool canMoveDownLeft = this.IsMoveValid(figure, new Position(figure.Position.X + 1, figure.Position.Y - 1));
                bool canMoveUpRight = this.IsMoveValid(figure, new Position(figure.Position.X - 1, figure.Position.Y + 1));
                bool canMoveUpLeft = this.IsMoveValid(figure, new Position(figure.Position.X - 1, figure.Position.Y - 1));

                if (canMoveDownRight || canMoveDownLeft || canMoveUpRight || canMoveUpLeft)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Checks if a figure has stepped over another figure
        /// or the cell is empty
        /// </summary>
        /// <param name="row">The x coordinate</param>
        /// <param name="col">The y coordinate</param>
        /// <returns>True/false</returns>
        private bool HasSteppedOverAnotherFigure(int row, int col)
        {
            if (Board.Field[row, col] == Board.WhiteCell || Board.Field[row, col] == Board.BlackCell)
            {
                return true;
            }

            return false;
        }
    }
}
