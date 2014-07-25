namespace KingSurvival.Console
{
    using KingSurvival.Base;

    /// <summary>
    /// The start of the program
    /// </summary>
    public class KingSurvivalDemo
    {
        public static void Main()
        {
            KingSurvivalEngine engine = new KingSurvivalConsoleEngine();
            engine.Start();
        }
    }
}
