namespace KingSurvival.Console
{
    using System;
    using System.Collections.Generic;
    using KingSurvival.Base;
    using KingSurvival.Base.Exceptions;
    using KingSurvival.Base.GameObjects;
    using KingSurvival.Console.InputOutputEngines;

    /// <summary>
    /// The main class Engine for the console application; implementing the FACADE pattern
    /// </summary>
    public class KingSurvivalConsoleEngine : KingSurvivalEngine
    {
        public const int MinRowIndex = 0;
        public const int MaxRowIndex = 8;
        public const int MinColumnIndex = 0;
        public const int MaxColumnIndex = 8;

        private readonly Figure firstPawn = FigureGetter.GetFigure(new Position(0, 0), 'A', "Pawn");
        private readonly Figure secondPawn = FigureGetter.GetFigure(new Position(0, 2), 'B', "Pawn");
        private readonly Figure thirdPawn = FigureGetter.GetFigure(new Position(0, 4), 'C', "Pawn");
        private readonly Figure fourthPawn = FigureGetter.GetFigure(new Position(0, 6), 'D', "Pawn");
        private readonly Figure king = FigureGetter.GetFigure(new Position(7, 3), 'K', "King");

        private readonly Board board;

        private readonly FigureMemory oldPosition = new FigureMemory();
        private int countTurns = 0;
        private bool kingsTurn = true;
        private bool isGameInProgress = true;

        public KingSurvivalConsoleEngine()
            : base(new ConsoleReader(), new ConsoleWriter())
        {
            this.board = Board.Instance;
            this.Figures = new List<Figure>();
            this.Figures.Add(this.firstPawn);
            this.Figures.Add(this.secondPawn);
            this.Figures.Add(this.thirdPawn);
            this.Figures.Add(this.fourthPawn);
            this.Figures.Add(this.king);
        }

        protected override void GameBegins()
        {
            foreach (var figure in this.Figures)
            {
                this.board.Notify(figure);
            }

            bool hasKingWon = false;

            while (this.isGameInProgress)
            {
                this.RenderBoard(Board.Field);

                if (this.kingsTurn)
                {
                    this.WriteMessage(ConsoleMessages.KingsTurnMessage());
                }
                else
                {
                    this.WriteMessage(ConsoleMessages.PawnsTurnMessage());
                }

                do
                {
                    try
                    {
                        Figure currentFigure;
                        var command = new Command(this.GetCommand().ToUpper());
                        var newPosition = Parser.GetNewPosition(command.NewPositionLetters);

                        if (this.kingsTurn)
                        {
                            currentFigure = this.king;

                            string kingSymbol = command.FigureLetter;
                            if (kingSymbol != "K")
                            {
                                throw new InvalidOperationException();
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
                                case "D":
                                    currentFigure = this.thirdPawn;
                                    break;
                                default:
                                    throw new InvalidOperationException();
                            }
                        }

                        this.ChangeFigurePosition(currentFigure, this.oldPosition, newPosition);

                        if (this.kingsTurn)
                        {
                            this.countTurns++;

                            bool hasWon = this.HasKingWon();
                            if (hasWon)
                            {
                                hasKingWon = true;
                                this.isGameInProgress = false;
                                break;
                            }
                        }
                        else
                        {
                            bool hasLost = this.HasKingLost();
                            if (hasLost)
                            {
                                this.isGameInProgress = false;
                                break;
                            }
                        }

                        this.kingsTurn = !this.kingsTurn;
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        this.WriteMessage(ConsoleMessages.InvalidMoveMessage());
                    }
                    catch (IndexOutOfRangeException)
                    {
                        this.WriteMessage(ConsoleMessages.OutsideBoardMoveMessage());
                    }
                    catch (StepOverException)
                    {
                        this.WriteMessage(ConsoleMessages.StepOverFigureMoveMessage());
                    }
                    catch (InvalidOperationException)
                    {
                        this.WriteMessage(ConsoleMessages.WrongFigureCommand());
                    }
                }
                while (true);
            }

            this.GameEnds(hasKingWon);
        }

        protected override void GameEnds(bool hasKingWon)
        {
            this.RenderBoard(Board.Field);

            if (hasKingWon)
            {
                this.WriteMessage(ConsoleMessages.KingWonMessage(this.countTurns));
            }
            else
            {
                this.WriteMessage(ConsoleMessages.KingLostMessage(this.countTurns));
            }
        }

        private bool HasKingWon()
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

        private bool HasKingLost()
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


        private bool ChangeFigurePosition(Figure figure, FigureMemory oldPosition, Position initial)
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

            return false;
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

        private bool IsPositionInsideBoard(int row, int col)
        {
            if (col >= MaxColumnIndex || col < MinColumnIndex || row >= MaxRowIndex || row < MinRowIndex)
            {
                return false;
            }

            return true;
        }
    }
}
