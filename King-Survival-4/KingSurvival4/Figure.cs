namespace KingSurvival4
{
    public class Figure
    {
        public Figure(Position initialPosition, char initialName, char initialSymbol)
        {
            this.Position = initialPosition;
            this.Name = initialName;
            this.Symbol = initialSymbol;
        }

        public Position Position { get; set; }

        public char Name { get; set; }

        public char Symbol { get; set; }

        public virtual void Move() 
        { 
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
