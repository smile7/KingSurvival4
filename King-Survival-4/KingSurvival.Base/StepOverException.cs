using System;


namespace KingSurvival4
{
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
