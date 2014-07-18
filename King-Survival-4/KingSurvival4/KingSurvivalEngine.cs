namespace KingSurvival4
{
    public class KingSurvivalEngine
    {
        protected IRenderer Renderer {get; private set;}
        protected IReader Reader {get; private set;}

        public KingSurvivalEngine(IReader reader, IRenderer renderer)
        {
            this.Reader = reader;
            this.Renderer = renderer;
        }

        public void Start()
        { 
            //TO DO: Move strat method from consoleEngine ot this one
        }
    }
}
