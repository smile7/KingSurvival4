namespace KingSurvival4
{
    public class KingSurvival4Demo
    {
        public static void Main()
        {
            KingSurvivalEngine engine = new KingSurvivalConsoleEngine(new ConsoleReader(), new ConsoleRenderer());
            engine.Start();
        }
    }
}
