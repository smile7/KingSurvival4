namespace KingSurvival4
{
    public interface IWriter
    {
        void WriteMessage(string message);

        void RenderBoard(string[,] board);

        void Clear();
    }
}
