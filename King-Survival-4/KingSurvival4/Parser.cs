namespace KingSurvival4
{
    internal abstract class Parser
    {
        public char FigureLetter { get; protected set; }

        public char VerticalLetter { get; protected set; }

        public char HorizontalLetter { get; protected set; }

        public void Interpret(Command commmand)
        {
            this.VerticalLetter = commmand.Input[1];
            this.HorizontalLetter = commmand.Input[2];

            switch (this.VerticalLetter)
            {
                //case 'U':

            }
        }

        public abstract char Letter();
    }
}
