namespace KingSurvival4
{
    /// <summary>
    /// A memento class for figure.
    /// Helps access the previous position of the figure if needed.
    /// </summary>
    public class FigureMemento
    {
        public FigureMemento(Position position, char symbol, string name)
        {
            this.Position = position;
            this.Symbol = symbol;
            this.Name = name;
        }

        public Position Position { get; set; }

        public string Name { get; set; }

        public char Symbol { get; set; }
    }
}
