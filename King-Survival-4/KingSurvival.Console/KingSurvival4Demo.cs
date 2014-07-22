namespace KingSurvival4
{
    /// <summary>
    /// The start of the program
    /// </summary>
    public class KingSurvival4Demo
    {
        public static void Main()
        {
            KingSurvivalEngine engine = new KingSurvivalConsoleEngine(new ConsoleReader(), new ConsoleWriter());
            engine.Start();
        }
    }
}
