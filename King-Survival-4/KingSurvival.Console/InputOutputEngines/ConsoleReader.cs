namespace KingSurvival4
{
    using System;

    /// <summary>
    /// The class which reads the messages from the console
    /// </summary>
    public class ConsoleReader : IReader
    {
        public string ReadMessage()
        {
            return Console.ReadLine();
        }
    }
}
