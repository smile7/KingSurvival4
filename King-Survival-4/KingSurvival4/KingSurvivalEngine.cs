namespace KingSurvival4
{
    public abstract class KingSurvivalEngine
    {
        protected IRenderer Renderer { get; private set; }
        protected IReader Reader { get; private set; }

        public KingSurvivalEngine(IReader reader, IRenderer renderer)
        {
            this.Reader = reader;
            this.Renderer = renderer;
        }

        public abstract void Start();

        protected string GetCommand()
        {
            return this.Reader.Read();
        }

        protected void PostMessage(string message)
        {
            this.Renderer.WriteMessage(message);
        }

        protected void PrintBoard(string[,] board)
        {
            this.Renderer.Clear();
            this.Renderer.Render(board);
        }
    }
}
