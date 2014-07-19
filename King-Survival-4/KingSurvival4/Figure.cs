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

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}