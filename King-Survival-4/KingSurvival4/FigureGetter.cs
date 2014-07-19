namespace KingSurvival4
{
    public static class FigureGetter
    {
        public static Figure GetFigure(Position position, char name, char symbol)
        {
            switch (symbol)
            {
                case 'K':
                    return new King(position);
                //case 'P':
                //    return new Pawn(position, name);
                default:
                    return new Pawn(position, name);
            }
        }
    }
}
