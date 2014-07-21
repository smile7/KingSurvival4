namespace KingSurvival4
{
    public class Memento
    {
        public Memento(Position position, char name, char symbol)
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
