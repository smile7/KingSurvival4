namespace KingSurvival4
{
    using System;

    /// <summary>
    /// An exception class for throwing exceptions if a figure wants 
    /// to move to a position which is occupied by another figure
    /// </summary>
    public class StepOverException : Exception
    {
        public StepOverException()
        {
        }

        public StepOverException(string message)
            : base(message)
        {
        }
    }
}
