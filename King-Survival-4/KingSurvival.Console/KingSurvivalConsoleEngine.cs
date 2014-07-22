namespace KingSurvival4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The main class Engine for the console applicatioin; implementing the FACADE pattern
    /// </summary>
    public class KingSurvivalConsoleEngine : KingSurvivalEngine
    {
        public const int MinRowIndex = 0;
        public const int MaxRowIndex = 8;
        public const int MinColumnIndex = 0;
        public const int MaxColumnIndex = 8;

        private Figure firstPawn = FigureGetter.GetFigure(new Position(0, 0), 'A', 'P');
        private Figure secondPawn = FigureGetter.GetFigure(new Position(0, 2), 'B', 'P');
        private Figure thirdPawn = FigureGetter.GetFigure(new Position(0, 4), 'C', 'P');
        private Figure fourthPawn = FigureGetter.GetFigure(new Position(0, 6), 'D', 'P');
        private Figure king = FigureGetter.GetFigure(new Position(7, 3), 'K', 'K');

        private Board board;

        public KingSurvivalConsoleEngine(ConsoleReader reader, ConsoleWriter renderer)
            : base(reader, renderer)
        {
            this.board = Board.Instance;
            this.Figures = new List<Figure>();
            this.Figures.Add(this.firstPawn);
            this.Figures.Add(this.secondPawn);
            this.Figures.Add(this.thirdPawn);
            this.Figures.Add(this.fourthPawn);
            this.Figures.Add(this.king);
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

                        this.PostMessage("King's turn: ");
                        try
                        {
                            var command = new Command(this.GetCommand().ToUpper());
                            Position initial = command.DetermineNewPosition();
                            string kingSymbol = command.FigureLetter;

                            if (kingSymbol != "K")
                            {
                                throw new ArgumentOutOfRangeException();
                            }

                            if (ClearOldFigurePosition(this.king, oldPosition, initial))
                            {
                                countTurns++;
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

                        try
                        {
                            var command = new Command(this.GetCommand().ToUpper());
                            Position initial = command.DetermineNewPosition();
                            Figure chosenPawn = this.firstPawn;
                            string pawnSymbol = command.FigureLetter;
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

                            ClearOldFigurePosition(chosenPawn, oldPosition, initial);

                            kingsTurn = true;


                            hasLost = HasKingLost();
                            if (hasLost)
                            {
                                Console.WriteLine("King lost in {0} turns", countTurns);
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

        private bool ClearOldFigurePosition(Figure figure, ProspectMemory oldPosition, Position initial)
        {
            if (this.IsMoveValid(figure, initial))
            {
                var clonedFigure = figure.Clone() as Figure;
                oldPosition.Memento = clonedFigure.SaveMemento();

                MoveableFigure changeFigurePosition = new MoveableFigure(figure);
                changeFigurePosition.MoveFigure(initial);

                board.Notify(figure, oldPosition.Memento.Position);

                return true;
            }

            return false;
        }

        private bool IsMoveValid(Figure figure, Position direction)
        {
            int newX = figure.Position.X + direction.X;
            int newY = figure.Position.Y + direction.Y;

            if (IsPositionInsideBoard(newX, newY))
            {
                return true;
            }

            return false;
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
            if (col >= MaxColumnIndex || col < MinColumnIndex || row >= MaxRowIndex || row < MinRowIndex)
            {
                throw new IndexOutOfRangeException();
            }

            return true;
        }
    }
}
