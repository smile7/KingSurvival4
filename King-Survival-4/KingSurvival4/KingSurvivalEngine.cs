namespace KingSurvival4
{
    public abstract class KingSurvivalEngine
    {
        protected IRenderer Renderer {get; private set;}
        protected IReader Reader {get; private set;}        

        public KingSurvivalEngine(IReader reader, IRenderer renderer)
        {
            this.Reader = reader;
            this.Renderer = renderer;
        }

        public abstract void Start();
    }
}
