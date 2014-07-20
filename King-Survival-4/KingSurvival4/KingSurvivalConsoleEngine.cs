namespace KingSurvival4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// FACADE for Facade pattern and Concrete implementation of Bridge pattern
    /// </summary>
    public class KingSurvivalConsoleEngine : KingSurvivalEngine
    {
        public const int MinRowIndex = 0;
        public const int MaxRowIndex = 8;
        public const int MinColumnIndex = 0;
        public const int MaxColumnIndex = 8;


        protected Figure firstPawn = FigureGetter.GetFigure(new Position(0, 0), 'A', 'P');
        protected Figure secondPawn = FigureGetter.GetFigure(new Position(0, 2), 'B', 'P');
        protected Figure thirdPawn = FigureGetter.GetFigure(new Position(0, 4), 'C', 'P');
        protected Figure fourthPawn = FigureGetter.GetFigure(new Position(0, 6), 'D', 'P');
        protected Figure king = FigureGetter.GetFigure(new Position(7, 3), 'K', 'K');

        Board board;
        public KingSurvivalConsoleEngine(ConsoleReader reader, ConsoleRenderer renderer)
            : base(reader, renderer)
        {
            board = Board.Instance;
            this.Figures = new List<Figure>();
            this.Figures.Add(firstPawn);
            this.Figures.Add(secondPawn);
            this.Figures.Add(thirdPawn);
            this.Figures.Add(fourthPawn);
            this.Figures.Add(king);
        }

        public override void Start()
        {
            bool kingsTurn = true;
            int countTurns = 0;

            ProspectMemory oldPosition = new ProspectMemory();

            while (true)
            {
                foreach (var figure in this.Figures)
                {
                    board.Notify(figure);
                }

                this.RenderBoard(Board.Field);


                bool hasWon = false;
                bool hasLost = false;
                if (kingsTurn)
                {
                    do
                    {
                        countTurns++;
                        this.PostMessage("King's turn: ");
                        var command = new CommandProxy();
                        try
                        {
                            command.Input = this.GetCommand();
                            Direction initial = command.DetermineDirection();
                            string kingSymbol = command.realCommand.FigureLetter;

                            if (kingSymbol != "K")
                            {
                                throw new ArgumentOutOfRangeException();
                            }

                            if (this.IsMoveValid(this.king, initial))
                            {
                                var clonedKing = this.king.Clone() as Figure;
                                oldPosition.Memento = clonedKing.SaveMemento();

                                MoveableFigure changeKingsPosition = new MoveableFigure(this.king);
                                changeKingsPosition.MoveFigure(initial);

                                board.Notify(this.king, oldPosition.Memento.Position);
                            }

                            kingsTurn = false;

                            hasWon = HasKingWon();
                            if (hasWon)
                            {
                                Console.WriteLine("King won in {0} turns", countTurns);
                                break;
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            this.PostMessage("Illegal move. Please try again.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            this.PostMessage("Your move is outside the board. Please try again.");
                        }
                        catch (InvalidOperationException)
                        {
                            this.PostMessage("You can't step over a Pawn. Please enter new command.");
                        }
                    }
                    while (kingsTurn);

                    if (hasWon)
                    {
                        break;
                    }
                }
                else
                {
                    do
                    {
                        this.PostMessage("Pawn's turn: ");
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
                                var clonedPawn = chosenPawn.Clone() as Figure;
                                oldPosition.Memento = clonedPawn.SaveMemento();

                                MoveableFigure changePawnsPOsition = new MoveableFigure(chosenPawn);
                                changePawnsPOsition.MoveFigure(initial);

                                board.Notify(chosenPawn, oldPosition.Memento.Position);
                            }

                            kingsTurn = true;


                            hasLost = HasKingLost();
                            if (hasLost)
                            {
                                Console.WriteLine("King lost in {0} turns" + countTurns);
                                break;
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            this.PostMessage("Illegal move. Please try again.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            this.PostMessage("Your move is outside the board. Please try again.");
                        }
                        catch (InvalidOperationException)
                        {
                            this.PostMessage("You can't step over another figure. Please enter new command.");
                        }
                    }
                    while (!kingsTurn);

                    if (hasLost)
                    {
                        break;
                    }
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

            if (Board.Field[newX, newY] != "+")
            {
                throw new InvalidOperationException();
            }

            return true;
        }

        public bool HasKingWon()
        {
            if (this.king.Position.X == 0)
            {
                return true;
            }

            for (int i = 0; i < Board.Field.GetLength(0); i += 2)
            {
                if (Board.Field[Board.Field.GetLength(1) - 1, i] == Board.WhiteCell || Board.Field[Board.Field.GetLength(1) - 1, i] == Board.BlackCell)
                {
                    return false;
                }
            }

            return true;
        }

        public bool HasKingLost()
        {
            var downRight = this.IsCellWhiteOrBlack(this.king.Position.X + 1, this.king.Position.Y + 1);
            var downLeft = this.IsCellWhiteOrBlack(this.king.Position.X + 1, this.king.Position.Y - 1);
            var upRight = this.IsCellWhiteOrBlack(this.king.Position.X - 1, this.king.Position.Y + 1);
            var upLeft = this.IsCellWhiteOrBlack(this.king.Position.X - 1, this.king.Position.Y - 1);
            if (!downRight && !downLeft && !upRight && !upLeft)
            {
                return true;
            }

            return false;
        }

        private bool IsCellWhiteOrBlack(int row, int col)
        {
            if (this.IsPositionInsideBoard(row, col))
            {
                if (Board.Field[row, col] == Board.WhiteCell || Board.Field[row, col] == Board.BlackCell)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsPositionInsideBoard(int row, int col)
        {
            if (row < 0 || row > Board.Field.GetLength(0) - 1 || col < 0 || col > Board.Field.GetLength(1) - 1)
            {
                return false;
            }

            return true;
        }
    }
}
