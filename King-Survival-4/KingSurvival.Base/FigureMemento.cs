namespace KingSurvival4
{
    /// <summary>
    /// A memento class for figure.
    /// Helps access the previous position of the figure if needed.
    /// </summary>
    public class FigureMemento
    {
        public FigureMemento(Position position, char name, char symbol)
        {
            this.Position = position;
            this.Name = name;
            this.Symbol = symbol;
        }

        public Position Position { get; set; }

        public char Name { get; set; }

        public char Symbol { get; set; }
    }
}
