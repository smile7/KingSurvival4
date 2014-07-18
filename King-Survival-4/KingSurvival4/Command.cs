namespace KingSurvival4
{
    public class Command : ICommand
    {
        private Parser parser;
        private ProspectMemory memory = new ProspectMemory();

        public Command(string initialInput)
        {
            this.Input = initialInput;
            this.FigureLetter = initialInput.Substring(0, 1);
            this.DirectionLetters = initialInput.Substring(1);
        }

        public string FigureLetter { get; set; }

        private string DirectionLetters { get; set; }

        public string Input { get; set; }

        public Direction DetermineDirection()
        {
            this.memory.Memento = this.SaveMemento();

            this.parser = new Parser(this.DirectionLetters);
            var direction = this.parser.GetDirection();
            return direction;
        }

        public Direction DetermineOppositeDirection()
        {
            this.RestoreMemento(this.memory.Memento); // this works without memento!!!!!!!!!!!!! try to fix it
            switch (this.DirectionLetters)
            {
                case "UL":
                    this.DirectionLetters = "DR";
                    break;
                case "UR":
                    this.DirectionLetters = "DL";
                    break;
                case "DL":
                    this.DirectionLetters = "UR";
                    break;
                case "DR":
                    this.DirectionLetters = "UL";
                    break;
            }

            this.parser = new Parser(this.DirectionLetters);
            var direction = this.parser.GetDirection();
            return direction;
        }

        public Memento SaveMemento()
        {
            return new Memento(this.DirectionLetters);
        }

        public void RestoreMemento(Memento memento)
        {
            this.DirectionLetters = memento.DirectionString;
        }
    }
}
