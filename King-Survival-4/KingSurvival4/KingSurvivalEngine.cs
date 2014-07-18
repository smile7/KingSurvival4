namespace KingSurvival4
{
    using System;
    public class KingSurvivalEngine
    {
        protected IRenderer Renderer {get; private set;}
        protected IReader Reader {get; private set;}

        public const int MinRowIndex = 0;
        public const int MaxRowIndex = 8;
        public const int MinColumnIndex = 0;
        public const int MaxColumnIndex = 8;

        protected Figure firstPawn = FigureGetter.GetFigure(new Position(0, 0), 'A', 'P');
        protected Figure secondPawn = FigureGetter.GetFigure(new Position(0, 2), 'B', 'P');
        protected Figure thirdPawn = FigureGetter.GetFigure(new Position(0, 4), 'C', 'P');
        protected Figure fourthPawn = FigureGetter.GetFigure(new Position(0, 6), 'D', 'P');
        protected Figure king = FigureGetter.GetFigure(new Position(7, 3), 'K', 'K');

        public KingSurvivalEngine(IReader reader, IRenderer renderer)
        {
            this.Reader = reader;
            this.Renderer = renderer;
        }

        public void Start()
        {
            var board = Board.Instance;
            bool kingsTurn = true;
            while (true)
            {
                // TODO check Kings win -> cw end message break;
                //Check kings lost -> cw end message break;

                this.Renderer.Clear();
                this.FillBoard();
                this.Renderer.Render(Board.Field);
                if (kingsTurn)
                {
                    do
                    {
                        this.Renderer.WriteMessage("King's turn: ");
                        var command = new CommandProxy();
                        try
                        {
                            command.Input = this.Reader.Read();
                            Direction initial = command.DetermineDirection();
                            string kingSymbol = command.realCommand.FigureLetter;

                            if (kingSymbol != "K")
                            {
                                throw new ArgumentOutOfRangeException();
                            }

                            if (this.IsMoveValid(this.king, initial))
                            {
                                MoveKing changeKingsPosition = new MoveKing();
                                changeKingsPosition.Move(this.king, initial);
                            }

                            kingsTurn = false;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            this.Renderer.WriteMessage("Illegal move. Please try again.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            this.Renderer.WriteMessage("Your move is outside the board. Please try again.");
                        }
                        catch (InvalidOperationException)
                        {
                            this.Renderer.WriteMessage("You can't step over a Pawn. Please enter new command.");
                        }
                    }
                    while (kingsTurn);
                }
                else
                {
                    do
                    {
                        this.Renderer.WriteMessage("Pawn's turn: ");
                        var command = new CommandProxy();

                        try
                        {
                            command.Input = this.Reader.Read();
                            Direction initial = command.DetermineDirection();
                            Figure chosenPawn = this.firstPawn;
                            string pawnSymbol = command.realCommand.FigureLetter;
                            switch (pawnSymbol)
                            {
                                case "A":
                                    chosenPawn = this.firstPawn;
                                    break;
                                case "B":
                                    chosenPawn = this.secondPawn;
                                    break;
                                case "C":
                                    chosenPawn = this.thirdPawn;
                                    break;
                                case "D":
                                    chosenPawn = this.fourthPawn;
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            if (this.IsMoveValid(chosenPawn, initial))
                            {
                                MovePawn changePawnsPOsition = new MovePawn();
                                changePawnsPOsition.Move(chosenPawn, initial);
                            }

                            kingsTurn = true;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            this.Renderer.WriteMessage("Illegal move. Please try again.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            this.Renderer.WriteMessage("Your move is outside the board. Please try again.");
                        }
                        catch (InvalidOperationException)
                        {
                            this.Renderer.WriteMessage("You can't step over another figure. Please enter new command.");
                        }
                    }
                    while (!kingsTurn);
                }
            }
        }

        private bool IsMoveValid(Figure figure, Direction direction)
        {
            int newX = figure.Position.X + direction.X;
            int newY = figure.Position.Y + direction.Y;

            if (newX >= MaxColumnIndex || newX < MinColumnIndex || newY >= MaxRowIndex || newY < MinRowIndex)
            {
                throw new IndexOutOfRangeException();
            }

            if (Board.field[newX, newY] != "+")
            {
                throw new InvalidOperationException();
            }

            return true;
        }

        private void FillBoard()
        {
            const string WhiteCell = "+";
            const string BlackCell = "-";

            for (int row = 0; row < Board.Field.GetLength(0); row++)
            {
                for (int col = 0; col < Board.Field.GetLength(1); col++)
                {
                    if ((row + col) % 2 == 0)
                    {
                        Board.Field[row, col] = WhiteCell;
                    }
                    else
                    {
                        Board.Field[row, col] = BlackCell;
                    }
                }
            }

            Board.Field[this.firstPawn.Position.X, this.firstPawn.Position.Y] = this.firstPawn.Name.ToString();
            Board.Field[this.secondPawn.Position.X, this.secondPawn.Position.Y] = this.secondPawn.Name.ToString();
            Board.Field[this.thirdPawn.Position.X, this.thirdPawn.Position.Y] = this.thirdPawn.Name.ToString();
            Board.Field[this.fourthPawn.Position.X, this.fourthPawn.Position.Y] = this.fourthPawn.Name.ToString();
            Board.Field[this.king.Position.X, this.king.Position.Y] = this.king.Name.ToString();
        }
    }
}
