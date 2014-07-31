namespace KingSurvival.Base.GameObjects
{
    using System;
    using KingSurvival.Base.FigureExtensions;

    /// <summary>
    /// An abstract class for the figures on the board which is implemented afterwards with Simple Factory pattern
    /// </summary>
    public abstract class Figure : ICloneable
    {
        public Figure(Position position, char symbol, string name)
        {
            this.Position = position;
            this.Name = name;
            this.Symbol = symbol;
        }

        public Position Position { get; set; }

        public string Name { get; set; }

        public char Symbol { get; set; }

        /// <summary>
        /// This saves a copy of a figure for further refference to its previous position
        /// </summary>
        /// <returns>A copy of the current figure</returns>
        public FigureMemento SaveMemento()
        {
            return new FigureMemento(this.Position, this.Symbol, this.Name);
        }

        /// <summary>
        /// Deep clone of a figure
        /// </summary>
        /// <returns>A deep copy of the current figure</returns>
        public object Clone()
        {
            Figure newFigure = (Figure)this.MemberwiseClone();
            newFigure.Position = (Position)this.Position.Clone();
            return newFigure;
        }
    }
}