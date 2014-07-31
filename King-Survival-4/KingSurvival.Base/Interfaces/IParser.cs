namespace KingSurvival.Base.Interfaces
{
    /// <summary>
    /// Interface for the Parser class
    /// </summary>
    public interface IParser
    {
        Position GetNewPosition(string command);
    }
}
