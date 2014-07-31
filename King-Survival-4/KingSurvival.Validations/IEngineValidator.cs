namespace KingSurvival.Validations
{
    using System.Collections.Generic;

    using KingSurvival.Base;
    using KingSurvival.Base.GameObjects;

    /// <summary>
    /// Interface for the EngineValidator class
    /// </summary>
    public interface IEngineValidator
    {
        bool IsMoveValid(Figure figure, Position newPosition);

        bool HasGameEnded(IDictionary<char, Figure> figures);

        bool HasKingWon(IDictionary<char, Figure> figures);

    }
}
