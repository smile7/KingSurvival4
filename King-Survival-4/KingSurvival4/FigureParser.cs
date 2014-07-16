namespace KingSurvival4
{
    using System;
    internal class FigureParser : Parser
    {
        public override void Letter()
        {
            switch (this.FirugeLetter)
            {
                case 'A':
                    var movingPawn = new MovePawn();
                    //movingPawn.Move(Pawn A, )
                    break;
            }
        }
    }
}
