using System;
namespace KingSurvival4
{
    /// <summary>
    /// The 'Component' abstract class for Decorator pattern and Simple Factory pattern
    /// </summary>
    public abstract class Figure
    {
        public Position Position { get; set; }

        public char Name { get; set; }

        public char Symbol { get; set; }

        public Memento SaveMemento()
        {
            return new Memento(this.Position, this.Name, this.Symbol);
        }
        public override string ToString()
        {
            return this.Name.ToString();
        }

        public abstract object Clone();
    }
}