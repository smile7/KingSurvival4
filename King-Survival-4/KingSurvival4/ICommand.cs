namespace KingSurvival4
{
    internal interface ICommand
    {
        int[] DetermineDirection();

        int[] DetermineOppositeDirection();
    }
}
