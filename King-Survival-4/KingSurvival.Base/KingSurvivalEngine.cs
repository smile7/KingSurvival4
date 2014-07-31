namespace KingSurvival.Base
{
    using System;
    using System.Collections.Generic;
    using KingSurvival.Base.GameObjects;
    using KingSurvival.Base.Interfaces;

    /// <summary>
    /// The main abstract class of the game which defines the methods and the properties that
    /// can be used by the concrete implementators for different platforms
    /// </summary>
    public abstract class KingSurvivalEngine
    {
        private IWriter writer;
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
                return this.writer;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("The writer cannot be null!");
                }

                this.writer = value;
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

        /// <summary>
        /// This is the logic of the game, the actual game starts here
        /// </summary>
        protected abstract void GameBegins();

        /// <summary>
        /// When the king wins or loses, this is the end logic
        /// </summary>
        protected abstract void GameEnds();

        /// <summary>
        /// Determines if the king wins in the end
        /// </summary>
        /// <returns>True/false</returns>
        //protected abstract bool HasKingWon();


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
        protected void WriteMessage(string message)
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
