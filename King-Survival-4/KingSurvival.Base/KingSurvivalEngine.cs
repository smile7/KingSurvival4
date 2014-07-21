namespace KingSurvival4
{
    using System.Collections.Generic;

    /// <summary>
    /// Abstract implementator for Bridge pattern
    /// </summary>
    public abstract class KingSurvivalEngine
    {
        public KingSurvivalEngine(IReader reader, IRenderer renderer)
        {
            this.Reader = reader;
            this.Renderer = renderer;
        }

        protected IRenderer Renderer { get; private set; } //TO DO: check if null when set

        protected IReader Reader { get; private set; }

        protected IList<Figure> Figures { get; set; }

        public abstract void Start();

        protected string GetCommand()
        {
            return this.Reader.Read();
        }

        protected void PostMessage(string message)
        {
            this.Renderer.WriteMessage(message);
        }

        protected void RenderBoard(string[,] board)
        {
            this.Renderer.Clear();
            this.Renderer.Render(board);
        }
    }
}
