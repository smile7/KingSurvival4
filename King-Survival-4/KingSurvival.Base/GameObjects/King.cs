namespace KingSurvival4
{
    using System;

    public class King : Figure, ICloneable

    {
        private const char KingName = 'K';
        private const char KingSymbol = 'K';
        public King(Position initialPosition)
            : base(initialPosition, KingName, KingSymbol)
        {
        }


    }
}
