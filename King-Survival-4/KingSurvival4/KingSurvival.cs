namespace KingSurvival4
{
    public class KingSurvival
    {
        protected IRenderer Renderer {get; private set;}
        protected IReader Reader {get; private set;}

        public KingSurvival(IReader reader, IRenderer renderer)
        {
            this.Reader = reader;
            this.Renderer = renderer;
        }
    }
}
