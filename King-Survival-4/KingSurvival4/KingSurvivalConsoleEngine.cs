namespace KingSurvival4
{
    using System;
    using System.Collections.Generic;

    public class KingSurvivalConsoleEngine : KingSurvivalEngine
    {
        public KingSurvivalConsoleEngine(ConsoleReader reader, ConsoleRenderer renderer)
            : base(reader, renderer)
        {
        }

    }
}
