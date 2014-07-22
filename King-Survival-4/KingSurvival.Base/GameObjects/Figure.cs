namespace KingSurvival4
{
    /// <summary>
    /// An abstract class for the figures on the board which is implemented afterwards with Simple Factory pattern
    /// </summary>
    public abstract class Figure
    {
        public Figure(Position position, char name, char symbol)
        {
            this.Position = position;
            this.Name = name;
            this.Symbol = symbol;
        }

        public Position Position { get; set; }

        public char Name { get; set; }

        public char Symbol { get; set; }

        /// <summary>
        /// This saves a copy of a figure for further refference to its previous position
        /// </summary>
        /// <returns>A copy of the current figure</returns>
        public FigureMemento SaveMemento()
        {
            return new FigureMemento(this.Position, this.Name, this.Symbol);
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