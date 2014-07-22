namespace KingSurvival4
{
    using System.Collections.Generic;

    /// <summary>
    /// The main abstract class of the game which defines the methods and the properties that
    /// can be used by the concrete implementators for different platforms
    /// </summary>
    public abstract class KingSurvivalEngine
    {
        public KingSurvivalEngine(IReader reader, IWriter renderer)
        {
            this.Reader = reader;
            this.Renderer = renderer;
        }

        protected IWriter Renderer { get; private set; } //TO DO: check if null when set

        protected IReader Reader { get; private set; }

        protected IList<Figure> Figures { get; set; }

        /// <summary>
        /// The start of the game
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Read a command from the player of the game
        /// </summary>
        /// <returns></returns>
        protected string GetCommand()
        {
            return this.Reader.ReadMessage();
        }

        /// <summary>
        /// Send a message to the player of the game
        /// </summary>
        /// <param name="message"></param>
        protected void PostMessage(string message)
        {
            this.Renderer.WriteMessage(message);
        }

        /// <summary>
        /// Prints the whole board
        /// </summary>
        /// <param name="board"></param>
        protected void RenderBoard(string[,] board)
        {
            this.Renderer.Clear();
            this.Renderer.RenderBoard(board);
        }
    }
}
