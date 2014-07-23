namespace KingSurvival4
{
using System;

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
