namespace KingSurvival4
{
    internal interface ICommand
    {
        Direction DetermineDirection();

        Direction DetermineOppositeDirection();
    }
}
