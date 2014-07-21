namespace KingSurvival4
{
    public interface IRenderer
    {
        void WriteMessage(string message);

        void Render(string[,] board);

        void Clear();
    }
}
