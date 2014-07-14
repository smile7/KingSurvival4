namespace KingSurvival4
{
    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    internal abstract class Decorator : Figure
    {
        protected Decorator(Figure libraryItem)
        {
            this.LibraryItem = libraryItem;
        }

        protected Figure LibraryItem { get; set; }

        public override void Display()
        {
            //skdujhf
        }
    }
}