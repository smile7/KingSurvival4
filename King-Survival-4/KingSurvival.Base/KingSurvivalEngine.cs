namespace KingSurvival4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The main abstract class of the game which defines the methods and the properties that
    /// can be used by the concrete implementators for different platforms
    /// </summary>
    public abstract class KingSurvivalEngine
    {
        private IWriter renderer;
        private IReader reader;
        public KingSurvivalEngine(IReader reader, IWriter renderer)
        {
            this.Reader = reader;
            this.Writer = renderer;
        }

        protected IList<Figure> Figures { get; set; }

        protected IWriter Writer
        {
            get
            {
                return this.renderer;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("The writer cannot be null!");
                }

                this.renderer = value;
            }
        }

        protected IReader Reader
        {
            get
            {
                return this.reader;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("The reader cannot be null!");
                }

                this.reader = value;
            }
        }

        /// <summary>
        /// The start of the game
        /// </summary>
        public void Start()
        {
            this.GameBegins();
        }

        protected abstract void GameBegins();


        /// <summary>
        /// Read a command from the player of the game
        /// </summary>
        /// <returns>A string with the command</returns>
        protected string GetCommand()
        {
            return this.Reader.ReadMessage();
        }

        /// <summary>
        /// Send a message to the player of the game
        /// </summary>
        /// <param name="message">The message that should be displayed</param>
        protected void PostMessage(string message)
        {
            this.Writer.WriteMessage(message);
        }

        /// <summary>
        /// Prints the whole board
        /// </summary>
        /// <param name="board"></param>
        protected void RenderBoard(string[,] board)
        {
            this.Writer.Clear();
            this.Writer.RenderBoard(board);
        }
    }
}
