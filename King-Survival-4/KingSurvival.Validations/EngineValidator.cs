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
        /// <summary>
        /// Checks if a figure moves to a new position, the new position is valid
        /// </summary>
        /// <param name="figure">The figure that is about to move</param>
        /// <param name="direction">The position that we want to move the figure to</param>
        /// <returns></returns>
        public bool IsMoveValid(Figure figure, Position direction)
        {
            int newX = figure.Position.X + direction.X;
            int newY = figure.Position.Y + direction.Y;

            if (this.IsPositionInsideBoard(newX, newY))
            {
                if (this.IsCellEmpty(newX, newY))
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
        public bool HasGameEnded(IDictionary<char, Figure> figures)
        {
            if (this.IsFigureOnTopOfBoard(figures[Constants.KingSymbol]) || this.ArePawnsOnBottomOfBoard(figures))
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
        public bool HasKingWon(IDictionary<char, Figure> figures)
        {
            if (this.IsFigureOnTopOfBoard(figures[Constants.KingSymbol]) || this.ArePawnsOnBottomOfBoard(figures))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a figure is on the top of the board
        /// </summary>
        /// <param name="figure">The figure</param>
        /// <returns>true/false</returns>
        private bool IsFigureOnTopOfBoard(Figure figure)
        {
            if (figure.Position.X == Constants.MinNumberOfRows)
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
            if (col < Constants.MinNumberOfCols ||
                col >= Constants.MaxNumberOfCols ||
                row < Constants.MinNumberOfRows ||
                row >= Constants.MaxNumberOfRows)
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
        private bool ArePawnsOnBottomOfBoard(IDictionary<char, Figure> figures)
        {
            if (figures[Constants.FirstPawnSymbol].Position.Y != Constants.MaxNumberOfRows ||
                figures[Constants.SecondPawnSymbol].Position.Y != Constants.MaxNumberOfRows ||
                figures[Constants.ThirdPawnSymbol].Position.Y != Constants.MaxNumberOfRows ||
                figures[Constants.FourthPawnSymbol].Position.Y != Constants.MaxNumberOfRows)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if a figure has stepped over another figure
        /// or the cell is empty
        /// </summary>
        /// <param name="row">The x coordinate</param>
        /// <param name="col">The y coordinate</param>
        /// <returns>True/false</returns>
        private bool IsCellEmpty(int row, int col)
        {
            if (Board.Field[row, col] == Constants.WhiteCell || Board.Field[row, col] == Constants.BlackCell)
            {
                return true;
            }

            return false;
        }
    }
}
