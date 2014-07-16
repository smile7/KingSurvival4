namespace KingSurvival4
{
    public class Command : ICommand
    {
        public Command(string initialInput)
        {
            this.Input = initialInput;
        }
        public string Input { get; set; }

        public void setInput(string input)
        {
            this.Input = input;
        }
    }
}
