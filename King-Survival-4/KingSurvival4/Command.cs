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

        public void ExecuteCommand()
        {
            throw new System.NotImplementedException();
        }

        public void UndoCommand()
        {
            throw new System.NotImplementedException();
        }
    }
}
