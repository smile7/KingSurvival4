namespace KingSurvival4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The main class Engine for the console application; implementing the FACADE pattern
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

        private ProspectMemory oldPosition = new ProspectMemory();
        private int countTurns = 0;
        private bool kingsTurn = true;

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
            while (true)
            {
                foreach (var figure in this.Figures)
                {
                    this.board.Notify(figure);
                }

                this.RenderBoard(Board.Field);

                this.ExecuteCommand();
                
            }
        }

        private void ExecuteCommand()
        {
            do
            {
                if (this.kingsTurn)
                {
                    this.PostMessage(ConsoleMessages.KingsTurnMessage());
                }
                else
                {
                    this.PostMessage(ConsoleMessages.PawnsTurnMessage());
                }

                try
                {
                    Figure currentFigure;
                    var command = new Command(this.GetCommand().ToUpper());
                    Position initial = command.DetermineNewPosition();

                    if (this.kingsTurn)
                    {
                        currentFigure = this.king;

                        string kingSymbol = command.FigureLetter;
                        if (kingSymbol != "K")
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                    else
                    {
                        string pawnSymbol = command.FigureLetter;
                        switch (pawnSymbol)
                        {
                            case "A":
                                currentFigure = this.firstPawn;
                                break;
                            case "B":
                                currentFigure = this.secondPawn;
                                break;
                            case "C":
                                currentFigure = this.thirdPawn;
                                break;
                            default:
                                currentFigure = this.fourthPawn;
                                break;
                        }
                    }

                    this.ChangeFigurePosition(currentFigure, oldPosition, initial);

                    if (this.kingsTurn)
                    {
                        countTurns++;

                        bool hasWon = this.HasKingWon();
                        if (hasWon)
                        {
                            Console.WriteLine("King won in {0} turns", countTurns);
                            break;
                        }
                    }
                    else
                    {
                        bool hasLost = this.HasKingLost();
                        if (hasLost)
                        {
                            Console.WriteLine("King lost in {0} turns", countTurns);
                            break;
                        }
                    }

                    this.kingsTurn = !this.kingsTurn;
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    this.PostMessage(ConsoleMessages.InvalidMoveMessage());
                }
                catch (IndexOutOfRangeException)
                {
                    this.PostMessage(ConsoleMessages.OutsideBoardMoveMessage());
                }
                catch (StepOverException)
                {
                    this.PostMessage(ConsoleMessages.StepOverFigureMoveMessage());
                }
            }
            while (true);
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
            bool canMoveDownRight = this.IsSurrounded(this.king.Position.X + 1, this.king.Position.Y + 1);
            bool canMoveDownLeft = this.IsSurrounded(this.king.Position.X + 1, this.king.Position.Y - 1);
            bool canMoveUpRight = this.IsSurrounded(this.king.Position.X - 1, this.king.Position.Y + 1);
            bool canMoveUpLeft = this.IsSurrounded(this.king.Position.X - 1, this.king.Position.Y - 1);

            if (!canMoveDownRight && !canMoveDownLeft && !canMoveUpRight && !canMoveUpLeft)
            {
                return true;
            }

            return false;
        }

        private bool IsSurrounded(int row, int col)
        {
            if (this.IsPositionInsideBoard(row, col))
            {
                if (this.HasSteppedOverAnotherFigure(row, col))
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
                return false;
            }

            return true;
        }

        private bool ChangeFigurePosition(Figure figure, ProspectMemory oldPosition, Position initial)
        {
            if (this.IsMoveValid(figure, initial))
            {
                var clonedFigure = figure.Clone() as Figure;
                oldPosition.Memento = clonedFigure.SaveMemento();

                MoveableFigure changeFigurePosition = new MoveableFigure(figure);
                changeFigurePosition.MoveFigure(initial);

                this.board.Notify(figure, oldPosition.Memento.Position);

                return true;
            }

            throw new ArgumentOutOfRangeException();
        }

        private bool IsMoveValid(Figure figure, Position newPosition)
        {
            int newX = figure.Position.X + newPosition.X;
            int newY = figure.Position.Y + newPosition.Y;

            if (this.IsPositionInsideBoard(newX, newY))
            {
                if (this.HasSteppedOverAnotherFigure(newX, newY))
                {
                    return true;
                }

                throw new StepOverException();
            }

            throw new IndexOutOfRangeException();
        }

        private bool HasSteppedOverAnotherFigure(int row, int col)
        {
            if (Board.Field[row, col] == Board.WhiteCell || Board.Field[row, col] == Board.BlackCell)
            {
                return true;
            }

            return false;
        }
    }
}
